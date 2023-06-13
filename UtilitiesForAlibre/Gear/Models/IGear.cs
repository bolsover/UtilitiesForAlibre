namespace Bolsover.Gear.Models
{
    public interface IGear
    {
        double Module { get; set; } // normal module
        double NumberOfTeeth { get; set; } // teeth
        double PressureAngle { get; set; } //pressure angle in degrees
        double WorkingPressureAngle { get; set; }
        double HelixAngle { get; set; } // helix angle in degrees
        double RootFilletFactor { get; set; } // root fillet factor 
        double AddendumFilletFactor { get; set; } // tip (addendum) fillet factor 
        string GearType { get; set; }
        double CircularBacklash { get; set; } // circular backlash required
        double Delta { get; set; } // distribution of profile shift X between g1, g2
        double WorkingCentreDistance { get; set; } //working centre distance
        double StandardCentreDistance { get; set; }
        double CentreDistanceIncrementFactor { get; set; }
        double PitchDiameter { get; set; }
        double WorkingPitchDiameter { get; set; }
        double BaseCircleDiameter { get; set; }
        double RootCircleDiameter { get; set; }
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
    }
}