using AlibreX;
using Bolsover.Involute.Model;

namespace Bolsover.Involute.Builder
{
    public abstract class InternalSpurGearBuilder : AlibreToothBuilder
    {
        public static void Build(IADDesignSession session, Tooth tooth, IGearDesignOutputParams gear)
        {
            var sketches = session.Sketches;
            var sketch = sketches.Item("Tooth");
            var figures = sketch.Figures;
            // open the sketch for changes
            sketch.BeginChange();
            // the existing sketch has a placeholder - just delete
            figures.Item(0).Delete();
            // the default Alibre units are cm. Scale everything by 0.1 for correct mm dimensions
            const double scale = 0.1;

            // add the points and curves to the sketch
            AddScaledPoint(sketch, tooth.Points[0].Point, scale);
            AddScaledPoint(sketch, tooth.Points[1].Point, scale);
            AddScaledPoint(sketch, tooth.Points[2].Point, scale);
            AddScaledPoint(sketch, tooth.Points[3].Point, scale);
            AddScaledPoint(sketch, tooth.Points[4].Point, scale);
            AddScaledPoint(sketch, tooth.Points[8].Point, scale);
            AddScaledPoint(sketch, tooth.Points[10].Point, scale);
            AddScaledPoint(sketch, tooth.Points[14].Point, scale);
            AddScaledPoint(sketch, tooth.Points[15].Point, scale);
            AddScaledPoint(sketch, tooth.Points[16].Point, scale);
            AddScaledPoint(sketch, tooth.Points[17].Point, scale);
            AddScaledPoint(sketch, tooth.Points[18].Point, scale);
            AddScaledPoint(sketch, tooth.Points[19].Point, scale);
            AddScaledPoint(sketch, tooth.Points[20].Point, scale);
            AddScaledPoint(sketch, tooth.Points[21].Point, scale);
            AddScaledCircle(sketch, tooth.Points[0].Point, gear.RootCircleDiameter, scale,
                true);
            AddScaledCircle(sketch, tooth.Points[0].Point, gear.BaseCircleDiameter, scale,
                true);
            AddScaledCircle(sketch, tooth.Points[0].Point, gear.PitchCircleDiameter, scale,
                true);
            AddScaledCircle(sketch, tooth.Points[0].Point, gear.OutsideDiameter, scale,
                true);
            AddScaledBsplineByInterpolation(sketch, tooth.RhsInvolute, scale);
            AddScaledBsplineByInterpolation(sketch, tooth.LhsInvolute, scale);
            if (gear.BaseCircleDiameter < gear.OutsideDiameter)
            {
                AddScaledLine(sketch, tooth.Points[1].Point, tooth.Points[18].Point, scale);
                AddScaledLine(sketch, tooth.Points[17].Point, tooth.Points[19].Point, scale);
                AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[0].Point, tooth.Points[16].Point, tooth.Points[17].Point, scale);
                AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[0].Point, tooth.Points[1].Point, tooth.Points[2].Point, scale);
            }
            else
            {
                AddScaledLine(sketch, tooth.Points[20].Point, tooth.Points[18].Point, scale);
                AddScaledLine(sketch, tooth.Points[21].Point, tooth.Points[19].Point, scale);
                AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[0].Point, tooth.Points[16].Point, tooth.Points[21].Point, scale);
                AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[0].Point, tooth.Points[20].Point, tooth.Points[2].Point, scale);
            }
            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[3].Point, tooth.Points[4].Point, tooth.Points[2].Point, scale);
            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[15].Point, tooth.Points[16].Point, tooth.Points[14].Point, scale);
            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[0].Point, tooth.Points[18].Point, tooth.Points[19].Point, scale);
            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[0].Point, tooth.Points[8].Point, tooth.Points[10].Point, scale);
            // complete the sketch changes
            sketch.EndChange();
            // open up an Alibre parameter transaction session
            session.Parameters.OpenParameterTransaction();
            // set the number of teeth for the circular pattern
            session.Parameters.Item("C1").Value = gear.GearDesignInputParams.Teeth;
            session.Parameters.Item("D2").Value = gear.GearDesignInputParams.Height * scale;
            // close the Alibre parameter transaction session
            session.Parameters.CloseParameterTransaction();
            // complete the sketch changes
            sketch.EndChange();
            // regenerate all Alibre features.
            ((IADPartSession) session).RegenerateAll();
        }
    }
}