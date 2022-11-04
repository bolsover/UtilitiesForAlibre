using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AlibreX;


namespace Bolsover.Gear
{
    public partial class GearUserControl : UserControl
    {
        private InvoluteGear g1;
        private InvoluteGear g2;


        public GearUserControl()
        {
            InitializeComponent();

            initGearPair();
        }

        private void initGearPair()
        {
            g1 = new InvoluteGear(1, 18, 20, 0, 0);
            g2 = new InvoluteGear(1, 18, 20, 0, 0);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearType = GearType.External;
            g2.GearType = GearType.External;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            g1.DeltaX = 50;
            g2.DeltaX = 50;
            numericUpDownModule.Value = Convert.ToDecimal(g1.ModeuleM);
            trackBarProfileShiftDistribution.Value = Convert.ToInt16(g1.DeltaX);
            numericUpDownOperatingCentreDistance.Value = Convert.ToDecimal(GearCalculations.StandardCentreDistanceA(g1));
            g1.Updated += GearPairOnUpdated;
            g2.Updated += GearPairOnUpdated;
            GearPairOnUpdated(null, null);
        }


        private void GearPairOnUpdated(object sender, EventArgs e)
        {
            g2.ProfileShiftX = GearCalculations.SigmaX(g1) * g1.DeltaX / 100;
            g1.ProfileShiftX = GearCalculations.SigmaX(g1) - g2.ProfileShiftX;
            textBoxTransverseModule.Text = GearCalculations.TransverseModuleMt(g1).ToString("0.00000");
            textBoxX1.Text = g1.ProfileShiftX.ToString("0.00000");
            textBoxX2.Text = g2.ProfileShiftX.ToString("0.00000");
            textBoxProfileShiftWithoutUndercut1.Text = GearCalculations.ProfileShiftWithoutUndercutX(g1).ToString("0.00000");
            textBoxProfileShiftWithoutUndercut2.Text = GearCalculations.ProfileShiftWithoutUndercutX(g2).ToString("0.00000");
            textBoxInvoluteFunction1.Text = GearCalculations.InvAlpha(g1).ToString("0.00000");
            textBoxInvoluteFunction2.Text = GearCalculations.InvAlpha(g1).ToString("0.00000");
            textBoxRadialPressureAngle.Text = GearCalculations.AlphaT(g1).ToString("0.00000");
            textBoxWorkingPressureAngle2.Text = GearCalculations.AlphaW(g1).ToString("0.00000");
            textBoxWorkingInvoluteFunctionAlphaW.Text = GearCalculations.InvAlphaW(g1).ToString("0.00000");
            textBoxPitchCircleDiameter1.Text = GearCalculations.ReferenceDiameterD(g1).ToString("0.00000");
            textBoxPitchCircleDiameter2.Text = GearCalculations.ReferenceDiameterD(g2).ToString("0.00000");
            textBoxWorkingPitchDiameter1.Text = GearCalculations.WorkingPitchDiameterDw(g1).ToString("0.00000");
            textBoxWorkingPitchDiameter2.Text = GearCalculations.WorkingPitchDiameterDw(g2).ToString("0.00000");
            textBoxTipDiameter1.Text = GearCalculations.AddendumDiameterDa(g1).ToString("0.00000");
            textBoxTipDiameter2.Text = GearCalculations.AddendumDiameterDa(g2).ToString("0.00000");
            textBoxBaseDiameter1.Text = GearCalculations.BaseDiameterDb(g1).ToString("0.00000");
            textBoxBaseDiameter2.Text = GearCalculations.BaseDiameterDb(g2).ToString("0.00000");
            textBoxRootDiameter1.Text = GearCalculations.RootDiameterDr(g1).ToString("0.00000");
            textBoxRootDiameter2.Text = GearCalculations.RootDiameterDr(g2).ToString("0.00000");
            textBoxIncrementFactorY.Text = GearCalculations.CentreDistanceIncrementFactorY(g1).ToString("0.00000");
            textBoxStandardCentreDistance.Text = GearCalculations.StandardCentreDistanceA(g1).ToString("0.00000");
            textBoxBacklashModificationXmod.Text = GearCalculations.XMod(g1).ToString("0.00000");
            textBoxSumOfProfileShifts.Text = GearCalculations.SigmaX(g1).ToString("0.00000");
            textBoxContactRatio.Text = GearCalculations.ContactRatio(g2).ToString("0.00000");

            textBoxContactRatio.ForeColor = GearCalculations.ContactRatio(g2) < 1.2 ? Color.Red : Color.Black;

            numericUpDownOperatingCentreDistance.ForeColor =
                !Equals(g1.WorkingCentreDistanceAw, GearCalculations.StandardCentreDistanceA(g1), 0.00001)
                    ? Color.Red
                    : Color.Black;

            textBoxContactRatio.Visible = g2.GearType != GearType.Internal;
            labelContactRatio.Visible = g2.GearType != GearType.Internal;
            labelContactRatio2.Visible = g2.GearType != GearType.Internal;
        }

        bool Equals(double x, double y, double tolerance)
        {
            var diff = Math.Abs(x - y);
            return diff <= tolerance ||
                   diff <= Math.Max(Math.Abs(x), Math.Abs(y)) * tolerance;
        }

        private void numericUpDownModule_ValueChanged(object sender, EventArgs e)
        {
            g1.ModeuleM = (double) ((NumericUpDown) sender).Value;
            g2.ModeuleM = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownPressureAngle_ValueChanged(object sender, EventArgs e)
        {
            g1.PressureAngleAlpha = (double) ((NumericUpDown) sender).Value;
            g2.PressureAngleAlpha = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownHelixAngle_ValueChanged(object sender, EventArgs e)
        {
            g1.HelixAngleBeta = (double) ((NumericUpDown) sender).Value;
            g2.HelixAngleBeta = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownTeeth1_ValueChanged(object sender, EventArgs e)
        {
            g1.TeethZ = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownTeeth2_ValueChanged(object sender, EventArgs e)
        {
            g2.TeethZ = (double) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownOperatingCentreDistance_ValueChanged(object sender, EventArgs e)
        {
            var value = (double) ((NumericUpDown) sender).Value;
            g1.WorkingCentreDistanceAw = value;
            g1.WorkingCentreDistanceAw = value;
            g2.WorkingCentreDistanceAw = value;
        }

        private void trackBarProfileShiftDistribution_Scroll(object sender, EventArgs e)
        {
            var value = ((TrackBar) sender).Value;
            g1.DeltaX = value;
            g2.DeltaX = value;
            sliderLabel.Text = Math.Abs(Convert.ToDouble(value)).ToString();
        }

        private void numericUpDownCircularBacklashBc_ValueChanged(object sender, EventArgs e)
        {
            var value = (double) ((NumericUpDown) sender).Value;

            g1.CircularBacklashBc = value;
            g2.CircularBacklashBc = value;
        }

        private void rootFilletNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            g1.RootFilletFactorRf = (double) ((NumericUpDown) sender).Value;
            g2.RootFilletFactorRf = (double) ((NumericUpDown) sender).Value;
        }

        private void tipReliefNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            g1.AddendumFilletFactorRa = (double) ((NumericUpDown) sender).Value;
            g2.AddendumFilletFactorRa = (double) ((NumericUpDown) sender).Value;
        }

        private void buttonBuildPinion_Click(object sender, EventArgs e)
        {
            const bool pinion = true;
            var saveFile = "PinionPleaseSaveAs.AD_PRT";
            var template = "PinionTemplate.AD_PRT";

            if (g1.HelixAngleBeta > 0)
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

            var gearToothPoints = new GearToothPoints
            {
                GearCentre = new Point(0, 0),
                // gear is helical if the helix pitch angle is greater than 0 degrees.
                IsHelical = g1.HelixAngleBeta > 0,
                IsPinion = pinion,
            };
            if (pinion)
            {
                gearToothPoints.G1 = g1;
            }
            else
            {
                gearToothPoints.G1 = g2;
            }

            gearBuilder.BuildGearToothPoints(gearToothPoints);

            gearToothPoints.TemplateFilePath = tempFile;

            IADDesignSession session = InitAlibrePinionFile(tempFile, true);

            AlibreBuilder.CreateInstance(gearToothPoints, session);
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

            if (g1.HelixAngleBeta > 0)
            {
                saveFile = "HelicalWheelPleaseSaveAs.AD_PRT";
                template = "HelicalWheelTemplate.AD_PRT";
            }

            BuildGear(saveFile, template, pinion);
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(g1.ToString());
            MessageBox.Show(g1.ToString(), "Gear Set", MessageBoxButtons.OK);
        }


        private void wheelRadioExt_CheckedChanged(object sender, EventArgs e)
        {
            g2.GearType = wheelRadioExt.Checked ? GearType.External : GearType.Internal;
        }

        private void wheelRadioInt_CheckedChanged(object sender, EventArgs e)
        {
            g2.GearType = wheelRadioInt.Checked ? GearType.Internal : GearType.External;
        }
    }
}