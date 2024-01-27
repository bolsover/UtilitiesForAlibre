using System.Collections.Generic;
using Bolsover.Involute.Calculator;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Builder
{
    public class InternalSpurHelicalToothBuilder : IToothPointsBuilder
    {
        private Tooth tooth;
        private GearPoint[] reliefPoints;

        public Tooth Build(IGearDesignOutputParams gearDesignOutputParams)
        {
            tooth = new();
            // rotation for left section of gear tooth
            var rotateRadians = Radians(gearDesignOutputParams.Kappa);
            // the basic right involute curve
            var rhsInvolute = InternalToothPointCalculator.BuildBasicInternalInvolute(gearDesignOutputParams, 25);
            if (gearDesignOutputParams.OutsideDiameter / 2 > gearDesignOutputParams.BaseCircleDiameter / 2)
            {
                var addendumPoint = new GearPoint(gearDesignOutputParams.OutsideDiameter / 2, 0);
                rhsInvolute =
                    Geometry.PointsFromIntersectionWithRootFillet(rhsInvolute, addendumPoint);
            }
            // calculate and assign relief points
            reliefPoints = InternalToothPointCalculator.CalcAddendumFilletPoints(gearDesignOutputParams);
            tooth.Points[2].Point = reliefPoints[2];
            tooth.Points[3].Point = reliefPoints[1];
            tooth.Points[4].Point = reliefPoints[0];
            tooth.Points[14].Point = reliefPoints[3];
            tooth.Points[15].Point = reliefPoints[4];
            tooth.Points[16].Point = reliefPoints[5];
            
            // trim the right involute to the addendum fillet
            rhsInvolute = Geometry.PointsFromIntersectionWithRootFillet(rhsInvolute, reliefPoints[0]);
            
            // ensure involute starts at same point as fillet
            rhsInvolute[0] = reliefPoints[0];
            
            // Mirror and rotate right involute points to create Left involute
            var lhsInvolute = GearPoint.MirrorPoints(rhsInvolute, 90);
            lhsInvolute = GearPoint.Rotated(lhsInvolute, rotateRadians);
            tooth.Points[8].Point = rhsInvolute[rhsInvolute.Count - 1];
            tooth.Points[10].Point = lhsInvolute[lhsInvolute.Count - 1];
            tooth.Points[5].Point = rhsInvolute[0];
            tooth.Points[13].Point = lhsInvolute[0];
            // left mid outer 
            tooth.Points[19].Point = new GearPoint(gearDesignOutputParams.OuterRingDiameter / 2, 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Radians(180 / gearDesignOutputParams.GearDesignInputParams.Teeth));
            // right mid outer
            tooth.Points[18].Point = tooth.Points[19].Point.Rotate(Radians(-360 / gearDesignOutputParams.GearDesignInputParams.Teeth));

            // left mid Addendum
            tooth.Points[17].Point = new GearPoint(gearDesignOutputParams.OutsideDiameter / 2, 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Radians(180 / gearDesignOutputParams.GearDesignInputParams.Teeth));
            // right mid Addendum
            tooth.Points[1].Point = tooth.Points[17].Point.Rotate(Radians(-360 / gearDesignOutputParams.GearDesignInputParams.Teeth));

            // left mid Base
            tooth.Points[21].Point = new GearPoint(gearDesignOutputParams.BaseCircleDiameter / 2, 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Radians(180 / gearDesignOutputParams.GearDesignInputParams.Teeth));
            // right mid Addendum
            tooth.Points[20].Point = tooth.Points[21].Point.Rotate(Radians(-360 / gearDesignOutputParams.GearDesignInputParams.Teeth));
            tooth.RhsInvolute = rhsInvolute;
            tooth.LhsInvolute = lhsInvolute;
            return tooth;
        }

    }
}