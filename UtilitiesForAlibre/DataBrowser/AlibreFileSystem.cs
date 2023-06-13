using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using AlibreX;

namespace Bolsover.DataBrowser
{
    public class AlibreFileSystem : IEquatable<AlibreFileSystem>, INotifyPropertyChanged
    {
        #region Private Properties

        private bool _isChecked;
        private ArrayList _children = new();

        #endregion

        #region Constructors

        public AlibreFileSystem(FileSystemInfo info)
        {
            Info = info;
            RetrieveAlibreData();
        }

        public AlibreFileSystem()
        {
        }

        #endregion

        #region Public Properties

        public bool HasChildren()
        {
            return _children.Count > 0;
        }


        public FileSystemInfo Info { get; set; }
        public bool IsDirectory => AsDirectory != null;
        public DirectoryInfo AsDirectory => Info as DirectoryInfo;
        public FileInfo AsFile => Info as FileInfo;
        public string Name => Info.Name;
        public string FullName => Info.FullName;

        public bool IsChecked
        {
            get => _isChecked;
            set => SetPropertyField("IsChecked", ref _isChecked, value);
        }

        public string AlibreDescription { get; set; }
        public ADUnits AlibreAngleDisplayUnits { get; set; }
        public double AlibreDensity { get; set; }
        public ADUnits AlibreLengthDisplayUnits { get; set; }
        public ADUnits AlibreMassUnits { get; set; }
        public ADUnits AlibreModelUnits { get; set; }
        public string AlibrePartNo { get; set; }
        public string AlibreMaterial { get; set; }
        public string AlibreMaterialGuid { get; set; }
        public string AlibreExtMaterial { get; set; }
        public string AlibreComment { get; set; }
        public string AlibreCostCenter { get; set; }
        public string AlibreCreatedBy { get; set; }
        public DateTime? AlibreCreatedDate { get; set; }
        public string AlibreCreatingApplication { get; set; }
        public string AlibreDocumentNumber { get; set; }
        public DateTime? AlibreEngApprovalDate { get; set; }
        public string AlibreEngApprovedBy { get; set; }
        public string AlibreEstimatedCost { get; set; }
        public string AlibreKeywords { get; set; }
        public string AlibreLastAuthor { get; set; }
        public DateTime? AlibreLastUpdateDate { get; set; }
        public DateTime? AlibreMfgApprovedDate { get; set; }
        public string AlibreMfgApprovedBy { get; set; }
        public DateTime? AlibreModified { get; set; }
        public string AlibreProduct { get; set; }
        public string AlibreReceivedFrom { get; set; }
        public string AlibreStockSize { get; set; }
        public string AlibreSupplier { get; set; }
        public string AlibreRevision { get; set; }
        public string AlibreTitle { get; set; }
        public string AlibreVendor { get; set; }
        public string AlibreWebLink { get; set; }

        public ArrayList Children
        {
            get => _children;
            set => _children = value;
        }

        #endregion


        public bool Equals(AlibreFileSystem other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(other.Info.FullName, Info.FullName);
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
         * Retrieves data from the Alibre Session and populates the corresponding fields in the AlibreFileSystem rowObject
         */
        // [MethodImpl(MethodImplOptions.Synchronized)]
        public void RetrieveAlibreData()
        {
            if (!IsDirectory
                && AsFile is {IsReadOnly: false}
                && AsFile.Extension.ToUpper().StartsWith(".AD_PRT") |
                AsFile.Extension.ToUpper().StartsWith(".AD_ASM") |
                AsFile.Extension.ToUpper().StartsWith(".AD_SMP"))
            {
                if (!IsFileLocked(AsFile))
                {
                    IADDesignSession session = AlibreConnector.RetrieveSessionForFile(this);
                    if (session != null)
                    {
                        var designProperties = session.DesignProperties;
                        ReadDesignProperties(designProperties);
                        session.Close();
                    }
                }
                else // else routine reads data from open sessions
                {
                    for (var i = 0; i < AlibreConnector.GetRoot().Sessions.Count; i++)
                    {
                        var currentSession = AlibreConnector.GetRoot().Sessions.Item(i);
                        if (currentSession.FilePath.ToUpper().Replace("/", "\\").Equals(Info.FullName.ToUpper()))
                        {
                            var designProperties = ((IADDesignSession) currentSession).DesignProperties;
                            ReadDesignProperties(designProperties);
                        }
                    }
                }
            }
            else if (!IsDirectory
                     && AsFile is {IsReadOnly: false}
                     && AsFile.Extension.ToUpper().StartsWith(".AD_DRW"))
            {
                if (!IsFileLocked(AsFile))
                {
                    IADDrawingSession session = AlibreConnector.RetrieveDrawingSessionForFile(this);
                    IADDrawingProperties designProperties;
                    if (session != null)
                    {
                        designProperties = session.Properties;
                        ReadDrawingProperties(designProperties);
                        session.Close();
                    }
                }
                //@todo fix this - can read data from open drawings at present
                // else
                // {
                //     for (int i = 0; i < AlibreConnector.GetRoot().Sessions.Count; i++)
                //     {
                //         IADSession currentSession = AlibreConnector.GetRoot().Sessions.Item(i);
                //         if (currentSession.FilePath.Replace("/", "\\").Equals(this.Info.FullName))
                //         {
                //             var designProperties = ((IADDrawingSession)currentSession).Properties;
                //
                //             ReadDrawingProperties(designProperties);
                //         }
                //     }
                // }
            }
        }

        private void ReadDrawingProperties(IADDrawingProperties designProperties)
        {
            AlibreDescription = designProperties.Description;
            AlibrePartNo = designProperties.Number;
        }

        private void ReadDesignProperties(IADDesignProperties designProperties)
        {
            AlibreDescription = designProperties.Description;
            AlibrePartNo = designProperties.Number;
            AlibreMaterial = designProperties.Material;
            // rowObject.AlibreAngleDisplayUnits = designProperties.AngleDisplayUnits;
            // rowObject.AlibreDensity = designProperties.Density;
            // rowObject.AlibreLengthDisplayUnits = designProperties.LengthDisplayUnits;
            // rowObject.AlibreMassUnits = designProperties.MassUnits;
            // rowObject.AlibreModelUnits = designProperties.ModelUnits;
            // rowObject.AlibreExtMaterial =
            //     (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_MATERIAL);
            AlibreComment =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_COMMENT);

            AlibreCostCenter =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_COST_CENTER);
            AlibreCreatedBy =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_CREATED_BY);

            var s = designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_CREATED_DATE);
            if (s != null)
            {
                AlibreCreatedDate = DateTime.Parse((string) s);
            }

            AlibreCreatingApplication =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty
                    .AD_CREATING_APPLICATION);
            AlibreDocumentNumber =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_DOCUMENT_NUMBER);

            s = designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_ENG_APPROVAL_DATE);
            if (s != null)
            {
                AlibreEngApprovalDate = DateTime.Parse((string) s);
            }

            AlibreEngApprovedBy =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_ENG_APPROVED_BY);
            AlibreEstimatedCost =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_ESTIMATED_COST);
            AlibreKeywords =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_KEYWORDS);
            AlibreLastAuthor =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_LAST_AUTHOR);
            s = designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_LAST_UPDATE_DATE);
            if (s != null)
            {
                AlibreLastUpdateDate = DateTime.Parse((string) s);
            }

            AlibreMfgApprovedBy =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_MFG_APPROVED_BY);
            s = designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_MFG_APPROVED_DATE);
            if (s != null)
            {
                AlibreMfgApprovedDate = DateTime.Parse((string) s);
            }

            s = designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_MODIFIED);
            if (s != null)
            {
                AlibreModified = DateTime.Parse((string) s);
            }

            AlibreProduct =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_PRODUCT);
            AlibreReceivedFrom =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_RECEIVED_FROM);
            AlibreRevision =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_REVISION);
            AlibreStockSize =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_STOCK_SIZE);
            AlibreSupplier =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_SUPPLIER);
            AlibreTitle =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_TITLE);
            AlibreVendor =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_VENDOR);
            AlibreWebLink =
                (string) designProperties.ExtendedDesignProperty(ADExtendedDesignProperty.AD_WEBLINK);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(AlibreFileSystem))
            {
                return false;
            }

            return Equals((AlibreFileSystem) obj);
        }

        public override int GetHashCode()
        {
            return Info != null ? Info.FullName.GetHashCode() : 0;
        }

        public static bool operator ==(AlibreFileSystem left, AlibreFileSystem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AlibreFileSystem left, AlibreFileSystem right)
        {
            return !Equals(left, right);
        }

        //
        // /// <summary>
        // /// Recursive method for walking component parts of an Alibre file
        // /// </summary>
        // /// <param name="alibreFileSystem"></param>
        // private void WalkAlibreData(AlibreFileSystem alibreFileSystem)
        // {
        //     if (alibreFileSystem.Info.Extension.ToUpper().StartsWith(".AD_A")) // assemblies normally have components
        //     {
        //         var session = AlibreConnector.RetrieveSessionForFile(alibreFileSystem);
        //         var collector = session.ConstituentFilePaths;
        //         session.Close();
        //         foreach (var s in collector)
        //         {
        //             var info = new FileInfo((string) s);
        //             if (info.Exists)
        //             {
        //                 var child = new AlibreFileSystem();
        //                 child.Info = info;
        //                 child.RetrieveAlibreData();
        //                 alibreFileSystem.Children.Add(child);
        //                 WalkAlibreData(child);
        //             }
        //         }
        //     }
        // }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetFileSystemInfos()
        {
            if (IsDirectory)
            {
                foreach (var x in AsDirectory.GetFileSystemInfos())
                {
                    var alibreFileSystem = new AlibreFileSystem(x);

                    Children.Add(alibreFileSystem);
                }
            }

            return Children;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        protected void SetPropertyField<T>(string propertyName, ref T field, T newValue)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}