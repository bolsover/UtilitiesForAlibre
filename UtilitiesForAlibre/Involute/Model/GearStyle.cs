using System;

namespace Bolsover.Involute.Model
{
    
    /// <summary>
    /// This enum is essentially a collection of flags that can be combined to represent the style of a gear.
    /// 
    /// Usage:
    /// Setting a gear style:
    /// GearStyle Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear
    ///
    /// Testing a gear style:
    /// if (Style.HasFlag(GearStyle.External) && Style.HasFlag(GearStyle.Spur))...
    ///
    /// Resetting a gear style:
    /// Style &= ~GearStyle.External; // removes the external flag from the style
    /// Style |= GearStyle.Internal; // adds the internal flag to the style
    /// 
    /// </summary>
    [Flags]
    public enum GearStyle
    {   
        Undefined = 0b_0000_0000, //0
        Spur = 0b_0000_0001, //1
        Helical = 0b_0000_0010, //2
        Rack = 0b_0000_0100, //4
        Internal = 0b_0000_1000, //8
        External = 0b_0001_0000, //16
        Worm = 0b_0010_0000, //32
        WormWheel = 0b_0100_0000, //64
        Bevel = 0b_1000_0000, //128
        Crown = 0b_1_0000_0000, //256
        Planetary = 0b_10_0000_0000, //512 
        Cycloidal = 0b_100_0000_0000 //1024  
        
    }
}