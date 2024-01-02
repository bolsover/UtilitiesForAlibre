using System;
using Bolsover.Gear.Models;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Gear.Calculators
{
    public class StandardHelicalGearCalculator
    {
        /// <summary>
        /// Calculates the centre distance increment factor (y) for a profile shifted gear pair
        ///
        /// y = (ax / mn) - (z1 + z2) / (2cos(beta))
        /// where:
        /// y: centre distance increment factor
        /// ax: working centre distance including any profile shift
        /// mn: module
        /// z1: number of teeth gear 1
        /// z2: number of teeth gear 2
        /// beta: helix angle
        /// 
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculateProfileShiftedCentreDistanceIncrementFactor(IGearPair gearPair)
        {
            var ax = gearPair.Gear.WorkingCentreDistance;
            var mn = gearPair.Gear.NormalModule;
            var sumz = gearPair.Pinion.NumberOfTeeth + gearPair.Gear.NumberOfTeeth;
            var beta = Radians(gearPair.Gear.HelixAngle);
            var y = (ax / mn) - (sumz / (2 * Math.Cos(beta)));
            return y;
        }

        /// <summary>
        /// Returns the working radial pressure angle in degrees
        ///  Acos(((z1 + z2) * cos(alphat)) / ((z1 +z2) + 2yCos(beta)))
        /// Where
        /// z1 = number of teeth gear 1
        /// z2 = number of teeth gear 2
        /// alphat = transverse pressure angle
        /// y = profile shifted centre distance increment factor
        /// beta = helix angle
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculateWorkingRadialPressureAngle(IGearPair gearPair)
        {
            var sumz = gearPair.Gear.NumberOfTeeth + gearPair.Pinion.NumberOfTeeth;
            var alphat = Radians(CalculateRadialPressureAngle(gearPair));
            var y = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var beta = Radians(gearPair.Gear.HelixAngle);
            var result = Degrees(Math.Acos((sumz * Math.Cos(alphat)) / (sumz + (2 * Math.Cos(beta)) * y)));
            return result;
        }


        /// <summary>
        /// Returns the Radial pressure angle using the formula
        /// alphat = Atan(Tan(alphan/beta))
        /// Where:
        /// alphan = Normal pressure angle
        /// beta = Helix angle
        /// 
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculateRadialPressureAngle(IGearPair gearPair)
        {
            var normalPressureAngle = Radians(gearPair.Gear.NormalPressureAngle);
            var beta = Radians(gearPair.Gear.HelixAngle);
            var alphat = Degrees(Math.Atan(Math.Tan(normalPressureAngle) / Math.Cos(beta)));
            return alphat;
        }


        public double CalculateTransverseModule(IGearPair gearPair)
        {
            return gearPair.Gear.NormalModule / Math.Cos(Radians(gearPair.Gear.HelixAngle));
        }


        public double CalculateTransverseInvoluteAlpha(IGearPair gearPair)
        {
            return Math.Tan(Radians(CalculateRadialPressureAngle(gearPair))) - Radians(CalculateRadialPressureAngle(gearPair));
        }

        /// <summary>
        /// Calculates the transverse involute function using the formula:
        /// awt = 2Tan(alphan) ((x1 + x2) / (z1 + z2)) + invat
        /// Where:
        /// alphan: Normal pressure angle
        /// x1: Normal Coefficient profile shift gear1
        /// x2: Normal Coefficient profile shift gear2
        /// z1: Teeth gear1
        /// z2: Teeth gear2
        /// invAlphat: transverse involute of normal pressure angle
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculateTransverseInvoluteFunction(IGearPair gearPair)
        {
            var alphan = Radians(gearPair.Gear.NormalPressureAngle);
            var twoTanAlpha = 2 * Math.Tan(alphan);
            var x1Plusx2 = gearPair.Gear.NormalCoefficientOfProfileShift + gearPair.Pinion.NormalCoefficientOfProfileShift;
            var z1Plusz2 = gearPair.Pinion.NumberOfTeeth + gearPair.Gear.NumberOfTeeth;
            var involuteAlphat = CalculateTransverseInvoluteAlpha(gearPair);
            var result = twoTanAlpha * (x1Plusx2 / z1Plusz2) + involuteAlphat;

            return result;
        }


        /// <summary>
        /// For standard gears, the coefficient of profile shift is always 0
        /// </summary>
        /// <returns></returns>
        public double CalculateStandardCoefficientOfProfileShift()
        {
            return 0;
        }

        public double CalculateStandardCentreDistance(IGearPair gearPair)
        {
            var num1 = CalculateGearStandardPitchDiameter(gearPair);
            var num2 = CalculatePinionStandardPitchDiameter(gearPair);

            return (num1 + num2) / 2;
        }

        /// <summary>
        ///  Calculates the standard pitch diameter using the formula:
        ///  d = mn * z / cos(beta)
        ///  Where:
        /// d = standard pitch diameter
        /// mn = normal module
        /// z = number of teeth
        /// beta = helix angle
        /// </summary>
        /// <param name="gear"></param>
        /// <returns>Standard pitch diameter of helical gear</returns>
        private double CalculateStandardPitchDiameter(IGear gear) => gear.NormalModule * gear.NumberOfTeeth / Math.Cos(Radians(gear.HelixAngle));

        public double CalculateGearStandardPitchDiameter(IGearPair gearPair) => CalculateStandardPitchDiameter(gearPair.Gear);

        public double CalculatePinionStandardPitchDiameter(IGearPair gearPair) => CalculateStandardPitchDiameter(gearPair.Pinion);


        /// <summary>
        /// Calculates the gear base diameter using the formula:
        /// db = d * cos(alphat)
        /// where:
        /// db = base diameter
        /// d = standard pitch diameter of gear
        /// alphat = radial pressure angle
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns>Base diameter of helical gear</returns>
        public double CalculateGearBaseDiameter(IGearPair gearPair) =>
            CalculateGearStandardPitchDiameter(gearPair) * Math.Cos(Radians(CalculateRadialPressureAngle(gearPair)));

        /// <summary>
        /// Calculates the pinion base diameter using the formula:
        /// db = d * cos(alphat)
        /// where:
        /// db = base diameter
        /// d = standard pitch diameter of pinion
        /// alphat = radial pressure angle
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns>Base diameter of helical gear</returns>
        public double CalculatePinionBaseDiameter(IGearPair gearPair) =>
            CalculatePinionStandardPitchDiameter(gearPair) * Math.Cos(Radians(CalculateRadialPressureAngle(gearPair)));


        /// <summary>
        /// Calculate Gear Addendum using the formula:
        /// ha = (1 + y - x1) * mn
        /// where:
        /// ha = addendum
        /// y = centre distance increment factor
        /// x1 = pinion coefficient of profile shift
        /// mn = normal module
        /// 
        /// </summary>
        /// <param name="gearPair">The gear pair for which we want to calculate the addendum.</param>
        /// <returns>The calculated gear addendum</returns>
        public double CalculateGearAddendum(IGearPair gearPair)
        {
            var normalModule = gearPair.Gear.NormalModule;
            var incrementFactor = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var pinionCoefficientOfProfileShift = gearPair.Pinion.NormalCoefficientOfProfileShift;

            var addendum = (1 + incrementFactor - pinionCoefficientOfProfileShift) * normalModule;
            return addendum;
        }


        /// <summary>
        /// Calculate Pinion Addendum using the formula:
        /// ha = (1 + y - x2) * mn
        /// where:
        /// ha = addendum
        /// y = centre distance increment factor
        /// x2 = gear coefficient of profile shift
        /// mn = normal module
        /// 
        /// </summary>
        /// <param name="gearPair">The gear pair for which we want to calculate the addendum.</param>
        /// <returns>The calculated gear addendum</returns>
        public double CalculatePinionAddendum(IGearPair gearPair)
        {
            var normalModule = gearPair.Gear.NormalModule;
            var incrementFactor = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var gearCoefficientOfProfileShift = gearPair.Gear.NormalCoefficientOfProfileShift;

            var pinionAddendum = (1 + incrementFactor - gearCoefficientOfProfileShift) * normalModule;
            return pinionAddendum;
        }

        /// <summary>
        /// Calculate the gear addendum circle diameter using the formula:
        ///  da = d + 2 * ha
        ///  where:
        ///  da = addendum circle diameter
        ///  d = standard pitch diameter
        ///  ha = addendum
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns>Gear addendum circle diameter</returns>
        public double CalculateStandardGearAddendumCircleDiameter(IGearPair gearPair)
        {
            var gearAddendum = CalculateGearAddendum(gearPair);
            var standardPitchDiameter = CalculateStandardPitchDiameter(gearPair.Gear);
            var addendumCircleDiameter = standardPitchDiameter + 2 * gearAddendum;
            return addendumCircleDiameter;
        }

        /// <summary>
        /// Calculate the pinion addendum circle diameter using the formula:
        ///  da = d + 2 * ha
        ///  where:
        ///  da = addendum circle diameter
        ///  d = standard pitch diameter
        ///  ha = addendum
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns>Pinion addendum circle diameter</returns>
        public double CalculateStandardPinionAddendumCircleDiameter(IGearPair gearPair)
        {
            var ha = CalculatePinionAddendum(gearPair);
            var d = CalculateStandardPitchDiameter(gearPair.Pinion);
            var da = d + 2 * ha;
            return da;
        }


        /// <summary>
        /// Calculate the gear dedendum using the formula:
        /// hf = (1.25 + y - x1) * mn
        /// where:
        /// hf = dedendum
        /// y = centre distance increment factor
        /// x1  = pinion coefficient of profile shift
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns>Gear Dedendum</returns>
        public double CalculateGearDedendum(IGearPair gearPair)
        {
            var mn = gearPair.Gear.NormalModule;
            var y = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var x1 = gearPair.Pinion.NormalCoefficientOfProfileShift;

            var hf1 = (1.25 + y - x1) * mn;
            return hf1;
        }


        /// <summary>
        /// Calculate the pinion dedendum using the formula:
        /// hf = (1.25 + y - x1) * mn
        /// where:
        /// hf = dedendum
        /// y = centre distance increment factor
        /// x2  = pinion coefficient of profile shift
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns>Gear Dedendum</returns>
        public double CalculatePinionDedendum(IGearPair gearPair)
        {
            var mn = gearPair.Gear.NormalModule;
            var y = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var x2 = gearPair.Gear.NormalCoefficientOfProfileShift;

            var hf = (1.25 + y - x2) * mn;
            return hf;
        }

        public double CalculateStandardGearDedendumCircleDiameter(IGearPair gearPair)
        {
            var hf = CalculateGearDedendum(gearPair);
            var d = CalculateStandardPitchDiameter(gearPair.Gear);
            var df = d - 2 * hf;
            return df;
        }

        public double CalculateStandardPinionDedendumCircleDiameter(IGearPair gearPair)
        {
            var hf = CalculatePinionDedendum(gearPair);
            var d = CalculateStandardPitchDiameter(gearPair.Pinion);
            var df = d - 2 * hf;
            return df;
        }

        public double CalculateWholeDepth(IGearPair gearPair)
        {
            var mn = gearPair.Gear.NormalModule;
            var y = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var x1 = gearPair.Pinion.NormalCoefficientOfProfileShift;
            var x2 = gearPair.Gear.NormalCoefficientOfProfileShift;
            var h = (2.25 + y - (x1 + x2)) * mn;
            return h;
        }

        public double CalculateGearOutsideDiameter(IGearPair gearPair)
        {
            return CalculateGearStandardPitchDiameter(gearPair) + 2 * CalculateGearAddendum(gearPair);
        }

        public double CalculatePinionOutsideDiameter(IGearPair gearPair)
        {
            return CalculatePinionStandardPitchDiameter(gearPair) + 2 * CalculatePinionAddendum(gearPair);
        }


        public double CalculateGearRootDiameter(IGearPair gearPair)
        {
            return CalculateGearOutsideDiameter(gearPair) - 2 * CalculateWholeDepth(gearPair);
        }

        public double CalculatePinionRootDiameter(IGearPair gearPair)
        {
            return CalculatePinionOutsideDiameter(gearPair) - 2 * CalculateWholeDepth(gearPair);
        }
    }
}