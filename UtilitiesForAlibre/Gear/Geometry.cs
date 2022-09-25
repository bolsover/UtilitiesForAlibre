using System;
using System.Collections.Generic;

namespace Bolsover.Gear
{
    public class Geometry
    {
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
        /// <param name="addendumRadius"></param>
        /// <param name="steps"></param>
        /// <returns></returns>
        public static List<Point> InvolutePoints(double baseRadius, double addendumRadius, int steps)
        {
            var points = new List<Point>(steps);
            var stepSize = (addendumRadius - baseRadius) / steps;

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
        /// Trims the given list of points to remove any points below the intersection with the root fillet end point or above the tip relief radius start point.
        /// </summary>
        /// <param name="involutePoints"></param>
        /// <returns></returns>
        public List<Point> TrimmedInvolutePoints(List<Point> involutePoints, Point tipReliefStart, Point rootFilletEnd)
        {
            List<Point> points = PointsToIntersectionWithTipReliefArc(involutePoints, tipReliefStart);

            List<Point> result = PointsFromIntersectionWithRootFillet(points, rootFilletEnd);

            return result;
        }

        /// <summary>
        /// Trims the given List<Point> of involute points to remove any points below the intersection with the root fillet.
        /// A calculated (interpolated) point will be added to ensure the root fillet ends where the involute curve starts.
        /// </summary>
        /// <param name="involutePoints"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private List<Point> PointsFromIntersectionWithRootFillet(List<Point> involutePoints, Point rootFilletEnd)
        {
            var resultList = new List<Point>();
            var centre = new Point(0, 0);
            var radius = DistanceBetweenPoints(centre, rootFilletEnd);
            Point priorPoint = null;
            for (var i = 0; i < involutePoints.Count; i++)
            {
                var point = involutePoints[i];
                if (priorPoint != null && IsInsideCircle(centre, radius, priorPoint) &&
                    !IsInsideCircle(centre, radius, point))
                {
                    // resultList.Add(rootFilletEnd);
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
        /// Trims the given List<Point> of involute points to remove any points above the intersection with the tip relief arc.
        /// The final point in the returned list will be the tip relief start point .
        /// </summary>
        /// <param name="involutePoints"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static List<Point> PointsToIntersectionWithTipReliefArc(List<Point> involutePoints, Point tipReliefStart)
        {
            var resultList = new List<Point>();
            var centre = new Point(0, 0);
            var radius = DistanceBetweenPoints(centre, tipReliefStart);
            Point priorPoint = null;
            for (var i = 0; i < involutePoints.Count; i++)
            {
                var point = involutePoints[i];
                if (priorPoint != null && !IsInsideCircle(centre, radius, point) &&
                    IsInsideCircle(centre, radius, priorPoint))
                {
                    resultList.Add(tipReliefStart);
                    // var Intersection = new Point();
                    // var result = Intersect(centre, radius,
                    //     priorPoint, point, ref Intersection);
                    // if (result == 0)
                    // {
                    //     resultList.Add(Intersection);
                    // }
                }

                if (IsInsideCircle(centre, radius, point))
                {
                    resultList.Add(point);
                }

                priorPoint = point;
            }

            return resultList;
        }

        /// <summary>
        /// Returns the absolute distance between two points
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static double DistanceBetweenPoints(Point a, Point b)
        {
            var num1 = b.X - a.X;
            var num2 = b.Y - a.Y;
            var num1Squared = num1 * num1;
            var num2Squared = num2 * num2;
            var result = Math.Sqrt(num1Squared + num2Squared);
            return result;
        }


        /// <summary>
        /// Returns the angle to a Point(x,y) on a circle diameter.
        /// </summary>
        /// <param name="circleCentre"></param>
        /// <param name="pointOnCircleDiameter"></param>
        /// <returns></returns>
        public static double AngleToPointOnCircle(Point circleCentre, Point pointOnCircleDiameter) =>
            Math.Atan2(pointOnCircleDiameter.Y - circleCentre.Y, pointOnCircleDiameter.X - circleCentre.X);

        /// <summary>
        /// Method to calculate if a specified checkPoint is within a circle 
        /// </summary>
        /// <param name="centrePoint"></param>
        /// <param name="circleRadius"></param>
        /// <param name="checkPoint"></param>
        /// <returns>Return bool true if the checkPoint is within the specifies circle. Otherwise false</returns>
        private static bool IsInsideCircle(Point centrePoint, double circleRadius, Point checkPoint)
        {
            return (Math.Sqrt(Math.Pow(centrePoint.X - checkPoint.X, 2) +
                              Math.Pow(centrePoint.Y - checkPoint.Y, 2)) < circleRadius);
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
        /// <param name="centrePoint"></param>
        /// <param name="circleRadius"></param>
        /// <param name="lineStart"></param>
        /// <param name="lineEnd"></param>
        /// <param name="intersectionPoint"></param>
        /// <returns>Returns 0 if a solution is found otherwise returns -1</returns>
        private int Intersect(Point centrePoint, double circleRadius,
            Point lineStart, Point lineEnd, ref Point intersectionPoint)
        {
            if (IsIntersecting(centrePoint, circleRadius, lineStart, lineEnd))
            {
                //Calculate terms of the linear and quadratic equations
                var m = (lineEnd.Y - lineStart.Y) / (lineEnd.X - lineStart.X);
                var d = lineStart.Y - m * lineStart.X;
                var a = 1 + m * m;
                var b = 2 * (m * d - m * centrePoint.Y - centrePoint.X);
                var c = centrePoint.X * centrePoint.X + d * d + centrePoint.Y * centrePoint.Y -
                        circleRadius * circleRadius - 2 * d * centrePoint.Y;
                // solve quadratic equation
                var sqRtTerm = Math.Sqrt(b * b - 4 * a * c);
                var x = (-b + sqRtTerm) / (2 * a);
                // make sure we have the correct root for our line segment
                if (x < Math.Min(lineStart.X, lineEnd.X) ||
                    x > Math.Max(lineStart.X, lineEnd.X))
                {
                    x = (-b - sqRtTerm) / (2 * a);
                }

                //solve for the y-component
                var y = m * x + d;
                // Intersection Calculated
                intersectionPoint = new Point(x, y);
                return 0;
            }

            // Line segment does not intersect at one point.  It is either 
            // fully outside, fully inside, intersects at two points, is 
            // tangential to, or one or more points is exactly on the 
            // circle radius.
            intersectionPoint = new Point(0, 0);
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


        /// <summary>
        /// Calculates a point in the involute at a distance from the gear centre (0,0)
        /// </summary>
        /// <param name="baseRadius"></param>
        /// <param name="distanceToInvolute"></param>
        /// <returns>A point in the involute at a distance from the gear centre</returns>
        private static Point PointOnInvolute(double baseRadius, double distanceToInvolute)
        {
            var alpha = Math.Acos(baseRadius / distanceToInvolute);
            var invAlpha = Math.Tan(alpha) - alpha; // involute function
            var x = distanceToInvolute * Math.Cos(invAlpha); // X coordinate
            var y = distanceToInvolute * Math.Sin(invAlpha); // Y coordinate
            return new Point(x, y);
        }


        /// <summary>
        /// Calculates the distance form the gear centre (0,0) to the start of the tip release radius.
        /// </summary>
        /// <param name="baseRadius"></param>
        /// <param name="addendumRadius"></param>
        /// <param name="reliefRadius"></param>
        /// <returns>A double value. The distance from the gear centre (0,0) to the start of the tip relief radius.</returns>
        private static double CentreToTipReliefRadiusStart(double baseRadius, double addendumRadius, double reliefRadius)
        {
            var oa = addendumRadius - reliefRadius;
            var oaSquared = oa * oa;
            var opSquared = baseRadius * baseRadius;
            var paSquared = oaSquared - opSquared;
            var pa = Math.Sqrt(paSquared);
            var pc = pa + reliefRadius;
            var pcSquared = pc * pc;
            var ocSquared = pcSquared + opSquared;
            return Math.Sqrt(ocSquared);
        }


        /// <summary>
        /// returns the angle in degrees that lies opposite sidea
        /// </summary>
        /// <param name="sidea"></param>
        /// <param name="sideb"></param>
        /// <param name="sidec"></param>
        /// <returns>the angle in degrees that lies opposite sidea</returns>
        private static double CosineRuleAngle(double sidea, double sideb, double sidec)
        {
            var aSquared = sidea * sidea;
            var bSquared = sideb * sideb;
            var cSquared = sidec * sidec;
            var resultRadians = Math.Acos((bSquared + cSquared - aSquared) / (2 * sideb * sidec));
            return Point.Degrees(resultRadians);
        }

        /// <summary>
        /// Calculates the X,Y coordinate of the point at which the tip relief radius starts.
        /// </summary>
        /// <param name="baseRadius"></param>
        /// <param name="addendumRadius"></param>
        /// <param name="tipReliefRadius"></param>
        /// <returns>Start point of the tip relief radius</returns>
        public Point StartPointOnInvoluteOfTipRelief(double baseRadius, double addendumRadius, double tipReliefRadius)
        {
            var distanceToInvolute = CentreToTipReliefRadiusStart(baseRadius, addendumRadius, tipReliefRadius);
            Point pointc = PointOnInvolute(baseRadius, distanceToInvolute);
            return pointc;
        }

        /// <summary>
        /// Calculates the angle from normal to the centre of the tip relief radius
        /// </summary>
        /// <param name="baseRadius"></param>
        /// <param name="addendumRadius"></param>
        /// <param name="tipReliefRadius"></param>
        /// <returns>Angle in radians to the centre of the tip relief radius</returns>
        private double AngleToTipRadiusCentre(double baseRadius, double addendumRadius, double tipReliefRadius)
        {
            var distanceToInvolute = CentreToTipReliefRadiusStart(baseRadius, addendumRadius, tipReliefRadius);
            var srartPoint = StartPointOnInvoluteOfTipRelief(baseRadius, addendumRadius, tipReliefRadius);

            double angle1 = CosineRuleAngle(srartPoint.Y, srartPoint.X, distanceToInvolute);

            double angle2 = CosineRuleAngle(tipReliefRadius, addendumRadius - tipReliefRadius, distanceToInvolute);

            var result = Point.Radians(angle1 + angle2);
            return result;
        }

        /// <summary>
        /// Calculates the centre point of the tip relief radius for a gear at centre 0,0
        /// </summary>
        /// <param name="baseRadius"></param>
        /// <param name="addendumRadius"></param>
        /// <param name="tipReliefRadius"></param>
        /// <returns>Centre point of the tip relief radius for a gear at centre 0,0</returns>
        public Point CentrePointOfTipRelief(double baseRadius, double addendumRadius, double tipReliefRadius)
        {
            var angleToTipRadiusCentre = AngleToTipRadiusCentre(baseRadius, addendumRadius, tipReliefRadius);
            var x = (addendumRadius - tipReliefRadius) * Math.Cos(angleToTipRadiusCentre);
            var y = (addendumRadius - tipReliefRadius) * Math.Sin(angleToTipRadiusCentre);
            return new Point(x, y);
        }

        /// <summary>
        /// Calculates the location of the end point of the tip relief radius on the addendum curve.
        /// </summary>
        /// <param name="baseRadius"></param>
        /// <param name="addendumRadius"></param>
        /// <param name="tipReliefRadius"></param>
        /// <returns>End point of the tip relief radius</returns>
        public Point EndPointOnAddendumOfTipRelief(double baseRadius, double addendumRadius, double tipReliefRadius)
        {
            var centrePoint = CentrePointOfTipRelief(baseRadius, addendumRadius, tipReliefRadius);
            var endPoint = Point.PolarOffset(centrePoint, tipReliefRadius, centrePoint.Gradient);
            return endPoint;
        }

       
    }
}