using System;
using System.IO;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Views;
using Bolsover.Utils;

namespace Bolsover.Bevel.Presenters
{
    public class BevelGearPresenter
    {
        private IBevelGearView _view;
        private IBevelGear _pinion;
        private IBevelGear _gear;


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
            view.ShaftAngleLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.ShaftAngleLatex);
            view.ModuleLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.ModuleLatex);
            view.PressureAngleLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.PressureAngleLatex);
            view.SpiralAngleLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.SpiralAngleLatex);

            view.RadialPressureAngleLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.RadialPressureAngleLatex);
            view.RadialPressureAngleFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.RadialPressureAngleFormulaLatex);
            view.NumberOfTeethLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.NumberOfTeethLatex);

            view.PitchDiameterLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.PitchDiameterLatex);
            view.PitchDiameterFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.PitchDiameterFormulaLatex);

            view.PitchConeAngle1Label.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.PitchConeAngle1Latex);
            view.PitchConeAngle1FormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.PitchConeAngle1FormulaLatex);

            view.PitchConeAngle2Label.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.PitchConeAngle2Latex);
            view.PitchConeAngle2FormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.PitchConeAngle2FormulaLatex);

            view.ConeDistanceLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.ConeDistanceLatex);
            view.ConeDistanceFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.ConeDistanceFormulaLatex);

            view.FaceWidthLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.FaceWidthLatex);
            view.FaceWidthFormulaLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.FaceWidthFormulaLatex);

            view.Addendum1Label.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.Addendum1Latex);
            view.Addendum1FormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumHa1GleasonStraightFormulaLatex);

            view.Addendum2Label.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.Addendum2Latex);
            view.Addendum2FormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumHa2GleasonStraightFormulaLatex);

            view.DedendumLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.DedendumLatex);
            view.DedendumFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.DedendumHfGleasonStraightFormulaLatex);

            view.DedendumAngleLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.DedendumAngleLatex);
            view.DedendumAngleFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.DedendumAngleFormulaLatex);

            view.AddendumAngle1Label.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumAngle1Latex);
            view.AddendumAngle1FormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumAngle1FormulaLatex);

            view.AddendumAngle2Label.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumAngle2Latex);
            view.AddendumAngle2FormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumAngle2FormulaLatex);

            view.OuterConeAngleLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.OuterConeAngleLatex);
            view.OuterConeAngleFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.OuterConeAngleFormulaLatex);

            view.RootConeAngleLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.RootConeAngleLatex);
            view.RootConeAngleFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.RootConeAngleFormulaLatex);

            view.OutsideDiameterLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.OutsideDiameterLatex);
            view.OutsideDiameterFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.OutsideDiameterFormulaLatex);

            view.PitchApexToCrownLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.PitchApexToCrownLatex);
            view.PitchApexToCrownFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.PitchApexToCrownFormulaLatex);

            view.AxialFaceWidthLabel.Image = LatexUtils.CreateImageFromLatex(BevelLatexStrings.AxialFaceWidthLatex);
            view.AxialFaceWidthFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.AxialFaceWidthFormulaLatex);

            view.InnerOutsideDiameterLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.InnerOutsideDiameterLatex);
            view.InnerOutsideDiameterFormulaLabel.Image =
                LatexUtils.CreateImageFromLatex(BevelLatexStrings.InnerOutsideDiameterFormulaLatex);
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
            view.ParentForm.Dispose();
        }


        private void ViewOnEditGearTypeEvent(object sender, EventArgs e)
        {
            _pinion.GearType = (string) ((ComboBox) sender).SelectedItem;
            _gear.GearType = (string) ((ComboBox) sender).SelectedItem;
            string s = (string) ((ComboBox) sender).SelectedItem;
            var view = (BevelGearView) _view;
            switch (s)
            {
                case "Standard":

                {
                    view.Addendum1FormulaLabel.Image =
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.StandardAddendumHaFormulaLatex);
                    view.DedendumFormulaLabel.Image =
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.StandardDedendumHfFormulaLatex);
                    view.Addendum2FormulaLabel.Image =
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.StandardAddendumHa2FormulaLatex);
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
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumHa1GleasonStraightFormulaLatex);
                    view.DedendumFormulaLabel.Image =
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.DedendumHfGleasonStraightFormulaLatex);
                    view.Addendum2FormulaLabel.Image =
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumHa2GleasonStraightFormulaLatex);
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
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumHa1GleasonStraightFormulaLatex);
                    view.DedendumFormulaLabel.Image =
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.DedendumHfGleasonStraightFormulaLatex);
                    view.Addendum2FormulaLabel.Image =
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumHa2GleasonStraightFormulaLatex);
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
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumHa1GleasonSpiralFormulaLatex);
                    view.DedendumFormulaLabel.Image =
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.DedendumGleasonSpiralFormulaLatex);
                    view.Addendum2FormulaLabel.Image =
                        LatexUtils.CreateImageFromLatex(BevelLatexStrings.AddendumHa2GleasonSpiralFormulaLatex);
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

        private void ViewOnBuildGearEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ViewOnBuildPinionEvent(object sender, EventArgs e)
        {
            var saveFile = "BevelPleaseSaveAs.AD_PRT";
            var template = "BevelGearTemplate.AD_PRT";


            BuildBevelGear(saveFile, template);
        }

        private void ViewOnEditModuleEvent(object sender, EventArgs e)
        {
            _pinion.Module = (double) ((NumericUpDown) sender).Value;
            _gear.Module = (double) ((NumericUpDown) sender).Value;
        }

        private void BuildBevelGear(string saveFile, string template)
        {
            // GearBuilder gearBuilder = new GearBuilder();

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

            File.Copy(filePath, tempFile, true);


            IADDesignSession session = InitAlibreBevelFile(tempFile, true);

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
            //session.Parameters.Item("ToothCount").Value = _pinion.numberOfTeeth;
            sketch.EndChange();

            session.Parameters.CloseParameterTransaction();
            ((IADPartSession) session).RegenerateAll();

            //   AlibreBuilder.CreateInstance(gearToothPoints, session);
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
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

        private IADDesignSession InitAlibreBevelFile(string filePath, bool openEditor)
        {
            IADRoot root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
            IADDesignSession session = (IADDesignSession) root.OpenFileEx(filePath, true);
            return session;
        }

        private void GleasonCalculations()
        {
            _pinion.PitchDiameter = BevelGearCalculator.CalculateGleasonPinionPitchDiameter(_pinion);
            _pinion.PitchConeAngle = BevelGearCalculator.CalculateGleasonPinionPitchConeAngle(_pinion, _gear);
            _pinion.ConeDistance = BevelGearCalculator.CalculateConeDistance(_pinion, _gear);
            _pinion.Addendum = BevelGearCalculator.CalculateGleasonPinionAddendum(_pinion, _gear);
            _pinion.Dedendum = BevelGearCalculator.CalculateGleasonPinionDedendum(_pinion, _gear);
            _pinion.DedendumAngle = BevelGearCalculator.CalculateGleasonPinionDedendumAngle(_pinion, _gear);
            _pinion.AddendumAngle = BevelGearCalculator.CalculateGleasonPinionAddendumAngle(_pinion, _gear);
            _pinion.OuterConeAngle = BevelGearCalculator.CalculateGleasonPinionOuterConeAngle(_pinion, _gear);
            _pinion.RootConeAngle = BevelGearCalculator.CalculateGleasonPinionRootConeAngle(_pinion, _gear);
            _pinion.OutsideDiameter = BevelGearCalculator.CalculateGleasonPinionOutsideDiameter(_pinion, _gear);
            _pinion.PitchApexToCrown = BevelGearCalculator.CalculateGleasonPinionPitchApexToCrown(_pinion, _gear);
            _pinion.AxialFaceWidth = BevelGearCalculator.CalculateGleasonPinionAxialFaceWidth(_pinion, _gear);
            _pinion.InnerOutsideDiameter = BevelGearCalculator.CalculateGleasonPinionInnerOutsideDiameter(_pinion, _gear);
            _pinion.RadialPressureAngle = BevelGearCalculator.CalculatePinionRadialPressureAngle(_pinion, _gear);
            _pinion.StringValue = "Pinion\r\n" + _pinion;
            _gear.PitchDiameter = BevelGearCalculator.CalculateGleasonGearPitchDiameter(_gear);
            _gear.PitchConeAngle = BevelGearCalculator.CalculateGleasonGearPitchConeAngle(_pinion, _gear);
            _gear.ConeDistance = BevelGearCalculator.CalculateConeDistance(_pinion, _gear);
            _gear.Addendum = BevelGearCalculator.CalculateGleasonGearAddendum(_pinion, _gear);
            _gear.Dedendum = BevelGearCalculator.CalculateGleasonGearDedendum(_pinion, _gear);
            _gear.DedendumAngle = BevelGearCalculator.CalculateGleasonGearDedendumAngle(_pinion, _gear);
            _gear.AddendumAngle = BevelGearCalculator.CalculateGleasonGearAddendumAngle(_pinion, _gear);
            _gear.OuterConeAngle = BevelGearCalculator.CalculateGleasonGearOuterConeAngle(_pinion, _gear);
            _gear.RootConeAngle = BevelGearCalculator.CalculateGleasonGearRootConeAngle(_pinion, _gear);
            _gear.OutsideDiameter = BevelGearCalculator.CalculateGleasonGearOutsideDiameter(_pinion, _gear);
            _gear.PitchApexToCrown = BevelGearCalculator.CalculateGleasonGearPitchApexToCrown(_pinion, _gear);
            _gear.AxialFaceWidth = BevelGearCalculator.CalculateGleasonGearAxialFaceWidth(_pinion, _gear);
            _gear.InnerOutsideDiameter = BevelGearCalculator.CalculateGleasonGearInnerOutsideDiameter(_pinion, _gear);
            _gear.RadialPressureAngle = BevelGearCalculator.CalculateGearRadialPressureAngle(_pinion, _gear);
            _gear.StringValue = "Gear\r\n" + _gear;
        }

        private void GleasonSpiralCalculations()
        {
            _pinion.PitchDiameter = BevelGearCalculator.CalculateGleasonPinionPitchDiameter(_pinion);
            _pinion.PitchConeAngle = BevelGearCalculator.CalculateGleasonPinionPitchConeAngle(_pinion, _gear);
            _pinion.ConeDistance = BevelGearCalculator.CalculateConeDistance(_pinion, _gear);
            _pinion.Addendum = BevelGearCalculator.CalculateGleasonSpiralPinionAddendum(_pinion, _gear);
            _pinion.Dedendum = BevelGearCalculator.CalculateGleasonSpiralPinionDedendum(_pinion, _gear);
            _pinion.DedendumAngle = BevelGearCalculator.CalculateGleasonSpiralPinionDedendumAngle(_pinion, _gear);
            _pinion.AddendumAngle = BevelGearCalculator.CalculateGleasonSpiralPinionAddendumAngle(_pinion, _gear);
            _pinion.OuterConeAngle = BevelGearCalculator.CalculateGleasonSpiralPinionOuterConeAngle(_pinion, _gear);
            _pinion.RootConeAngle = BevelGearCalculator.CalculateGleasonSpiralPinionRootConeAngle(_pinion, _gear);
            _pinion.OutsideDiameter = BevelGearCalculator.CalculateGleasonSpiralPinionOutsideDiameter(_pinion, _gear);
            _pinion.PitchApexToCrown = BevelGearCalculator.CalculateGleasonSpiralPinionPitchApexToCrown(_pinion, _gear);
            _pinion.AxialFaceWidth = BevelGearCalculator.CalculateGleasonSpiralPinionAxialFaceWidth(_pinion, _gear);
            _pinion.InnerOutsideDiameter =
                BevelGearCalculator.CalculateGleasonSpiralPinionInnerOutsideDiameter(_pinion, _gear);
            _pinion.RadialPressureAngle = BevelGearCalculator.CalculatePinionRadialPressureAngle(_pinion, _gear);
            _pinion.StringValue = "Pinion\r\n" + _pinion;
            _gear.PitchDiameter = BevelGearCalculator.CalculateGleasonGearPitchDiameter(_gear);
            _gear.PitchConeAngle = BevelGearCalculator.CalculateGleasonGearPitchConeAngle(_pinion, _gear);
            _gear.ConeDistance = BevelGearCalculator.CalculateConeDistance(_pinion, _gear);
            _gear.Addendum = BevelGearCalculator.CalculateGleasonSpiralGearAddendum(_pinion, _gear);
            _gear.Dedendum = BevelGearCalculator.CalculateGleasonSpiralGearDedendum(_pinion, _gear);
            _gear.DedendumAngle = BevelGearCalculator.CalculateGleasonSpiralGearDedendumAngle(_pinion, _gear);
            _gear.AddendumAngle = BevelGearCalculator.CalculateGleasonSpiralGearAddendumAngle(_pinion, _gear);
            _gear.OuterConeAngle = BevelGearCalculator.CalculateGleasonSpiralGearOuterConeAngle(_pinion, _gear);
            _gear.RootConeAngle = BevelGearCalculator.CalculateGleasonSpiralGearRootConeAngle(_pinion, _gear);
            _gear.OutsideDiameter = BevelGearCalculator.CalculateGleasonSpiralGearOutsideDiameter(_pinion, _gear);
            _gear.PitchApexToCrown = BevelGearCalculator.CalculateGleasonSpiralGearPitchApexToCrown(_pinion, _gear);
            _gear.AxialFaceWidth = BevelGearCalculator.CalculateGleasonSpiralGearAxialFaceWidth(_pinion, _gear);
            _gear.InnerOutsideDiameter = BevelGearCalculator.CalculateGleasonSpiralGearInnerOutsideDiameter(_pinion, _gear);
            _gear.RadialPressureAngle = BevelGearCalculator.CalculateGearRadialPressureAngle(_pinion, _gear);
            _gear.StringValue = "Gear\r\n" + _gear;
        }

        private void StandardCalculations()
        {
            _pinion.PitchDiameter = BevelGearCalculator.CalculateStandardPinionPitchDiameter(_pinion);
            _pinion.PitchConeAngle = BevelGearCalculator.CalculateStandardPinionPitchConeAngle(_pinion, _gear);
            _pinion.ConeDistance = BevelGearCalculator.CalculateConeDistance(_pinion, _gear);
            _pinion.Addendum = BevelGearCalculator.CalculateStandardPinionAddendum(_pinion, _gear);
            _pinion.Dedendum = BevelGearCalculator.CalculateStandardPinionDedendum(_pinion, _gear);
            _pinion.DedendumAngle = BevelGearCalculator.CalculateStandardPinionDedendumAngle(_pinion, _gear);
            _pinion.AddendumAngle = BevelGearCalculator.CalculateStandardPinionAddendumAngle(_pinion, _gear);
            _pinion.OuterConeAngle = BevelGearCalculator.CalculateStandardPinionOuterConeAngle(_pinion, _gear);
            _pinion.RootConeAngle = BevelGearCalculator.CalculateStandardPinionRootConeAngle(_pinion, _gear);
            _pinion.OutsideDiameter = BevelGearCalculator.CalculateStandardPinionOutsideDiameter(_pinion, _gear);
            _pinion.PitchApexToCrown = BevelGearCalculator.CalculateStandardPinionPitchApexToCrown(_pinion, _gear);
            _pinion.AxialFaceWidth = BevelGearCalculator.CalculateStandardPinionAxialFaceWidth(_pinion, _gear);
            _pinion.InnerOutsideDiameter = BevelGearCalculator.CalculateStandardPinionInnerOutsideDiameter(_pinion, _gear);
            _pinion.RadialPressureAngle = BevelGearCalculator.CalculateGearRadialPressureAngle(_pinion, _gear);
            _pinion.StringValue = "Pinion\r\n" + _pinion;
            _gear.PitchDiameter = BevelGearCalculator.CalculateStandardGearPitchDiameter(_gear);
            _gear.PitchConeAngle = BevelGearCalculator.CalculateStandardGearPitchConeAngle(_pinion, _gear);
            _gear.ConeDistance = BevelGearCalculator.CalculateConeDistance(_pinion, _gear);
            _gear.Addendum = BevelGearCalculator.CalculateStandardGearAddendum(_pinion, _gear);
            _gear.Dedendum = BevelGearCalculator.CalculateStandardGearDedendum(_pinion, _gear);
            _gear.DedendumAngle = BevelGearCalculator.CalculateStandardGearDedendumAngle(_pinion, _gear);
            _gear.AddendumAngle = BevelGearCalculator.CalculateStandardGearAddendumAngle(_pinion, _gear);
            _gear.OuterConeAngle = BevelGearCalculator.CalculateStandardGearOuterConeAngle(_pinion, _gear);
            _gear.RootConeAngle = BevelGearCalculator.CalculateStandardGearRootConeAngle(_pinion, _gear);
            _gear.OutsideDiameter = BevelGearCalculator.CalculateStandardGearOutsideDiameter(_pinion, _gear);
            _gear.PitchApexToCrown = BevelGearCalculator.CalculateStandardGearPitchApexToCrown(_pinion, _gear);
            _gear.AxialFaceWidth = BevelGearCalculator.CalculateStandardGearAxialFaceWidth(_pinion, _gear);
            _gear.InnerOutsideDiameter = BevelGearCalculator.CalculateStandardGearInnerOutsideDiameter(_pinion, _gear);
            _gear.RadialPressureAngle = BevelGearCalculator.CalculateGearRadialPressureAngle(_pinion, _gear);
            _gear.StringValue = "Gear\r\n" + _gear;
        }
    }
}