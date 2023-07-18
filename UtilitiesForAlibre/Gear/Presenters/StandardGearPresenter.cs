using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Gear.Models;
using Bolsover.Gear.Views;
using static Bolsover.Gear.Images.GearLatexStrings;
using static Bolsover.Utils.LatexUtils;

namespace Bolsover.Gear.Presenters
{
    public class StandardGearPresenter
    {
        private readonly StandardGearView _view;
        private readonly IGearPair _gearPair;
        private readonly StandardHelicalGearCalculator calculator = new();


        public StandardGearPresenter(StandardGearView view)
        {
            _view = view;
            _gearPair = new GearPair();

            InitGearPair();
            SetupDefaults();
            ClearLabelText();
            SetupLabelLatexImages();
            SetupEventListeners();
            BindData();
            _gearPair.Pinion.Updated += GearsOnUpdated;
            _gearPair.Gear.Updated += GearsOnUpdated;
            Calculate();
        }

        private void InitGearPair()
        {
            var gear = new Bolsover.Gear.Models.Gear
            {
                NormalModule = 1.0,
                NormalPressureAngle = 20.0,
                HelixAngle = 0,
                NumberOfTeeth = 50.0,
                CoefficientOfProfileShift = 0,
                TipReliefRadius = 0.25,
                RootFilletFactor = 0.38,
                CentreDistanceIncrementFactor = 0,
                WorkingCentreDistance = 50
            };

            var pinion = new Bolsover.Gear.Models.Gear
            {
                NormalModule = 1.0,
                NormalPressureAngle = 20.0,
                HelixAngle = 0,
                NumberOfTeeth = 50.0,
                CoefficientOfProfileShift = 0,
                TipReliefRadius = 0.25,
                RootFilletFactor = 0.38,
                CentreDistanceIncrementFactor = 0,
                WorkingCentreDistance = 50
            };
            _gearPair.Gear = gear;
            _gearPair.Pinion = pinion;
        }


        private void SetupDefaults()
        {
            _view.teethNumericUpDown.Value = (decimal) _gearPair.Gear.NumberOfTeeth;
            _view.moduleNumericUpDown.Value = (decimal) _gearPair.Gear.NormalModule;
            _view.pressureAngleNumericUpDown.Value = (decimal) _gearPair.Gear.NormalPressureAngle;
            _view.helixAngleNumericUpDown.Value = (decimal) _gearPair.Gear.HelixAngle;
        }

        private void SetupEventListeners()
        {
            _view.EditGearNumberOfTeethEvent += ViewOnEditGearNumberOfTeethEvent;
            _view.EditModuleEvent += ViewOnEditModuleEvent;
            _view.EditHelixAngleEvent += ViewOnEditHelixAngleEvent;
            _view.CancelEvent += ViewOnCancelEvent;
            _view.BuildGearEvent += ViewOnBuildWheelEvent;
            _view.EditPressureAngleEvent += ViewOnEditPressureAngleEvent;
        }

        private void ClearLabelText()
        {
            _view.normalModuleSymbolLabel.Text = "";
            _view.normalPressureAngleSymbolLabel.Text = "";
            _view.helixAngleSymbolLabel.Text = "";
            _view.teethLabel.Text = "";
            _view.transverseInvoluteSymbolLabel.Text = "";
            _view.involuteFormulaLabel.Text = "";
            _view.pitchDiameterFormulaLabel.Text = "";
            _view.PitchDiameterSymbolLabel.Text = "";
            _view.baseDiameterFormulaLabel.Text = "";
            _view.baseDiameterSymbolLabel.Text = "";
            _view.addendumFormulaLabel.Text = "";
            _view.addendumSymbolLabel.Text = "";
            _view.dedendumFormulaLabel.Text = "";
            _view.dedendumSymbolLabel.Text = "";
            _view.wholeDepthFormulaLabel.Text = "";
            _view.wholeDepthSymbolLabel.Text = "";
            _view.outsideDiameterFormulaLabel.Text = "";
            _view.outsideDiameterSymbolLabel.Text = "";
            _view.rootDiameterFormulaLabel.Text = "";
            _view.rootDiameterSymbolLabel.Text = "";
        }

        private void SetupLabelLatexImages()
        {
            _view.normalModuleSymbolLabel.Image = CreateImageFromLatex(NormalModuleSymbol);
            _view.normalPressureAngleSymbolLabel.Image = CreateImageFromLatex(NormalPressureAngleSymbol);
            _view.helixAngleSymbolLabel.Image = CreateImageFromLatex(HelixAngleSymbol);
            _view.teethLabel.Image = CreateImageFromLatex(NumberOfTeethSymbol);
            _view.transverseInvoluteSymbolLabel.Image = CreateImageFromLatex(TransverseInvoluteFunctionSymbol);
            _view.involuteFormulaLabel.Image = CreateImageFromLatex(TransverseInvoluteFunctionFormula);
            _view.pitchDiameterFormulaLabel.Image = CreateImageFromLatex(PitchDiameterFormula);
            _view.PitchDiameterSymbolLabel.Image = CreateImageFromLatex(PitchDiameterSymbol);
            _view.baseDiameterFormulaLabel.Image = CreateImageFromLatex(BaseDiameterFormula);
            _view.baseDiameterSymbolLabel.Image = CreateImageFromLatex(BaseDiameterSymbol);
            _view.addendumFormulaLabel.Image = CreateImageFromLatex(AddendumFormula);
            _view.addendumSymbolLabel.Image = CreateImageFromLatex(AddendumSymbol);
            _view.dedendumFormulaLabel.Image = CreateImageFromLatex(DedendumFormula);
            _view.dedendumSymbolLabel.Image = CreateImageFromLatex(DedendumSymbol);
            _view.wholeDepthFormulaLabel.Image = CreateImageFromLatex(WholeDepthFormula);
            _view.wholeDepthSymbolLabel.Image = CreateImageFromLatex(WholeDepthSymbol);
            _view.outsideDiameterFormulaLabel.Image = CreateImageFromLatex(OutsideDiameterFormula);
            _view.rootDiameterFormulaLabel.Image = CreateImageFromLatex(RootDiameterFormula);
            _view.outsideDiameterSymbolLabel.Image = CreateImageFromLatex(OutsideDiameterSymbol);
            _view.rootDiameterSymbolLabel.Image = CreateImageFromLatex(RootDiameterSymbol);
        }

        private void BindData()
        {
            var gear = _gearPair.Gear;
            _view.involuteFunctiontextBox.DataBindings.Add("Text", gear, "InvoluteFunction", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000", null);
            _view.pitchDiameterTextBox.DataBindings.Add("Text", gear, "PitchDiameter", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            _view.baseDiameterTextBox.DataBindings.Add("Text", gear, "BaseDiameter", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            _view.addendumTextBox.DataBindings.Add("Text", gear, "Addendum", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            _view.dedendumTextBox.DataBindings.Add("Text", gear, "Dedendum", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            _view.wholeDepthTextBox.DataBindings.Add("Text", gear, "WholeDepth", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            _view.outsideDiameterTextBox.DataBindings.Add("Text", gear, "OutsideDiameter", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            _view.rootDiameterTextBox.DataBindings.Add("Text", gear, "RootDiameter", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            _view.dataTextBox.DataBindings.Add("Text", gear, "GearString", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "", null);
        }


        private void GearsOnUpdated(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            _gearPair.Gear.TransverseModule = calculator.CalculateTransverseModule(_gearPair);
            _gearPair.Pinion.TransverseModule = _gearPair.Gear.TransverseModule;
            _gearPair.Gear.RadialPressureAngle = calculator.CalculateRadialPressureAngle(_gearPair);
            _gearPair.Pinion.RadialPressureAngle = _gearPair.Gear.RadialPressureAngle;
            _gearPair.Gear.InvoluteFunction = calculator.CalculateTransverseInvoluteFunction(_gearPair);
            _gearPair.Pinion.InvoluteFunction = _gearPair.Gear.InvoluteFunction;
            _gearPair.Gear.StandardCentreDistance = calculator.CalculateStandardCentreDistance(_gearPair);
            _gearPair.Pinion.StandardCentreDistance = _gearPair.Gear.StandardCentreDistance;
            // for standard gears, working centre distance is the same as standard centre distance
            _gearPair.Gear.WorkingCentreDistance = _gearPair.Gear.StandardCentreDistance;
            _gearPair.Pinion.WorkingCentreDistance = _gearPair.Gear.StandardCentreDistance;

            _gearPair.Gear.CentreDistanceIncrementFactor = calculator.CalculateProfileShiftedCentreDistanceIncrementFactor(_gearPair);
            _gearPair.Pinion.CentreDistanceIncrementFactor = _gearPair.Gear.CentreDistanceIncrementFactor;
            _gearPair.Gear.CoefficientOfProfileShift = calculator.CalculateStandardCoefficientOfProfileShift();
            _gearPair.Pinion.CoefficientOfProfileShift = _gearPair.Gear.CoefficientOfProfileShift;
            _gearPair.Gear.RadialWorkingPressureAngle = calculator.CalculateWorkingRadialPressureAngle(_gearPair);
            _gearPair.Pinion.RadialWorkingPressureAngle = _gearPair.Gear.RadialWorkingPressureAngle;
            _gearPair.Gear.PitchDiameter = calculator.CalculateGearStandardPitchDiameter(_gearPair);
            _gearPair.Pinion.PitchDiameter = calculator.CalculatePinionStandardPitchDiameter(_gearPair);
            _gearPair.Gear.BaseDiameter = calculator.CalculateGearBaseDiameter(_gearPair);
            _gearPair.Pinion.BaseDiameter = calculator.CalculatePinionBaseDiameter(_gearPair);
            _gearPair.Gear.Addendum = calculator.CalculateGearAddendum(_gearPair);
            _gearPair.Pinion.Addendum = calculator.CalculatePinionAddendum(_gearPair);
            _gearPair.Gear.Dedendum = calculator.CalculateGearDedendum(_gearPair);
            _gearPair.Pinion.Dedendum = calculator.CalculatePinionDedendum(_gearPair);
            _gearPair.Gear.WholeDepth = calculator.CalculateWholeDepth(_gearPair);
            _gearPair.Pinion.WholeDepth = _gearPair.Gear.WholeDepth;
            _gearPair.Gear.OutsideDiameter = calculator.CalculateGearOutsideDiameter(_gearPair);
            _gearPair.Pinion.OutsideDiameter = calculator.CalculatePinionOutsideDiameter(_gearPair);
            _gearPair.Gear.RootDiameter = calculator.CalculateGearRootDiameter(_gearPair);
            _gearPair.Pinion.RootDiameter = calculator.CalculatePinionRootDiameter(_gearPair);
            _gearPair.Gear.AddendumCircleDiameter = calculator.CalculateStandardGearAddendumCircleDiameter(_gearPair);
            _gearPair.Pinion.AddendumCircleDiameter = calculator.CalculateStandardPinionAddendumCircleDiameter(_gearPair);
            _gearPair.Gear.DedendumCircleDiameter = calculator.CalculateStandardGearDedendumCircleDiameter(_gearPair);
            _gearPair.Pinion.DedendumCircleDiameter = calculator.CalculateStandardPinionDedendumCircleDiameter(_gearPair);
            _gearPair.Gear.GearString = ToSimpleGearString(_gearPair.Gear);
            _gearPair.Pinion.GearString = ToSimpleGearString(_gearPair.Pinion);
        }

        private string ToSimpleGearString(IGear gear)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Item ".PadRight(30) + "Metric".PadRight(30) + "Imperial");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("Normal Module".PadRight(30) + gear.NormalModule.ToString("0.000").PadRight(30) +
                                     (25.4 / gear.NormalModule).ToString("0.0000 in DP") + ", " +
                                     (Math.PI / (25.4 / gear.NormalModule)).ToString("0.0000 in CP"));
            stringBuilder.AppendLine("Radial Module".PadRight(30) + gear.TransverseModule.ToString("0.000").PadRight(30) +
                                     (25.4 / gear.TransverseModule).ToString("0.0000 in DP") + ", " +
                                     (Math.PI / (25.4 / gear.TransverseModule)).ToString("0.0000 in CP"));
            stringBuilder.AppendLine("Normal Pressure Angle".PadRight(30) + gear.NormalPressureAngle.ToString("0.000°").PadRight(30) +
                                     gear.NormalPressureAngle.ToString("0.000°"));
            stringBuilder.AppendLine("Radial Pressure Angle".PadRight(30) + gear.RadialPressureAngle.ToString("0.000°").PadRight(30) +
                                     gear.RadialPressureAngle.ToString("0.000°"));
            stringBuilder.AppendLine(
                "Helix Angle".PadRight(30) + gear.HelixAngle.ToString("0.000°").PadRight(30) + gear.HelixAngle.ToString("0.000°"));
            stringBuilder.AppendLine("Number Of Teeth".PadRight(30) + gear.NumberOfTeeth.ToString().PadRight(30) + gear.NumberOfTeeth.ToString());
            stringBuilder.AppendLine("Base Diameter".PadRight(30) + gear.BaseDiameter.ToString("0.000 mm").PadRight(30) +
                                     (gear.BaseDiameter / 25.4).ToString("0.0000 in"));
            stringBuilder.AppendLine("Root Diameter".PadRight(30) + gear.RootDiameter.ToString("0.000 mm").PadRight(30) +
                                     (gear.BaseDiameter / 25.4).ToString("0.0000 in"));
            stringBuilder.AppendLine("Pitch Diameter".PadRight(30) + gear.PitchDiameter.ToString("0.000 mm").PadRight(30) +
                                     (gear.RootDiameter / 25.4).ToString("0.0000 in"));
            stringBuilder.AppendLine("Outside Diameter".PadRight(30) + gear.OutsideDiameter.ToString("0.000 mm").PadRight(30) +
                                     (gear.OutsideDiameter / 25.4).ToString("0.0000 in"));
            stringBuilder.AppendLine("Addendum".PadRight(30) + gear.Addendum.ToString("0.000 mm").PadRight(30) +
                                     (gear.Addendum / 25.4).ToString("0.0000 in"));
            stringBuilder.AppendLine("Dedendum".PadRight(30) + gear.Dedendum.ToString("0.000 mm").PadRight(30) +
                                     (gear.Dedendum / 25.4).ToString("0.0000 in"));
            stringBuilder.AppendLine("Whole Depth".PadRight(30) + gear.WholeDepth.ToString("0.000 mm").PadRight(30) +
                                     (gear.WholeDepth / 25.4).ToString("0.0000 in"));
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(
                "Note: This utility will create standard External Spur and Helical Gears only. " +
                "The generated gear will almost certainly need to be edited in Alibre for gear height and " +
                "in the case of helical gears for hand (Left or Right) of the helix.  ");
            stringBuilder.AppendLine("Also note that this utility does not generate gears with an undercut to the tooth profile. " +
                                     "This can be a problem for gears with a low tooth count (typically <= 17) and/or a high helix angle.");

            stringBuilder.AppendLine("Finally, be aware that gears (particularly helical) with high tooth counts may take a very long time to generate!");
                return stringBuilder.ToString();
        }


        private void ViewOnEditGearNumberOfTeethEvent(object sender, EventArgs e)
        {
            _gearPair.Gear.NumberOfTeeth = (double) ((NumericUpDown) sender).Value;
            _gearPair.Pinion.NumberOfTeeth = (double) ((NumericUpDown) sender).Value;
        }

        private void ViewOnEditModuleEvent(object sender, EventArgs e)
        {
            _gearPair.Gear.NormalModule = (double) ((NumericUpDown) sender).Value;
            _gearPair.Pinion.NormalModule = (double) ((NumericUpDown) sender).Value;
        }

        private void ViewOnEditHelixAngleEvent(object sender, EventArgs e)
        {
            _gearPair.Gear.HelixAngle = (double) ((NumericUpDown) sender).Value;
            _gearPair.Pinion.HelixAngle = (double) ((NumericUpDown) sender).Value;
        }

        private void ViewOnEditPressureAngleEvent(object sender, EventArgs e)
        {
            _gearPair.Gear.NormalPressureAngle = (double) ((NumericUpDown) sender).Value;
            _gearPair.Pinion.NormalPressureAngle = (double) ((NumericUpDown) sender).Value;
        }

        private void ViewOnCancelEvent(object sender, EventArgs e)
        {
            _view.FindForm().Close();
        }

        private void ViewOnBuildWheelEvent(object sender, EventArgs e)
        {
            var saveFile = "WheelPleaseSaveAs.AD_PRT";
            var template = "WheelTemplate.AD_PRT";

            if (_gearPair.Gear.HelixAngle > 0)
            {
                saveFile = "HelicalWheelPleaseSaveAs.AD_PRT";
                template = "HelicalWheelTemplate.AD_PRT";
            }

            BuildGear(saveFile, template);
        }

        private void BuildGear(string saveFile, string template)
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

            var filePath = Globals.InstallPath;

            if (filePath != null)
            {
                filePath += "\\Gear\\" + template;
            }

            File.Copy(filePath, tempFile, true);

            var gearToothPoints = new GearToothPoints
            {
                GearCentre = new GearPoint(0, 0),
                // gear is helical if the helix pitch angle is greater than 0 degrees.
                IsHelical = _gearPair.Gear.HelixAngle > 0,
                IsPinion = false,
            };

            InvoluteGear gear = new InvoluteGear(_gearPair.Gear.NormalModule, (int) _gearPair.Gear.NumberOfTeeth, _gearPair.Gear.NormalPressureAngle,
                _gearPair.Gear.HelixAngle, 0);
            gear.GearType = GearType.External;
            gear.RootFilletFactorRf = 0.38;
            gear.AddendumFilletFactorRa = 0.1;
            gear.CircularBacklashBc = 0.0;
            gear.WorkingCentreDistanceAw = _gearPair.Gear.StandardCentreDistance;
            InvoluteGear matingGear = new InvoluteGear(_gearPair.Gear.NormalModule, (int) _gearPair.Gear.NumberOfTeeth,
                _gearPair.Gear.NormalPressureAngle, _gearPair.Gear.HelixAngle, 0);
            matingGear.GearType = GearType.External;
            matingGear.RootFilletFactorRf = 0.38;
            matingGear.AddendumFilletFactorRa = 0.1;
            matingGear.CircularBacklashBc = 0.0;
            matingGear.WorkingCentreDistanceAw = _gearPair.Gear.StandardCentreDistance;
            gear.MatingGear = matingGear;
            matingGear.MatingGear = gear;
            gearToothPoints.G1 = gear;

            gearBuilder.BuildGearToothPoints(gearToothPoints);

            gearToothPoints.TemplateFilePath = tempFile;

            IADDesignSession session = InitAlibrePinionFile(tempFile, true);

            AlibreBuilder.CreateInstance(gearToothPoints, session);
        }

        public IADDesignSession InitAlibrePinionFile(string filePath, bool openEditor)
        {
            IADRoot root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
            IADDesignSession session = (IADDesignSession) root.OpenFileEx(filePath, true);
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
    }
}