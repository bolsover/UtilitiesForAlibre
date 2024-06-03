using System;
using Bolsover.Involute.Model;

namespace Bolsover.WormGear.Model
{
    public class WormGearDesignOutputParams : IGearDesignOutputParams
    {
        public IGearDesignInputParams GearDesignInputParams { get; set; }
        public double RadialWorkingPressureAngle { get; set; }
        public double RadialPressureAngle { get; set; }
        public double PitchCircleDiameter { get; set; }
        public double BaseCircleDiameter { get; set; }
        public double NormalCoefficientOfProfileShift { get; set; }
        public double AxialPitch { get; set; }
        public double HelixPitchLength { get; set; }
        public double HelicalPressureAngle { get; set; }
        public double RadialModule { get; set; }
        public double RootFilletDiameter { get; set; }
        public double RootFilletRadius { get; set; }
        public double TipReliefRadius { get; set; }
        public double Addendum { get; set; }
        public double Dedendum { get; set; }
        public double WholeDepth { get; set; }
        public double OutsideDiameter { get; set; }
        public double RootCircleDiameter { get; set; }
        public double Pitch { get; set; }
        public string GearString { get; set; }
        public double BacklashAdjustmentFactorXMod { get; set; }
        public double WorkingPitchDiameter { get; set; }
        
        public void Reset()
        {
            throw new NotImplementedException();
        }
        
        public double SumCoefficientOfProfileShift { get; set; }
        public double DifferenceCoefficientOfProfileShift { get; set; }
        public double CentreDistanceIncrementFactor { get; set; }
        public double CentreDistance { get; set; }
        public bool Auto { get; set; }
        public double WorkingInvoluteFunction { get; set; }
        public double RadialInvoluteFunction { get; set; }
        public double RadialWorkingInvoluteFunction { get; set; }
        public double InvoluteFunction { get; set; }
        public double WorkingPressureAngle { get; set; }
        public double ContactRatioAlpha { get; set; }
        public double ContactRatioBeta { get; set; }
        public double ContactRatioGamma { get; set; }
        public double Phi { get; set; }
        public double Theta { get; set; }
        public double Kappa { get; set; }
        public double HalfToothAngle { get; set; }
        public double ToothAngle { get; set; }
        public double OuterRingDiameter { get; set; }
    }
}