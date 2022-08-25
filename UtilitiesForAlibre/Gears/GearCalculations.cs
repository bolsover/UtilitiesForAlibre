using System;
using System.Collections.Generic;
using System.Linq;


namespace Bolsover.Gears
{
    public class GearCalculations
    {
        // public static double Alpha(GearParameters parameters)
        // {
        //     return Alpha(parameters.Teeth, parameters.NormalModule, parameters.NormalPressureAngle);
        // }
        //
        // public static double Alpha(double teeth, double normalModule, double pressureAngle)
        // {
        //     var baseCircleDiameter = NormalBaseDiameter(teeth, normalModule, pressureAngle);
        //     var pitchCircleDiameter = NormalPitchCircleDiameter(teeth, normalModule);
        //     var result = Degrees(
        //         Math.Sqrt(pitchCircleDiameter * pitchCircleDiameter - baseCircleDiameter * baseCircleDiameter) /
        //         baseCircleDiameter) - pressureAngle;
        //     return result;
        // }
        //
        // public static double Beta(GearParameters parameters)
        // {
        //     return Beta(parameters.Teeth, parameters.NormalModule, parameters.NormalPressureAngle);
        // }
        //
        //
        // /// <summary>
        // /// Returns one quarter radial tooth pitch
        // /// </summary>
        // /// <param name="teeth"></param>
        // /// <returns></returns>
        // public static double Beta(double teeth, double normalModule, double pressureAngle)
        // {
        //     return (360 / (teeth * 4) + Alpha(teeth, normalModule, pressureAngle)) * 2;
        // }
        //
        // public static double Beta2(Point centre, Point p1)
        // {
        //     return Math.Atan2(p1.Y - centre.Y, p1.X - centre.X);
        // }
        //
        // public static double InvoluteFunction(double pressureAngle)
        // {
        //     return Math.Tan(Radians(pressureAngle)) - Radians(pressureAngle);
        // }
        //
        //
        // public static double Addendum(double normalModule, double addendumCoefficient)
        // {
        //     return normalModule * addendumCoefficient;
        // }
        //
        // public static double Dedendum(double normalModule, double dedendumCoefficient)
        // {
        //     return normalModule * dedendumCoefficient;
        // }
        //
        // /// <summary>
        // /// Returns the Normal Pitch of a gear given the Normal Module.
        // /// Formula is Normal Pitch = Normal Module * Pi
        // /// </summary>
        // /// <param name="normalModule"></param>
        // /// <returns></returns>
        // public static double NormalPitch(double normalModule)
        // {
        //     return normalModule * Math.PI;
        // }
        //
        // /// <summary>
        // /// Returns the Transverse Module for the given Normal Module and Helix Angle
        // /// Formula: TransverseModule = NormalModule / Cos(Radians(HelixAngle))
        // /// </summary>
        // /// <param name="normalModule"></param>
        // /// <param name="helixAngle"></param>
        // /// <returns></returns>
        // public static double TransverseModule(double normalModule, double helixAngle)
        // {
        //     return normalModule / Math.Cos(Radians(helixAngle));
        // }
        //
        // public static double TransversePressureAngle(double normalPressureAngle, double helixAngle)
        // {
        //     return Degrees(Math.Atan(Math.Tan(Radians(normalPressureAngle)) / Math.Cos(Radians(helixAngle))));
        // }
        //
        // public static double TransversePitchCircleDiameter(int teeth, double normalModule, double helixAngle)
        // {
        //     return teeth * normalModule / Math.Cos(Radians(helixAngle));
        // }
        //
        // public static double TransverseBaseCircleDiameter(int teeth, double normalPressureAngle, double helixAngle,
        //     double normalModule)
        // {
        //     return teeth * normalModule / Math.Cos(Radians(helixAngle)) *
        //            Math.Cos(Math.Atan(Math.Tan(Radians(normalPressureAngle)) / Math.Cos(Radians(helixAngle))));
        // }
        //
        // public static double NormalPitchCircleDiameter(GearParameters parameters)
        // {
        //     return NormalPitchCircleDiameter(parameters.Teeth, parameters.NormalModule);
        // }
        //
        // public static double NormalPitchCircleDiameter(double teeth, double normalModule)
        // {
        //     return teeth * normalModule;
        // }
        //
        // public static double NormalBaseDiameter(GearParameters parameters)
        // {
        //     return NormalBaseDiameter(parameters.Teeth, parameters.NormalModule, parameters.NormalPressureAngle);
        // }
        //
        // public static double NormalBaseDiameter(double teeth, double normalModule, double normalPressureAngle)
        // {
        //     return teeth * normalModule * Math.Cos(Radians(normalPressureAngle));
        // }
        //
        // public static double TransverseDedendumDiameter(int teeth, double normalModule, double helixAngle,
        //     double dedendumCoefficient)
        // {
        //     return teeth * normalModule / Math.Cos(Radians(helixAngle)) -
        //            2 * Dedendum(normalModule, dedendumCoefficient);
        // }
        //
        // public static double NormalDedendumDiameter(GearParameters parameters)
        // {
        //     return NormalDedendumDiameter(parameters.Teeth, parameters.NormalModule, parameters.DedendumCoefficient,
        //         parameters.ProfileShift);
        // }
        //
        // public static double NormalDedendumDiameter(double teeth, double normalModule, double dedendumCoefficient,
        //     double profileShift)
        // {
        //     return teeth * normalModule - 2 * Dedendum(normalModule, dedendumCoefficient) * (1 - profileShift);
        // }
        //
        // public static double NormalAddendumDiameter(GearParameters parameters)
        // {
        //     return NormalAddendumDiameter(parameters.Teeth, parameters.NormalModule, parameters.AddendumCoefficient,
        //         parameters.ProfileShift);
        // }
        //
        // public static double NormalAddendumDiameter(double teeth, double normalModule, double addendumCoefficient,
        //     double profileShift)
        // {
        //     return teeth * normalModule +
        //            2 * Addendum(normalModule, addendumCoefficient) * (1 + profileShift);
        // }
        //
        // public static double TransverseAddendumPitchCircleDiameter(int teeth, double normalModule, double helixAngle,
        //     double addendumCoefficient)
        // {
        //     return teeth * normalModule / Math.Cos(Radians(helixAngle)) +
        //            2 * Addendum(normalModule, addendumCoefficient);
        // }
        //
        // public static double TransversePitch(double normalModule, double helixAngle)
        // {
        //     return normalModule / Math.Cos(Radians(helixAngle)) * Math.PI;
        // }
        //
        // public static double AxialPitch(double normalModule, double helixAngle)
        // {
        //     return normalModule / Math.Cos(Radians(helixAngle)) * Math.PI / Math.Tan(Radians(helixAngle));
        // }
        //
        // public static Point CoordinateIntersectRadialLineCircle(double theta, double circleRadius, Point circleCentre)
        // {
        //     return new Point
        //     {
        //         X = circleRadius * Math.Cos(Radians(theta)) + circleCentre.X,
        //         Y = circleRadius * Math.Sin(Radians(theta)) + circleCentre.Y
        //     };
        // }
        //
        //
        // /// <summary>
        // /// Returns a Point representing the X,Y coordinate on an involute curve where the point is alphaDegrees from the normal.
        // /// </summary>
        // /// <param name="radius"></param>
        // /// <param name="alphaDegrees"></param>
        // /// <returns></returns>
        // public static Point InvoluteCoordinateR(double radius, double alphaDegrees)
        // {
        //     var point = new Point()
        //     {
        //         X = radius * (Math.Cos(Radians(alphaDegrees)) +
        //                       Radians(alphaDegrees) * Math.Sin(Radians(alphaDegrees))),
        //         Y = radius * (Math.Sin(Radians(alphaDegrees)) - Radians(alphaDegrees) * Math.Cos(Radians(alphaDegrees)))
        //     };
        //     return point;
        // }
        //
        //
        //
        // public static double HelixPitchLength(int teeth, double normalModule, double helixAngle)
        // {
        //     return AxialPitch(normalModule, helixAngle) * teeth;
        // }
        //
        // /// <summary>
        // /// Converts the given angle in Degrees ° to Radians
        // /// Uses the formula Radians = Degrees * Pi/180
        // /// </summary>
        // /// <param name="angle"></param>
        // /// <returns></returns>
        // public static double Radians(double angle)
        // {
        //     return angle * (Math.PI / 180.0);
        // }
        //
        // /// <summary>
        // /// Converts the given angle in Radians to Degrees
        // /// Uses the formula Degrees = Radians * 180/Pi
        // /// </summary>
        // /// <param name="radians"></param>
        // /// <returns></returns>
        // public static double Degrees(double radians)
        // {
        //     return radians * (180.0 / Math.PI);
        // }
        //
        // public static Point CalculateIntersectionLineCircle(Gear gear, double radius, Point startPoint, Point endPoint)
        // {
        //     var Intersection = new Point();
        //     var result = Intersect(gear.Parameters.Centre, radius,
        //         startPoint, endPoint, ref Intersection);
        //     if (result == 0)
        //     {
        //         return Intersection;
        //     }
        //
        //     return null;
        // }
        //
        // /// <summary>
        // /// Method to calculate if a specified checkPoint is within a circle 
        // /// </summary>
        // /// <param name="CirclePos"></param>
        // /// <param name="CircleRad"></param>
        // /// <param name="checkPoint"></param>
        // /// <returns>Return bool true if the checkPoint is within the specifies circle. Otherwise false</returns>
        // public static bool IsInsideCircle(Point CirclePos, double CircleRad, Point checkPoint)
        // {
        //     if (Math.Sqrt(Math.Pow(CirclePos.X - checkPoint.X, 2) +
        //                   Math.Pow(CirclePos.Y - checkPoint.Y, 2)) < CircleRad)
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }
        //
        // /// <summary>
        // /// Method to calculate if a line between two points intersects a given circle
        // /// </summary>
        // /// <param name="CirclePos"></param>
        // /// <param name="CircleRad"></param>
        // /// <param name="LineStart"></param>
        // /// <param name="LineEnd"></param>
        // /// <returns></returns>
        // public static bool IsIntersecting(Point CirclePos, double CircleRad, Point LineStart,
        //     Point LineEnd)
        // {
        //     if (IsInsideCircle(CirclePos, CircleRad, LineStart) ^
        //         IsInsideCircle(CirclePos, CircleRad, LineEnd))
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }
        //
        // /// <summary>
        // // Method to calculate the absolute position where a line intersects a circle.
        // // The position is available in the ref Point Intersection.
        // // Method will return -1 if:
        // // 1 The line is tangential to the circle
        // // 2 One or both points are exactly ON the circle
        // // 3 The line intersects at two points
        // //
        // //This function takes the intersection point as a ref parameter and returns either -1 (no intersection) or 0 (intersection found). I used an int return value in case you want to extend this to differentiate the edge cases. The intersection is calculated from elementary geometry - remember that a line is expressed as (see : Slope Intercept and Point Slope Form )
        // //
        // // y = M*x + B
        // //     and a circle (centered at (C.x, C.y) with radius r) is
        // //
        // // (x - C.x)^2 + (y - C.y)^2 - r^2 = 0
        // // You solve this system of equations by substitution :
        // //
        // // (x - C.x)^2 + ((M*x + B) - C.y)^2 - r^2 = 0
        // // Expanding and collecting terms you get :
        // //
        // // (1+M^2)x^2 + 2*(MB - MC.y - C.x)x + (C.x^2 + C.y^2 + B^2 - r^2 - 2B*C.y) = 0
        // // This is a standard quadratic equation of the form
        // //
        // //     ax^2 + bx + c = 0
        // // where :
        // // a = (1+M^2)
        // // b = 2*(MB - MC.y - C.x)
        // // c = (C.x^2 + C.y^2 + B^2 - r^2 - 2B*C.y)
        // // Which can be solved by the quadratic formula (see : Quadratic Formula ):
        // //
        // // x = (-b ± Sqrt(b^2 - 4ac))/(2a)
        // // This gives two roots for the infinite line on which our line segment lies - we do a final check above to make sure that we choose the solution for our specific line segment.
        // ///
        // /// 
        // /// </summary>
        // /// <param name="CirclePos"></param>
        // /// <param name="CircleRad"></param>
        // /// <param name="LineStart"></param>
        // /// <param name="LineEnd"></param>
        // /// <param name="Intersection"></param>
        // /// <returns>Returns 0 if a solution is found otherwise returns -1</returns>
        // public static int Intersect(Point CirclePos, double CircleRad,
        //     Point LineStart, Point LineEnd, ref Point Intersection)
        // {
        //     if (IsIntersecting(CirclePos, CircleRad, LineStart, LineEnd))
        //     {
        //         //Calculate terms of the linear and quadratic equations
        //         var m = (LineEnd.Y - LineStart.Y) / (LineEnd.X - LineStart.X);
        //         var d = LineStart.Y - m * LineStart.X;
        //         var a = 1 + m * m;
        //         var b = 2 * (m * d - m * CirclePos.Y - CirclePos.X);
        //         var c = CirclePos.X * CirclePos.X + d * d + CirclePos.Y * CirclePos.Y -
        //                 CircleRad * CircleRad - 2 * d * CirclePos.Y;
        //         // solve quadratic equation
        //         var sqRtTerm = Math.Sqrt(b * b - 4 * a * c);
        //         var x = (-b + sqRtTerm) / (2 * a);
        //         // make sure we have the correct root for our line segment
        //         if (x < Math.Min(LineStart.X, LineEnd.X) ||
        //             x > Math.Max(LineStart.X, LineEnd.X))
        //         {
        //             x = (-b - sqRtTerm) / (2 * a);
        //         }
        //
        //         //solve for the y-component
        //         var y = m * x + d;
        //         // Intersection Calculated
        //         Intersection = new Point(x, y);
        //         return 0;
        //     }
        //
        //     // Line segment does not intersect at one point.  It is either 
        //     // fully outside, fully inside, intersects at two points, is 
        //     // tangential to, or one or more points is exactly on the 
        //     // circle radius.
        //     Intersection = new Point(0, 0);
        //     return -1;
        // }
        //
        // public static List<Point> MirrorPoints(List<Point> points, double angleDegrees)
        // {
        //     var result = new List<Point>();
        //     foreach (var point in points)
        //     {
        //         result.Add(Mirror(point, angleDegrees));
        //     }
        //
        //     return result;
        // }
        //
        //
        // public static Point Mirror(Point point, double angleDegrees)
        // {
        //     var magnitude = Math.Sqrt(point.X * point.X + point.Y * point.Y);
        //     var d = Degrees(Math.Acos(point.Y / magnitude));
        //     var d2 = angleDegrees - (d - angleDegrees);
        //
        //     var result = new Point()
        //     {
        //         X = Math.Sin(Radians(d2)) * magnitude,
        //         Y = Math.Cos(Radians(d2)) * magnitude
        //     };
        //     return result;
        // }
        //
        // /// <summary>
        // /// Translates a point about an angle
        // /// </summary>
        // /// <param name="point"></param>
        // /// <param name="theta"></param>
        // /// <returns></returns>
        // public static Point TranslatePoint(Point point, double theta)
        // {
        //     var result = new Point()
        //     {
        //         X = Math.Cos(theta) * point.X - Math.Sin(theta) * point.Y,
        //         Y = Math.Sin(theta) * point.X + Math.Cos(theta) * point.Y
        //     };
        //     return result;
        // }
        //
        // /// <summary>
        // /// Rotate a sequence of points about the origin in the anticlockwise
        // /// direction by the angle phi
        // /// </summary>
        // /// <param name="points">The points from which a rotated
        // /// <param name="phi">The angle to rotate by in radians</param>
        // /// point sequence will be generated</param>
        // /// <returns>The sequence of rotated points</returns>
        // /// 
        // public static List<Point> Rotated(List<Point> points, double phi)
        // {
        //     var result = new List<Point>();
        //     foreach (var point in points)
        //     {
        //         result.Add(point.Rotate(phi));
        //     }
        //
        //     return result;
        // }
        //
        //
        //
        // /// <summary>
        // /// Obtain a point on an involute or a trochoidal curve
        // /// </summary>
        // /// <param name="radius">The radius of the base circle on which the involute is formed</param>
        // /// <param name="offX">Assuming the involute touches the base circle along the +ve
        // /// X axis, with the circle centred on the origin, offX is the X component of the
        // /// offset to the point being traced as a locus relative to the  This value and
        // /// the offY value must both be zero to draw the involute itself. Non-zero values
        // /// trace out the trochoid path, as offX and offY also rotate about the point on the involute
        // /// at the same angular rate as the involute tangential point rotates.</param>
        // /// <param name="offY">The Y component of the offset from the point on the involute</param>
        // /// <param name="phi">The angle away from the involute contact point at the right of the circle.
        // /// Note that anticlockwise angles are positive.</param>
        // /// <param name="phiOffset">The angle by which the involute's touch point differs from the
        // /// right of the circle. The whole involute is rotated around the outside of the circle
        // /// by this amount. Note that the trochoid is rotated by the same amount.</param>
        // /// <returns>The computed X, Y coordinate for the parameters supplied.</returns>
        // public static Point InvolutePlusOffset
        //     (double radius, double offX, double offY, double phi, double phiOffset)
        // {
        //     var cosPhiTotal = Math.Cos(phi + phiOffset);
        //     var sinPhiTotal = Math.Sin(phi + phiOffset);
        //
        //     var x = radius * (cosPhiTotal + phi * sinPhiTotal)
        //         + offX * cosPhiTotal - offY * sinPhiTotal;
        //     var y = radius * (sinPhiTotal - phi * cosPhiTotal)
        //             + offX * sinPhiTotal + offY * cosPhiTotal;
        //     return new Point(x, y);
        // }
        //
        // /// <summary>
        // /// Generate a sequence of points on a circle that is centred on a nominated point
        // /// </summary>
        // /// <param name="startAngle">The starting angle on the curve. 0 represents the
        // /// point on the circle where it crosses a line parallel to the positive X axis, 
        // /// with anticlockwise angles being positive.</param>
        // /// <param name="endAngle">The angle beyond which no points are added to
        // /// the list of output points</param>
        // /// <param name="dAngle">The delta value for the angle between each point</param>
        // /// <param name="radius">The radius of the circle</param>
        // /// <param name="centre">The centre for the circle from which the points
        // /// are computed</param>
        // /// <returns>The set of points on the circumference of the circle</returns>
        // public static IEnumerable<Point> CirclePoints
        //     (double startAngle, double endAngle, double dAngle, double radius, Point centre)
        // {
        //     return CirclePoints(startAngle, endAngle, dAngle, radius)
        //         .Select(p => centre.Offset(p));
        // }
        //
        // /// <summary>
        // /// Generate a sequence of points on a circle, centred on the origin
        // /// </summary>
        // /// <param name="startAngle">The starting angle on the curve. 0 represents the
        // /// point on the circle where it crosses the positive X axis, with anticlockwise
        // /// angle values being positive. Given the centre of the circle is set at the
        // /// origin, the touch point is set to the right of the circle (Y = 0
        // /// and X positive)</param>
        // /// <param name="endAngle">The angle beyond which no points are added to
        // /// the list of output points</param>
        // /// <param name="dAngle">The delta value for the angle between each point</param>
        // /// <param name="radius">The radius of the circle</param>
        // /// are computed</param>
        // /// <returns>The set of points on the circumference of the circle</returns>
        // public static IEnumerable<Point> CirclePoints
        //     (double startAngle, double endAngle, double dAngle, double radius)
        // {
        //     var angle = startAngle;
        //     for (var i = 0; angle < endAngle; angle = startAngle + dAngle * ++i)
        //     {
        //         yield return Point.FromPolar(radius, angle);
        //     }
        //
        //     yield return Point.FromPolar(radius, endAngle);
        // }
        //
        // public static Point ExtendLine(Point start, Point end, double distance)
        // {
        //     var num1 = Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2));
        //     var x3 = end.X + distance * ((end.X - start.X) / num1);
        //     var y3 = end.Y + distance * ((end.Y - start.Y) / num1);
        //     return new Point(x3, y3);
        // }
    }
}