using System;
using Bolsover.Bevel.Models;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Bevel.Calculator
{
    public static class BevelGearCalculator
    {
        public static (double, double) CalculatePitchDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var d1 = pinion.NumberOfTeeth * pinion.Module;
            var d2 = gear.NumberOfTeeth * pinion.Module;
            return (d1, d2);
        }


        public static (double, double) CalculatePitchConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var ratio1 = gear.NumberOfTeeth / pinion.NumberOfTeeth;
            var cosSigma1 = Math.Cos(Radians(pinion.ShaftAngle));
            var sinSigma1 = Math.Sin(Radians(pinion.ShaftAngle));
            var pitchConeAnglePinion = Degrees(Math.Atan(sinSigma1 / (ratio1 + cosSigma1)));
            var pitchConeAngleGear = pinion.ShaftAngle - pitchConeAnglePinion;
            return (pitchConeAnglePinion, pitchConeAngleGear);
        }


        public static (double, double) CalculatePitchConeDistance(IBevelGear pinion, IBevelGear gear)
        {
            var d = CalculatePitchDiameter(pinion, gear);
            var delta = CalculatePitchConeAngle(pinion, gear);
            var cd1 = d.Item1 / (2 * Math.Sin(Radians(delta.Item1)));
            var cd2 = d.Item2 / (2 * Math.Sin(Radians(delta.Item2)));
            return (cd1, cd2);
        }


        public static (double, double) CalculateBackConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var a = CalculatePitchConeAngle(pinion, gear);
            return (90 - a.Item1, 90 - a.Item2);
        }


        public static (double, double) CalculateAddendum(IBevelGear pinion, IBevelGear gear)
        {
            return gear.GearType switch
            {
                BevelGearType.Standard => CalculateStandardAddendum(pinion, gear),
                BevelGearType.Gleason => CalculateGleasonAddendum(pinion, gear),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static (double, double) CalculateDedendum(IBevelGear pinion, IBevelGear gear)
        {
            return gear.GearType switch
            {
                BevelGearType.Standard => CalculateStandardDedendum(pinion, gear),
                BevelGearType.Gleason => CalculateGleasonDedendum(pinion, gear),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static (double, double) CalculateStandardAddendum(IBevelGear pinion, IBevelGear gear)
        {
            var ha1 = 1.0 * pinion.Module;
            var ha2 = 1.0 * gear.Module;
            return (ha1, ha2);
        }

        private static (double, double) CalculateStandardDedendum(IBevelGear pinion, IBevelGear gear)
        {
            var hf1 = 1.25 * pinion.Module;
            var hf2 = 1.25 * gear.Module;
            return (hf1, hf2);
        }

        private static (double, double) CalculateGleasonAddendum(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculatePitchConeAngle(pinion, gear);
            var cosDelta1 = Math.Cos(Radians(delta.Item1));
            var cosDelta2 = Math.Cos(Radians(delta.Item2));
            var z1 = pinion.NumberOfTeeth;
            var z2 = gear.NumberOfTeeth;
            var ha2 = 0.54 * gear.Module + (0.46 * gear.Module / ((z2 * cosDelta1) / (z1 * cosDelta2)));
            var ha1 = 2 * gear.Module - ha2;
            return (ha1, ha2);
        }

        private static (double, double) CalculateGleasonDedendum(IBevelGear pinion, IBevelGear gear)
        {
            var ha = CalculateGleasonAddendum(pinion, gear);
            var hf1 = 2.188 * pinion.Module - ha.Item1;
            var hf2 = 2.188 * gear.Module - ha.Item2;
            return (hf1, hf2);
        }

        public static (double, double) CalculateDedendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var hf = CalculateDedendum(pinion, gear);
            var cd = CalculatePitchConeDistance(pinion, gear);
            var da1 = Degrees(Math.Atan(hf.Item1 / cd.Item1));
            var da2 = Degrees(Math.Atan(hf.Item2 / cd.Item2));
            return (da1, da2);
        }


        public static (double, double) CalculateAddendumAngle(IBevelGear pinion, IBevelGear gear)
        {
            var ha = CalculateAddendum(pinion, gear);
            var cd = CalculatePitchConeDistance(pinion, gear);
            var aa1 = Degrees(Math.Atan(ha.Item1 / cd.Item1));
            var aa2 = Degrees(Math.Atan(ha.Item2 / cd.Item2));
            return (aa1, aa2);
        }


        public static (double, double) CalculateOuterConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculatePitchConeAngle(pinion, gear);
            var thetaa = CalculateAddendumAngle(pinion, gear);
            var oa1 = delta.Item1 + thetaa.Item1;
            var oa2 = delta.Item2 + thetaa.Item2;
            return (oa1, oa2);
        }


        public static (double, double) CalculateRootConeAngle(IBevelGear pinion, IBevelGear gear)
        {
            var delta = CalculatePitchConeAngle(pinion, gear);
            var thetaf = CalculateDedendumAngle(pinion, gear);
            var ra1 = delta.Item1 - thetaf.Item1;
            var ra2 = delta.Item2 - thetaf.Item2;
            return (ra1, ra2);
        }


        public static (double, double) CalculatePitchApexToCrown(IBevelGear pinion, IBevelGear gear)
        {
            var cd = CalculatePitchConeDistance(pinion, gear);
            var ha = CalculateAddendum(pinion, gear);
            var ca = CalculatePitchConeAngle(pinion, gear);

            var a2c1 = cd.Item1 * Math.Cos(Radians(ca.Item1)) -
                       ha.Item1 * Math.Sin(Radians(ca.Item1));
            var a2c2 = cd.Item2 * Math.Cos(Radians(ca.Item2)) -
                       ha.Item2 * Math.Sin(Radians(ca.Item2));
            return (a2c1, a2c2);
        }


        public static (double, double) CalculateAxialFaceWidth(IBevelGear pinion, IBevelGear gear)
        {
            var oa = CalculateOuterConeAngle(pinion, gear);
            var aa = CalculateAddendumAngle(pinion, gear);
            var afw1 = pinion.FaceWidth * Math.Cos(Radians(oa.Item1)) / Math.Cos(Radians(aa.Item1));
            var afw2 = gear.FaceWidth * Math.Cos(Radians(oa.Item2)) / Math.Cos(Radians(aa.Item2));
            return (afw1, afw2);
        }


        public static (double, double) CalculateOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var d = CalculatePitchDiameter(pinion, gear);
            var ha = CalculateAddendum(pinion, gear);
            var pca = CalculatePitchConeAngle(pinion, gear);
            var od2 = d.Item2 + 2 * ha.Item2 * Math.Cos(Radians(pca.Item2));
            var od1 = d.Item1 + 2 * ha.Item1 * Math.Cos(Radians(pca.Item1));
            return (od1, od2);
        }


        public static (double, double) CalculateInnerOutsideDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var od = CalculateOutsideDiameter(pinion, gear);
            var ca = CalculateOuterConeAngle(pinion, gear);
            var addendumAngle = CalculateAddendumAngle(pinion, gear);
            var iod1 = od.Item1 - 2 * pinion.FaceWidth * Math.Sin(Radians(ca.Item1)) /
                Math.Cos(Radians(addendumAngle.Item1));
            var iod2 = od.Item2 - 2 * pinion.FaceWidth * Math.Sin(Radians(ca.Item2)) /
                Math.Cos(Radians(addendumAngle.Item2));
            return (iod1, iod2);
        }


        public static (double, double) CalculateTredgoldEquivalentBaseDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var pitchDiameter = CalculateTredgoldEquivalentPitchDiameter(pinion, gear);
            var alpha = pinion.PressureAngle; // Pressure Angle
            var db1 = pitchDiameter.Item1 * Math.Cos(Radians(alpha)); // Base Diameter of Pinion
            var db2 = pitchDiameter.Item2 * Math.Cos(Radians(alpha)); // Base Diameter of Pinion
            return (db1, db2);
        }

        public static (double, double) CalculateTredgoldEquivalentAddendumDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var d = CalculateTredgoldEquivalentPitchDiameter(pinion, gear);
            var ha = CalculateAddendum(pinion, gear);
            var ad1 = d.Item1 + (2 * ha.Item1);
            var ad2 = d.Item2 + (2 * ha.Item2);
            return (ad1, ad2);
        }

        public static (double, double) CalculateTredgoldEquivalentRootDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var d = CalculateTredgoldEquivalentPitchDiameter(pinion, gear);
            var hf = CalculateDedendum(pinion, gear);
            var rd1 = d.Item1 - (2 * hf.Item1);
            var rd2 = d.Item2 - (2 * hf.Item2);
            return (rd1, rd2);
        }


        public static (double, double) CalculateTredgoldEquivalentPitchDiameter(IBevelGear pinion, IBevelGear gear)
        {
            var d = CalculatePitchDiameter(pinion, gear);
            var pitchConeAngle = CalculatePitchConeAngle(pinion, gear);
            var result1 = d.Item1 / Math.Cos(Radians(pitchConeAngle.Item1));
            var result2 = d.Item2 / Math.Cos(Radians(pitchConeAngle.Item2));
            return (result1, result2);
        }


        public static (double, double) CalculateTredgoldEquivalentToothCount(IBevelGear pinion, IBevelGear gear)
        {
            var equivalentPitchDiameter = CalculateTredgoldEquivalentPitchDiameter(pinion, gear);

            var ez1 = equivalentPitchDiameter.Item1 / pinion.Module;
            var ez2 = equivalentPitchDiameter.Item2 / gear.Module;
            return (ez1, ez2);
        }


        public static (double, double) CalculateRadialPressureAngle(IBevelGear pinion, IBevelGear gear)
        {
            var tanAlphaN1 = Math.Tan(Radians(pinion.PressureAngle));
            var cosBetaM1 = Math.Cos(Radians(pinion.SpiralAngle));
            var a1 = Degrees(Math.Atan(tanAlphaN1 / cosBetaM1));
            var tanAlphaN2 = Math.Tan(Radians(gear.PressureAngle));
            var cosBetaM2 = Math.Cos(Radians(gear.SpiralAngle));
            var a2 = Degrees(Math.Atan(tanAlphaN2 / cosBetaM2));

            return (a1, a2);
        }
    }
}