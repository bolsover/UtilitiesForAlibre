using AlibreX;
using Bolsover.Involute.Model;

namespace Bolsover.Involute.Builder
{
    public abstract class ExternalHelicalGearBuilder : AlibreToothBuilder
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

            for (var i = 0; i < tooth.Points.Count; i++)
            {
                AddScaledPoint(sketch, tooth.Points[i].Point, scale);
            }

            AddScaledCircle(sketch, tooth.Points[0].Point, gear.RootCircleDiameter, scale,
                true);
            AddScaledCircle(sketch, tooth.Points[0].Point, gear.BaseCircleDiameter, scale,
                true);
            AddScaledCircle(sketch, tooth.Points[0].Point, gear.PitchCircleDiameter, scale,
                true);
            AddScaledCircle(sketch, tooth.Points[0].Point, gear.OutsideDiameter, scale,
                true);
            AddScaledLine(sketch, tooth.Points[0].Point, tooth.Points[1].Point, scale);
            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[0].Point, tooth.Points[1].Point, tooth.Points[2].Point, scale);
            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[3].Point, tooth.Points[4].Point, tooth.Points[2].Point, scale);

            AddScaledBsplineByInterpolation(sketch, tooth.RhsInvolute, scale);
            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[7].Point, tooth.Points[6].Point, tooth.Points[8].Point, scale);
            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[0].Point, tooth.Points[8].Point, tooth.Points[10].Point, scale);
            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[11].Point, tooth.Points[10].Point, tooth.Points[12].Point, scale);
            AddScaledBsplineByInterpolation(sketch, tooth.LhsInvolute, scale);

            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[15].Point, tooth.Points[16].Point, tooth.Points[14].Point, scale);
            AddScaledCircularArcByCenterStartEnd(sketch, tooth.Points[0].Point, tooth.Points[16].Point, tooth.Points[17].Point, scale);
            AddScaledLine(sketch, tooth.Points[0].Point, tooth.Points[17].Point, scale);

            if (gear.BaseCircleDiameter > gear.RootCircleDiameter + gear.RootFilletDiameter)
            {
                AddScaledLine(sketch, tooth.Points[13].Point, tooth.Points[14].Point, scale);
                AddScaledLine(sketch, tooth.Points[4].Point, tooth.Points[5].Point, scale);
            }
            // complete the sketch changes
            sketch.EndChange();
            // open up an Alibre parameter transaction session
            session.Parameters.OpenParameterTransaction();
            // set the number of teeth for the circular pattern
            session.Parameters.Item("C1").Value = gear.GearDesignInputParams.Teeth;
            session.Parameters.Item("D2").Value = gear.GearDesignInputParams.Height * scale;
            session.Parameters.Item("D3").Value = gear.HelixPitchLength * scale;
            // close the Alibre parameter transaction session
            session.Parameters.CloseParameterTransaction();
            // complete the sketch changes
            sketch.EndChange();
            // regenerate all Alibre features.
            ((IADPartSession) session).RegenerateAll();
        }
    }
}