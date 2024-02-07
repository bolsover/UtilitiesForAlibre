using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bolsover.Involute.Builder;
using Bolsover.Involute.Calculator;
using Bolsover.Involute.Model;
using Bolsover.Involute.View;
using BrightIdeasSoftware;
using static Bolsover.Involute.Images.GearLatexStrings;
using static Bolsover.Involute.Model.GearStyle;
using static Bolsover.Utils.LatexUtils;

namespace Bolsover.Involute.Presenter
{
    public class GearViewPresenter
    {
        private GearView _view;
        public GearPairDesignInputParams Model;
        private GearPairDesignOutputParams _gearPairDesignOutputParams;
        private IGearCalculator _gearCalculator;
        private IToothPointsBuilder _toothPointsBuilder;
        private AlibreToothBuilder _alibreToothBuilder;

        public GearViewPresenter(GearView view)
        {
            _view = view;
            Initialise();
        }

        private void Initialise()
        {
            Model = new GearPairDesignInputParams();

            _gearPairDesignOutputParams = new GearPairDesignOutputParams
            {
                GearPairDesignInputParams = Model
            };
            _toothPointsBuilder = new ExternalSpurHelicalToothBuilder(); // setup default builder
            InitGearPair();
            SetupDefaults();
            ClearLabelText();
            SetupLabelLatexImages();
            SetupEventListeners();
            SetupViewDefaults();
            SetupObjectListView();
            Recalculate();
           
        }

        private void SetupViewDefaults()
        {
            _view.operatingCentreDistanceNumericUpDown.Enabled = !Model.Auto;
            _view.pinionProfileShiftNumericUpDown.Enabled = !Model.Auto;
            _view.gearProfileShiftNumericUpDown.Enabled = !Model.Auto;
            _view.normalBacklashNumericUpDown.Enabled = !Model.Auto;
        }

        private void InitGearPair()
        {
            var gear = new GearDesignInputParams();
            var pinion = new GearDesignInputParams();
            Model.Gear = gear;
            Model.Pinion = pinion;
            gear.GearPairDesign = Model;
            pinion.GearPairDesign = Model;
            Model.Auto = true;
            _gearPairDesignOutputParams.PinionDesignOutput = new GearDesignOutputParams();
            _gearPairDesignOutputParams.GearDesignOutput = new GearDesignOutputParams();
            _gearPairDesignOutputParams.PinionDesignOutput.GearDesignInputParams = pinion;
            _gearPairDesignOutputParams.GearDesignOutput.GearDesignInputParams = gear;
        }

        private void SetupDefaults()
        {
            _view.gearTeethNumericUpDown.Value = (decimal) Model.Gear.Teeth;
            _view.pinionTeethNumericUpDown.Value = (decimal) Model.Pinion.Teeth;
            _view.moduleNumericUpDown.Value = (decimal) Model.Gear.Module;
            _view.pressureAngleNumericUpDown.Value = (decimal) Model.Gear.PressureAngle;
            _view.helixAngleNumericUpDown.Value = (decimal) Model.Gear.HelixAngle;
        }

        private void SetupLabelLatexImages()
        {
            _view.normalModuleSymbolLabel.Image = CreateImageFromLatex(NormalModuleSymbol);
            _view.normalPressureAngleSymbolLabel.Image = CreateImageFromLatex(NormalPressureAngleSymbol);
            _view.helixAngleSymbolLabel.Image = CreateImageFromLatex(HelixAngleSymbol);
            _view.teethLabel.Image = CreateImageFromLatex(NumberOfTeethSymbol2);
            _view.circularBacklashSymbolLabel.Image = CreateImageFromLatex(CircularBacklashXmodSymbol);
            _view.rootFilletFactorSymbolLabel.Image = CreateImageFromLatex(RootFilletFactorSymbol);
            _view.tipReliefFactorSymbolLabel.Image = CreateImageFromLatex(TipReliefFactorSymbol);
            _view.operatingCentreSymbolLabel.Image = CreateImageFromLatex(OperatingCentreDistanceSymbol);
            _view.totalProfileShiftSymbolLabel.Image = CreateImageFromLatex(TotalProfileShiftSymbol);
            _view.profileShiftSymbolLabel.Image = CreateImageFromLatex(ProfileShiftSymbol);
        }

        private void ClearLabelText()

        {
            _view.normalModuleSymbolLabel.Text = "";
            _view.normalPressureAngleSymbolLabel.Text = "";
            _view.helixAngleSymbolLabel.Text = "";
            _view.teethLabel.Text = "";
            _view.circularBacklashSymbolLabel.Text = "";
            _view.rootFilletFactorSymbolLabel.Text = "";
            _view.tipReliefFactorSymbolLabel.Text = "";
            _view.operatingCentreSymbolLabel.Text = "";
            _view.totalProfileShiftSymbolLabel.Text = "";
            _view.profileShiftSymbolLabel.Text = "";
            _view.noteLabel.Text = "";
        }

        private void SetupEventListeners()
        {
            _view.EditGearNumberOfTeethEvent += ViewOnEditGearNumberOfTeethEvent;
            _view.EditPinionNumberOfTeethEvent += ViewOnEditPinionNumberOfTeethEvent;
            _view.EditModuleEvent += ViewOnEditModuleEvent;
            _view.EditHelixAngleEvent += ViewOnEditHelixAngleEvent;
            _view.CancelEvent += ViewOnCancelEvent;
            _view.BuildGearEvent += ViewOnBuildWheelEvent;
            _view.BuildPinionEvent += ViewOnBuildPinionEvent;
            _view.EditPressureAngleEvent += ViewOnEditPressureAngleEvent;
            _view.EditGearHeightEvent += ViewOnEditGearHeightEvent;
            _view.AutoManualEvent += ViewOnAutoManualEvent;
            _view.EditCentreDistanceEvent += ViewOnEditCentreDistanceEvent;
            _view.EditPinionProfileShiftEvent += ViewOnEditPinionProfileShiftEvent;
            _view.EditGearProfileShiftEvent += ViewOnEditGearProfileShiftEvent;
            _view.EditNormalBacklashEvent += ViewOnEditCircularBacklashEvent;
            _view.EditGearStyleEvent += ViewOnEditGearStyleEvent;
            _view.EditRootFilletFactorEvent += ViewOnEditRootFilletFactorEvent;
            _view.EditAddendumFilletFactorEvent += ViewOnEditAddendumFilletFactorEvent;
            ((GearDesignOutputParams)_gearPairDesignOutputParams.GearDesignOutput).GearChanged += GearDesignOutputOnGearChanged;
            ((GearDesignOutputParams)_gearPairDesignOutputParams.PinionDesignOutput).GearChanged += GearDesignOutputOnGearChanged;
            Model.Gear.GearChanged += GearDesignInputParamsOnGearChanged;
            Model.Pinion.GearChanged += GearDesignInputParamsOnGearChanged;
            Model.GearChanged += GearDesignInputParamsOnGearChanged;
            _view.objectListView1.FormatRow += delegate (object sender1, FormatRowEventArgs e) {
                var data = (GearData)e.Model;
                if (data.IsError) e.Item.BackColor = Color.Red;
                
            };
        }

        private void SetupObjectListView()
        {
            _view.olvColumn1.AspectGetter = rowObject => ((GearData)rowObject).Item;
            _view.olvColumn2.AspectGetter = rowObject => ((GearData)rowObject).MetricValue;
            _view.olvColumn3.AspectGetter = rowObject => ((GearData)rowObject).ImperialValue;
            _view.olvColumn4.AspectGetter = rowObject => ((GearData)rowObject).Note;
            
        }

        private void GearDesignInputParamsOnGearChanged(object sender, GearChangeEventArgs args)
        {
            var geardata = _gearCalculator.BuildGearData(Model, _gearPairDesignOutputParams);
            var gearDatas = geardata.ToList();
            _view.objectListView1.SetObjects(gearDatas);
            bool flag = gearDatas.Any(gearData => gearData.IsError);
            if (flag)
            {
                // _view.buildGearButton.Enabled = false;
                // _view.buildPinionButton.Enabled = false;
                _view.noteLabel.Text = "Please correct the errors before building the gear";
                _view.noteLabel.ForeColor = Color.Red;
            }
            else
            {
                // _view.buildGearButton.Enabled = true;
                // _view.buildPinionButton.Enabled = true;
                _view.noteLabel.Text = "All values are within acceptable limits";
                _view.noteLabel.ForeColor = Color.Black;
            }
        }
       
        

        private void GearDesignOutputOnGearChanged(object sender, GearChangeEventArgs e)
        {
         
        }

        private void Recalculate()
        {
            Calculate();

            
            //_view.dataTextBox.Text = _gearCalculator.CalculateGearString(Model, _gearPairDesignOutputParams);
            _view.xModTextBox.Text = _gearCalculator.CalculateProfileShiftModificationForBacklash(Model).ToString("F4");
            var sumx = _gearPairDesignOutputParams.GearPairDesignInputParams.Gear.CoefficientOfProfileShift +
                      _gearPairDesignOutputParams.GearPairDesignInputParams.Pinion.CoefficientOfProfileShift;
            _view.assignedTotalNormalProfileShiftTextBox.Text = sumx.ToString("F4");

            // Difference coefficient of profile shift is only used for internal gears
            if (Model.Gear.Style.HasFlag(Internal))
            {
                var xDiff = _gearCalculator.CalculateDifferenceCoefficientOfProfileShift(Model);
                _view.totalNormalProfileShiftTextBox.Text = (xDiff).ToString("F4");
            }
            else
                // Sum coefficient of profile shift is only used for external gears
            {
                var xSum = _gearCalculator.CalculateSumCoefficientOfProfileShift(Model);
                _view.totalNormalProfileShiftTextBox.Text = (xSum).ToString("F4");
            }

            if (!Model.Auto) return;
            Model.WorkingCentreDistance = _gearCalculator.CalculateCentreDistance(Model);
            _view.operatingCentreDistanceNumericUpDown.Value = (decimal) Model.WorkingCentreDistance;
            _view.pinionProfileShiftNumericUpDown.Value = 0.0M;
            _view.gearProfileShiftNumericUpDown.Value = 0.0M;
        }

        private void ViewOnEditAddendumFilletFactorEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Gear.AddendumFilletFactor = newValue;
                Model.Pinion.AddendumFilletFactor = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditRootFilletFactorEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Gear.RootFilletFactor = newValue;
                Model.Pinion.RootFilletFactor = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditGearStyleEvent(object sender, EventArgs e)
        {
            if (!Model.Auto)
            {
                ViewOnAutoManualEvent(null, null);
            }

            if (sender is RadioButton radioButton)
            {
                if (sender.Equals(_view.extRadioButton))
                {
                    if (radioButton.Checked)
                    {
                        Model.Gear.Style &= ~Internal;
                        Model.Gear.Style |= External;
                    }
                    else
                    {
                        Model.Gear.Style &= ~External;
                        Model.Gear.Style |= Internal;
                    }
                }
                else if (sender.Equals(_view.intRadioButton))
                {
                    if (radioButton.Checked)
                    {
                        Model.Gear.Style &= ~External;
                        Model.Gear.Style |= Internal;
                        MessageBox.Show("Internal gears must be large enough to fit the pinion inside!");
                    }
                    else
                    {
                        Model.Gear.Style &= ~Internal;
                        Model.Gear.Style |= External;
                    }
                }
            }

            Recalculate();
        }

        private void ViewOnCancelEvent(object sender, EventArgs e) => _view.FindForm()!.Close();

        private void ViewOnEditHelixAngleEvent(object sender, EventArgs e)
        {
            if (!Model.Auto)
            {
                ViewOnAutoManualEvent(null, null);
            }

            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Gear.HelixAngle = newValue;
                Model.Pinion.HelixAngle = newValue;
                if (newValue > 0)
                {
                    Model.Gear.Style &= ~Spur;
                    Model.Pinion.Style &= ~Spur;
                    Model.Gear.Style |= Helical;
                    Model.Pinion.Style |= Helical;
                }
                else
                {
                    Model.Gear.Style &= ~Helical;
                    Model.Pinion.Style &= ~Helical;
                    Model.Gear.Style |= Spur;
                    Model.Pinion.Style |= Spur;
                }
            }

            Recalculate();
        }

        private void ViewOnEditModuleEvent(object sender, EventArgs e)
        {
            if (!Model.Auto)
            {
                ViewOnAutoManualEvent(null, null);
            }

            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Gear.Module = newValue;
                Model.Pinion.Module = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditGearNumberOfTeethEvent(object sender, EventArgs e)
        {
            if (!Model.Auto)
            {
                ViewOnAutoManualEvent(null, null);
            }

            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Gear.Teeth = newValue;
            }

            //prevent the gear from having fewer teeth than the pinion
            if (Model.Gear.Teeth < Model.Pinion.Teeth)
            {
                MessageBox.Show("Gear cannot have fewer teeth than pinion");
                Model.Gear.Teeth = Model.Pinion.Teeth;
                _view.gearTeethNumericUpDown.Value = (decimal) Model.Gear.Teeth;
            }

            Recalculate();
        }

        private void ViewOnEditPinionNumberOfTeethEvent(object sender, EventArgs e)
        {
            if (!Model.Auto)
            {
                ViewOnAutoManualEvent(null, null);
            }

            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Pinion.Teeth = newValue;
            }

            //prevent the gear from having fewer teeth than the pinion
            if (Model.Gear.Teeth < Model.Pinion.Teeth)
            {
                MessageBox.Show("Pinion cannot have more teeth than gear");
                Model.Pinion.Teeth = Model.Gear.Teeth;
                _view.pinionTeethNumericUpDown.Value = (decimal) Model.Pinion.Teeth;
            }

            Recalculate();
        }

        private void ViewOnEditCircularBacklashEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Gear.CircularBacklash = newValue;
                Model.Pinion.CircularBacklash = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditGearProfileShiftEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Gear.CoefficientOfProfileShift = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditPinionProfileShiftEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Pinion.CoefficientOfProfileShift = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditCentreDistanceEvent(object sender, EventArgs e)
        {
            if (!Model.Auto)
            {
                if (sender is NumericUpDown numericUpDown)
                {
                    var newValue = (double) numericUpDown.Value;
                    Model.WorkingCentreDistance = newValue;
                }
            }

            Recalculate();
        }

        private void ViewOnAutoManualEvent(object sender, EventArgs e)
        {
            Model.Auto = !Model.Auto;
            _view.operatingCentreDistanceNumericUpDown.Enabled = !Model.Auto;
            _view.pinionProfileShiftNumericUpDown.Enabled = !Model.Auto;
            _view.gearProfileShiftNumericUpDown.Enabled = !Model.Auto;
            _view.normalBacklashNumericUpDown.Enabled = !Model.Auto;
            _view.autoManualButton.Text = Model.Auto ? "Automatic" : "Manual";
            _view.noteLabel.Text = Model.Auto
                ? "Centre distance is calculated automatically"
                : "Centre distance and profile shifts are entered manually";
            if(Model.Auto) _view.normalBacklashNumericUpDown.Value = 0.0M;
            Recalculate();
        }

        private void ViewOnEditGearHeightEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Gear.Height = newValue;
                Model.Pinion.Height = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditPressureAngleEvent(object sender, EventArgs e)
        {
            if (!Model.Auto)
            {
                ViewOnAutoManualEvent(null, null);
            }

            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double) numericUpDown.Value;
                Model.Gear.PressureAngle = newValue;
                Model.Pinion.PressureAngle = newValue;
            }

            Recalculate();
        }

        private void ViewOnBuildPinionEvent(object sender, EventArgs e)
        {
            Recalculate();
            var gearDetails = GetPinionDetails();
            SetupBuilderForGearType(false);
            var tooth = _toothPointsBuilder.Build(_gearPairDesignOutputParams.PinionDesignOutput);
            _alibreToothBuilder ??= new AlibreToothBuilder();
            _alibreToothBuilder.Build(tooth, gearDetails.SaveFile, gearDetails.Template, _gearPairDesignOutputParams.PinionDesignOutput);
        }

        private void SetupBuilderForGearType(bool isGear)
        {
            if (!isGear) // this is a pinion
            {
                _toothPointsBuilder = _toothPointsBuilder is ExternalSpurHelicalToothBuilder ? _toothPointsBuilder : new ExternalSpurHelicalToothBuilder();
                return;
            }

            // this is a gear
            if (Model.Gear.Style.HasFlag(External) && (Model.Gear.Style.HasFlag(Spur) || Model.Gear.Style.HasFlag(Helical)))
            {
                _toothPointsBuilder = _toothPointsBuilder is ExternalSpurHelicalToothBuilder ? _toothPointsBuilder : new ExternalSpurHelicalToothBuilder();
            }
            else if (Model.Gear.Style.HasFlag(Internal) && (Model.Gear.Style.HasFlag(Spur) || Model.Gear.Style.HasFlag(Helical)))
            {
                _toothPointsBuilder = _toothPointsBuilder is InternalSpurHelicalToothBuilder ? _toothPointsBuilder : new InternalSpurHelicalToothBuilder();
            }
        }

        private void ViewOnBuildWheelEvent(object sender, EventArgs e)
        {
            Recalculate();
            var gearDetails = GetGearDetails();
            SetupBuilderForGearType(true);
            var tooth = _toothPointsBuilder.Build(_gearPairDesignOutputParams.GearDesignOutput);
            _alibreToothBuilder ??= new AlibreToothBuilder();
            _alibreToothBuilder.Build(tooth, gearDetails.SaveFile, gearDetails.Template, _gearPairDesignOutputParams.GearDesignOutput);
        }

        private (string SaveFile, string Template) GetGearDetails()
        {
            var isHelical = Model.Gear.Style.HasFlag(Helical);

            var saveFile = isHelical
                ? "HelicalWheelPleaseSaveAs.AD_PRT"
                : "WheelPleaseSaveAs.AD_PRT";

            var template = isHelical
                ? "HelicalWheelTemplate.AD_PRT"
                : "WheelTemplate.AD_PRT";

            return (saveFile, template);
        }

        private (string SaveFile, string Template) GetPinionDetails()
        {
            var isHelical = Model.Pinion.Style.HasFlag(Helical);

            var saveFile = isHelical
                ? "HelicalPinionPleaseSaveAs.AD_PRT"
                : "PinionPleaseSaveAs.AD_PRT";

            var template = isHelical
                ? "HelicalPinionTemplate.AD_PRT"
                : "PinionTemplate.AD_PRT";

            return (saveFile, template);
        }

        private void Calculate()
        {
            if (Model.Gear.Style.HasFlag(External) && Model.Gear.Style.HasFlag(Spur))
                CalculatePositiveShiftedExternalSpurGear();
            else if (Model.Gear.Style.HasFlag(External) && Model.Gear.Style.HasFlag(Helical))
                CalculatePositiveShiftedExternalHelicalGear();
            else if (Model.Gear.Style.HasFlag(Internal) && Model.Gear.Style.HasFlag(Spur))
                CalculatePositiveShiftedIntExtSpurGear();
            else if (Model.Gear.Style.HasFlag(Internal) && Model.Gear.Style.HasFlag(Helical))
                CalculatePositiveShiftedIntExtHelicalGear();
            else if (Model.Gear.Style.HasFlag(Rack) && Model.Gear.Style.HasFlag(Spur))
                CalculateStraightRackGear();
            else if (Model.Gear.Style.HasFlag(Rack) && Model.Gear.Style.HasFlag(Helical))
                CalculateHelicalRackGear();
            else
                throw new ArgumentException("Gear style not recognised");
        }

        #region GearStyles

        private static void CalculateHelicalRackGear()
        {
            throw new NotImplementedException();
        }

        private static void CalculateStraightRackGear()
        {
            throw new NotImplementedException();
        }

        private void CalculatePositiveShiftedIntExtHelicalGear()
        {
            if (_gearCalculator is not ProfileShiftedIntExtHelicalGearCalculator)
            {
                _gearCalculator = new ProfileShiftedIntExtHelicalGearCalculator(Model, _gearPairDesignOutputParams);
            }

            _gearCalculator.Calculate();
        }

        private void CalculatePositiveShiftedIntExtSpurGear()
        {
            if (_gearCalculator is not ProfileShiftedIntExtSpurGearCalculator)
            {
                _gearCalculator = new ProfileShiftedIntExtSpurGearCalculator(Model, _gearPairDesignOutputParams);
            }

            _gearCalculator.Calculate();
        }

        private void CalculatePositiveShiftedExternalHelicalGear()
        {
            if (_gearCalculator is not ProfileShiftedExternalHelicalGearCalculator)
            {
                _gearCalculator = new ProfileShiftedExternalHelicalGearCalculator(Model, _gearPairDesignOutputParams);
            }

            _gearCalculator.Calculate();
        }

        private void CalculatePositiveShiftedExternalSpurGear()
        {
            if (_gearCalculator is not ProfileShiftedExternalSpurGearCalculator)
            {
                _gearCalculator = new ProfileShiftedExternalSpurGearCalculator(Model, _gearPairDesignOutputParams);
            }

            _gearCalculator.Calculate();
        }

        #endregion
    }
}