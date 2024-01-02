using System;
using System.ComponentModel;

namespace Bolsover.Involute.Model
{
    public interface IGearPairDesignInputParams
    {
        IGearDesignInputParams Pinion { get; set; }
        IGearDesignInputParams Gear { get; set; }
        bool Auto { get; set; }
        double WorkingCentreDistance { get; set; } //working centre distance of gear pair - include allowance for profile shifted gears

        event PropertyChangedEventHandler PropertyChanged;
    }
}