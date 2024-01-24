using Bolsover.Involute.Model;

namespace Bolsover.Involute.Calculator
{
    public interface IGearCalculator
    {
        /// <summary>
        /// Calculates the gear pair design output parameters.
        /// This method runs all the calculations and populates the output parameters appropriate to the gear pair.
        /// </summary>
        void Calculate();
        
        /// <summary>
        /// Calculates the modification coefficient for profile shift required to achieve the specified circular backlash.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateProfileShiftModificationForBacklash(IGearPairDesignInputParams pairDesignInputParams);

        /// <summary>
        /// Generates a string representation of the gear pair design input and output parameters.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <param name="pairDesignOutputParams"></param>
        /// <returns></returns>
        string CalculateGearString(IGearPairDesignInputParams pairDesignInputParams, IGearPairDesignOutputParams pairDesignOutputParams);
        
        /// <summary>
        /// Calculates the sum coefficient of profile shift x1+x2.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateSumCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the difference coefficient of profile shift x2-x1.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateDifferenceCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the working pitch diameter d_w.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        (double, double) CalculateWorkingPitchDiameter(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Standard Centre Distance a.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateCentreDistance(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Working Pressure Angle alpha_w.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateWorkingPressureAngle(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Whole Depth h.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateWholeDepth(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Centre Distance Increment Factor y.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateCentreDistanceIncrementFactor(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Working Involute Function inv_alpha_w.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateWorkingInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Involute Fumction inv_alpha
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        (double, double) CalculateInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Dedendum h_f
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        (double, double) CalculateDedendum(IGearPairDesignInputParams pairDesignInputParams);
       
        /// <summary>
        /// Calculates the Addendum h_a
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        (double, double) CalculateAddendum(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Root Diameter d_f
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        (double, double) CalculateRootDiameter(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Outside Diameter d_a
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        (double, double) CalculateOutsideDiameter(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Base Diameter d_b
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        (double, double) CalculateBaseDiameter(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Pitch Diameter d
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        (double, double) CalculatePitchDiameter(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Radial Contact Ration epsilon_alpha
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateContactRatioAlpha(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Axial Contact Ration epsilon_beta
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateContactRatioBeta(IGearPairDesignInputParams pairDesignInputParams);
       
        /// <summary>
        /// Calculates the Radial Module m_t
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateRadialModule(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Radial Pressure Angle alpha_t
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateRadialPressureAngle(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Radial Involute Function inv_alpha_t
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateRadialInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Radial Working Involute Function inv_alpha_wt
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateRadialWorkingInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the Radial Working Pressure Angle alpha_wt
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        double CalculateRadialWorkingPressureAngle(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the axial pitch of the specified gear 
        /// </summary>
        /// <param name="gear"></param>
        /// <returns>item1: axial pitch of pinion, item 2 axial pitch of gear </returns>
        (double, double) CalculateAxialPitch(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates the helix pitch length for the specified gear.
        /// In Alibre this is used to define the pitch of the helical boss extruded to form an individual tooth 
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>item1: helix pitch length of pinion, item 2 helix pitch length of gear</returns>
        (double, double) CalculateHelixPitchLength(IGearPairDesignInputParams pairDesignInputParams);
        
        
        /// <summary>
        /// Calculates the small angle between the point at which the involute starts on the base circle and the
        /// point at which the involute crosses the reference pitch diameter
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>a tuple containing the angles for the pinion and gear as item1 and item2 respectively</returns>
        (double, double) CalculatePhi(IGearPairDesignInputParams pairDesignInputParams);
        
       /// <summary>
       ///  Half Tooth Angle At Reference Diameter (Pitch circle)
       /// </summary>
       /// <param name="pairDesignInputParams"></param>
       /// <returns></returns>
        (double, double) CalculateTheta(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Angle by which involute has to be rotated to form opposing tooth flank
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        (double, double) CalculateKappa(IGearPairDesignInputParams pairDesignInputParams);
        
        /// <summary>
        /// Calculates a proposed filename based on the gear input parameters
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>A tuple with proposed file names for pinion (item1) and gear (item2)</returns>
        (string, string) CalculateFileName(IGearPairDesignInputParams pairDesignInputParams);

        (double, double) CalculateHalfToothAngle(IGearPairDesignInputParams pairDesignInputParams);


        (double, double) CalculateToothAngle(IGearPairDesignInputParams pairDesignInputParams);

        (double, double) CalculateTipReliefRadius(IGearPairDesignInputParams designInputParams);

        (double, double) CalculateRootReliefDiameter(IGearPairDesignInputParams designInputParams);

        (double, double) CalculateRootReliefRadius(IGearPairDesignInputParams designInputParams);
        
        /// <summary>
        /// Calculates the outer ring diameter of a ring or internal gear
        /// </summary>
        /// <param name="designInputParams"></param>
        /// <returns>A tuple with outer ring diameters for pinion (item1) and gear (item2)</returns>
        (double, double) CalculateOuterRingDiameter(IGearPairDesignInputParams designInputParams); 
    }
}