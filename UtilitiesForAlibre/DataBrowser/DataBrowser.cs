using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlibreX;
using Bolsover.DataBrowser.Materials;
using BrightIdeasSoftware;

namespace Bolsover.DataBrowser
{
    public partial class DataBrowserForm : Form
    {
        #region privateProperties

        private AlibreFileSystem editingRow;
        private bool IsCopyToAllSelected;
        private readonly ToolTip copySelectedTooltip = new();
        private readonly ToolTip filterTooltip = new();
        private readonly ToolTip saveStateTooltip = new();
        private readonly ToolTip restoreStateTooltip = new();
        private readonly ToolTip partNoTooltip = new();
        private byte[] treeListViewViewState;
        private readonly PartNoConfig.PartNoConfig partNoConfig = new();
        private Point MouseDownLocation; //Reference point for moving part no control
        private static DataBrowserForm instance;

        #endregion


        #region Constructor

        public static DataBrowserForm Instance()
        {
            if (instance == null)
            {
                instance = new DataBrowserForm();
            }

            instance.Visible = true;
            return instance;
        }

        private DataBrowserForm()
        {
            InitializeComponent();
            setupColumns();
            setupTree();
            RegisterCustomEditors();
            SetupToolTips();
            restoreState();
            InitPartNoConfig();
            FormClosing += (sender, args) =>
            {
                ((DataBrowserForm) sender).Visible = false;
                args.Cancel = true;
            };
        }

        #endregion

        #region privateInitialisationMethods

        private void setupTree()
        {
            // TreeListView require two delegates:
            // 1. CanExpandGetter - Can a particular model be expanded?
            // 2. ChildrenGetter - Once the CanExpandGetter returns true, ChildrenGetter should return the list of children
            treeListView.CanExpandGetter = rowObject =>
                ((AlibreFileSystem) rowObject).IsDirectory | ((AlibreFileSystem) rowObject).HasChildren();
            treeListView.ChildrenGetter = rowObject =>
            {
                try
                {
                    if (((AlibreFileSystem) rowObject)
                        .HasChildren()) // return existing children if this branch has already been indexed.
                    {
                        return ((AlibreFileSystem) rowObject).Children;
                    }

                    return ((AlibreFileSystem) rowObject).GetFileSystemInfos();
                }
                catch (UnauthorizedAccessException ex)
                {
                    BeginInvoke((MethodInvoker) delegate { treeListView.Collapse(rowObject); });
                    return new ArrayList();
                }
            };

            var roots = new ArrayList();
            foreach (var di in DriveInfo.GetDrives())
            {
                if (di.IsReady)
                {
                    var alFileSystem = new AlibreFileSystem(new DirectoryInfo(di.Name));
                    roots.Add(alFileSystem);
                }
            }

            treeListView.Roots = roots;
            treeListView.CellEditStarting += HandleCellEditStarting;
            treeListView.CellEditFinished += HandleCellEditFinished;

            // apply some style
            var font = treeListView.Font;
            var headerFont = new Font(font, FontStyle.Bold);
            var style = new HeaderFormatStyle();
            style.SetFont(headerFont);
            style.SetForeColor(Color.Navy);
            treeListView.HeaderFormatStyle = style;
        }

        private void InitPartNoConfig()
        {
            partNoConfig.MouseDown += partNoConfigMouseDown;
            partNoConfig.MouseMove += partNoConfigMouseMove;
            partNoConfig.Location = new Point(50, 50);
            Controls.Add(partNoConfig);
            partNoConfig.Hide();
        }


        /*
         * Setup ToolTips
         */
        private void SetupToolTips()
        {
            copySelectedTooltip.SetToolTip(checkBoxCopy,
                "When selected, values entered in one field will be copied to all applicable fields in same column.");
            filterTooltip.SetToolTip(checkBoxFilter,
                "When selected, the tree is filtered to show only Alibre files.");
            saveStateTooltip.SetToolTip(buttonSaveState,
                "Saves column layout to file.");
            restoreStateTooltip.SetToolTip(buttonRestoreState,
                "Restores column layout from file.");
            partNoTooltip.SetToolTip(buttonPartNo,
                "Opens the Part Numbering control.");
        }

        /// <summary>
        /// Helper method to cast object Types
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="castTo"></param>
        /// <returns></returns>
        private static dynamic Cast(dynamic obj, Type castTo)
        {
            return Convert.ChangeType(obj, castTo);
        }


        /*
         * Set up column AspectPutters and AspectGetters
         */
        private void setupColumns()
        {
            ConfigureAspectGetters();
            ConfigureAspectPutters();
        }

        /*
         * Register custom editors for DateTime columns and the Material column.
         * All other columns use string types
         */
        private void RegisterCustomEditors()
        {
            // Register DateTime picker
            ObjectListView.EditorRegistry.Register(typeof(DateTime), delegate
            {
                var c = new DateTimePicker();
                c.Format = DateTimePickerFormat.Short;
                return c;
            });

            // Register MaterialPicker for use exclusively with olvColumnAlibreMaterial
            ObjectListView.EditorRegistry.Register(typeof(string), (model, column, value) =>
            {
                if (column == olvColumnAlibreMaterial)
                {
                    var mc = new MaterialPicker(value.ToString());
                    mc.ItemHasBeenSelected += McOnItemHasBeenSelected;
                    return mc;
                }

                return null;
            });
        }

        #endregion

        #region AspectPutters

        /// <summary>
        /// Configures the MaterialAspectPutter.
        /// This is a special case because the designProperty for Material is actually populated with the IADMaterial Material
        /// GUID value. This value is never shown by Alibre which always shows the corresponding name of the Material.
        /// This method therefore saves the designProperty for Material GUID and closes the design session updating the Alibre
        /// file with the selected material. The editing row is then updated with the actual material name but this is not saved.
        /// </summary>
        private void ConfigureAlibreMaterialAspectPutter()
        {
            olvColumnAlibreMaterial.AspectPutter = (editingRow, value) =>
            {
                if (value.GetType() == typeof(MaterialNode))
                {
                    Console.WriteLine(value);
                    var designSession = AlibreConnector.RetrieveSessionForFile((AlibreFileSystem) editingRow);
                    var designProperties = designSession.DesignProperties;
                    designProperties.Material = ((MaterialNode) value).Guid;
                    ((AlibreFileSystem) editingRow).AlibreMaterialGuid = ((MaterialNode) value).Guid;

                    try
                    {
                        designSession.Close(true);
                        ((AlibreFileSystem) editingRow).AlibreMaterial = ((MaterialNode) value).NodeName;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            };
        }

        /*
         * Configures AspectPutter methods for individual columns with the exception of extended deign property for Materials
         * The extended deign property for material is overwritten whenever the user selects a Material design property.
         * Alibre would flag a warning if the user attempted update of the Material design property if this would overwrite
         * the extended deign property.
         */
        private void ConfigureAspectPutters()
        {
            ConfigreAlibreDescriptionAspectPutter();
            ConfigreAlibrePartNoAspectPutter();
            ConfigureAlibreModifiedAspectPutter();
            ConfigureAlibreMaterialAspectPutter();
            ConfigureColumnAspectPutter(olvColumnAlibreComment, ADExtendedDesignProperty.AD_COMMENT, typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreCreatedDate, ADExtendedDesignProperty.AD_CREATED_DATE,
                typeof(DateTime));
            // ConfigureColumnAspectPutter(olvColumnAlibreMaterial, ADExtendedDesignProperty.AD_MATERIAL, typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreCostCenter, ADExtendedDesignProperty.AD_COST_CENTER,
                typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreCreatedBy, ADExtendedDesignProperty.AD_CREATED_BY,
                typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreCreatingApplication,
                ADExtendedDesignProperty.AD_CREATING_APPLICATION, typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreDocumentNumber, ADExtendedDesignProperty.AD_DOCUMENT_NUMBER,
                typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreEngApprovalDate, ADExtendedDesignProperty.AD_ENG_APPROVAL_DATE,
                typeof(DateTime));
            ConfigureColumnAspectPutter(olvColumnAlibreEngApprovedBy, ADExtendedDesignProperty.AD_ENG_APPROVED_BY,
                typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreEstimatedCost, ADExtendedDesignProperty.AD_ESTIMATED_COST,
                typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreKeywords, ADExtendedDesignProperty.AD_KEYWORDS, typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreLastAuthor, ADExtendedDesignProperty.AD_LAST_AUTHOR,
                typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreLastUpdateDate, ADExtendedDesignProperty.AD_LAST_UPDATE_DATE,
                typeof(DateTime));
            ConfigureColumnAspectPutter(olvColumnAlibreMfgApprovedBy, ADExtendedDesignProperty.AD_MFG_APPROVED_BY,
                typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreMfgApprovedDate, ADExtendedDesignProperty.AD_MFG_APPROVED_DATE,
                typeof(DateTime));
            ConfigureColumnAspectPutter(olvColumnAlibreProduct, ADExtendedDesignProperty.AD_PRODUCT, typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreReceivedFrom, ADExtendedDesignProperty.AD_RECEIVED_FROM,
                typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreRevision, ADExtendedDesignProperty.AD_REVISION, typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreStockSize, ADExtendedDesignProperty.AD_STOCK_SIZE,
                typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreSupplier, ADExtendedDesignProperty.AD_SUPPLIER, typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreTitle, ADExtendedDesignProperty.AD_TITLE, typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreVendor, ADExtendedDesignProperty.AD_VENDOR, typeof(string));
            ConfigureColumnAspectPutter(olvColumnAlibreWebLink, ADExtendedDesignProperty.AD_WEBLINK, typeof(string));
        }


        /*
         * Configures AspectPutters based on the column, extendedDesignProperty and Type
         * OLVColumn column: The column to be configured
         * ADExtendedDesignProperty extendedDesignProperty: the property against which a value is put.
         * Type type: The Type of property being put.
         */
        private void ConfigureColumnAspectPutter(OLVColumn column, ADExtendedDesignProperty extendedDesignProperty,
            Type type)
        {
            column.AspectPutter = (rowObject, value) =>
            {
                var session = AlibreConnector.RetrieveSessionForFile((AlibreFileSystem) rowObject);
                var designProperties = session.DesignProperties;
                switch (extendedDesignProperty)
                {
                    case ADExtendedDesignProperty.AD_WEBLINK:
                        ((AlibreFileSystem) rowObject).AlibreWebLink = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_VENDOR:
                        ((AlibreFileSystem) rowObject).AlibreVendor = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_MFG_APPROVED_DATE:
                        ((AlibreFileSystem) rowObject).AlibreMfgApprovedDate = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_COMMENT:
                        ((AlibreFileSystem) rowObject).AlibreComment = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_CREATED_DATE:
                        ((AlibreFileSystem) rowObject).AlibreCreatedDate = Cast(value, type);
                        break;

                    case ADExtendedDesignProperty.AD_MATERIAL:
                        ((AlibreFileSystem) rowObject).AlibreExtMaterial = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_COST_CENTER:
                        ((AlibreFileSystem) rowObject).AlibreCostCenter = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_CREATED_BY:
                        ((AlibreFileSystem) rowObject).AlibreCreatedBy = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_CREATING_APPLICATION:
                        ((AlibreFileSystem) rowObject).AlibreCreatingApplication = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_DOCUMENT_NUMBER:
                        ((AlibreFileSystem) rowObject).AlibreDocumentNumber = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_ENG_APPROVAL_DATE:
                        ((AlibreFileSystem) rowObject).AlibreEngApprovalDate = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_ENG_APPROVED_BY:
                        ((AlibreFileSystem) rowObject).AlibreEngApprovedBy = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_ESTIMATED_COST:
                        ((AlibreFileSystem) rowObject).AlibreEstimatedCost = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_KEYWORDS:
                        ((AlibreFileSystem) rowObject).AlibreKeywords = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_LAST_AUTHOR:
                        ((AlibreFileSystem) rowObject).AlibreLastAuthor = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_MFG_APPROVED_BY:
                        ((AlibreFileSystem) rowObject).AlibreMfgApprovedBy = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_PRODUCT:
                        ((AlibreFileSystem) rowObject).AlibreProduct = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_RECEIVED_FROM:
                        ((AlibreFileSystem) rowObject).AlibreReceivedFrom = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_REVISION:
                        ((AlibreFileSystem) rowObject).AlibreRevision = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_STOCK_SIZE:
                        ((AlibreFileSystem) rowObject).AlibreStockSize = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_SUPPLIER:
                        ((AlibreFileSystem) rowObject).AlibreSupplier = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_TITLE:
                        ((AlibreFileSystem) rowObject).AlibreTitle = Cast(value, type);
                        break;
                    case ADExtendedDesignProperty.AD_LAST_UPDATE_DATE:
                        ((AlibreFileSystem) rowObject).AlibreLastUpdateDate = Cast(value, type);
                        break;
                }

                if (type == typeof(DateTime))
                {
                    value = ((DateTime) value).Date.ToShortDateString();
                    designProperties.ExtendedDesignProperty(extendedDesignProperty, value);
                }
                else
                {
                    designProperties.ExtendedDesignProperty(extendedDesignProperty, Cast(value, type));
                }

                session.Close(true);
            };
        }


        /*
         * Configures the AspectPutter for the Modified column.
         * 
         */
        private void ConfigureAlibreModifiedAspectPutter()
        {
            olvColumnAlibreModified.AspectPutter = (rowObject, value) =>
            {
                ((AlibreFileSystem) rowObject).AlibreModified = (DateTime) value;
                var session = AlibreConnector.RetrieveSessionForFile((AlibreFileSystem) rowObject);

                var designProperties = session.DesignProperties;
                designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_MODIFIED,
                    ((DateTime) value).Date.ToShortDateString());
                try
                {
                    session.Close(true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            };
        }


        /*
         * Configures the AspectPutter for the Part No column
         */
        private void ConfigreAlibrePartNoAspectPutter()
        {
            olvColumnAlibrePartNo.AspectPutter = (rowObject, value) =>
            {
                ((AlibreFileSystem) rowObject).AlibrePartNo = (string) value;
                if (((AlibreFileSystem) rowObject).Info.Extension.ToUpper().StartsWith(".AD_D"))
                {
                    var session = AlibreConnector.RetrieveDrawingSessionForFile((AlibreFileSystem) rowObject);
                    var designProperties = session.Properties;
                    designProperties.Number = (string) value;

                    try
                    {
                        session.Close(true);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                else
                {
                    var session = AlibreConnector.RetrieveSessionForFile((AlibreFileSystem) rowObject);
                    var designProperties = session.DesignProperties;
                    designProperties.Number = (string) value;

                    try
                    {
                        session.Close(true);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            };
        }


        /*
         * Configures the AspectPutter for the Description column
         */
        private void ConfigreAlibreDescriptionAspectPutter()
        {
            olvColumnAlibreDescription.AspectPutter = (rowObject, value) =>
            {
                ((AlibreFileSystem) rowObject).AlibreDescription = (string) value;
                if (((AlibreFileSystem) rowObject).Info.Extension.ToUpper().StartsWith(".AD_D"))
                {
                    var session = AlibreConnector.RetrieveDrawingSessionForFile((AlibreFileSystem) rowObject);
                    var designProperties = session.Properties;
                    designProperties.Description = (string) value;

                    try
                    {
                        session.Close(true);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                else
                {
                    var session = AlibreConnector.RetrieveSessionForFile((AlibreFileSystem) rowObject);
                    var designProperties = session.DesignProperties;
                    designProperties.Description = (string) value;

                    try
                    {
                        session.Close(true);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            };
        }

        #endregion

        #region AspectGetters

        /// <summary>
        ///Configures all the AspectGetter methods for individual columns
        /// 
        /// </summary>
        private void ConfigureAspectGetters()
        {
            var helper = new SysImageListHelper(treeListView);
            olvColumnName.ImageGetter = rowObject => helper.GetImageIndex(((AlibreFileSystem) rowObject).FullName);
            olvColumnType.AspectGetter =
                rowObject => ShellUtilities.GetFileType(((AlibreFileSystem) rowObject).FullName);
            olvColumnModified.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).Info.LastWriteTime;
            olvColumnAlibreDescription.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreDescription;
            olvColumnAlibrePartNo.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibrePartNo;
            olvColumnAlibreMaterial.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreMaterial;
            //  olvColumnAlibreExtMaterial.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreExtMaterial;
            olvColumnAlibreComment.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreComment;
            olvColumnAlibreCostCenter.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreCostCenter;
            olvColumnAlibreCreatedBy.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreCreatedBy;
            olvColumnAlibreCreatedDate.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreCreatedDate;
            olvColumnAlibreCreatingApplication.AspectGetter =
                rowObject => ((AlibreFileSystem) rowObject).AlibreCreatingApplication;
            olvColumnAlibreDocumentNumber.AspectGetter =
                rowObject => ((AlibreFileSystem) rowObject).AlibreDocumentNumber;
            olvColumnAlibreEngApprovalDate.AspectGetter =
                rowObject => ((AlibreFileSystem) rowObject).AlibreEngApprovalDate;
            olvColumnAlibreEngApprovedBy.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreEngApprovedBy;
            olvColumnAlibreEstimatedCost.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreEstimatedCost;
            olvColumnAlibreKeywords.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreKeywords;
            olvColumnAlibreLastAuthor.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreLastAuthor;
            olvColumnAlibreLastUpdateDate.AspectGetter =
                rowObject => ((AlibreFileSystem) rowObject).AlibreLastUpdateDate;
            olvColumnAlibreMfgApprovedBy.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreMfgApprovedBy;
            olvColumnAlibreMfgApprovedDate.AspectGetter =
                rowObject => ((AlibreFileSystem) rowObject).AlibreMfgApprovedDate;
            olvColumnAlibreModified.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreModified;
            olvColumnAlibreProduct.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreProduct;
            olvColumnAlibreReceivedFrom.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreReceivedFrom;
            olvColumnAlibreRevision.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreRevision;
            olvColumnAlibreStockSize.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreStockSize;
            olvColumnAlibreSupplier.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreSupplier;
            olvColumnAlibreTitle.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreTitle;
            olvColumnAlibreVendor.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreVendor;
            olvColumnAlibreWebLink.AspectGetter = rowObject => ((AlibreFileSystem) rowObject).AlibreWebLink;
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Filters the table for files with extension starting with .AD_
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFilter.Checked)
            {
                treeListView.ModelFilter = new ModelFilter(rowObject =>
                {
                    if (((AlibreFileSystem) rowObject).IsDirectory)
                    {
                        return true;
                    }

                    return ((AlibreFileSystem) rowObject).Info.Extension.StartsWith(".AD_");
                });
            }
            else
            {
                treeListView.ModelFilter = new ModelFilter(rowObject => { return true; });
            }
        }

        /// <summary>
        /// Sets the value of IsCopyToAllSelected bool.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxCopy_CheckedChanged(object sender, EventArgs e)
        {
            IsCopyToAllSelected = ((CheckBox) sender).Checked;
        }

        /// <summary>
        /// Saves the layout of table columns to file.
        /// File is %AppData%\DataBrowser\table.settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveState_Click(object sender, EventArgs e)
        {
            treeListViewViewState = treeListView.SaveState();
            var directorypath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                "\\UtilitiesForAlibre";
            var filepath = directorypath + "\\table.settings";
            var directoryInfo = new DirectoryInfo(directorypath);
            if (!directoryInfo.Exists)
            {
                Directory.CreateDirectory(directorypath);
            }

            File.WriteAllBytes(filepath, treeListViewViewState);
        }

        /// <summary>
        /// Restores the treeListViewViewState from that previously saved to disk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRestoreState_Click(object sender, EventArgs e)
        {
            restoreState();
        }

        /// <summary>
        /// Activates part no control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPartNo_Click(object sender, EventArgs e)
        {
            partNoConfig.SelectedItems = treeListView.CheckedObjects;
            partNoConfig.Show();
            partNoConfig.BringToFront();
        }


        /// <summary>
        /// Used for positioning of part no control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void partNoConfigMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        /// <summary>
        /// Used for positioning of part no control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void partNoConfigMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                partNoConfig.Left = e.X + partNoConfig.Left - MouseDownLocation.X;
                partNoConfig.Top = e.Y + partNoConfig.Top - MouseDownLocation.Y;
            }
        }

        /// <summary>
        /// Retrieves the MaterialNode selected in the MaterialPicker.
        /// Obtains the IADDesignSession and IADDesignProperties for the row being edited.
        /// Updates the IADDesignProperties.Material with the Guid from the Material.
        /// Saves the IADDesignSession.
        /// Resets the AlibreMaterial property of the row being edited with the Name of the Material.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void McOnItemHasBeenSelected(object sender, MaterialPicker.SelectedItemEventArgs selectedItemEventArgs)
        {
            try
            {
                var materialNode = selectedItemEventArgs.SelectedChoice;
                olvColumnAlibreMaterial.AspectPutter.Invoke(editingRow, materialNode);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        /// Cell edit finished is used as a trigger to check if the cell contents should be copied to other cells in same column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCellEditFinished(object sender, CellEditEventArgs e)
        {
            if (IsCopyToAllSelected)
            {
                CopyToSelected(sender, e);
            }
        }


        /// <summary>
        /// Handle CellEditStarting
        /// Set editingRow field to correspond to the row being edited.
        /// Cancel edit and return if the row is a directory.
        /// Cancel edit and return if the row is not checked.
        /// Cancel edit and return if row is not a Part, Assembly or Sheet Metal design
        /// Fix up the cell edit control bounds - special attention to MaterialPicker
        /// Cancel edit and return if row is locked - probably open in Alibre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCellEditStarting(object sender, CellEditEventArgs e)
        {
            var rowObject = (AlibreFileSystem) e.RowObject;
            editingRow = rowObject;

            // directory items are not editable
            if (rowObject.IsDirectory)
            {
                e.Cancel = true;
                return;
            }

            // only checked items should be editable
            if (!rowObject.IsChecked)
            {
                e.Cancel = true;
                return;
            }

            // prevent edits to anything other than sheet metal, part and assembly abd drawing types
            var extension = rowObject.Info.Extension.ToUpper();
            if (!(rowObject.Info.Extension.ToUpper().StartsWith(".AD_P") |
                  rowObject.Info.Extension.ToUpper().StartsWith(".AD_A") |
                  rowObject.Info.Extension.ToUpper().StartsWith(".AD_S") |
                  rowObject.Info.Extension.ToUpper().StartsWith(".AD_D")))
            {
                e.Cancel = true;
                return;
            }

            // drawing can only edit description and part no fields
            if (rowObject.Info.Extension.ToUpper().StartsWith(".AD_D"))
            {
                if (!(e.Column == olvColumnAlibreDescription || e.Column == olvColumnAlibrePartNo))
                {
                    e.Cancel = true;
                    return;
                }
            }


            // olvColumnAlibreMaterial uses MaterialPicker other string based columns use default editor
            if (e.Column != olvColumnAlibreMaterial)
            {
                // fix up size of cell editor
                e.Control.Bounds = e.CellBounds;
            }
            else
            {
                if (!(rowObject.Info.Extension.ToUpper().StartsWith(".AD_P") |
                      rowObject.Info.Extension.ToUpper().StartsWith(".AD_S")))
                {
                    e.Cancel = true;
                    return;
                }

                e.Control.Bounds = new Rectangle(e.CellBounds.X, e.CellBounds.Y, 250, 300);
            }

            // prevent editing locked files
            if (IsFileLocked(rowObject.AsFile))
            {
                e.Cancel = true;
                var message = "File Locked - Probably Open in Alibre.";
                var title = "File Locked";
                MessageBox.Show(message, title);
            }

            Debug.WriteLine(sender);
        }

        #endregion

        #region PrivateAndProtectedMethods

        /// <summary>
        /// Method to copy info from one cell to other cells in the same column where the row is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyToSelected(object sender, CellEditEventArgs e)
        {
            UseWaitCursor = true;
            var copyAction = new Action<CellEditEventArgs, IList>(CopySelected);
            var task = new Task(() => copyAction(e, treeListView.CheckedObjects));
            task.Start();
        }

        /// <summary>
        /// Method used by CopyAction.
        /// Iterates through all the checked records and invokes the appropriate OLVColumn AspectPutter.
        /// Note that updates to Material are treated as a special case.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="checkedObjects"></param>
        private void CopySelected(CellEditEventArgs e, IList checkedObjects)
        {
            foreach (var checkedObject in checkedObjects)
            {
                var rowObject = (AlibreFileSystem) checkedObject;
                if (e.Column == olvColumnAlibreMaterial && rowObject.Info.Extension.ToUpper().StartsWith(".AD_P") |
                    rowObject.Info.Extension.ToUpper().StartsWith(".AD_S"))
                {
                    var afs = (AlibreFileSystem) e.RowObject;
                    var materialNode = new MaterialNode(afs.AlibreMaterial);
                    materialNode.Guid = afs.AlibreMaterialGuid;
                    progressLabel.Text = "Copy to " + rowObject.Name;
                    e.Column.AspectPutter.Invoke(rowObject, materialNode);
                    treeListView.Refresh();
                }

                else
                {
                    if (rowObject.Info.Extension.ToUpper().StartsWith(".AD_P") |
                        rowObject.Info.Extension.ToUpper().StartsWith(".AD_A") |
                        rowObject.Info.Extension.ToUpper().StartsWith(".AD_S") |
                        rowObject.Info.Extension.ToUpper().StartsWith(".AD_D"))
                    {
                        progressLabel.Text = "Copy to " + rowObject.Name;
                        e.Column.AspectPutter.Invoke(rowObject, e.NewValue);
                        treeListView.Refresh();
                    }
                }
            }

            progressLabel.Text = "Copy complete ";
            UseWaitCursor = false;
        }

        /*
         * Utility to check if file is locked or open elsewhere
         */
        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }


        /*
         * Restores the layout of table columns from those previously saved to file.
         * File is %AppData%\DataBrowser\table.settings
         */
        private void restoreState()
        {
            var directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                "\\UtilitiesForAlibre";
            var directoryInfo = new DirectoryInfo(directoryPath);
            if (!directoryInfo.Exists)
            {
                Directory.CreateDirectory(directoryPath);
            }

            var filepath = directoryPath + "\\table.settings";
            var fileInfo = new FileInfo(filepath);
            if (fileInfo.Exists)
            {
                treeListViewViewState = File.ReadAllBytes(filepath);
                treeListView.RestoreState(treeListViewViewState);
            }
        }

        #endregion
    }
}