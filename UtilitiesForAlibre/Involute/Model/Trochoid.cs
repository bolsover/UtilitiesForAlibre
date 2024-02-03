using System;

namespace Bolsover.Involute.Model
{
    /// <summary>
    /// A plane curve that is the trajectory of a point M inside or outside a circle that rolls upon another circle.
    /// A trochoid is called an epitrochoid or a hypotrochoid, depending on whether the rolling circle has external
    /// or internal contact with the fixed circle.
    /// </summary>
    public class Trochoid
    {
        public double RollingCircleRadius { get; set; }

        public double FixedCircleRadius { get; set; }

        public double TracePoint { get; set; }

        private static double Radians(double angle)
        {
            return angle * (Math.PI / 180.0);
        }

        private double HypoModulus
        {
            get => FixedCircleRadius - RollingCircleRadius;
        }

        private double EpiModulus
        {
            get => FixedCircleRadius + RollingCircleRadius;
        }


        public double HypoTrochoidX(double theta) => HypoModulus * Math.Cos(Radians(theta)) +
                                                     TracePoint * Math.Cos(HypoModulus / RollingCircleRadius *
                                                                           Radians(theta));

        public double HypoTrochoidY(double theta) => HypoModulus * Math.Sin(Radians(theta)) -
                                                     TracePoint * Math.Sin(HypoModulus / RollingCircleRadius *
                                                                           Radians(theta));


        public double EpiTrochoidX(double theta) => EpiModulus * Math.Cos(Radians(theta)) -
                                                    TracePoint * Math.Cos(
                                                        EpiModulus / RollingCircleRadius * Radians(theta));

        public double EpiTrochoidY(double theta) => EpiModulus * Math.Sin(Radians(theta)) -
                                                    TracePoint * Math.Sin(
                                                        EpiModulus / RollingCircleRadius * Radians(theta));


        // Parametric equation for Polar coordinates of involute 
        public static double PolarRinv(double baseDiameter, double zeta) => baseDiameter / 2 * Math.Sqrt(1 + Math.Pow(zeta, 2));
        public static double PolarEtaInv(double zeta) => zeta - Math.Atan(zeta);

        // Convert polar to cartesian r is radius of circle, eta is angle in radians
        public static GearPoint PolarToCartesian(double r, double eta)
        {
            var x = r * Math.Cos(eta);
            var y = r * Math.Sin(eta);

            return new GearPoint(x, y);
        }

        // Parametric equation for trochoid undercut

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseDiameter"></param>
        /// <param name="delta"> </param>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public static double PolarRtro(double baseDiameter, double delta, double lambda) =>
            Math.Sqrt(Math.Pow(baseDiameter / 2, 2) + Math.Pow(delta, 2) -
                      baseDiameter * delta * Math.Cos(Math.PI / 2 - lambda));

        public static double PolarEtaTro(double theta, double epsilon, double alpha) => theta + epsilon + alpha;

        public double TanEpsilon(double baseDiameter, double lambda, double delta) =>
            delta * Math.Cos(lambda) / (baseDiameter / 2 - delta * Math.Sin(lambda));
    }
}