using System;
using Bolsover.Gear.Models;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Gear.Calculators
{
    public class StandardExternalExternalSpurGearCalculator 
    {
        public double CalculateInvoluteAlpha(IGearPair gearPair)
        {
            return Math.Tan(Radians(gearPair.Gear.NormalPressureAngle)) - Radians(gearPair.Gear.NormalPressureAngle);
        }

        public double CalculateInvoluteFunction(IGearPair gearPair)
        {
            var twoTanAlpha = 2 * Math.Tan(Radians(gearPair.Gear.NormalPressureAngle));
            var x1plusx2 = gearPair.Pinion.CoefficientOfProfileShift + gearPair.Gear.CoefficientOfProfileShift;
            var z1plusz2 = gearPair.Pinion.NumberOfTeeth + gearPair.Gear.NumberOfTeeth;
            var involuteAlpha = CalculateInvoluteAlpha(gearPair);
            var result = twoTanAlpha * (x1plusx2 / z1plusz2) + involuteAlpha;

            return result;
        }

        public double CalculateWorkingPressureAngle(IGearPair gearPair)
        {
            var num1 = gearPair.Gear.NumberOfTeeth + gearPair.Pinion.NumberOfTeeth;
            var num2 = 2 * CalculateCentreDistanceIncrementFactor(gearPair);
            var num3 = Math.Cos(Radians(gearPair.Gear.NormalPressureAngle));
            return Degrees(Math.Acos(num1 * num3 / (num1 + num2)));
        }

        public double CalculateCentreDistance(IGearPair gearPair)
        {
            return (gearPair.Pinion.NumberOfTeeth + gearPair.Gear.NumberOfTeeth) * gearPair.Gear.NormalModule / 2;
        }


        public double CalculateGearPitchDiameter(IGearPair gearPair)
        {
            return gearPair.Gear.NumberOfTeeth * gearPair.Gear.NormalModule;
        }

        public double CalculatePinionPitchDiameter(IGearPair gearPair)
        {
            return gearPair.Pinion.NumberOfTeeth * gearPair.Pinion.NormalModule;
        }

        public double CalculatePinionBaseDiameter(IGearPair gearPair)
        {
            return CalculatePinionPitchDiameter(gearPair) * Math.Cos(Radians(gearPair.Gear.NormalPressureAngle));
        }

        public double CalculateGearBaseDiameter(IGearPair gearPair)
        {
            return CalculateGearPitchDiameter(gearPair) * Math.Cos(Radians(gearPair.Gear.NormalPressureAngle));
        }

        public double CalculatePinionWorkingPitchDiameter(IGearPair gearPair)
        {
            var baseDiameter = CalculatePinionBaseDiameter(gearPair);
            var cosWorkingPressureAngle = Math.Cos(Radians(CalculateWorkingPressureAngle(gearPair)));
            return baseDiameter / cosWorkingPressureAngle;
        }

        public double CalculateGearWorkingPitchDiameter(IGearPair gearPair)
        {
            var baseDiameter = CalculateGearBaseDiameter(gearPair);
            var cosWorkingPressureAngle = Math.Cos(Radians(CalculateWorkingPressureAngle(gearPair)));
            return baseDiameter / cosWorkingPressureAngle;
        }


        public double CalculatePinionAddendum(IGearPair gearPair)
        {
            return (1.00 + CalculateCentreDistanceIncrementFactor(gearPair) - gearPair.Gear.CoefficientOfProfileShift) *
                   gearPair.Gear.NormalModule;
        }

        public double CalculateGearAddendum(IGearPair gearPair)
        {
            return (1.00 + CalculateCentreDistanceIncrementFactor(gearPair) - gearPair.Pinion.CoefficientOfProfileShift) *
                   gearPair.Gear.NormalModule;
        }

        public double CalculateGearDedendum(IGearPair gearPair)
        {
            var addendum = CalculateGearAddendum(gearPair);
            var wholeDepth = CalculateGearWholeDepth(gearPair);

            return wholeDepth - addendum;
        }

        public double CalculatePinionDedendum(IGearPair gearPair)
        {
            var addendum = CalculatePinionAddendum(gearPair);
            var wholeDepth = CalculatePinionWholeDepth(gearPair);

            return wholeDepth - addendum;
        }


        public double CalculatePinionWholeDepth(IGearPair gearPair)
        {
            return (2.25 + CalculateCentreDistanceIncrementFactor(gearPair) -
                    (gearPair.Pinion.CoefficientOfProfileShift + gearPair.Gear.CoefficientOfProfileShift)) *
                   gearPair.Gear.NormalModule;
        }

        public double CalculateGearWholeDepth(IGearPair gearPair)
        {
            return (2.25 + CalculateCentreDistanceIncrementFactor(gearPair) -
                    (gearPair.Pinion.CoefficientOfProfileShift + gearPair.Gear.CoefficientOfProfileShift)) *
                   gearPair.Gear.NormalModule;
        }


        public double CalculatePinionOutsideDiameter(IGearPair gearPair)
        {
            return CalculatePinionPitchDiameter(gearPair) + 2 * CalculatePinionAddendum(gearPair);
        }

        public double CalculateGearOutsideDiameter(IGearPair gearPair)
        {
            return CalculateGearPitchDiameter(gearPair) + 2 * CalculateGearAddendum(gearPair);
        }


        public double CalculatePinionRootDiameter(IGearPair gearPair)
        {
            return CalculatePinionOutsideDiameter(gearPair) - 2 * CalculatePinionWholeDepth(gearPair);
        }

        public double CalculateGearRootDiameter(IGearPair gearPair)
        {
            return CalculateGearOutsideDiameter(gearPair) - 2 * CalculateGearWholeDepth(gearPair);
        }


        public double CalculateCentreDistanceIncrementFactor(IGearPair gearPair)
        {
            var num1 = gearPair.Gear.WorkingCentreDistance / gearPair.Gear.NormalModule;
            var num2 = gearPair.Gear.NumberOfTeeth + gearPair.Pinion.NumberOfTeeth;
            var num3 = 2;

            var result = num1 - num2 / num3;
            return result;
        }

        public double CalculateSumCoefficientOfProfileShift(IGearPair gearPair)
        {
            var z1Plusz2 = gearPair.Pinion.NumberOfTeeth + gearPair.Gear.NumberOfTeeth;
            var invalphaw = CalculateInvoluteFunction(gearPair);
            var invalpha = CalculateInvoluteAlpha(gearPair);
            var twoTanAlpha = 2 * Math.Tan(Radians(gearPair.Gear.NormalPressureAngle));

            var result = z1Plusz2 * (invalphaw - invalpha) / twoTanAlpha;
            return result;
        }


        public double CalculateRadialWorkingPressureAngle(IGearPair gearPair)
        {
            throw new NotImplementedException();
        }

        public double CalculateGearHalfToothAngleAtPitchDiameter(IGearPair gearPair)
        {
            return 90 / gearPair.Gear.NumberOfTeeth + 360 *
                (gearPair.Gear.CoefficientOfProfileShift + CalculateGearBacklashModification(gearPair)) *
                Math.Tan(Radians(gearPair.Gear.NormalPressureAngle)) /
                (Math.PI * gearPair.Gear.NumberOfTeeth);
        }

        public double CalculatePinionHalfToothAngleAtPitchDiameter(IGearPair gearPair)
        {
            return 90 / gearPair.Pinion.NumberOfTeeth + 360 *
                (gearPair.Pinion.CoefficientOfProfileShift + CalculatePinionBacklashModification(gearPair)) *
                Math.Tan(Radians(gearPair.Pinion.NormalPressureAngle)) /
                (Math.PI * gearPair.Pinion.NumberOfTeeth);
        }

        public double CalculateGearBacklashModification(IGearPair gearPair)
        {
            return -gearPair.Gear.CircularBacklash /
                   (2 * gearPair.Gear.NormalModule *
                    Math.Tan(Radians(gearPair.Gear.NormalPressureAngle))) *
                   Math.Cos(Radians(CalculateWorkingPressureAngle(gearPair))) /
                   Math.Cos(Radians(gearPair.Gear.NormalPressureAngle));
        }

        public double CalculatePinionBacklashModification(IGearPair gearPair)
        {
            return -gearPair.Pinion.CircularBacklash /
                   (2 * gearPair.Pinion.NormalModule *
                    Math.Tan(Radians(gearPair.Pinion.NormalPressureAngle))) *
                   Math.Cos(Radians(CalculateWorkingPressureAngle(gearPair))) /
                   Math.Cos(Radians(gearPair.Pinion.NormalPressureAngle));
        }


    }
}