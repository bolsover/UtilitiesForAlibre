namespace Bolsover.Gear.Models
{
    public class GearPair : IGearPair
    {
        private IGear _pinion;
        private IGear _gear;

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
    }
}