using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AlibreX;
using Microsoft.Win32;

namespace Bolsover.Gear
{
    public partial class ExternalGearUserControl : UserControl
    {
        private InvoluteGear gear1;
        private InvoluteGear gear2;
        private GearPair gearPair;

        public ExternalGearUserControl()
        {
            InitializeComponent();
            initGearPair();
        }

        public GearPair Pair
        {
            get => gearPair;
            set => gearPair = value;
        }

        private void initGearPair()
        {
            gear1 = new InvoluteGear(1, 18, 20, 0, 0);
            gear2 = new InvoluteGear(1, 18, 20, 0, 0);
            gear1.RootFilletFactorRf = 0.38;
            gear2.RootFilletFactorRf = 0.38;
            gear1.AddendumFilletFactorRa = 0.25;
            gear2.AddendumFilletFactorRa = 0.25;
            gearPair = new GearPair(gear1, gear2, 18, 0)
            {
                DeltaX = 50
            };
            numericUpDownModule.Value = Convert.ToDecimal(gear1.ModeuleM);
            trackBarProfileShiftDistribution.Value = Convert.ToInt16(gearPair.DeltaX);
            numericUpDownOperatingCentreDistance.Value = Convert.ToDecimal(gearPair.StandardCentreDistanceA);
            gearPair.Updated += GearPairOnUpdated;
            GearPairOnUpdated(null, null);
        }


        private void GearPairOnUpdated(object sender, EventArgs e)
        {
            gear2.ProfileShiftX = Pair.SigmaX * Pair.DeltaX / 100;
            gear1.ProfileShiftX = Pair.SigmaX - gear2.ProfileShiftX;
            textBoxTransverseModule.Text = gearPair.G1.TransverseModuleMt.ToString("0.00000");
            textBoxX1.Text = gearPair.G1.ProfileShiftX.ToString("0.00000");
            textBoxX2.Text = gearPair.G2.ProfileShiftX.ToString("0.00000");
            textBoxProfileShiftWithoutUndercut1.Text = gearPair.G1.ProfileShiftWithoutUndercutX.ToString("0.00000");
            textBoxProfileShiftWithoutUndercut2.Text = gearPair.G2.ProfileShiftWithoutUndercutX.ToString("0.00000");
            textBoxInvoluteFunction1.Text = gearPair.G1.InvAlpha.ToString("0.00000");
            textBoxInvoluteFunction2.Text = gearPair.G2.InvAlpha.ToString("0.00000");
            textBoxRadialPressureAngle.Text = gearPair.G1.AlphaT.ToString("0.00000");
            textBoxWorkingPressureAngle2.Text = gearPair.AlphaW.ToString("0.00000");
            textBoxWorkingInvoluteFunctionAlphaW.Text = gearPair.InvAlphaW.ToString("0.00000");
            textBoxPitchCircleDiameter1.Text = gearPair.G1.ReferenceDiameterD.ToString("0.00000");
            textBoxPitchCircleDiameter2.Text = gearPair.G2.ReferenceDiameterD.ToString("0.00000");
            textBoxWorkingPitchDiameter1.Text = gearPair.WorkingPitchDiameterDw(gearPair.G1).ToString("0.00000");
            textBoxWorkingPitchDiameter2.Text = gearPair.WorkingPitchDiameterDw(gearPair.G2).ToString("0.00000");
            textBoxTipDiameter1.Text = gearPair.AddendumDiameterDa(gearPair.G1, gearPair.G2).ToString("0.00000");
            textBoxTipDiameter2.Text = gearPair.AddendumDiameterDa(gearPair.G2, gearPair.G1).ToString("0.00000");
            textBoxBaseDiameter1.Text = gearPair.G1.BaseDiameterDb.ToString("0.00000");
            textBoxBaseDiameter2.Text = gearPair.G2.BaseDiameterDb.ToString("0.00000");
            textBoxRootDiameter1.Text = gearPair.G1.RootDiameterDr.ToString("0.00000");
            textBoxRootDiameter2.Text = gearPair.G2.RootDiameterDr.ToString("0.00000");
            textBoxIncrementFactorY.Text = gearPair.CentreDistanceIncrementFactorY.ToString("0.00000");
            textBoxStandardCentreDistance.Text = gearPair.StandardCentreDistanceA.ToString("0.00000");
            textBoxBacklashModificationXmod.Text = gearPair.XMod.ToString("0.00000");
            textBoxSumOfProfileShifts.Text = gearPair.SigmaX.ToString("0.00000");
            textBoxContactRatio.Text = gearPair.ContactRatio().ToString("0.00000");

           
            if (gearPair.ContactRatio() < 1.2)
            {
                textBoxContactRatio.ForeColor = Color.Red;
            }
            else
            {
                textBoxContactRatio.ForeColor = Color.Black;
            }

            if (!Equals(gearPair.WorkingCentreDistanceAw, gearPair.StandardCentreDistanceA, 0.00001))
            {
                numericUpDownOperatingCentreDistance.ForeColor = Color.Red;
            }
            else
            {
                numericUpDownOperatingCentreDistance.ForeColor = Color.Black;
            }
        }
        bool Equals(double x, double y, double tolerance)
        {
            var diff = Math.Abs(x - y);
            return diff <= tolerance ||
                   diff <= Math.Max(Math.Abs(x), Math.Abs(y)) * tolerance;
        }

        private void numericUpDownModule_ValueChanged(object sender, EventArgs e)
        {
            gear1.ModeuleM = (double) ((NumericUpDown) sender).Value;
            gear2.ModeuleM = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownPressureAngle_ValueChanged(object sender, EventArgs e)
        {
            gear1.PressureAngleAlpha = (double) ((NumericUpDown) sender).Value;
            gear2.PressureAngleAlpha = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownHelixAngle_ValueChanged(object sender, EventArgs e)
        {
            gear1.HelixAngleBeta = (double) ((NumericUpDown) sender).Value;
            gear2.HelixAngleBeta = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownTeeth1_ValueChanged(object sender, EventArgs e)
        {
            gear1.TeethZ = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownTeeth2_ValueChanged(object sender, EventArgs e)
        {
            gear2.TeethZ = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownOperatingCentreDistance_ValueChanged(object sender, EventArgs e)
        {
            Pair.WorkingCentreDistanceAw = (double) ((NumericUpDown) sender).Value;
        }

        private void trackBarProfileShiftDistribution_Scroll(object sender, EventArgs e)
        {
            Pair.DeltaX = ((TrackBar) sender).Value;
            sliderLabel.Text = Math.Abs(Convert.ToDouble(Pair.DeltaX)).ToString();
        }

        private void numericUpDownCircularBacklashBc_ValueChanged(object sender, EventArgs e)
        {
            Pair.CircularBacklashBc = (double) ((NumericUpDown) sender).Value;
        }

        private void rootFilletNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            gear1.RootFilletFactorRf = (double) ((NumericUpDown) sender).Value;
            gear2.RootFilletFactorRf = (double) ((NumericUpDown) sender).Value;
        }

        private void tipReliefNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            gear1.AddendumFilletFactorRa = (double) ((NumericUpDown) sender).Value;
            gear2.AddendumFilletFactorRa = (double) ((NumericUpDown) sender).Value;
        }

        private void buttonBuildPinion_Click(object sender, EventArgs e)
        {
            const bool pinion = true;
            var saveFile = "PinionPleaseSaveAs.AD_PRT";
            var template = "PinionTemplate.AD_PRT";

            if (Pair.G1.HelixAngleBeta > 0)
            {
                saveFile = "HelicalPinionPleaseSaveAs.AD_PRT";
                template = "HelicalPinionTemplate.AD_PRT";
            }

            BuildGear(saveFile, template, pinion);
        }

        private void BuildGear(string saveFile, string template, bool pinion)
        {
            GearBuilder gearBuilder = new GearBuilder();

            var userTempDirectory = Path.GetTempPath();
            var tempFile = userTempDirectory + "\\" + saveFile;
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show("Temporary file " + saveFile + "is currently open. \nPlease save-as or discard.", "Oops");
                return;
            }

            var FilePath = Globals.InstallPath;
           
            if (FilePath != null)
            {
                FilePath += "\\Gear\\" + template;
            }

            File.Copy(FilePath, tempFile, true);

            var gearToothPoints = gearBuilder.BuildGearToothPoints(Pair, pinion);
            gearToothPoints.TemplateFilePath = tempFile;

            IADDesignSession session = InitAlibrePinionFile(tempFile, true);

            new AlibreBuilder(gearToothPoints, session);
        }

        public IADDesignSession InitAlibrePinionFile(string filePath, bool openEditor)
        {
            IADRoot Root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
            IADDesignSession session = (IADDesignSession) Root.OpenFileEx(filePath, true);
            return session;
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

        private void buttonBuildWheel_Click(object sender, EventArgs e)
        {
            const bool pinion = false;
            var saveFile = "WheelPleaseSaveAs.AD_PRT";
            var template = "WheelTemplate.AD_PRT";

            if (Pair.G1.HelixAngleBeta > 0)
            {
                saveFile = "HelicalWheelPleaseSaveAs.AD_PRT";
                template = "HelicalWheelTemplate.AD_PRT";
            }

            BuildGear(saveFile, template, pinion);
        }
    }
}