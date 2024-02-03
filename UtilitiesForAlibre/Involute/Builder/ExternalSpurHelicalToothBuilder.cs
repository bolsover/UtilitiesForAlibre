
using System.Collections.Generic;
using Bolsover.Involute.Model;
using static Bolsover.Involute.Calculator.ToothPointCalculator;


namespace Bolsover.Involute.Builder
{
    public class ExternalSpurHelicalToothBuilder : IToothPointsBuilder
    {
        private Tooth _tooth;

        public Tooth Build(IGearDesignOutputParams gearDesignOutputParams)
        {
            _tooth = new()
                {
                    RhsInvolute = BuildRhsToothInvolute(gearDesignOutputParams),
                    LhsInvolute = BuildLhsToothInvolute(gearDesignOutputParams)
                };
            _tooth.Points[0].Point = BuildPoint0(gearDesignOutputParams);
            _tooth.Points[1].Point = BuildPoint1(gearDesignOutputParams);
            _tooth.Points[2].Point = BuildPoint2(gearDesignOutputParams);
            _tooth.Points[3].Point = BuildPoint3(gearDesignOutputParams);
            _tooth.Points[4].Point = BuildPoint4(gearDesignOutputParams);
            _tooth.Points[5].Point = BuildPoint5(gearDesignOutputParams);
            _tooth.Points[6].Point = BuildPoint6(gearDesignOutputParams);
            _tooth.Points[7].Point = BuildPoint7(gearDesignOutputParams);
            _tooth.Points[8].Point = BuildPoint8(gearDesignOutputParams);
            _tooth.Points[9].Point = BuildPoint9(gearDesignOutputParams);
            _tooth.Points[10].Point = BuildPoint10(gearDesignOutputParams);
            _tooth.Points[11].Point = BuildPoint11(gearDesignOutputParams);
            _tooth.Points[12].Point = BuildPoint12(gearDesignOutputParams);
            _tooth.Points[13].Point = BuildPoint13(gearDesignOutputParams);
            _tooth.Points[14].Point = BuildPoint14(gearDesignOutputParams);
            _tooth.Points[15].Point = BuildPoint15(gearDesignOutputParams);
            _tooth.Points[16].Point = BuildPoint16(gearDesignOutputParams);
            _tooth.Points[17].Point = BuildPoint17(gearDesignOutputParams);


            return _tooth;
        }


        private static List<GearPoint> BuildRhsToothInvolute(IGearDesignOutputParams gearDesignOutputParams)
        {
            return RhsInvolute(gearDesignOutputParams);
        }


        private static List<GearPoint> BuildLhsToothInvolute(IGearDesignOutputParams gearDesignOutputParams)
        {
            return LhsInvolute(gearDesignOutputParams);
            
         
        }

        /// <summary>
        /// Simply returns a new GearPoint at x:0, y:0 as the gear centre point
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint0(IGearDesignOutputParams gearDesignOutputParams)
        {
            return new GearPoint(0, 0);
        }

        /// <summary>
        /// RHS Mid point between adjacent teeth on root diameter
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint1(IGearDesignOutputParams gearDesignOutputParams)
        {
            return RhsMidRoot(gearDesignOutputParams);
        }

       

        /// <summary>
        /// RHS Start of root relief arc
        /// This point is at the intersection of the root relief arc and the involute
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint2(IGearDesignOutputParams gearDesignOutputParams)
        {
            return RhsStartRootRelief(gearDesignOutputParams);
        }

        

        /// <summary>
        /// RHS Centre of root relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint3(IGearDesignOutputParams gearDesignOutputParams)
        {

            return RhsRootFilletCentre(gearDesignOutputParams);
        }

        /// <summary>
        /// RHS End of root relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint4(IGearDesignOutputParams gearDesignOutputParams)
        {
            return GearPointRhsEndRootRelief(gearDesignOutputParams);

        }

       
        /// <summary>
        /// RHS Start of involute
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint5(IGearDesignOutputParams gearDesignOutputParams)
        {
            return RhsStartInvolute(gearDesignOutputParams);
        }

        /// <summary>
        /// RHS Start of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint6(IGearDesignOutputParams gearDesignOutputParams)
        {
            return RhsStartOfTipRelief(gearDesignOutputParams);
        }

        /// <summary>
        /// RHS Centre of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint7(IGearDesignOutputParams gearDesignOutputParams)
        {
            return RhsCentreOfTipRelief(gearDesignOutputParams);
        }

       

        /// <summary>
        /// RHS End of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint8(IGearDesignOutputParams gearDesignOutputParams)
        {
            return RhsEndTipRelief(gearDesignOutputParams);
        }

        

        /// <summary>
        /// Centre point on outside diameter
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint9(IGearDesignOutputParams gearDesignOutputParams)
        {
            return CentrePointOutsideDiameter(gearDesignOutputParams);
        }

        

        /// <summary>
        /// LHS End of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint10(IGearDesignOutputParams gearDesignOutputParams)
        {
            return LhsEndTipRelief(gearDesignOutputParams);
        }

        

        /// <summary>
        /// LHS Centre of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint11(IGearDesignOutputParams gearDesignOutputParams)
        {
            return LhsCentreTipRelief(gearDesignOutputParams);
        }

      

        /// <summary>
        /// LHS Start of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint12(IGearDesignOutputParams gearDesignOutputParams)
        {
            return LhsStartOfTipRelief(gearDesignOutputParams);
        }

        /// <summary>
        /// LHS Start of involute
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint13(IGearDesignOutputParams gearDesignOutputParams)
        {
            return LhsStartInvolute(gearDesignOutputParams);
        }

        /// <summary>
        /// LHS End of root relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint14(IGearDesignOutputParams gearDesignOutputParams)
        {
            return LhsEndRootRelief(gearDesignOutputParams);
        }

        

        /// <summary>
        /// LHS Centre of root relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint15(IGearDesignOutputParams gearDesignOutputParams)
        {
            return LhsCentreRootRelief(gearDesignOutputParams);
        }

        

        /// <summary>
        /// LHS start of root relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint16(IGearDesignOutputParams gearDesignOutputParams)
        {
            return LhsStartRootRelief(gearDesignOutputParams);
        }

     

        /// <summary>
        /// LHS Mid point between adjacent teeth on root diameter
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private static GearPoint BuildPoint17(IGearDesignOutputParams gearDesignOutputParams)
        {
            
            return LhsMidRoot(gearDesignOutputParams);
      
        }
    }
}