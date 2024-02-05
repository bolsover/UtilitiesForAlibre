using System.ComponentModel;

namespace Bolsover.DataBrowser{
    partial class DataBrowserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeListView = new BrightIdeasSoftware.TreeListView();
            this.olvColumnName = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnType = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnModified = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreDescription = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibrePartNo = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreMaterial = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreComment = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreLastUpdateDate = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreLastAuthor = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreKeywords = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreEstimatedCost = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreEngApprovedBy = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreEngApprovalDate = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreDocumentNumber = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreCreatingApplication = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreCreatedDate = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreCreatedBy = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreCostCenter = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreMfgApprovedBy = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreMfgApprovedDate = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreModified = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreProduct = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreReceivedFrom = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreRevision = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreStockSize = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreSupplier = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreTitle = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreVendor = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnAlibreWebLink = new BrightIdeasSoftware.OLVColumn();
            this.checkBoxFilter = new System.Windows.Forms.CheckBox();
            this.checkBoxCopy = new System.Windows.Forms.CheckBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.buttonSaveState = new System.Windows.Forms.Button();
            this.buttonRestoreState = new System.Windows.Forms.Button();
            this.buttonPartNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListView
            // 
            this.treeListView.AllColumns.Add(this.olvColumnName);
            this.treeListView.AllColumns.Add(this.olvColumnType);
            this.treeListView.AllColumns.Add(this.olvColumnModified);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreDescription);
            this.treeListView.AllColumns.Add(this.olvColumnAlibrePartNo);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreMaterial);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreComment);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreLastUpdateDate);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreLastAuthor);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreKeywords);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreEstimatedCost);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreEngApprovedBy);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreEngApprovalDate);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreDocumentNumber);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreCreatingApplication);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreCreatedDate);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreCreatedBy);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreCostCenter);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreMfgApprovedBy);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreMfgApprovedDate);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreModified);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreProduct);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreReceivedFrom);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreRevision);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreStockSize);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreSupplier);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreTitle);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreVendor);
            this.treeListView.AllColumns.Add(this.olvColumnAlibreWebLink);
            this.treeListView.AllowColumnReorder = true;
            this.treeListView.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.treeListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.treeListView.CellEditUseWholeCell = false;
            this.treeListView.CellVerticalAlignment = System.Drawing.StringAlignment.Near;
            this.treeListView.CheckBoxes = true;
            this.treeListView.CheckedAspectName = "IsChecked";
            this.treeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.olvColumnName, this.olvColumnType, this.olvColumnModified, this.olvColumnAlibreDescription, this.olvColumnAlibrePartNo, this.olvColumnAlibreMaterial, this.olvColumnAlibreComment, this.olvColumnAlibreLastUpdateDate, this.olvColumnAlibreLastAuthor, this.olvColumnAlibreKeywords, this.olvColumnAlibreEstimatedCost, this.olvColumnAlibreEngApprovedBy, this.olvColumnAlibreEngApprovalDate, this.olvColumnAlibreDocumentNumber, this.olvColumnAlibreCreatingApplication, this.olvColumnAlibreCreatedDate, this.olvColumnAlibreCreatedBy, this.olvColumnAlibreCostCenter, this.olvColumnAlibreMfgApprovedBy, this.olvColumnAlibreMfgApprovedDate, this.olvColumnAlibreModified, this.olvColumnAlibreProduct, this.olvColumnAlibreReceivedFrom, this.olvColumnAlibreRevision, this.olvColumnAlibreStockSize, this.olvColumnAlibreSupplier, this.olvColumnAlibreTitle, this.olvColumnAlibreVendor, this.olvColumnAlibreWebLink });
            this.treeListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.treeListView.GridLines = true;
            this.treeListView.HideSelection = false;
            this.treeListView.HierarchicalCheckboxes = true;
            this.treeListView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeListView.Location = new System.Drawing.Point(16, 15);
            this.treeListView.Margin = new System.Windows.Forms.Padding(5);
            this.treeListView.Name = "treeListView";
            this.treeListView.ShowCommandMenuOnRightClick = true;
            this.treeListView.ShowGroups = false;
            this.treeListView.ShowImagesOnSubItems = true;
            this.treeListView.Size = new System.Drawing.Size(1451, 773);
            this.treeListView.TabIndex = 0;
            this.treeListView.TintSortColumn = true;
            this.treeListView.UseCompatibleStateImageBehavior = false;
            this.treeListView.UseFilterIndicator = true;
            this.treeListView.UseFiltering = true;
            this.treeListView.UseHotItem = true;
            this.treeListView.View = System.Windows.Forms.View.Details;
            this.treeListView.VirtualMode = true;
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "Name";
            this.olvColumnName.IsEditable = false;
            this.olvColumnName.IsTileViewColumn = true;
            this.olvColumnName.Text = "Name";
            this.olvColumnName.Width = 180;
            // 
            // olvColumnType
            // 
            this.olvColumnType.IsEditable = false;
            this.olvColumnType.Text = "Type";
            this.olvColumnType.Width = 125;
            // 
            // olvColumnModified
            // 
            this.olvColumnModified.IsEditable = false;
            this.olvColumnModified.Text = "Date modified";
            this.olvColumnModified.Width = 100;
            // 
            // olvColumnAlibreDescription
            // 
            this.olvColumnAlibreDescription.CellEditUseWholeCell = true;
            this.olvColumnAlibreDescription.Text = "Description";
            this.olvColumnAlibreDescription.Width = 250;
            // 
            // olvColumnAlibrePartNo
            // 
            this.olvColumnAlibrePartNo.Text = "Part #";
            this.olvColumnAlibrePartNo.Width = 100;
            // 
            // olvColumnAlibreMaterial
            // 
            this.olvColumnAlibreMaterial.ButtonMaxWidth = 20;
            this.olvColumnAlibreMaterial.Text = "Material";
            this.olvColumnAlibreMaterial.Width = 100;
            // 
            // olvColumnAlibreComment
            // 
            this.olvColumnAlibreComment.Text = "Comment";
            this.olvColumnAlibreComment.Width = 100;
            // 
            // olvColumnAlibreLastUpdateDate
            // 
            this.olvColumnAlibreLastUpdateDate.Text = "Last Update Date";
            this.olvColumnAlibreLastUpdateDate.Width = 100;
            // 
            // olvColumnAlibreLastAuthor
            // 
            this.olvColumnAlibreLastAuthor.Text = "Last Author";
            this.olvColumnAlibreLastAuthor.Width = 100;
            // 
            // olvColumnAlibreKeywords
            // 
            this.olvColumnAlibreKeywords.Text = "Keywords";
            this.olvColumnAlibreKeywords.Width = 100;
            // 
            // olvColumnAlibreEstimatedCost
            // 
            this.olvColumnAlibreEstimatedCost.Text = "Estimated Cost";
            this.olvColumnAlibreEstimatedCost.Width = 100;
            // 
            // olvColumnAlibreEngApprovedBy
            // 
            this.olvColumnAlibreEngApprovedBy.Text = "Eng ApprovalBy";
            this.olvColumnAlibreEngApprovedBy.Width = 100;
            // 
            // olvColumnAlibreEngApprovalDate
            // 
            this.olvColumnAlibreEngApprovalDate.Text = "Eng Approved Date";
            this.olvColumnAlibreEngApprovalDate.Width = 100;
            // 
            // olvColumnAlibreDocumentNumber
            // 
            this.olvColumnAlibreDocumentNumber.Text = "Document Number";
            this.olvColumnAlibreDocumentNumber.Width = 100;
            // 
            // olvColumnAlibreCreatingApplication
            // 
            this.olvColumnAlibreCreatingApplication.Text = "Creating Application";
            this.olvColumnAlibreCreatingApplication.Width = 100;
            // 
            // olvColumnAlibreCreatedDate
            // 
            this.olvColumnAlibreCreatedDate.Text = "Created Date";
            this.olvColumnAlibreCreatedDate.Width = 100;
            // 
            // olvColumnAlibreCreatedBy
            // 
            this.olvColumnAlibreCreatedBy.Text = "Created By";
            this.olvColumnAlibreCreatedBy.Width = 100;
            // 
            // olvColumnAlibreCostCenter
            // 
            this.olvColumnAlibreCostCenter.Text = "Cost Center";
            this.olvColumnAlibreCostCenter.Width = 100;
            // 
            // olvColumnAlibreMfgApprovedBy
            // 
            this.olvColumnAlibreMfgApprovedBy.Text = "Mfg Approved By";
            this.olvColumnAlibreMfgApprovedBy.Width = 100;
            // 
            // olvColumnAlibreMfgApprovedDate
            // 
            this.olvColumnAlibreMfgApprovedDate.Text = "Mfg Approved Date";
            this.olvColumnAlibreMfgApprovedDate.Width = 100;
            // 
            // olvColumnAlibreModified
            // 
            this.olvColumnAlibreModified.Text = "Modified";
            this.olvColumnAlibreModified.Width = 100;
            // 
            // olvColumnAlibreProduct
            // 
            this.olvColumnAlibreProduct.Text = "Product";
            this.olvColumnAlibreProduct.Width = 100;
            // 
            // olvColumnAlibreReceivedFrom
            // 
            this.olvColumnAlibreReceivedFrom.Text = "Received From";
            this.olvColumnAlibreReceivedFrom.Width = 100;
            // 
            // olvColumnAlibreRevision
            // 
            this.olvColumnAlibreRevision.Text = "Revision";
            this.olvColumnAlibreRevision.Width = 100;
            // 
            // olvColumnAlibreStockSize
            // 
            this.olvColumnAlibreStockSize.Text = "Stock Size";
            this.olvColumnAlibreStockSize.Width = 100;
            // 
            // olvColumnAlibreSupplier
            // 
            this.olvColumnAlibreSupplier.Text = "Supplier";
            this.olvColumnAlibreSupplier.Width = 100;
            // 
            // olvColumnAlibreTitle
            // 
            this.olvColumnAlibreTitle.Text = "Title";
            this.olvColumnAlibreTitle.Width = 100;
            // 
            // olvColumnAlibreVendor
            // 
            this.olvColumnAlibreVendor.Text = "Vendor";
            this.olvColumnAlibreVendor.Width = 100;
            // 
            // olvColumnAlibreWebLink
            // 
            this.olvColumnAlibreWebLink.Text = "Web Link";
            this.olvColumnAlibreWebLink.Width = 100;
            // 
            // checkBoxFilter
            // 
            this.checkBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFilter.Location = new System.Drawing.Point(1263, 796);
            this.checkBoxFilter.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxFilter.Name = "checkBoxFilter";
            this.checkBoxFilter.Size = new System.Drawing.Size(205, 35);
            this.checkBoxFilter.TabIndex = 4;
            this.checkBoxFilter.Text = "Filter For Alibre Designs";
            this.checkBoxFilter.UseVisualStyleBackColor = true;
            this.checkBoxFilter.CheckedChanged += new System.EventHandler(this.checkBoxFilter_CheckedChanged);
            // 
            // checkBoxCopy
            // 
            this.checkBoxCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxCopy.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.checkBoxCopy.Location = new System.Drawing.Point(1085, 795);
            this.checkBoxCopy.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCopy.Name = "checkBoxCopy";
            this.checkBoxCopy.Size = new System.Drawing.Size(171, 35);
            this.checkBoxCopy.TabIndex = 5;
            this.checkBoxCopy.Text = "Copy to All Selected";
            this.checkBoxCopy.UseVisualStyleBackColor = true;
            this.checkBoxCopy.CheckedChanged += new System.EventHandler(this.checkBoxCopy_CheckedChanged);
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressLabel.Location = new System.Drawing.Point(16, 800);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(381, 35);
            this.progressLabel.TabIndex = 6;
            this.progressLabel.Text = "Progress";
            // 
            // buttonSaveState
            // 
            this.buttonSaveState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveState.Location = new System.Drawing.Point(869, 794);
            this.buttonSaveState.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveState.Name = "buttonSaveState";
            this.buttonSaveState.Size = new System.Drawing.Size(100, 35);
            this.buttonSaveState.TabIndex = 7;
            this.buttonSaveState.Text = "Save State";
            this.buttonSaveState.UseVisualStyleBackColor = true;
            this.buttonSaveState.Click += new System.EventHandler(this.buttonSaveState_Click);
            // 
            // buttonRestoreState
            // 
            this.buttonRestoreState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRestoreState.Location = new System.Drawing.Point(977, 794);
            this.buttonRestoreState.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRestoreState.Name = "buttonRestoreState";
            this.buttonRestoreState.Size = new System.Drawing.Size(100, 35);
            this.buttonRestoreState.TabIndex = 8;
            this.buttonRestoreState.Text = "Restore State";
            this.buttonRestoreState.UseVisualStyleBackColor = true;
            this.buttonRestoreState.Click += new System.EventHandler(this.buttonRestoreState_Click);
            // 
            // buttonPartNo
            // 
            this.buttonPartNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPartNo.Location = new System.Drawing.Point(697, 794);
            this.buttonPartNo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPartNo.Name = "buttonPartNo";
            this.buttonPartNo.Size = new System.Drawing.Size(164, 35);
            this.buttonPartNo.TabIndex = 9;
            this.buttonPartNo.Text = " Part No Config";
            this.buttonPartNo.UseVisualStyleBackColor = true;
            this.buttonPartNo.Click += new System.EventHandler(this.buttonPartNo_Click);
            // 
            // DataBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 839);
            this.Controls.Add(this.buttonPartNo);
            this.Controls.Add(this.buttonRestoreState);
            this.Controls.Add(this.buttonSaveState);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.checkBoxCopy);
            this.Controls.Add(this.checkBoxFilter);
            this.Controls.Add(this.treeListView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataBrowserForm";
            this.Text = "Data Browser for Alibre";
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonPartNo;

        private System.Windows.Forms.Button buttonSaveState;
        private System.Windows.Forms.Button buttonRestoreState;


        private System.Windows.Forms.Label progressLabel;

        private System.Windows.Forms.CheckBox checkBoxCopy;

        private System.Windows.Forms.CheckBox checkBoxFilter;

        private BrightIdeasSoftware.OLVColumn olvColumnAlibreModified;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreProduct;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreReceivedFrom;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreRevision;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreStockSize;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreSupplier;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreTitle;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreVendor;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreWebLink;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreMfgApprovedDate;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreMfgApprovedBy;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreLastUpdateDate;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreLastAuthor;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreKeywords;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreEstimatedCost;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreEngApprovedBy;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreEngApprovalDate;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreDocumentNumber;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreCreatingApplication;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreCreatedDate;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreCreatedBy;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreCostCenter;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreComment;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreMaterial;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibrePartNo;
        private BrightIdeasSoftware.OLVColumn olvColumnAlibreDescription;
        private BrightIdeasSoftware.OLVColumn olvColumnModified;
        private BrightIdeasSoftware.OLVColumn olvColumnType;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private BrightIdeasSoftware.TreeListView treeListView;

        #endregion

    }

}
