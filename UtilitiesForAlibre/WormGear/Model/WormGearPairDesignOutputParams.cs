using System;
using Bolsover.Involute.Model;

namespace Bolsover.WormGear.Model
{
    public class WormGearPairDesignOutputParams : IGearPairDesignOutputParams
    {
        public IGearPairDesignInputParams GearPairDesignInputParams { get; set; }
        public IGearDesignOutputParams PinionDesignOutput { get; set; }
        public IGearDesignOutputParams GearDesignOutput { get; set; }
        
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}