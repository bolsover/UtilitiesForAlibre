using System;

namespace Bolsover.Gears
{
    /// <summary>
    /// A plane curve that is the trajectory of a point M inside or outside a circle that rolls upon another circle.
    /// A trochoid is called an epitrochoid or a hypotrochoid, depending on whether the rolling circle has external
    /// or internal contact with the fixed circle.
    /// </summary>
    public class Trochoid
    {
        private double rollingCircleRadius;
        private double fixedCircleRadius;
        private double tracePoint; // Distance From Centre Rolling Circle

        public double RollingCircleRadius
        {
            get => rollingCircleRadius;
            set => rollingCircleRadius = value;
        }

        public double FixedCircleRadius
        {
            get => fixedCircleRadius;
            set => fixedCircleRadius = value;
        }

        public double TracePoint
        {
            get => tracePoint;
            set => tracePoint = value;
        }

        public static double Radians(double angle)
        {
            return angle * (Math.PI / 180.0);
        }

        public double HypoModulus => FixedCircleRadius - RollingCircleRadius;
        public double EpiModulus => FixedCircleRadius + RollingCircleRadius;


        public double HypoTrochoidX(double theta) => HypoModulus * Math.Cos(Radians(theta)) + TracePoint * Math.Cos((HypoModulus / RollingCircleRadius) * Radians(theta));
        public double HypoTrochoidY(double theta) => HypoModulus * Math.Sin(Radians(theta)) - TracePoint * Math.Sin((HypoModulus / RollingCircleRadius) * Radians(theta));


        public double EpiTrochoidX(double theta) => EpiModulus * Math.Cos(Radians(theta)) -  TracePoint * Math.Cos((EpiModulus / RollingCircleRadius) * Radians(theta));
        public double EpiTrochoidY(double theta) => EpiModulus * Math.Sin(Radians(theta)) - TracePoint * Math.Sin((EpiModulus / RollingCircleRadius) * Radians(theta));
    }
}