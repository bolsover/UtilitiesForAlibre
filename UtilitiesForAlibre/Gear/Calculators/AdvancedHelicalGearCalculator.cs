using System;
using Bolsover.Gear.Models;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Gear.Calculators
{
    public class AdvancedHelicalGearCalculator : StandardHelicalGearCalculator

    {
        /// <summary>
        ///  Calculates the transverse pressure angle of a gear pair using the formula:
        ///  αt = atan(tan(α) / cos(β))
        ///  Where:
        ///  at = Transverse Pressure Angle
        ///  α = Normal Pressure Angle
        ///  β = Helix Angle
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns>The Transverse Pressure angle</returns>
        public double CalculateTransversePressureAngle(IGearPair gearPair)
        {
            var a = gearPair.Gear.NormalPressureAngle;
            var b = gearPair.Gear.HelixAngle;
            var at = Degrees(Math.Atan(Math.Tan(Radians(a)) / Math.Cos(Radians(b))));
            return at;
        }

        /// <summary>
        /// Calculates the transverse involute function of a gear pair using the formula:
        /// invat = tan(αt) - αt
        /// Where:
        /// invat = Transverse Involute Function
        /// at = Transverse Pressure Angle
        /// 
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns>Transverse Involute Function</returns>
        public double CalculateTransverseInvoluteFunction(IGearPair gearPair)
        {
            var aT = CalculateTransversePressureAngle(gearPair);
            var invat = Math.Tan(Radians(aT)) - Radians(aT);
            return invat;
        }

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
        /// <returns>Profile sifted centre distance</returns>
        public double CalculateProfileShiftedCentreDistance(IGearPair gearPair)
        {
            var normalModule = gearPair.Gear.NormalModule;
            var pinionNumberOfTeeth = gearPair.Pinion.NumberOfTeeth;
            var gearNumberOfTeeth = gearPair.Gear.NumberOfTeeth;
            var helixAngle = gearPair.Gear.HelixAngle;
            var pinionCoefficientOfProfileShift = gearPair.Pinion.NormalCoefficientOfProfileShift;
            var gearCoefficientOfProfileShift = gearPair.Gear.NormalCoefficientOfProfileShift;

            var a = (normalModule * (pinionNumberOfTeeth + gearNumberOfTeeth) / 2) / Math.Cos(Radians(helixAngle)) +
                    normalModule * (pinionCoefficientOfProfileShift + gearCoefficientOfProfileShift);

            return a;
        }
        /// <summary>
        /// Calculates the total profile shift of the gear pair using the formula:
        /// sigmax = x1 + x2 - xmod
        /// where: x1 and x2 are the coefficients of profile shift for the pinion and gear respectively
        /// xmod is the modification of profile shift to achieve the desired backlash
        /// </summary>
        /// <param name="gearPair"></param>
        /// <returns>Sum of profile shifts</returns>
        public double SumCoefficientOfProfileShift(IGearPair gearPair)
        {
            var xMod = CalculateTotalProfileShiftRequiredForBacklash(gearPair);   
            var x1 = gearPair.Pinion.NormalCoefficientOfProfileShift;
            var x2 = gearPair.Gear.NormalCoefficientOfProfileShift;

            var sigmaX = x1 + x2 - xMod;

            return sigmaX;
        }

        /// <summary>
        ///  Returns the transverse working involute function of a gear pair using the formula:
        /// alphaW = tan(αW) - αW
        /// Where:
        /// aW: Working pressure angle
        /// </summary>
        /// <param name="pair"></param>
        /// <returns>The working involute function of the gear pair</returns>
        public double CalculateWorkingInvoluteFunction(IGearPair pair)
        {
            var alphaW = CalculateWorkingPressureAngle(pair);
            return Math.Tan(Radians(alphaW)) - Radians(alphaW);
        }

        /// <summary>
        /// Calculates the transverse working pressure angle of a gear pair using the formula:
        ///  αW = acos(((z1+z2) * cos(αT) / ((z1+z2) + 2 * y * cos(β)))
        ///  Where:
        ///  aW = Working transverse pressure angle
        ///  z1, z2 = Number of teeth on the first and second gear respectively
        ///  αT = Transverse pressure angle
        ///  y = Centre distance increment factor
        ///  β = Helix angle
        /// </summary>
        /// <param name="pair"></param>
        /// <returns>Transverse Working Pressure Angle for gear pair</returns>
        public double CalculateWorkingPressureAngle(IGearPair pair)
        {
            var z1z2 = pair.Pinion.NumberOfTeeth + pair.Gear.NumberOfTeeth;
            var y = CalculateCentreDistanceIncrementFactor(pair);
            var a = pair.Gear.NormalPressureAngle;
            var b = pair.Gear.HelixAngle;
            var at = Degrees(Math.Atan(Math.Tan(Radians(a)) / Math.Cos(Radians(b))));
            var cosat = Math.Cos(Radians(at));
            var aW = Degrees(Math.Acos((z1z2 * cosat) /
                                           (z1z2 + 2 * y * Math.Cos(Radians(b)))));
            return aW;
        }

        /// <summary>
        ///  Calculates the centre distance increment factor of a gear pair using the formula:
        ///  y = aw / m - ((z1 + z2) / (2 * cos(β)))
        ///  Where:
        ///  y = Centre distance increment factor
        ///  aw = Profile shifted centre distance
        ///  m = Module
        ///  z1, z2 = Number of teeth on the first and second gear respectively
        ///  β = Helix angle
        /// </summary>
        /// <param name="pair"></param>
        /// <returns>Centre Distance increment factor of gear pair</returns>
        public double CalculateCentreDistanceIncrementFactor(IGearPair pair)
        {
            var z1 = pair.Pinion.NumberOfTeeth;
            var z2 = pair.Gear.NumberOfTeeth;
            var aw = pair.Gear.WorkingCentreDistance;
            var m = pair.Gear.NormalModule;
            var b = pair.Gear.HelixAngle;

            var y = aw / m - ((z1 + z2) / (2 * Math.Cos(Radians(b))));
            return y;
        }

        
       
        /// <summary>
        /// Calculates the tooth thickness at the pitch circle of a gear using the formula:
        /// s = mt * (π/2 + 2x * tan(at))
        /// where:
        /// s = tooth thickness
        /// mt = transverse module
        /// x = profile shift
        /// at = transverse pressure angle
        /// </summary>
        /// <param name="gear"></param>
        /// <returns>s the Tooth Thickness</returns>
        public double CalculateToothThickness(IGear gear)
        {
            
            var m = gear.NormalModule;// module
            var x = gear.NormalCoefficientOfProfileShift;// profile shift
            var a = gear.NormalPressureAngle;// pressure angle
            var b = gear.HelixAngle;  // helix angle
            var at = Math.Atan(Math.Tan(Radians(a))); // transverse pressure angle radians
            var mt = m / Math.Cos(Radians(b)); // transverse module
            
            var s = mt * (Math.PI / 2 + 2 * x * Math.Tan(at));

            return s;

        }
        
        public double CalculateGearToothThickness(IGearPair pair)
        {
            return CalculateToothThickness(pair.Gear);
        }
        
        public double CalculatePinionToothThickness(IGearPair pair)
        {
            return CalculateToothThickness(pair.Pinion);
        }
        
        
        
        

        /// <summary>
        /// Calculates the total profile shift required for backlash of a gear pair using the formula:
        /// modx = jt / (2 * mt * tan(at))
        /// where:
        /// modx = profile shift required for backlash
        /// jt = circumferential backlash required
        /// mt = transverse module
        /// at = transverse pressure angle
        /// </summary>
        /// <param name="pair"></param>
        /// <returns>The total profile shift modification required to achieve the specified circumferential backlash</returns>
        public double CalculateTotalProfileShiftRequiredForBacklash(IGearPair pair)
        {
            var jt = CalculateCircumferentialBacklash(pair); // jt = circumferential backlash required calculated from the normal backlash
            var a = pair.Gear.NormalPressureAngle;
            var b = pair.Gear.HelixAngle;
            var mt = pair.Gear.NormalModule / Math.Cos(Radians(b)); // mt = transverse module
            var at = Math.Atan(Math.Tan(Radians(a)) / Math.Cos(Radians(b))); // at = transverse pressure angle in radians
            var modx = jt / (2 * mt * Math.Tan(at)); // x = profile shift required for backlash
            return -modx; // x is negated because the profile must be reduced to achieve the required backlash
        }

        /// <summary>
        /// Calculates the circumferential backlash of a gear pair using the formula:
        /// jt = jn / (cos(a) * cos(b))
        /// where:
        /// jt = circumferential backlash
        /// jn = normal backlash required
        /// a = normal pressure angle
        /// b = helix angle
        /// </summary>
        /// <param name="pair"></param>
        /// <returns>Circumferential backlash</returns>
        public double CalculateCircumferentialBacklash(IGearPair pair)
        {
            var jn = pair.Gear.NormalBacklash; // jn = required backlash
            var a = pair.Gear.NormalPressureAngle;
            var b = pair.Gear.HelixAngle;
            var jt = jn / (Math.Cos(Radians(a)) * Math.Cos(Radians(b)));
            return jt;
        }

        /// <summary>
        /// Calculates the Sum of Coefficient of Profile Shift (excluding any adjustment for backlash) of a gear pair using the formula:
        /// y= (z1 + z2) * (aW - aT) / 2 tan(a) 
        /// Where:
        /// y = Sum of Coefficient of Profile Shift
        /// z1, z2 = Number of teeth on the first and second gear respectively
        /// at = Transverse pressure angle
        /// aw = Working pressure angle
        /// a   = Normal pressure angle
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public double CalculateSumCoefficientOfProfileShift(IGearPair pair)
        {
            var aT = CalculateTransverseInvoluteFunction(pair);
            var aW = CalculateWorkingInvoluteFunction(pair);
            var z1z2 = pair.Gear.NumberOfTeeth + pair.Pinion.NumberOfTeeth;
            var tanAx2 = 2 * Math.Tan(Radians(pair.Gear.NormalPressureAngle));
            var y = z1z2 * (aW - aT) / tanAx2;
            
            return y;
        }


        /// <summary>
        /// Implements the direct approximation of Inverse Involute by Cheng.
        /// Accurate to six significant figures up to phi = 60 degrees.
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Inverse Involute in degrees</returns>
        public double InverseInvolute(double q)
        {
            double phi = Math.Pow(3 * q, 1.0 / 3) -
                         (2 * q) / 5 +
                         (9.0 / 175) * Math.Pow(3, 2.0 / 3) * Math.Pow(q, 5.0 / 3) -
                         (2.0 / 175) * Math.Pow(3, 1.0 / 3) * Math.Pow(q, 7.0 / 3) -
                         (144.0 / 67375) * Math.Pow(q, 9.0 / 3) +
                         (3258.0 / 3128125) * Math.Pow(3, 2.0 / 3) * Math.Pow(q, 11.0 / 3) -
                         (49711.0 / 153278125) * Math.Pow(3, 1.0 / 3) * Math.Pow(q, 13.0 / 3);
            return Degrees(phi);
        }

        public double AddendumReliefRadiusRa(IGear gear) => gear.TipReliefRadius * gear.NormalModule;

        public double GearTheta(IGearPair gearPair) =>
            90 / gearPair.Gear.NumberOfTeeth + 360 * (gearPair.Gear.NormalCoefficientOfProfileShift + CalculateTotalProfileShiftRequiredForBacklash(gearPair)) *
            Math.Tan(Radians(CalculateTransversePressureAngle(gearPair))) /
            (Math.PI * gearPair.Gear.NumberOfTeeth);

        public double PinionTheta(IGearPair gearPair) =>
            90 / gearPair.Pinion.NumberOfTeeth + 360 * (gearPair.Pinion.NormalCoefficientOfProfileShift + CalculateTotalProfileShiftRequiredForBacklash(gearPair)) *
            Math.Tan(Radians(CalculateTransversePressureAngle(gearPair))) /
            (Math.PI * gearPair.Pinion.NumberOfTeeth);

        /// <summary>
        ///  Calculates the angular separation in degrees of a point at the start of the involute on the base circle and the point at which
        /// the involute intersects the pitch circle. 
        ///  Formula:
        ///  α = sqrt((dp^2 - db^2) / db^2) - αt
        ///  Where:
        ///  a = Angular separation in degrees
        ///  dp = Pitch diameter
        ///  db = Base diameter
        ///  αt = Radial pressure angle
        ///  Note that the gear Pitch Diameter, Base Diameter and Radial Pressure Angle must be set before calling this method.
        /// </summary>
        /// <param name="gear"></param>
        /// <returns>Degrees between involute start point on base circle and involute intersection with pitch circle</returns>
        public double Alpha(IGear gear)
        {
            var dp = gear.PitchCircleDiameter;
            var db = gear.BaseCircleDiameter;
            var alpha = gear.NormalPressureAngle;
            var beta = gear.HelixAngle;
            var at = Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta)));
            
            var result = Degrees((Math.Sqrt(Math.Pow(dp, 2) - Math.Pow(db, 2)) / db )- at); 
            return result;
        }

        // <summary>
        /// Half Tooth Angle At Reference Diameter (Pitch circle)
        /// Note that the gear Profile Shift and Backlash adjustment factor and Radial Pressure Angle must be set before calling this method.
        /// Formula:
        ///  θ = 90 / z + 360 * (x + xmod) * tan(αr) / (π * z)
        ///  where:
        ///  θ = Half Tooth Angle At Reference Diameter (Pitch circle)
        ///  z = Number of teeth
        ///  x = Profile shift
        ///  xmod = Backlash adjustment factor
        ///  αr = Radial pressure angle
        ///  
        /// </summary>
        /// <param name="g"></param>
        /// <returns>Half Tooth Angle At Reference Diameter (Pitch circle)</returns>
        public double Theta(IGear gear)
        {
            var xmod = gear.BacklashAdjustmentFactorXMod;
            var x = gear.NormalCoefficientOfProfileShift;
            var z = gear.NumberOfTeeth;
            var ar = gear.RadialPressureAngle;
            
            var theta = 90 / z + 360 * (x + xmod) *
                         Math.Tan(Radians(ar)) /
                         (Math.PI * z);
            return theta;
        }
            
        
        
        /// <summary>
        /// Angle by which involute has to be rotated to form opposing tooth flank
        /// Formula
        /// rot = (θ + α) * 2
        /// where:
        /// rot = Angle by which involute has to be rotated to form opposing tooth flank
        /// θ = Half Tooth Angle At Reference Diameter (Pitch circle)
        /// α = degrees between involute start point on base circle and involute intersection with pitch circle
        /// Note that the gear Profile Shift and Backlash adjustment factor and Radial Pressure Angle must be set before calling this method.
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public double RotateDegrees(IGear gear) => (Theta(gear) + Alpha(gear)) * 2;
        
        /// <summary>
        /// Calculates the axial pitch of the specified gear 
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public  double AxialPitch(IGear gear) =>
            gear.RadialPressureAngle / Math.Cos(Radians(gear.HelixAngle)) * Math.PI /
            Math.Tan(Radians(gear.HelixAngle));
        
        /// <summary>
        /// Calculates the helix pitch length for the specified gear.
        /// In Alibre this is used to define the pitch of the helical boss extruded to form an individual tooth 
        /// </summary>
        /// <param name="gear"></param>
        /// <returns></returns>
        public double HelixPitchLength(IGear gear) => AxialPitch(gear) * gear.NumberOfTeeth;
        
    }
    
    
}