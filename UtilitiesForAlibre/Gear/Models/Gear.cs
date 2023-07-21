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
        private double _circularBacklash;
        private double _coefficientOfProfileShift;
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
        private double _profileShift;
        private double _rootFilletDiameter;
        private double _rootFilletFactor;
        private double _standardCentreDistance;
        private double _tipReliefRadius;
        private double _transverseModule;
        private double _workingCentreDistance;
        private double _workingPitchDiameter;
        private double _radialWorkingPressureAngle;
        private double _baseDiameter;
        private double _addendum;
        private double _dedendum;
        private double _wholeDepth;
        private double _outsideDiameter;
        private double _rootDiameter;
        private string _simpleGearString;
        private double _radialPressureAngle;
        private double _height = 10;
        private double _pitch;

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


        public double ProfileShift
        {
            get => _profileShift;
            set => SetField(ref _radialWorkingPressureAngle, value);
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

        public double CircularBacklash
        {
            get => _circularBacklash;
            set => SetField(ref _circularBacklash, value);
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

        public double PitchDiameter
        {
            get => _pitchDiameter;
            set => SetField(ref _pitchDiameter, value);
        }

        public double WorkingPitchDiameter
        {
            get => _workingPitchDiameter;
            set => SetField(ref _workingPitchDiameter, value);
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

        public double CoefficientOfProfileShift
        {
            get => _coefficientOfProfileShift;
            set => SetField(ref _coefficientOfProfileShift, value);
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

        public double BaseDiameter
        {
            get => _baseDiameter;
            set => SetField(ref _baseDiameter, value);
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

        public double RootDiameter
        {
            get => _rootDiameter;
            set => SetField(ref _rootDiameter, value);
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