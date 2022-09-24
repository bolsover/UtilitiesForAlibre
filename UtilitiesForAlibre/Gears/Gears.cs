using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Gear;
using Microsoft.Win32;


namespace Bolsover.Gears
{
    public partial class Gears : Form
    {
        private ExternalGearParameters parameters = new();


        public Gears()
        {
            InitializeComponent();

            initBindings();

            parameters.Updated += ParametersOnUpdated;
        }


        private void ParametersOnUpdated(object sender, EventArgs e)
        {
            textBoxInvoluteFunction1.Text = parameters.InvoluteFunctionInvAlpha.ToString("0.00000");
            textBoxPitchCircleDiameter1.Text = parameters.ReferenceDiameterD1.ToString("0.00000");
            textBoxTipDiameter1.Text = parameters.TipDiameterDa1.ToString("0.00000");
            textBoxBaseDiameter1.Text = parameters.BaseDiameterDb1.ToString("0.00000");
            textBoxRootDiameter1.Text = parameters.RootDiameterDr1.ToString("0.00000");
            // textBoxBasePitch1.Text = parameters.BasePitchPb1.ToString("0.00000");
            textBoxWorkingPitchDiameter1.Text = parameters.WorkingPitchDiameterDw1.ToString("0.00000");
            textBoxInvoluteFunction2.Text = parameters.InvoluteFunctionInvAlpha.ToString("0.00000");
            textBoxPitchCircleDiameter2.Text = parameters.ReferenceDiameterD2.ToString("0.00000");
            textBoxTipDiameter2.Text = parameters.TipDiameterDa2.ToString("0.00000");
            textBoxBaseDiameter2.Text = parameters.BaseDiameterDb2.ToString("0.00000");
            textBoxRootDiameter2.Text = parameters.RootDiameterDr2.ToString("0.00000");
            // textBoxBasePitch2.Text = parameters.BasePitchPb2.ToString("0.00000");
            textBoxWorkingPitchDiameter2.Text = parameters.WorkingPitchDiameterDw2.ToString("0.00000");
            textBoxStandardCentreDistance.Text = parameters.StandardCentreDistanceA.ToString("0.00000");
            textBoxSumOfProfileShifts.Text = parameters.SumCoefficientOfProfileShift.ToString("0.00000");
            textBoxWorkingPressureAngle2.Text = parameters.WorkingPressureAngleAw.ToString("0.00000");
            textBoxWorkingInvoluteFunctionAlphaW.Text = parameters.InvoluteFunctionInvAlphaW.ToString("0.00000");
            textBoxIncrementFactorY.Text = parameters.CentreDistanceIncrementFactorY.ToString("0.00000");
            textBoxBacklashModificationXmod.Text = parameters.ProfileShiftXMod.ToString("0.00000");
            textBoxX1.Text = parameters.ProfileShiftX1.ToString("0.00000");
            textBoxX2.Text = parameters.ProfileShiftX2.ToString("0.00000");
            textBoxProfileShiftWithoutUndercut1.Text = parameters.ProfileShiftWithoutUndercutX1.ToString("0.00000");
            textBoxProfileShiftWithoutUndercut2.Text = parameters.ProfileShiftWithoutUndercutX2.ToString("0.00000");
            textBoxContactRatio.Text = parameters.ContactRatio().ToString("0.00000");
            textBoxAlpha1.Text = parameters.Alpha1.ToString("0.00000");
            textBoxRotate.Text = parameters.RotateDegrees1.ToString("0.00000");
            if (parameters.ContactRatio() < 1.2)
            {
                textBoxContactRatio.ForeColor = Color.Red;
            }
            else
            {
                textBoxContactRatio.ForeColor = Color.Black;
            }

            if (parameters.WorkingCentreDistanceAw != parameters.StandardCentreDistanceA)
            {
                numericUpDownOperatingCentreDistance.ForeColor = Color.Red;
            }
            else
            {
                numericUpDownOperatingCentreDistance.ForeColor = Color.Black;
            }

            textBoxRadialPressureAngle.Text = parameters.RadialPressureAngle.ToString("0.00000");
            textBoxTransverseModule.Text = parameters.ModuleMt.ToString("0.00000");
        }


        private void initBindings()
        {
            // comboBoxGearType.DataSource = GearType.Types();
            parameters.Type = GearType.EXTERNAL_SPUR;
            parameters.TeethZ1 = 18;
            parameters.TeethZ2 = 36;
            parameters.Centre = new Point(0, 0);
            parameters.ModuleMn = 1;
            parameters.PressureAngleAlpha = 20;
            parameters.DistributionOfProfileShift = 50;
            numericUpDownModule.Value = Convert.ToDecimal(parameters.ModuleMn);
            trackBarProfileShiftDistribution.Value = Convert.ToInt16(parameters.DistributionOfProfileShift);
            numericUpDownOperatingCentreDistance.Value = Convert.ToDecimal(parameters.StandardCentreDistanceA);
        }

        private void buttonPinionBuildClick(object sender, EventArgs e)
        {
            if (parameters.HelixAngle > 0)
            {
                BuildHelicalPinion();
            }
            else
            {
                BuildPinion();
            }
        }

        private void BuildHelicalPinion()
        {
            var userTempDirectory = System.IO.Path.GetTempPath();
            var tempFile = userTempDirectory + "\\HelicalPinionPleaseSaveAs.AD_PRT";
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show("Temporary file 'HelicalPinionPleaseSaveAs.AD_PRT' is currently open. \nPlease save-as or discard.", "Oops");
                return;
            }

            var FilePath = (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Alibre Design Add-Ons\",
                "{305297BD-DE8D-4F36-86A4-AA5E69538A69}", null);
            if (FilePath != null)
            {
                FilePath += "\\Gears\\HelicalPinionTemplate.AD_PRT";
            }

            System.IO.File.Copy(FilePath, tempFile, true);
            InitAlibrePinionFile(tempFile, true);
            var test = new AlibreGearBuilder(parameters);
            test.BuildPinion();
        }

        private void BuildTest()
        {
            Gear.InvoluteGear g1;
            Gear.InvoluteGear g2;
            GearPair gearPair;

            GearToothPoints gearToothPoints;

            g1 = new Gear.InvoluteGear(3, 24, 20, 0, 0.36);
            g2 = new Gear.InvoluteGear(3, 12, 20, 0, 0.6);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            gearPair = new GearPair(g1, g2, 56.4999, 0);
            // gearPair.Updated += GearPairOnUpdated;
            GearBuilder gearBuilder = new GearBuilder();
            gearToothPoints = gearBuilder.BuildGearToothPoints(gearPair, false);


            var userTempDirectory = System.IO.Path.GetTempPath();
            var tempFile = userTempDirectory + "\\PinionPleaseSaveAs.AD_PRT";
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show("Temporary file 'PinionPleaseSaveAs.AD_PRT' is currently open. \nPlease save-as or discard.", "Oops");
                return;
            }

            var FilePath = (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Alibre Design Add-Ons\",
                "{305297BD-DE8D-4F36-86A4-AA5E69538A69}", null);
            if (FilePath != null)
            {
                FilePath += "\\Gears\\PinionTemplate.AD_PRT";
            }

            System.IO.File.Copy(FilePath, tempFile, true);

            gearToothPoints = gearBuilder.BuildGearToothPoints(gearPair, false);
            gearToothPoints.TemplateFilePath = tempFile;

            InitAlibrePinionFile(tempFile, true);
            // var test = new AlibreGearBuilder(parameters);
            // test.BuildPinion();

            var test = new AlibreBuilder(gearToothPoints, parameters.PinionSession);
        }

        private void BuildPinion()
        {
            var userTempDirectory = System.IO.Path.GetTempPath();
            var tempFile = userTempDirectory + "\\PinionPleaseSaveAs.AD_PRT";
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show("Temporary file 'PinionPleaseSaveAs.AD_PRT' is currently open. \nPlease save-as or discard.", "Oops");
                return;
            }

            var FilePath = (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Alibre Design Add-Ons\",
                "{305297BD-DE8D-4F36-86A4-AA5E69538A69}", null);
            if (FilePath != null)
            {
                FilePath += "\\Gears\\PinionTemplate.AD_PRT";
            }

            System.IO.File.Copy(FilePath, tempFile, true);
            InitAlibrePinionFile(tempFile, true);
            var test = new AlibreGearBuilder(parameters);
            test.BuildPinion();
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
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

        public void InitAlibrePinionFile(string filePath, bool openEditor)
        {
            parameters.Root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
            parameters.PinionSession = (IADDesignSession) parameters.Root.OpenFileEx(filePath, true);
        }

        public void InitAlibreWheelFile(string filePath, bool openEditor)
        {
            parameters.Root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
            parameters.WheelSession = (IADDesignSession) parameters.Root.OpenFileEx(filePath, true);
        }


        private void numericUpDownModule_ValueChanged(object sender, EventArgs e)
        {
            parameters.ModuleMn = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownPressureAngle_ValueChanged(object sender, EventArgs e)
        {
            parameters.PressureAngleAlpha = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownTeeth1_ValueChanged(object sender, EventArgs e)
        {
            parameters.TeethZ1 = (double) ((NumericUpDown) sender).Value;
        }


        private void numericUpDownTeeth2_ValueChanged(object sender, EventArgs e)
        {
            parameters.TeethZ2 = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownOperatingCentreDistance_ValueChanged(object sender, EventArgs e)
        {
            parameters.WorkingCentreDistanceAw = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownCircularBacklashBc_ValueChanged(object sender, EventArgs e)
        {
            parameters.CircularBacklashReqdBc = (double) ((NumericUpDown) sender).Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            parameters.DistributionOfProfileShift = ((TrackBar) sender).Value;

            sliderLabel.Text = Math.Abs(Convert.ToDouble(parameters.DistributionOfProfileShift)).ToString();
        }

        private void buttonBuildWheel_Click(object sender, EventArgs e)
        {
            if (parameters.HelixAngle > 0)
            {
                BuildHelicalWheel();
            }
            else
            {
                BuildWheel();
            }
        }

        private void BuildHelicalWheel()
        {
            var userTempDirectory = System.IO.Path.GetTempPath();
            var tempFile = userTempDirectory + "\\HelicalWheelPleaseSaveAs.AD_PRT";
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show("Temporary file 'HelicalWheelPleaseSaveAs.AD_PRT' is currently open. \nPlease save-as or discard.", "Oops");
                return;
            }

            var FilePath = (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Alibre Design Add-Ons\",
                "{305297BD-DE8D-4F36-86A4-AA5E69538A69}", null);
            if (FilePath != null)
            {
                FilePath += "\\Gears\\HelicalWheelTemplate.AD_PRT";
            }

            System.IO.File.Copy(FilePath, tempFile, true);
            InitAlibreWheelFile(tempFile, true);
            var alibreGearBuilder = new AlibreGearBuilder(parameters);
            alibreGearBuilder.BuildWheel();
        }


        private void BuildWheel()
        {
            var userTempDirectory = System.IO.Path.GetTempPath();
            var tempFile = userTempDirectory + "\\WheelPleaseSaveAs.AD_PRT";
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show("Temporary file 'WheelPleaseSaveAs.AD_PRT' is currently open. \nPlease save-as or discard.", "Oops");
                return;
            }

            var FilePath = (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Alibre Design Add-Ons\",
                "{305297BD-DE8D-4F36-86A4-AA5E69538A69}", null);
            if (FilePath != null)
            {
                FilePath += "\\Gears\\WheelTemplate.AD_PRT";
            }

            System.IO.File.Copy(FilePath, tempFile, true);
            InitAlibreWheelFile(tempFile, true);
            var alibreGearBuilder = new AlibreGearBuilder(parameters);
            alibreGearBuilder.BuildWheel();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show(parameters.commonData() + parameters.PinionData() + parameters.WheelData(), "Gear Pair Data");
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            StringBuilder help = new StringBuilder();
            help.Append("Instructions for Standard Spur Gears\n\n");
            help.Append("1 Select Module size.\n");
            help.Append("2 Select Gear Teeth number.\n");
            help.Append("3 Adjust Operating Centre Distance to match Standard Centre Distance.\n");
            help.Append("Standard Gears can now be generated.\n\n");
            help.Append("Centre Distance Adjustments\n");
            help.Append("4 If required adjust Operating Centre Distance to meet design goals.\n");
            help.Append("5 If required adjust distribution of profile shift. \n");
            help.Append("Taking care not to allow Contact ratio to fall below 1.2\n\n");
            help.Append("Backlash and Root Fillet Adjustments\n");
            help.Append("6 If required, adjust Backlash and Root Fillet. \n");
            help.Append("Gear backlash can be adjusted as needed. A value of 0.1 will give a total backlash of appx 0.1mm for a module 1 gear pair.\n");
            help.Append("Root Fillet diameter can be adjusted as needed. \n");
            help.Append("Value is in terms of Module size. So a value of 0.38 will give a root fillet of 0.38mm diameter for a module 1 gear.\n");

            help.Append("Instructions for Helical Spur Gears\n\n");
            help.Append("As above but also select required helix angle.\n");


            MessageBox.Show(help.ToString(), "Help");
        }

        private void numericUpDownHelixAngle_ValueChanged(object sender, EventArgs e)
        {
            parameters.HelixAngle = (double) ((NumericUpDown) sender).Value;
        }
    }
}