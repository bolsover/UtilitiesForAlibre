using System;
using System.IO;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Bevel.Builder;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Views;
using static Bolsover.Bevel.Calculator.BevelGearCalculator;
using static Bolsover.Utils.LatexUtils;

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
            GearsOnUpdated(null, null);
            BindData();
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
                GearType = "Standard"
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
                GearType = "Standard"
            };
        }

        private void GearsOnUpdated(object sender, EventArgs e)
        {
            StandardCalculations();
        }


        private void SetupLabelLatexImages()
        {
            var view = (BevelGearView)_view;
            view.ShaftAngleLabel.Image = CreateImageFromLatex(BevelLatexStrings.ShaftAngleLatex);
            view.ModuleLabel.Image = CreateImageFromLatex(BevelLatexStrings.ModuleLatex);
          
            CreateImageFromLatex(BevelLatexStrings.RadialPressureAngleFormulaLatex);
            view.NumberOfTeethLabel.Image = CreateImageFromLatex(BevelLatexStrings.NumberOfTeethLatex);
            view.FaceWidthLabel.Image = CreateImageFromLatex(BevelLatexStrings.FaceWidthLatex);
            view.FaceWidthFormulaLabel.Image = CreateImageFromLatex(BevelLatexStrings.FaceWidthFormulaLatex);
        }

        private void BindData()
        {
            var view = (BevelGearView)_view;


            view.PinionTextBox.DataBindings.Add("Text", _pinion, "stringValue", true,
                DataSourceUpdateMode.OnPropertyChanged, null, null, null);

            view.GearTextBox.DataBindings.Add("Text", _gear, "stringValue", true,
                DataSourceUpdateMode.OnPropertyChanged, null, null, null);
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


        private void StandardCalculations()
        {
            _pinion.PitchDiameter = CalculateStandardPinionPitchDiameter(_pinion);
            _pinion.PitchConeAngle = CalculateStandardPinionPitchConeAngle(_pinion, _gear);
            _pinion.ConeDistance = CalculatePinionConeDistance(_pinion, _gear);
            _pinion.Addendum = CalculateStandardPinionAddendum(_pinion);
            _pinion.Dedendum = CalculateStandardPinionDedendum(_pinion);
            _pinion.DedendumAngle = CalculateStandardPinionDedendumAngle(_pinion, _gear);
            _pinion.AddendumAngle = CalculateStandardPinionAddendumAngle(_pinion, _gear);
            _pinion.OuterConeAngle = CalculateStandardPinionOuterConeAngle(_pinion, _gear);
            _pinion.RootConeAngle = CalculateStandardPinionRootConeAngle(_pinion, _gear);
            _pinion.OutsideDiameter = CalculateStandardPinionOutsideDiameter(_pinion, _gear);
            _pinion.PitchApexToCrown = CalculateStandardPinionPitchApexToCrown(_pinion, _gear);
            _pinion.AxialFaceWidth = CalculateStandardPinionAxialFaceWidth(_pinion, _gear);
            _pinion.InnerOutsideDiameter = CalculateStandardPinionInnerOutsideDiameter(_pinion, _gear);
            _pinion.RadialPressureAngle = CalculateGearRadialPressureAngle(_pinion, _gear);
            _pinion.EquivalentPitchDiameter = CalculateTredgoldPinionEquivalentPitchDiameter(_pinion, _gear);
            _pinion.EquivalentBaseDiameter = CalculateTredgoldPinionEquivalentBaseDiameter(_pinion, _gear);
            _pinion.EquivalentAddendumDiameter = CalculateTredgoldPinionEquivalentAddendumDiameter(_pinion, _gear);
            _pinion.EquivalentRootDiameter = CalculateTredgoldPinionEquivalentRootDiameter(_pinion, _gear);
            _pinion.BackConeDistance = CalculateStandardPinionBackConeDistance(_pinion, _gear);
            var x = CalculateStandardPinionBackConeAngle(_pinion, _gear);
            _pinion.BackConeAngle = x;
           // _pinion.BackConeAngle = CalculateStandardGearPitchConeAngle(_pinion, _gear);
            _pinion.StringValue = "Pinion\r\n" + _pinion;
            _gear.PitchDiameter = CalculateStandardGearPitchDiameter(_gear);
            _gear.PitchConeAngle = CalculateStandardGearPitchConeAngle(_pinion, _gear);
            _gear.ConeDistance = CalculateGearConeDistance(_pinion, _gear);
            _gear.Addendum = CalculateStandardGearAddendum(_gear);
            _gear.Dedendum = CalculateStandardGearDedendum(_gear);
            _gear.DedendumAngle = CalculateStandardGearDedendumAngle(_pinion, _gear);
            _gear.AddendumAngle = CalculateStandardGearAddendumAngle(_pinion, _gear);
            _gear.OuterConeAngle = CalculateStandardGearOuterConeAngle(_pinion, _gear);
            _gear.RootConeAngle = CalculateStandardGearRootConeAngle(_pinion, _gear);
            _gear.OutsideDiameter = CalculateStandardGearOutsideDiameter(_pinion, _gear);
            _gear.PitchApexToCrown = CalculateStandardGearPitchApexToCrown(_pinion, _gear);
            _gear.AxialFaceWidth = CalculateStandardGearAxialFaceWidth(_pinion, _gear);
            _gear.InnerOutsideDiameter = CalculateStandardGearInnerOutsideDiameter(_pinion, _gear);
            _gear.RadialPressureAngle = CalculateGearRadialPressureAngle(_pinion, _gear);
            _gear.EquivalentPitchDiameter = CalculateTredgoldGearEquivalentPitchDiameter(_pinion, _gear);
            _gear.EquivalentBaseDiameter = CalculateTredgoldGearEquivalentBaseDiameter(_pinion, _gear);
            _gear.EquivalentAddendumDiameter = CalculateTredgoldGearEquivalentAddendumDiameter(_pinion, _gear);
            _gear.EquivalentRootDiameter = CalculateTredgoldGearEquivalentRootDiameter(_pinion, _gear);
            _gear.BackConeDistance = CalculateStandardGearBackConeDistance(_pinion, _gear);
            _gear.BackConeAngle = CalculateStandardPinionPitchConeAngle(_pinion, _gear);
            _gear.StringValue = "Gear\r\n" + _gear;
        }
    }
}