using System;
using System.Collections.Generic;
using AlibreX;

namespace Bolsover.Gears
{
    public class AlibreGearBuilder
    {
        // private IADDesignPlane plane;


        private ExternalGearParameters parameters;


        public void BuildPinion()
        {
            var sketchs = ((IADDesignSession) parameters.PinionSession).Sketches;
            var sketch = sketchs.Item("Tooth");
            var figures = sketch.Figures;
            sketch.BeginChange();
            figures.Item(0).Delete();
            var scale = 0.1;
            var centre = new Point(0, 0);

            // add reference circles to sketch
            DrawPinionReferenceCircles(sketch, parameters, scale);
            // build the first Involute curve;

            var curvePoints = parameters.InvoluteCurvePoints1();


            // trim the curve points to remove any below the intersection with the root fillet
            curvePoints = parameters.PointsFromIntersectionWithRootFilletPointE(curvePoints, parameters.RootFilletXe1);

            var pointc = parameters.StartPointOnInvoluteOfTipRelief();

            curvePoints = parameters.PointsToIntersectionWithTipReliefArc(curvePoints, pointc);


            var dPointrot =
                new Point(parameters.PointD1.X, parameters.PointD1.Y).Rotate(
                    parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            var aPointrot =
                new Point(parameters.PointA1.X, parameters.PointA1.Y).Rotate(
                    parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            var ePointrot =
                new Point(parameters.PointE1.X, parameters.PointE1.Y).Rotate(
                    parameters.AngleToPointOnCircle(centre, curvePoints[0]));


            AddScaledCircularArcByCenterStartEnd(sketch, dPointrot, ePointrot,
                aPointrot, scale);

// reflect the first curve.
            var mirrorPoints = Point.MirrorPoints(curvePoints, 90);
            // rotate the mirror pints to form opposing involute curve

            var rotatedMirrorPoints = Point.Rotated(mirrorPoints, Point.Radians(parameters.RotateDegrees1));

            var drPoint = Point.Mirror(parameters.PointD1, 90).Rotate(Point.Radians(parameters.RotateDegrees1))
                .Rotate(-parameters.AngleToPointOnCircle(centre, curvePoints[0]));

            //root fillet start
            var arPoint = Point.Mirror(parameters.PointA1, 90).Rotate(Point.Radians(parameters.RotateDegrees1))
                .Rotate(-parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            var erPoint = Point.Mirror(parameters.PointE1, 90).Rotate(Point.Radians(parameters.RotateDegrees1))
                .Rotate(-parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            AddScaledCircularArcByCenterStartEnd(sketch, drPoint, arPoint,
                erPoint, scale);


            // add first curve to sketch
            AddScaledBsplineByInterpolation(sketch, curvePoints, scale);

            // opposing tooth face
            AddScaledBsplineByInterpolation(sketch, rotatedMirrorPoints, scale);

            // addendum curve
            // AddScaledCircularArcByCenterStartEnd(sketch, centre, curvePoints[curvePoints.Count - 1],
            //     rotatedMirrorPoints[rotatedMirrorPoints.Count - 1],
            //     scale);

            if (parameters.BaseDiameterDb1 > parameters.RootDiameterDr1 + parameters.FilletDiameter)
            {
                AddScaledLine(sketch, ePointrot, curvePoints[0], scale);
                AddScaledLine(sketch, erPoint, rotatedMirrorPoints[0], scale);
            }

//tip mid point
            Point p1 = new Point(parameters.TipDiameterDa1 / 2, 0).Rotate(Point.Radians(parameters.RotateDegrees1 / 2));

            IADSketchLine toothCentre = AddScaledLine(sketch, centre, p1, scale);
            toothCentre.IsReference = true;

            // right mid tooth
            Point p2 = new Point(parameters.RootDiameterDr1 / 2, 0)
                .Rotate(Point.Radians(parameters.RotateDegrees1 / 2))
                .Rotate(Point.Radians(180 / parameters.TeethZ1));
            AddScaledLine(sketch, centre, p2, scale);

            AddScaledCircularArcByCenterStartEnd(sketch, centre, arPoint, p2, scale);


            Point p3 = p2.Rotate(Point.Radians(-360 / parameters.TeethZ1));
            AddScaledLine(sketch, centre, p3, scale);

            AddScaledCircularArcByCenterStartEnd(sketch, centre, p3, aPointrot, scale);

//--------------------------------------------------------------------------------------------------
            // var pointc = parameters.StartPointOnInvoluteOfTipRelief();
            var pointa = parameters.CentrePointOfTipRelief();
            var pointb = parameters.EndPointOnAddendumOfTipRelief();


            IADSketchLine testc = AddScaledLine(sketch, centre, pointc, scale);
            testc.IsReference = true;
            IADSketchLine testa = AddScaledLine(sketch, pointc, pointa, scale);
            testa.IsReference = true;
            IADSketchLine testb = AddScaledLine(sketch, pointa, pointb, scale);
            testb.IsReference = true;
// tip relief 1
            AddScaledCircularArcByCenterStartEnd(sketch, pointa, curvePoints[curvePoints.Count - 1], pointb, scale);

            var pointcr = Point.Mirror(pointc, 90).Rotate(Point.Radians(parameters.RotateDegrees1))
                .Rotate(-parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            var pointar = Point.Mirror(pointa, 90).Rotate(Point.Radians(parameters.RotateDegrees1))
                .Rotate(-parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            var pointbr = Point.Mirror(pointb, 90).Rotate(Point.Radians(parameters.RotateDegrees1))
                .Rotate(-parameters.AngleToPointOnCircle(centre, curvePoints[0]));


            IADSketchLine testcr = AddScaledLine(sketch, centre, pointcr, scale);
            testcr.IsReference = true;
            IADSketchLine testar = AddScaledLine(sketch, pointcr, pointar, scale);
            testar.IsReference = true;
            IADSketchLine testbr = AddScaledLine(sketch, pointar, pointbr, scale);
            testbr.IsReference = true;
// tip relief 2
            AddScaledCircularArcByCenterStartEnd(sketch, pointar, pointbr, rotatedMirrorPoints[rotatedMirrorPoints.Count - 1], scale);
            // addendum curve
            AddScaledCircularArcByCenterStartEnd(sketch, centre, pointb, pointbr, scale);
//---------------------------------------------------------------------------------------------------           
            parameters.PinionSession.Parameters.OpenParameterTransaction();

            parameters.PinionSession.Parameters.Item("C1").Value = parameters.TeethZ1;
            // parameters.PinionSession.Parameters.Item("D3").Value = 0.025;
            if (parameters.HelixAngle > 0)
            {
                parameters.PinionSession.Parameters.Item("D3").Value = parameters.HelixPitchLength1 * scale;
            }

            parameters.PinionSession.Parameters.CloseParameterTransaction();


            sketch.EndChange();
            ((IADPartSession) parameters.PinionSession).RegenerateAll();
        }

        public void BuildWheel()
        {
            var sketchs = ((IADDesignSession) parameters.WheelSession).Sketches;
            var sketch = sketchs.Item("Tooth");
            var figures = sketch.Figures;
            sketch.BeginChange();
            figures.Item(0).Delete();
            var scale = 0.1;
            var centre = new Point(0, 0);

            // add reference circles to sketch
            DrawWheelReferenceCircles(sketch, parameters, scale);
            // build the first Involute curve;

            var curvePoints = parameters.InvoluteCurvePoints2();


            // trim the curve points to remove any below the intersection with the root fillet
            curvePoints = parameters.PointsFromIntersectionWithRootFilletPointE(curvePoints, parameters.RootFilletXe2);


            var dPointrot =
                new Point(parameters.PointD2.X, parameters.PointD2.Y).Rotate(
                    parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            var aPointrot =
                new Point(parameters.PointA2.X, parameters.PointA2.Y).Rotate(
                    parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            var ePointrot =
                new Point(parameters.PointE2.X, parameters.PointE2.Y).Rotate(
                    parameters.AngleToPointOnCircle(centre, curvePoints[0]));


            AddScaledCircularArcByCenterStartEnd(sketch, dPointrot, ePointrot,
                aPointrot, scale);

// reflect the first curve.
            var mirrorPoints = Point.MirrorPoints(curvePoints, 90);
            // rotate the mirror pints to form opposing involute curve

            var rotatedMirrorPoints = Point.Rotated(mirrorPoints, Point.Radians(parameters.RotateDegrees2));

            var drPoint = Point.Mirror(parameters.PointD2, 90).Rotate(Point.Radians(parameters.RotateDegrees2))
                .Rotate(-parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            var arPoint = Point.Mirror(parameters.PointA2, 90).Rotate(Point.Radians(parameters.RotateDegrees2))
                .Rotate(-parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            var erPoint = Point.Mirror(parameters.PointE2, 90).Rotate(Point.Radians(parameters.RotateDegrees2))
                .Rotate(-parameters.AngleToPointOnCircle(centre, curvePoints[0]));
            AddScaledCircularArcByCenterStartEnd(sketch, drPoint, arPoint,
                erPoint, scale);


            // add first curve to sketch
            AddScaledBsplineByInterpolation(sketch, curvePoints, scale);

            AddScaledBsplineByInterpolation(sketch, rotatedMirrorPoints, scale);

            AddScaledCircularArcByCenterStartEnd(sketch, centre, curvePoints[curvePoints.Count - 1],
                rotatedMirrorPoints[rotatedMirrorPoints.Count - 1],
                scale);
            if (parameters.BaseDiameterDb2 > parameters.RootDiameterDr2 + parameters.FilletDiameter)
            {
                AddScaledLine(sketch, ePointrot, curvePoints[0], scale);
                AddScaledLine(sketch, erPoint, rotatedMirrorPoints[0], scale);
            }


            Point p1 = new Point(parameters.TipDiameterDa2 / 2, 0).Rotate(Point.Radians(parameters.RotateDegrees2 / 2));

            IADSketchLine toothCentre = AddScaledLine(sketch, centre, p1, scale);
            toothCentre.IsReference = true;

            Point p2 = new Point(parameters.RootDiameterDr2 / 2, 0)
                .Rotate(Point.Radians(parameters.RotateDegrees2 / 2))
                .Rotate(Point.Radians(180 / parameters.TeethZ2));
            AddScaledLine(sketch, centre, p2, scale);

            AddScaledCircularArcByCenterStartEnd(sketch, centre, arPoint, p2, scale);


            Point p3 = p2.Rotate(Point.Radians(-360 / parameters.TeethZ2));
            AddScaledLine(sketch, centre, p3, scale);

            AddScaledCircularArcByCenterStartEnd(sketch, centre, p3, aPointrot, scale);

            parameters.WheelSession.Parameters.OpenParameterTransaction();

            parameters.WheelSession.Parameters.Item("C1").Value = parameters.TeethZ2;
            if (parameters.HelixAngle > 0)
            {
                parameters.WheelSession.Parameters.Item("D3").Value = parameters.HelixPitchLength2 * scale;
            }

            parameters.WheelSession.Parameters.CloseParameterTransaction();


            sketch.EndChange();
            ((IADPartSession) parameters.WheelSession).RegenerateAll();
        }


        public AlibreGearBuilder(ExternalGearParameters parameters)
        {
            this.parameters = parameters;
        }

        private void DrawPinionReferenceCircles(IADSketch sketch, ExternalGearParameters parameters, double scale)
        {
            DrawCircle(sketch, parameters.Centre, parameters.BaseDiameterDb1, scale, true);
            // DrawCircle(sketch, parameters.Centre, parameters.RootDiameterDr1, scale, true);
            DrawCircle(sketch, parameters.Centre, parameters.TipDiameterDa1, scale, true);
            // DrawCircle(sketch, parameters.Centre, parameters.ReferenceDiameterD1, scale, true);
            // var matingGearCentre = new Point(parameters.WorkingCentreDistanceAw, 0);
            // DrawCircle(sketch, matingGearCentre, parameters.BaseDiameterDb2, scale, true);
            // DrawCircle(sketch, matingGearCentre, parameters.RootDiameterDr2, scale, true);
            // DrawCircle(sketch, matingGearCentre, parameters.TipDiameterDa2, scale, true);
            // DrawCircle(sketch, matingGearCentre, parameters.ReferenceDiameterD2, scale, true);
        }

        private void DrawWheelReferenceCircles(IADSketch sketch, ExternalGearParameters parameters, double scale)
        {
            DrawCircle(sketch, parameters.Centre, parameters.BaseDiameterDb2, scale, true);
            // DrawCircle(sketch, parameters.Centre, parameters.RootDiameterDr2, scale, true);
            DrawCircle(sketch, parameters.Centre, parameters.TipDiameterDa2, scale, true);
            // DrawCircle(sketch, parameters.Centre, parameters.ReferenceDiameterD2, scale, true);
            // var matingGearCentre = new Point(parameters.WorkingCentreDistanceAw, 0);
            // DrawCircle(sketch, matingGearCentre, parameters.BaseDiameterDb1, scale, true);
            // DrawCircle(sketch, matingGearCentre, parameters.RootDiameterDr1, scale, true);
            // DrawCircle(sketch, matingGearCentre, parameters.TipDiameterDa1, scale, true);
            // DrawCircle(sketch, matingGearCentre, parameters.ReferenceDiameterD1, scale, true);
        }

        private IADSketchCircle DrawCircle(IADSketch sketch, Point centre, double diameter, double scale,
            bool isReference)
        {
            var circle = sketch.Figures.AddCircle(centre.X * scale, centre.Y * scale, diameter / 2 * scale);
            circle.IsReference = isReference;
            return circle;
        }


        private IADSketchLine AddScaledLine(IADSketch sketch, Point start, Point end, double scale)
        {
            return sketch.Figures.AddLine(start.X * scale, start.Y * scale, end.X * scale, end.Y * scale);
        }

        private IADSketchCircularArc AddScaledCircularArcByCenterStartEnd(IADSketch sketch, Point centre, Point start,
            Point end, double scale)
        {
            return sketch.Figures.AddCircularArcByCenterStartEnd(centre.X * scale, centre.Y * scale,
                start.X * scale, start.Y * scale, end.X * scale,
                end.Y * scale);
        }


        private IADSketchBspline AddScaledBsplineByInterpolation(IADSketch sketch, List<Point> points, double scale)
        {
            Array interpolationPoints = new double[points.Count * 2];
            var j = 0;
            foreach (var point in points)
            {
                interpolationPoints.SetValue(point.X * scale, j++);
                interpolationPoints.SetValue(point.Y * scale, j++);
            }

            return sketch.Figures.AddBsplineByInterpolation(ref interpolationPoints);
        }

        private IADSketchLine TestTipPoints(IADSketch sketch)
        {
            Point start = parameters.CoordinateIntersectionCircleWithInvolute(parameters.BaseDiameterDb1 / 2, parameters.TipDiameterDa1 / 2);
            Point end = parameters.CoordinateIntersectionCircleWithInvolute(parameters.BaseDiameterDb1 / 2, (parameters.TipDiameterDa1 - 0.5) / 2);
            return AddScaledLine(sketch, start, end, 0.1);
        }
    }
}