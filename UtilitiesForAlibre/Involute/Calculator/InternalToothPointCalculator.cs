using System;
using System.Collections.Generic;
using Bolsover.Gear.Calculators;
using Bolsover.Gear.Models;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Calculator
{
    public static class InternalToothPointCalculator
    {
        public static double CalcGearCentreToFilletCentreDistance(IGearDesignOutputParams gearDesignOutputParams)
        {
            double gearCentreToFilletCentre;

            if (gearDesignOutputParams.OutsideDiameter > gearDesignOutputParams.BaseCircleDiameter)
            {
                gearCentreToFilletCentre = gearDesignOutputParams.OutsideDiameter / 2 + gearDesignOutputParams.RootFilletRadius;
            }
            else
            {
                gearCentreToFilletCentre = gearDesignOutputParams.BaseCircleDiameter / 2 + gearDesignOutputParams.RootFilletRadius;
            }

            return gearCentreToFilletCentre;
        }

        /// <summary>
        /// Calculates the angle between a line from the gear centre to the centre point of the Addendum Relief circle centre
        /// and a line from the Addendum Relief circle centre to a tangent point on the base circle.
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static double InnerGearTipReliefCentreToBaseTangentAngle(IGearDesignOutputParams gearDesignOutputParams)
        {
            var addendumRadius = gearDesignOutputParams.OutsideDiameter / 2;
            var baseRadius = gearDesignOutputParams.BaseCircleDiameter / 2;
            var reliefRadius = gearDesignOutputParams.RootFilletRadius;

            double d = DistanceBaseTangentPointToInnerGearAddendumRelief(baseRadius,
                addendumRadius, reliefRadius);
            double angleToBase;
            if (addendumRadius > baseRadius)
            {
                angleToBase = GearPoint.Degrees(Math.Acos(d / (addendumRadius + reliefRadius)));
            }
            else
            {
                angleToBase = GearPoint.Degrees(Math.Acos(d / (baseRadius + reliefRadius)));
            }

            return angleToBase;
        }

        /// <summary>
        /// Calculates the distance from the centre of the inner gear addendum relief to a point on the base circle where a
        /// line from the addendum relief centre meets the base circle at a tangent. A line to the gear centre will be at 90°
        /// to this line. 
        /// </summary>
        /// <param name="baseRadius"></param>
        /// <param name="addendumRadius"></param>
        /// <param name="reliefRadius"></param>
        /// <returns></returns>
        public static double DistanceBaseTangentPointToInnerGearAddendumRelief(double baseRadius, double addendumRadius,
            double reliefRadius)
        {
            double hypotenuse;
            if (addendumRadius > baseRadius)
            {
                hypotenuse = addendumRadius + reliefRadius;
            }
            else
            {
                hypotenuse = baseRadius + reliefRadius;
            }

            var hypotenuseSquared = hypotenuse * hypotenuse;
            var baseRadiusSquared = baseRadius * baseRadius;
            var resultSquared = hypotenuseSquared - baseRadiusSquared;
            return Math.Sqrt(resultSquared);
        }

        public static GearPoint EndPoint(IGearDesignOutputParams gearDesignOutputParams, double gearCentreToFilletCentre, double adjustedAngleToBase)
        {
            double radiansToBase = GearPoint.Radians(180 - adjustedAngleToBase);

            var p = new GearPoint(gearCentreToFilletCentre, 0);
            var y = GearPoint.PolarOffset(p, gearDesignOutputParams.RootFilletRadius, radiansToBase);
            var centre = new GearPoint(0, 0);
            var distanceToY = Geometry.DistanceBetweenPoints(centre, y);

            return Geometry.PointOnInvolute(gearDesignOutputParams.BaseCircleDiameter / 2, distanceToY);
        }

        private static bool Equals(double x, double y, double tolerance)
        {
            var diff = Math.Abs(x - y);
            return diff <= tolerance;
        }

        public static GearPoint StartPoint(IGearDesignOutputParams gearDesignOutputParams, GearPoint centreGearPoint)
        {
            return GearPoint.PolarOffset(centreGearPoint, gearDesignOutputParams.RootFilletRadius,
                GearPoint.Radians(180 - Math.Atan(centreGearPoint.Y / centreGearPoint.X)));
        }

        public static GearPoint CentrePoint(IGearDesignOutputParams gearDesignOutputParams, GearPoint endGearPoint, double adjustedAngleToBase)
        {
            return GearPoint.PolarOffset(endGearPoint,
                gearDesignOutputParams.RootFilletRadius, GearPoint.Radians(-adjustedAngleToBase));
        }

        /// <summary>
        /// Nasty big routine to find location of inner gear tip relief points.
        /// Was not able to find geometric way finding these points so this routine uses a binary search to find the locations.
        /// Works by finding a good geometric location for the end point (point on involute) and then uses a binary search to determine
        /// location of centre and start points. Observe that the start-centre distance is Module * factor and the start point is
        /// located on the base or addendum circle (whichever is greater).
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public static GearPoint[] CalcAddendumFilletPoints(IGearDesignOutputParams gearDesignOutputParams)
        {
            // tolerance of 0.000001 seems to work well with alibre
            var tolerance = 0.000001;
            var centre = new GearPoint(0, 0);

            var targetGearCentreToFilletCentreDistance = CalcGearCentreToFilletCentreDistance(gearDesignOutputParams);
            var addendumReliefRadius = gearDesignOutputParams.RootFilletRadius;
            var targetGearCentreToStartPointDistance = targetGearCentreToFilletCentreDistance - addendumReliefRadius;
            // the angle used as the initial start point for the search
            var angleToBase = InnerGearTipReliefCentreToBaseTangentAngle(gearDesignOutputParams);
            // the search range with be +- this angle about the initial search point.
            var changeAngle = 4.0d;

            // initial angles for search
            var maxAngle = angleToBase + changeAngle;
            var minAngle = angleToBase - changeAngle;
            var midAngle = angleToBase;

            // points used in binary search. Final results will be taken from the three Mid Points.
            // Min and Max points are used in the binary search
            GearPoint startMidGearPoint;
            GearPoint centreMidGearPoint;
            GearPoint endMidGearPoint;
            GearPoint startMinGearPoint;
            GearPoint centreMinGearPoint;
            GearPoint endMinGearPoint;
            GearPoint startMaxGearPoint;
            GearPoint centreMaxGearPoint;
            GearPoint endMaxGearPoint;

            // setup the mid points
            endMidGearPoint = EndPoint(gearDesignOutputParams, targetGearCentreToFilletCentreDistance, angleToBase);
            centreMidGearPoint = CentrePoint(gearDesignOutputParams, endMidGearPoint, midAngle);
            startMidGearPoint = StartPoint(gearDesignOutputParams, centreMidGearPoint);
            // calculate distance to mid start point
            var distanceToStartMidPoint = Geometry.DistanceBetweenPoints(centre, startMidGearPoint);
            // test value this needs to tend towards zero
            var midTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMidPoint);
            // setup the minimums
            endMinGearPoint = EndPoint(gearDesignOutputParams, targetGearCentreToFilletCentreDistance, angleToBase);
            centreMinGearPoint = CentrePoint(gearDesignOutputParams, endMinGearPoint, minAngle);
            startMinGearPoint = StartPoint(gearDesignOutputParams, centreMinGearPoint);
            var distanceToStartMinPoint = Geometry.DistanceBetweenPoints(centre, startMinGearPoint);
            var minTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMinPoint);
            // setup the maximums
            endMaxGearPoint = EndPoint(gearDesignOutputParams, targetGearCentreToFilletCentreDistance, angleToBase);
            centreMaxGearPoint = CentrePoint(gearDesignOutputParams, endMaxGearPoint, maxAngle);
            startMaxGearPoint = StartPoint(gearDesignOutputParams, centreMaxGearPoint);
            var distanceToStartMaxPoint = Geometry.DistanceBetweenPoints(centre, startMaxGearPoint);
            var maxTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMaxPoint);

            // search loop 
            while (!Equals(0, midTestValue, tolerance))
            {
                if (maxTestValue > minTestValue)
                {
                    // need to search between mid and min
                    startMaxGearPoint = startMidGearPoint;
                    // recalc midAngle
                    maxAngle = midAngle;
                    midAngle = (minAngle + maxAngle) / 2;
                    centreMidGearPoint = CentrePoint(gearDesignOutputParams, endMidGearPoint, midAngle);
                    startMidGearPoint = StartPoint(gearDesignOutputParams, centreMidGearPoint);
                    centreMinGearPoint = CentrePoint(gearDesignOutputParams, endMinGearPoint, minAngle);
                    startMinGearPoint = StartPoint(gearDesignOutputParams, centreMinGearPoint);
                }
                else
                {
                    // need to search between mid and max
                    startMinGearPoint = startMidGearPoint;
                    // recalc midAngle
                    minAngle = midAngle;
                    midAngle = (minAngle + maxAngle) / 2;
                    centreMidGearPoint = CentrePoint(gearDesignOutputParams, endMidGearPoint, midAngle);
                    startMidGearPoint = StartPoint(gearDesignOutputParams, centreMidGearPoint);
                    centreMaxGearPoint = CentrePoint(gearDesignOutputParams, endMaxGearPoint, maxAngle);
                    startMaxGearPoint = StartPoint(gearDesignOutputParams, centreMaxGearPoint);
                }

                distanceToStartMaxPoint = Geometry.DistanceBetweenPoints(centre, startMaxGearPoint);

                // max test value
                maxTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMaxPoint);

                // calculate distance to mid start point
                distanceToStartMidPoint = Geometry.DistanceBetweenPoints(centre, startMidGearPoint);

                // test value this needs to tend towards zero
                midTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMidPoint);

                distanceToStartMinPoint = Geometry.DistanceBetweenPoints(centre, startMinGearPoint);

                // min test value
                minTestValue = Math.Abs(targetGearCentreToStartPointDistance - distanceToStartMinPoint);
            }

            var kappaRadians = Radians(gearDesignOutputParams.Kappa);
            var lhsEndMidGearPoint = GearPoint.Mirror(endMidGearPoint, 90).Rotate(kappaRadians);
            var lhsCentreMidGearPoint = GearPoint.Mirror(centreMidGearPoint, 90).Rotate(kappaRadians);
            var lhsStartMidGearPoint = GearPoint.Mirror(startMidGearPoint, 90).Rotate(kappaRadians);

            GearPoint[] results = new[] {endMidGearPoint, centreMidGearPoint, startMidGearPoint, lhsEndMidGearPoint, lhsCentreMidGearPoint, lhsStartMidGearPoint};


            return results;
        }



      
        public static List<GearPoint> BuildBasicInternalInvolute(IGearDesignOutputParams gearDesignOutputParams, int steps)
        {
            List<GearPoint> involuteList = Geometry.InvolutePoints(gearDesignOutputParams.BaseCircleDiameter / 2,
                gearDesignOutputParams.RootCircleDiameter / 2, steps);
            return involuteList;
        }

       
       
    }
}