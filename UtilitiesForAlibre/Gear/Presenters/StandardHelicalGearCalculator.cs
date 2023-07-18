using System;
using Bolsover.Gear.Models;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Gear.Presenters
{
    public class StandardHelicalGearCalculator
    {
        /// <summary>
        /// Returns the profile shifted centre distance of a gear pair using the formula:
        /// a = (m * (z1 + z2) / 2) / cos(β) + m * (x1 + x2)
        /// Where 
        /// m: Module of the gears
        /// z1, z2: Number of teeth on the first and second gear respectively
        /// β: Helix angle (in radians)
        /// x1, x2: Coefficients of profile shift for the first and second gear respectively
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculateProfileShiftedCentreDistance(IGearPair gearPair)
        {
            var m = gearPair.Gear.NormalModule;
            var z1 = gearPair.Pinion.NumberOfTeeth;
            var z2 = gearPair.Gear.NumberOfTeeth;
            var beta = gearPair.Gear.HelixAngle;
            var x1 = gearPair.Pinion.CoefficientOfProfileShift;
            var x2 = gearPair.Gear.CoefficientOfProfileShift;
            
            var a = (m * (z1 + z2) / 2) / Math.Cos(Radians(beta)) + m * (x1 + x2);

            return a;
        }

     
        /// <summary>
        /// Calculates the centre distance increment factor (y) for a profile shifted gear pair
        ///
        /// y = (ax / mn) - (z1 + z2) / (2cos(beta))
        /// where:
        /// y: centre distance increment factor
        /// ax: working centre distance including any profile shift
        /// mn: module
        /// z1: number of teeth gear 1
        /// z2: number of teeth gear 2
        /// beta: helix angle
        /// 
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculateProfileShiftedCentreDistanceIncrementFactor(IGearPair gearPair)
        {
            var ax = gearPair.Gear.WorkingCentreDistance;
            var mn = gearPair.Gear.NormalModule;
            var sumz = gearPair.Pinion.NumberOfTeeth + gearPair.Gear.NumberOfTeeth;
            var beta = Radians(gearPair.Gear.HelixAngle);
            var y = (ax / mn) - (sumz / (2 * Math.Cos(beta)));
            return y;
        }

        /// <summary>
        /// Returns the working radial pressure angle in degrees
        ///  Acos(((z1 + z2) * cos(alphat)) / ((z1 +z2) + 2yCos(beta)))
        /// Where
        /// z1 = number of teeth gear 1
        /// z2 = number of teeth gear 2
        /// alphat = transverse pressure angle
        /// y = profile shifted centre distance increment factor
        /// beta = helix angle
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculateWorkingRadialPressureAngle(IGearPair gearPair)
        {
            var sumz = gearPair.Gear.NumberOfTeeth + gearPair.Pinion.NumberOfTeeth;
            var alphat = Radians(CalculateRadialPressureAngle(gearPair));
            var y = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var beta = Radians(gearPair.Gear.HelixAngle);
            var result = Degrees(Math.Acos((sumz * Math.Cos(alphat)) / (sumz + (2 * Math.Cos(beta)) * y)));
            return result;
        }
        
       
        /// <summary>
        /// Returns the Radial pressure angle using the formula
        /// alphat = Atan(Tan(alphan/beta))
        /// Where:
        /// alphan = Normal pressure angle
        /// beta = Helix angle
        /// 
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculateRadialPressureAngle(IGearPair gearPair)
        {
            var alphan = Radians(gearPair.Gear.NormalPressureAngle);
            var beta = Radians(gearPair.Gear.HelixAngle);
            var alphat = Degrees(Math.Atan(Math.Tan(alphan) / Math.Cos(beta)));
            return alphat;
        }
       

        public double CalculateTransverseModule(IGearPair gearPair)
        {
            return gearPair.Gear.NormalModule/Math.Cos(Radians(gearPair.Gear.HelixAngle));
        }
        //
        // public double CalculateTipReliefRadius(double module, double numberOfTeeth)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public double CalculateRootFilletFactor(double module, double numberOfTeeth)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public double CalculateTransverseWorkingPressureAngle(double workingPressureAngle, double helixAngle)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public double CalculateTransverseWorkingCentreDistance(double workingCentreDistance, double helixAngle)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public double CalculateTransverseWorkingPitchDiameter(double workingPitchDiameter, double helixAngle)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public double CalculateTransverseTipReliefRadius(double tipReliefRadius, double helixAngle)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public double CalculateTransverseRootFilletFactor(double rootFilletFactor, double helixAngle)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public double CalculateTransverseStandardCentreDistance(double standardCentreDistance, double helixAngle)
        // {
        //     throw new System.NotImplementedException();
        // }

        public double CalculateTransverseInvoluteAlpha(IGearPair gearPair)
        {
           return Math.Tan(Radians(CalculateRadialPressureAngle(gearPair))) - Radians(CalculateRadialPressureAngle(gearPair));
        }

        /// <summary>
        /// Calculates the transverse involute function using the formula:
        /// awt = 2Tan(alphan) ((x1 + x2) / (z1 + z2)) + invat
        /// Where:
        /// alphan: Normal pressure angle
        /// x1: Normal Coefficient profile shift gear1
        /// x2: Normal Coefficient profile shift gear2
        /// z1: Teeth gear1
        /// z2: Teeth gear2
        /// invAlphat: transverse involute of normal pressure angle
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculateTransverseInvoluteFunction(IGearPair gearPair)
        {

            var alphan = Radians(gearPair.Gear.NormalPressureAngle);
            var twoTanAlpha = 2 * Math.Tan(alphan);
            var x1plusx2 = gearPair.Gear.CoefficientOfProfileShift + gearPair.Pinion.CoefficientOfProfileShift;
            var z1plusz2 = gearPair.Pinion.NumberOfTeeth + gearPair.Gear.NumberOfTeeth;
            var involuteAlphat = CalculateTransverseInvoluteAlpha(gearPair);
            var result = twoTanAlpha * (x1plusx2 / z1plusz2) + involuteAlphat;
        
            return result;
        }

       
        /// <summary>
        /// For standard gears, the coefficient of profile shift is always 0
        /// </summary>
        /// <returns></returns>
        public double CalculateStandardCoefficientOfProfileShift()
        {
           
            return 0;
        }
        
        public double CalculateStandardCentreDistance(IGearPair gearPair)
        {

            var num1 = CalculateGearStandardPitchDiameter(gearPair);
            var num2 = CalculatePinionStandardPitchDiameter(gearPair);

            return (num1 + num2) / 2;
        }

        private double CalculateStandardPitchDiameter(IGear gear)
        {
            return gear.NormalModule * gear.NumberOfTeeth / Math.Cos(Radians(gear.HelixAngle));
        }
        
        public double CalculateGearStandardPitchDiameter(IGearPair gearPair)
        {
            return CalculateStandardPitchDiameter(gearPair.Gear);
        }
        
        public double CalculatePinionStandardPitchDiameter(IGearPair gearPair)
        {
            return CalculateStandardPitchDiameter(gearPair.Pinion);
        }
        
      

        public double CalculateGearBaseDiameter(IGearPair gearPair)
        {
            return CalculateGearStandardPitchDiameter(gearPair) * Math.Cos(Radians(CalculateRadialPressureAngle(gearPair)));
        }
        
        public double CalculatePinionBaseDiameter(IGearPair gearPair)
        {
            return CalculatePinionStandardPitchDiameter(gearPair) * Math.Cos(Radians(CalculateRadialPressureAngle(gearPair)));
        }
     
        
        /// <summary>
        /// Returns the addendum value for the Gear (gear2) of a gear pair
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculateGearAddendum(IGearPair gearPair)
        {
            var mn = gearPair.Gear.NormalModule;
            var y = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var x2 = gearPair.Pinion.CoefficientOfProfileShift;

            var ha = (1 + y - x2) * mn;
            return ha;
        }
        
        public double CalculateStandardGearAddendumCircleDiameter(IGearPair gearPair)
        {
            var ha = CalculateGearAddendum(gearPair);
            var d = CalculateStandardPitchDiameter(gearPair.Gear);
            var da = d + 2 * ha;
            return da;
        }
        /// <summary>
        /// Returns the addendum value for the Pinion (gear1) of a gear pair
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns></returns>
        public double CalculatePinionAddendum(IGearPair gearPair)
        {
            var mn = gearPair.Gear.NormalModule;
            var y = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var x1 = gearPair.Gear.CoefficientOfProfileShift;

            var ha1 = (1 + y - x1) * mn;
            return ha1;
        }
        
        public double CalculateStandardPinionAddendumCircleDiameter(IGearPair gearPair)
        {
            var ha = CalculatePinionAddendum(gearPair);
            var d = CalculateStandardPitchDiameter(gearPair.Pinion);
            var da = d + 2 * ha;
            return da;
        }

        public double CalculateGearDedendum(IGearPair gearPair)
        {
            var mn = gearPair.Gear.NormalModule;
            var y = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var x1 = gearPair.Pinion.CoefficientOfProfileShift;

            var ha1 = (1.25 + y - x1) * mn;
            return ha1;
        }
        
        
        public double CalculateStandardGearDedendumCircleDiameter(IGearPair gearPair)
        {
            var ha = CalculateGearDedendum(gearPair);
            var d = CalculateStandardPitchDiameter(gearPair.Gear);
            var df = d - 2 * ha;
            return df;
        }
        
        public double CalculatePinionDedendum(IGearPair gearPair)
        {
            var mn = gearPair.Gear.NormalModule;
            var y = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var x2 = gearPair.Gear.CoefficientOfProfileShift;

            var ha1 = (1.25 + y - x2) * mn;
            return ha1;
        }
        
        public double CalculateStandardPinionDedendumCircleDiameter(IGearPair gearPair)
        {
            var ha = CalculatePinionDedendum(gearPair);
            var d = CalculateStandardPitchDiameter(gearPair.Pinion);
            var df = d - 2 * ha;
            return df;
        }

        public double CalculateWholeDepth(IGearPair gearPair)
        {
            var mn = gearPair.Gear.NormalModule;
            var y = CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            var x1 = gearPair.Pinion.CoefficientOfProfileShift;
            var x2 = gearPair.Gear.CoefficientOfProfileShift;
            var h = (2.25 + y - (x1 + x2)) * mn;
            return h;
        }

        public double CalculateGearOutsideDiameter(IGearPair gearPair)
        {
            return CalculateGearStandardPitchDiameter(gearPair) + 2 * CalculateGearAddendum(gearPair);
        }
        
        public double CalculatePinionOutsideDiameter(IGearPair gearPair)
        {
            return CalculatePinionStandardPitchDiameter(gearPair) + 2 * CalculatePinionAddendum(gearPair);
        }


        public double CalculateGearRootDiameter(IGearPair gearPair)
        {
            return CalculateGearOutsideDiameter(gearPair) - 2 * CalculateWholeDepth(gearPair);
            
         
        }
        public double CalculatePinionRootDiameter(IGearPair gearPair)
        {
            return CalculatePinionOutsideDiameter(gearPair) - 2 * CalculateWholeDepth(gearPair);
            
         
        }
    }
}