using Bolsover.Involute.Model;

namespace Bolsover.WormGear.Model
{
    public class WormGearPairDesignInputParams : IGearPairDesignInputParams
    {
        public IGearDesignInputParams Pinion { get; set; }
        public IGearDesignInputParams Gear { get; set; }
        public bool Auto { get; set; }
        public double WorkingCentreDistance { get; set; }
        public event GearChangedEventHandler GearChanged;
    }
}