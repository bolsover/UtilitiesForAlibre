using System;
using System.IO;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Views;
using static Bolsover.Bevel.Presenters.BevelGearCalculator;
using static Bolsover.Utils.LatexUtils;

namespace Bolsover.Bevel.Presenters
{
    public sealed class BevelGearPresenter
    {
        private readonly IBevelGearView _view;
        private readonly IBevelGear _pinion;
        private readonly IBevelGear _gear;


        public BevelGearPresenter(IBevelGearView view, IBevelGear pinion, IBevelGear gear)
        {
            _view = view;
            _pinion = pinion;
            _gear = gear;

            _view.EditModuleEvent += ViewOnEditModuleEvent;
            _view.BuildPinionEvent += ViewOnBuildPinionEvent;
            _view.BuildGearEvent += ViewOnBuildGearEvent;
            _view.EditShaftAngleEvent += ViewOnEditShaftAngleEvent;
            _view.EditPressureAngleEvent += ViewOnEditPressureAngleEvent;
            _view.EditSpiralAngleEvent += ViewOnEditSpiralAngleEvent;
            _view.EditPinionNumberOfTeethEvent += ViewOnEditPinionNumberOfTeethEvent;
            _view.EditPinionHandEvent += ViewOnEditPinionHandEvent;
            _view.EditGearNumberOfTeethEvent += ViewOnEditGearNumberOfTeethEvent;
            _view.EditGearHandEvent += ViewOnEditGearHandEvent;
            _view.EditFaceWidthEvent += ViewOnEditFaceWidthEvent;
            _view.EditGearTypeEvent += ViewOnEditGearTypeEvent;
            _view.CancelEvent += ViewOnCancelEvent;

            _pinion.Updated += GearsOnUpdated;
            _gear.Updated += GearsOnUpdated;


            GearsOnUpdated(null, null);
            BindData();

            SetupLabelLatexImages();

            ((BevelGearView) _view).GearHandComboBox.SelectedIndex = 1;
            ((BevelGearView) _view).GearHandComboBox.Visible = false;
            ((BevelGearView) _view).PinionHandComboBox.SelectedIndex = 0;
            ((BevelGearView) _view).PinionHandComboBox.Visible = false;
        }

        private void GearsOnUpdated(object sender, EventArgs e)
        {
            var s = (string) ((BevelGearView) _view).GearTypeComboBox.SelectedItem;
            switch (s)
            {
                case "Standard":

                {
                    StandardCalculations();
                    break;
                }
                case "Gleason":

                {
                    GleasonCalculations();
                    break;
                }

                case "Gleason Zerol":

                {
                    GleasonCalculations();
                    break;
                }

                case "Gleason Spiral":

                {
                    GleasonSpiralCalculations();
                    break;
                }
            }
        }


        private void SetupLabelLatexImages()
        {
            var view = (BevelGearView) _view;
            view.ShaftAngleLabel.Image = CreateImageFromLatex(BevelLatexStrings.ShaftAngleLatex);
            view.ModuleLabel.Image = CreateImageFromLatex(BevelLatexStrings.ModuleLatex);
            view.PressureAngleLabel.Image = CreateImageFromLatex(BevelLatexStrings.PressureAngleLatex);
            view.SpiralAngleLabel.Image = CreateImageFromLatex(BevelLatexStrings.SpiralAngleLatex);

            view.RadialPressureAngleLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.RadialPressureAngleLatex);
            view.RadialPressureAngleFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.RadialPressureAngleFormulaLatex);
            view.NumberOfTeethLabel.Image = CreateImageFromLatex(BevelLatexStrings.NumberOfTeethLatex);

            view.PitchDiameterLabel.Image = CreateImageFromLatex(BevelLatexStrings.PitchDiameterLatex);
            view.PitchDiameterFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.PitchDiameterFormulaLatex);

            view.PitchConeAngle1Label.Image = CreateImageFromLatex(BevelLatexStrings.PitchConeAngle1Latex);
            view.PitchConeAngle1FormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.PitchConeAngle1FormulaLatex);

            view.PitchConeAngle2Label.Image = CreateImageFromLatex(BevelLatexStrings.PitchConeAngle2Latex);
            view.PitchConeAngle2FormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.PitchConeAngle2FormulaLatex);

            view.ConeDistanceLabel.Image = CreateImageFromLatex(BevelLatexStrings.ConeDistanceLatex);
            view.ConeDistanceFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.ConeDistanceFormulaLatex);

            view.FaceWidthLabel.Image = CreateImageFromLatex(BevelLatexStrings.FaceWidthLatex);
            view.FaceWidthFormulaLabel.Image = CreateImageFromLatex(BevelLatexStrings.FaceWidthFormulaLatex);

            view.Addendum1Label.Image = CreateImageFromLatex(BevelLatexStrings.Addendum1Latex);
            view.Addendum1FormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.AddendumHa1GleasonStraightFormulaLatex);

            view.Addendum2Label.Image = CreateImageFromLatex(BevelLatexStrings.Addendum2Latex);
            view.Addendum2FormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.AddendumHa2GleasonStraightFormulaLatex);

            view.DedendumLabel.Image = CreateImageFromLatex(BevelLatexStrings.DedendumLatex);
            view.DedendumFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.DedendumHfGleasonStraightFormulaLatex);

            view.DedendumAngleLabel.Image = CreateImageFromLatex(BevelLatexStrings.DedendumAngleLatex);
            view.DedendumAngleFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.DedendumAngleFormulaLatex);

            view.AddendumAngle1Label.Image = CreateImageFromLatex(BevelLatexStrings.AddendumAngle1Latex);
            view.AddendumAngle1FormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.AddendumAngle1FormulaLatex);

            view.AddendumAngle2Label.Image = CreateImageFromLatex(BevelLatexStrings.AddendumAngle2Latex);
            view.AddendumAngle2FormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.AddendumAngle2FormulaLatex);

            view.OuterConeAngleLabel.Image = CreateImageFromLatex(BevelLatexStrings.OuterConeAngleLatex);
            view.OuterConeAngleFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.OuterConeAngleFormulaLatex);

            view.RootConeAngleLabel.Image = CreateImageFromLatex(BevelLatexStrings.RootConeAngleLatex);
            view.RootConeAngleFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.RootConeAngleFormulaLatex);

            view.OutsideDiameterLabel.Image = CreateImageFromLatex(BevelLatexStrings.OutsideDiameterLatex);
            view.OutsideDiameterFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.OutsideDiameterFormulaLatex);

            view.PitchApexToCrownLabel.Image = CreateImageFromLatex(BevelLatexStrings.PitchApexToCrownLatex);
            view.PitchApexToCrownFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.PitchApexToCrownFormulaLatex);

            view.AxialFaceWidthLabel.Image = CreateImageFromLatex(BevelLatexStrings.AxialFaceWidthLatex);
            view.AxialFaceWidthFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.AxialFaceWidthFormulaLatex);

            view.InnerOutsideDiameterLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.InnerOutsideDiameterLatex);
            view.InnerOutsideDiameterFormulaLabel.Image =
                CreateImageFromLatex(BevelLatexStrings.InnerOutsideDiameterFormulaLatex);
        }

        private void BindData()
        {
            var view = (BevelGearView) _view;

            view.PitchDiameterPinionTextBox.DataBindings.Add("Text", _pinion, "pitchDiameter", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.PitchConeAnglePinionTextBox.DataBindings.Add("Text", _pinion, "pitchConeAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);
            view.ConeDistanceTextBox.DataBindings.Add("Text", _pinion, "coneDistance", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.AddendumPinionTextBox.DataBindings.Add("Text", _pinion, "addendum", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.DedendumPinionTextBox.DataBindings.Add("Text", _pinion, "dedendum", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.DedendumAnglePinionTextBox.DataBindings.Add("Text", _pinion, "dedendumAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);
            view.AddendumAnglePinionTextBox.DataBindings.Add("Text", _pinion, "addendumAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);
            view.OuterConeAnglePinionTextBox.DataBindings.Add("Text", _pinion, "outerConeAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);
            view.RootConeAnglePinionTextBox.DataBindings.Add("Text", _pinion, "rootConeAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);
            view.OutsideDiameterPinionTextBox.DataBindings.Add("Text", _pinion, "outsideDiameter", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.PitchApexToCrownPinionTextBox.DataBindings.Add("Text", _pinion, "pitchApexToCrown", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.AxialFaceWidthPinionTextBox.DataBindings.Add("Text", _pinion, "axialFaceWidth", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.InnerOutsideDiameterPinionTextBox.DataBindings.Add("Text", _pinion, "innerOutsideDiameter", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);


            view.PitchDiameterGearTextBox.DataBindings.Add("Text", _gear, "pitchDiameter", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.PitchConeAngleGearTextBox.DataBindings.Add("Text", _gear, "pitchConeAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);
            view.AddendumGearTextBox.DataBindings.Add("Text", _gear, "addendum", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.DedendumGearTextBox.DataBindings.Add("Text", _gear, "dedendum", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.DedendumAngleGearTextBox.DataBindings.Add("Text", _gear, "dedendumAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);
            view.AddendumAngleGearTextBox.DataBindings.Add("Text", _gear, "addendumAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);
            view.OuterConeAngleGearTextBox.DataBindings.Add("Text", _gear, "outerConeAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);
            view.RootConeAngleGearTextBox.DataBindings.Add("Text", _gear, "rootConeAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);
            view.OutsideDiameterGearTextBox.DataBindings.Add("Text", _gear, "outsideDiameter", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.PitchApexToCrownGearTextBox.DataBindings.Add("Text", _gear, "pitchApexToCrown", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.AxialFaceWidthGearTextBox.DataBindings.Add("Text", _gear, "axialFaceWidth", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.InnerOutsideDiameterGearTextBox.DataBindings.Add("Text", _gear, "innerOutsideDiameter", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000 mm", null);
            view.RadialPressureAngleTextBox.DataBindings.Add("Text", _pinion, "radialPressureAngle", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "0.0000°", null);


            view.PinionTextBox.DataBindings.Add("Text", _pinion, "stringValue", true,
                DataSourceUpdateMode.OnPropertyChanged, null, null, null);

            view.GearTextBox.DataBindings.Add("Text", _gear, "stringValue", true,
                DataSourceUpdateMode.OnPropertyChanged, null, null, null);
        }

        private void ViewOnCancelEvent(object sender, EventArgs e)
        {
            var view = (BevelGearView) _view;
            view.ParentForm?.Dispose();
        }


        private void ViewOnEditGearTypeEvent(object sender, EventArgs e)
        {
            _pinion.GearType = (string) ((ComboBox) sender).SelectedItem;
            _gear.GearType = (string) ((ComboBox) sender).SelectedItem;
            var s = (string) ((ComboBox) sender).SelectedItem;
            var view = (BevelGearView) _view;
            switch (s)
            {
                case "Standard":

                {
                    view.Addendum1FormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.StandardAddendumHaFormulaLatex);
                    view.DedendumFormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.StandardDedendumHfFormulaLatex);
                    view.Addendum2FormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.StandardAddendumHa2FormulaLatex);
                    view.SpiralAngleNumericUpDown.Value = decimal.Zero;
                    view.SpiralAngleNumericUpDown.Enabled = false;
                    view.PinionHandComboBox.Enabled = false;
                    view.PinionHandComboBox.Visible = false;
                    view.GearHandComboBox.Enabled = false;
                    view.GearHandComboBox.Visible = false;
                    GearsOnUpdated(null, null);
                    return;
                }

                case "Gleason":

                {
                    view.Addendum1FormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.AddendumHa1GleasonStraightFormulaLatex);
                    view.DedendumFormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.DedendumHfGleasonStraightFormulaLatex);
                    view.Addendum2FormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.AddendumHa2GleasonStraightFormulaLatex);
                    view.SpiralAngleNumericUpDown.Value = decimal.Zero;
                    view.SpiralAngleNumericUpDown.Enabled = false;
                    view.PinionHandComboBox.Enabled = false;
                    view.PinionHandComboBox.Visible = false;
                    view.GearHandComboBox.Enabled = false;
                    view.GearHandComboBox.Visible = false;
                    GearsOnUpdated(null, null);
                    return;
                }

                case "Gleason Zerol":

                {
                    view.SpiralAngleNumericUpDown.Value = decimal.Zero;
                    view.SpiralAngleNumericUpDown.Enabled = false;

                    // zerol gears use same addendum/dedendum formulae as straight gleason gears
                    view.Addendum1FormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.AddendumHa1GleasonStraightFormulaLatex);
                    view.DedendumFormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.DedendumHfGleasonStraightFormulaLatex);
                    view.Addendum2FormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.AddendumHa2GleasonStraightFormulaLatex);
                    view.PinionHandComboBox.Enabled = true;
                    view.PinionHandComboBox.Visible = true;
                    view.GearHandComboBox.Enabled = true;
                    view.GearHandComboBox.Visible = true;
                    GearsOnUpdated(null, null);
                    return;
                }

                case "Gleason Spiral":

                {
                    view.SpiralAngleNumericUpDown.Value = decimal.Zero;
                    view.SpiralAngleNumericUpDown.Enabled = true;
                    // throw new System.NotImplementedException();
                    // spiral gears use different addendum/dedendum formulae 
                    view.Addendum1FormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.AddendumHa1GleasonSpiralFormulaLatex);
                    view.DedendumFormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.DedendumGleasonSpiralFormulaLatex);
                    view.Addendum2FormulaLabel.Image =
                        CreateImageFromLatex(BevelLatexStrings.AddendumHa2GleasonSpiralFormulaLatex);
                    view.PinionHandComboBox.Enabled = true;
                    view.PinionHandComboBox.Visible = true;
                    view.GearHandComboBox.Enabled = true;
                    view.GearHandComboBox.Visible = true;
                    GearsOnUpdated(null, null);
                    return;
                }
            }
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

        private void ViewOnEditPinionNumberOfTeethEvent(object sender, EventArgs e)
        {
            _pinion.NumberOfTeeth = (double) ((NumericUpDown) sender).Value;
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

        private static void ViewOnBuildGearEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ViewOnBuildPinionEvent(object sender, EventArgs e)
        {
            const string saveFile = "BevelPleaseSaveAs.AD_PRT";
            const string template = "BevelGearTemplate.AD_PRT";


            BuildBevelGear(saveFile, template);
        }

        private void ViewOnEditModuleEvent(object sender, EventArgs e)
        {
            _pinion.Module = (double) ((NumericUpDown) sender).Value;
            _gear.Module = (double) ((NumericUpDown) sender).Value;
        }

        private void BuildBevelGear(string saveFile, string template)
        {
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
                filePath += "\\Bevel\\Images\\" + template;
            }

            if (filePath != null) File.Copy(filePath, tempFile, true);


            var session = InitAlibreBevelFile(tempFile);

            var sketches = session.Sketches;
            var sketch = sketches.Item("Sketch<1>");
            // var figures = sketch.Figures;
            // open the sketch for changes
            sketch.BeginChange();
            session.Parameters.OpenParameterTransaction();
            session.Parameters.Item("PitchRadius").Value = _pinion.PitchDiameter / 2 / 10;
            session.Parameters.Item("FaceWidth").Value = _pinion.FaceWidth / 10;
            session.Parameters.Item("Dedendum").Value = _pinion.Dedendum / 10;
            session.Parameters.Item("WholeDepth").Value = (_pinion.Addendum + _pinion.Dedendum) / 10;
            session.Parameters.Item("ConeAngle").Value = _pinion.PitchConeAngle * (Math.PI / 180.0);
            sketch.EndChange();

            session.Parameters.CloseParameterTransaction();
            ((IADPartSession) session).RegenerateAll();
        }

        private bool IsFileLocked(FileInfo file)
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

        private static IADDesignSession InitAlibreBevelFile(string filePath)
        {
            var root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
            var session = (IADDesignSession) root.OpenFileEx(filePath, true);
            return session;
        }

        private void GleasonCalculations()
        {
            _pinion.PitchDiameter = CalculateGleasonPinionPitchDiameter(_pinion);
            _pinion.PitchConeAngle = CalculateGleasonPinionPitchConeAngle(_pinion, _gear);
            _pinion.ConeDistance = CalculateConeDistance(_pinion, _gear);
            _pinion.Addendum = CalculateGleasonPinionAddendum(_pinion, _gear);
            _pinion.Dedendum = CalculateGleasonPinionDedendum(_pinion, _gear);
            _pinion.DedendumAngle = CalculateGleasonPinionDedendumAngle(_pinion, _gear);
            _pinion.AddendumAngle = CalculateGleasonPinionAddendumAngle(_pinion, _gear);
            _pinion.OuterConeAngle = CalculateGleasonPinionOuterConeAngle(_pinion, _gear);
            _pinion.RootConeAngle = CalculateGleasonPinionRootConeAngle(_pinion, _gear);
            _pinion.OutsideDiameter = CalculateGleasonPinionOutsideDiameter(_pinion, _gear);
            _pinion.PitchApexToCrown = CalculateGleasonPinionPitchApexToCrown(_pinion, _gear);
            _pinion.AxialFaceWidth = CalculateGleasonPinionAxialFaceWidth(_pinion, _gear);
            _pinion.InnerOutsideDiameter = CalculateGleasonPinionInnerOutsideDiameter(_pinion, _gear);
            _pinion.RadialPressureAngle = CalculatePinionRadialPressureAngle(_pinion, _gear);
            _pinion.StringValue = "Pinion\r\n" + _pinion;
            _gear.PitchDiameter = CalculateGleasonGearPitchDiameter(_gear);
            _gear.PitchConeAngle = CalculateGleasonGearPitchConeAngle(_pinion, _gear);
            _gear.ConeDistance = CalculateConeDistance(_pinion, _gear);
            _gear.Addendum = CalculateGleasonGearAddendum(_pinion, _gear);
            _gear.Dedendum = CalculateGleasonGearDedendum(_pinion, _gear);
            _gear.DedendumAngle = CalculateGleasonGearDedendumAngle(_pinion, _gear);
            _gear.AddendumAngle = CalculateGleasonGearAddendumAngle(_pinion, _gear);
            _gear.OuterConeAngle = CalculateGleasonGearOuterConeAngle(_pinion, _gear);
            _gear.RootConeAngle = CalculateGleasonGearRootConeAngle(_pinion, _gear);
            _gear.OutsideDiameter = CalculateGleasonGearOutsideDiameter(_pinion, _gear);
            _gear.PitchApexToCrown = CalculateGleasonGearPitchApexToCrown(_pinion, _gear);
            _gear.AxialFaceWidth = CalculateGleasonGearAxialFaceWidth(_pinion, _gear);
            _gear.InnerOutsideDiameter = CalculateGleasonGearInnerOutsideDiameter(_pinion, _gear);
            _gear.RadialPressureAngle = CalculateGearRadialPressureAngle(_pinion, _gear);
            _gear.StringValue = "Gear\r\n" + _gear;
        }

        private void GleasonSpiralCalculations()
        {
            _pinion.PitchDiameter = CalculateGleasonPinionPitchDiameter(_pinion);
            _pinion.PitchConeAngle = CalculateGleasonPinionPitchConeAngle(_pinion, _gear);
            _pinion.ConeDistance = CalculateConeDistance(_pinion, _gear);
            _pinion.Addendum = CalculateGleasonSpiralPinionAddendum(_pinion, _gear);
            _pinion.Dedendum = CalculateGleasonSpiralPinionDedendum(_pinion, _gear);
            _pinion.DedendumAngle = CalculateGleasonSpiralPinionDedendumAngle(_pinion, _gear);
            _pinion.AddendumAngle = CalculateGleasonSpiralPinionAddendumAngle(_pinion, _gear);
            _pinion.OuterConeAngle = CalculateGleasonSpiralPinionOuterConeAngle(_pinion, _gear);
            _pinion.RootConeAngle = CalculateGleasonSpiralPinionRootConeAngle(_pinion, _gear);
            _pinion.OutsideDiameter = CalculateGleasonSpiralPinionOutsideDiameter(_pinion, _gear);
            _pinion.PitchApexToCrown = CalculateGleasonSpiralPinionPitchApexToCrown(_pinion, _gear);
            _pinion.AxialFaceWidth = CalculateGleasonSpiralPinionAxialFaceWidth(_pinion, _gear);
            _pinion.InnerOutsideDiameter =
                CalculateGleasonSpiralPinionInnerOutsideDiameter(_pinion, _gear);
            _pinion.RadialPressureAngle = CalculatePinionRadialPressureAngle(_pinion, _gear);
            _pinion.StringValue = "Pinion\r\n" + _pinion;
            _gear.PitchDiameter = CalculateGleasonGearPitchDiameter(_gear);
            _gear.PitchConeAngle = CalculateGleasonGearPitchConeAngle(_pinion, _gear);
            _gear.ConeDistance = CalculateConeDistance(_pinion, _gear);
            _gear.Addendum = CalculateGleasonSpiralGearAddendum(_pinion, _gear);
            _gear.Dedendum = CalculateGleasonSpiralGearDedendum(_pinion, _gear);
            _gear.DedendumAngle = CalculateGleasonSpiralGearDedendumAngle(_pinion, _gear);
            _gear.AddendumAngle = CalculateGleasonSpiralGearAddendumAngle(_pinion, _gear);
            _gear.OuterConeAngle = CalculateGleasonSpiralGearOuterConeAngle(_pinion, _gear);
            _gear.RootConeAngle = CalculateGleasonSpiralGearRootConeAngle(_pinion, _gear);
            _gear.OutsideDiameter = CalculateGleasonSpiralGearOutsideDiameter(_pinion, _gear);
            _gear.PitchApexToCrown = CalculateGleasonSpiralGearPitchApexToCrown(_pinion, _gear);
            _gear.AxialFaceWidth = CalculateGleasonSpiralGearAxialFaceWidth(_pinion, _gear);
            _gear.InnerOutsideDiameter = CalculateGleasonSpiralGearInnerOutsideDiameter(_pinion, _gear);
            _gear.RadialPressureAngle = CalculateGearRadialPressureAngle(_pinion, _gear);
            _gear.StringValue = "Gear\r\n" + _gear;
        }

        private void StandardCalculations()
        {
            _pinion.PitchDiameter = CalculateStandardPinionPitchDiameter(_pinion);
            _pinion.PitchConeAngle = CalculateStandardPinionPitchConeAngle(_pinion, _gear);
            _pinion.ConeDistance = CalculateConeDistance(_pinion, _gear);
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
            _pinion.StringValue = "Pinion\r\n" + _pinion;
            _gear.PitchDiameter = CalculateStandardGearPitchDiameter(_gear);
            _gear.PitchConeAngle = CalculateStandardGearPitchConeAngle(_pinion, _gear);
            _gear.ConeDistance = CalculateConeDistance(_pinion, _gear);
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
            _gear.StringValue = "Gear\r\n" + _gear;
        }
    }
}