using System;
using System.Collections.Generic;
using System.Text;
using AlibreX;


namespace Bolsover.Gears
{
    /// <summary>
    /// Profile Shifted Spur Gears are always considered as a pair comprised of a pinion and a wheel.
    /// Profile shifting is often used to adjust the centre distance of two gears but can also be used to prevent
    /// undercut in smaller gears and to increase tooth strength.
    /// The Pinion is usually smaller than the Wheel.
    /// Both gears must have the same normal Module but can have different profile shifts.
    /// In the meshing of profile shifted gears, it is the operating pitch circles that are in contact. The standard
    /// pitch circles are no longer of significance; it is the operating pressure angle that matters.
    /// A standard gear is profile shifted gear with 0 coefficient of shift that is x1 = x2 = 0.
    /// The total coefficient of profile shift is usually in the region of 1.
    /// There are differing theories on how to distribute the sum of the coefficient of profile shift. Usually, the
    /// pinion is given sufficient shift to prevent undercut with the remainder given to the wheel. 
    /// </summary>
    public class ProfileShiftSpurGearParameters
    {
        private double teethZ1;
        private double teethZ2;
        private double workingCentreDistanceAw;
        private double circularBacklashReqdBc;
        private double distributionOfProfileShift;
        private double moduleMn;
        private double filletFactor = 0.38;
        private GearType type;
        private double pressureAngleAlpha;
        private Point centre;
        private double helixAngle = 0;


        #region CommonToBothGears

        public string commonData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Common Data\n");
            sb.Append("Module: " + ModuleMn + "\n");
            sb.Append("Transverse Module: " + ModuleMt + "\n");
            sb.Append("Centre: " + Centre.X + ", " + Centre.Y + "\n");
            sb.Append("PressureAngle: " + PressureAngleAlpha + "\n");
            sb.Append("DistributionOfProfileShift: " + DistributionOfProfileShift + "\n");
            sb.Append("CircularBacklashReqdBc: " + CircularBacklashReqdBc + "\n");
            sb.Append("ProfileShiftXMod: " + ProfileShiftXMod + "\n");
            sb.Append("WorkingCentreDistanceAw: " + WorkingCentreDistanceAw + "\n");
            sb.Append("StandardCentreDistanceA: " + StandardCentreDistanceA + "\n");
            sb.Append("CentreDistanceIncrementFactorY: " + CentreDistanceIncrementFactorY + "\n");
            sb.Append("InvoluteFunctionInvAlpha: " + InvoluteFunctionInvAlpha + "\n");
            sb.Append("InvoluteFunctionInvAlphaW: " + InvoluteFunctionInvAlphaW + "\n");

            sb.Append("ContactRatio: " + ContactRatio() + "\n\n\n");

            return sb.ToString();
        }

        public event EventHandler Updated;

        private void Update()
        {
            OnUpdated();
        }

        private void OnUpdated()
        {
            Updated?.Invoke(this, EventArgs.Empty);
        }

        public double FilletFactor
        {
            get => filletFactor;
            set => filletFactor = value;
        }

        public GearType Type
        {
            get => type;
            set
            {
                type = value;
                Update();
            }
        }


        public IADDesignSession PinionSession { get; set; }
        public IADDesignSession WheelSession { get; set; }

        public IADRoot Root { get; set; }

        public Point Centre
        {
            get => centre;
            set
            {
                centre = value;
                Update();
            }
        }

        public double ModuleMn
        {
            get => moduleMn;
            set
            {
                moduleMn = value;
                Update();
            }
        }
        
        public double HelixAngle
        {
            get => helixAngle;
        set
        {
            helixAngle = value;
            Update();
        }
         
        }


        public double PressureAngleAlpha
        {
            get => pressureAngleAlpha;
            set
            {
                pressureAngleAlpha = value;
                Update();
            }
        }

        public double DistributionOfProfileShift
        {
            get => distributionOfProfileShift;
            set
            {
                distributionOfProfileShift = value;

                Update();
            }
        }


        public double CircularBacklashReqdBc
        {
            get => circularBacklashReqdBc;
            set
            {
                circularBacklashReqdBc = value;
                Update();
            }
        }

        public double WorkingCentreDistanceAw
        {
            get => workingCentreDistanceAw;
            set
            {
                workingCentreDistanceAw = value;
                Update();
            }
        }

        /// <summary>
        /// Transverse Module
        /// </summary>
        public double ModuleMt => ModuleMn / Math.Cos(Point.Radians(HelixAngle));

        public double RadialPressureAngle => Point.Degrees(Math.Atan(Math.Tan(Point.Radians(PressureAngleAlpha)) / Math.Cos(Point.Radians(HelixAngle))));


        public double CentreDistanceIncrementFactorY => (WorkingCentreDistanceAw / ModuleMn) - ((TeethZ1 + TeethZ2) / (2 * Math.Cos(Point.Radians(HelixAngle))));
   //     public double CentreDistanceIncrementFactorY =>  (TeethZ1 + TeethZ2) / 2 * Math.Cos(Point.Radians(HelixAngle)) * (Math.Cos(Point.Radians(RadialPressureAngle))/Math.Cos(Point.Radians(WorkingPressureAngleAw)) -1);


        /// <summary>
        /// Involute function for working pressure angle
        /// </summary>
        public double InvoluteFunctionInvAlphaW =>
            Math.Tan(Point.Radians(WorkingPressureAngleAw)) - Point.Radians(WorkingPressureAngleAw);

        /// <summary>
        /// Involute function for standard pressure angle
        /// </summary>
        public double InvoluteFunctionInvAlpha => Math.Tan(Point.Radians(RadialPressureAngle)) - Point.Radians(RadialPressureAngle);

        /// <summary>
        /// Standard Centre Distance is the normal distance between pinion and wheel centres when no profile adjustment has been made 
        /// </summary>
        ///  public double StandardCentreDistanceA => ModuleMn * ((TeethZ1 + TeethZ2) / 2);
        public double StandardCentreDistanceA => ((TeethZ1 + TeethZ2) / (2 * Math.Cos(Point.Radians(HelixAngle)))) * ModuleMn;

        /// <summary>
        /// Working Pressure Angle is the the angle calculated when the Working Centre Distance has been changed from the Standard
        /// </summary>
        // public double WorkingPressureAngleAw =>
        //     Point.Degrees(
        //         Math.Acos(StandardCentreDistanceA / WorkingCentreDistanceAw * Math.Cos(Point.Radians(RadialPressureAngle))));

        public double WorkingPressureAngleAw =>
            Point.Degrees(
                Math.Acos((TeethZ1 + TeethZ2) * Math.Cos(Point.Radians(RadialPressureAngle))
                          /
                          ((TeethZ1 + TeethZ2) + (2 * CentreDistanceIncrementFactorY * Math.Cos(Point.Radians(HelixAngle))))
                ));

        /// <summary>
        /// Utility function
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        private double SquareRootOfSquares(double r1, double r2) => Math.Sqrt(r1 * r1 - r2 * r2);


        /// <summary>
        /// The total sum coefficient of profile shifts including any allowance for backlash
        /// </summary>
        public double SumCoefficientOfProfileShift =>
            ((TeethZ1 + TeethZ2) * (InvoluteFunctionInvAlphaW - InvoluteFunctionInvAlpha) /
            (2 * Math.Tan(Point.Radians(PressureAngleAlpha))) + ProfileShiftXMod) ;

        /// <summary>
        /// The calculated profile shift required to achieve the desired circumferential backlash
        /// </summary>
        public double ProfileShiftXMod => -CircularBacklashReqdBc /
                                          (2 * ModuleMn * Math.Tan(Point.Radians(PressureAngleAlpha))) *
                                          Math.Cos(Point.Radians(WorkingPressureAngleAw)) /
                                          Math.Cos(Point.Radians(PressureAngleAlpha));

        /// <summary>
        /// Calculated contact ratio of the pinion, wheel pair.
        /// The contact ratio should not fall below 1.2. 
        /// </summary>
        /// <returns></returns>
        public double ContactRatio()
        {
            var num1 = SquareRootOfSquares((TipDiameterDa1 + ProfileShiftXMod) / 2, BaseDiameterDb1 / 2);
            var num2 = SquareRootOfSquares((TipDiameterDa2 + ProfileShiftXMod) / 2, BaseDiameterDb2 / 2);
            var num3 = WorkingCentreDistanceAw * Math.Sin(Point.Radians(WorkingPressureAngleAw));
            var num4 = ModuleMt * Math.PI * Math.Cos(Point.Radians(RadialPressureAngle));
            
            return (num1 + num2 - num3) / num4 ;
        }


        /// <summary>
        /// Calculates the coordinates (X,Y) of points on an involute curve given the radius of the involute base
        /// circle, the radius of the tip circle of the gear and the number of steps required.
        /// 
        /// The base circle is given as reference pitch circle diameter as db = d cos(a).
        /// Where:
        /// db = Base circle diameter
        /// d is the reference pitch circle diameter (tooth count * module size)
        /// a = Gear pressure angle;
        /// 
        /// The tip circle is usually the reference pitch circle diameter of the gear given as dt = z * m + 2ha
        /// Where:
        /// dt = tip circle diameter
        /// z = number of teeth
        /// m = module size in mm
        /// ha = addendum (usually 1m)
        ///
        /// Steps is the number of points to be returned for an involute curve extending from the base to the tip radii.
        /// For 25 steps, the first step (0) will be on the base circle, the last step (24) will be on the tip circle.
        /// Intervening points will be regularly spaced from the base circle.
        ///  
        /// </summary>
        /// <param name="baseRadius"></param>
        /// <param name="tipRadius"></param>
        /// <param name="steps"></param>
        /// <returns></returns>
        public static List<Point> InvolutePoints(double baseRadius, double tipRadius, int steps)
        {
            var points = new List<Point>(steps);
            var stepSize = (tipRadius - baseRadius) / steps;

            for (var i = 0; i < steps + 1; i++)
            {
                var step = baseRadius + i * stepSize; // dimension of current step
                var alpha = Math.Acos(baseRadius / step);
                var invAlpha = Math.Tan(alpha) - alpha; // involute function
                var x = step * Math.Cos(invAlpha); // X coordinate
                var y = step * Math.Sin(invAlpha); // Y coordinate
                points.Add(new Point(x, y));
            }

            return points;
        }


        /// <summary>
        /// Returns the angle to a Point(x,y) in a circle diameter.
        /// </summary>
        /// <param name="circleCentre"></param>
        /// <param name="pointOnCircleDiameter"></param>
        /// <returns></returns>
        public double AngleToPointOnCircle(Point circleCentre, Point pointOnCircleDiameter) =>
            Math.Atan2(pointOnCircleDiameter.Y - circleCentre.Y, pointOnCircleDiameter.X - circleCentre.X);


        /// <summary>
        /// Trims the given List<Point> of involute points to remove any points below the intersection with the root fillet.
        /// A calculated (interpolated) point will be added to ensure the root fillet ends where the involute curve starts.
        /// </summary>
        /// <param name="involutePoints"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public List<Point> PointsFromIntersectionWithRootFilletPointE(List<Point> involutePoints, double radius)
        {
            var resultList = new List<Point>();
            var centre = new Point(0, 0);
            Point priorPoint = null;
            for (var i = 0; i < involutePoints.Count; i++)
            {
                var point = involutePoints[i];
                if (priorPoint != null && IsInsideCircle(centre, radius, priorPoint) &&
                    !IsInsideCircle(centre, radius, point))
                {
                    var Intersection = new Point();
                    var result = Intersect(centre, radius,
                        priorPoint, point, ref Intersection);
                    if (result == 0)
                    {
                        resultList.Add(Intersection);
                    }
                }

                if (!IsInsideCircle(centre, radius, point))
                {
                    resultList.Add(point);
                }

                priorPoint = point;
            }

            return resultList;
        }

        /// <summary>
        /// Method to calculate if a specified checkPoint is within a circle 
        /// </summary>
        /// <param name="CirclePos"></param>
        /// <param name="CircleRad"></param>
        /// <param name="checkPoint"></param>
        /// <returns>Return bool true if the checkPoint is within the specifies circle. Otherwise false</returns>
        private bool IsInsideCircle(Point CirclePos, double CircleRad, Point checkPoint)
        {
            return (Math.Sqrt(Math.Pow(CirclePos.X - checkPoint.X, 2) +
                              Math.Pow(CirclePos.Y - checkPoint.Y, 2)) < CircleRad);
        }

        /// <summary>
        // Method to calculate the absolute position where a line intersects a circle.
        // The position is available in the ref Point Intersection.
        // Method will return -1 if:
        // 1 The line is tangential to the circle
        // 2 One or both points are exactly ON the circle
        // 3 The line intersects at two points
        //
        //This function takes the intersection point as a ref parameter and returns either -1 (no intersection) or 0 (intersection found). I used an int return value in case you want to extend this to differentiate the edge cases. The intersection is calculated from elementary geometry - remember that a line is expressed as (see : Slope Intercept and Point Slope Form )
        //
        // y = M*x + B
        //     and a circle (centered at (C.x, C.y) with radius r) is
        //
        // (x - C.x)^2 + (y - C.y)^2 - r^2 = 0
        // You solve this system of equations by substitution :
        //
        // (x - C.x)^2 + ((M*x + B) - C.y)^2 - r^2 = 0
        // Expanding and collecting terms you get :
        //
        // (1+M^2)x^2 + 2*(MB - MC.y - C.x)x + (C.x^2 + C.y^2 + B^2 - r^2 - 2B*C.y) = 0
        // This is a standard quadratic equation of the form
        //
        //     ax^2 + bx + c = 0
        // where :
        // a = (1+M^2)
        // b = 2*(MB - MC.y - C.x)
        // c = (C.x^2 + C.y^2 + B^2 - r^2 - 2B*C.y)
        // Which can be solved by the quadratic formula (see : Quadratic Formula ):
        //
        // x = (-b ± Sqrt(b^2 - 4ac))/(2a)
        // This gives two roots for the infinite line on which our line segment lies - we do a final check above to make sure that we choose the solution for our specific line segment.
        ///
        /// 
        /// </summary>
        /// <param name="CirclePos"></param>
        /// <param name="CircleRad"></param>
        /// <param name="LineStart"></param>
        /// <param name="LineEnd"></param>
        /// <param name="Intersection"></param>
        /// <returns>Returns 0 if a solution is found otherwise returns -1</returns>
        private int Intersect(Point CirclePos, double CircleRad,
            Point LineStart, Point LineEnd, ref Point Intersection)
        {
            if (IsIntersecting(CirclePos, CircleRad, LineStart, LineEnd))
            {
                //Calculate terms of the linear and quadratic equations
                var m = (LineEnd.Y - LineStart.Y) / (LineEnd.X - LineStart.X);
                var d = LineStart.Y - m * LineStart.X;
                var a = 1 + m * m;
                var b = 2 * (m * d - m * CirclePos.Y - CirclePos.X);
                var c = CirclePos.X * CirclePos.X + d * d + CirclePos.Y * CirclePos.Y -
                        CircleRad * CircleRad - 2 * d * CirclePos.Y;
                // solve quadratic equation
                var sqRtTerm = Math.Sqrt(b * b - 4 * a * c);
                var x = (-b + sqRtTerm) / (2 * a);
                // make sure we have the correct root for our line segment
                if (x < Math.Min(LineStart.X, LineEnd.X) ||
                    x > Math.Max(LineStart.X, LineEnd.X))
                {
                    x = (-b - sqRtTerm) / (2 * a);
                }

                //solve for the y-component
                var y = m * x + d;
                // Intersection Calculated
                Intersection = new Point(x, y);
                return 0;
            }

            // Line segment does not intersect at one point.  It is either 
            // fully outside, fully inside, intersects at two points, is 
            // tangential to, or one or more points is exactly on the 
            // circle radius.
            Intersection = new Point(0, 0);
            return -1;
        }

        /// <summary>
        /// Method to calculate if a line between two points intersects a given circle
        /// </summary>
        /// <param name="CirclePos"></param>
        /// <param name="CircleRad"></param>
        /// <param name="LineStart"></param>
        /// <param name="LineEnd"></param>
        /// <returns></returns>
        private bool IsIntersecting(Point CirclePos, double CircleRad, Point LineStart,
            Point LineEnd)
        {
            return (IsInsideCircle(CirclePos, CircleRad, LineStart) ^
                    IsInsideCircle(CirclePos, CircleRad, LineEnd));
        }

        public double FilletDiameter => ModuleMn * FilletFactor;

        #endregion

        #region Gear1

        public string PinionData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Pinion Data\n");
            sb.Append("TeethZ1: " + TeethZ1 + "\n");
            sb.Append("ProfileShiftX1: " + ProfileShiftX1 + "\n");
            sb.Append("ReferenceDiameterD1: " + ReferenceDiameterD1 + "\n");
            sb.Append("TipDiameterDa1: " + TipDiameterDa1 + "\n");
            sb.Append("RootDiameterDr1: " + RootDiameterDr1 + "\n");
            sb.Append("BaseDiameterDb1: " + BaseDiameterDb1 + "\n");
            // sb.Append("BasePitchPb1: " + BasePitchPb1 + "\n");
            // sb.Append("Alpha1: " + Alpha1 + "\n");
            // sb.Append("RotateDegrees1: " + RotateDegrees1 + "\n");
            // sb.Append("CircularToothThicknessS1: " + CircularToothThicknessS1 + "\n");
            // sb.Append("TeethWithoutUndercutZc1: " + TeethWithoutUndercutZc1 + "\n");
            sb.Append("AngleToFilletCentre1: " + AngleToFilletCentre1 + "\n");
            sb.Append("HalfToothAngleAtPitchCircleTheta1: " + HalfToothAngleAtPitchCircleTheta1 + "\n");
            // sb.Append("CircularToothThicknessS1: " + CircularToothThicknessS1 + "\n\n\n");
            return sb.ToString();
        }

        public double TeethZ1
        {
            get => teethZ1;
            set
            {
                teethZ1 = value;
                Update();
            }
        }

        public double ProfileShiftX1 => SumCoefficientOfProfileShift - ProfileShiftX2;
            
            
        public double ReferenceDiameterD1 => ModuleMn * TeethZ1 / Math.Cos(Point.Radians(HelixAngle));
        public double BaseDiameterDb1 => ReferenceDiameterD1 * Math.Cos(Point.Radians(RadialPressureAngle));

        public double TipDiameterDa1 =>
            ReferenceDiameterD1 + 2 * ((1 + CentreDistanceIncrementFactorY - ProfileShiftX2) * ModuleMn);

        // public double BasePitchPb1 => ModuleMn * Math.PI * Math.Cos(Point.Radians(PressureAngleAlpha));
        public double WorkingPitchDiameterDw1 => BaseDiameterDb1 / Math.Cos(Point.Radians(WorkingPressureAngleAw));
        public double RootDiameterDr1 => ReferenceDiameterD1 + 2 * ModuleMn * (-1.25 + ProfileShiftX1);

        public double Alpha1 => Point.Degrees(
            Math.Sqrt(ReferenceDiameterD1 * ReferenceDiameterD1 - BaseDiameterDb1 * BaseDiameterDb1) /
            BaseDiameterDb1) - RadialPressureAngleAlphaT;

        public double RotateDegrees1 => (HalfToothAngleAtPitchCircleTheta1 + Alpha1) * 2;

        // /// <summary>
        // /// Tooth thickness at reference pitch circle.
        // /// </summary>
        // public double CircularToothThicknessS1 =>
        //     ModuleMn * (Math.PI / 2 + 2 * ProfileShiftX1 * Math.Tan(Point.Radians(PressureAngleAlpha)));

        // public double TeethWithoutUndercutZc1 =>
        //     2 * (1 - ProfileShiftX1) / Math.Pow(Math.Sin(Point.Radians(PressureAngleAlpha)), 2);

        public double AngleToFilletCentre1 =>
            Math.Asin(FilletDiameter / 2 / ((RootDiameterDr1 + FilletDiameter) / 2));

        public double RootFilletXd1 => (FilletDiameter + RootDiameterDr1) / 2 *
                                       Math.Cos(AngleToFilletCentre1);

        public double RootFilletYd1 => -((FilletDiameter + RootDiameterDr1) / 2 *
                                         Math.Sin(AngleToFilletCentre1));


        public double RootFilletXa1 => RootDiameterDr1 / 2 * Math.Cos(AngleToFilletCentre1);

        public double RootFilletYa1 =>
            -RootDiameterDr1 / 2 * Math.Sin(AngleToFilletCentre1);

        public Point PointE1 => new(RootFilletXe1, RootFilletYe1);
        public Point PointA1 => new(RootFilletXa1, RootFilletYa1);
        public Point PointD1 => new(RootFilletXd1, RootFilletYd1);

        public double RootFilletXe1 => RootDiameterDr1 / 2 * Math.Tan(AngleToFilletCentre1) +
                                       RootDiameterDr1 / 2 / Math.Cos(AngleToFilletCentre1);


        public double RootFilletYe1 => 0;


        public double HalfToothAngleAtPitchCircleTheta1 =>
            90 / TeethZ1 + 360 * (ProfileShiftX1 + ProfileShiftXMod) *
            Math.Tan(Point.Radians(RadialPressureAngleAlphaT)) /
            (Math.PI * TeethZ1);

        public List<Point> InvoluteCurvePoints1()
        {
            var points = InvolutePoints(BaseDiameterDb1 / 2, TipDiameterDa1 / 2, 25);

            return PointsFromIntersectionWithRootFilletPointE(points, RootFilletXe1);
        }

        #endregion


        #region Gear2

        public string WheelData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Wheel Data\n");
            sb.Append("TeethZ2: " + TeethZ1 + "\n");
            sb.Append("ProfileShiftX2: " + ProfileShiftX2 + "\n");

            sb.Append("ReferenceDiameterD2: " + ReferenceDiameterD2 + "\n");
            sb.Append("TipDiameterDa2: " + TipDiameterDa2 + "\n");
            sb.Append("RootDiameterDr2: " + RootDiameterDr2 + "\n");
            sb.Append("BaseDiameterDb2: " + BaseDiameterDb2 + "\n");
            // sb.Append("BasePitchPb2: " + BasePitchPb2 + "\n");
            // sb.Append("Alpha2: " + Alpha2 + "\n");
            // sb.Append("RotateDegrees2: " + RotateDegrees2 + "\n");
           
            // sb.Append("TeethWithoutUndercutZc2: " + TeethWithoutUndercutZc2 + "\n");
            sb.Append("AngleToFilletCentre2: " + AngleToFilletCentre2 + "\n");
            sb.Append("HalfToothAngleAtPitchCircleTheta2: " + HalfToothAngleAtPitchCircleTheta2 + "\n");
            // sb.Append("CircularToothThicknessS2: " + CircularToothThicknessS2 + "\n\n\n");
            return sb.ToString();
        }

        public double TeethZ2
        {
            get => teethZ2;
            set
            {
                teethZ2 = value;
                Update();
            }
        }

        public double ProfileShiftX2 => SumCoefficientOfProfileShift * DistributionOfProfileShift / 100;


        public double ReferenceDiameterD2 => ModuleMn * TeethZ2 /Math.Cos(Point.Radians(HelixAngle));

        public double BaseDiameterDb2 => ReferenceDiameterD2 * Math.Cos(Point.Radians(RadialPressureAngle));


        public double TipDiameterDa2 =>
            ReferenceDiameterD2 + 2 * ((1 + CentreDistanceIncrementFactorY - ProfileShiftX1) * ModuleMn);


        public double RootDiameterDr2 => ReferenceDiameterD2 + 2 * ModuleMn * (-1.25 + ProfileShiftX2);


        public double RotateDegrees2 => (HalfToothAngleAtPitchCircleTheta2 + Alpha2) * 2;


        public double Alpha2 => Point.Degrees(
            Math.Sqrt(ReferenceDiameterD2 * ReferenceDiameterD2 - BaseDiameterDb2 * BaseDiameterDb2) /
            BaseDiameterDb2) - RadialPressureAngleAlphaT;


        // public double BasePitchPb2 => ModuleMn * Math.PI * Math.Cos(Point.Radians(PressureAngleAlpha));


        public double WorkingPitchDiameterDw2 => BaseDiameterDb2 / Math.Cos(Point.Radians(WorkingPressureAngleAw));


        // public double TeethWithoutUndercutZc2 =>
        //     2 * (1 - ProfileShiftX2) / Math.Pow(Math.Sin(Point.Radians(PressureAngleAlpha)), 2);


        // /// <summary>
        // /// Tooth thickness at reference pitch circle.
        // /// </summary>
        // public double CircularToothThicknessS2 =>
        //     ModuleMn * (Math.PI / 2 + 2 * ProfileShiftX2 * Math.Tan(Point.Radians(PressureAngleAlpha)));


        public double HalfToothAngleAtPitchCircleTheta2 =>
            90 / TeethZ2 + 360 * (ProfileShiftX2 + ProfileShiftXMod) *
            Math.Tan(Point.Radians(RadialPressureAngleAlphaT)) /
            (Math.PI * TeethZ2);

        // public double ChordalToothThicknessSj1 =>
        //     TeethZ1 * ModuleMn * Math.Sin(Point.Radians(HalfToothAngleAtPitchCircleTheta1));
        //
        // public double ChordalToothThicknessSj2 =>
        //     TeethZ2 * ModuleMn * Math.Sin(Point.Radians(HalfToothAngleAtPitchCircleTheta2));


        public double ProfileShiftWithoutUndercutX1 =>
            1 - TeethZ1 / 2 * Math.Pow(Math.Sin(Point.Radians(PressureAngleAlpha)), 2);

        public double ProfileShiftWithoutUndercutX2 =>
            1 - TeethZ2 / 2 * Math.Pow(Math.Sin(Point.Radians(PressureAngleAlpha)), 2);


        public double AngleToFilletCentre2 =>
            Math.Asin(FilletDiameter / 2 / ((RootDiameterDr2 + FilletDiameter) / 2));

        public double RootFilletXd2 => (FilletDiameter + RootDiameterDr2) / 2 *
                                       Math.Cos(AngleToFilletCentre2);

        public double RootFilletYd2 => -((FilletDiameter + RootDiameterDr2) / 2 *
                                         Math.Sin(AngleToFilletCentre2));

        public double RootFilletXa2 => RootDiameterDr2 / 2 * Math.Cos(AngleToFilletCentre2);

        public double RootFilletYa2 =>
            -RootDiameterDr2 / 2 * Math.Sin(AngleToFilletCentre2);


        public double RootFilletXe2 => RootDiameterDr2 / 2 * Math.Tan(AngleToFilletCentre2) +
                                       RootDiameterDr2 / 2 / Math.Cos(AngleToFilletCentre2);

        public double RootFilletYe2 => 0;

        public Point PointE2 => new(RootFilletXe2, RootFilletYe2);
        public Point PointA2 => new(RootFilletXa2, RootFilletYa2);
        public Point PointD2 => new(RootFilletXd2, RootFilletYd2);

        
        public List<Point> InvoluteCurvePoints2()
        {
            var points = InvolutePoints(BaseDiameterDb2 / 2, TipDiameterDa2 / 2, 25);

            return PointsFromIntersectionWithRootFilletPointE(points, RootFilletXe2);
        }

        #endregion

        #region Helical

        public double RadialPressureAngleAlphaT => Point.Degrees(Math.Atan(Math.Tan(Point.Radians(PressureAngleAlpha)) / Math.Cos(Point.Radians(HelixAngle))));

        public  double AxialPitch =>
            ModuleMt / Math.Cos(Point.Radians(HelixAngle)) * Math.PI / Math.Tan(Point.Radians(HelixAngle));
       

        public  double HelixPitchLength1 =>  AxialPitch * TeethZ1;
        public  double HelixPitchLength2 =>  AxialPitch * TeethZ2;

        #endregion
    }
}