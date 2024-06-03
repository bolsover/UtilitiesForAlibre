using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bolsover.Bevel.Builder;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Views;
using Bolsover.Involute.Model;
using static Bolsover.Bevel.Calculator.BevelGearCalculator;
using static Bolsover.Utils.LatexUtils;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Bevel.Presenters
{
    public sealed class BevelGearPresenter
    {
        private const string threeZero = "0.000";
        
        private const double mmToIn = 25.4;
        private readonly IBevelGearView _view;
        private bool _doOnce;
        private IBevelGear _gear;
        private IBevelGear _pinion;
        
        
        public BevelGearPresenter(IBevelGearView view)
        {
            _view = view;
            InitGearDefaults();
            SetupEvents();
            SetupObjectListView();
            GearsOnUpdated(null, null);
            SetupLabelLatexImages();
            // ((BevelGearView)_view).documentationLink.Links.Add(0,2,"http://www.bolsover.com/UtilitiesForAlibre");
            // ((BevelGearView)_view).documentationLink.LinkClicked += DocumentationLinkOnLinkClicked;
        }
        
        private void SetupEvents()
        {
            _view.EditModuleEvent += ViewOnEditModuleEvent;
            _view.BuildPinionEvent += ViewOnBuildPinionEvent;
            _view.BuildGearEvent += ViewOnBuildGearEvent;
            _view.EditShaftAngleEvent += ViewOnEditShaftAngleEvent;
            _view.EditPressureAngleEvent += ViewOnEditPressureAngleEvent;
            _view.EditPinionNumberOfTeethEvent += ViewOnEditPinionNumberOfTeethEvent;
            _view.EditGearNumberOfTeethEvent += ViewOnEditGearNumberOfTeethEvent;
            _view.EditFaceWidthEvent += ViewOnEditFaceWidthEvent;
            _view.EditGearTypeEvent += ViewOnEditGearTypeEvent;
            _view.CancelEvent += ViewOnCancelEvent;
            _pinion.Updated += GearsOnUpdated;
            _gear.Updated += GearsOnUpdated;
        }
        
        private void InitGearDefaults()
        {
            _pinion = new BevelGear
            {
                ShaftAngle = 90d,
                SpiralAngle = 0d,
                Module = 3.0d,
                PressureAngle = 20.0d,
                FaceWidth = 22.0d,
                NumberOfTeeth = 20.0d,
                Hand = "L",
                GearType = GearStyle.BevelStandard
            };
            _gear = new BevelGear
            {
                ShaftAngle = 90d,
                SpiralAngle = 0d,
                Module = 3.0d,
                PressureAngle = 20.0d,
                FaceWidth = 22.0d,
                NumberOfTeeth = 40.0d,
                Hand = "R",
                GearType = GearStyle.BevelStandard
            };
        }
        
        private void GearsOnUpdated(object sender, EventArgs e)
        {
            StandardCalculations();
            var data = BuildBevelGearData();
            ((BevelGearView) _view).objectListView1.SetObjects(data);
            if (!_doOnce)
            {
                ((BevelGearView) _view).objectListView1.AutoResizeColumns();
                _doOnce = true;
            }
            
            UpdateNotesLabel(_gear.GearType);
        }
        
        private void SetupObjectListView()
        {
            ((BevelGearView) _view).olvColumn1.AspectGetter = rowObject => ((BevelGearData) rowObject).Item;
            ((BevelGearView) _view).olvColumn2.AspectGetter = rowObject => ((BevelGearData) rowObject).PinionMetricValue;
            ((BevelGearView) _view).olvColumn3.AspectGetter = rowObject => ((BevelGearData) rowObject).PinionImperialValue;
            ((BevelGearView) _view).olvColumn4.AspectGetter = rowObject => ((BevelGearData) rowObject).PinionNotes;
            ((BevelGearView) _view).olvColumn5.AspectGetter = rowObject => ((BevelGearData) rowObject).GearMetricValue;
            ((BevelGearView) _view).olvColumn6.AspectGetter = rowObject => ((BevelGearData) rowObject).GearImperialValue;
            ((BevelGearView) _view).olvColumn7.AspectGetter = rowObject => ((BevelGearData) rowObject).GearNotes;
        }
        
        
        private void SetupLabelLatexImages()
        {
            var view = (BevelGearView) _view;
            view.ShaftAngleLabel.Image = CreateImageFromLatex(BevelLatexStrings.ShaftAngleLatex);
            view.ModuleLabel.Image = CreateImageFromLatex(BevelLatexStrings.ModuleLatex);
            view.PressureAngleLabel.Image = CreateImageFromLatex(BevelLatexStrings.PressureAngleLatex);
            view.standardLabel.Image = CreateImageFromLatex(BevelLatexStrings.StandardLatex);
            view.gleasonLabel.Image = CreateImageFromLatex(BevelLatexStrings.GleasonLatex);
            view.NumberOfTeethLabel.Image = CreateImageFromLatex(BevelLatexStrings.NumberOfTeethLatex);
            view.FaceWidthLabel.Image = CreateImageFromLatex(BevelLatexStrings.FaceWidthLatex);
            view.FaceWidthFormulaLabel.Image = CreateImageFromLatex(BevelLatexStrings.FaceWidthFormulaLatex);
        }
        
        
        private void ViewOnCancelEvent(object sender, EventArgs e)
        {
            var view = (BevelGearView) _view;
            view.ParentForm?.Dispose();
        }
        
        
        private void ViewOnEditFaceWidthEvent(object sender, EventArgs e)
        {
            _pinion.FaceWidth = (double) ((NumericUpDown) sender).Value;
            _gear.FaceWidth = (double) ((NumericUpDown) sender).Value;
        }
        
        private void ViewOnEditGearHandEvent(object sender, EventArgs e)
        {
            _gear.Hand = (string) ((ComboBox) sender).SelectedItem;
        }
        
        private void ViewOnEditGearNumberOfTeethEvent(object sender, EventArgs e)
        {
            _gear.NumberOfTeeth = (double) ((NumericUpDown) sender).Value;
        }
        
        private void ViewOnEditPinionHandEvent(object sender, EventArgs e)
        {
            _pinion.Hand = (string) ((ComboBox) sender).SelectedItem;
        }
        
        private void ViewOnEditGearTypeEvent(object sender, EventArgs e)
        {
            _gear.GearType = RadioButtonToGearType((RadioButton) sender);
            _pinion.GearType = RadioButtonToGearType((RadioButton) sender);
        }
        
        private void UpdateNotesLabel(GearStyle gearType)
        {
            var view = (BevelGearView) _view;
            view.NotesLabel.Text = gearType switch
            {
                GearStyle.BevelStandard => "For Standard gears, the addendum (ha) is 1.000m and the dedendum (hf) 1.25m",
                GearStyle.BevelGleason =>
                    "For Gleason gears, the addendum (ha) and dedendum (hf) are calculated using the formulae shown above.",
                _ => ""
            };
        }
        
        private static GearStyle RadioButtonToGearType(RadioButton sender)
        {
            switch (sender.Name)
            {
                case "standardRadioButton":
                    return GearStyle.BevelStandard;
                case "gleasonRadioButton":
                    return GearStyle.BevelGleason;
                default:
                    return GearStyle.BevelStandard;
            }
        }
        
        private void ViewOnEditPinionNumberOfTeethEvent(object sender, EventArgs e)
        {
            var value = (double) ((NumericUpDown) sender).Value;
            // ensure minimum number of teeth for Gleason gears is 13
            if (_pinion.GearType == GearStyle.BevelGleason && value < 13)
            {
                value = 13;
                ((BevelGearView) _view).NumberOfTeethPinionNumericUpDown.Value = 13;
            }
            
            _pinion.NumberOfTeeth = value;
        }
        
        private void ViewOnEditSpiralAngleEvent(object sender, EventArgs e)
        {
            _pinion.SpiralAngle = (double) ((NumericUpDown) sender).Value;
            _gear.SpiralAngle = (double) ((NumericUpDown) sender).Value;
        }
        
        private void ViewOnEditPressureAngleEvent(object sender, EventArgs e)
        {
            _pinion.PressureAngle = (double) ((NumericUpDown) sender).Value;
            _gear.PressureAngle = (double) ((NumericUpDown) sender).Value;
        }
        
        private void ViewOnEditShaftAngleEvent(object sender, EventArgs e)
        {
            _pinion.ShaftAngle = (double) ((NumericUpDown) sender).Value;
            _gear.ShaftAngle = (double) ((NumericUpDown) sender).Value;
        }
        
        private void ViewOnBuildGearEvent(object sender, EventArgs e)
        {
            const string saveFile = "BevelPleaseSaveAs.AD_PRT";
            const string template = "BevelGearTemplate.AD_PRT";
            
            BuildBevelGear(saveFile, template, _gear);
        }
        
        private void ViewOnBuildPinionEvent(object sender, EventArgs e)
        {
            const string saveFile = "BevelPleaseSaveAs.AD_PRT";
            const string template = "BevelGearTemplate.AD_PRT";
            BuildBevelGear(saveFile, template, _pinion);
        }
        
        private void ViewOnEditModuleEvent(object sender, EventArgs e)
        {
            _pinion.Module = (double) ((NumericUpDown) sender).Value;
            _gear.Module = (double) ((NumericUpDown) sender).Value;
        }
        
        private void BuildBevelGear(string saveFile, string template, IBevelGear bevelGear)
        {
            _ = BevelGearBuilder.Build(saveFile, template, bevelGear);
        }
        
        
        private List<BevelGearData> BuildBevelGearData()
        {
            var data = new List<BevelGearData>();
            data.Add(new BevelGearData("Type", _pinion.GearType.ToString(), "", "", _gear.GearType.ToString(), "", ""));
            data.Add(new BevelGearData("Module", ToFormat(_pinion.Module, threeZero),
                ToFormat(mmToIn / _pinion.Module, "0.0000 in DP"),
                ToFormat(Math.PI / (mmToIn / _pinion.Module), "0.0000 in CP"), ToFormat(_gear.Module, threeZero),
                (mmToIn / _gear.Module).ToString("0.0000 in DP"),
                ToFormat(Math.PI / (mmToIn / _gear.Module), "0.0000 in CP")));
            data.Add(new BevelGearData("Teeth", _pinion.NumberOfTeeth.ToString("0"), "", "",
                _gear.NumberOfTeeth.ToString("0"), "", ""));
            data.Add(new BevelGearData("Shaft Angle", ToDegreeFormat(_pinion.ShaftAngle), "", "",
                ToDegreeFormat(_gear.ShaftAngle), "", ""));
            data.Add(new BevelGearData("Face Width", ToMmFormat(_pinion.FaceWidth), ToInchFormat(_pinion.FaceWidth), "",
                ToMmFormat(_gear.FaceWidth), ToInchFormat(_gear.FaceWidth),
                ""));
            data.Add(new BevelGearData("Pressure Angle", ToDegreeFormat(_pinion.PressureAngle), "", "",
                ToDegreeFormat(_gear.PressureAngle), "",
                ""));
            data.Add(new BevelGearData("Pitch Cone Angle", ToDegreeFormat(_pinion.PitchConeAngle), "", "",
                ToDegreeFormat(_gear.PitchConeAngle),
                "", ""));
            data.Add(new BevelGearData("Pitch Diameter", ToMmFormat(_pinion.PitchDiameter),
                ToInchFormat(_pinion.PitchDiameter),
                "", ToMmFormat(_gear.PitchDiameter), ToInchFormat(_gear.PitchDiameter), ""));
            data.Add(new BevelGearData("Base Diameter", ToMmFormat(_pinion.BaseDiameter), ToInchFormat(_pinion.BaseDiameter),
                "", ToMmFormat(_gear.BaseDiameter), ToInchFormat(_gear.BaseDiameter), ""));
            data.Add(new BevelGearData("Root Diameter", ToMmFormat(_pinion.RootDiameter),
                ToInchFormat(_pinion.RootDiameter),
                "", ToMmFormat(_gear.RootDiameter), ToInchFormat(_gear.RootDiameter), ""));
            
            data.Add(new BevelGearData("Cone Distance", ToMmFormat(_pinion.ConeDistance), ToInchFormat(_pinion.ConeDistance),
                "", ToMmFormat(_gear.ConeDistance), ToInchFormat(_gear.ConeDistance), ""));
            data.Add(new BevelGearData("Addendum", ToMmFormat(_pinion.Addendum), ToInchFormat(_pinion.Addendum), "",
                ToMmFormat(_gear.Addendum), ToInchFormat(_gear.Addendum), ""));
            data.Add(new BevelGearData("Dedendum", ToMmFormat(_pinion.Dedendum), ToInchFormat(_pinion.Dedendum), "",
                ToMmFormat(_gear.Dedendum), ToInchFormat(_gear.Dedendum), ""));
            data.Add(new BevelGearData("Equivalent Pitch Diameter", ToMmFormat(_pinion.EquivalentPitchDiameter),
                ToInchFormat(_pinion.EquivalentPitchDiameter), "", ToMmFormat(_gear.EquivalentPitchDiameter),
                ToInchFormat(_gear.EquivalentPitchDiameter), ""));
            data.Add(new BevelGearData("Equivalent Base Diameter", ToMmFormat(_pinion.EquivalentBaseDiameter),
                ToInchFormat(_pinion.EquivalentBaseDiameter), "", ToMmFormat(_gear.EquivalentBaseDiameter),
                ToInchFormat(_gear.EquivalentBaseDiameter), ""));
            data.Add(new BevelGearData("Equivalent Addendum Diameter", ToMmFormat(_pinion.EquivalentAddendumDiameter),
                ToInchFormat(_pinion.EquivalentAddendumDiameter), "", ToMmFormat(_gear.EquivalentAddendumDiameter),
                ToInchFormat(_gear.EquivalentAddendumDiameter), ""));
            data.Add(new BevelGearData("Equivalent Root Diameter", ToMmFormat(_pinion.EquivalentRootDiameter),
                ToInchFormat(_pinion.EquivalentRootDiameter), "", ToMmFormat(_gear.EquivalentRootDiameter),
                ToInchFormat(_gear.EquivalentRootDiameter), ""));
            data.Add(new BevelGearData("Back Cone Angle", ToDegreeFormat(_pinion.BackConeAngle), "", "",
                ToDegreeFormat(_gear.BackConeAngle),
                "", ""));
            if (_pinion.GearType == GearStyle.BevelGleason)
            {
                data.Add(new BevelGearData("KFactor", _pinion.KFactor.ToString(threeZero), "", "",
                    _gear.KFactor.ToString(threeZero),
                    "", ""));
                data.Add(new BevelGearData("Circular Thickness°", ToDegreeFormat(_pinion.CircularThicknessDegrees), "", "",
                    ToDegreeFormat(_gear.CircularThicknessDegrees),
                    "", ""));
                data.Add(new BevelGearData("Inter Tooth°", ToDegreeFormat(_pinion.InterToothDegrees), "", "",
                    ToDegreeFormat(_gear.InterToothDegrees),
                    "", ""));
            }
            
            return data;
        }
        
        
        private void StandardCalculations()
        {
            _pinion.PitchDiameter = CalculatePitchDiameter(_pinion, _gear).Item1;
            _pinion.BaseDiameter = CalculateBaseDiameter(_pinion, _gear).Item1;
            _pinion.RootDiameter = CalculateRootDiameter(_pinion, _gear).Item1;
            _pinion.PitchConeAngle = CalculatePitchConeAngle(_pinion, _gear).Item1;
            _pinion.ConeDistance = CalculatePitchConeDistance(_pinion, _gear).Item1;
            _pinion.Addendum = CalculateAddendum(_pinion, _gear).Item1;
            _pinion.Dedendum = CalculateDedendum(_pinion, _gear).Item1;
            _pinion.DedendumAngle = CalculateDedendumAngle(_pinion, _gear).Item1;
            _pinion.AddendumAngle = CalculateAddendumAngle(_pinion, _gear).Item1;
            _pinion.OuterConeAngle = CalculateOuterConeAngle(_pinion, _gear).Item1;
            _pinion.RootConeAngle = CalculateRootConeAngle(_pinion, _gear).Item1;
            _pinion.OutsideDiameter = CalculateOutsideDiameter(_pinion, _gear).Item1;
            _pinion.PitchApexToCrown = CalculatePitchApexToCrown(_pinion, _gear).Item1;
            _pinion.AxialFaceWidth = CalculateAxialFaceWidth(_pinion, _gear).Item1;
            _pinion.InnerOutsideDiameter = CalculateInnerOutsideDiameter(_pinion, _gear).Item1;
            _pinion.RadialPressureAngle = CalculateRadialPressureAngle(_pinion, _gear).Item1;
            _pinion.EquivalentPitchDiameter = CalculateTredgoldEquivalentPitchDiameter(_pinion, _gear).Item1;
            _pinion.EquivalentBaseDiameter = CalculateTredgoldEquivalentBaseDiameter(_pinion, _gear).Item1;
            _pinion.EquivalentAddendumDiameter = CalculateTredgoldEquivalentAddendumDiameter(_pinion, _gear).Item1;
            _pinion.EquivalentRootDiameter = CalculateTredgoldEquivalentRootDiameter(_pinion, _gear).Item1;
            _pinion.BackConeAngle = CalculateBackConeAngle(_pinion, _gear).Item1;
            _pinion.KFactor = CalculateKFactor(_pinion, _gear).Item1;
            _pinion.CircularThicknessDegrees = CalculateCircularThicknessDegrees(_pinion, _gear).Item1;
            _pinion.InterToothDegrees = CalculateInterToothDegrees(_pinion, _gear).Item1;
            _pinion.StringValue = "Pinion\r\n" + _pinion;
            _gear.PitchDiameter = CalculatePitchDiameter(_pinion, _gear).Item2;
            _gear.BaseDiameter = CalculateBaseDiameter(_pinion, _gear).Item2;
            _gear.RootDiameter = CalculateRootDiameter(_pinion, _gear).Item2;
            _gear.PitchConeAngle = CalculatePitchConeAngle(_pinion, _gear).Item2;
            _gear.ConeDistance = CalculatePitchConeDistance(_pinion, _gear).Item2;
            _gear.Addendum = CalculateAddendum(_pinion, _gear).Item2;
            _gear.Dedendum = CalculateDedendum(_pinion, _gear).Item2;
            _gear.DedendumAngle = CalculateDedendumAngle(_pinion, _gear).Item2;
            _gear.AddendumAngle = CalculateAddendumAngle(_pinion, _gear).Item2;
            _gear.OuterConeAngle = CalculateOuterConeAngle(_pinion, _gear).Item2;
            _gear.RootConeAngle = CalculateRootConeAngle(_pinion, _gear).Item2;
            _gear.OutsideDiameter = CalculateOutsideDiameter(_pinion, _gear).Item2;
            _gear.PitchApexToCrown = CalculatePitchApexToCrown(_pinion, _gear).Item2;
            _gear.AxialFaceWidth = CalculateAxialFaceWidth(_pinion, _gear).Item2;
            _gear.InnerOutsideDiameter = CalculateInnerOutsideDiameter(_pinion, _gear).Item2;
            _gear.RadialPressureAngle = CalculateRadialPressureAngle(_pinion, _gear).Item2;
            _gear.EquivalentPitchDiameter = CalculateTredgoldEquivalentPitchDiameter(_pinion, _gear).Item2;
            _gear.EquivalentBaseDiameter = CalculateTredgoldEquivalentBaseDiameter(_pinion, _gear).Item2;
            _gear.EquivalentAddendumDiameter = CalculateTredgoldEquivalentAddendumDiameter(_pinion, _gear).Item2;
            _gear.EquivalentRootDiameter = CalculateTredgoldEquivalentRootDiameter(_pinion, _gear).Item2;
            _gear.BackConeAngle = CalculateBackConeAngle(_pinion, _gear).Item2;
            _gear.KFactor = CalculateKFactor(_pinion, _gear).Item2;
            _gear.CircularThicknessDegrees = CalculateCircularThicknessDegrees(_pinion, _gear).Item2;
            _gear.InterToothDegrees = CalculateInterToothDegrees(_pinion, _gear).Item2;
            _gear.StringValue = "Gear\r\n" + _gear;
        }
    }
}