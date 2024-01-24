using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AlibreX;
using Bolsover.Gear.Models;
using Bolsover.Involute.Model;

namespace Bolsover.Involute.Builder
{
    public class AlibreToothBuilder
    {
        public void Build(Tooth tooth, string SaveFile, string Template, IGearDesignOutputParams Gear)
        {
            var tempFile = GetAlibreFilePath(SaveFile, Template);
            if (tempFile == null) return;
            IADDesignSession session = InitAlibreFile(tempFile, true);
            Calculate(session, tooth, Gear);
        }

        private void Calculate(IADDesignSession session, Tooth tooth, IGearDesignOutputParams Gear)
        {
            if (Gear.GearDesignInputParams.Style.HasFlag(GearStyle.External) && Gear.GearDesignInputParams.Style.HasFlag(GearStyle.Spur))
                ExternalSpurGearBuilder.Build(session, tooth, Gear);
            else if (Gear.GearDesignInputParams.Style.HasFlag(GearStyle.External) && Gear.GearDesignInputParams.Style.HasFlag(GearStyle.Helical))
                ExternalHelicalGearBuilder.Build(session, tooth, Gear);
            else if (Gear.GearDesignInputParams.Style.HasFlag(GearStyle.Internal) && Gear.GearDesignInputParams.Style.HasFlag(GearStyle.Spur))
                InternalSpurGearBuilder.Build(session, tooth, Gear);
            else if (Gear.GearDesignInputParams.Style.HasFlag(GearStyle.Internal) && Gear.GearDesignInputParams.Style.HasFlag(GearStyle.Helical))
                InternalHelicalGearBuilder.Build(session, tooth, Gear);
            // else if (Gear.GearDesignInputParams.Style.HasFlag(GearStyle.Rack) && Gear.GearDesignInputParams.Style.HasFlag(GearStyle.Spur))
            //     CalculateStraightRackGear(Model);
            // else if (Gear.GearDesignInputParams.Style.HasFlag(GearStyle.Rack) && Gear.GearDesignInputParams.Style.HasFlag(GearStyle.Helical))
            //     CalculateHelicalRackGear(Model);
            else
                throw new ArgumentException("Gear style not recognised");
        }

        private string GetAlibreFilePath(string SaveFile, string Template)
        {
            var filePath = Globals.InstallPath;
            var tempFile = Path.Combine(Path.GetTempPath(), SaveFile);
            var tempFileInfo = new FileInfo(tempFile);
            if (tempFileInfo.Exists && IsFileLocked(tempFileInfo))
            {
                MessageBox.Show($"Temporary file {SaveFile} is currently open. \nPlease save-as or discard.", "Oops");
                return null;
            }

            if (filePath != null)
            {
                filePath += "\\Gear\\" + Template;
            }

            File.Copy(filePath, tempFile, true);
            return tempFile;
        }

        private IADDesignSession InitAlibreFile(string filePath, bool openEditor)
        {
            IADRoot root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
            IADDesignSession session = (IADDesignSession) root.OpenFileEx(filePath, true);
            return session;
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
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

        protected static IADSketchCircle AddScaledCircle(IADSketch sketch, GearPoint centre, double diameter, double scale,
            bool isReference)
        {
            var circle = sketch.Figures.AddCircle(centre.X * scale, centre.Y * scale, diameter / 2 * scale);
            circle.IsReference = isReference;
            return circle;
        }

        protected static IADSketchLine AddScaledLine(IADSketch sketch, GearPoint start, GearPoint end, double scale)
        {
            return sketch.Figures.AddLine(start.X * scale, start.Y * scale, end.X * scale, end.Y * scale);
        }

        protected static IADSketchCircularArc AddScaledCircularArcByCenterStartEnd(IADSketch sketch, GearPoint centre,
            GearPoint start,
            GearPoint end, double scale)
        {
            return sketch.Figures.AddCircularArcByCenterStartEnd(centre.X * scale, centre.Y * scale,
                start.X * scale, start.Y * scale, end.X * scale,
                end.Y * scale);
        }

        protected static IADSketchPoint AddScaledPoint(IADSketch sketch, GearPoint point, double scale)
        {
            return sketch.Figures.AddSketchPoint(point.X * scale, point.Y * scale);
        }

        protected static IADSketchBspline AddScaledBsplineByInterpolation(IADSketch sketch, List<GearPoint> points,
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