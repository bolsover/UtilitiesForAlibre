using System;
using System.Collections.Generic;
using System.Linq;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Model
{
    /// <summary>
    /// A class to represent points in space
    /// </summary>
    public class GearPoint
    {
        public double X { get; set; }
        public double Y { get; set; }


        public GearPoint()
        {
        }

        public GearPoint(double x, double y)
        {
            X = x;
            Y = y;
        }


        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
        }

        public static GearPoint operator +(GearPoint m, GearPoint n)
        {
            return m.Offset(n.X, n.Y);
        }

        public static GearPoint operator -(GearPoint m)
        {
            return new GearPoint(-m.X, -m.Y);
        }

        public static GearPoint operator -(GearPoint m, GearPoint n)
        {
            return m.Offset(-n);
        }

        private GearPoint Offset(GearPoint m)
        {
            return Offset(m.X, m.Y);
        }

        public static GearPoint FromPolar(double magnitude, double angle)
        {
            return new GearPoint(Math.Cos(angle), Math.Sin(angle)).Scale(magnitude);
        }


        private GearPoint Offset(double x, double y)
        {
            return new GearPoint(X + x, Y + y);
        }

        private GearPoint Scale(double magnitude)
        {
            return new GearPoint(magnitude * X, magnitude * Y);
        }

        public static double Magnitude(GearPoint p)
        {
            return Math.Sqrt(SumOfSquares(p.X, p.Y));
        }

        private static double SumOfSquares(double x, double y)
        {
            return x * x + y * y;
        }

        public static double DiffOfSquares(double x, double y)
        {
            return x * x - y * y;
        }

        public double Phase
        {
            get => Math.Atan2(Y, X);
        }

        public double Gradient
        {
            get => X == 0 ? Y < 0 ? double.MinValue : double.MaxValue : Y / X;
        }

        public GearPoint Rotate(double angle)
        {
            var cosAngle = Math.Cos(angle);
            var sinAngle = Math.Sin(angle);
            return new GearPoint(X * cosAngle - Y * sinAngle, X * sinAngle + Y * cosAngle);
        }


        public GearPoint RotateAbout(GearPoint origin, double angle)
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
        public static List<GearPoint> Rotated(List<GearPoint> points, double phi)
        {
            return points.Select(point => point.Rotate(phi)).ToList();
        }

        public static GearPoint Mirror(GearPoint gearPoint, double angleDegrees)
        {
            var magnitude = Math.Sqrt(gearPoint.X * gearPoint.X + gearPoint.Y * gearPoint.Y);
            var d = Degrees(Math.Acos(gearPoint.Y / magnitude));
            var d2 = angleDegrees - (d - angleDegrees);

            var result = new GearPoint
            {
                X = Math.Sin(Radians(d2)) * magnitude,
                Y = Math.Cos(Radians(d2)) * magnitude
            };
            return result;
        }

       

        public static List<GearPoint> MirrorPoints(List<GearPoint> points, double angleDegrees)
        {
            return points.Select(point => Mirror(point, angleDegrees)).ToList();
        }

        public static GearPoint PolarOffset(GearPoint origin, double magnitude, double angleRadians)
        {
            var x = origin.X + magnitude * Math.Cos(angleRadians);
            var y = origin.Y + magnitude * Math.Sin(angleRadians);
            return new GearPoint(x, y);
        }
    }
}