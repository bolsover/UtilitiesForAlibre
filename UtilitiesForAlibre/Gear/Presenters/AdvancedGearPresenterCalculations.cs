using Bolsover.Gear.Calculators;
using Bolsover.Gear.Models;
using Bolsover.Gear.Views;

namespace Bolsover.Gear.Presenters
{
    public class AdvancedGearPresenterCalculations
    {
        private readonly AdvancedHelicalGearCalculator _calculator = new();
        private GearPair _gearPair;
      

        public AdvancedGearPresenterCalculations(GearPair gearPair)
        {
            _gearPair = gearPair;
          
            
        }

        public void Calculate()
        {
            Models.Gear gear = (Models.Gear) _gearPair.Gear;
            Models.Gear pinion = (Models.Gear) _gearPair.Pinion;

            gear.TransverseModule = _calculator.CalculateTransverseModule(_gearPair);
            pinion.TransverseModule = _gearPair.Gear.TransverseModule;
            gear.RadialPressureAngle = _calculator.CalculateRadialPressureAngle(_gearPair);
            pinion.RadialPressureAngle = _gearPair.Gear.RadialPressureAngle;
            gear.InvoluteFunction = _calculator.CalculateTransverseInvoluteFunction(_gearPair);
            pinion.InvoluteFunction = _gearPair.Gear.InvoluteFunction;
            gear.StandardCentreDistance = _calculator.CalculateStandardCentreDistance(_gearPair);
            pinion.StandardCentreDistance = _gearPair.Gear.StandardCentreDistance;
            // for standard gears, working centre distance is the same as standard centre distance
            if (_gearPair.Auto)

            {
                gear.WorkingCentreDistance = _calculator.CalculateProfileShiftedCentreDistance(_gearPair);
                pinion.WorkingCentreDistance = _gearPair.Gear.WorkingCentreDistance;
                gear.NormalCoefficientOfProfileShift = 0d;
                pinion.NormalCoefficientOfProfileShift = 0d;
               
            }
            else
            {
               gear.BacklashAdjustmentFactorXMod = _calculator.CalculateTotalProfileShiftRequiredForBacklash(_gearPair);
                pinion.BacklashAdjustmentFactorXMod = _gearPair.Gear.BacklashAdjustmentFactorXMod;
              
            }

            var assignedTotal = 
             gear.NormalCoefficientOfProfileShift + pinion.NormalCoefficientOfProfileShift + gear.BacklashAdjustmentFactorXMod;

            
            gear.CentreDistanceIncrementFactor = _calculator.CalculateProfileShiftedCentreDistanceIncrementFactor(_gearPair);
            pinion.CentreDistanceIncrementFactor = _gearPair.Gear.CentreDistanceIncrementFactor;
            gear.RadialWorkingPressureAngle = _calculator.CalculateWorkingRadialPressureAngle(_gearPair);
            pinion.RadialWorkingPressureAngle = _gearPair.Gear.RadialWorkingPressureAngle;
            gear.PitchCircleDiameter = _calculator.CalculateGearStandardPitchDiameter(_gearPair);
            pinion.PitchCircleDiameter = _calculator.CalculatePinionStandardPitchDiameter(_gearPair);
            gear.BaseCircleDiameter = _calculator.CalculateGearBaseDiameter(_gearPair);
            pinion.BaseCircleDiameter = _calculator.CalculatePinionBaseDiameter(_gearPair);
            gear.Addendum = _calculator.CalculateGearAddendum(_gearPair);
            pinion.Addendum = _calculator.CalculatePinionAddendum(_gearPair);
            gear.Dedendum = _calculator.CalculateGearDedendum(_gearPair);
            pinion.Dedendum = _calculator.CalculatePinionDedendum(_gearPair);
            gear.WholeDepth = _calculator.CalculateWholeDepth(_gearPair);
            pinion.WholeDepth = _gearPair.Gear.WholeDepth;
            gear.OutsideDiameter = _calculator.CalculateGearOutsideDiameter(_gearPair);
            pinion.OutsideDiameter = _calculator.CalculatePinionOutsideDiameter(_gearPair);
            gear.RootCircleDiameter = _calculator.CalculateGearRootDiameter(_gearPair);
            pinion.RootCircleDiameter = _calculator.CalculatePinionRootDiameter(_gearPair);
            gear.AddendumCircleDiameter = _calculator.CalculateStandardGearAddendumCircleDiameter(_gearPair);
            pinion.AddendumCircleDiameter = _calculator.CalculateStandardPinionAddendumCircleDiameter(_gearPair);
            gear.DedendumCircleDiameter = _calculator.CalculateStandardGearDedendumCircleDiameter(_gearPair);
            pinion.DedendumCircleDiameter = _calculator.CalculateStandardPinionDedendumCircleDiameter(_gearPair);
            gear.Theta = _calculator.GearTheta(_gearPair);
            pinion.Theta = _calculator.PinionTheta(_gearPair);
            gear.Alpha = _calculator.Alpha(gear);
            pinion.Alpha = _calculator.Alpha(pinion);
         
        }
    }
}