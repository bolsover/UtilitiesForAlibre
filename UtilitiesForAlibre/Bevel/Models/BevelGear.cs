using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bolsover.Bevel.Models
{
    public class BevelGear : IBevelGear, INotifyPropertyChanged
    {
        private double _module;
        private double _shaftAngle;
        private double _pressureAngle;
        private double _spiralAngle;
        private double _radialPressureAngle;
        private double _numberOfTeeth;
        private double _pitchConeAngle;
        private double _pitchDiameter;
        private double _baseDiameter;
        private double _rootDiameter;
        private double _innerOutsideDiameter;
        private double _axialFaceWidth;
        private double _pitchApexToCrown;
        private double _faceWidth;
        private double _coneDistance;
        private double _outsideDiameter;
        private double _rootConeAngle;
        private double _addendum;
        private double _dedendum;
        private double _dedendumAngle;
        private double _addendumAngle;
        private double _outerConeAngle;
        private string _hand;
        private string _stringValue;
        private BevelGearType _gearType;
        private double _equivalentPitchDiameter;
        private double _equivalentBaseDiameter;
        private double _equivalentRootDiameter;
        private double _equivalentAddendumDiameter;
        private double _backConeDistance;
        private double _backConeAngle;
        private double _kFactor;
        private double _circularThicknessDegrees;
        private double _interToothDegrees;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Gear Type ".PadRight(25) + _gearType);
            stringBuilder.AppendLine("Module ".PadRight(25) + _module);
            stringBuilder.AppendLine("Shaft Angle ".PadRight(25) + _shaftAngle);
            stringBuilder.AppendLine("Pressure Angle ".PadRight(25) + _pressureAngle);
            stringBuilder.AppendLine("Spiral Angle ".PadRight(25) + _spiralAngle);
            stringBuilder.AppendLine("Radial Pressure Angle ".PadRight(25) + _radialPressureAngle);
            stringBuilder.AppendLine("Number Of Teeth ".PadRight(25) + _numberOfTeeth);
            stringBuilder.AppendLine("Pitch Cone Angle ".PadRight(25) + _pitchConeAngle);
            stringBuilder.AppendLine("Pitch Diameter ".PadRight(25) + _pitchDiameter);
            stringBuilder.AppendLine("Inner Outside Diameter ".PadRight(25) + _innerOutsideDiameter);
            stringBuilder.AppendLine("Axial Face Width ".PadRight(25) + _axialFaceWidth);
            stringBuilder.AppendLine("Pitch Apex To Crown ".PadRight(25) + _pitchApexToCrown);
            stringBuilder.AppendLine("Face Width ".PadRight(25) + _faceWidth);
            stringBuilder.AppendLine("Cone Distance ".PadRight(25) + _coneDistance);
            stringBuilder.AppendLine("Outside Diameter ".PadRight(25) + _outsideDiameter);
            stringBuilder.AppendLine("Root Cone Angle ".PadRight(25) + _rootConeAngle);
            stringBuilder.AppendLine("Addendum ".PadRight(25) + _addendum);
            stringBuilder.AppendLine("Dedendum ".PadRight(25) + _dedendum);
            stringBuilder.AppendLine("Dedendum Angle ".PadRight(25) + _dedendumAngle);
            stringBuilder.AppendLine("Addendum Angle ".PadRight(25) + _addendumAngle);
            stringBuilder.AppendLine("Outer Cone Angle ".PadRight(25) + _outerConeAngle);
            stringBuilder.AppendLine("Back Cone Angle ".PadRight(25) + _backConeAngle);
            stringBuilder.AppendLine("Equivalent Pitch Diameter ".PadRight(25) + _equivalentPitchDiameter);
            stringBuilder.AppendLine("Equivalent Base Diameter ".PadRight(25) + _equivalentBaseDiameter);
            stringBuilder.AppendLine("Equivalent Root Diameter ".PadRight(25) + _equivalentRootDiameter);
            stringBuilder.AppendLine("Equivalent Addendum Diameter ".PadRight(25) + _equivalentAddendumDiameter);
            
            
            return stringBuilder.ToString();
        }

        public double Module
        {
            get => _module;
            set
            {
                _module = value;
                OnUpdated();
            }
        }


        public string StringValue
        {
            get => _stringValue;
            set
            {
                _stringValue = value;
                OnPropertyChanged();
            }
        }

        public double EquivalentPitchDiameter
        {
            get => _equivalentPitchDiameter;
            set
            {
                _equivalentPitchDiameter = value;
                OnPropertyChanged();
            }
        }

        public double EquivalentBaseDiameter
        {
            get => _equivalentBaseDiameter;
            set
            {
                _equivalentBaseDiameter = value;
                OnPropertyChanged();
            }
        }

        public double EquivalentRootDiameter
        {
            get => _equivalentRootDiameter;
            set
            {
                _equivalentRootDiameter = value;
                OnPropertyChanged();
            }
        }

        public double EquivalentAddendumDiameter
        {
            get => _equivalentAddendumDiameter;
            set
            {
                _equivalentAddendumDiameter = value;
                OnPropertyChanged();
            }
        }

        public double BackConeDistance
        {
            get => _backConeDistance;
            set
            {
                _backConeDistance = value;
                OnPropertyChanged();
            }
        }

        public double BackConeAngle
        {
            get => _backConeAngle;
            set
            {
                _backConeAngle = value;
                OnPropertyChanged();
            }
        }

        public double KFactor  {
            get => _kFactor;
            set
            {
                _kFactor = value;
                OnPropertyChanged();
            }
        }

        public double CircularThicknessDegrees { 
            get => _circularThicknessDegrees;
            set
            {
                _circularThicknessDegrees = value;
                OnPropertyChanged();
            }
        }

        public double InterToothDegrees { 
            get => _interToothDegrees;
            set
            {
                _interToothDegrees = value;
                OnPropertyChanged();
            }
        }

        public BevelGearType GearType
        {
            get => _gearType;
            set
            {
                _gearType = value;
                OnUpdated();
            }
        }

        public double ShaftAngle
        {
            get => _shaftAngle;
            set
            {
                _shaftAngle = value;
                OnUpdated();
            }
        }


        public double PressureAngle
        {
            get => _pressureAngle;
            set
            {
                _pressureAngle = value;
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

        public double PitchDiameter
        {
            get => _pitchDiameter;
            set
            {
                _pitchDiameter = value;
                OnPropertyChanged();
            }
        }

        public double BaseDiameter {
            get => _baseDiameter;
            set
            {
                _baseDiameter = value;
                OnPropertyChanged();
            }
        }
        public double RootDiameter{
            get => _rootDiameter;
            set
            {
                _rootDiameter = value;
                OnPropertyChanged();
            }
        }

        public double RadialPressureAngle
        {
            get => _radialPressureAngle;
            set
            {
                _radialPressureAngle = value;
                OnPropertyChanged();
            }
        }

        public double PitchConeAngle
        {
            get => _pitchConeAngle;
            set
            {
                _pitchConeAngle = value;
                OnPropertyChanged();
            }
        }

        public double ConeDistance
        {
            get => _coneDistance;
            set
            {
                _coneDistance = value;
                OnPropertyChanged();
            }
        }

        public double FaceWidth
        {
            get => _faceWidth;
            set
            {
                _faceWidth = value;
                OnUpdated();
            }
        }

        public double Addendum
        {
            get => _addendum;
            set
            {
                _addendum = value;
                OnPropertyChanged();
            }
        }

        public double Dedendum
        {
            get => _dedendum;
            set
            {
                _dedendum = value;
                OnPropertyChanged();
            }
        }

        public double DedendumAngle
        {
            get => _dedendumAngle;
            set
            {
                _dedendumAngle = value;
                OnPropertyChanged();
            }
        }

        public double AddendumAngle
        {
            get => _addendumAngle;
            set
            {
                _addendumAngle = value;
                OnPropertyChanged();
            }
        }

        public double OuterConeAngle
        {
            get => _outerConeAngle;
            set
            {
                _outerConeAngle = value;
                OnPropertyChanged();
            }
        }

        public double RootConeAngle
        {
            get => _rootConeAngle;
            set
            {
                _rootConeAngle = value;
                OnPropertyChanged();
            }
        }

        public double OutsideDiameter
        {
            get => _outsideDiameter;
            set
            {
                _outsideDiameter = value;
                OnPropertyChanged();
            }
        }

        public double PitchApexToCrown
        {
            get => _pitchApexToCrown;
            set
            {
                _pitchApexToCrown = value;
                OnPropertyChanged();
            }
        }

        public double AxialFaceWidth
        {
            get => _axialFaceWidth;
            set
            {
                _axialFaceWidth = value;
                OnPropertyChanged();
            }
        }

        public double InnerOutsideDiameter
        {
            get => _innerOutsideDiameter;
            set
            {
                _innerOutsideDiameter = value;
                OnPropertyChanged();
            }
        }

        public string Hand
        {
            get => _hand;
            set
            {
                _hand = value;
                OnUpdated();
            }
        }

        public double SpiralAngle
        {
            get => _spiralAngle;
            set
            {
                _spiralAngle = value;
                OnUpdated();
            }
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