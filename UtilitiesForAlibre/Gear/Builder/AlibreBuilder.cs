using System;
using System.Collections.Generic;
using AlibreX;
using Bolsover.Gear.Calculators;
using Bolsover.Gear.Models;

namespace Bolsover.Gear.Builder
{
    public class AlibreBuilder
    {
        private GearToothPoints _gearToothPoints;
        private IADDesignSession _session;

        private AlibreBuilder(GearToothPoints gearToothPoints, IADDesignSession session)
        {
            this._gearToothPoints = gearToothPoints;
            this._session = session;
            if (gearToothPoints.G1.GearTypeEnum == GearTypeEnum.External)
            {
                BuildExternalGear();
            }
            else
            {
                BuildInternalGear();
            }
        }

        public static AlibreBuilder CreateInstance(GearToothPoints gearToothPoints, IADDesignSession session)
        {
            return new AlibreBuilder(gearToothPoints, session);
        }

        private void BuildInternalGear()
        {
            var sketches = _session.Sketches;
            var sketch = sketches.Item("Tooth");
            var figures = sketch.Figures;
            // open the sketch for changes
            sketch.BeginChange();
            // the existing sketch has a placeholder - just delete
            figures.Item(0).Delete();
            // the default Alibre units are cm. Scale everything by 0.1 for correct mm dimensions
            var scale = 0.1;
            InvoluteGear gear = _gearToothPoints.G1;


            // draw outerRing
            AddScaledCircle(sketch, _gearToothPoints.GearCentre, GearCalculations.OuterRingDiameter(gear), scale, true);
            // draw right involute
            AddScaledBsplineByInterpolation(sketch, _gearToothPoints.RightInvolute, scale);
            // draw left involute
            AddScaledBsplineByInterpolation(sketch, _gearToothPoints.LeftInvolute, scale);


            if (GearCalculations.AddendumRadiusRa(gear) > GearCalculations.BaseRadiusRb(gear))
            {
                AddScaledLine(sketch, _gearToothPoints.LeftMidAddendum, _gearToothPoints.LeftMidOuter, scale);

                AddScaledLine(sketch, _gearToothPoints.RightMidAddendum, _gearToothPoints.RightMidOuter, scale);

                AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.GearCentre, _gearToothPoints.RightMidAddendum,
                    _gearToothPoints.RightAddendumFilletStart, scale);

                AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.GearCentre,
                    _gearToothPoints.LeftAddendumFilletStart,
                    _gearToothPoints.LeftMidAddendum, scale);
            }
            else
            {
                AddScaledLine(sketch, _gearToothPoints.LeftMidBase, _gearToothPoints.LeftMidOuter, scale);

                AddScaledLine(sketch, _gearToothPoints.RightMidBase, _gearToothPoints.RightMidOuter, scale);
                AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.GearCentre, _gearToothPoints.RightMidBase,
                    _gearToothPoints.RightAddendumFilletStart, scale);

                AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.GearCentre,
                    _gearToothPoints.LeftAddendumFilletStart,
                    _gearToothPoints.LeftMidBase, scale);
            }


// add the relief arcs
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.RightAddendumFilletCentre,
                _gearToothPoints.RightAddendumFilletEnd, _gearToothPoints.RightAddendumFilletStart, scale);
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.LeftAddendumFilletCentre,
                _gearToothPoints.LeftAddendumFilletStart, _gearToothPoints.LeftAddendumFilletEnd, scale);


            // add outer arc
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.GearCentre, _gearToothPoints.RightMidOuter,
                _gearToothPoints.LeftMidOuter, scale);

            // Add arc at top of involute curves
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.GearCentre, _gearToothPoints.RightInvoluteEnd,
                _gearToothPoints.LeftInvoluteEnd, scale);


            // open up an Alibre parameter transaction session
            _session.Parameters.OpenParameterTransaction();
            // set the number of teeth for the circular pattern
            _session.Parameters.Item("C1").Value = gear.TeethZ;
            // if this is a helical gear, set the helix pitch length
            if (gear.HelixAngleBeta > 0)
            {
                _session.Parameters.Item("D3").Value = GearCalculations.HelixPitchLength(gear) * scale;
            }

            // close the Alibre parameter transaction session
            _session.Parameters.CloseParameterTransaction();
            // complete the sketch changes
            sketch.EndChange();
            // regenerate all Alibre features.
            ((IADPartSession) _session).RegenerateAll();
        }

        private void BuildExternalGear()
        {
            var sketches = _session.Sketches;
            var sketch = sketches.Item("Tooth");
            var figures = sketch.Figures;
            // open the sketch for changes
            sketch.BeginChange();
            // the existing sketch has a placeholder - just delete
            figures.Item(0).Delete();
            // the default Alibre units are cm. Scale everything by 0.1 for correct mm dimensions
            var scale = 0.1;
            InvoluteGear gear = _gearToothPoints.G1;

            // draw line from centre to right root midpoint
            AddScaledLine(sketch, _gearToothPoints.GearCentre, _gearToothPoints.RightMidRoot, scale);
            //draw arc from right root midpoint to right root fillet start
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.GearCentre, _gearToothPoints.RightMidRoot,
                _gearToothPoints.RightRootFilletStart, scale);
            //draw right root fillet
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.RightRootFilletCentre,
                _gearToothPoints.RightRootFilletEnd, _gearToothPoints.RightRootFilletStart, scale);
            // draw right involute
            AddScaledBsplineByInterpolation(sketch, _gearToothPoints.RightInvolute, scale);
            // draw right tip relief
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.RightTipReliefCentre,
                _gearToothPoints.RightTipReliefStart, _gearToothPoints.RightTipReliefEnd, scale);
            // draw addendum arc
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.GearCentre, _gearToothPoints.RightTipReliefEnd,
                _gearToothPoints.LeftTipReliefEnd, scale);
            // draw left tip relief
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.LeftTipReliefCentre,
                _gearToothPoints.LeftTipReliefEnd, _gearToothPoints.LeftTipReliefStart, scale);
            // draw left involute
            AddScaledBsplineByInterpolation(sketch, _gearToothPoints.LeftInvolute, scale);
            //draw left root fillet
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.LeftRootFilletCentre,
                _gearToothPoints.LeftRootFilletStart, _gearToothPoints.LeftRootFilletEnd, scale);
            //draw arc from left root midpoint to left root fillet start
            AddScaledCircularArcByCenterStartEnd(sketch, _gearToothPoints.GearCentre, _gearToothPoints.LeftRootFilletStart,
                _gearToothPoints.LeftMidRoot, scale);
            // draw line from centre to left root midpoint
            AddScaledLine(sketch, _gearToothPoints.GearCentre, _gearToothPoints.LeftMidRoot, scale);

            if (GearCalculations.BaseDiameterDb(gear) >
                GearCalculations.RootDiameterDr(gear) + GearCalculations.RootFilletDiameter(gear))
            {
                AddScaledLine(sketch, _gearToothPoints.LeftRootFilletEnd, _gearToothPoints.LeftInvolute[0], scale);
                AddScaledLine(sketch, _gearToothPoints.RightRootFilletEnd, _gearToothPoints.RightInvolute[0], scale);
            }

            // open up an Alibre parameter transaction session
            _session.Parameters.OpenParameterTransaction();
            // set the number of teeth for the circular pattern
            _session.Parameters.Item("C1").Value = gear.TeethZ;
            _session.Parameters.Item("D2").Value = gear.Height * scale;
            // if this is a helical gear, set the helix pitch length
            if (gear.HelixAngleBeta > 0)
            {
                _session.Parameters.Item("D3").Value = GearCalculations.HelixPitchLength(gear) * scale;
            }

            // close the Alibre parameter transaction session
            _session.Parameters.CloseParameterTransaction();
            // complete the sketch changes
            sketch.EndChange();
            // regenerate all Alibre features.
            ((IADPartSession) _session).RegenerateAll();
        }


        private IADSketchCircle AddScaledCircle(IADSketch sketch, GearPoint centre, double diameter, double scale,
            bool isReference)
        {
            var circle = sketch.Figures.AddCircle(centre.X * scale, centre.Y * scale, diameter / 2 * scale);
            circle.IsReference = isReference;
            return circle;
        }


        private static IADSketchLine AddScaledLine(IADSketch sketch, GearPoint start, GearPoint end, double scale)
        {
            return sketch.Figures.AddLine(start.X * scale, start.Y * scale, end.X * scale, end.Y * scale);
        }

        private static IADSketchCircularArc AddScaledCircularArcByCenterStartEnd(IADSketch sketch, GearPoint centre,
            GearPoint start,
            GearPoint end, double scale)
        {
            return sketch.Figures.AddCircularArcByCenterStartEnd(centre.X * scale, centre.Y * scale,
                start.X * scale, start.Y * scale, end.X * scale,
                end.Y * scale);
        }


        private static IADSketchBspline AddScaledBsplineByInterpolation(IADSketch sketch, List<GearPoint> points,
            double scale)
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