namespace Bolsover.Involute.Model
{
    public interface IGearDesignOutputParams
    {
        IGearDesignInputParams GearDesignInputParams { get; set; }
        double RadialWorkingPressureAngle { get; set; }
        double RadialPressureAngle { get; set; } //radial or transverse pressure angle in degrees

        double PitchCircleDiameter { get; set; }
        double BaseCircleDiameter { get; set; }

        double NormalCoefficientOfProfileShift { get; set; }
        double AxialPitch { get; set; }
        double HelixPitchLength { get; set; }
        double HelicalPressureAngle { get; set; }

        double RadialModule { get; set; }
        double RootFilletDiameter { get; set; }
        
        double RootFilletRadius { get; set; }
        double TipReliefRadius { get; set; }

        double Addendum { get; set; }
        double Dedendum { get; set; }
        double WholeDepth { get; set; }
        double OutsideDiameter { get; set; }
        double RootCircleDiameter { get; set; }
        double Pitch { get; set; }
        string GearString { get; set; }
        double BacklashAdjustmentFactorXMod { get; set; }

        double WorkingPitchDiameter { get; set; }

        void Reset();

        double SumCoefficientOfProfileShift { get; set; }

        double DifferenceCoefficientOfProfileShift { get; set; }

        double CentreDistanceIncrementFactor { get; set; }

        double CentreDistance { get; set; }
        bool Auto { get; set; }

        double WorkingInvoluteFunction { get; set; }

        double RadialInvoluteFunction { get; set; }

        double RadialWorkingInvoluteFunction { get; set; }

        double InvoluteFunction { get; set; }

        double WorkingPressureAngle { get; set; }

        double ContactRatioAlpha { get; set; }

        double ContactRatioBeta { get; set; }

        double ContactRatioGamma { get; set; }
        
        double Phi { get; set; }
        
        double Theta { get; set; }
        
        double Kappa { get; set; } // also the rotate degrees
        
        double HalfToothAngle { get; set; }
        
        double ToothAngle { get; set; }
        
        double OuterRingDiameter { get; set; } // outer diameter of internal gear`
    }
}