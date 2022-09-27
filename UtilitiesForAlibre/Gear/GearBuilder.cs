namespace Bolsover.Gear
{
    public class GearBuilder
    {
        public GearToothPoints BuildGearToothPoints(GearPair gearPair, bool isPinion)
        {
            GearToothPoints gearToothPoints = new GearToothPoints();
            gearToothPoints.GearCentre = new Point(0, 0);
            // gear is helical if the helix pitch angle is greater than 0 degrees.
            gearToothPoints.IsHelical = gearPair.G1.HelixAngleBeta > 0;
            gearToothPoints.IsPinion = isPinion;
            gearToothPoints.Pair = gearPair;

            BuildToothPoints(gearPair, gearToothPoints);
            return gearToothPoints;
        }

        private void BuildToothPoints(GearPair gearPair, GearToothPoints gearToothPoints)
        {
            Geometry geometry = new Geometry();
            InvoluteGear g1;
            InvoluteGear g2;

            if (gearToothPoints.IsPinion)
            {
                g1 = gearPair.G1;
                g2 = gearPair.G2;
            }
            else
            {
                g2 = gearPair.G1;
                g1 = gearPair.G2;
            }

            // rotation for left section of gear tooth
            var rotateRadians = Point.Radians(GearCalculations.RotateDegrees(g1, g2));
            // the basic right involute curve
            gearToothPoints.RightInvolute = Geometry.InvolutePoints(GearCalculations.BaseRadiusRb(g1), GearCalculations.AddendumRadiusRa(g1, g2), 25);
            //initial position of root fillet - will need to be adjusted to end at start of right involute
            gearToothPoints.RightRootFilletEnd = GearCalculations.RootFilletEndPoint(g1);
            // start point of the tip relief
            gearToothPoints.RightTipReliefStart = geometry.StartPointOnInvoluteOfTipRelief(GearCalculations.BaseRadiusRb(g1), GearCalculations.AddendumRadiusRa(g1, g2), g1.AddendumFilletFactorRa);
            // trim the right involute as required to fit root fillet ant tip relief
            gearToothPoints.RightInvolute = geometry.TrimmedInvolutePoints(gearToothPoints.RightInvolute, gearToothPoints.RightTipReliefStart, gearToothPoints.RightRootFilletEnd);
            // angle though which right root fillet needs to be rotated to correctly intersect the right involute
            var angleToAdjustedRightRootFilletEnd = Geometry.AngleToPointOnCircle(gearToothPoints.GearCentre, gearToothPoints.RightInvolute[0]);
            // adjust the root fillet points
            gearToothPoints.RightRootFilletEnd = gearToothPoints.RightRootFilletEnd.Rotate(angleToAdjustedRightRootFilletEnd);
            gearToothPoints.RightRootFilletCentre = GearCalculations.RootFilletCentrePoint(g1).Rotate(angleToAdjustedRightRootFilletEnd);
            gearToothPoints.RightRootFilletStart = GearCalculations.RootFilletStartPoint(g1).Rotate(angleToAdjustedRightRootFilletEnd);

            // tip relief centre point
            gearToothPoints.RightTipReliefCentre = geometry.CentrePointOfTipRelief(GearCalculations.BaseRadiusRb(g1), GearCalculations.AddendumRadiusRa(g1, g2), g1.AddendumFilletFactorRa);
            // tip relief end point
            gearToothPoints.RightTipReliefEnd = geometry.EndPointOnAddendumOfTipRelief(GearCalculations.BaseRadiusRb(g1), GearCalculations.AddendumRadiusRa(g1, g2), g1.AddendumFilletFactorRa);
            // tip centre point
            gearToothPoints.ToothTipCentre = new Point(GearCalculations.AddendumRadiusRa(g1, g2), 0).Rotate(rotateRadians / 2); //good
            // left mid root point
            gearToothPoints.LeftMidRoot = new Point(GearCalculations.RootDiameterDr(g1) / 2, 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Point.Radians(180 / g1.TeethZ));
            // right mid root point
            gearToothPoints.RightMidRoot = gearToothPoints.LeftMidRoot.Rotate(Point.Radians(-360 / g1.TeethZ));
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