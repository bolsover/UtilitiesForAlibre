
using System.Collections.Generic;
using Bolsover.Involute.Calculator;
using Bolsover.Involute.Model;


namespace Bolsover.Involute.Builder
{
    public class ExternalSpurHelicalToothBuilder : IToothPointsBuilder
    {
        private Tooth tooth;

        public Tooth Build(IGearDesignOutputParams gearDesignOutputParams)
        {
            tooth = new();
            tooth.RhsInvolute = BuildRhsToothInvolute(gearDesignOutputParams);
            tooth.LhsInvolute = BuildLhsToothInvolute(gearDesignOutputParams);
            tooth.Points[0].Point = BuildPoint0(gearDesignOutputParams);
            tooth.Points[1].Point = BuildPoint1(gearDesignOutputParams);
            tooth.Points[2].Point = BuildPoint2(gearDesignOutputParams);
            tooth.Points[3].Point = BuildPoint3(gearDesignOutputParams);
            tooth.Points[4].Point = BuildPoint4(gearDesignOutputParams);
            tooth.Points[5].Point = BuildPoint5(gearDesignOutputParams);
            tooth.Points[6].Point = BuildPoint6(gearDesignOutputParams);
            tooth.Points[7].Point = BuildPoint7(gearDesignOutputParams);
            tooth.Points[8].Point = BuildPoint8(gearDesignOutputParams);
            tooth.Points[9].Point = BuildPoint9(gearDesignOutputParams);
            tooth.Points[10].Point = BuildPoint10(gearDesignOutputParams);
            tooth.Points[11].Point = BuildPoint11(gearDesignOutputParams);
            tooth.Points[12].Point = BuildPoint12(gearDesignOutputParams);
            tooth.Points[13].Point = BuildPoint13(gearDesignOutputParams);
            tooth.Points[14].Point = BuildPoint14(gearDesignOutputParams);
            tooth.Points[15].Point = BuildPoint15(gearDesignOutputParams);
            tooth.Points[16].Point = BuildPoint16(gearDesignOutputParams);
            tooth.Points[17].Point = BuildPoint17(gearDesignOutputParams);


            return tooth;
        }


        private List<GearPoint> BuildRhsToothInvolute(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.RhsInvolute(gearDesignOutputParams);
        }


        private List<GearPoint> BuildLhsToothInvolute(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.LhsInvolute(gearDesignOutputParams);
            
         
        }

        /// <summary>
        /// Simply returns a new GearPoint at x:0, y:0 as the gear centre point
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint0(IGearDesignOutputParams gearDesignOutputParams)
        {
            return new GearPoint(0, 0);
        }

        /// <summary>
        /// RHS Mid point between adjacent teeth on root diameter
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint1(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.RhsMidRoot(gearDesignOutputParams);
        }

       

        /// <summary>
        /// RHS Start of root relief arc
        /// This point is at the intersection of the root relief arc and the involute
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint2(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.RhsStartRootRelief(gearDesignOutputParams);
        }

        

        /// <summary>
        /// RHS Centre of root relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint3(IGearDesignOutputParams gearDesignOutputParams)
        {

            return ToothPointCalculator.RhsRootFilletCentre(gearDesignOutputParams);
        }

        /// <summary>
        /// RHS End of root relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint4(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.GearPointRhsEndRootRelief(gearDesignOutputParams);

        }

       
        /// <summary>
        /// RHS Start of involute
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint5(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.RhsStartInvolute(gearDesignOutputParams);
        }

        /// <summary>
        /// RHS Start of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint6(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.RhsStartOfTipRelief(gearDesignOutputParams);
        }

        /// <summary>
        /// RHS Centre of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint7(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.RhsCentreOfTipRelief(gearDesignOutputParams);
        }

       

        /// <summary>
        /// RHS End of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint8(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.RhsEndTipRelief(gearDesignOutputParams);
        }

        

        /// <summary>
        /// Centre point on outside diameter
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint9(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.CentrePointOutsideDiameter(gearDesignOutputParams);
        }

        

        /// <summary>
        /// LHS End of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint10(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.LhsEndTipRelief(gearDesignOutputParams);
        }

        

        /// <summary>
        /// LHS Centre of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint11(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.LhsCentreTipRelief(gearDesignOutputParams);
        }

      

        /// <summary>
        /// LHS Start of tip relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint12(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.LhsStartOfTipRelief(gearDesignOutputParams);
        }

        /// <summary>
        /// LHS Start of involute
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint13(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.LhsStartInvolute(gearDesignOutputParams);
        }

        /// <summary>
        /// LHS End of root relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint14(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.LhsEndRootRelief(gearDesignOutputParams);
        }

        

        /// <summary>
        /// LHS Centre of root relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint15(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.LhsCentreRootRelief(gearDesignOutputParams);
        }

        

        /// <summary>
        /// LHS start of root relief arc
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint16(IGearDesignOutputParams gearDesignOutputParams)
        {
            return ToothPointCalculator.LhsStartRootRelief(gearDesignOutputParams);
        }

     

        /// <summary>
        /// LHS Mid point between adjacent teeth on root diameter
        /// </summary>
        /// <param name="gearDesignOutputParams"></param>
        /// <returns></returns>
        private GearPoint BuildPoint17(IGearDesignOutputParams gearDesignOutputParams)
        {
            
            return ToothPointCalculator.LhsMidRoot(gearDesignOutputParams);
      
        }
    }
}