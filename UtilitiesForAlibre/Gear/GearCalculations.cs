using System;

namespace Bolsover.Gear
{
    public static class GearCalculations
    {
        /// <summary>
        /// Standard Centre Distance is the normal distance between pinion and wheel centres when no profile adjustment has been made 
        /// </summary>
        public static double StandardCentreDistanceA(InvoluteGear g1, InvoluteGear g2) =>
            ((g1.TeethZ + g2.TeethZ) / (2 * Math.Cos(Radians(g1.HelixAngleBeta)))) * g1.ModeuleM;

        /// <summary>
        /// Involute function for working pressure angle
        /// </summary>
        public static double InvAlphaW(InvoluteGear g1, InvoluteGear g2) =>
            Math.Tan(Point.Radians(AlphaW(g1, g2))) - Point.Radians(AlphaW(g1, g2));


        /// <summary>
        /// The total sum coefficient of profile shifts including any allowance for backlash
        /// </summary>
        public static double SigmaX(InvoluteGear g1, InvoluteGear g2) =>
            ((g1.TeethZ + g2.TeethZ) * (InvAlphaW(g1, g2) - InvAlpha(g1)) /
                (2 * Math.Tan(Radians(g1.PressureAngleAlpha))) + XMod(g1, g2));


        /// <summary>
        /// The calculated profile shift required to achieve the desired circumferential backlash
        /// </summary>
        public static double XMod(InvoluteGear g1, InvoluteGear g2) => -g1.Pair.CircularBacklashBc /
                                                                       (2 * g1.ModeuleM *
                                                                        Math.Tan(Radians(g1.PressureAngleAlpha))) *
                                                                       Math.Cos(Radians(AlphaW(g1, g2))) /
                                                                       Math.Cos(Radians(g1.PressureAngleAlpha));


        /// <summary>
        /// Working Pressure Angle of the gear pair
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns></returns>
        public static double AlphaW(InvoluteGear g1, InvoluteGear g2) =>
            Degrees(
                Math.Acos((g1.TeethZ + g2.TeethZ) * Math.Cos(Radians(AlphaT(g1)))
                          /
                          ((g1.TeethZ + g2.TeethZ) + (2 * CentreDistanceIncrementFactorY(g1, g2) *
                                                      Math.Cos(Radians(g1.HelixAngleBeta))))
                ));


        /// <summary>
        /// Centre Distance Increment Factor for the gear pair
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns></returns>
        public static double CentreDistanceIncrementFactorY(InvoluteGear g1, InvoluteGear g2) =>
            (g1.Pair.WorkingCentreDistanceAw / g1.ModeuleM) -
            ((g1.TeethZ + g2.TeethZ) / (2 * Math.Cos(Radians(g1.HelixAngleBeta))));


        /// <summary>
        /// Reeturns Tip or Addendum diameter of g1
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns></returns>
        public static double AddendumDiameterDa(InvoluteGear g1, InvoluteGear g2) =>
            ReferenceDiameterD(g1) + 2 * ((1 + CentreDistanceIncrementFactorY(g1, g2) - g2.ProfileShiftX) * g1.ModeuleM);


        /// <summary>
        /// Reeturns Tip or Addendum diameter of g1
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns></returns>
        public static double AddendumRadiusRa(InvoluteGear g1, InvoluteGear g2) => AddendumDiameterDa(g1, g2) / 2;


        /// <summary>
        /// Working Pitch Diameter
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double WorkingPitchDiameterDw(InvoluteGear g1, InvoluteGear g2) =>
            BaseDiameterDb(g1) / Math.Cos(Radians(AlphaW(g1, g2)));

        /// <summary>
        /// Utility function
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        private static double SquareRootOfSquares(double r1, double r2) => Math.Sqrt(r1 * r1 - r2 * r2);


        /// <summary>
        /// Half Tooth Angle At Reference Diameter (Pitch circle)
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double Theta(InvoluteGear g1, InvoluteGear g2) =>
            90 / g1.TeethZ + 360 * (g1.ProfileShiftX + XMod(g1, g2)) *
            Math.Tan(Radians(AlphaT(g1))) /
            (Math.PI * g1.TeethZ);


        /// <summary>
        /// Angle by which involute has to be rotated to form opposing tooth flank
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double RotateDegrees(InvoluteGear g1, InvoluteGear g2) => (Theta(g1, g2) + Alpha1(g1)) * 2;

        /// <summary>
        /// The maximum profile shift allowable before undercutting occurs
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double ProfileShiftWithoutUndercutX(InvoluteGear g) =>
            1 - g.TeethZ / 2 * Math.Pow(Math.Sin(Point.Radians(g.PressureAngleAlpha)), 2);

        /// <summary>
        /// Calculates the axial pitch of the specified gear 
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double AxialPitch(InvoluteGear g) =>
            TransverseModuleMt(g) / Math.Cos(Point.Radians(g.HelixAngleBeta)) * Math.PI /
            Math.Tan(Point.Radians(g.HelixAngleBeta));

        /// <summary>
        /// Calculates the helix pitch length for the specified gear.
        /// In Alibre this is used to define the pitch of the helical boss extruded to form an individual tooth 
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double HelixPitchLength(InvoluteGear g) => AxialPitch(g) * g.TeethZ;

        /// <summary>
        /// The Transverse or helical Pressure Angle
        /// </summary>
        public static double AlphaT(InvoluteGear g) =>
            Degrees(Math.Atan(Math.Tan(Radians(g.PressureAngleAlpha)) / Math.Cos(Radians(g.HelixAngleBeta))));

        public static double Alpha1(InvoluteGear g) => Degrees(
            Math.Sqrt(ReferenceDiameterD(g) * ReferenceDiameterD(g) - BaseDiameterDb(g) * BaseDiameterDb(g)) /
            BaseDiameterDb(g)) - AlphaT(g);

        /// <summary>
        /// Involute function for standard pressure angle
        /// </summary>
        public static double InvAlpha(InvoluteGear g) => Math.Tan(Radians(AlphaT(g))) - Radians(AlphaT(g));

        /// <summary>
        /// Root diameter of the given gear
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double RootDiameterDr(InvoluteGear g) =>
            ReferenceDiameterD(g) + 2 * g.ModeuleM * (-1.25 + g.ProfileShiftX);

        /// <summary>
        /// Base diameter of the given gear
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double BaseDiameterDb(InvoluteGear g) => ReferenceDiameterD(g) * Math.Cos(Radians(AlphaT(g)));

        /// <summary>
        /// Base Radius of the given gear
        /// </summary>
        public static double BaseRadiusRb(InvoluteGear g) => BaseDiameterDb(g) / 2;


        /// <summary>
        /// Reference or Standard pitch diameter of the given gear
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double ReferenceDiameterD(InvoluteGear g) =>
            g.ModeuleM * g.TeethZ / Math.Cos(Radians(g.HelixAngleBeta));

        /// <summary>
        /// Transverse or axial module of the given gear
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double TransverseModuleMt(InvoluteGear g) => g.ModeuleM / Math.Cos(Radians(g.HelixAngleBeta));


        /// <summary>
        /// Calculated contact ratio of the pinion, wheel pair.
        /// The contact ratio should not fall below 1.2. 
        /// </summary>
        /// <returns></returns>
        public static double ContactRatio(InvoluteGear g1, InvoluteGear g2)
        {
            var num1 = SquareRootOfSquares((AddendumDiameterDa(g1, g2) + XMod(g1, g2)) / 2, BaseDiameterDb(g1) / 2);
            var num2 = SquareRootOfSquares((AddendumDiameterDa(g2, g1) + XMod(g1, g2)) / 2, BaseDiameterDb(g2) / 2);
            var num3 = g1.Pair.WorkingCentreDistanceAw * Math.Sin(Radians(AlphaW(g1, g2)));
            var num4 = TransverseModuleMt(g1) * Math.PI * Math.Cos(Radians(AlphaT(g1)));

            return (num1 + num2 - num3) / num4;
        }

        #region Root Fillet Parameters

        /// <summary>
        /// Fillet Diameter
        /// </summary>
        public static double RootFilletDiameter(InvoluteGear g1) => g1.ModeuleM * g1.RootFilletFactorRf;


        /// <summary>
        /// Returns the angle in radians to the centre of the root fillet circle
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static double AngleToFilletCentre(InvoluteGear g) =>
            Math.Asin(RootFilletDiameter(g) / 2 / ((RootDiameterDr(g) + RootFilletDiameter(g)) / 2));

        public static double RootFilletCentreXd(InvoluteGear g) => (RootFilletDiameter(g) + RootDiameterDr(g)) / 2 *
                                                                   Math.Cos(AngleToFilletCentre(g));

        public static double RootFilletCentreYd(InvoluteGear g) => -(RootFilletDiameter(g) + RootDiameterDr(g)) / 2 *
                                                                   Math.Sin(AngleToFilletCentre(g));

        public static double RootFilletStartXa(InvoluteGear g) => RootDiameterDr(g) / 2 * Math.Cos(AngleToFilletCentre(g));

        public static double RootFilletStartYa(InvoluteGear g) =>
            -RootDiameterDr(g) / 2 * Math.Sin(AngleToFilletCentre(g));

        public static double RootFilletEndXe(InvoluteGear g) => RootDiameterDr(g) / 2 * Math.Tan(AngleToFilletCentre(g)) +
                                                                RootDiameterDr(g) / 2 / Math.Cos(AngleToFilletCentre(g));

        public static double RootFilletEndYe(InvoluteGear g) => 0;

        public static Point RootFilletEndPoint(InvoluteGear g) => new(RootFilletEndXe(g), RootFilletEndYe(g));
        public static Point RootFilletStartPoint(InvoluteGear g) => new(RootFilletStartXa(g), RootFilletStartYa(g));
        public static Point RootFilletCentrePoint(InvoluteGear g) => new(RootFilletCentreXd(g), RootFilletCentreYd(g));

        #endregion

        #region Degree Radian Conversion

        /// <summary>
        /// Converts the given angle in Degrees ° to Radians
        /// Uses the formula Radians = Degrees * Pi/180
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private static double Radians(double angle)
        {
            return angle * (Math.PI / 180.0);
        }

        /// <summary>
        /// Converts the given angle in Radians to Degrees
        /// Uses the formula Degrees = Radians * 180/Pi
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        private static double Degrees(double radians)
        {
            return radians * (180.0 / Math.PI);
        }

        #endregion
    }
}