using System;

namespace Bolsover.Gear
{
    public class GearBuilder
    {
        public GearToothPoints BuildGearToothPoints(GearToothPoints gearToothPoints)
        {
            if (gearToothPoints.G1.GearType == GearType.External)
            {
                BuildExternalToothPoints(gearToothPoints);
            }
            else
            {
                BuildInternalToothPoints(gearToothPoints);
            }


            return gearToothPoints;
        }

        private void BuildInternalToothPoints(GearToothPoints gearToothPoints)
        {
            InvoluteGear gear = gearToothPoints.G1;
            var outerRingDiameter = GearCalculations.OuterRingDiameter(gear);
            // rotation for left section of gear tooth
            var rotateRadians = Point.Radians(GearCalculations.RotateDegrees(gear));
            // the basic right involute curve
            gearToothPoints.RightInvolute = Geometry.InvolutePoints(GearCalculations.BaseRadiusRb(gear),
                GearCalculations.RootDiameterDr(gear) / 2, 25);

            // trim the involute if the addendum circle is larger than the base circle
            // Point pointq;
            if (GearCalculations.AddendumRadiusRa(gear) > GearCalculations.BaseRadiusRb(gear))
            {
                var addendumPoint = new Point(GearCalculations.AddendumRadiusRa(gear), 0);

                gearToothPoints.RightInvolute =
                    Geometry.PointsFromIntersectionWithRootFillet(gearToothPoints.RightInvolute, addendumPoint);
            }

            Point[] filletPoints = GearCalculations.CalcAddendumFilletPoints(gear);

            gearToothPoints.RightAddendumFilletEnd = filletPoints[0];
            gearToothPoints.RightAddendumFilletCentre = filletPoints[1];
            gearToothPoints.RightAddendumFilletStart = filletPoints[2];


            gearToothPoints.LeftAddendumFilletEnd =
                Point.Mirror(gearToothPoints.RightAddendumFilletEnd, 90).Rotate(rotateRadians);
            gearToothPoints.LeftAddendumFilletCentre =
                Point.Mirror(gearToothPoints.RightAddendumFilletCentre, 90).Rotate(rotateRadians);
            gearToothPoints.LeftAddendumFilletStart =
                Point.Mirror(gearToothPoints.RightAddendumFilletStart, 90).Rotate(rotateRadians);

            gearToothPoints.RightInvolute = Geometry.PointsFromIntersectionWithRootFillet(gearToothPoints.RightInvolute,
                gearToothPoints.RightAddendumFilletEnd);
            gearToothPoints.RightInvolute[0] = gearToothPoints.RightAddendumFilletEnd;

            // Mirror and rotate right involute points to create Left involute
            gearToothPoints.LeftInvolute = Point.MirrorPoints(gearToothPoints.RightInvolute, 90);
            gearToothPoints.LeftInvolute = Point.Rotated(gearToothPoints.LeftInvolute, rotateRadians);

            gearToothPoints.RightInvoluteEnd = gearToothPoints.RightInvolute[gearToothPoints.RightInvolute.Count - 1];
            gearToothPoints.LeftInvoluteEnd = gearToothPoints.LeftInvolute[gearToothPoints.LeftInvolute.Count - 1];

            gearToothPoints.RightInvoluteStart = gearToothPoints.RightInvolute[0];
            gearToothPoints.LeftInvoluteStart = gearToothPoints.LeftInvolute[0];

            // left mid outer 
            gearToothPoints.LeftMidOuter = new Point(GearCalculations.OuterRingDiameter(gear) / 2, 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Point.Radians(180 / gear.TeethZ));
            // right mid outer
            gearToothPoints.RightMidOuter = gearToothPoints.LeftMidOuter.Rotate(Point.Radians(-360 / gear.TeethZ));

            // left mid Addendum
            gearToothPoints.LeftMidAddendum = new Point(GearCalculations.AddendumRadiusRa(gear), 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Point.Radians(180 / gear.TeethZ));
            // right mid Addendum
            gearToothPoints.RightMidAddendum = gearToothPoints.LeftMidAddendum.Rotate(Point.Radians(-360 / gear.TeethZ));

            // left mid Base
            gearToothPoints.LeftMidBase = new Point(GearCalculations.BaseRadiusRb(gear), 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Point.Radians(180 / gear.TeethZ));
            // right mid Addendum
            gearToothPoints.RightMidBase = gearToothPoints.LeftMidBase.Rotate(Point.Radians(-360 / gear.TeethZ));
        }

        private void BuildExternalToothPoints(GearToothPoints gearToothPoints)
        {
            InvoluteGear gear = gearToothPoints.G1;
            // rotation for left section of gear tooth
            var rotateRadians = Point.Radians(GearCalculations.RotateDegrees(gear));
            // the basic right involute curve
            gearToothPoints.RightInvolute = Geometry.InvolutePoints(GearCalculations.BaseRadiusRb(gear),
                GearCalculations.AddendumRadiusRa(gear), 25);
            //initial position of root fillet - will need to be adjusted to end at start of right involute
            gearToothPoints.RightRootFilletEnd = GearCalculations.RootFilletEndPoint(gear);
            // start point of the tip relief
            gearToothPoints.RightTipReliefStart = Geometry.StartPointOnInvoluteOfTipRelief(
                GearCalculations.BaseRadiusRb(gear),
                GearCalculations.AddendumRadiusRa(gear), GearCalculations.AddendumReliefRadiusRa(gear));
            // trim the right involute as required to fit root fillet and tip relief
            gearToothPoints.RightInvolute = Geometry.TrimmedInvolutePoints(gearToothPoints.RightInvolute,
                gearToothPoints.RightTipReliefStart, gearToothPoints.RightRootFilletEnd);
            // angle though which right root fillet needs to be rotated to correctly intersect the right involute
            var angleToAdjustedRightRootFilletEnd =
                Geometry.AngleToPointOnCircle(gearToothPoints.GearCentre, gearToothPoints.RightInvolute[0]);
            // adjust the root fillet points
            gearToothPoints.RightRootFilletEnd =
                gearToothPoints.RightRootFilletEnd.Rotate(angleToAdjustedRightRootFilletEnd);
            gearToothPoints.RightRootFilletCentre =
                GearCalculations.RootFilletCentrePoint(gear).Rotate(angleToAdjustedRightRootFilletEnd);
            gearToothPoints.RightRootFilletStart =
                GearCalculations.RootFilletStartPoint(gear).Rotate(angleToAdjustedRightRootFilletEnd);

            // tip relief centre point
            gearToothPoints.RightTipReliefCentre = Geometry.CentrePointOfTipRelief(GearCalculations.BaseRadiusRb(gear),
                GearCalculations.AddendumRadiusRa(gear), GearCalculations.AddendumReliefRadiusRa(gear));
            // tip relief end point
            gearToothPoints.RightTipReliefEnd = Geometry.EndPointOnAddendumOfTipRelief(GearCalculations.BaseRadiusRb(gear),
                GearCalculations.AddendumRadiusRa(gear), GearCalculations.AddendumReliefRadiusRa(gear));
            // tip centre point
            gearToothPoints.ToothTipCentre =
                new Point(GearCalculations.AddendumRadiusRa(gear), 0).Rotate(rotateRadians / 2); //good
            // left mid root point
            gearToothPoints.LeftMidRoot = new Point(GearCalculations.RootDiameterDr(gear) / 2, 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Point.Radians(180 / gear.TeethZ));
            // right mid root point
            gearToothPoints.RightMidRoot = gearToothPoints.LeftMidRoot.Rotate(Point.Radians(-360 / gear.TeethZ));
            // left side points are mirrored, rotated copies of right side
            gearToothPoints.LeftRootFilletStart = Point.Mirror(gearToothPoints.RightRootFilletStart, 90)
                .Rotate(rotateRadians);

            gearToothPoints.LeftRootFilletCentre = Point.Mirror(gearToothPoints.RightRootFilletCentre, 90)
                .Rotate(rotateRadians);

            gearToothPoints.LeftRootFilletEnd = Point.Mirror(gearToothPoints.RightRootFilletEnd, 90)
                .Rotate(rotateRadians);

            gearToothPoints.LeftTipReliefStart = Point.Mirror(gearToothPoints.RightTipReliefStart, 90)
                .Rotate(rotateRadians);

            gearToothPoints.LeftTipReliefCentre = Point.Mirror(gearToothPoints.RightTipReliefCentre, 90)
                .Rotate(rotateRadians);

            gearToothPoints.LeftTipReliefEnd = Point.Mirror(gearToothPoints.RightTipReliefEnd, 90)
                .Rotate(rotateRadians);


            // Mirror and rotate right involute points to create Left involute
            gearToothPoints.LeftInvolute = Point.MirrorPoints(gearToothPoints.RightInvolute, 90);
            gearToothPoints.LeftInvolute = Point.Rotated(gearToothPoints.LeftInvolute, rotateRadians);
        }
    }
}