using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bolsover.Involute.Model
{
    public class GearPairDesignOutputParams : IGearPairDesignOutputParams, INotifyPropertyChanged
    {
        private IGearPairDesignInputParams _gearPairDesignInputParams;
        private IGearDesignOutputParams _pinionDesignOutput;
        private IGearDesignOutputParams _gearDesignOutput;

        private string _gearString;

        public GearPairDesignOutputParams()
        {
            _pinionDesignOutput = new GearDesignOutputParams();
            _gearDesignOutput = new GearDesignOutputParams();
        }

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