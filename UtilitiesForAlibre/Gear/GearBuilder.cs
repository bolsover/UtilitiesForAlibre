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
            InvoluteGear gear1;
            InvoluteGear gear2;

            if (gearToothPoints.IsPinion)
            {
                gear1 = gearPair.G1;
                gear2 = gearPair.G2;
            }
            else
            {
                gear2 = gearPair.G1;
                gear1 = gearPair.G2;
            }

            // rotation for left section of gear tooth
            var rotateRadians = Point.Radians(gearPair.RotateDegrees(gear1));
            // the basic right involute curve
            gearToothPoints.RightInvolute = Geometry.InvolutePoints(gear1.BaseRadiusRb, gearPair.AddendumRadiusRa(gear1, gear2), 25);
            //initial position of root fillet - will need to be adjusted to end at start of right involute
            gearToothPoints.RightRootFilletEnd = gearPair.RootFilletEndPoint(gear1);
            // start point of the tip relief
            gearToothPoints.RightTipReliefStart = geometry.StartPointOnInvoluteOfTipRelief(gear1.BaseRadiusRb, gearPair.AddendumRadiusRa(gear1, gear2), gear1.AddendumFilletFactorRa);
            // trim the right involute as required to fit root fillet ant tip relief
            gearToothPoints.RightInvolute = geometry.TrimmedInvolutePoints(gearToothPoints.RightInvolute, gearToothPoints.RightTipReliefStart, gearToothPoints.RightRootFilletEnd);
            // angle though which right root fillet needs to be rotated to correctly intersect the right involute
            var angleToAdjustedRightRootFilletEnd = Geometry.AngleToPointOnCircle(gearToothPoints.GearCentre, gearToothPoints.RightInvolute[0]);
            // adjust the root fillet points
            gearToothPoints.RightRootFilletEnd = gearToothPoints.RightRootFilletEnd.Rotate(angleToAdjustedRightRootFilletEnd);
            gearToothPoints.RightRootFilletCentre = gearPair.RootFilletCentrePoint(gear1).Rotate(angleToAdjustedRightRootFilletEnd);
            gearToothPoints.RightRootFilletStart = gearPair.RootFilletStartPoint(gear1).Rotate(angleToAdjustedRightRootFilletEnd);

            // tip relief centre point
            gearToothPoints.RightTipReliefCentre = geometry.CentrePointOfTipRelief(gear1.BaseRadiusRb, gearPair.AddendumRadiusRa(gear1, gear2), gear1.AddendumFilletFactorRa);
            // tip relief end point
            gearToothPoints.RightTipReliefEnd = geometry.EndPointOnAddendumOfTipRelief(gear1.BaseRadiusRb, gearPair.AddendumRadiusRa(gear1, gear2), gear1.AddendumFilletFactorRa);
            // tip centre point
            gearToothPoints.ToothTipCentre = new Point(gearPair.AddendumRadiusRa(gear1, gear2), 0).Rotate(rotateRadians / 2); //good
            // left mid root point
            gearToothPoints.LeftMidRoot = new Point(gear1.RootDiameterDr / 2, 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Point.Radians(180 / gear1.TeethZ));
            // right mid root point
            gearToothPoints.RightMidRoot = gearToothPoints.LeftMidRoot.Rotate(Point.Radians(-360 / gear1.TeethZ));
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