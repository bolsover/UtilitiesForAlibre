using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Bevel.Builder;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Views;
using static Bolsover.Bevel.Calculator.BevelGearCalculator;
using static Bolsover.Utils.LatexUtils;
using BrightIdeasSoftware;

namespace Bolsover.Bevel.Presenters
{
    public sealed class BevelGearPresenter
    {
        private readonly IBevelGearView _view;
        private IBevelGear _pinion;
        private IBevelGear _gear;


        public BevelGearPresenter(IBevelGearView view)
        {
            _view = view;
            InitGearDefaults();
            SetupEvents();
            SetupObjectListView(); 
            GearsOnUpdated(null, null);
            SetupLabelLatexImages();
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
                GearType = BevelGearType.Standard
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
                GearType = BevelGearType.Standard
            };
        }

        private void GearsOnUpdated(object sender, EventArgs e)
        {
            StandardCalculations();
            var data = BuildBevelGearData();
            ((BevelGearView)_view).objectListView1.SetObjects(data);
            UpdateNotesLabel(_gear.GearType);
        }

        private void SetupObjectListView()
        {
            ((BevelGearView)_view).olvColumn1.AspectGetter = rowObject => ((BevelGearData)rowObject).Item;
            ((BevelGearView)_view).olvColumn2.AspectGetter = rowObject => ((BevelGearData)rowObject).PinionMetricValue;
            ((BevelGearView)_view).olvColumn3.AspectGetter = rowObject => ((BevelGearData)rowObject).PinionImperialValue;
            ((BevelGearView)_view).olvColumn4.AspectGetter = rowObject => ((BevelGearData)rowObject).PinionNotes;
            ((BevelGearView)_view).olvColumn5.AspectGetter = rowObject => ((BevelGearData)rowObject).GearMetricValue;
            ((BevelGearView)_view).olvColumn6.AspectGetter = rowObject => ((BevelGearData)rowObject).GearImperialValue;
            ((BevelGearView)_view).olvColumn7.AspectGetter = rowObject => ((BevelGearData)rowObject).GearNotes;
        }


        private void SetupLabelLatexImages()
        {
            var view = (BevelGearView)_view;
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
            var view = (BevelGearView)_view;
            view.ParentForm?.Dispose();
        }


        private void ViewOnEditFaceWidthEvent(object sender, EventArgs e)
        {
            _pinion.FaceWidth = (double)((NumericUpDown)sender).Value;
            _gear.FaceWidth = (double)((NumericUpDown)sender).Value;
        }

        private void ViewOnEditGearHandEvent(object sender, EventArgs e)
        {
            _gear.Hand = (string)((ComboBox)sender).SelectedItem;
        }

        private void ViewOnEditGearNumberOfTeethEvent(object sender, EventArgs e)
        {
            _gear.NumberOfTeeth = (double)((NumericUpDown)sender).Value;
        }

        private void ViewOnEditPinionHandEvent(object sender, EventArgs e)
        {
            _pinion.Hand = (string)((ComboBox)sender).SelectedItem;
        }

        private void ViewOnEditGearTypeEvent(object sender, EventArgs e)
        {
            _gear.GearType = RadioButtonToGearType((RadioButton)sender);
            _pinion.GearType = RadioButtonToGearType((RadioButton)sender);
        }
        
        private void UpdateNotesLabel(BevelGearType gearType)
        {
            var view = (BevelGearView)_view;
            view.NotesLabel.Text = gearType switch
            {
                BevelGearType.Standard => "For Standard gears, the addendum (ha) is 1.000m and the dedendum (hf) 1.25m",
                BevelGearType.Gleason =>
                    "For Gleason gears, the addendum (ha) and dedendum (hf) are calculated using the formulae shown above.",
                _ => ""
            };
        }

        private static BevelGearType RadioButtonToGearType(RadioButton sender)
        {
            switch (sender.Name)
            {
                case "standardRadioButton":
                    return BevelGearType.Standard;
                case "gleasonRadioButton":
                    return BevelGearType.Gleason;
                default:
                    return BevelGearType.Standard;
            }
        }

        private void ViewOnEditPinionNumberOfTeethEvent(object sender, EventArgs e)
        {
            _pinion.NumberOfTeeth = (double)((NumericUpDown)sender).Value;
        }

        private void ViewOnEditSpiralAngleEvent(object sender, EventArgs e)
        {
            _pinion.SpiralAngle = (double)((NumericUpDown)sender).Value;
            _gear.SpiralAngle = (double)((NumericUpDown)sender).Value;
        }

        private void ViewOnEditPressureAngleEvent(object sender, EventArgs e)
        {
            _pinion.PressureAngle = (double)((NumericUpDown)sender).Value;
            _gear.PressureAngle = (double)((NumericUpDown)sender).Value;
        }

        private void ViewOnEditShaftAngleEvent(object sender, EventArgs e)
        {
            _pinion.ShaftAngle = (double)((NumericUpDown)sender).Value;
            _gear.ShaftAngle = (double)((NumericUpDown)sender).Value;
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
            _pinion.Module = (double)((NumericUpDown)sender).Value;
            _gear.Module = (double)((NumericUpDown)sender).Value;
        }

        private void BuildBevelGear(string saveFile, string template, IBevelGear bevelGear)
        {
            BevelGearBuilder.Build(saveFile, template, bevelGear);
        }

        private List<BevelGearData> BuildBevelGearData()
        {
            var data = new List<BevelGearData>();
            data.Add(new BevelGearData("Type", _pinion.GearType.ToString(), "", "", _gear.GearType.ToString(), "", ""));
            data.Add(new BevelGearData("Module", _pinion.Module.ToString("0.000"), (25.4 / _pinion.Module).ToString("0.0000 in DP"),
                (Math.PI / (25.4 / _pinion.Module)).ToString("0.0000 in CP"), _gear.Module.ToString("0.000"),
                (25.4 / _gear.Module).ToString("0.0000 in DP"), (Math.PI / (25.4 / _gear.Module)).ToString("0.0000 in CP")));
            data.Add(new BevelGearData("Teeth", _pinion.NumberOfTeeth.ToString("0"), "", "", _gear.NumberOfTeeth.ToString("0"), "", ""));
            data.Add(new BevelGearData("Shaft Angle", _pinion.ShaftAngle.ToString("0.000°"), "", "", _gear.ShaftAngle.ToString("0.000°"), "", ""));
            data.Add(new BevelGearData("Face Width", _pinion.FaceWidth.ToString("0.000 mm"), (_pinion.FaceWidth / 25.4).ToString("0.000 in"), "", _gear.FaceWidth.ToString("0.000 mm"), (_gear.FaceWidth / 25.4).ToString("0.000 in"),
                ""));
            data.Add(new BevelGearData("Pressure Angle", _pinion.PressureAngle.ToString("0.000°"), "", "", _gear.PressureAngle.ToString("0.000°"), "",
                ""));
            data.Add(new BevelGearData("Pitch Cone Angle", _pinion.PitchConeAngle.ToString("0.000°"), "", "", _gear.PitchConeAngle.ToString("0.000°"),
                "", ""));
            data.Add(new BevelGearData("Pitch Diameter", _pinion.PitchDiameter.ToString("0.000 mm"), (_pinion.PitchDiameter / 25.4).ToString("0.000 in"),
                "", _gear.PitchDiameter.ToString("0.000 mm"), (_gear.PitchDiameter / 25.4).ToString("0.000 in"), ""));
            data.Add(new BevelGearData("Cone Distance", _pinion.ConeDistance.ToString("0.000 mm"), (_pinion.ConeDistance / 25.4).ToString("0.000 in"),
                "", _gear.ConeDistance.ToString("0.000 mm"), (_gear.ConeDistance / 25.4).ToString("0.000 in"), ""));
            data.Add(new BevelGearData("Addendum", _pinion.Addendum.ToString("0.000 mm"), (_pinion.Addendum / 25.4).ToString("0.000 in"), "",
                _gear.Addendum.ToString("0.000 mm"), (_gear.Addendum / 25.4).ToString("0.000 in"), ""));
            data.Add(new BevelGearData("Dedendum", _pinion.Dedendum.ToString("0.000 mm"), (_pinion.Dedendum / 25.4).ToString("0.000 in"), "",
                _gear.Dedendum.ToString("0.000 mm"), (_gear.Dedendum / 25.4).ToString("0.000 in"), ""));
            data.Add(new BevelGearData("Equivalent Pitch Diameter", _pinion.EquivalentPitchDiameter.ToString("0.000 mm"),
                (_pinion.EquivalentPitchDiameter / 25.4).ToString("0.000 in"), "", _gear.EquivalentPitchDiameter.ToString("0.000 mm"),
                (_gear.EquivalentPitchDiameter / 25.4).ToString("0.000 in"), ""));
            data.Add(new BevelGearData("Equivalent Base Diameter", _pinion.EquivalentBaseDiameter.ToString("0.000 mm"),
                (_pinion.EquivalentBaseDiameter / 25.4).ToString("0.000 in"), "", _gear.EquivalentBaseDiameter.ToString("0.000 mm"),
                (_gear.EquivalentBaseDiameter / 25.4).ToString("0.000 in"), ""));
            data.Add(new BevelGearData("Equivalent Addendum Diameter", _pinion.EquivalentAddendumDiameter.ToString("0.000 mm"),
                (25.4 / _pinion.EquivalentAddendumDiameter / 25.4).ToString("0.000 in"), "", _gear.EquivalentAddendumDiameter.ToString("0.000 mm"),
                (_gear.EquivalentAddendumDiameter / 25.4).ToString("0.000 in"), ""));
            data.Add(new BevelGearData("Equivalent Root Diameter", _pinion.EquivalentRootDiameter.ToString("0.000 mm"),
                (_pinion.EquivalentRootDiameter / 25.4).ToString("0.000 in"), "", _gear.EquivalentRootDiameter.ToString("0.000 mm"),
                (_gear.EquivalentRootDiameter / 25.4).ToString("0.000 in"), ""));
            data.Add(new BevelGearData("Back Cone Angle", _pinion.BackConeAngle.ToString("0.000°"), "", "", _gear.BackConeAngle.ToString("0.000°"),
                "", ""));

            return data;
        }


        private void StandardCalculations()
        {
            _pinion.PitchDiameter = CalculatePitchDiameter(_pinion, _gear).Item1;
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
            _pinion.StringValue = "Pinion\r\n" + _pinion;
            _gear.PitchDiameter = CalculatePitchDiameter(_pinion, _gear).Item2;
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
            _gear.StringValue = "Gear\r\n" + _gear;
        }
    }
}