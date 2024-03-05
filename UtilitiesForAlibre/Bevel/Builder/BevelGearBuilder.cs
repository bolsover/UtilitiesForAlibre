using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Bevel.Models;
using Bolsover.Involute.Builder;
using Bolsover.Involute.Calculator;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Bevel.Builder
{
    public abstract class BevelGearBuilder : AlibreToothBuilder
    {
        public static void Build(string saveFile, string template, IBevelGear bevelGear)
        {
            var userTempDirectory = Path.GetTempPath();
            var tempFile = userTempDirectory + "\\" + saveFile;
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show("Temporary file " + saveFile + "is currently open. \nPlease save-as or discard.", "Oops");
                return;
            }

            var filePath = Globals.InstallPath;

            if (filePath != null)
            {
                filePath += "\\Bevel\\Images\\" + template;
            }

            if (filePath != null) File.Copy(filePath, tempFile, true);
            var session = InitAlibreBevelFile(tempFile);
            session.StartChanges();
            session.Parameters.OpenParameterTransaction();
            UpdateParameters(bevelGear, session);
            var sketch2 = session.Sketches.Item("Sketch<2>");
            UpdateSketch2(bevelGear, sketch2);

            session.Parameters.CloseParameterTransaction();

            session.StopChanges();
            ((IADPartSession)session).RegenerateAll();
        }


        private static void UpdateParameters(IBevelGear bevelGear, IADSession session)
        {
            session.Parameters.Item("PitchRadius").Value = bevelGear.PitchDiameter / 2 / 10;
            session.Parameters.Item("FaceWidth").Value = bevelGear.FaceWidth / 10;
            session.Parameters.Item("Dedendum").Value = bevelGear.Dedendum / 10;
            session.Parameters.Item("WholeDepth").Value = (bevelGear.Addendum + bevelGear.Dedendum) / 10;
            session.Parameters.Item("ConeAngle").Value = Radians(bevelGear.PitchConeAngle);
            session.Parameters.Item("BackConeAngle").Value =
                Radians(bevelGear.BackConeAngle * 1.001); // small increase to ensure plane does not interfere with gear geometry
            session.Parameters.Item("ToothCount").Value = bevelGear.NumberOfTeeth;
        }

        private static void UpdateSketch2(IBevelGear bevelGear, IADSketch sketch)
        {
            sketch.BeginChange();
            sketch.Figures.Item(0).Delete();
            var eqAddDia = bevelGear.EquivalentAddendumDiameter;
            var eqPitchDia = bevelGear.EquivalentPitchDiameter;
            var eqBaseDia = bevelGear.EquivalentBaseDiameter;
            var eqRootDia = bevelGear.EquivalentRootDiameter;
            var invOuterDia = eqAddDia + bevelGear.Module * 0.5; // ensure outer cut is slightly larger than addendum
            AddScaledCircle(sketch, new GearPoint(0, 0), eqPitchDia, 0.1,
                true);
            AddScaledCircle(sketch, new GearPoint(0, 0), eqBaseDia, 0.1,
                true);
            AddScaledCircle(sketch, new GearPoint(0, 0), eqAddDia, 0.1,
                true);
            AddScaledCircle(sketch, new GearPoint(0, 0), eqRootDia, 0.1,
                true);
            var phi = CalculatePhi(bevelGear);
            var quarterTooth = 90 / (bevelGear.NumberOfTeeth / Math.Cos(Radians(bevelGear.PitchConeAngle)));
            var rhsInvolute = Geometry.InvolutePoints(eqBaseDia / 2, invOuterDia / 2, 50);
            if (eqBaseDia > eqRootDia)
            {
                var lhsInvolute = GearPoint.MirrorPoints(rhsInvolute, 90);
                rhsInvolute = GearPoint.Rotated(rhsInvolute, Radians(90));
                lhsInvolute = GearPoint.Rotated(lhsInvolute, Radians(90));
                if (bevelGear.GearType == BevelGearType.Standard)
                {
                    rhsInvolute = GearPoint.Rotated(rhsInvolute, Radians(quarterTooth - phi));
                    lhsInvolute = GearPoint.Rotated(lhsInvolute, -Radians(quarterTooth - phi));
                }
                else
                {
                    var a = AngleForGleason(bevelGear);
                    var x = Radians(bevelGear.InterToothDegrees / 2);
                    var j = x - a;
                    rhsInvolute = GearPoint.Rotated(rhsInvolute, j);
                    lhsInvolute = GearPoint.Rotated(lhsInvolute, -j);
                }

                AddScaledBsplineByInterpolation(sketch, rhsInvolute, 0.1);
                AddScaledBsplineByInterpolation(sketch, lhsInvolute, 0.1);
                AddScaledCircularArcByCenterStartEnd(sketch, new GearPoint(0, 0), lhsInvolute[lhsInvolute.Count - 1],
                    rhsInvolute[rhsInvolute.Count - 1], 0.1);


                var leftFilletPoints = CalculateCircleAndTangentPoints(sketch, bevelGear, lhsInvolute[0], true);
                var rightFilletPoints = CalculateCircleAndTangentPoints(sketch, bevelGear, rhsInvolute[0], false);

                var arc1 =
                    AddScaledCircularArcByCenterStartEnd(sketch, leftFilletPoints.Item1, leftFilletPoints.Item2, leftFilletPoints.Item3, 0.1);
                AddScaledLine(sketch, lhsInvolute[0], SketchPointToGearPoint(arc1.End), 0.1);
                var arc2 = AddScaledCircularArcByCenterStartEnd(sketch, rightFilletPoints.Item1, rightFilletPoints.Item3,
                    rightFilletPoints.Item2, 0.1);
                AddScaledLine(sketch, rhsInvolute[0], SketchPointToGearPoint(arc2.Start), 0.1);
                AddScaledLine(sketch, SketchPointToGearPoint(arc1.Start), SketchPointToGearPoint(arc2.End), 0.1);
            }
            else
            {
                rhsInvolute = Geometry.PointsOutsideCircle(rhsInvolute, new GearPoint(0, 0), bevelGear.EquivalentRootDiameter / 2);
                var rootPoint = ToothPointCalculator.PointOnInvolute(bevelGear.EquivalentBaseDiameter / 2, bevelGear.EquivalentRootDiameter / 2);
                rhsInvolute.Insert(0, rootPoint);
                var lhsInvolute = GearPoint.MirrorPoints(rhsInvolute, 90);
                rhsInvolute = GearPoint.Rotated(rhsInvolute, Radians(90));
                lhsInvolute = GearPoint.Rotated(lhsInvolute, Radians(90));
                if (bevelGear.GearType == BevelGearType.Standard)
                {
                    rhsInvolute = GearPoint.Rotated(rhsInvolute, Radians(quarterTooth - phi));
                    lhsInvolute = GearPoint.Rotated(lhsInvolute, -Radians(quarterTooth - phi));
                }
                else
                {
                    var a = AngleForGleason(bevelGear);
                    var x = Radians(bevelGear.InterToothDegrees / 2);
                    var j = x - a;
                    rhsInvolute = GearPoint.Rotated(rhsInvolute, j);
                    lhsInvolute = GearPoint.Rotated(lhsInvolute, -j);
                }

                AddScaledBsplineByInterpolation(sketch, rhsInvolute, 0.1);
                AddScaledBsplineByInterpolation(sketch, lhsInvolute, 0.1);
                AddScaledCircularArcByCenterStartEnd(sketch, new GearPoint(0, 0), lhsInvolute[lhsInvolute.Count - 1],
                    rhsInvolute[rhsInvolute.Count - 1], 0.1);
                AddScaledCircularArcByCenterStartEnd(sketch, new GearPoint(0, 0), lhsInvolute[0],
                    rhsInvolute[0], 0.1);
            }

            sketch.EndChange();
        }

        private static double AngleForGleason(IBevelGear bevelGear)
        {
            GearPoint involutePitchPoint = Geometry.PointOnInvolute(bevelGear.EquivalentBaseDiameter / 2, bevelGear.EquivalentPitchDiameter / 2);
            double angle = Geometry.AngleToPointOnCircle(new GearPoint(0, 0), involutePitchPoint);
            return angle;
        }

        private static GearPoint SketchPointToGearPoint(IADSketchPoint point)
        {
            return new GearPoint(point.X * 10, point.Y * 10);
        }


        private static (GearPoint, GearPoint, GearPoint) CalculateCircleAndTangentPoints(IADSketch sketch, IBevelGear bevelGear,
            GearPoint involuteStart, bool isLeft)
        {
            var gearCentre = new GearPoint(0, 0);
            var baseToRoot = bevelGear.EquivalentBaseDiameter / 2 - bevelGear.EquivalentRootDiameter / 2;
            var filletRadius = baseToRoot * 0.5;
            var distanceToRadius = bevelGear.EquivalentRootDiameter / 2 + filletRadius;
            var adjAngleRadToFilletCentre = Math.Asin(filletRadius / (distanceToRadius));
            var angleRadToInvolute = Geometry.AngleToPointOnCircle(gearCentre, involuteStart);
            var angleToFilletCentre = angleRadToInvolute + adjAngleRadToFilletCentre;
            if (!isLeft)
            {
                angleToFilletCentre = angleRadToInvolute - adjAngleRadToFilletCentre;
            }

            var circleCenter = new GearPoint(gearCentre.X + distanceToRadius * Math.Cos(angleToFilletCentre),
                gearCentre.Y + distanceToRadius * Math.Sin(angleToFilletCentre));
            AddScaledPoint(sketch, circleCenter, 0.1);
            var intersectPointS = Intersection(circleCenter, bevelGear.EquivalentRootDiameter / 2);

            AddScaledPoint(sketch, intersectPointS, 0.1);

            var intersectPointE = Intersection(involuteStart, distanceToRadius);
            AddScaledPoint(sketch, intersectPointE, 0.1);

            return (circleCenter, intersectPointS, intersectPointE);
        }


        private static GearPoint Intersection(GearPoint lineEnd, double baseRadius)
        {
            var centre = new GearPoint(0, 0);
            var intersection = new GearPoint(0, 0);
            Geometry.Intersect(centre, baseRadius, centre, lineEnd, ref intersection);
            return intersection;
        }

        private static double CalculatePhi(IBevelGear bevelGear)
        {
            var alpha = bevelGear.PressureAngle; // Pressure Angle degrees
            var d = bevelGear.EquivalentPitchDiameter; // Pitch Diameters
            var db = bevelGear.EquivalentBaseDiameter; // Base Diameter of Pinion

            var phi = Math.Sqrt(Math.Pow(d, 2) - Math.Pow(db, 2)) / db * 180 / Math.PI - alpha;


            return phi;
        }

        private static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
                stream.Close();
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        private static IADDesignSession InitAlibreBevelFile(string filePath)
        {
            var root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
            var session = (IADDesignSession)root.OpenFileEx(filePath, true);
            return session;
        }
    }
}