using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bolsover.Involute.Model
{
    public class GearDesignOutputParams : IGearDesignOutputParams, INotifyPropertyChanged
    {
        private IGearDesignInputParams _gearDesignInputParams;
        private double _radialWorkingPressureAngle;
        private double _radialPressureAngle;

        private double _pitchCircleDiameter;
        private double _baseCircleDiameter;
        private double _normalCoefficientOfProfileShift;
        private double _axialPitch;
        private double _helixPitchLength;
        private double _helicalPressureAngle;
        private double _radialModule;
        private double _rootFilletDiameter;
        private double _tipReliefRadius;

        private double _addendum;
        private double _dedendum;
        private double _wholeDepth;
        private double _outsideDiameter;
        private double _rootCircleDiameter;
        private double _pitch;
        private string _gearString;
        private double _backlashAdjustmentFactorXMod;

        private double _workingPitchDiameter;
        private double _workingPressureAngle;
        private double _sumCoefficientOfProfileShift;
        private double _differenceCoefficientOfProfileShift;
        private double _centreDistanceIncrementFactor;
        private double _centreDistance;
        private bool _auto;
        private double _workingInvoluteFunction;
        private double _radialInvoluteFunction;
        private double _radialWorkingInvoluteFunction;
        private double _involuteFunction;
        private double _contactRatioAlpha;
        private double _contactRatioBeta;
        private double _contactRatioGamma;

        public IGearDesignInputParams GearDesignInputParams
        {
            get => _gearDesignInputParams;
            set => SetField(ref _gearDesignInputParams, value);
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

        public double PitchCircleDiameter
        {
            get => _pitchCircleDiameter;
            set => SetField(ref _pitchCircleDiameter, value);
        }

        public double BaseCircleDiameter
        {
            get => _baseCircleDiameter;
            set => SetField(ref _baseCircleDiameter, value);
        }

        public double NormalCoefficientOfProfileShift
        {
            get => _normalCoefficientOfProfileShift;
            set => SetField(ref _normalCoefficientOfProfileShift, value);
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

        public double RadialModule
        {
            get => _radialModule;
            set => SetField(ref _radialModule, value);
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
            get => _rootCircleDiameter;
            set => SetField(ref _rootCircleDiameter, value);
        }

        public double Pitch
        {
            get => _pitch;
            set => SetField(ref _pitch, value);
        }

        public string GearString
        {
            get => _gearString;
            set => SetField(ref _gearString, value);
        }

        public double BacklashAdjustmentFactorXMod
        {
            get => _backlashAdjustmentFactorXMod;
            set => SetField(ref _backlashAdjustmentFactorXMod, value);
        }

        public double WorkingPitchDiameter
        {
            get => _workingPitchDiameter;
            set => SetField(ref _workingPitchDiameter, value);
        }

        public double InvoluteFunction
        {
            get => _involuteFunction;
            set => _involuteFunction = value;
        }

        public double WorkingPressureAngle
        {
            get => _workingPressureAngle;
            set => SetField(ref _workingPressureAngle, value);
        }

        public double ContactRatioAlpha
        {
            get => _contactRatioAlpha;
            set => SetField(ref _contactRatioAlpha, value);
        }

        public double ContactRatioBeta
        {
            get => _contactRatioBeta;
            set => SetField(ref _contactRatioBeta, value);
        }

        public double ContactRatioGamma
        {
            get => _contactRatioAlpha + _contactRatioBeta;
        }

        public void Reset()
        {
            _contactRatioAlpha = 0;
            _contactRatioBeta = 0;
            _contactRatioGamma = 0; 
            _radialWorkingPressureAngle = 0;
            _radialPressureAngle = 0;
            _pitchCircleDiameter = 0;
            _baseCircleDiameter = 0;
            _normalCoefficientOfProfileShift = 0;
            _axialPitch = 0;
            _helixPitchLength = 0;
            _helicalPressureAngle = 0;
            _radialModule = 0;
            _rootFilletDiameter = 0;
            _tipReliefRadius = 0;
            _addendum = 0;
            _dedendum = 0;
            _wholeDepth = 0;
            _outsideDiameter = 0;
            _rootCircleDiameter = 0;
            _pitch = 0;
            _gearString = "";
            _backlashAdjustmentFactorXMod = 0;
            _workingPitchDiameter = 0;
            _workingPressureAngle = 0;
            _sumCoefficientOfProfileShift = 0;
            _differenceCoefficientOfProfileShift = 0;
            _centreDistanceIncrementFactor = 0;
            _centreDistance = 0;
            // _auto = false;
            _workingInvoluteFunction = 0;
            _radialInvoluteFunction = 0;
            _radialWorkingInvoluteFunction = 0;
            _involuteFunction = 0;
        
            
            
        }

        public double SumCoefficientOfProfileShift
        {
            get => _sumCoefficientOfProfileShift;
            set => SetField(ref _sumCoefficientOfProfileShift, value);
        }

        public double DifferenceCoefficientOfProfileShift
        {
            get => _differenceCoefficientOfProfileShift;
            set => SetField(ref _differenceCoefficientOfProfileShift, value);
        }

        public double CentreDistanceIncrementFactor
        {
            get => _centreDistanceIncrementFactor;
            set => SetField(ref _centreDistanceIncrementFactor, value);
        }

        public double CentreDistance
        {
            get => _centreDistance;
            set => SetField(ref _centreDistance, value);
        }

        public bool Auto
        {
            get => _auto;
            set => SetField(ref _auto, value);
        }

        public double WorkingInvoluteFunction
        {
            get => _workingInvoluteFunction;
            set => SetField(ref _workingInvoluteFunction, value);
        }

        public double RadialInvoluteFunction
        {
            get => _radialInvoluteFunction;
            set => SetField(ref _radialInvoluteFunction, value);
        }

        public double RadialWorkingInvoluteFunction
        {
            get => _radialWorkingInvoluteFunction;
            set => SetField(ref _radialWorkingInvoluteFunction, value);
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