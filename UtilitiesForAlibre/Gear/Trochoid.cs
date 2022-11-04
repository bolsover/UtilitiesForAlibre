using System;

namespace Bolsover.Gear
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


        public double HypoTrochoidX(double theta) => HypoModulus * Math.Cos(Radians(theta)) +
                                                     TracePoint * Math.Cos((HypoModulus / RollingCircleRadius) *
                                                                           Radians(theta));

        public double HypoTrochoidY(double theta) => HypoModulus * Math.Sin(Radians(theta)) -
                                                     TracePoint * Math.Sin((HypoModulus / RollingCircleRadius) *
                                                                           Radians(theta));


        public double EpiTrochoidX(double theta) => EpiModulus * Math.Cos(Radians(theta)) -
                                                    TracePoint * Math.Cos(
                                                        (EpiModulus / RollingCircleRadius) * Radians(theta));

        public double EpiTrochoidY(double theta) => EpiModulus * Math.Sin(Radians(theta)) -
                                                    TracePoint * Math.Sin(
                                                        (EpiModulus / RollingCircleRadius) * Radians(theta));


        // Parametric equation for Polar coordinates of involute 
        public double PolarRinv(double baseDiameter, double zeta) => (baseDiameter / 2) * Math.Sqrt(1 + Math.Pow(zeta, 2));
        public double PolarEtaInv(double zeta) => zeta - Math.Atan(zeta);

        // Convert polar to cartesian r is radius of circle, eta is angle in radians
        public Point PolarToCartesian(double r, double eta)
        {
            double x = r * Math.Cos(eta);
            double y = r * Math.Sin(eta);

            return new Point(x, y);
        }

        // Parametric equation for trochoid undercut

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseDiameter"></param>
        /// <param name="delta"> </param>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public double PolarRtro(double baseDiameter, double delta, double lambda) =>
            Math.Sqrt(Math.Pow(baseDiameter / 2, 2) + Math.Pow(delta, 2) -
                      (baseDiameter * delta * Math.Cos((Math.PI / 2) - lambda)));

        public double PolarEtaTro(double theta, double epsilon, double alpha) => theta + epsilon + alpha;

        public double TanEpsilon(double baseDiameter, double lambda, double delta) =>
            delta * Math.Cos(lambda) / (baseDiameter / 2 - delta * Math.Sin(lambda));
    }
}