using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Bolsover.Involute.Model;

namespace Bolsover.RackPinion.Model
{
    public class RackPinionDesignOutputParams : IGearPairDesignOutputParams
    {
        private IGearPairDesignInputParams _gearPairDesignInputParams;
        private IGearDesignOutputParams _pinionDesignOutput = new GearDesignOutputParams();
        private IGearDesignOutputParams _gearDesignOutput = new GearDesignOutputParams();


        public IGearPairDesignInputParams GearPairDesignInputParams
        {
            get => _gearPairDesignInputParams;
            set => SetField(ref _gearPairDesignInputParams, value);
        }

        public IGearDesignOutputParams PinionDesignOutput
        {
            get => _pinionDesignOutput;
            set => SetField(ref _pinionDesignOutput, value);
        }

        public IGearDesignOutputParams GearDesignOutput
        {
            get => _gearDesignOutput;
            set => SetField(ref _gearDesignOutput, value);
        }

        public void Reset()
        {
            _pinionDesignOutput.Reset();
            _gearDesignOutput.Reset();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}