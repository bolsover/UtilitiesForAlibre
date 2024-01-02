using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bolsover.Involute.Model
{
    public class GearPairDesignInputParams : IGearPairDesignInputParams, INotifyPropertyChanged
    {
        private IGearDesignInputParams _pinion;
        private IGearDesignInputParams _gearDesign;
        private bool _auto;
        private double _workingCentreDistance;
        
        public GearPairDesignInputParams()
        {
            Pinion = new GearDesignInputParams();
            Gear = new GearDesignInputParams();
            Auto = true;
            WorkingCentreDistance = 0;
           }

        public IGearDesignInputParams Pinion
        {
            get => _pinion;
            set => SetField(ref _pinion, value);
        }
        
        public IGearDesignInputParams Gear
        {
            get => _gearDesign;
            set => SetField(ref _gearDesign, value);
        }

        public bool Auto
        {
            get => _auto;
            set => SetField(ref _auto, value);
        }

        public double WorkingCentreDistance
        {
            get => _workingCentreDistance;
            set =>  SetField(ref _workingCentreDistance, value);
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