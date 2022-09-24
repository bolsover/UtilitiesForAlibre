using System;


namespace Bolsover.Gear
{
    public class GearPair
    {
        private InvoluteGear g1;
        private InvoluteGear g2;
        private double deltaX = 50; // distribution of profile shift X between g1, g2
        private double circularBacklashbc; // circular backlash required
        private double workingCentreDistanceaw; //working centre distance

        public GearPair(InvoluteGear g1, InvoluteGear g2, double aw, double circularBacklashBc)
        {
            this.g1 = g1;
            this.g2 = g2;
            workingCentreDistanceaw = aw;
            circularBacklashbc = circularBacklashBc;
            this.g1.Updated += OnUpdated;
            this.g2.Updated += OnUpdated;
        }


        public event EventHandler Updated;

        private void OnUpdated(object sender, EventArgs e)
        {
            Updated?.Invoke(this, EventArgs.Empty);
        }


        public InvoluteGear G1
        {
            get => g1;
            set
            {
                g1 = value;

                OnUpdated(this, null);
            }
        }

        public InvoluteGear G2
        {
            get => g2;
            set
            {
                g2 = value;
                OnUpdated(this, null);
            }
        }


        public double DeltaX // distribution of profile shift X between g1, g2
        {
            get => deltaX;
            set
            {
                deltaX = value;

                G2.ProfileShiftX = SigmaX * DeltaX / 100;
                G1.ProfileShiftX = SigmaX - G2.ProfileShiftX;
                OnUpdated(this, null);
            }
        }

        public double CircularBacklashBc // circular backlash required
        {
            get => circularBacklashbc;
            set
            {
                circularBacklashbc = value;
                OnUpdated(this, null);
            }
        }

        public double WorkingCentreDistanceAw // working centre distance
        {
            get => workingCentreDistanceaw;
            set
            {
                workingCentreDistanceaw = value;
                OnUpdated(this, null);
            }
        }


        /// <summary>
        /// Involute function for working pressure angle
        /// </summary>
        public double InvAlphaW =>
            Math.Tan(Point.Radians(AlphaW)) - Point.Radians(AlphaW);


        /// <summary>
        /// The total sum coefficient of profile shifts including any allowance for backlash
        /// </summary>
        public double SigmaX =>
            ((G1.TeethZ + G2.TeethZ) * (InvAlphaW - G1.InvAlpha) /
                (2 * Math.Tan(Radians(G1.PressureAngleAlpha))) + XMod);


        /// <summary>
        /// The calculated profile shift required to achieve the desired circumferential backlash
        /// </summary>
        public double XMod => -CircularBacklashBc /
                              (2 * G1.ModeuleM * Math.Tan(Radians(G1.PressureAngleAlpha))) *
                              Math.Cos(Radians(AlphaW)) /
                              Math.Cos(Radians(G1.PressureAngleAlpha));


        /// <summary>
        /// Working Pressure Angle
        /// </summary>
        public double AlphaW =>
            Degrees(
                Math.Acos((G1.TeethZ + G2.TeethZ) * Math.Cos(Radians(G1.AlphaT))
                          /
                          ((G1.TeethZ + G2.TeethZ) + (2 * CentreDistanceIncrementFactorY * Math.Cos(Radians(G1.HelixAngleBeta))))
                ));


        /// <summary>
        /// Centre Distance Increment Factor
        /// </summary>
        public double CentreDistanceIncrementFactorY => (WorkingCentreDistanceAw / G1.ModeuleM) - ((G1.TeethZ + G2.TeethZ) / (2 * Math.Cos(Radians(G1.HelixAngleBeta))));


        /// <summary>
        /// Standard Centre Distance is the normal distance between pinion and wheel centres when no profile adjustment has been made 
        /// </summary>

        public double StandardCentreDistanceA => ((G1.TeethZ + G2.TeethZ) / (2 * Math.Cos(Radians(G1.HelixAngleBeta)))) * G1.ModeuleM;


        /// <summary>
        /// Reeturns Tip or Addendum diameter of g1
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns></returns>
        public double AddendumDiameterDa(InvoluteGear g1, InvoluteGear g2) =>
            g1.ReferenceDiameterD + 2 * ((1 + CentreDistanceIncrementFactorY - g2.ProfileShiftX) * G1.ModeuleM);


        /// <summary>
        /// Reeturns Tip or Addendum diameter of g1
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns></returns>
        public double AddendumRadiusRa(InvoluteGear g1, InvoluteGear g2) => AddendumDiameterDa(g1, g2) / 2;


        /// <summary>
        /// Working Pitch Diameter
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public double WorkingPitchDiameterDw(InvoluteGear g) => g.BaseDiameterDb / Math.Cos(Radians(AlphaW));

        /// <summary>
        /// Utility function
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        private double SquareRootOfSquares(double r1, double r2) => Math.Sqrt(r1 * r1 - r2 * r2);


        /// <summary>
        /// Calculated contact ratio of the pinion, wheel pair.
        /// The contact ratio should not fall below 1.2. 
        /// </summary>
        /// <returns></returns>
        public double ContactRatio()
        {
            var num1 = SquareRootOfSquares((AddendumDiameterDa(G1, G2) + XMod) / 2, G1.BaseDiameterDb / 2);
            var num2 = SquareRootOfSquares((AddendumDiameterDa(G2, G1) + XMod) / 2, G2.BaseDiameterDb / 2);
            var num3 = WorkingCentreDistanceAw * Math.Sin(Radians(AlphaW));
            var num4 = G1.TransverseModuleMt * Math.PI * Math.Cos(Radians(G1.AlphaT));

            return (num1 + num2 - num3) / num4;
        }

        /// <summary>
        /// Half Tooth Angle At Reference Diameter (Pitch circle)
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public double Theta(InvoluteGear g) =>
            90 / g.TeethZ + 360 * (g.ProfileShiftX + XMod) *
            Math.Tan(Radians(g.AlphaT)) /
            (Math.PI * g.TeethZ);


        /// <summary>
        /// Angle by which involute has to be rotated to form opposing tooth flank
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public double RotateDegrees(InvoluteGear g) => (Theta(g) + g.Alpha1) * 2;

        #region Root Fillet Parameters

        /// <summary>
        /// Fillet Diameter
        /// </summary>
        public double RootFilletDiameter => G1.ModeuleM * G1.RootFilletFactorRf;


        /// <summary>
        /// Returns the angle in radians to the centre of the root fillet circle
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public double AngleToFilletCentre(InvoluteGear g) =>
            Math.Asin(RootFilletDiameter / 2 / ((g.RootDiameterDr + RootFilletDiameter) / 2));

        public double RootFilletCentreXd(InvoluteGear g) => (RootFilletDiameter + g.RootDiameterDr) / 2 *
                                                            Math.Cos(AngleToFilletCentre(g));


        public double RootFilletCentreYd(InvoluteGear g) => -(RootFilletDiameter + g.RootDiameterDr) / 2 *
                                                            Math.Sin(AngleToFilletCentre(g));


        public double RootFilletStartXa(InvoluteGear g) => g.RootDiameterDr / 2 * Math.Cos(AngleToFilletCentre(g));

        public double RootFilletStartYa(InvoluteGear g) =>
            -g.RootDiameterDr / 2 * Math.Sin(AngleToFilletCentre(g));

        public double RootFilletEndXe(InvoluteGear g) => g.RootDiameterDr / 2 * Math.Tan(AngleToFilletCentre(g)) +
                                                         g.RootDiameterDr / 2 / Math.Cos(AngleToFilletCentre(g));


        public double RootFilletEndYe(InvoluteGear g) => 0;

        public Point RootFilletEndPoint(InvoluteGear g) => new(RootFilletEndXe(g), RootFilletEndYe(g));
        public Point RootFilletStartPoint(InvoluteGear g) => new(RootFilletStartXa(g), RootFilletStartYa(g));
        public Point RootFilletCentrePoint(InvoluteGear g) => new(RootFilletCentreXd(g), RootFilletCentreYd(g));

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

        public Point CoordinateIntersectionCircleWithInvolute(double baseRadius, double circleRadius)
        {
            var num1 = Math.Acos(baseRadius / circleRadius); // pressure angle at circleRadius in radians
            var num2 = Math.Tan(num1) - num1; // involute function of num1
            var x = circleRadius * Math.Cos(num2); // X location
            var y = circleRadius * Math.Sin(num2);
            return new Point(x, y);
        }
    }
}