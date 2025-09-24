using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Bolsover.DataBrowser.PartNoConfig
{
    public partial class PartNoConfig : UserControl
    {
        private readonly ToolTip _applyTooltip = new();
        private readonly ToolTip _cancelTooltip = new();
        private readonly PartNoManager _partNoManager = new();
        private readonly ToolTip _saveTooltip = new();
        private IList _selectedItems;
        
        public PartNoConfig()
        {
            InitializeComponent();
            Bindings();
            SetupToolTips();
        }
        
        public IList SelectedItems
        {
            get => _selectedItems;
            set
            {
                _selectedItems = value;
                labelInfo.Text = "Info " + _selectedItems.Count + " files to renumber.";
            }
        }
        
        private void SetupToolTips()
        {
            _saveTooltip.SetToolTip(button2,
                "Saves the settings for the next part numbering session.");
            _applyTooltip.SetToolTip(button1,
                "Updates the selected files with the new part numbers.");
            _cancelTooltip.SetToolTip(buttonCancel,
                "Cancels this dialog without updating files.");
        }
        
        private void Bindings()
        {
            textBoxPrefix.DataBindings.Add("Text", PartNoManager.PartNoSetting, "Prefix");
            textBoxSuffix.DataBindings.Add("Text", PartNoManager.PartNoSetting, "Suffix");
            nextNumberSpinner.DataBindings.Add("Value", PartNoManager.PartNoSetting, "PartNo");
            stepSpinner.DataBindings.Add("Value", PartNoManager.PartNoSetting, "SkipNo");
            textBoxExample.DataBindings.Add("Text", PartNoManager.PartNoSetting, "Example");
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            PartNoManager.SaveConfig();
        }
        
        private void buttonApply_Click(object sender, EventArgs e)
        {
            foreach (var oItem in _selectedItems)
            {
                var fileSystem = (AlibreFileSystem) oItem;
                
                if (fileSystem.Info.Extension.ToUpper().StartsWith(".AD_P") |
                    fileSystem.Info.Extension.ToUpper().StartsWith(".AD_A") |
                    fileSystem.Info.Extension.ToUpper().StartsWith(".AD_S"))
                {
                    labelInfo.Text = "Info updating " + fileSystem.Name;
                    var session = AlibreConnector.RetrieveSessionForFile(fileSystem);
                    fileSystem.AlibrePartNo = PartNoManager.PartNoSetting.Prefix +
                                              PartNoManager.PartNoSetting.PartNo +
                                              PartNoManager.PartNoSetting.Suffix;
                    PartNoManager.PartNoSetting.PartNo += PartNoManager.PartNoSetting.SkipNo;
                    nextNumberSpinner.Value = PartNoManager.PartNoSetting.PartNo;
                    var designProperties = session.DesignProperties;
                    designProperties.Number = fileSystem.AlibrePartNo;
                    session.Close(true);
                }
                else if (fileSystem.Info.Extension.ToUpper().StartsWith(".AD_D"))
                {
                    labelInfo.Text = "Info updating " + fileSystem.Name;
                    var session = AlibreConnector.RetrieveDrawingSessionForFile(fileSystem);
                    fileSystem.AlibrePartNo = PartNoManager.PartNoSetting.Prefix +
                                              PartNoManager.PartNoSetting.PartNo +
                                              PartNoManager.PartNoSetting.Suffix;
                    PartNoManager.PartNoSetting.PartNo += PartNoManager.PartNoSetting.SkipNo;
                    nextNumberSpinner.Value = PartNoManager.PartNoSetting.PartNo;
                    var designProperties = session.Properties;
                    designProperties.Number = fileSystem.AlibrePartNo;
                    session.Close(true);
                }
                
                PartNoManager.SaveConfig();
            }
            
            labelInfo.Text = "Info done updating";
            Hide();
        }
        
        [Serializable]
        public class PartNoSetting
        {
            private string _example;
            private int _partNo;
            private string _prefix;
            private int _skipNo;
            private string _suffix;
            
            public string Prefix
            {
                get => _prefix;
                set
                {
                    _prefix = value;
                    InvokePropertyChanged(new PropertyChangedEventArgs("prefix"));
                }
            }
            
            public string Suffix
            {
                get => _suffix;
                set
                {
                    _suffix = value;
                    InvokePropertyChanged(new PropertyChangedEventArgs("suffix"));
                }
            }
            
            public int PartNo
            {
                get => _partNo;
                set
                {
                    _partNo = value;
                    InvokePropertyChanged(new PropertyChangedEventArgs("partNo"));
                }
            }
            
            public int SkipNo
            {
                get => _skipNo;
                set
                {
                    _skipNo = value;
                    InvokePropertyChanged(new PropertyChangedEventArgs("skipNo"));
                }
            }
            
            public string Example
            {
                get => _prefix + _partNo + _suffix;
                set => _example = value;
            }
            
            #region Implementation of INotifyPropertyChanged
            
            public event PropertyChangedEventHandler PropertyChanged;
            
            private void InvokePropertyChanged(PropertyChangedEventArgs e)
            {
                var handler = PropertyChanged;
                Example = _prefix + _partNo + _suffix;
                handler?.Invoke(this, e);
            }
            
            #endregion
        }
        
        private class PartNoManager
        {
            public PartNoManager()
            {
                Initialize();
            }
            
            public static PartNoSetting PartNoSetting { get; set; } = new();
            
            private void Initialize()
            {
                LoadConfig();
            }
            
            private static void LoadConfig()
            {
                var directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                    "\\UtilitiesForAlibre";
                var directoryInfo = new DirectoryInfo(directoryPath);
                if (!directoryInfo.Exists)
                {
                    Directory.CreateDirectory(directoryPath);
                }
                
                var filepath = directoryPath + "\\partnumber.settings";
                var fileInfo = new FileInfo(filepath);
                if (!fileInfo.Exists) return;
                var srReader = File.OpenText(filepath);
                var tType = PartNoSetting.GetType();
                var xsSerializer = new XmlSerializer(tType);
                var oData = xsSerializer.Deserialize(srReader);
                PartNoSetting = (PartNoSetting) oData;
                srReader.Close();
            }
            
            // Save configuration file
            public static void SaveConfig()
            {
                var directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                    "\\UtilitiesForAlibre";
                var directoryInfo = new DirectoryInfo(directoryPath);
                if (!directoryInfo.Exists)
                {
                    Directory.CreateDirectory(directoryPath);
                }
                
                var filepath = directoryPath + "\\partnumber.settings";
                var swWriter = File.CreateText(filepath);
                var tType = PartNoSetting.GetType();
                if (!tType.IsSerializable) return;
                var xsSerializer = new XmlSerializer(tType);
                xsSerializer.Serialize(swWriter, PartNoSetting);
                swWriter.Close();
            }
        }
    }
}