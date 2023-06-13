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
        double InnerOutsideDiameter { get; set; }
        double AxialFaceWidth { get; set; }
        double PitchApexToCrown { get; set; }
        double FaceWidth { get; set; }
        double ConeDistance { get; set; }
        double OutsideDiameter { get; set; }
        double RootConeAngle { get; set; }
        double Addendum { get; set; }
        double Dedendum { get; set; }
        double DedendumAngle { get; set; }
        double AddendumAngle { get; set; }
        double OuterConeAngle { get; set; }
        string Hand { get; set; }
        string StringValue { get; set; }

        string GearType { get; set; }

        event EventHandler Updated;
    }
}