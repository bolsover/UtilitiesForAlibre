using System;
using AlibreX;

namespace Bolsover.CycloidalGear
{
    public class CycloidalGearBuilder
    {
        private CycloidalGearProperties _gearProperties;
        private IADDesignSession _session;
        private double _errorLimit = 0.000001D;

        public CycloidalGearBuilder(CycloidalGearProperties gearProperties, IADDesignSession session)
        {
            _gearProperties = gearProperties;
            _session = session;
            BuildGear();
        }

        private void BuildGear()
        {
            var sketch = CreateSketch(_session);
            ComputeWheel();
            sketch.BeginChange();
            if (_gearProperties.DrawWheel)
            {
                DrawWheel(sketch);
            }

            if (_gearProperties.DrawPinion)
            {
                DrawPinion(sketch);
            }

            //sketch.Figures.AddLine(0.0, 0.0, 5.5, 6.6);
            sketch.EndChange();
        }

        /// <summary>
        /// From http://www.csparks.com/watchmaking/CycloidalGears/index.jhtml:
        /// The nominal width of a tooth or a space when they are equally spaced is just pi/2, or about 1.57.
        /// For pinions, we will reduce the width of the tooth a bit. For pinions with 6-10 leaves, the tooth
        /// width at the pitch circle is 1.05. For pinions with 11 or more teeth the tooth width is 1.25.
        /// </summary>
        private void InitializePinionToothWidth()
        {
            if (_gearProperties.PinionCount <= 10)
            {
                _gearProperties.PinionHalfToothAngle =
                    1.05D * _gearProperties.Module / _gearProperties.PinionPitchDiameter;
            }

            else
            {
                _gearProperties.PinionHalfToothAngle =
                    1.25D * _gearProperties.Module / _gearProperties.PinionPitchDiameter;
            }
        }

        /// <summary>
        /// For details see the Profile - Leaves tables in
        /// http://www.csparks.com/watchmaking/CycloidalGears/index.jhtml
        /// </summary>
        private void InitialIzePinionAddendum()
        {
            if (_gearProperties.PinionCount <= 7)
            {
                //  high ogival
                _gearProperties.PinionAddendum = 0.855D * _gearProperties.Module;
                _gearProperties.PinionAddendumRadius = 1.05D * _gearProperties.Module;
            }

            else if (_gearProperties.PinionCount == 8 | _gearProperties.PinionCount == 9)
            {
                // medium ogival
                _gearProperties.PinionAddendum = 0.67D * _gearProperties.Module;
                _gearProperties.PinionAddendumRadius = 0.7D * _gearProperties.Module;
            }
            else if (_gearProperties.PinionCount == 10)
            {
                // round top for small tooth
                _gearProperties.PinionAddendum = 0.525D * _gearProperties.Module;
                _gearProperties.PinionAddendumRadius = 0.525D * _gearProperties.Module;
            }
            else
            {
                // 11+ teeth, round top for wider tooth
                _gearProperties.PinionAddendum = 0.625D * _gearProperties.Module;
                _gearProperties.PinionAddendumRadius = 0.625D * _gearProperties.Module;
            }
        }

        private void InitPinion()
        {
            _gearProperties.PinionPitchDiameter = _gearProperties.Module * _gearProperties.PinionCount;
            if (_gearProperties.CustomSlopEnabled)
            {
                _gearProperties.PinionDedendum = _gearProperties.WheelAddendum + _gearProperties.CustomSlop;
            }
            else
            {
                _gearProperties.PinionDedendum =
                    _gearProperties.Module * (_gearProperties.PracticalWheelAddendumFactor + 0.4);
            }

            InitializePinionToothWidth();
            InitialIzePinionAddendum();
        }


        public double Radians(double angle)
        {
            return Math.PI / 180 * angle;
        }

        private void DrawWheel(IADSketch sketch)
        {
            var wheelCentreX = 0.0D;
            var wheelCentreY = 0.0D;
            var outerDiameter = _gearProperties.WheelPitchDiameter + _gearProperties.WheelAddendum * 2;
            var innerDiameter = _gearProperties.WheelPitchDiameter - _gearProperties.WheelDedendum * 2;
            var outerRadius = outerDiameter / 2;
            var innerRadius = innerDiameter / 2;
            var wheelPitchRadius = _gearProperties.WheelPitchDiameter / 2;
            var toothAngle = 360.0 / _gearProperties.WheelCount;
            for (var i = 0; i < _gearProperties.WheelCount; i++)
            {
                var refAngleApex = toothAngle * i;
                var nextRefAngleApex = toothAngle * (i + 1);
                var point1X = outerRadius * Math.Cos(Radians(refAngleApex));
                var point1Y = outerRadius * Math.Sin(Radians(refAngleApex));
                var point2X = wheelPitchRadius * Math.Cos(Radians(refAngleApex + toothAngle / 4));
                var point2Y = wheelPitchRadius * Math.Sin(Radians(refAngleApex + toothAngle / 4));
                var point3X = innerRadius * Math.Cos(Radians(refAngleApex + toothAngle / 4));
                var point3Y = innerRadius * Math.Sin(Radians(refAngleApex + toothAngle / 4));
                var point4X = innerRadius * Math.Cos(Radians(refAngleApex - toothAngle / 4));
                var point4Y = innerRadius * Math.Sin(Radians(refAngleApex - toothAngle / 4));
                var point5X = wheelPitchRadius * Math.Cos(Radians(refAngleApex - toothAngle / 4));
                var point5Y = wheelPitchRadius * Math.Sin(Radians(refAngleApex - toothAngle / 4));
                var point6X = innerRadius * Math.Cos(Radians(nextRefAngleApex - toothAngle / 4));
                var point6Y = innerRadius * Math.Sin(Radians(nextRefAngleApex - toothAngle / 4));
                var pointA = new Point(point1X, point1Y);
                var pointB = new Point(point2X, point2Y);
                var pointC = new Point(point5X, point5Y);
                var wheelCenter = new Point(0.0D, 0.0D);

                var radCenter =
                    ComputeAddedumRadiusCenter(_gearProperties.WheelAddendumRadius, pointA, pointB, wheelCenter);
                sketch.Figures.AddCircularArcByCenterStartEnd(radCenter.X / 10, radCenter.Y / 10,
                    point1X / 10, point1Y / 10, point2X / 10, point2Y / 10);

                radCenter =
                    ComputeAddedumRadiusCenter(_gearProperties.WheelAddendumRadius, pointC, pointA, wheelCenter);
                sketch.Figures.AddCircularArcByCenterStartEnd(radCenter.X / 10, radCenter.Y / 10,
                    point5X / 10, point5Y / 10, point1X / 10, point1Y / 10);

                sketch.Figures.AddLine(point2X / 10, point2Y / 10, point3X / 10, point3Y / 10);
                sketch.Figures.AddLine(point4X / 10, point4Y / 10, point5X / 10, point5Y / 10);

                sketch.Figures.AddCircularArcByCenterStartEnd(wheelCentreX, wheelCentreY, point3X / 10,
                    point3Y / 10, point6X / 10, point6Y / 10);
            }

            var wheelPitchDiameter =
                sketch.Figures.AddCircle(wheelCentreX, wheelCentreY, _gearProperties.WheelPitchDiameter / 20);
            wheelPitchDiameter.IsReference = true;

            if (_gearProperties.WheelCentreHole > 0)
            {
                var wheelCenterHole =
                    sketch.Figures.AddCircle(wheelCentreX, wheelCentreY, _gearProperties.WheelCentreHole / 20);
            }
        }

        private void DrawPinion(IADSketch sketch)
        {
            InitPinion();
            var pinionCentreX = _gearProperties.WheelPitchDiameter + _gearProperties.PinionPitchDiameter;
            var pinionCentreY = 0.0D;
            var outerDiameter = _gearProperties.PinionPitchDiameter + _gearProperties.PinionAddendum * 2;
            var innerDiameter = _gearProperties.PinionPitchDiameter - _gearProperties.PinionDedendum * 2;
            var outerRadius = outerDiameter / 2;
            var innerRadius = innerDiameter / 2;
            var pinionPitchRadius = _gearProperties.PinionPitchDiameter / 2;
            var toothAngle = 360.0 / _gearProperties.PinionCount;
            var halfToothAngle = _gearProperties.PinionHalfToothAngle;

            for (var i = 0; i < _gearProperties.PinionCount; i++)
            {
                var refAngleApex = toothAngle * i;
                var nextRefAngleApex = toothAngle * (i + 1);
                var point1X = outerRadius * Math.Cos(Radians(refAngleApex)) + pinionCentreX;
                var point1Y = outerRadius * Math.Sin(Radians(refAngleApex));
                var point2X = pinionPitchRadius * Math.Cos(Radians(refAngleApex) + halfToothAngle) +
                              pinionCentreX;
                var point2Y = pinionPitchRadius * Math.Sin(Radians(refAngleApex) + halfToothAngle);
                var point3X = innerRadius * Math.Cos(Radians(refAngleApex) + halfToothAngle) + pinionCentreX;
                var point3Y = innerRadius * Math.Sin(Radians(refAngleApex) + halfToothAngle);
                var point4X = innerRadius * Math.Cos(Radians(refAngleApex) - halfToothAngle) + pinionCentreX;
                var point4Y = innerRadius * Math.Sin(Radians(refAngleApex) - halfToothAngle);
                var point5X = pinionPitchRadius * Math.Cos(Radians(refAngleApex) - halfToothAngle) +
                              pinionCentreX;
                var point5Y = pinionPitchRadius * Math.Sin(Radians(refAngleApex) - halfToothAngle);
                var point6X = innerRadius * Math.Cos(Radians(nextRefAngleApex) - halfToothAngle) +
                              pinionCentreX;
                var point6Y = innerRadius * Math.Sin(Radians(nextRefAngleApex) - halfToothAngle);
                var pointA = new Point(point1X, point1Y);
                var pointB = new Point(point2X, point2Y);
                var pointC = new Point(point5X, point5Y);
                var pinionCenter = new Point(pinionCentreX, pinionCentreY);

                var radCenter = ComputeAddedumRadiusCenter(_gearProperties.PinionAddendumRadius, pointA, pointB,
                    pinionCenter);
                sketch.Figures.AddCircularArcByCenterStartEnd(radCenter.X / 10, radCenter.Y / 10,
                    point1X / 10, point1Y / 10, point2X / 10, point2Y / 10);
                radCenter = ComputeAddedumRadiusCenter(_gearProperties.PinionAddendumRadius, pointC, pointA,
                    pinionCenter);
                sketch.Figures.AddCircularArcByCenterStartEnd(radCenter.X / 10, radCenter.Y / 10,
                    point5X / 10, point5Y / 10, point1X / 10, point1Y / 10);
                sketch.Figures.AddLine(point2X / 10, point2Y / 10, point3X / 10, point3Y / 10);
                sketch.Figures.AddLine(point4X / 10, point4Y / 10, point5X / 10, point5Y / 10);
                sketch.Figures.AddCircularArcByCenterStartEnd(pinionCenter.X / 10, pinionCenter.Y / 10, point3X / 10,
                    point3Y / 10, point6X / 10, point6Y / 10);
            }

            if (_gearProperties.PinionCentreHole > 0)
            {
                var circlecentre =
                    sketch.Figures.AddCircle(pinionCentreX / 10, pinionCentreY / 10,
                        _gearProperties.PinionCentreHole / 20);
            }
        }

        private Point ComputeAddedumRadiusCenter(double radius, Point a, Point b, Point center)
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

            var radiusCentre = new Point(centerx1, centery1);
            //var gear_centre = new Point(0.0D, 0.0D);

            if (IsPointWithinWheel(center, radiusCentre, _gearProperties.WheelPitchDiameter))
            {
                return radiusCentre;
            }

            radiusCentre.X = centerx2;
            radiusCentre.Y = centery2;
            return radiusCentre;
        }

        private bool IsPointWithinWheel(Point wheelCentre, Point testPoint, double wheelRadius)
        {
            var dX = testPoint.X - wheelCentre.X;
            var dY = testPoint.Y - wheelCentre.Y;
            var px = Math.Sqrt(dX * dX + dY * dY);
            return px <= wheelRadius;
        }

        private double ComputeAddendumFactor()
        {
            var t0 = 1.0;
            var t1 = 0.0;
            var r2 = 2.0 * _gearProperties.WheelCount / _gearProperties.PinionCount;
            while (Math.Abs(t1 - t0) > _errorLimit)
            {
                t0 = t1;
                var b = Math.Atan2(Math.Sin(t0), 1.0 + r2 - Math.Cos(t0));
                t1 = Math.PI / _gearProperties.PinionCount + r2 * b;
            }

            var k = 1.0 + r2;
            var d = Math.Sqrt(1.0 + k * k - 2.0 * k * Math.Cos(t1));
            var result = 0.25 * _gearProperties.PinionCount * (1.0 - k + d);
            return result;
        }

        private void ComputeWheel()
        {
            _gearProperties.WheelAddFactor = ComputeAddendumFactor();
            _gearProperties.PracticalWheelAddendumFactor = _gearProperties.WheelAddFactor * 0.95;
            _gearProperties.GearRatio = (double)_gearProperties.WheelCount / _gearProperties.PinionCount;
            _gearProperties.WheelCircularPitch = _gearProperties.Module * Math.PI;
            _gearProperties.WheelDedendum = _gearProperties.Module * Math.PI / 2;
            _gearProperties.WheelPitchDiameter = _gearProperties.Module * _gearProperties.WheelCount;
            _gearProperties.PinionPitchDiameter = _gearProperties.Module * _gearProperties.PinionCount;
            _gearProperties.WheelAddendum = _gearProperties.Module * 0.95 * _gearProperties.WheelAddFactor;
            _gearProperties.WheelAddendumRadius = _gearProperties.Module * 1.4 * _gearProperties.WheelAddFactor;
        }

        private IADSketch CreateSketch(IADDesignSession session)
        {
            var sketch = session.Sketches.AddSketch(null, _gearProperties.Plane, "Gear");
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