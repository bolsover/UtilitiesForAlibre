using System;
using Bolsover.Bevel.Models;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Bevel.Calculator
{
    public static class BevelGearCalculator
    {
        public static double CalculateStandardPinionPitchDiameter(IBevelGear pinion)
        {
            return pinion.NumberOfTeeth * pinion.Module;
        }

        public static double CalculateStandardGearPitchDiameter(IBevelGear gear)
        {
            return gear.NumberOfTeeth * gear.Module;
        }




        

  
        public static double CalculateStandardPinionPitchConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var ratio = gear.NumberOfTeeth / pinion.NumberOfTeeth;
            var cosSigma = Math.Cos(Radians(pinion.ShaftAngle));
            var sinSigma = Math.Sin(Radians(pinion.ShaftAngle));
            var result = Math.Atan(sinSigma / (ratio + cosSigma));
            return Degrees(result);
        }

        public static double CalculateStandardGearPitchConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var pitchConeAnglePinion = CalculateStandardPinionPitchConeAngle(pinion, gear);

            return gear.ShaftAngle - pitchConeAnglePinion;
        }


        public static double CalculatePinionConeDistance(IBevelGear pinion, IBevelGear gear)
        {
            var d2 = CalculateStandardPinionPitchDiameter(gear);
            var cosDelta2 = Math.Cos(Radians(CalculateStandardPinionPitchConeAngle(pinion, gear)));
            return d2 / (2 * cosDelta2);
        }
        
        public static double CalculateGearConeDistance(IBevelGear pinion, IBevelGear gear)
        {
            var d2 = CalculateStandardGearPitchDiameter(gear);
            var cosDelta2 = Math.Cos(Radians(CalculateStandardGearPitchConeAngle(pinion, gear)));
            return d2 / (2 * cosDelta2);
        }
        
        public static double CalculateStandardGearBackConeDistance(IBevelGear pinion, IBevelGear gear)
        {
            var d2 = CalculateStandardGearPitchDiameter(gear);
            var tanDelta2 = Math.Tan(Radians( CalculateStandardPinionPitchConeAngle(pinion, gear)));
            return (d2/2)  / tanDelta2;
        }
        
        public static double CalculateStandardPinionBackConeDistance(IBevelGear pinion, IBevelGear gear)
        {
            var d2 = CalculateStandardPinionPitchDiameter(pinion);
            var tanDelta2 = Math.Tan(Radians(CalculateStandardGearPitchConeAngle(pinion, gear)));
            return (d2/2)  / tanDelta2;
        }
        
        public static double CalculateStandardPinionBackConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var result =  90 - CalculateStandardPinionPitchConeAngle(pinion, gear);
            return result;
        }

     

        public static double CalculateStandardPinionAddendum(IBevelGear pinion)
        {
            return 1.0 * pinion.Module;
        }

        public static double CalculateStandardGearAddendum(IBevelGear gear)
        {
            return 1.0 * gear.Module;
        }

        public static double CalculateStandardPinionDedendum(IBevelGear pinion)
        {
            return 1.25 * pinion.Module;
        }

        public static double CalculateStandardGearDedendum(IBevelGear gear)
        {
            return 1.25 * gear.Module;
        }

     

        public static double CalculateStandardPinionDedendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var dedendum = CalculateStandardPinionDedendum(pinion);
            var coneDistance = CalculatePinionConeDistance(pinion, gear);
            var result = Degrees(Math.Atan(dedendum / coneDistance));
            return result;
        }

        public static double CalculateStandardGearDedendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var dedendum = CalculateStandardGearDedendum(gear);
            var coneDistance = CalculateGearConeDistance(pinion, gear);
            var result = Degrees(Math.Atan(dedendum / coneDistance));
            return result;
        }

       

        public static double CalculateStandardPinionAddendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var addedendum = CalculateStandardPinionAddendum(pinion);
            var coneDistance = CalculatePinionConeDistance(pinion, gear);
            var result = Degrees(Math.Atan(addedendum / coneDistance));
            return result;
        }

        public static double CalculateStandardGearAddendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var addedendum = CalculateStandardGearAddendum(gear);
            var coneDistance = CalculateGearConeDistance(pinion, gear);
            var result = Degrees(Math.Atan(addedendum / coneDistance));
            return result;
        }

      

        public static double CalculateStandardGearOuterConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateStandardGearPitchConeAngle(pinion, gear);
            var thetaa = CalculateStandardGearAddendumAngle(pinion, gear);
            return delta + thetaa;
        }

        public static double CalculateStandardPinionOuterConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateStandardPinionPitchConeAngle(pinion, gear);
            var thetaa = CalculateStandardPinionAddendumAngle(pinion, gear);
            return delta + thetaa;
        }

        public static double CalculateStandardGearRootConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateStandardGearPitchConeAngle(pinion, gear);
            var thetaf = CalculateStandardGearDedendumAngle(pinion, gear);
            return delta - thetaf;
        }

        public static double CalculateStandardPinionRootConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateStandardPinionPitchConeAngle(pinion, gear);
            var thetaf = CalculateStandardPinionDedendumAngle(pinion, gear);
            return delta - thetaf;
        }

     

        public static double CalculateStandardPinionPitchApexToCrown(IBevelGear pinion, IBevelGear gear)
        {
            var coneDistance = CalculatePinionConeDistance(pinion, gear);
            var pinionAddendum = CalculateStandardPinionAddendum(pinion);
            var pinionPitchConeAngle = CalculateStandardPinionPitchConeAngle(pinion, gear);
            var result = coneDistance * Math.Cos(Radians(pinionPitchConeAngle)) -
                         pinionAddendum * Math.Sin(Radians(pinionPitchConeAngle));
            return result;
        }

        public static double CalculateStandardGearPitchApexToCrown(IBevelGear pinion, IBevelGear gear)
        {
            var coneDistance = CalculateGearConeDistance(pinion, gear);
            var gearAddendum = CalculateStandardGearAddendum(gear);
            var gearPitchConeAngle = CalculateStandardGearPitchConeAngle(pinion, gear);
            var result = coneDistance * Math.Cos(Radians(gearPitchConeAngle)) -
                         gearAddendum * Math.Sin(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateStandardPinionAxialFaceWidth(IBevelGear pinion, IBevelGear gear)
        {
            var outerConeAngle = CalculateStandardPinionOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateStandardPinionAddendumAngle(pinion, gear);
            var result = pinion.FaceWidth * Math.Cos(Radians(outerConeAngle)) / Math.Cos(Radians(addendumAngle));
            return result;
        }

        public static double CalculateStandardGearAxialFaceWidth(IBevelGear pinion, IBevelGear gear)
        {
            var outerConeAngle = CalculateStandardGearOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateStandardGearAddendumAngle(pinion, gear);
            var result = gear.FaceWidth * Math.Cos(Radians(outerConeAngle)) / Math.Cos(Radians(addendumAngle));
            return result;
        }

      

        public static double CalculateStandardGearOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateStandardGearPitchDiameter(gear);
            var addendum = CalculateStandardGearAddendum(gear);
            var gearPitchConeAngle = CalculateStandardGearPitchConeAngle(pinion, gear);
            var result = pitchDiameter + 2 * addendum * Math.Cos(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateStandardPinionOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateStandardPinionPitchDiameter(pinion);
            var addendum = CalculateStandardPinionAddendum(pinion);
            var gearPitchConeAngle = CalculateStandardPinionPitchConeAngle(pinion, gear);
            var result = pitchDiameter + 2 * addendum * Math.Cos(Radians(gearPitchConeAngle));
            return result;
        }

      

        public static double CalculateStandardPinionInnerOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var outsideDiameter = CalculateStandardPinionOutsideDiameter(pinion, gear);
            var outerConeAngle = CalculateStandardPinionOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateStandardPinionAddendumAngle(pinion, gear);
            var result = outsideDiameter - 2 * pinion.FaceWidth * Math.Sin(Radians(outerConeAngle)) /
                Math.Cos(Radians(addendumAngle));
            return result;
        }

        public static double CalculateStandardGearInnerOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var outsideDiameter = CalculateStandardGearOutsideDiameter(pinion, gear);
            var outerConeAngle = CalculateStandardGearOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateStandardGearAddendumAngle(pinion, gear);
            var result = outsideDiameter - 2 * pinion.FaceWidth * Math.Sin(Radians(outerConeAngle)) /
                Math.Cos(Radians(addendumAngle));
            return result;
        }

        public static double CalculateTredgoldPinionEquivalentPitchDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateStandardPinionPitchDiameter(pinion);
            var pitchConeAngle = CalculateStandardPinionPitchConeAngle(pinion, gear);
            var result = pitchDiameter / Math.Cos(Radians(pitchConeAngle));
            return result;
        }
        
        public static double CalculateTredgoldPinionEquivalentBaseDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateTredgoldPinionEquivalentPitchDiameter(pinion, gear);
            var alpha = pinion.PressureAngle; // Pressure Angle
            var db = pitchDiameter * Math.Cos(Radians(alpha)); // Base Diameter of Pinion
            
            return db;
        }
        
        public static double CalculateTredgoldPinionEquivalentAddendumDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateTredgoldPinionEquivalentPitchDiameter(pinion, gear);
            var ha = pinion.Addendum;
            var result = pitchDiameter +(2 * ha);
            return result;
        }
        
        public static double CalculateTredgoldPinionEquivalentRootDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateTredgoldPinionEquivalentPitchDiameter(pinion, gear);
            var hf = pinion.Dedendum;
            var result = pitchDiameter -(2 * hf);
            return result;
        }

        public static double CalculateTredgoldGearEquivalentPitchDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateStandardGearPitchDiameter(gear);
            var pitchConeAngle = CalculateStandardGearPitchConeAngle(pinion, gear);
            var result = pitchDiameter / Math.Cos(Radians(pitchConeAngle));
            return result;
        }
        
        public static double CalculateTredgoldGearEquivalentBaseDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateTredgoldGearEquivalentPitchDiameter(pinion, gear);
            var alpha = gear.PressureAngle; // Pressure Angle
            var db = pitchDiameter * Math.Cos(Radians(alpha)); // Base Diameter of Pinion
            return db;
        }
        
        public static double CalculateTredgoldGearEquivalentAddendumDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateTredgoldGearEquivalentPitchDiameter(pinion, gear);
            var ha = gear.Addendum;
            var result = pitchDiameter +(2 * ha);
            return result;
        }
        
        public static double CalculateTredgoldGearEquivalentRootDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateTredgoldGearEquivalentPitchDiameter(pinion, gear);
            var hf = gear.Dedendum;
            var result = pitchDiameter -(2 * hf);
            return result;
        }

        public static double CalculateTredgoldPinionEquivalentToothCount(IBevelGear pinion, IBevelGear gear)
        {
            var equivalentPitchDiameter = CalculateTredgoldPinionEquivalentPitchDiameter(pinion, gear);

            var result = equivalentPitchDiameter / pinion.Module;
            return result;
        }

        public static double CalculateTredgoldGearEquivalentToothCount(IBevelGear pinion, IBevelGear gear)
        {
            var equivalentPitchDiameter = CalculateTredgoldGearEquivalentPitchDiameter(pinion, gear);

            var result = equivalentPitchDiameter / pinion.Module;
            return result;
        }

        public static double CalculatePinionRadialPressureAngle(IBevelGear pinion, IBevelGear gear)
        {
            var tanAlphaN = Math.Tan(Radians(pinion.PressureAngle));
            var cosBetaM = Math.Cos(Radians(pinion.SpiralAngle));


            var result = Degrees(Math.Atan(tanAlphaN / cosBetaM));
            return result;
        }

        public static double CalculateGearRadialPressureAngle(IBevelGear pinion, IBevelGear gear)
        {
            var tanAlphaN = Math.Tan(Radians(gear.PressureAngle));
            var cosBetaM = Math.Cos(Radians(gear.SpiralAngle));


            var result = Degrees(Math.Atan(tanAlphaN / cosBetaM));
            return result;
        }
    }
}