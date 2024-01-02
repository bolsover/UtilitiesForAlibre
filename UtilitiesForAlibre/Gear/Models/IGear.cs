using System;

namespace Bolsover.Gear.Models
{
    public interface IGear
    {
        IGearPair GearPair { get; set; } // the gear pair to which this gear belongs
        double Height { get; set; } // height of gear
        double NormalModule { get; set; } // normal module
        
        double NumberOfTeeth { get; set; } // teeth
        double NormalPressureAngle { get; set; }  //pressure angle in degrees
        double RadialWorkingPressureAngle { get; set; }
        double RadialPressureAngle { get; set; } //radial or transverse pressure angle in degrees
        double HelixAngle { get; set; } // helix angle in degrees
        double RootFilletFactor { get; set; } // root fillet factor 
        double AddendumFilletFactor { get; set; } // tip (addendum) fillet factor 
        string GearType { get; set; }
      
        double CircumferentialBacklash { get; set; } // circular backlash required
        double Delta { get; set; } // distribution of profile shift X between g1, g2
        double WorkingCentreDistance { get; set; } //working centre distance of gear pair - include allowance for profile shifted gears
        double StandardCentreDistance { get; set; }
        double CentreDistanceIncrementFactor { get; set; } // centre distance increment factor for profile shifted gear pair
        double PitchCircleDiameter { get; set; }
  
        double BaseCircleDiameter { get; set; }
        

        double AddendumCircleDiameter { get; set; }
        double DedendumCircleDiameter { get; set; }
        double NormalCoefficientOfProfileShift { get; set; }
        
        double AxialPitch { get; set; }
        double HelixPitchLength { get; set; }
        double HelicalPressureAngle { get; set; }
        double InvoluteFunction { get; set; }
        double TransverseModule { get; set; }
        double RootFilletDiameter { get; set; }
        double TipReliefRadius { get; set; }
        double ContactRatio { get; set; }
       
        double Addendum { get; set; }
        double Dedendum { get; set; }

        double WholeDepth { get; set; }
        double OutsideDiameter { get; set; }
        double RootCircleDiameter { get; set; }
        double Pitch { get; set; }
        string GearString { get; set; }
        
        GearType Type { get; set; }
        double NormalBacklash { get; set; }
        double BacklashAdjustmentFactorXMod { get; set; }
        double Theta { get; set; }
        double Alpha { get; set; }
        event EventHandler Updated;
    }
}