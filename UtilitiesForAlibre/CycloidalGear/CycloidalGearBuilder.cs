using System;
using AlibreX;

namespace Bolsover.CycloidalGear
{
    public class CycloidalGearBuilder
    {
        private CycloidalGearProperties GearProperties;
        private IADDesignSession Session;
        private double errorLimit = 0.000001D;

        public CycloidalGearBuilder(CycloidalGearProperties gearProperties, IADDesignSession session)
        {
            GearProperties = gearProperties;
            Session = session;
            buildGear();
        }

        private void buildGear()
        {
            var sketch = createSketch(Session);
            computeWheel();
            sketch.BeginChange();
            if (GearProperties.DrawWheel) drawWheel(sketch);
            if (GearProperties.DrawPinion) drawPinion(sketch);
            //sketch.Figures.AddLine(0.0, 0.0, 5.5, 6.6);
            sketch.EndChange();
        }

        /// <summary>
        /// From http://www.csparks.com/watchmaking/CycloidalGears/index.jhtml:
        /// The nominal width of a tooth or a space when they are equally spaced is just pi/2, or about 1.57.
        /// For pinions, we will reduce the width of the tooth a bit. For pinions with 6-10 leaves, the tooth
        /// width at the pitch circle is 1.05. For pinions with 11 or more teeth the tooth width is 1.25.
        /// </summary>
        private void initializePinionToothWidth()
        {
            if (GearProperties.PinionCount <= 10)
                GearProperties.PinionHalfToothAngle =
                    1.05D * GearProperties.Module / GearProperties.PinionPitchDiameter;

            else
                GearProperties.PinionHalfToothAngle =
                    1.25D * GearProperties.Module / GearProperties.PinionPitchDiameter;
        }

        /// <summary>
        /// For details see the Profile - Leaves tables in
        /// http://www.csparks.com/watchmaking/CycloidalGears/index.jhtml
        /// </summary>
        private void initialIzePinionAddendum()
        {
            if (GearProperties.PinionCount <= 7)
            {
                //  high ogival
                GearProperties.PinionAddendum = 0.855D * GearProperties.Module;
                GearProperties.PinionAddendumRadius = 1.05D * GearProperties.Module;
            }

            else if ((GearProperties.PinionCount == 8) | (GearProperties.PinionCount == 9))
            {
                // medium ogival
                GearProperties.PinionAddendum = 0.67D * GearProperties.Module;
                GearProperties.PinionAddendumRadius = 0.7D * GearProperties.Module;
            }
            else if (GearProperties.PinionCount == 10)
            {
                // round top for small tooth
                GearProperties.PinionAddendum = 0.525D * GearProperties.Module;
                GearProperties.PinionAddendumRadius = 0.525D * GearProperties.Module;
            }
            else
            {
                // 11+ teeth, round top for wider tooth
                GearProperties.PinionAddendum = 0.625D * GearProperties.Module;
                GearProperties.PinionAddendumRadius = 0.625D * GearProperties.Module;
            }
        }

        private void initPinion()
        {
            GearProperties.PinionPitchDiameter = GearProperties.Module * GearProperties.PinionCount;
            if (GearProperties.CustomSlopEnabled)
                GearProperties.PinionDedendum = GearProperties.WheelAddendum + GearProperties.CustomSlop;
            else
                GearProperties.PinionDedendum =
                    GearProperties.Module * (GearProperties.PracticalWheelAddendumFactor + 0.4);
            initializePinionToothWidth();
            initialIzePinionAddendum();
        }


        public double Radians(double angle)
        {
            return Math.PI / 180 * angle;
        }

        private void drawWheel(IADSketch sketch)
        {
            var wheelCentreX = 0.0D;
            var wheelCentreY = 0.0D;
            var outerDiameter = GearProperties.WheelPitchDiameter + GearProperties.WheelAddendum * 2;
            var innerDiameter = GearProperties.WheelPitchDiameter - GearProperties.WheelDedendum * 2;
            var outerRadius = outerDiameter / 2;
            var innerRadius = innerDiameter / 2;
            var wheelPitchRadius = GearProperties.WheelPitchDiameter / 2;
            var toothAngle = 360.0 / GearProperties.WheelCount;
            for (var i = 0; i < GearProperties.WheelCount; i++)
            {
                var refAngleApex = toothAngle * i;
                var nextRefAngleApex = toothAngle * (i + 1);
                var point_1_x = outerRadius * Math.Cos(Radians(refAngleApex));
                var point_1_y = outerRadius * Math.Sin(Radians(refAngleApex));
                var point_2_x = wheelPitchRadius * Math.Cos(Radians(refAngleApex + toothAngle / 4));
                var point_2_y = wheelPitchRadius * Math.Sin(Radians(refAngleApex + toothAngle / 4));
                var point_3_x = innerRadius * Math.Cos(Radians(refAngleApex + toothAngle / 4));
                var point_3_y = innerRadius * Math.Sin(Radians(refAngleApex + toothAngle / 4));
                var point_4_x = innerRadius * Math.Cos(Radians(refAngleApex - toothAngle / 4));
                var point_4_y = innerRadius * Math.Sin(Radians(refAngleApex - toothAngle / 4));
                var point_5_x = wheelPitchRadius * Math.Cos(Radians(refAngleApex - toothAngle / 4));
                var point_5_y = wheelPitchRadius * Math.Sin(Radians(refAngleApex - toothAngle / 4));
                var point_6_x = innerRadius * Math.Cos(Radians(nextRefAngleApex - toothAngle / 4));
                var point_6_y = innerRadius * Math.Sin(Radians(nextRefAngleApex - toothAngle / 4));
                var point_a = new Point(point_1_x, point_1_y);
                var point_b = new Point(point_2_x, point_2_y);
                var point_c = new Point(point_5_x, point_5_y);
                var wheelCenter = new Point(0.0D, 0.0D);

                var rad_center =
                    computeAddedumRadiusCenter(GearProperties.WheelAddendumRadius, point_a, point_b, wheelCenter);
                sketch.Figures.AddCircularArcByCenterStartEnd(rad_center.X / 10, rad_center.Y / 10,
                    point_1_x / 10, point_1_y / 10, point_2_x / 10, point_2_y / 10);

                rad_center =
                    computeAddedumRadiusCenter(GearProperties.WheelAddendumRadius, point_c, point_a, wheelCenter);
                sketch.Figures.AddCircularArcByCenterStartEnd(rad_center.X / 10, rad_center.Y / 10,
                    point_5_x / 10, point_5_y / 10, point_1_x / 10, point_1_y / 10);

                sketch.Figures.AddLine(point_2_x / 10, point_2_y / 10, point_3_x / 10, point_3_y / 10);
                sketch.Figures.AddLine(point_4_x / 10, point_4_y / 10, point_5_x / 10, point_5_y / 10);

                sketch.Figures.AddCircularArcByCenterStartEnd(wheelCentreX, wheelCentreY, point_3_x / 10,
                    point_3_y / 10, point_6_x / 10, point_6_y / 10);
            }

            var wheelPitchDiameter =
                sketch.Figures.AddCircle(wheelCentreX, wheelCentreY, GearProperties.WheelPitchDiameter / 20);
            wheelPitchDiameter.IsReference = true;

            if (GearProperties.WheelCentreHole > 0)
            {
                var wheelCenterHole =
                    sketch.Figures.AddCircle(wheelCentreX, wheelCentreY, GearProperties.WheelCentreHole / 20);
            }
        }

        private void drawPinion(IADSketch sketch)
        {
            initPinion();
            var pinion_centre_x = GearProperties.WheelPitchDiameter + GearProperties.PinionPitchDiameter;
            var pinion_centre_y = 0.0D;
            var outer_diameter = GearProperties.PinionPitchDiameter + GearProperties.PinionAddendum * 2;
            var inner_diameter = GearProperties.PinionPitchDiameter - GearProperties.PinionDedendum * 2;
            var outer_radius = outer_diameter / 2;
            var inner_radius = inner_diameter / 2;
            var pinion_pitch_radius = GearProperties.PinionPitchDiameter / 2;
            var toothAngle = 360.0 / GearProperties.PinionCount;
            var half_tooth_angle = GearProperties.PinionHalfToothAngle;

            for (var i = 0; i < GearProperties.PinionCount; i++)
            {
                var refAngleApex = toothAngle * i;
                var nextRefAngleApex = toothAngle * (i + 1);
                var point_1_x = outer_radius * Math.Cos(Radians(refAngleApex)) + pinion_centre_x;
                var point_1_y = outer_radius * Math.Sin(Radians(refAngleApex));
                var point_2_x = pinion_pitch_radius * Math.Cos(Radians(refAngleApex) + half_tooth_angle) +
                                pinion_centre_x;
                var point_2_y = pinion_pitch_radius * Math.Sin(Radians(refAngleApex) + half_tooth_angle);
                var point_3_x = inner_radius * Math.Cos(Radians(refAngleApex) + half_tooth_angle) + pinion_centre_x;
                var point_3_y = inner_radius * Math.Sin(Radians(refAngleApex) + half_tooth_angle);
                var point_4_x = inner_radius * Math.Cos(Radians(refAngleApex) - half_tooth_angle) + pinion_centre_x;
                var point_4_y = inner_radius * Math.Sin(Radians(refAngleApex) - half_tooth_angle);
                var point_5_x = pinion_pitch_radius * Math.Cos(Radians(refAngleApex) - half_tooth_angle) +
                                pinion_centre_x;
                var point_5_y = pinion_pitch_radius * Math.Sin(Radians(refAngleApex) - half_tooth_angle);
                var point_6_x = inner_radius * Math.Cos(Radians(nextRefAngleApex) - half_tooth_angle) +
                                pinion_centre_x;
                var point_6_y = inner_radius * Math.Sin(Radians(nextRefAngleApex) - half_tooth_angle);
                var point_a = new Point(point_1_x, point_1_y);
                var point_b = new Point(point_2_x, point_2_y);
                var point_c = new Point(point_5_x, point_5_y);
                var pinionCenter = new Point(pinion_centre_x, pinion_centre_y);

                var rad_center = computeAddedumRadiusCenter(GearProperties.PinionAddendumRadius, point_a, point_b,
                    pinionCenter);
                sketch.Figures.AddCircularArcByCenterStartEnd(rad_center.X / 10, rad_center.Y / 10,
                    point_1_x / 10, point_1_y / 10, point_2_x / 10, point_2_y / 10);
                rad_center = computeAddedumRadiusCenter(GearProperties.PinionAddendumRadius, point_c, point_a,
                    pinionCenter);
                sketch.Figures.AddCircularArcByCenterStartEnd(rad_center.X / 10, rad_center.Y / 10,
                    point_5_x / 10, point_5_y / 10, point_1_x / 10, point_1_y / 10);
                sketch.Figures.AddLine(point_2_x / 10, point_2_y / 10, point_3_x / 10, point_3_y / 10);
                sketch.Figures.AddLine(point_4_x / 10, point_4_y / 10, point_5_x / 10, point_5_y / 10);
                sketch.Figures.AddCircularArcByCenterStartEnd(pinionCenter.X / 10, pinionCenter.Y / 10, point_3_x / 10,
                    point_3_y / 10, point_6_x / 10, point_6_y / 10);
            }

            if (GearProperties.PinionCentreHole > 0)
            {
                var circlecentre =
                    sketch.Figures.AddCircle(pinion_centre_x / 10, pinion_centre_y / 10,
                        GearProperties.PinionCentreHole / 20);
            }
        }

        private Point computeAddedumRadiusCenter(double radius, Point a, Point b, Point center)
        {
            var q = Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
            var y3 = (a.Y + b.Y) / 2;
            var x3 = (a.X + b.X) / 2;
            var basex = Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(q / 2, 2)) * (a.Y - b.Y) / q;
            var basey = Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(q / 2, 2)) * (b.X - a.X) / q;
            var centerx1 = x3 + basex;
            var centery1 = y3 + basey;
            var centerx2 = x3 - basex;
            var centery2 = y3 - basey;

            var radius_centre = new Point(centerx1, centery1);
            //var gear_centre = new Point(0.0D, 0.0D);

            if (isPointWithinWheel(center, radius_centre, GearProperties.WheelPitchDiameter)) return radius_centre;

            radius_centre.X = centerx2;
            radius_centre.Y = centery2;
            return radius_centre;
        }

        private bool isPointWithinWheel(Point wheel_centre, Point test_point, double wheel_radius)
        {
            var d_x = test_point.X - wheel_centre.X;
            var d_y = test_point.Y - wheel_centre.Y;
            var px = Math.Sqrt(d_x * d_x + d_y * d_y);
            return px <= wheel_radius;
        }

        private double computeAddendumFactor()
        {
            var t0 = 1.0;
            var t1 = 0.0;
            var r2 = 2.0 * GearProperties.WheelCount / GearProperties.PinionCount;
            while (Math.Abs(t1 - t0) > errorLimit)
            {
                t0 = t1;
                var b = Math.Atan2(Math.Sin(t0), 1.0 + r2 - Math.Cos(t0));
                t1 = Math.PI / GearProperties.PinionCount + r2 * b;
            }

            var k = 1.0 + r2;
            var d = Math.Sqrt(1.0 + k * k - 2.0 * k * Math.Cos(t1));
            var result = 0.25 * GearProperties.PinionCount * (1.0 - k + d);
            return result;
        }

        private void computeWheel()
        {
            GearProperties.WheelAddFactor = computeAddendumFactor();
            GearProperties.PracticalWheelAddendumFactor = GearProperties.WheelAddFactor * 0.95;
            GearProperties.GearRatio = GearProperties.WheelCount / GearProperties.PinionCount;
            GearProperties.WheelCircularPitch = GearProperties.Module * Math.PI;
            GearProperties.WheelDedendum = GearProperties.Module * Math.PI / 2;
            GearProperties.WheelPitchDiameter = GearProperties.Module * GearProperties.WheelCount;
            GearProperties.PinionPitchDiameter = GearProperties.Module * GearProperties.PinionCount;
            GearProperties.WheelAddendum = GearProperties.Module * 0.95 * GearProperties.WheelAddFactor;
            GearProperties.WheelAddendumRadius = GearProperties.Module * 1.4 * GearProperties.WheelAddFactor;
        }

        private IADSketch createSketch(IADDesignSession session)
        {
            var sketch = session.Sketches.AddSketch(null, GearProperties.Plane, "Gear");
            return sketch;
        }

        private class Point
        {
            public double X;
            public double Y;

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
    }
}