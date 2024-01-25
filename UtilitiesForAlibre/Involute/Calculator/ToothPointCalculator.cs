using System;
using System.Collections.Generic;
using Bolsover.Gear.Calculators;
using Bolsover.Gear.Models;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Calculator
{
    public static class ToothPointCalculator
    {
        public static List<GearPoint> RhsInvolute(IGearDesignOutputParams gearDesignOutputParams)
        {
            var RHSinvolute = BuildBasicInvolute(gearDesignOutputParams, 25);
            var rootFilletEnd = GearPointRhsEndRootRelief(gearDesignOutputParams);
            var tipReliefStart = RhsStartOfTipRelief(gearDesignOutputParams);
            RHSinvolute = Geometry.TrimmedInvolutePoints(RHSinvolute, tipReliefStart, rootFilletEnd);

            return RHSinvolute;
        }
        
     

        public static GearPoint RhsStartInvolute(IGearDesignOutputParams gearDesignOutputParams)
        {
            var RHSinvolute = BuildBasicInvolute(gearDesignOutputParams, 25);
            var rootFilletEnd = GearPointRhsEndRootRelief(gearDesignOutputParams);
            var tipReliefStart = RhsStartOfTipRelief(gearDesignOutputParams);
            RHSinvolute = Geometry.TrimmedInvolutePoints(RHSinvolute, tipReliefStart, rootFilletEnd);

            return RHSinvolute[0];
        }

        public static List<GearPoint> LhsInvolute(IGearDesignOutputParams gearDesignOutputParams)
        {
            var rightInvolute = BuildBasicInvolute(gearDesignOutputParams, 25);
            var rootFilletEnd = GearPointRhsEndRootRelief(gearDesignOutputParams);

            var point6 = RhsStartOfTipRelief(gearDesignOutputParams);
            rightInvolute = Geometry.TrimmedInvolutePoints(rightInvolute,
                point6, rootFilletEnd);
            var kappaRadians = Radians(gearDesignOutputParams.Kappa);

            var leftInvolute = GearPoint.MirrorPoints(rightInvolute, 90);
            leftInvolute = GearPoint.Rotated(leftInvolute, kappaRadians);
            return leftInvolute;
        }

        public static GearPoint LhsStartInvolute(IGearDesignOutputParams gearDesignOutputParams)
        {
            var rightInvolute = BuildBasicInvolute(gearDesignOutputParams, 25);
            var rootFilletEnd = GearPointRhsEndRootRelief(gearDesignOutputParams);

            var point6 = RhsStartOfTipRelief(gearDesignOutputParams);
            rightInvolute = Geometry.TrimmedInvolutePoints(rightInvolute,
                point6, rootFilletEnd);
            var kappaRadians = Radians(gearDesignOutputParams.Kappa);

            var leftInvolute = GearPoint.MirrorPoints(rightInvolute, 90);
            leftInvolute = GearPoint.Rotated(leftInvolute, kappaRadians);
            return leftInvolute[0];
        }

        public static double AngleToRootFilletCentre(IGearDesignOutputParams gearDesignOutputParams)
        {
            var result =  Math.Asin(gearDesignOutputParams.RootFilletDiameter / (gearDesignOutputParams.RootCircleDiameter + gearDesignOutputParams.RootFilletDiameter));
            return result;
        }
           

        public static GearPoint RhsRootFilletCentre(IGearDesignOutputParams gearDesignOutputParams)
        {
            var rhSinvolute = BuildBasicInvolute(gearDesignOutputParams, 25);
            var ex = gearDesignOutputParams.RootCircleDiameter / 2 * Math.Tan(AngleToRootFilletCentre(gearDesignOutputParams)) +
                     gearDesignOutputParams.RootCircleDiameter / 2 / Math.Cos(AngleToRootFilletCentre(gearDesignOutputParams));

            var rootFilletEnd = new GearPoint(ex, 0);

            var tipReliefStart = RhsStartOfTipRelief(gearDesignOutputParams);
            rhSinvolute = Geometry.TrimmedInvolutePoints(rhSinvolute,
                tipReliefStart, rootFilletEnd);
            var centre = new GearPoint(0, 0);
            var x = (gearDesignOutputParams.RootFilletDiameter + gearDesignOutputParams.RootCircleDiameter) / 2 *
                    Math.Cos(AngleToFilletCentre(gearDesignOutputParams));
            var y = -((gearDesignOutputParams.RootFilletDiameter/2) + gearDesignOutputParams.RootCircleDiameter / 2) *
                    Math.Sin(AngleToFilletCentre(gearDesignOutputParams));
            var angleToAdjustedRightRootFilletEnd = Geometry.AngleToPointOnCircle(centre, rhSinvolute[0]);
            var result = new GearPoint(x, y).Rotate(angleToAdjustedRightRootFilletEnd);
            return result;
        }
        
        public static GearPoint LhsCentreRootRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            var rhs = RhsRootFilletCentre(gearDesignOutputParams);
            var kappaRadians = Radians(gearDesignOutputParams.Kappa);
            return GearPoint.Mirror(rhs, 90).Rotate(kappaRadians);
        }

      

        public static GearPoint GearPointRhsEndRootRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            var rhSinvolute = BuildBasicInvolute(gearDesignOutputParams, 25);
            var x = gearDesignOutputParams.RootCircleDiameter / 2 * Math.Tan(AngleToRootFilletCentre(gearDesignOutputParams)) +
                    gearDesignOutputParams.RootCircleDiameter / 2 / Math.Cos(AngleToRootFilletCentre(gearDesignOutputParams));

            var rootFilletEnd = new GearPoint(x, 0);

            var tipReliefStart = RhsStartOfTipRelief(gearDesignOutputParams);
            rhSinvolute = Geometry.TrimmedInvolutePoints(rhSinvolute,
                tipReliefStart, rootFilletEnd);
            var centre = new GearPoint(0, 0);
            var angleToAdjustedRightRootFilletEnd = Geometry.AngleToPointOnCircle(centre, rhSinvolute[0]);

            var result = rootFilletEnd.Rotate(angleToAdjustedRightRootFilletEnd);
            return result;
        }

        public static GearPoint LhsEndTipRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            var baseRadius = gearDesignOutputParams.BaseCircleDiameter / 2;
            var addendumRadius = gearDesignOutputParams.OutsideDiameter / 2;
            var tipReliefRadius = gearDesignOutputParams.TipReliefRadius;
            var kappaRadians = Radians(gearDesignOutputParams.Kappa);
            var rhs = Geometry.EndPointOnAddendumOfTipRelief(baseRadius, addendumRadius, tipReliefRadius);
            return GearPoint.Mirror(rhs, 90).Rotate(kappaRadians);
        }

        public static List<GearPoint> BuildBasicInvolute(IGearDesignOutputParams gearDesignOutputParams, int steps)
        {
            List<GearPoint> involuteList = Geometry.InvolutePoints(gearDesignOutputParams.BaseCircleDiameter / 2,
                gearDesignOutputParams.OutsideDiameter / 2, steps);
            return involuteList;
        }
        
        

        public static GearPoint CentrePointOutsideDiameter(IGearDesignOutputParams gearDesignOutputParams)
        {
            var rhSinvolute = BuildBasicInvolute(gearDesignOutputParams, 4);
            var kappaRadians = Radians(gearDesignOutputParams.Kappa);

            var lhSinvolute = GearPoint.MirrorPoints(rhSinvolute, 90);
            lhSinvolute = GearPoint.Rotated(lhSinvolute, kappaRadians);
            return Geometry.MidPoint(rhSinvolute[4], lhSinvolute[4]);
        }

        public static GearPoint RhsCentreOfTipRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            var baseRadius = gearDesignOutputParams.BaseCircleDiameter / 2;
            var addendumRadius = gearDesignOutputParams.OutsideDiameter / 2;
            var tipReliefRadius = gearDesignOutputParams.TipReliefRadius;
            return Geometry.CentrePointOfTipRelief(baseRadius, addendumRadius, tipReliefRadius);
        }

        public static GearPoint RhsEndTipRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            var baseRadius = gearDesignOutputParams.BaseCircleDiameter / 2;
            var addendumRadius = gearDesignOutputParams.OutsideDiameter / 2;
            var tipReliefRadius = gearDesignOutputParams.TipReliefRadius;

            var result = Geometry.EndPointOnAddendumOfTipRelief(baseRadius, addendumRadius, tipReliefRadius);
            return result;
        }

        public static GearPoint RhsMidRoot(IGearDesignOutputParams gearDesignOutputParams)
        {
            var midRoot = new GearPoint(gearDesignOutputParams.RootCircleDiameter / 2, 0)
                .Rotate(Radians(gearDesignOutputParams.Kappa / 2))
                .Rotate(Radians(180 / gearDesignOutputParams.GearDesignInputParams.Teeth))
                .Rotate(Radians(-360 / gearDesignOutputParams.GearDesignInputParams.Teeth));
            return midRoot;
        }
        
        public static GearPoint LhsMidRoot(IGearDesignOutputParams gearDesignOutputParams)
        {
            var midRoot = new GearPoint(gearDesignOutputParams.RootCircleDiameter / 2, 0)
                .Rotate(Radians(gearDesignOutputParams.Kappa / 2))
                .Rotate(Radians(180 / gearDesignOutputParams.GearDesignInputParams.Teeth))
                .Rotate(Radians(-360 / gearDesignOutputParams.GearDesignInputParams.Teeth));
            var kappaRadians = Radians(gearDesignOutputParams.Kappa);
            return GearPoint.Mirror(midRoot, 90).Rotate(kappaRadians);
        }

        /// <summary>
        /// Calculates the X,Y coordinate of the point at which the tip relief radius starts.
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns>Start point of the tip relief radius</returns>
        public static GearPoint RhsStartOfTipRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            var baseRadius = gearDesignOutputParams.BaseCircleDiameter / 2;
            var addendumRadius = gearDesignOutputParams.OutsideDiameter / 2;
            var tipReliefRadius = gearDesignOutputParams.TipReliefRadius;
            var distanceToInvolute = CentreToTipReliefRadiusStart(baseRadius, addendumRadius, tipReliefRadius);
            GearPoint pointc = PointOnInvolute(baseRadius, distanceToInvolute);
            return pointc;
        }
        
        public static GearPoint LhsStartOfTipRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            var baseRadius = gearDesignOutputParams.BaseCircleDiameter / 2;
            var addendumRadius = gearDesignOutputParams.OutsideDiameter / 2;
            var tipReliefRadius = gearDesignOutputParams.TipReliefRadius;
            var distanceToInvolute = CentreToTipReliefRadiusStart(baseRadius, addendumRadius, tipReliefRadius);
            GearPoint pointc = PointOnInvolute(baseRadius, distanceToInvolute);
            var kappaRadians = Radians(gearDesignOutputParams.Kappa);
            return GearPoint.Mirror(pointc, 90).Rotate(kappaRadians);
        }

        /// <summary>
        /// Calculates a point in the involute at a distance from the gear centre (0,0)
        /// </summary>
        /// <param name="baseRadius"></param>
        /// <param name="distanceToInvolute"></param>
        /// <returns>A point in the involute at a distance from the gear centre</returns>
        public static GearPoint PointOnInvolute(double baseRadius, double distanceToInvolute)
        {
            var alpha = Math.Acos(baseRadius / distanceToInvolute);
            var invAlpha = Math.Tan(alpha) - alpha; // involute function
            var x = distanceToInvolute * Math.Cos(invAlpha); // X coordinate
            var y = distanceToInvolute * Math.Sin(invAlpha); // Y coordinate
            return new GearPoint(x, y);
        }
        
        // public static GearPoint LhsStartRootRelief(IGearDesignOutputParams gearDesignOutputParams)
        // {
        //     var rhs =  ToothPointCalculator.RhsStartOfTipRelief(gearDesignOutputParams);
        //     var kappaRadians = Radians(gearDesignOutputParams.Kappa);
        //     return GearPoint.Mirror(rhs, 90).Rotate(kappaRadians);
        // }
        public static GearPoint LhsEndRootRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            // var result = GearPointRhsEndRootRelief(gearDesignOutputParams);
            var result = GearPointRhsEndRootRelief(gearDesignOutputParams);
            var kappaRadians = Radians(gearDesignOutputParams.Kappa);
            return GearPoint.Mirror(result, 90).Rotate(kappaRadians);
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
        /// Returns the angle in radians to the centre of the root fillet circle
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        public static double AngleToFilletCentre(IGearDesignOutputParams gearDesignOutputParams) =>
            Math.Asin(gearDesignOutputParams.RootFilletDiameter / ((gearDesignOutputParams.RootCircleDiameter + gearDesignOutputParams.RootFilletDiameter)));

        public static GearPoint RhsStartRootRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            var rhSinvolute = BuildBasicInvolute(gearDesignOutputParams, 25);
            var ex = gearDesignOutputParams.RootCircleDiameter / 2 * Math.Tan(AngleToRootFilletCentre(gearDesignOutputParams)) +
                     gearDesignOutputParams.RootCircleDiameter / 2 / Math.Cos(AngleToRootFilletCentre(gearDesignOutputParams));
            var rootFilletEnd = new GearPoint(ex, 0);
            var tipReliefStart = ToothPointCalculator.RhsStartOfTipRelief(gearDesignOutputParams);

            rhSinvolute = Geometry.TrimmedInvolutePoints(rhSinvolute, tipReliefStart, rootFilletEnd);
            var centre = new GearPoint(0, 0);
            var angleToAdjustedRightRootFilletEnd = Geometry.AngleToPointOnCircle(centre, rhSinvolute[0]);
            var angleToFilletCentre = Math.Asin(gearDesignOutputParams.RootFilletDiameter / ((gearDesignOutputParams.RootCircleDiameter) + gearDesignOutputParams.RootFilletDiameter));
            var rootFilletStartX = gearDesignOutputParams.RootCircleDiameter / 2 * Math.Cos(angleToFilletCentre);
            var rootFilletStartY = -gearDesignOutputParams.RootCircleDiameter / 2 * Math.Sin(angleToFilletCentre);

            return new GearPoint(rootFilletStartX, rootFilletStartY).Rotate(angleToAdjustedRightRootFilletEnd);
        }

        public static GearPoint LhsStartRootRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            var rhSinvolute = BuildBasicInvolute(gearDesignOutputParams, 25);
            var ex = gearDesignOutputParams.RootCircleDiameter / 2 * Math.Tan(AngleToRootFilletCentre(gearDesignOutputParams)) +
                     gearDesignOutputParams.RootCircleDiameter / 2 / Math.Cos(AngleToRootFilletCentre(gearDesignOutputParams));
            var rootFilletEnd = new GearPoint(ex, 0);
            var tipReliefStart = ToothPointCalculator.RhsStartOfTipRelief(gearDesignOutputParams);

            rhSinvolute = Geometry.TrimmedInvolutePoints(rhSinvolute, tipReliefStart, rootFilletEnd);
            var centre = new GearPoint(0, 0);
            var angleToAdjustedRightRootFilletEnd = Geometry.AngleToPointOnCircle(centre, rhSinvolute[0]);
            var angleToFilletCentre = Math.Asin(gearDesignOutputParams.RootFilletDiameter / ((gearDesignOutputParams.RootCircleDiameter) + gearDesignOutputParams.RootFilletDiameter));
            var rootFilletStartX = gearDesignOutputParams.RootCircleDiameter / 2 * Math.Cos(angleToFilletCentre);
            var rootFilletStartY = -gearDesignOutputParams.RootCircleDiameter / 2 * Math.Sin(angleToFilletCentre);
            var kappaRadians = Radians(gearDesignOutputParams.Kappa);
            var rhsCentre = new GearPoint(rootFilletStartX, rootFilletStartY).Rotate(angleToAdjustedRightRootFilletEnd);
            return GearPoint.Mirror(rhsCentre, 90).Rotate(kappaRadians);
        }

        public static GearPoint LhsCentreTipRelief(IGearDesignOutputParams gearDesignOutputParams)
        {
            var baseRadius = gearDesignOutputParams.BaseCircleDiameter / 2;
            var addendumRadius = gearDesignOutputParams.OutsideDiameter / 2;
            var tipReliefRadius = gearDesignOutputParams.TipReliefRadius;
            var kappaRadians = Radians(gearDesignOutputParams.Kappa);
            var rhsCentre = Geometry.CentrePointOfTipRelief(baseRadius, addendumRadius, tipReliefRadius);

            return GearPoint.Mirror(rhsCentre, 90).Rotate(kappaRadians);
        }
    }
}