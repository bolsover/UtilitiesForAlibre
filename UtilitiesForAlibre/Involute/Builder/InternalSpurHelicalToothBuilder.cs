using Bolsover.Involute.Calculator;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Builder
{
    public class InternalSpurHelicalToothBuilder : IToothPointsBuilder
    {
        private Tooth _tooth;
        private GearPoint[] _reliefPoints;

        public Tooth Build(IGearDesignOutputParams gearDesignOutputParams)
        {
            _tooth = new Tooth();
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
            _reliefPoints = InternalToothPointCalculator.CalcAddendumFilletPoints(gearDesignOutputParams);
            _tooth.Points[2].Point = _reliefPoints[2];
            _tooth.Points[3].Point = _reliefPoints[1];
            _tooth.Points[4].Point = _reliefPoints[0];
            _tooth.Points[14].Point = _reliefPoints[3];
            _tooth.Points[15].Point = _reliefPoints[4];
            _tooth.Points[16].Point = _reliefPoints[5];
            
            // trim the right involute to the addendum fillet
            rhsInvolute = Geometry.PointsFromIntersectionWithRootFillet(rhsInvolute, _reliefPoints[0]);
            
            // ensure involute starts at same point as fillet
            rhsInvolute[0] = _reliefPoints[0];
            
            // Mirror and rotate right involute points to create Left involute
            var lhsInvolute = GearPoint.MirrorPoints(rhsInvolute, 90);
            lhsInvolute = GearPoint.Rotated(lhsInvolute, rotateRadians);
            _tooth.Points[8].Point = rhsInvolute[rhsInvolute.Count - 1];
            _tooth.Points[10].Point = lhsInvolute[lhsInvolute.Count - 1];
            _tooth.Points[5].Point = rhsInvolute[0];
            _tooth.Points[13].Point = lhsInvolute[0];
            // left mid outer 
            _tooth.Points[19].Point = new GearPoint(gearDesignOutputParams.OuterRingDiameter / 2, 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Radians(180 / gearDesignOutputParams.GearDesignInputParams.Teeth));
            // right mid outer
            _tooth.Points[18].Point = _tooth.Points[19].Point.Rotate(Radians(-360 / gearDesignOutputParams.GearDesignInputParams.Teeth));

            // left mid Addendum
            _tooth.Points[17].Point = new GearPoint(gearDesignOutputParams.OutsideDiameter / 2, 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Radians(180 / gearDesignOutputParams.GearDesignInputParams.Teeth));
            // right mid Addendum
            _tooth.Points[1].Point = _tooth.Points[17].Point.Rotate(Radians(-360 / gearDesignOutputParams.GearDesignInputParams.Teeth));

            // left mid Base
            _tooth.Points[21].Point = new GearPoint(gearDesignOutputParams.BaseCircleDiameter / 2, 0)
                .Rotate(rotateRadians / 2)
                .Rotate(Radians(180 / gearDesignOutputParams.GearDesignInputParams.Teeth));
            // right mid Addendum
            _tooth.Points[20].Point = _tooth.Points[21].Point.Rotate(Radians(-360 / gearDesignOutputParams.GearDesignInputParams.Teeth));
            _tooth.RhsInvolute = rhsInvolute;
            _tooth.LhsInvolute = lhsInvolute;
            return _tooth;
        }

    }
}