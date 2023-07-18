using System;

namespace Bolsover.Gear.Models
{
    public interface IGear
    {
        double NormalModule { get; set; } // normal module
        
        double NumberOfTeeth { get; set; } // teeth
        double NormalPressureAngle { get; set; }  //pressure angle in degrees
        double RadialWorkingPressureAngle { get; set; }
        double RadialPressureAngle { get; set; } //radial or transverse pressure angle in degrees
        double HelixAngle { get; set; } // helix angle in degrees
        double RootFilletFactor { get; set; } // root fillet factor 
        double AddendumFilletFactor { get; set; } // tip (addendum) fillet factor 
        string GearType { get; set; }
        double CircularBacklash { get; set; } // circular backlash required
        double Delta { get; set; } // distribution of profile shift X between g1, g2
        double WorkingCentreDistance { get; set; } //working centre distance of gear pair - include allowance for profile shifted gears
        double StandardCentreDistance { get; set; }
        double CentreDistanceIncrementFactor { get; set; } // centre distance increment factor for profile shifted gear pair
        double PitchDiameter { get; set; }
        double WorkingPitchDiameter { get; set; }
        double BaseCircleDiameter { get; set; }
        double ProfileShift { get; set; }

        double AddendumCircleDiameter { get; set; }
        double DedendumCircleDiameter { get; set; }
        double CoefficientOfProfileShift { get; set; }
        double AxialPitch { get; set; }
        double HelixPitchLength { get; set; }
        double HelicalPressureAngle { get; set; }
        double InvoluteFunction { get; set; }
        double TransverseModule { get; set; }
        double RootFilletDiameter { get; set; }
        double TipReliefRadius { get; set; }
        double ContactRatio { get; set; }
        double BaseDiameter { get; set; }
        double Addendum { get; set; }
        double Dedendum { get; set; }

        double WholeDepth { get; set; }
        double OutsideDiameter { get; set; }
        double RootDiameter { get; set; }
        
        // double CentreDistance { get; set; }

        
        string GearString { get; set; }
        event EventHandler Updated;
    }
}