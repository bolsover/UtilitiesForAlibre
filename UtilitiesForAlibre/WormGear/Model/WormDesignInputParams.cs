using System;
using Bolsover.Involute.Model;

namespace Bolsover.WormGear.Model
{
    public class WormDesignInputParams : IGearDesignInputParams
    
    {
        public double Height { get; set; }
        public double Module { get; set; }
        public double Teeth { get; set; }
        public double PressureAngle { get; set; }
        public double HelixAngle { get; set; }
        public double RootFilletFactor { get; set; }
        public double AddendumFilletFactor { get; set; }
        public double CircularBacklash { get; set; }
        public double CoefficientOfProfileShift { get; set; }
        public double WormPitchDiameter { get; set; }
        public double HeightOfPitchLine { get; set; }
        public GearStyle Style { get; set; }
        public IGearPairDesignInputParams GearPairDesign { get; set; }
        
        public void SetDefaults()
        {
            throw new NotImplementedException();
        }
        
        public event GearChangedEventHandler GearChanged;
    }
}