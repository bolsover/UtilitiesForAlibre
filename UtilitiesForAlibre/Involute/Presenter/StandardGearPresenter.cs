using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Gear.Builder;
using Bolsover.Gear.Models;
using Bolsover.Involute.Calculator;
using Bolsover.Involute.View;
using static Bolsover.Gear.Images.GearLatexStrings;
using static Bolsover.Utils.LatexUtils;

namespace Bolsover.Involute.Presenter
{
    public sealed class StandardGearPresenter
    {
        private readonly StandardGearView _view;
        private readonly IGearPair _gearPair;
        private readonly StandardHelicalGearCalculator _calculator = new();
        private const string GearSubDirectory = "\\Gear\\";
        private const double RootFilletFactorRf = 0.38;
        private const double AddendumFilletFactorRa = 0.1;
        private const double CircularBacklashBc = 0.0;
        private const double ProfileShiftx = 0;


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
                NormalCoefficientOfProfileShift = 0,
                TipReliefRadius = 0.25,
                RootFilletFactor = 0.38,
                CentreDistanceIncrementFactor = 0,
                WorkingCentreDistance = 50,
                Type = GearType.External
            };

            var pinion = new Bolsover.Gear.Models.Gear
            {
                NormalModule = 1.0,
                NormalPressureAngle = 20.0,
                HelixAngle = 0,
                NumberOfTeeth = 50.0,
                NormalCoefficientOfProfileShift = 0,
                TipReliefRadius = 0.25,
                RootFilletFactor = 0.38,
                CentreDistanceIncrementFactor = 0,
                WorkingCentreDistance = 50,
                Type = GearType.External
            };
            _gearPair.Gear = gear;
            _gearPair.Pinion = pinion;
            _gearPair.Auto = true;
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
            _view.EditGearHeightEvent += ViewOnEditGearHeightEvent;
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
            var gear = _gearPair.Gear;
            var pinion = _gearPair.Pinion;

            gear.TransverseModule = _calculator.CalculateTransverseModule(_gearPair);
            pinion.TransverseModule = _gearPair.Gear.TransverseModule;
            gear.RadialPressureAngle = _calculator.CalculateRadialPressureAngle(_gearPair);
            pinion.RadialPressureAngle = _gearPair.Gear.RadialPressureAngle;
            gear.InvoluteFunction = _calculator.CalculateTransverseInvoluteFunction(_gearPair);
            pinion.InvoluteFunction = _gearPair.Gear.InvoluteFunction;
            gear.StandardCentreDistance = _calculator.CalculateStandardCentreDistance(_gearPair);
            pinion.StandardCentreDistance = _gearPair.Gear.StandardCentreDistance;
            // for standard gears, working centre distance is the same as standard centre distance
            gear.WorkingCentreDistance = _gearPair.Gear.StandardCentreDistance;
            pinion.WorkingCentreDistance = _gearPair.Gear.StandardCentreDistance;
            gear.CentreDistanceIncrementFactor = _calculator.CalculateProfileShiftedCentreDistanceIncrementFactor(_gearPair);
            pinion.CentreDistanceIncrementFactor = _gearPair.Gear.CentreDistanceIncrementFactor;
            gear.NormalCoefficientOfProfileShift = _calculator.CalculateStandardCoefficientOfProfileShift();
            pinion.NormalCoefficientOfProfileShift = _gearPair.Gear.NormalCoefficientOfProfileShift;
            gear.RadialWorkingPressureAngle = _calculator.CalculateWorkingRadialPressureAngle(_gearPair);
            pinion.RadialWorkingPressureAngle = _gearPair.Gear.RadialWorkingPressureAngle;
            gear.PitchCircleDiameter = _calculator.CalculateGearStandardPitchDiameter(_gearPair);
            pinion.PitchCircleDiameter = _calculator.CalculatePinionStandardPitchDiameter(_gearPair);
            gear.BaseCircleDiameter = _calculator.CalculateGearBaseDiameter(_gearPair);
            pinion.BaseCircleDiameter = _calculator.CalculatePinionBaseDiameter(_gearPair);
            gear.Addendum = _calculator.CalculateGearAddendum(_gearPair);
            pinion.Addendum = _calculator.CalculatePinionAddendum(_gearPair);
            gear.Dedendum = _calculator.CalculateGearDedendum(_gearPair);
            pinion.Dedendum = _calculator.CalculatePinionDedendum(_gearPair);
            gear.WholeDepth = _calculator.CalculateWholeDepth(_gearPair);
            pinion.WholeDepth = _gearPair.Gear.WholeDepth;
            gear.OutsideDiameter = _calculator.CalculateGearOutsideDiameter(_gearPair);
            pinion.OutsideDiameter = _calculator.CalculatePinionOutsideDiameter(_gearPair);
            gear.RootCircleDiameter = _calculator.CalculateGearRootDiameter(_gearPair);
            pinion.RootCircleDiameter = _calculator.CalculatePinionRootDiameter(_gearPair);
            gear.AddendumCircleDiameter = _calculator.CalculateStandardGearAddendumCircleDiameter(_gearPair);
            pinion.AddendumCircleDiameter = _calculator.CalculateStandardPinionAddendumCircleDiameter(_gearPair);
            gear.DedendumCircleDiameter = _calculator.CalculateStandardGearDedendumCircleDiameter(_gearPair);
            pinion.DedendumCircleDiameter = _calculator.CalculateStandardPinionDedendumCircleDiameter(_gearPair);
            gear.GearString = ToSimpleGearString(_gearPair.Gear);
            pinion.GearString = ToSimpleGearString(_gearPair.Pinion);
        }


        private string ToSimpleGearString(IGear gear)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Item ".PadRight(30) + "Metric".PadRight(30) + "Imperial");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("Normal Module".PadRight(30) + gear.NormalModule.ToString("0.000").PadRight(30) +
                                     (25.4 / gear.NormalModule).ToString("0.0000 in DP") + ", " +
                                     (Math.PI / (25.4 / gear.NormalModule)).ToString("0.0000 in CP"));
            stringBuilder.AppendLine("Radial Module".PadRight(30) + gear.TransverseModule.ToString("0.000").PadRight(30) +
                                     (25.4 / gear.TransverseModule).ToString("0.0000 in DP") + ", " +
                                     (Math.PI / (25.4 / gear.TransverseModule)).ToString("0.0000 in CP"));

            stringBuilder.AppendLine(
                GetFormattedData("Normal Pressure Angle", gear.NormalPressureAngle, gear.NormalPressureAngle, "0.000°", "0.000°"));
            stringBuilder.AppendLine(
                GetFormattedData("Radial Pressure Angle", gear.RadialPressureAngle, gear.RadialPressureAngle, "0.000°", "0.000°"));
            stringBuilder.AppendLine(GetFormattedData("Helix Angle", gear.HelixAngle, gear.HelixAngle, "0.000°", "0.000°"));
            stringBuilder.AppendLine(GetFormattedData("Number Of Teeth", gear.NumberOfTeeth, gear.NumberOfTeeth, "0", "0"));
            stringBuilder.AppendLine(GetFormattedData("Base Diameter", gear.BaseCircleDiameter, gear.BaseCircleDiameter / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Root Diameter", gear.RootCircleDiameter, gear.RootCircleDiameter / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Pitch Diameter", gear.PitchCircleDiameter, gear.PitchCircleDiameter / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Outside Diameter", gear.OutsideDiameter, gear.OutsideDiameter / 25.4, "0.000 mm",
                "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Addendum", gear.Addendum, gear.Addendum / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Dedendum", gear.Dedendum, gear.Dedendum / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("WholeDepth", gear.WholeDepth, gear.WholeDepth / 25.4, "0.000 mm", "0.0000 in"));

           
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(
                "Note: This utility will create standard External Spur and Helical Gears only. " +
                "The generated gear will almost certainly need to be edited in Alibre to add centre hole/boss and " +
                "in the case of helical gears for hand (Left or Right) of the helix.  ");
            stringBuilder.AppendLine("Also note that this utility does not generate gears with an undercut to the tooth profile. " +
                                     "This can be a problem for gears with a low tooth count (typically <= 17) and/or a high helix angle.");

            stringBuilder.AppendLine(
                "Finally, be aware that gears (particularly helical) with high tooth counts may take a very long time to generate!");
            return stringBuilder.ToString();
        }

        private static string GetFormattedData(string columnName, double metricValue, double imperialValue, string metricFormat, string imperialFormat)
        {
            const int columnWidth = 30;
            var metric = metricValue.ToString(metricFormat);
            var imperial = imperialValue.ToString(imperialFormat);
            return $"{columnName,-columnWidth}{metric,-columnWidth}{imperial}";
            
        }


        private void ViewOnEditGearNumberOfTeethEvent(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown numericUpDown) return;
            var newValue = (double)numericUpDown.Value;
            _gearPair.Gear.NumberOfTeeth = newValue;
            _gearPair.Pinion.NumberOfTeeth = newValue;
        }

        private void ViewOnEditModuleEvent(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown numericUpDown) return;
            var newValue = (double)numericUpDown.Value;
            _gearPair.Gear.NormalModule = newValue;
            _gearPair.Pinion.NormalModule = newValue;

        }

        private void ViewOnEditHelixAngleEvent(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown numericUpDown) return;
            var newValue = (double)numericUpDown.Value;
            _gearPair.Gear.HelixAngle = newValue;
            _gearPair.Pinion.HelixAngle = newValue;

        }

        private void ViewOnEditPressureAngleEvent(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown numericUpDown) return;
            var newValue = (double)numericUpDown.Value;
            _gearPair.Gear.NormalPressureAngle = newValue;
            _gearPair.Pinion.NormalPressureAngle = newValue;

        }

        private void ViewOnEditGearHeightEvent(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown numericUpDown) return;
            var newValue = (double)numericUpDown.Value;
            _gearPair.Gear.Height = newValue;
            _gearPair.Pinion.Height = newValue;

        }

        private void ViewOnCancelEvent(object sender, EventArgs e) => _view.FindForm()!.Close();

       
        private void ViewOnBuildWheelEvent(object sender, EventArgs e)
        {
            var gearDetails = GetGearDetails();
            BuildGear(gearDetails.SaveFile, gearDetails.Template);
        }
    
        private (string SaveFile, string Template) GetGearDetails()
        {
            var isHelical = _gearPair.Gear.HelixAngle > 0;

            var saveFile = isHelical 
                ? "HelicalWheelPleaseSaveAs.AD_PRT" 
                : "WheelPleaseSaveAs.AD_PRT";

            var template = isHelical 
                ? "HelicalWheelTemplate.AD_PRT" 
                : "WheelTemplate.AD_PRT";
        
            return (saveFile, template);
        }

 


        private void BuildGear(string saveFile, string template)
        {
            var gearBuilder = new GearBuilder();

            var tempFile = Path.Combine(Path.GetTempPath(), saveFile);
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show($"Temporary file {saveFile} is currently open. \nPlease save-as or discard.", "Oops");
                return;
            }

            var filepath = $"{Globals.InstallPath}{GearSubDirectory}{template}";

           File.Copy(filepath, tempFile, true);

            var gearToothPoints = new GearToothPoints
            {
                GearCentre = new GearPoint(0, 0),
                // gear is helical if the helix pitch angle is greater than 0 degrees.
                IsHelical = _gearPair.Gear.HelixAngle > 0,
                IsPinion = false
            };

            var gear = CreateInvoluteGear(_gearPair.Gear);
            var matingGear = CreateInvoluteGear(_gearPair.Gear);
            gear.MatingGear = matingGear;
            matingGear.MatingGear = gear;
            gearToothPoints.G1 = gear;

            gearBuilder.BuildGearToothPoints(gearToothPoints);

            gearToothPoints.TemplateFilePath = tempFile;

            var session = InitAlibrePinionFile(tempFile);

            AlibreBuilder.CreateInstance(gearToothPoints, session);
        }

        private static InvoluteGear CreateInvoluteGear(IGear gearSettings)
        {
            return new InvoluteGear(
                gearSettings.NormalModule,
                (int) gearSettings.NumberOfTeeth,
                gearSettings.NormalPressureAngle,
                gearSettings.HelixAngle,
                ProfileShiftx)
            {
                GearTypeEnum = GearTypeEnum.External,
                RootFilletFactorRf = RootFilletFactorRf,
                AddendumFilletFactorRa = AddendumFilletFactorRa,
                CircularBacklashBc = CircularBacklashBc,
                WorkingCentreDistanceAw = gearSettings.StandardCentreDistance,
                Height = gearSettings.Height
            };
        }

        private static IADDesignSession InitAlibrePinionFile(string filePath)
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
    }
}