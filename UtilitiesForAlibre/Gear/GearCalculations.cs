using System;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Gear
{
    public static class GearCalculations
    {
        #region Gear Parameters

        /// <summary>
        /// Standard Centre Distance is the normal distance between pinion and wheel centres when no profile adjustment has been made 
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static double StandardCentreDistanceA(InvoluteGear gear)
        {
            // 
            double a = 0;
            // g1 is external, mating gear is internal
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.Internal)
            {
                var num1 = gear.MatingGear.TeethZ - gear.TeethZ;
                var num2 = 2 * Math.Cos(Radians(gear.HelixAngleBeta));
                a = num1 / num2 * gear.ModeuleM;
            }

            // g1 is internal, mating gear is external
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.External)
            {
                var num1 = gear.TeethZ - gear.MatingGear.TeethZ;
                var num2 = 2 * Math.Cos(Radians(gear.HelixAngleBeta));
                a = num1 / num2 * gear.ModeuleM;
            }

            // both gears are external
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.External)
            {
                var num1 = gear.TeethZ + gear.MatingGear.TeethZ;
                var num2 = 2 * Math.Cos(Radians(gear.HelixAngleBeta));
                a = num1 / num2 * gear.ModeuleM;
            }

            // both gears are external - should never happen - throw an exception
            TestForBothInternalError(gear);

            return a;
        }


        /// <summary>
        /// Involute function for working pressure angle
        /// </summary>
        public static double InvAlphaW(InvoluteGear gear)
        {
            TestForBothInternalError(gear);
            return Math.Tan(Radians(AlphaW(gear))) - Radians(AlphaW(gear));
        }


        /// <summary>
        /// For an external gear pair,the total sum coefficient of profile shifts including any allowance for backlash.
        /// For an external , internal gear pair the difference of profile shifts i.e X1 - X2
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static double SigmaX(InvoluteGear gear)
        {
            double x = 0;
            // gear is external, mating gear is internal
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.Internal)
            {
                var num1 = InvAlpha(gear);
                var num2 = InvAlphaW(gear);
                var num3 = gear.MatingGear.TeethZ - gear.TeethZ;
                var num4 = 2 * Math.Tan(Radians(AlphaT(gear)));
                x = num3 * (num2 - num1) / num4;
                x += XMod(gear);
            }

            // gear is internal, mating gear is external
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.External)

            {
                var num1 = InvAlpha(gear.MatingGear);
                var num2 = InvAlphaW(gear.MatingGear);
                var num3 = gear.TeethZ - gear.MatingGear.TeethZ;
                var num4 = 2 * Math.Tan(Radians(AlphaT(gear.MatingGear)));
                x = num3 * (num2 - num1) / num4;
                x += XMod(gear.MatingGear);
            }

            // both gears are external
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.External)
            {
                var num1 = InvAlpha(gear);
                var num2 = InvAlphaW(gear);
                var num3 = gear.TeethZ + gear.MatingGear.TeethZ;
                var num4 = 2 * Math.Tan(Radians(AlphaT(gear)));
                x = num3 * (num2 - num1) / num4;
                x += XMod(gear);
            }

            // both gears are internal - should never happen - throw an exception
            TestForBothInternalError(gear);

            return x;
        }


        //@Todo test against all gear types

        /// <summary>
        /// /// The calculated profile shift required to achieve the desired circumferential backlash
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double XMod(InvoluteGear gear)
        {
            TestForBothInternalError(gear);

            double xm = 0;

            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.Internal)
            {
                xm = -gear.CircularBacklashBc /
                     (2 * gear.ModeuleM *
                      Math.Tan(Radians(gear.PressureAngleAlpha))) *
                     Math.Cos(Radians(AlphaW(gear))) /
                     Math.Cos(Radians(gear.PressureAngleAlpha));
            }

            // g1 is internal, mating gear is external
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.External)
            {
                xm = -gear.CircularBacklashBc /
                     (2 * gear.ModeuleM *
                      Math.Tan(Radians(gear.PressureAngleAlpha))) *
                     Math.Cos(Radians(AlphaW(gear))) /
                     Math.Cos(Radians(gear.PressureAngleAlpha));
            }

            // both gears are external
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.External)
            {
                xm = -gear.CircularBacklashBc /
                     (2 * gear.ModeuleM *
                      Math.Tan(Radians(gear.PressureAngleAlpha))) *
                     Math.Cos(Radians(AlphaW(gear))) /
                     Math.Cos(Radians(gear.PressureAngleAlpha));
            }


            return xm;
        }


        /// <summary>
        /// Working Pressure Angle of the gear pair
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static double AlphaW(InvoluteGear gear)
        {
            double aw = 0;

            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.Internal)
            {
                var num1 = gear.MatingGear.TeethZ - gear.TeethZ;
                var num2 = 2 * CentreDistanceIncrementFactorY(gear) *
                           Math.Cos(Radians(gear.HelixAngleBeta));
                var num3 = Math.Cos(Radians(AlphaT(gear)));
                aw = Degrees(Math.Acos(num3 / ((num2 / num1) + 1)));
            }

            // g1 is internal, mating gear is external
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.External)
            {
                var num1 = gear.TeethZ - gear.MatingGear.TeethZ;
                var num2 = 2 * CentreDistanceIncrementFactorY(gear.MatingGear) *
                           Math.Cos(Radians(gear.MatingGear.HelixAngleBeta));
                var num3 = Math.Cos(Radians(AlphaT(gear.MatingGear)));
                aw = Degrees(Math.Acos(num3 / ((num2 / num1) + 1)));
            }

            // both gears are external
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.External)
            {
                var num1 = gear.TeethZ + gear.MatingGear.TeethZ;
                var num2 = 2 * CentreDistanceIncrementFactorY(gear) *
                           Math.Cos(Radians(gear.HelixAngleBeta));
                var num3 = Math.Cos(Radians(AlphaT(gear)));
                aw = Degrees(Math.Acos(num1 * num3 / (num1 + num2)));
            }

            // both gears are external - should never happen - throw an exception
            TestForBothInternalError(gear);

            return aw;
        }


        /// <summary>
        /// Centre Distance Increment Factor for the gear pair
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static double CentreDistanceIncrementFactorY(InvoluteGear gear)
        {
            double y = 0;
            // g1 is external, mating gear is internal
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.Internal)
            {
                var num1 = gear.WorkingCentreDistanceAw / gear.ModeuleM;
                var num2 = gear.MatingGear.TeethZ - gear.TeethZ;
                var num3 = 2 * Math.Cos(Radians(gear.HelixAngleBeta));

                y = num1 - num2 / num3;
            }

            // g1 is internal, mating gear is external
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.External)
            {
                var num1 = gear.WorkingCentreDistanceAw / gear.ModeuleM;
                var num2 = gear.TeethZ - gear.MatingGear.TeethZ;
                var num3 = 2 * Math.Cos(Radians(gear.HelixAngleBeta));

                y = num1 - num2 / num3;
            }

            // both gears are external
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.External)
            {
                var num1 = gear.WorkingCentreDistanceAw / gear.ModeuleM;
                var num2 = gear.TeethZ + gear.MatingGear.TeethZ;
                var num3 = 2 * Math.Cos(Radians(gear.HelixAngleBeta));

                y = num1 - num2 / num3;
            }

            // both gears are external - should never happen - throw an exception
            TestForBothInternalError(gear);
            return y;
        }


        /// <summary>
        /// Returns Tip or Addendum diameter of gear
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static double AddendumDiameterDa(InvoluteGear gear)
        {
            double da = 0;
            // g1 is external, mating gear is internal
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.Internal)
            {
                da = ReferenceDiameterD(gear) + (2 * AddendumHa(gear));
            }

            // g1 is internal, mating gear is external
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.External)
            {
                da = ReferenceDiameterD(gear) - (2 * AddendumHa(gear));
            }

            // both gears are external
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.External)
            {
                da = ReferenceDiameterD(gear) + (2 * AddendumHa(gear));
            }

            // both gears are external - should never happen - throw an exception
            TestForBothInternalError(gear);

            return da;
        }

        /// <summary>
        /// Reeturns Tip or Addendum radius of g1
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double AddendumRadiusRa(InvoluteGear gear) => AddendumDiameterDa(gear) / 2;


        public static double AddendumReliefRadiusRa(InvoluteGear gear) => gear.AddendumFilletFactorRa * gear.ModeuleM;


        /// <summary>
        /// Working Pitch Diameter
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double WorkingPitchDiameterDw(InvoluteGear gear)
        {
            TestForBothInternalError(gear);
            double dw = BaseDiameterDb(gear) / Math.Cos(Radians(AlphaW(gear)));


            return dw;
        }


        /// <summary>
        /// Utility function
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        private static double SquareRootOfSquares(double r1, double r2) => Math.Sqrt(r1 * r1 - r2 * r2);

        /// <summary>
        /// Returns the Addendum of gear. 
        /// </summary>
        /// <param name="gear"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public static double AddendumHa(InvoluteGear gear)
        {
            double ha = 0;
            // g1 is external, mating gear is internal
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.Internal)
            {
                ha = (1 + gear.ProfileShiftX) * gear.ModeuleM;
            }

            // g1 is internal, mating gear is external
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.External)
            {
                ha = (1 - gear.ProfileShiftX) * gear.ModeuleM;
            }

            // both gears are external
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.External)
            {
                ha = (1 + CentreDistanceIncrementFactorY(gear) - gear.MatingGear.ProfileShiftX) * gear.ModeuleM;
            }

            // both gears are external - should never happen - throw an exception
            TestForBothInternalError(gear);

            return ha;
        }


        /// <summary>
        /// Half Tooth Angle At Reference Diameter (Pitch circle)
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double Theta(InvoluteGear gear) =>
            90 / gear.TeethZ + 360 * (gear.ProfileShiftX + XMod(gear)) *
            Math.Tan(Radians(AlphaT(gear))) /
            (Math.PI * gear.TeethZ);


        /// <summary>
        /// Angle by which involute has to be rotated to form opposing tooth flank
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double RotateDegrees(InvoluteGear gear) => (Theta(gear) + Alpha1(gear)) * 2;

        /// <summary>
        /// The maximum profile shift allowable before undercutting occurs
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double ProfileShiftWithoutUndercutX(InvoluteGear gear) =>
            1 - gear.TeethZ / 2 * Math.Pow(Math.Sin(Point.Radians(gear.PressureAngleAlpha)), 2);

        /// <summary>
        /// Calculates the axial pitch of the specified gear 
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double AxialPitch(InvoluteGear gear) =>
            TransverseModuleMt(gear) / Math.Cos(Point.Radians(gear.HelixAngleBeta)) * Math.PI /
            Math.Tan(Point.Radians(gear.HelixAngleBeta));

        /// <summary>
        /// Calculates the helix pitch length for the specified gear.
        /// In Alibre this is used to define the pitch of the helical boss extruded to form an individual tooth 
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double HelixPitchLength(InvoluteGear gear) => AxialPitch(gear) * gear.TeethZ;

        /// <summary>
        /// The Transverse or helical Pressure Angle
        /// </summary>
        public static double AlphaT(InvoluteGear gear) =>
            Degrees(Math.Atan(Math.Tan(Radians(gear.PressureAngleAlpha)) / Math.Cos(Radians(gear.HelixAngleBeta))));

        public static double Alpha1(InvoluteGear gear) => Degrees(
            Math.Sqrt(ReferenceDiameterD(gear) * ReferenceDiameterD(gear) - BaseDiameterDb(gear) * BaseDiameterDb(gear)) /
            BaseDiameterDb(gear)) - AlphaT(gear);

        /// <summary>
        /// Involute function for standard pressure angle
        /// </summary>
        public static double InvAlpha(InvoluteGear gear)
        {
            double invAlpha = 0;
            // g1 is external, mating gear is internal
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.Internal)
            {
                invAlpha = Math.Tan(Radians(AlphaT(gear))) - Radians(AlphaT(gear));
            }

            // g1 is internal, mating gear is external
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.External)
            {
                invAlpha = Math.Tan(Radians(AlphaT(gear))) - Radians(AlphaT(gear));
            }

            // both gears are external
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.External)
            {
                invAlpha = Math.Tan(Radians(AlphaT(gear))) - Radians(AlphaT(gear));
            }

            // both gears are external - should never happen - throw an exception
            TestForBothInternalError(gear);

            return invAlpha;
        }

        private static void TestForBothInternalError(InvoluteGear gear)
        {
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.Internal)
            {
                throw new InvalidOperationException("Both gears can't be internal!");
            }
        }

        /// <summary>
        /// OuterRingDiameter
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double OuterRingDiameter(InvoluteGear gear)
        {
            return Math.Ceiling(RootDiameterDr(gear)) + gear.ModeuleM;
        }


        /// <summary>
        /// Root diameter of the given gear
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double RootDiameterDr(InvoluteGear gear)
        {
            double dr = 0;
            // g1 is external, mating gear is internal
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.Internal)
            {
                dr = AddendumDiameterDa(gear) - (2 * (2.25 * gear.ModeuleM));
            }

            // g1 is internal, mating gear is external
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.External)
            {
                dr = AddendumDiameterDa(gear) + (2 * (2.25 * gear.ModeuleM));
            }

            // both gears are external
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.External)
            {
                dr = ReferenceDiameterD(gear) + 2 * gear.ModeuleM * (-1.25 + gear.ProfileShiftX);
            }

            // both gears are external - should never happen - throw an exception
            TestForBothInternalError(gear);

            return dr;
        }


        /// <summary>
        /// Base diameter of the given gear
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static double BaseDiameterDb(InvoluteGear gear)
        {
            TestForBothInternalError(gear);
            return ReferenceDiameterD(gear) * Math.Cos(Radians(AlphaT(gear)));
        }

        /// <summary>
        /// Base Radius of the given gear
        /// </summary>
        public static double BaseRadiusRb(InvoluteGear gear) => BaseDiameterDb(gear) / 2;


        /// <summary>
        /// Reference or Standard pitch diameter of the given gear
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static double ReferenceDiameterD(InvoluteGear gear)
        {
            TestForBothInternalError(gear);

            return gear.ModeuleM * gear.TeethZ / Math.Cos(Radians(gear.HelixAngleBeta));
        }


        /// <summary>
        /// Transverse or axial module of the given gear
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double TransverseModuleMt(InvoluteGear gear) => gear.ModeuleM / Math.Cos(Radians(gear.HelixAngleBeta));


        /// <summary>
        /// Calculated contact ratio of the pinion, wheel pair.
        /// The contact ratio should not fall below 1.2. 
        /// </summary>
        /// <returns></returns>
        public static double ContactRatio(InvoluteGear gear)
        {
            double ratio = 0;
            // g1 is external, mating gear is internal
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.Internal)

            {
                var num2 = SquareRootOfSquares((AddendumDiameterDa(gear) + XMod(gear)) / 2, BaseDiameterDb(gear) / 2);
                var num1 = SquareRootOfSquares((AddendumDiameterDa(gear.MatingGear) + XMod(gear.MatingGear)) / 2,
                    BaseDiameterDb(gear.MatingGear) / 2);
                var num3 = gear.WorkingCentreDistanceAw * Math.Sin(Radians(AlphaW(gear)));
                var num4 = TransverseModuleMt(gear) * Math.PI * Math.Cos(Radians(AlphaT(gear)));


                ratio = (num1 - num2 + num3) / num4;
            }

            // g1 is internal, mating gear is external
            if (gear.GearType == GearType.Internal && gear.MatingGear.GearType == GearType.External)
            {
                var num2 = SquareRootOfSquares((AddendumDiameterDa(gear) + XMod(gear)) / 2, BaseDiameterDb(gear) / 2);
                var num1 = SquareRootOfSquares((AddendumDiameterDa(gear.MatingGear) + XMod(gear)) / 2,
                    BaseDiameterDb(gear.MatingGear) / 2);
                var num3 = gear.WorkingCentreDistanceAw * Math.Sin(Radians(AlphaW(gear)));
                var num4 = TransverseModuleMt(gear) * Math.PI * Math.Cos(Radians(AlphaT(gear)));

                ratio = (num2 - num1 + num3) / num4;
            }

            // both gears are external
            if (gear.GearType == GearType.External && gear.MatingGear.GearType == GearType.External)
            {
                var num1 = SquareRootOfSquares((AddendumDiameterDa(gear) + XMod(gear)) / 2, BaseDiameterDb(gear) / 2);
                var num2 = SquareRootOfSquares((AddendumDiameterDa(gear.MatingGear) + XMod(gear)) / 2,
                    BaseDiameterDb(gear.MatingGear) / 2);
                var num3 = gear.WorkingCentreDistanceAw * Math.Sin(Radians(AlphaW(gear)));
                var num4 = TransverseModuleMt(gear) * Math.PI * Math.Cos(Radians(AlphaT(gear)));

                ratio = (num1 + num2 - num3) / num4;
            }

            // both gears are external - should never happen - throw an exception
            TestForBothInternalError(gear);

            return ratio;
        }

        #endregion

        #region Root Fillet Parameters

        /// <summary>
        /// Fillet Diameter
        /// </summary>
        public static double RootFilletDiameter(InvoluteGear gear) => gear.ModeuleM * gear.RootFilletFactorRf;

        public static double RootFilletRadius(InvoluteGear gear) => RootFilletDiameter(gear) / 2;


        /// <summary>
        /// Returns the angle in radians to the centre of the root fillet circle
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double AngleToFilletCentre(InvoluteGear gear) =>
            Math.Asin(RootFilletDiameter(gear) / 2 / ((RootDiameterDr(gear) + RootFilletDiameter(gear)) / 2));

        public static double RootFilletCentreXd(InvoluteGear gear) => (RootFilletDiameter(gear) + RootDiameterDr(gear)) / 2 *
                                                                      Math.Cos(AngleToFilletCentre(gear));

        public static double RootFilletCentreYd(InvoluteGear gear) =>
            -(RootFilletDiameter(gear) + RootDiameterDr(gear)) / 2 *
            Math.Sin(AngleToFilletCentre(gear));

        public static double RootFilletStartXa(InvoluteGear gear) =>
            RootDiameterDr(gear) / 2 * Math.Cos(AngleToFilletCentre(gear));

        public static double RootFilletStartYa(InvoluteGear gear) =>
            -RootDiameterDr(gear) / 2 * Math.Sin(AngleToFilletCentre(gear));

        public static double RootFilletEndXe(InvoluteGear gear) =>
            RootDiameterDr(gear) / 2 * Math.Tan(AngleToFilletCentre(gear)) +
            RootDiameterDr(gear) / 2 / Math.Cos(AngleToFilletCentre(gear));

        public static double RootFilletEndYe(InvoluteGear gear) => 0;

        public static Point RootFilletEndPoint(InvoluteGear gear) => new(RootFilletEndXe(gear), RootFilletEndYe(gear));
        public static Point RootFilletStartPoint(InvoluteGear gear) => new(RootFilletStartXa(gear), RootFilletStartYa(gear));

        public static Point RootFilletCentrePoint(InvoluteGear gear) =>
            new(RootFilletCentreXd(gear), RootFilletCentreYd(gear));

        #endregion

        #region Internal Gear Addendum Fillet Parameters

        /// <summary>
        /// Calculates the distance from the centre of the inner gear addendum relief to a point on the base circle where a
        /// line from the addendum relief centre meets the base circle at a tangent. A line to the gear centre will be at 90°
        /// to this line. 
        /// </summary>
        /// <param name="baseRadius"></param>
        /// <param name="addendumRadius"></param>
        /// <param name="reliefRadius"></param>
        /// <returns></returns>
        public static double DistanceBaseTangentPointToInnerGearAddendumRelief(double baseRadius, double addendumRadius,
            double reliefRadius)
        {
            double hypotenuse;
            if (addendumRadius > baseRadius)
            {
                hypotenuse = addendumRadius + reliefRadius;
            }
            else
            {
                hypotenuse = baseRadius + reliefRadius;
            }

            var hypotenuseSquared = hypotenuse * hypotenuse;
            var baseRadiusSquared = baseRadius * baseRadius;
            var resultSquared = hypotenuseSquared - baseRadiusSquared;
            return Math.Sqrt(resultSquared);
        }


        /// <summary>
        /// Calculates the angle between a line from the gear centre to the centre point of the Addendum Relief circle centre
        /// and a line from the Addendum Relief circle centre to a tangent point on the base circle.
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double InnerGearTipReliefCentreToBaseTangentAngle(InvoluteGear gear)
        {
            var addendumRadius = GearCalculations.AddendumRadiusRa(gear);
            var baseRadius = GearCalculations.BaseRadiusRb(gear);
            var reliefRadius = GearCalculations.RootFilletRadius(gear);

            double d = DistanceBaseTangentPointToInnerGearAddendumRelief(baseRadius,
                addendumRadius, reliefRadius);
            double angleToBase;
            if (addendumRadius > baseRadius)
            {
                angleToBase = Point.Degrees(Math.Acos(d / (addendumRadius + reliefRadius)));
            }
            else
            {
                angleToBase = Point.Degrees(Math.Acos(d / (baseRadius + reliefRadius)));
            }

            return angleToBase;
        }

        public static double CalcGearCentreToFilletCentreDistance(InvoluteGear gear)
        {
            double gearCentreToFilletCentre;

            if (AddendumRadiusRa(gear) > BaseRadiusRb(gear))
            {
                gearCentreToFilletCentre = AddendumRadiusRa(gear) + RootFilletRadius(gear);
            }
            else
            {
                gearCentreToFilletCentre = BaseRadiusRb(gear) + RootFilletRadius(gear);
            }

            return gearCentreToFilletCentre;
        }


        /// <summary>
        /// Nasty big routine to find location of inner gear tip relief points.
        /// Was not able to find geometric way finding these points so this routine uses a binary search to find the locations.
        /// Works by finding a good geometric location for the end point (point on involute) and then uses a binary search to determine
        /// location of centre and start points. Observe that the start-centre distance is Module * factor and the start point is
        /// located on the base or addendum circle (whichever is greater).
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static Point[] CalcAddendumFilletPoints(InvoluteGear gear)
        {
            // tolerance of 0.000001 seems to work well with alibre
            double tolerance = 0.000001;
            Point centre = new Point(0, 0);

            double targetGearCentreToFilletCentreDistance = CalcGearCentreToFilletCentreDistance(gear);
            double addendumReliefRadius = RootFilletRadius(gear);
            double targetGearCentreToStartPointDistance = targetGearCentreToFilletCentreDistance - addendumReliefRadius;
            // the angle used as the initial start point for the search
            double angleToBase = InnerGearTipReliefCentreToBaseTangentAngle(gear);
            // the search range with be +- this angle about the initial search point.
            double changeAngle = 4.0d;

            // initial angles for search
            double maxAngle = angleToBase + changeAngle;
            double minAngle = angleToBase - changeAngle;
            double midAngle = angleToBase;

            // points used in binary search. Final results will be taken from the three Mid Points.
            // Min and Max points are used in the binary search
            Point startMidPoint;
            Point centreMidPoint;
            Point endMidPoint;
            Point startMinPoint;
            Point centreMinPoint;
            Point endMinPoint;
            Point startMaxPoint;
            Point centreMaxPoint;
            Point endMaxPoint;

            // setup the mid points
            endMidPoint = EndPoint(gear, targetGearCentreToFilletCentreDistance, angleToBase);
            centreMidPoint = CentrePoint(gear, endMidPoint, midAngle);
            startMidPoint = StartPoint(gear, centreMidPoint);
            // calculate distance to mid start point
            double distanceToStartMidPoint = Geometry.DistanceBetweenPoints(centre, startMidPoint);
            // test value this needs to tend towards zero
            double midTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMidPoint);
            // setup the minimums
            endMinPoint = EndPoint(gear, targetGearCentreToFilletCentreDistance, angleToBase);
            centreMinPoint = CentrePoint(gear, endMinPoint, minAngle);
            startMinPoint = StartPoint(gear, centreMinPoint);
            double distanceToStartMinPoint = Geometry.DistanceBetweenPoints(centre, startMinPoint);
            double minTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMinPoint);
            // setup the maximums
            endMaxPoint = EndPoint(gear, targetGearCentreToFilletCentreDistance, angleToBase);
            centreMaxPoint = CentrePoint(gear, endMaxPoint, maxAngle);
            startMaxPoint = StartPoint(gear, centreMaxPoint);
            double distanceToStartMaxPoint = Geometry.DistanceBetweenPoints(centre, startMaxPoint);
            double maxTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMaxPoint);

            // search loop 
            while (!Equals(0, midTestValue, tolerance))
            {
                if (maxTestValue > minTestValue)
                {
                    // need to search between mid and min
                    startMaxPoint = startMidPoint;
                    // recalc midAngle
                    maxAngle = midAngle;
                    midAngle = (minAngle + maxAngle) / 2;
                    centreMidPoint = CentrePoint(gear, endMidPoint, midAngle);
                    startMidPoint = StartPoint(gear, centreMidPoint);
                    centreMinPoint = CentrePoint(gear, endMinPoint, minAngle);
                    startMinPoint = StartPoint(gear, centreMinPoint);
                }
                else
                {
                    // need to search between mid and max
                    startMinPoint = startMidPoint;
                    // recalc midAngle
                    minAngle = midAngle;
                    midAngle = (minAngle + maxAngle) / 2;
                    centreMidPoint = CentrePoint(gear, endMidPoint, midAngle);
                    startMidPoint = StartPoint(gear, centreMidPoint);
                    centreMaxPoint = CentrePoint(gear, endMaxPoint, maxAngle);
                    startMaxPoint = StartPoint(gear, centreMaxPoint);
                }

                distanceToStartMaxPoint = Geometry.DistanceBetweenPoints(centre, startMaxPoint);

                // max test value
                maxTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMaxPoint);

                // calculate distance to mid start point
                distanceToStartMidPoint = Geometry.DistanceBetweenPoints(centre, startMidPoint);

                // test value this needs to tend towards zero
                midTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMidPoint);

                distanceToStartMinPoint = Geometry.DistanceBetweenPoints(centre, startMinPoint);

                // min test value
                minTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMinPoint);
            }

            Point[] results = new[] {endMidPoint, centreMidPoint, startMidPoint};

            return results;
        }

        private static bool Equals(double x, double y, double tolerance)
        {
            var diff = Math.Abs(x - y);
            return diff <= tolerance;
        }


        public static Point StartPoint(InvoluteGear gear, Point centrePoint)
        {
            return Point.PolarOffset(centrePoint, RootFilletRadius(gear),
                Point.Radians(180 - Math.Atan(centrePoint.Y / centrePoint.X)));
        }

        public static Point CentrePoint(InvoluteGear gear, Point endPoint, double adjustedAngleToBase)
        {
            return Point.PolarOffset(endPoint,
                RootFilletRadius(gear), Point.Radians(-adjustedAngleToBase));
        }


        public static Point EndPoint(InvoluteGear gear, double gearCentreToFilletCentre, double adjustedAngleToBase)
        {
            double radiansToBase = Point.Radians(180 - adjustedAngleToBase);

            Point p = new Point(gearCentreToFilletCentre, 0);
            Point y = Point.PolarOffset(p, RootFilletRadius(gear), radiansToBase);
            Point centre = new Point(0, 0);
            double distanceToY = Geometry.DistanceBetweenPoints(centre, y);

            return Geometry.PointOnInvolute(BaseRadiusRb(gear), distanceToY);
        }

        #endregion
    }
}