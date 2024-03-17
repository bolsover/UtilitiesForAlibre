using System;
using System.IO;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Involute.Builder;
using Bolsover.Involute.Calculator;
using Bolsover.Involute.Model;
using Bolsover.RackPinion.Model;
using Bolsover.RackPinion.View;
using static Bolsover.Utils.ConversionUtils;
using static Bolsover.Utils.LatexUtils;
using static Bolsover.Involute.Model.GearStyle;

namespace Bolsover.RackPinion.Presenter
{
    public class RackPinionPresenter
    {
        private RackPinionView _view;
        public GearPairDesignInputParams Model;
        private RackPinionDesignOutputParams _gearPairDesignOutputParams;
        private IToothPointsBuilder _toothPointsBuilder;
        private AlibreToothBuilder _alibreToothBuilder;
        private IGearCalculator _gearCalculator;

        public RackPinionPresenter(RackPinionView view)
        {
            _view = view;
            Initialise();
        }

        private void Initialise()
        {
            Model = new GearPairDesignInputParams();
            _gearPairDesignOutputParams = new RackPinionDesignOutputParams
            {
                GearPairDesignInputParams = Model
            };
            _toothPointsBuilder = new ExternalSpurHelicalToothBuilder(); // setup default builder for pinion
            InitGearPair();
            SetupDefaults();
            ClearLabelText();
            SetupLabelLatexImages();
            SetupEventListeners();

            SetupObjectListView();
            Recalculate();
        }

        private void Recalculate()
        {
            Calculate();
        }

        private void Calculate()
        {
            if (Model.Gear.Style.HasFlag(Rack) && Model.Gear.Style.HasFlag(Spur))
                CalculateStraightRackGear();
            else if (Model.Gear.Style.HasFlag(Rack) && Model.Gear.Style.HasFlag(Helical))
                CalculateHelicalRackGear();
            else
                throw new ArgumentException("Gear style not recognised");
        }

        private void CalculateHelicalRackGear()
        {
            if (_gearCalculator is not ProfileShiftedExternalHelicalGearCalculator)
            {
                _gearCalculator = new ProfileShiftedExternalHelicalGearCalculator(Model, _gearPairDesignOutputParams);
            }

            _gearCalculator.Calculate();
        }

        private void CalculateStraightRackGear()
        {
            if (_gearCalculator is not ProfileShiftedExternalSpurGearCalculator)
            {
                _gearCalculator = new ProfileShiftedExternalSpurGearCalculator(Model, _gearPairDesignOutputParams);
            }

            _gearCalculator.Calculate();
        }


        private void SetupLabelLatexImages()
        {
            _view.moduleSymbol.Image = CreateImageFromLatex(RackPinionLatexStrings.ModuleLatex);
            _view.alphaSymbol.Image = CreateImageFromLatex(RackPinionLatexStrings.AlphaLatex);
            _view.betaSymbol.Image = CreateImageFromLatex(RackPinionLatexStrings.BetaLatex);
            _view.teethSymbol.Image = CreateImageFromLatex(RackPinionLatexStrings.TeethLatex);
            _view.widthSymbol.Image = CreateImageFromLatex(RackPinionLatexStrings.WidthLatex);
        }

        private void ClearLabelText()
        {
            _view.moduleSymbol.Text = "";
            _view.alphaSymbol.Text = "";
            _view.betaSymbol.Text = "";
            _view.teethSymbol.Text = "";
            _view.widthSymbol.Text = "";
        }

        private void SetupObjectListView()
        {
            _view.olvColumn1.AspectGetter = rowObject => ((GearData)rowObject).Item;
            _view.olvColumn2.AspectGetter = rowObject => ((GearData)rowObject).MetricValue;
            _view.olvColumn3.AspectGetter = rowObject => ((GearData)rowObject).ImperialValue;
            _view.olvColumn4.AspectGetter = rowObject => ((GearData)rowObject).Note;
        }

        private void SetupEventListeners()
        {
            _view.BuildRackEvent += ViewOnBuildRack;
            _view.BuildPinionEvent += ViewOnBuildPinionEvent;
            _view.CancelEvent += ViewOnCancelEvent;
            _view.EditModuleEvent += ViewOnEditModuleEvent;
            _view.EditPressureAngleEvent += ViewOnEditPressureAngleEvent;
            _view.EditPinionNumberOfTeethEvent += ViewOnEditPinionNumberOfTeethEvent;
            _view.EditGearNumberOfTeethEvent += ViewOnEditGearNumberOfTeethEvent;
            _view.EditHelixAngleEvent += ViewOnEditHelixAngleEvent;
            _view.EditGearHeightEvent += ViewOnEditGearHeightEvent;
        }

        private void ViewOnEditGearHeightEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double)numericUpDown.Value;
                Model.Gear.Height = newValue;
                Model.Pinion.Height = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditHelixAngleEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double)numericUpDown.Value;
                Model.Gear.HelixAngle = newValue;
                Model.Pinion.HelixAngle = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditGearNumberOfTeethEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double)numericUpDown.Value;
                Model.Gear.Teeth = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditPinionNumberOfTeethEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double)numericUpDown.Value;

                Model.Pinion.Teeth = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditPressureAngleEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double)numericUpDown.Value;
                Model.Gear.PressureAngle = newValue;
                Model.Pinion.PressureAngle = newValue;
            }

            Recalculate();
        }

        private void ViewOnEditModuleEvent(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                var newValue = (double)numericUpDown.Value;
                Model.Gear.Module = newValue;
                Model.Pinion.Module = newValue;
            }
        }

        private void ViewOnCancelEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ViewOnBuildRack(object sender, EventArgs e)
        {
            var fileData = GetRackDetails();
            var filePath = GetAlibreFilePath(fileData.SaveFile, fileData.Template);
            var session = InitAlibreFile(filePath);
            session.Parameters.OpenParameterTransaction();
            session.Parameters.Item("Alpha").Value = Radians(Model.Gear.PressureAngle);
            session.Parameters.Item("Beta").Value = Radians(Model.Gear.HelixAngle);
            session.Parameters.Item("Module").Value = Model.Gear.Module * 0.1;
            session.Parameters.Item("RackTeeth").Value = Model.Gear.Teeth;
            session.Parameters.Item("Width").Value = Model.Gear.Height * 0.1;
            session.Parameters.CloseParameterTransaction();
            ((IADPartSession)session).RegenerateAll();
        }

        private void ViewOnBuildPinionEvent(object sender, EventArgs e)
        {
            //   Recalculate();
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
                _toothPointsBuilder = _toothPointsBuilder is ExternalSpurHelicalToothBuilder
                    ? _toothPointsBuilder
                    : new ExternalSpurHelicalToothBuilder();
                return;
            }

            // this is a gear
            if (Model.Gear.Style.HasFlag(External) && (Model.Gear.Style.HasFlag(Spur) || Model.Gear.Style.HasFlag(Helical)))
            {
                _toothPointsBuilder = _toothPointsBuilder is ExternalSpurHelicalToothBuilder
                    ? _toothPointsBuilder
                    : new ExternalSpurHelicalToothBuilder();
            }
            else if (Model.Gear.Style.HasFlag(Internal) && (Model.Gear.Style.HasFlag(Spur) || Model.Gear.Style.HasFlag(Helical)))
            {
                _toothPointsBuilder = _toothPointsBuilder is InternalSpurHelicalToothBuilder
                    ? _toothPointsBuilder
                    : new InternalSpurHelicalToothBuilder();
            }
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

        private (string SaveFile, string Template) GetRackDetails()
        {
            return ("RackPleaseSaveAs.AD_PRT", "HelicalRackTemplate.AD_PRT");
        }

        private static string GetAlibreFilePath(string SaveFile, string Template)
        {
            var filePath = Globals.InstallPath;
            var tempFile = Path.Combine(Path.GetTempPath(), SaveFile);
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show($"Temporary file {SaveFile} is currently open. \nPlease save-as or discard.", "Oops");
                return null;
            }

            if (filePath != null)
            {
                filePath += "\\Gear\\" + Template;
            }

            File.Copy(filePath, tempFile, true);
            return tempFile;
        }

        private static IADDesignSession InitAlibreFile(string filePath)
        {
            var root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
            var session = (IADDesignSession)root.OpenFileEx(filePath, true);
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

        private void InitGearPair()
        {
            var gear = new GearDesignInputParams();
            var pinion = new GearDesignInputParams();
            gear.Style = Rack | Spur;
            pinion.Style = Rack | Spur;
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
            _view.gearTeethNumericUpDown.Value = (decimal)Model.Gear.Teeth;
            _view.pinionTeethNumericUpDown.Value = (decimal)Model.Pinion.Teeth;
            _view.moduleNumericUpDown.Value = (decimal)Model.Gear.Module;
            _view.pressureAngleNumericUpDown.Value = (decimal)Model.Gear.PressureAngle;
            _view.helixAngleNumericUpDown.Value = (decimal)Model.Gear.HelixAngle;
        }
    }
}