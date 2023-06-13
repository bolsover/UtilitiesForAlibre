using Bolsover.Gear.Models;

namespace Bolsover.Gear.Calculators
{
    public interface IGearCalculator
    {
        /// <summary>
        /// Calculates the value of Tan(alpha) - alpha where alpha is the normal pressure angle
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns>Tan(alpha) - alpha
        /// </returns>
        double CalculateInvoluteAlpha(IGearPair gearPair);

        /// <summary>
        /// Calculates the value of the involute function inv alpha w
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        double CalculateInvoluteFunction(IGearPair gearPair);

        /// <summary>
        /// Calculates the working pressure angle in degrees
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        double CalculateWorkingPressureAngle(IGearPair gearPair);

        /// <summary>
        /// Calculates the 'Standard' centre distance of a gear pair. Note that this is NOT the same as the Working Centre Distance which is set at design time.
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        double CalculateCentreDistance(IGearPair gearPair);
       
        
        /// <summary>
        /// Calculates the Pitch Diameter of the gear.
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        double CalculateGearPitchDiameter(IGearPair gearPair);
        
        /// <summary>
        /// Calculates the Pitch Diameter of the pioion.
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        double CalculatePinionPitchDiameter(IGearPair gearPair);
    
        double CalculatePinionBaseDiameter(IGearPair gearPair);

        double CalculateGearBaseDiameter(IGearPair gearPair);
        double CalculatePinionWorkingPitchDiameter(IGearPair gearPair);
        double CalculateGearWorkingPitchDiameter(IGearPair gearPair);
        double CalculatePinionAddendum(IGearPair gearPair);
        double CalculateGearAddendum(IGearPair gearPair);
        
        double CalculateGearDedendum(IGearPair gearPair);
        double CalculatePinionDedendum(IGearPair gearPair);

        double CalculatePinionOutsideDiameter(IGearPair gearPair);
        double CalculateGearOutsideDiameter(IGearPair gearPair);

        double CalculatePinionRootDiameter(IGearPair gearPair);
        double CalculateGearRootDiameter(IGearPair gearPair);
        double CalculateCentreDistanceIncrementFactor(IGearPair gearPair);
        double CalculateSumCoefficientOfProfileShift(IGearPair gearPair);
       
        double CalculateRadialWorkingPressureAngle(IGearPair gearPair);

       double CalculateGearHalfToothAngleAtPitchDiameter(IGearPair gearPair);
        double CalculatePinionHalfToothAngleAtPitchDiameter(IGearPair gearPair);

        public double CalculateGearBacklashModification(IGearPair gearPair);
        
        public double CalculatePinionBacklashModification(IGearPair gearPair);
        
        /// <summary>
        /// The maximum profile shift allowable before undercutting occurs
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        double CalculatePinionMaxProfileShiftWithoutUndercut(IGearPair gearPair);
        
        /// <summary>
        /// The maximum profile shift allowable before undercutting occurs
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        double CalculateGearMaxProfileShiftWithoutUndercut(IGearPair gearPair);
        double CalculatePinionAxialPitch(IGearPair gearPair);
        double CalculateGearAxialPitch(IGearPair gearPair);
        double CalculatePinionHelixPitchLength(IGearPair gearPair);
        double CalculateGearHelixPitchLength(IGearPair gearPair);
        double CalculateGearTransversePressureAngle(IGearPair gearPair);
        double CalculatePinionTransversePressureAngle(IGearPair gearPair);
        double CalculateGearOuterRingDiameter(IGearPair gearPair);
    }
}