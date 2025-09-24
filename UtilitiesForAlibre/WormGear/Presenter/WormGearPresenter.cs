using System;
using System.IO;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Involute.Model;
using Bolsover.WormGear.View;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.WormGear.Presenter
{
    public class WormGearPresenter
    {
        private GearPairDesignOutputParams _gearPairDesignOutputParams;
        private readonly WormGearView _view;
        public GearPairDesignInputParams Model;
        
        public WormGearPresenter(WormGearView view)
        {
            _view = view;
            Initialise();
        }
        
        private void Initialise()
        {
            Model = new GearPairDesignInputParams();
            _gearPairDesignOutputParams = new GearPairDesignOutputParams
            {
                GearPairDesignInputParams = Model
            };
            SetupEventListeners();
        }
        
        private void SetupEventListeners()
        {
            _view.CancelEvent += OnCancel;
            _view.EditModuleEvent += OnEditModule;
            _view.EditPressureAngleEvent += OnEditPressureAngle;
            _view.EditWormThreadsEvent += OnEditWormThreads;
            _view.EditGearTeethEvent += OnEditGearTeeth;
            _view.BuildWormEvent += OnBuildWorm;
            _view.BuildGearEvent += OnBuildGear;
            _view.WormLengthEvent += OnWormLength;
            _view.GearWidthEvent += OnGearWidth;
            _view.WormPdEvent += OnWormPd;
        }
        
        private void OnWormPd(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Pinion.WormPitchDiameter = newValue;
            }
        }
        
        private void OnGearWidth(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Gear.Height = newValue;
            }
        }
        
        private void OnWormLength(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                
                Model.Pinion.Height = newValue;
            }
        }
        
        private void OnBuildGear(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        
        private void OnBuildWorm(object sender, EventArgs e)
        {
            var fileData = GetRackDetails();
            var filePath = GetAlibreFilePath(fileData.SaveFile, fileData.Template);
            var session = InitAlibreFile(filePath);
            session.Parameters.OpenParameterTransaction();
            session.Parameters.Item("Alpha").Value = Radians(Model.Pinion.PressureAngle);
            session.Parameters.Item("Length").Value = Model.Pinion.Height * 0.1;
            session.Parameters.Item("Module").Value = Model.Pinion.Module;
            session.Parameters.Item("PitchDiameter").Value = Model.Pinion.WormPitchDiameter * 0.1;
            session.Parameters.Item("Starts").Value = Model.Pinion.Teeth;
            session.Parameters.CloseParameterTransaction();
            ((IADPartSession) session).RegenerateAll();
        }
        
        private (string SaveFile, string Template) GetRackDetails()
        {
            return ("WormPleaseSaveAs.AD_PRT", "WormTemplate.AD_PRT");
        }
        
        private static string GetAlibreFilePath(string SaveFile, string Template)
        {
            var filePath = Globals.InstallPath;
            var tempFile = Path.Combine(Path.GetTempPath(), SaveFile);
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show($"Temporary file {SaveFile} is currently open. \nPlease save-as or discard.", "Oops");
                return null;
            }
            
            if (filePath != null)
            {
                filePath += "\\Gear\\" + Template;
            }
            
            File.Copy(filePath, tempFile, true);
            return tempFile;
        }
        
        private static IADDesignSession InitAlibreFile(string filePath)
        {
            var root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
            var session = (IADDesignSession) root.OpenFileEx(filePath, true);
            return session;
        }
        
        
        private static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
                stream.Close();
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
        
        private void OnEditGearTeeth(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                
                Model.Gear.Teeth = newValue;
            }
        }
        
        private void OnEditWormThreads(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                
                Model.Pinion.Teeth = newValue;
            }
        }
        
        private void OnEditPressureAngle(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Pinion.PressureAngle = newValue;
                Model.Gear.PressureAngle = newValue;
            }
        }
        
        private void OnEditModule(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Pinion.Module = newValue;
                Model.Gear.Module = newValue;
            }
        }
        
        private void OnCancel(object sender, EventArgs e)
        {
            _view.FindForm()!.Close();
        }
    }
}