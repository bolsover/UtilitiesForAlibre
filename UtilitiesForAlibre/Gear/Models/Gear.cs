using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bolsover.Gear.Models
{
    public class Gear : IGear, INotifyPropertyChanged
    {
        private double _addendumCircleDiameter;
        private double _addendumFilletFactor;
        private double _axialPitch;
        private double _baseCircleDiameter;
        private double _centreDistanceIncrementFactor;
        private double _circumferentialBacklash;
         private double _normalCoefficientOfProfileShift;
        private double _contactRatio;
        private double _dedendumCircleDiameter;
        private double _delta;
        private string _gearType;
        private double _helicalPressureAngle;
        private double _helixAngle;
        private double _helixPitchLength;
        private double _involuteFunction;
        private double _module;
        private double _numberOfTeeth;
        private double _pitchDiameter;
        private double _pressureAngle;
        private double _rootFilletDiameter;
        private double _rootFilletFactor;
        private double _standardCentreDistance;
        private double _tipReliefRadius;
        private double _transverseModule;
        private double _workingCentreDistance;
        private double _workingPitchDiameter;
        private double _radialWorkingPressureAngle;
       
        private double _addendum;
        private double _dedendum;
        private double _wholeDepth;
        private double _outsideDiameter;
        private double _rootDiameter;
        private string _simpleGearString;
        private double _radialPressureAngle;
        private double _height = 10;
        private double _pitch;
        private GearType _type;
      
        private double _backlashAdjustmentFactorXMod;
       
        private IGearPair _gearPair;
        private double _normalBacklash;
        private double _theta;
        private double _alpha;

        public double Pitch
        {
            get => _pitch;
            set => SetField(ref _pitch, value);
        }

        public string GearString
        {
            get => _simpleGearString;
            set => SetField(ref _simpleGearString, value);
        }

        public GearType Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }


        public double BacklashAdjustmentFactorXMod
        {
            get => _backlashAdjustmentFactorXMod;
            set => SetField(ref _backlashAdjustmentFactorXMod, value);
        }

        public double Theta
        {
            get => _theta;
            set => SetField(ref _theta, value);
        }

        public double Alpha
        {
            get => _alpha;
            set => SetField(ref _alpha, value);
        }


        public double NormalCoefficientOfProfileShift
        {
            get => _normalCoefficientOfProfileShift;
            set => SetField(ref _normalCoefficientOfProfileShift, value);
        }

        public IGearPair GearPair
        {
            get => _gearPair;
            set => _gearPair = value;
        }

        public double Height
        {
            get => _height;
            set => _height = value;
        }

        public double NormalModule
        {
            get => _module;
            set
            {
                _module = value;
                OnUpdated();
            }
        }

        public double NumberOfTeeth
        {
            get => _numberOfTeeth;
            set
            {
                _numberOfTeeth = value;
                OnUpdated();
            }
        }

        public double NormalPressureAngle
        {
            get => _pressureAngle;
            set
            {
                _pressureAngle = value;
                OnUpdated();
            }
        }

        public double RadialWorkingPressureAngle
        {
            get => _radialWorkingPressureAngle;
            set => SetField(ref _radialWorkingPressureAngle, value);
        }

        public double RadialPressureAngle
        {
            get => _radialPressureAngle;
            set => SetField(ref _radialPressureAngle, value);
        }

        public double HelixAngle
        {
            get => _helixAngle;
            set
            {
                _helixAngle = value;
                OnUpdated();
            }
        }

        public double RootFilletFactor
        {
            get => _rootFilletFactor;
            set => SetField(ref _rootFilletFactor, value);
        }

        public double AddendumFilletFactor
        {
            get => _addendumFilletFactor;
            set => SetField(ref _addendumFilletFactor, value);
        }

        public string GearType
        {
            get => _gearType;
            set => SetField(ref _gearType, value);
        }

        public double NormalBacklash
        {
            get => _normalBacklash;
            set
            {
                _normalBacklash = value;
                OnUpdated();
            }
        }

        public double CircumferentialBacklash
        {
            get => _circumferentialBacklash;
            set => SetField(ref _circumferentialBacklash, value);
        }

        public double Delta
        {
            get => _delta;
            set => SetField(ref _delta, value);
        }

        public double WorkingCentreDistance
        {
            get => _workingCentreDistance;
            set => SetField(ref _workingCentreDistance, value);
        }

        public double StandardCentreDistance
        {
            get => _standardCentreDistance;
            set => SetField(ref _standardCentreDistance, value);
        }

        public double CentreDistanceIncrementFactor
        {
            get => _centreDistanceIncrementFactor;
            set => SetField(ref _centreDistanceIncrementFactor, value);
        }

        public double PitchCircleDiameter
        {
            get => _pitchDiameter;
            set => SetField(ref _pitchDiameter, value);
        }

     
        public double BaseCircleDiameter
        {
            get => _baseCircleDiameter;
            set => SetField(ref _baseCircleDiameter, value);
        }


        public double AddendumCircleDiameter
        {
            get => _addendumCircleDiameter;
            set => SetField(ref _addendumCircleDiameter, value);
        }

        public double DedendumCircleDiameter
        {
            get => _dedendumCircleDiameter;
            set => SetField(ref _dedendumCircleDiameter, value);
        }

        
      
        public double AxialPitch
        {
            get => _axialPitch;
            set => SetField(ref _axialPitch, value);
        }

        public double HelixPitchLength
        {
            get => _helixPitchLength;
            set => SetField(ref _helixPitchLength, value);
        }

        public double HelicalPressureAngle
        {
            get => _helicalPressureAngle;
            set => SetField(ref _helicalPressureAngle, value);
        }

        public double InvoluteFunction
        {
            get => _involuteFunction;
            set => SetField(ref _involuteFunction, value);
        }

        public double TransverseModule
        {
            get => _transverseModule;
            set => SetField(ref _transverseModule, value);
        }

        public double RootFilletDiameter
        {
            get => _rootFilletDiameter;
            set => SetField(ref _rootFilletDiameter, value);
        }

        public double TipReliefRadius
        {
            get => _tipReliefRadius;
            set => SetField(ref _tipReliefRadius, value);
        }

        public double ContactRatio
        {
            get => _contactRatio;
            set => SetField(ref _contactRatio, value);
        }

       
        public double Addendum
        {
            get => _addendum;
            set => SetField(ref _addendum, value);
        }

        public double Dedendum
        {
            get => _dedendum;
            set => SetField(ref _dedendum, value);
        }

        public double WholeDepth
        {
            get => _wholeDepth;
            set => SetField(ref _wholeDepth, value);
        }

        public double OutsideDiameter
        {
            get => _outsideDiameter;
            set => SetField(ref _outsideDiameter, value);
        }

        public double RootCircleDiameter
        {
            get => _rootDiameter;
            set => SetField(ref _rootDiameter, value);
        }
        
        public string ToAdvancedGearString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Item ".PadRight(30) + "Metric".PadRight(30) + "Imperial");
            // stringBuilder.AppendLine("");

            stringBuilder.AppendLine("Normal Module".PadRight(30) + NormalModule.ToString("0.000").PadRight(30) +
                                     (25.4 / NormalModule).ToString("0.0000 in DP") + ", " +
                                     (Math.PI / (25.4 / NormalModule)).ToString("0.0000 in CP"));
            stringBuilder.AppendLine("Radial Module".PadRight(30) + TransverseModule.ToString("0.000").PadRight(30) +
                                     (25.4 / TransverseModule).ToString("0.0000 in DP") + ", " +
                                     (Math.PI / (25.4 / TransverseModule)).ToString("0.0000 in CP"));

            stringBuilder.AppendLine(
                GetFormattedData("Normal Pressure Angle", NormalPressureAngle, NormalPressureAngle, "0.000°", "0.000°"));
            stringBuilder.AppendLine(
                GetFormattedData("Radial Pressure Angle", RadialPressureAngle, RadialPressureAngle, "0.000°", "0.000°"));
            stringBuilder.AppendLine(GetFormattedData("Helix Angle", HelixAngle, HelixAngle, "0.000°", "0.000°"));
            stringBuilder.AppendLine(GetFormattedData("Number Of Teeth", NumberOfTeeth, NumberOfTeeth, "0", "0"));
            stringBuilder.AppendLine(GetFormattedData("Base Diameter", BaseCircleDiameter, BaseCircleDiameter / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Root Diameter", RootCircleDiameter, RootCircleDiameter / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Pitch Diameter", PitchCircleDiameter, PitchCircleDiameter / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Outside Diameter", OutsideDiameter, OutsideDiameter / 25.4, "0.000 mm",
                "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Addendum", Addendum, Addendum / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Dedendum", Dedendum, Dedendum / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Whole Depth", WholeDepth, WholeDepth / 25.4, "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Std Centre Distance", StandardCentreDistance, StandardCentreDistance / 25.4,
                "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Working Centre Distance", WorkingCentreDistance, WorkingCentreDistance / 25.4,
                "0.000 mm", "0.0000 in"));
            stringBuilder.AppendLine(GetFormattedData("Theta", Theta, Theta,
                "0.000°", "0.0000°"));
            stringBuilder.AppendLine(GetFormattedData("Alpha", Alpha, Alpha,
                "0.000°", "0.0000°"));

            stringBuilder.AppendLine("");
            return stringBuilder.ToString();
        }
        
        private string GetFormattedData(String columnName, double metricValue, double imperialValue, string metricFormat, string imperialFormat)
        {
            const int columnWidth = 30;
            var metric = metricValue.ToString(metricFormat);
            var imperial = imperialValue.ToString(imperialFormat);
            return $"{columnName,-columnWidth}{metric,-columnWidth}{imperial}";
        }

        public event EventHandler Updated;

        private void OnUpdated()
        {
            Updated?.Invoke(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}