using System;

namespace Bolsover.Bevel.Models
{
    public interface IBevelGear
    {
        double Module { get; set; }
        double ShaftAngle { get; set; }
        double PressureAngle { get; set; }
        double SpiralAngle { get; set; }
        double RadialPressureAngle { get; set; }
        double NumberOfTeeth { get; set; }
        double PitchConeAngle { get; set; }
        double PitchDiameter { get; set; }
        double BaseDiameter { get; set; }
        double RootDiameter { get; set; }
         double OutsideDiameter { get; set; }
        double InnerOutsideDiameter { get; set; }
        double AxialFaceWidth { get; set; }
        double PitchApexToCrown { get; set; }
        double FaceWidth { get; set; }
        double ConeDistance { get; set; }
        double RootConeAngle { get; set; }
        double Addendum { get; set; }
        double Dedendum { get; set; }
        double DedendumAngle { get; set; }
        double AddendumAngle { get; set; }
        double OuterConeAngle { get; set; }
        string Hand { get; set; }
        string StringValue { get; set; }
        double EquivalentPitchDiameter { get; set; }
        double EquivalentBaseDiameter { get; set; }
        double EquivalentRootDiameter { get; set; }
        double EquivalentAddendumDiameter { get; set; }
        double BackConeDistance { get; set; }
        double BackConeAngle { get; set; }
        
        double KFactor { get; set; }
        double CircularThicknessDegrees { get; set; }
        double InterToothDegrees { get; set; }

        BevelGearType GearType { get; set; }

        event EventHandler Updated;
    }
}