using System;

namespace Bolsover.WormGear.Calculator
{
    public class WormGearCalculator
    {
        #region Worm Gear Calculation methods
        
        public void Calculate()
        {
            // Calculate the pitch of the worm
            Pitch = Math.PI * Module;
            
            // Calculate the lead angle of the worm
            CalculatedLeadAngle = Math.Atan(Module * WormThreads / WormPitchDiameter);
            
            GearPitchDiameter = GearTeeth * Module;
            
            // Calculate the centre distance between the worm and the gear
            EstimatedCentreDistance = (GearTeeth * Module + WormPitchDiameter) / 2;
            
            // Calculate the addendum of the worm
            Addendum = 1.0 * Module;
            
            // Calculate the dedendum of the worm
            Dedendum = 1.25 * Module;
            
            // Calculate the whole depth of the worm
            WholeDepth = 2.25 * Module;
            
            // Calculate the outside diameter of the worm
            WormOutsideDiameter = WormPitchDiameter + 2 * Module;
            
            // Calculate the outside diameter of the gear
            GearOutsideDiameter = GearTeeth * Module + 2 * Module + Module;
            
            // Calculate the root diameter of the worm
            WormRootDiameter = WormPitchDiameter + 2 * Module - 4.5 * Module;
            
            // Calculate the root diameter of the gear
            GearRootDiameter = GearTeeth * Module + 2 * Module - 4.5 * Module;
            
            // Calculate the throat diameter of the worm
            ThroatDiameter = GearTeeth * Module + 2 * Module;
            
            // Calculate the throat surface radius of the worm
            ThroatSurfaceRadius = WormPitchDiameter / 2 - 1.0 * Module;
            
            // Calculate the worm length
            WormLength = Math.PI * Module * (4.5 + 0.02 * GearTeeth);
            
            // Calculate the gear blank width
            GearBlankWidth = 2 * Module * Math.Sqrt(WormPitchDiameter / Module + 1);
            
            WormEstimatedPitchDiameter1 = 2.4 * Math.PI * Module + 1.1;
            WormEstimatedPitchDiameter2 = 2 * DesiredCentreDistance - GearTeeth * Module;
        }
        
        #endregion
        
        #region Worm Gear Calculation inputs
        
        public double WormPitchDiameter { get; set; }
        public double WormThreads { get; set; }
        public double Module { get; set; }
        
        public double PressureAngle { get; set; }
        public double GearTeeth { get; set; }
        
        public double DesiredCentreDistance { get; set; }
        
        public double DesiredLeadAngle { get; set; }
        
        #endregion
        
        
        #region Worm Gear Calculation outputs
        
        public double CalculatedLeadAngle { get; set; }
        public double Pitch { get; set; }
        public double EstimatedCentreDistance { get; set; }
        
        public double Addendum { get; set; }
        public double Dedendum { get; set; }
        public double WholeDepth { get; set; }
        public double GearPitchDiameter { get; set; }
        public double WormOutsideDiameter { get; set; }
        public double GearOutsideDiameter { get; set; }
        public double WormRootDiameter { get; set; }
        public double GearRootDiameter { get; set; }
        public double ThroatDiameter { get; set; }
        public double ThroatSurfaceRadius { get; set; }
        public double WormLength { get; set; }
        public double GearBlankWidth { get; set; }
        
        public double WormEstimatedPitchDiameter1 { get; set; }
        public double WormEstimatedPitchDiameter2 { get; set; }
        
        #endregion
    }
}