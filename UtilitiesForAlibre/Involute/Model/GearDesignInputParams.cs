using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bolsover.Involute.Model
{
    
    public sealed class GearDesignInputParams : IGearDesignInputParams
    {
        private double _height;
        private double _module;
        private double _teeth;
        private double _pressureAngle;
        private double _helixAngle;
        private double _rootFilletFactor;
        private double _addendumFilletFactor;
       private double _workingCentreDistance;
        private double _profileShift;
        private GearStyle _style;
        private double _circularBacklash;
        private double _heightOfPitchLine;

        public GearDesignInputParams()
        {
            SetDefaults();
        }

        public void SetDefaults()
        {
            Module = 1.0;
            PressureAngle = 20.0;
            HelixAngle = 0;
            Teeth = 30.0;
            CoefficientOfProfileShift = 0;
            AddendumFilletFactor = 0.25;
            RootFilletFactor = 0.38;
            WorkingCentreDistance = 30;
            CircularBacklash = 0.0;
            Height = 20.0;
            HeightOfPitchLine = 0.0;
            Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear
        }

        

        public double Height
        {
            get => _height;
            set => SetField(ref _height, value);
        }

        public double Module
        {
            get => _module;
            set => SetField(ref _module, value);
        }

        public double Teeth
        {
            get => _teeth;
            set => SetField(ref _teeth, value);
        }

        public double PressureAngle
        {
            get => _pressureAngle;
            set => SetField(ref _pressureAngle, value);
        }

        public double HelixAngle
        {
            get => _helixAngle;
            set => SetField(ref _helixAngle, value);
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

      

        public double WorkingCentreDistance
        {
            get => _workingCentreDistance;
            set => SetField(ref _workingCentreDistance, value);
        }

        public double CircularBacklash
        {
            get => _circularBacklash;
            set => SetField(ref _circularBacklash, value);
        }

        public double CoefficientOfProfileShift
        {
            get => _profileShift;
            set => SetField(ref _profileShift, value);
        }

        public double HeightOfPitchLine
        {
            get => _heightOfPitchLine;
            set => SetField(ref _heightOfPitchLine, value);
        }

        public GearStyle Style
        {
            get => _style;
            set => SetField(ref _style, value);
        }

        public IGearPairDesignInputParams GearPairDesign { get; set; }

        public event  GearChangedEventHandler GearChanged;

        private void OnGearChanged([CallerMemberName] string propertyName = null, object value = null)
        {
            GearChanged?.Invoke(this, new GearChangeEventArgs(propertyName, value));
        }
        

        private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnGearChanged(propertyName, value);
            return true;
        }
    }
}