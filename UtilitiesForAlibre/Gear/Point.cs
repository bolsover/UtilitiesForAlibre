using System;
using System.Collections.Generic;

namespace Bolsover.Gear
{
    /// <summary>
    /// A class to represent points in space
    /// </summary>
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }


        public Point()
        {
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }


        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
        }

        public static Point operator +(Point m, Point n)
        {
            return m.Offset(n.X, n.Y);
        }

        public static Point operator -(Point m)
        {
            return new Point(-m.X, -m.Y);
        }

        public static Point operator -(Point m, Point n)
        {
            return m.Offset(-n);
        }

        public Point Offset(Point m)
        {
            return Offset(m.X, m.Y);
        }

        public static Point FromPolar(double magnitude, double angle)
        {
            return new Point(Math.Cos(angle), Math.Sin(angle)).Scale(magnitude);
        }


        public Point Offset(double X, double Y)
        {
            return new Point(this.X + X, this.Y + Y);
        }

        public Point Scale(double magnitude)
        {
            return new Point(magnitude * X, magnitude * Y);
        }

        public static double Magnitude(Point p)
        {
            return Math.Sqrt(SumOfSquares(p.X, p.Y));
        }

        public static double SumOfSquares(double x, double y)
        {
            return x * x + y * y;
        }

        public static double DiffOfSquares(double x, double y)
        {
            return x * x - y * y;
        }

        public double Phase => Math.Atan2(Y, X);

        public double Gradient =>
            X == 0 ? Y < 0 ? double.MinValue : double.MaxValue : Y / X;

        public Point Rotate(double angle)
        {
            var cosAngle = Math.Cos(angle);
            var sinAngle = Math.Sin(angle);
            return new Point(X * cosAngle - Y * sinAngle, X * sinAngle + Y * cosAngle);
        }


        public Point RotateAbout(Point origin, double angle)
        {
            return origin + (this - origin).Rotate(angle);
        }

        /// <summary>
        /// Rotate a sequence of points about the origin in the anticlockwise
        /// direction by the angle phi
        /// </summary>
        /// <param name="points">The points from which a rotated
        /// <param name="phi">The angle to rotate by in radians</param>
        /// point sequence will be generated</param>
        /// <returns>The sequence of rotated points</returns>
        /// 
        public static List<Point> Rotated(List<Point> points, double phi)
        {
            var result = new List<Point>();
            foreach (var point in points)
            {
                result.Add(point.Rotate(phi));
            }

            return result;
        }

        public static Point Mirror(Point point, double angleDegrees)
        {
            var magnitude = Math.Sqrt(point.X * point.X + point.Y * point.Y);
            var d = Degrees(Math.Acos(point.Y / magnitude));
            var d2 = angleDegrees - (d - angleDegrees);

            var result = new Point()
            {
                X = Math.Sin(Radians(d2)) * magnitude,
                Y = Math.Cos(Radians(d2)) * magnitude
            };
            return result;
        }

        /// <summary>
        /// Converts the given angle in Degrees ° to Radians
        /// Uses the formula Radians = Degrees * Pi/180
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double Radians(double angle)
        {
            return angle * (Math.PI / 180.0);
        }

        /// <summary>
        /// Converts the given angle in Radians to Degrees
        /// Uses the formula Degrees = Radians * 180/Pi
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static double Degrees(double radians)
        {
            return radians * (180.0 / Math.PI);
        }

        public static List<Point> MirrorPoints(List<Point> points, double angleDegrees)
        {
            var result = new List<Point>();
            foreach (var point in points)
            {
                result.Add(Mirror(point, angleDegrees));
            }

            return result;
        }

        public static Point PolarOffset(Point origin, double magnitude, double angleRadians)
        {
            var x = origin.X + (magnitude * Math.Cos(angleRadians));
            var y = origin.Y + (magnitude * Math.Sin(angleRadians));
            return new Point(x, y);
        }
    }
}