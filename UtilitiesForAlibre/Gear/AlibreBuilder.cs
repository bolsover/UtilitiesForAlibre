using System;
using System.Collections.Generic;
using AlibreX;
using Bolsover.Gear;

namespace Bolsover.Gear
{
    public class AlibreBuilder
    {
        private GearToothPoints gearToothPoints;
        private IADDesignSession session;

        public AlibreBuilder(GearToothPoints gearToothPoints, IADDesignSession session)
        {
            this.gearToothPoints = gearToothPoints;
            this.session = session;
            buildGear();
        }

        public void buildGear()
        {
            var sketchs = session.Sketches;
            var sketch = sketchs.Item("Tooth");
            var figures = sketch.Figures;
            // open the sketch for changes
            sketch.BeginChange();
            // the existing sketch has a placeholder - just delete
            figures.Item(0).Delete();
            // the default Alibre units are cm. Scale everything by 0.1 for correct mm dimensions
            var scale = 0.1;
            InvoluteGear gear1;
            if (gearToothPoints.IsPinion)
            {
                gear1 = gearToothPoints.Pair.G1;
            }
            else
            {
                gear1 = gearToothPoints.Pair.G2;
            }

            // draw line from centre to right root midpoint
            AddScaledLine(sketch, gearToothPoints.GearCentre, gearToothPoints.RightMidRoot, scale);
            //draw arc from right root midpoint to right root fillet start
            AddScaledCircularArcByCenterStartEnd(sketch, gearToothPoints.GearCentre, gearToothPoints.RightMidRoot, gearToothPoints.RightRootFilletStart, scale);
            //draw right root fillet
            AddScaledCircularArcByCenterStartEnd(sketch, gearToothPoints.RightRootFilletCentre, gearToothPoints.RightRootFilletEnd, gearToothPoints.RightRootFilletStart, scale);
            // draw right involute
            AddScaledBsplineByInterpolation(sketch, gearToothPoints.RightInvolute, scale);
            // draw right tip relief
            AddScaledCircularArcByCenterStartEnd(sketch, gearToothPoints.RightTipReliefCentre, gearToothPoints.RightTipReliefStart, gearToothPoints.RightTipReliefEnd, scale);
            // draw addendum arc
            AddScaledCircularArcByCenterStartEnd(sketch, gearToothPoints.GearCentre, gearToothPoints.RightTipReliefEnd, gearToothPoints.LeftTipReliefEnd, scale);
            // draw left tip relief
            AddScaledCircularArcByCenterStartEnd(sketch, gearToothPoints.LeftTipReliefCentre, gearToothPoints.LeftTipReliefEnd, gearToothPoints.LeftTipReliefStart, scale);
            // draw left involute
            AddScaledBsplineByInterpolation(sketch, gearToothPoints.LeftInvolute, scale);
            //draw left root fillet
            AddScaledCircularArcByCenterStartEnd(sketch, gearToothPoints.LeftRootFilletCentre, gearToothPoints.LeftRootFilletStart, gearToothPoints.LeftRootFilletEnd, scale);
            //draw arc from left root midpoint to left root fillet start
            AddScaledCircularArcByCenterStartEnd(sketch, gearToothPoints.GearCentre, gearToothPoints.LeftRootFilletStart, gearToothPoints.LeftMidRoot, scale);
            // draw line from centre to left root midpoint
            AddScaledLine(sketch, gearToothPoints.GearCentre, gearToothPoints.LeftMidRoot, scale);

            if (gear1.BaseDiameterDb > gear1.RootDiameterDr + gearToothPoints.Pair.RootFilletDiameter)
            {
                AddScaledLine(sketch, gearToothPoints.LeftRootFilletEnd, gearToothPoints.LeftInvolute[0], scale);
                AddScaledLine(sketch, gearToothPoints.RightRootFilletEnd, gearToothPoints.RightInvolute[0], scale);
            }

            // open up an Alibre parameter transaction session
            session.Parameters.OpenParameterTransaction();
            // set the number of teeth for the circular pattern
            session.Parameters.Item("C1").Value = gear1.TeethZ;
            // if this is a helical gear, set the helix pitch length
            if (gear1.HelixAngleBeta > 0)
            {
                session.Parameters.Item("D3").Value = gear1.HelixPitchLength * scale;
            }

            // close the Alibre parameter transaction session
            session.Parameters.CloseParameterTransaction();
            // complete the sketch changes
            sketch.EndChange();
            // regenerate all Alibre features.
            ((IADPartSession) session).RegenerateAll();
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
    }
}