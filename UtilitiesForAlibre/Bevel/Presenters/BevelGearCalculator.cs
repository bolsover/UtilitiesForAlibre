using System;
using Bolsover.Bevel.Models;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Bevel.Presenters
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

        public static double CalculateGleasonPinionPitchDiameter(IBevelGear pinion)
        {
            return CalculateStandardPinionPitchDiameter(pinion);
        }

        public static double CalculateGleasonGearPitchDiameter(IBevelGear gear)
        {
            return CalculateStandardGearPitchDiameter(gear);
        }


        public static double CalculateStandardPinionPitchConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var ratio = gear.NumberOfTeeth / pinion.NumberOfTeeth;
            var cosSigma = Math.Cos(Radians(pinion.ShaftAngle));
            var sinSigma = Math.Sin(Radians(pinion.ShaftAngle));
            var result = Math.Atan(sinSigma / (ratio + cosSigma));
            return Degrees(result);
        }

        public static double CalculateGleasonPinionPitchConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            return CalculateStandardPinionPitchConeAngle(pinion, gear);
        }

        public static double CalculateStandardGearPitchConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var pitchConeAnglePinion = CalculateStandardPinionPitchConeAngle(pinion, gear);

            return gear.ShaftAngle - pitchConeAnglePinion;
        }

        public static double CalculateGleasonGearPitchConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var pitchConeAnglePinion = CalculateGleasonPinionPitchConeAngle(pinion, gear);

            return gear.ShaftAngle - pitchConeAnglePinion;
        }

        public static double CalculateGleasonSpiralGearPitchConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var pitchConeAnglePinion = CalculateGleasonPinionPitchConeAngle(pinion, gear);

            return gear.ShaftAngle - pitchConeAnglePinion;
        }

        public static double CalculateGleasonSpiralPinionPitchConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var pitchConeAnglePinion = CalculateGleasonGearPitchConeAngle(pinion, gear);

            return gear.ShaftAngle - pitchConeAnglePinion;
        }

        public static double CalculateConeDistance(IBevelGear pinion, IBevelGear gear)
        {
            var d2 = CalculateStandardPinionPitchDiameter(gear);
            var sinDelta2 = Math.Sin(Radians(CalculateStandardGearPitchConeAngle(pinion, gear)));
            return d2 / (2 * sinDelta2);
        }

        public static double CalculateGleasonGearAddendum(IBevelGear pinion, IBevelGear gear)
        {
            var m540 = gear.Module * 0.540;
            var m460 = gear.Module * 0.460;
            var z2CosDelta1 = gear.NumberOfTeeth * Math.Cos(Radians(CalculateGleasonPinionPitchConeAngle(pinion, gear)));
            var z1CosDelta2 = pinion.NumberOfTeeth * Math.Cos(Radians(CalculateGleasonGearPitchConeAngle(pinion, gear)));
            var result = m540 + (m460 / (z2CosDelta1 / z1CosDelta2));
            return result;
        }

        public static double CalculateGleasonSpiralGearAddendum(IBevelGear pinion, IBevelGear gear)
        {
            var m460 = gear.Module * 0.460;
            var m390 = gear.Module * 0.390;
            var z2CosDelta1 = gear.NumberOfTeeth * Math.Cos(Radians(CalculateGleasonPinionPitchConeAngle(pinion, gear)));
            var z1CosDelta2 = pinion.NumberOfTeeth * Math.Cos(Radians(CalculateGleasonGearPitchConeAngle(pinion, gear)));
            var result = m460 + (m390 / (z2CosDelta1 / z1CosDelta2));
            return result;
        }

        public static double CalculateGleasonSpiralPinionAddendum(IBevelGear pinion, IBevelGear gear)
        {
            return 1.7 * pinion.Module - CalculateGleasonSpiralGearAddendum(pinion, gear);
        }

        public static double CalculateGleasonSpiralGearDedendum(IBevelGear pinion, IBevelGear gear)
        {
            return 1.888 * gear.Module - CalculateGleasonSpiralGearAddendum(pinion, gear);
        }

        public static double CalculateGleasonSpiralPinionDedendum(IBevelGear pinion, IBevelGear gear)
        {
            return 1.888 * pinion.Module - CalculateGleasonSpiralPinionAddendum(pinion, gear);
        }

        public static double CalculateGleasonPinionAddendum(IBevelGear pinion, IBevelGear gear)
        {
            return 2.0 * pinion.Module - CalculateGleasonGearAddendum(pinion, gear);
        }

        public static double CalculateStandardPinionAddendum(IBevelGear pinion, IBevelGear gear)
        {
            return 1.0 * pinion.Module;
        }

        public static double CalculateStandardGearAddendum(IBevelGear pinion, IBevelGear gear)
        {
            return 1.0 * gear.Module;
        }

        public static double CalculateStandardPinionDedendum(IBevelGear pinion, IBevelGear gear)
        {
            return 1.25 * pinion.Module;
        }

        public static double CalculateStandardGearDedendum(IBevelGear pinion, IBevelGear gear)
        {
            return 1.25 * gear.Module;
        }

        public static double CalculateGleasonPinionDedendum(IBevelGear pinion, IBevelGear gear)
        {
            return (2.188 * pinion.Module) - CalculateGleasonPinionAddendum(pinion, gear);
        }

        public static double CalculateGleasonGearDedendum(IBevelGear pinion, IBevelGear gear)
        {
            return (2.188 * gear.Module) - CalculateGleasonGearAddendum(pinion, gear);
        }


        public static double CalculateGleasonPinionDedendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var dedendum = CalculateGleasonPinionDedendum(pinion, gear);
            var coneDistance = CalculateConeDistance(pinion, gear);
            var result = Degrees(Math.Atan(dedendum / coneDistance));
            return result;
        }

        public static double CalculateGleasonSpiralPinionDedendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var dedendum = CalculateGleasonSpiralPinionDedendum(pinion, gear);
            var coneDistance = CalculateConeDistance(pinion, gear);
            var result = Degrees(Math.Atan(dedendum / coneDistance));
            return result;
        }

        public static double CalculateGleasonSpiralGearDedendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var dedendum = CalculateGleasonSpiralGearDedendum(pinion, gear);
            var coneDistance = CalculateConeDistance(pinion, gear);
            var result = Degrees(Math.Atan(dedendum / coneDistance));
            return result;
        }

        public static double CalculateGleasonGearDedendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var dedendum = CalculateGleasonGearDedendum(pinion, gear);
            var coneDistance = CalculateConeDistance(pinion, gear);
            var result = Degrees(Math.Atan(dedendum / coneDistance));
            return result;
        }

        public static double CalculateStandardPinionDedendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var dedendum = CalculateStandardPinionDedendum(pinion, gear);
            var coneDistance = CalculateConeDistance(pinion, gear);
            var result = Degrees(Math.Atan(dedendum / coneDistance));
            return result;
        }

        public static double CalculateStandardGearDedendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            return CalculateStandardPinionDedendumAngle(pinion, gear);
        }

        public static double CalculateGleasonPinionAddendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            return CalculateGleasonGearDedendumAngle(pinion, gear);
        }

        public static double CalculateGleasonSpiralPinionAddendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            return CalculateGleasonSpiralGearDedendumAngle(pinion, gear);
        }

        public static double CalculateGleasonSpiralGearAddendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            return CalculateGleasonSpiralPinionDedendumAngle(pinion, gear);
        }

        public static double CalculateGleasonGearAddendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            return CalculateGleasonPinionDedendumAngle(pinion, gear);
        }

        public static double CalculateStandardPinionAddendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var addedendum = CalculateStandardPinionAddendum(pinion, gear);
            var coneDistance = CalculateConeDistance(pinion, gear);
            var result = Degrees(Math.Atan(addedendum / coneDistance));
            return result;
        }

        public static double CalculateStandardGearAddendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            return CalculateStandardPinionAddendumAngle(pinion, gear);
        }

        public static double CalculateGleasonGearOuterConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateGleasonGearPitchConeAngle(pinion, gear);
            var thetaa = CalculateGleasonGearAddendumAngle(pinion, gear);
            return delta + thetaa;
        }

        public static double CalculateGleasonSpiralGearOuterConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateGleasonGearPitchConeAngle(pinion, gear);
            var thetaa = CalculateGleasonSpiralGearAddendumAngle(pinion, gear);
            return delta + thetaa;
        }

        public static double CalculateGleasonPinionOuterConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateGleasonPinionPitchConeAngle(pinion, gear);
            var thetaa = CalculateGleasonPinionAddendumAngle(pinion, gear);
            return delta + thetaa;
        }

        public static double CalculateGleasonSpiralPinionOuterConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateGleasonPinionPitchConeAngle(pinion, gear);
            var thetaa = CalculateGleasonSpiralPinionAddendumAngle(pinion, gear);
            return delta + thetaa;
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

        public static double CalculateGleasonGearRootConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateGleasonGearPitchConeAngle(pinion, gear);
            var thetaf = CalculateGleasonGearDedendumAngle(pinion, gear);
            return delta - thetaf;
        }

        public static double CalculateGleasonSpiralGearRootConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateGleasonSpiralGearPitchConeAngle(pinion, gear);
            var thetaf = CalculateGleasonSpiralGearDedendumAngle(pinion, gear);
            return delta - thetaf;
        }

        public static double CalculateGleasonSpiralPinionRootConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateGleasonSpiralPinionPitchConeAngle(pinion, gear);
            var thetaf = CalculateGleasonSpiralPinionDedendumAngle(pinion, gear);
            return delta - thetaf;
        }

        public static double CalculateGleasonPinionRootConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculateGleasonPinionPitchConeAngle(pinion, gear);
            var thetaf = CalculateGleasonPinionDedendumAngle(pinion, gear);
            return delta - thetaf;
        }

        public static double CalculateGleasonPinionPitchApexToCrown(IBevelGear pinion, IBevelGear gear)
        {
            var coneDistance = CalculateConeDistance(pinion, gear);
            var pinionAddendum = CalculateGleasonPinionAddendum(pinion, gear);
            var pinionPitchConeAngle = CalculateGleasonPinionPitchConeAngle(pinion, gear);
            var result = coneDistance * Math.Cos(Radians(pinionPitchConeAngle)) -
                         pinionAddendum * Math.Sin(Radians(pinionPitchConeAngle));
            return result;
        }

        public static double CalculateGleasonGearPitchApexToCrown(IBevelGear pinion, IBevelGear gear)
        {
            var coneDistance = CalculateConeDistance(pinion, gear);
            var gearAddendum = CalculateGleasonGearAddendum(pinion, gear);
            var gearPitchConeAngle = CalculateGleasonGearPitchConeAngle(pinion, gear);
            var result = coneDistance * Math.Cos(Radians(gearPitchConeAngle)) -
                         gearAddendum * Math.Sin(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateGleasonSpiralGearPitchApexToCrown(IBevelGear pinion, IBevelGear gear)
        {
            var coneDistance = CalculateConeDistance(pinion, gear);
            var gearAddendum = CalculateGleasonSpiralGearAddendum(pinion, gear);
            var gearPitchConeAngle = CalculateGleasonSpiralGearPitchConeAngle(pinion, gear);
            var result = coneDistance * Math.Cos(Radians(gearPitchConeAngle)) -
                         gearAddendum * Math.Sin(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateGleasonSpiralPinionPitchApexToCrown(IBevelGear pinion, IBevelGear gear)
        {
            var coneDistance = CalculateConeDistance(pinion, gear);
            var gearAddendum = CalculateGleasonSpiralPinionAddendum(pinion, gear);
            var gearPitchConeAngle = CalculateGleasonSpiralPinionPitchConeAngle(pinion, gear);
            var result = coneDistance * Math.Cos(Radians(gearPitchConeAngle)) -
                         gearAddendum * Math.Sin(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateStandardPinionPitchApexToCrown(IBevelGear pinion, IBevelGear gear)
        {
            var coneDistance = CalculateConeDistance(pinion, gear);
            var pinionAddendum = CalculateStandardPinionAddendum(pinion, gear);
            var pinionPitchConeAngle = CalculateStandardPinionPitchConeAngle(pinion, gear);
            var result = coneDistance * Math.Cos(Radians(pinionPitchConeAngle)) -
                         pinionAddendum * Math.Sin(Radians(pinionPitchConeAngle));
            return result;
        }

        public static double CalculateStandardGearPitchApexToCrown(IBevelGear pinion, IBevelGear gear)
        {
            var coneDistance = CalculateConeDistance(pinion, gear);
            var gearAddendum = CalculateStandardGearAddendum(pinion, gear);
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

        public static double CalculateGleasonPinionAxialFaceWidth(IBevelGear pinion, IBevelGear gear)
        {
            var outerConeAngle = CalculateGleasonPinionOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateGleasonPinionAddendumAngle(pinion, gear);
            var result = pinion.FaceWidth * Math.Cos(Radians(outerConeAngle)) / Math.Cos(Radians(addendumAngle));
            return result;
        }

        public static double CalculateGleasonGearAxialFaceWidth(IBevelGear pinion, IBevelGear gear)
        {
            var outerConeAngle = CalculateGleasonGearOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateGleasonGearAddendumAngle(pinion, gear);
            var result = gear.FaceWidth * Math.Cos(Radians(outerConeAngle)) / Math.Cos(Radians(addendumAngle));
            return result;
        }

        public static double CalculateGleasonSpiralGearAxialFaceWidth(IBevelGear pinion, IBevelGear gear)
        {
            var outerConeAngle = CalculateGleasonSpiralGearOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateGleasonSpiralGearAddendumAngle(pinion, gear);
            var result = gear.FaceWidth * Math.Cos(Radians(outerConeAngle)) / Math.Cos(Radians(addendumAngle));
            return result;
        }

        public static double CalculateGleasonSpiralPinionAxialFaceWidth(IBevelGear pinion, IBevelGear gear)
        {
            var outerConeAngle = CalculateGleasonSpiralPinionOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateGleasonSpiralPinionAddendumAngle(pinion, gear);
            var result = gear.FaceWidth * Math.Cos(Radians(outerConeAngle)) / Math.Cos(Radians(addendumAngle));
            return result;
        }

        public static double CalculateGleasonGearOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateGleasonGearPitchDiameter(gear);
            var addendum = CalculateGleasonGearAddendum(pinion, gear);
            var gearPitchConeAngle = CalculateGleasonGearPitchConeAngle(pinion, gear);
            var result = pitchDiameter + 2 * addendum * Math.Cos(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateGleasonSpiralGearOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateGleasonGearPitchDiameter(gear);
            var addendum = CalculateGleasonSpiralGearAddendum(pinion, gear);
            var gearPitchConeAngle = CalculateGleasonSpiralGearPitchConeAngle(pinion, gear);
            var result = pitchDiameter + 2 * addendum * Math.Cos(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateGleasonSpiralPinionOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateGleasonPinionPitchDiameter(pinion);
            var addendum = CalculateGleasonSpiralPinionAddendum(pinion, gear);
            var gearPitchConeAngle = CalculateGleasonSpiralPinionPitchConeAngle(pinion, gear);
            var result = pitchDiameter + 2 * addendum * Math.Cos(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateGleasonPinionOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateGleasonPinionPitchDiameter(pinion);
            var addendum = CalculateGleasonPinionAddendum(pinion, gear);
            var gearPitchConeAngle = CalculateGleasonPinionPitchConeAngle(pinion, gear);
            var result = pitchDiameter + 2 * addendum * Math.Cos(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateStandardGearOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateStandardGearPitchDiameter(gear);
            var addendum = CalculateStandardGearAddendum(pinion, gear);
            var gearPitchConeAngle = CalculateStandardGearPitchConeAngle(pinion, gear);
            var result = pitchDiameter + 2 * addendum * Math.Cos(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateStandardPinionOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateStandardPinionPitchDiameter(pinion);
            var addendum = CalculateStandardPinionAddendum(pinion, gear);
            var gearPitchConeAngle = CalculateStandardPinionPitchConeAngle(pinion, gear);
            var result = pitchDiameter + 2 * addendum * Math.Cos(Radians(gearPitchConeAngle));
            return result;
        }

        public static double CalculateGleasonPinionInnerOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var outsideDiameter = CalculateGleasonPinionOutsideDiameter(pinion, gear);
            var outerConeAngle = CalculateGleasonPinionOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateGleasonPinionAddendumAngle(pinion, gear);
            var result = outsideDiameter - 2 * pinion.FaceWidth * Math.Sin(Radians(outerConeAngle)) /
                Math.Cos(Radians(addendumAngle));
            return result;
        }

        public static double CalculateGleasonGearInnerOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var outsideDiameter = CalculateGleasonGearOutsideDiameter(pinion, gear);
            var outerConeAngle = CalculateGleasonGearOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateGleasonGearAddendumAngle(pinion, gear);
            var result = outsideDiameter - 2 * pinion.FaceWidth * Math.Sin(Radians(outerConeAngle)) /
                Math.Cos(Radians(addendumAngle));
            return result;
        }

        public static double CalculateGleasonSpiralPinionInnerOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var outsideDiameter = CalculateGleasonSpiralPinionOutsideDiameter(pinion, gear);
            var outerConeAngle = CalculateGleasonSpiralPinionOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateGleasonSpiralPinionAddendumAngle(pinion, gear);
            var result = outsideDiameter - 2 * pinion.FaceWidth * Math.Sin(Radians(outerConeAngle)) /
                Math.Cos(Radians(addendumAngle));
            return result;
        }

        public static double CalculateGleasonSpiralGearInnerOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var outsideDiameter = CalculateGleasonSpiralGearOutsideDiameter(pinion, gear);
            var outerConeAngle = CalculateGleasonSpiralGearOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateGleasonSpiralGearAddendumAngle(pinion, gear);
            var result = outsideDiameter - 2 * pinion.FaceWidth * Math.Sin(Radians(outerConeAngle)) /
                Math.Cos(Radians(addendumAngle));
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

        public static double CalculateTredgoldGearEquivalentPitchDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateStandardGearPitchDiameter(gear);
            var pitchConeAngle = CalculateStandardGearPitchConeAngle(pinion, gear);
            var result = pitchDiameter / Math.Cos(Radians(pitchConeAngle));
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
            return CalculatePinionRadialPressureAngle(pinion, gear);
        }
    }
}