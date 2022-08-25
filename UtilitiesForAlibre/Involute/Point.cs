﻿using System;

namespace Bolsover.Involute
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

        // public static  Point Rotate(Point point, double angle)
        // {
        //     var cosAngle = Math.Cos(angle);
        //     var sinAngle = Math.Sin(angle);
        //     return new Point(point.X * cosAngle - point.Y * sinAngle, point.X * sinAngle + point.Y * cosAngle);
        // }

        /// <summary>
        /// Translates a point about an angle
        /// </summary>
        /// <param name="point"></param>
        /// <param name="theta"></param>
        /// <returns></returns>
        public static Point TranslatesPoint(Point point, double theta)
        {
            var result = new Point()
            {
                X = Math.Cos(theta) * point.X - Math.Sin(theta) * point.Y,
                Y = Math.Sin(theta) * point.X + Math.Cos(theta) * point.Y
            };
            return result;
        }

        public Point RotateAbout(Point origin, double angle)
        {
            return origin + (this - origin).Rotate(angle);
        }
    }
}