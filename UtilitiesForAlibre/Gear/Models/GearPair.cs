using System;

namespace Bolsover.Gear.Models
{
    public class GearPair : IGearPair
    {
        private IGear _pinion; // when calculating this is always gear 1
        private IGear _gear; // when calculating this is always gear 2
        private double _centreDistance;

        public IGear Pinion
        {
            get => _pinion;
            set => _pinion = value;
        }

        public IGear Gear
        {
            get => _gear;
            set => _gear = value;
        }

        

        public event EventHandler Updated;

        private void OnUpdated()
        {
            Updated?.Invoke(this, EventArgs.Empty);
        }
    }
}