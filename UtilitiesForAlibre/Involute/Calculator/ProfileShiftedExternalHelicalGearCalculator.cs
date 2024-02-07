using System;
using System.Collections.Generic;
using System.Text;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Calculator
{
    public class ProfileShiftedExternalHelicalGearCalculator : IGearCalculator
    {
        private readonly IGearPairDesignInputParams _designInputParams;
        private readonly IGearPairDesignOutputParams _designOutputParams;
        

        public ProfileShiftedExternalHelicalGearCalculator(IGearPairDesignInputParams designInputParams,
            IGearPairDesignOutputParams designOutputParams)
        {
            _designInputParams = designInputParams;
            _designOutputParams = designOutputParams;
            _designOutputParams.PinionDesignOutput ??= new GearDesignOutputParams();
            _designOutputParams.GearDesignOutput ??= new GearDesignOutputParams();
            SetupEventListeners();
        }

        private void SetupEventListeners()
        {
            _designInputParams.GearChanged += (_, _) => Calculate();
        }

        /// <summary>
        /// Calculates various design parameters for gear and pinion.
        /// </summary>
        public void Calculate()
        {
            _designOutputParams.Reset();
            var gearOut = _designOutputParams.GearDesignOutput;
            var pinionOut = _designOutputParams.PinionDesignOutput;

            var tipReliefRadius = CalculateTipReliefRadius(_designInputParams); // Tip Relief Radius
            gearOut.TipReliefRadius = tipReliefRadius.Item2; // Tip Relief Radius
            pinionOut.TipReliefRadius = tipReliefRadius.Item1; // Tip Relief Radius

            var rootReliefDiameter = CalculateRootReliefDiameter(_designInputParams); // Root Relief Diameter
            gearOut.RootFilletDiameter = rootReliefDiameter.Item2; // Root Relief Diameter
            pinionOut.RootFilletDiameter = rootReliefDiameter.Item1; // Root Relief Diameter

            var rootReliefRadius = CalculateRootReliefRadius(_designInputParams); // Root Relief Radius
            gearOut.RootFilletRadius = rootReliefRadius.Item2; // Root Relief Radius
            pinionOut.RootFilletRadius = rootReliefRadius.Item1; // Root Relief Radius

            var kappa = CalculateKappa(_designInputParams); // Kappa
            gearOut.Kappa = kappa.Item2; // Kappa
            pinionOut.Kappa = kappa.Item1; // Kappa

            var theta = CalculateTheta(_designInputParams); // Theta
            gearOut.Theta = theta.Item2; // Theta
            pinionOut.Theta = theta.Item1; // Theta

            var phi = CalculatePhi(_designInputParams); // Phi
            gearOut.Phi = phi.Item2; // Phi
            pinionOut.Phi = phi.Item1; // Phi

            var pX = CalculateAxialPitch(_designInputParams); // Axial Pitch
            gearOut.AxialPitch = pX.Item2; // Axial Pitch
            pinionOut.AxialPitch = pX.Item1; // Axial Pitch

            var ph = CalculateHelixPitchLength(_designInputParams); //Helix Pitch Length
            gearOut.HelixPitchLength = ph.Item2; // Helix Pitch Length
            pinionOut.HelixPitchLength = ph.Item1; // Helix Pitch Length

            var xMod = CalculateProfileShiftModificationForBacklash(_designInputParams); // Profile Shift Modification for Backlash
            gearOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash
            pinionOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash

            var sumX = CalculateSumCoefficientOfProfileShift(_designInputParams);
            gearOut.SumCoefficientOfProfileShift = sumX; // Sum of Coefficient of Profile Shift
            pinionOut.SumCoefficientOfProfileShift = sumX; // Sum of Coefficient of Profile Shift

            var alphaWt = CalculateRadialWorkingPressureAngle(_designInputParams);
            gearOut.RadialWorkingPressureAngle = alphaWt; // Radial Pressure Angle
            pinionOut.RadialWorkingPressureAngle = alphaWt; // Radial Pressure Angle

            var invAlphaWt = CalculateRadialWorkingInvoluteFunction(_designInputParams);
            gearOut.RadialWorkingInvoluteFunction = invAlphaWt; // Radial Involute Function
            pinionOut.RadialWorkingInvoluteFunction = invAlphaWt; // Radial Involute Function

            var a = CalculateCentreDistance(_designInputParams); //Centre Distance (standard)
            gearOut.CentreDistance = a; //Centre Distance (standard)
            pinionOut.CentreDistance = a; //Centre Distance (standard)

            var y = CalculateCentreDistanceIncrementFactor(_designInputParams); // Centre Distance Increment Factor
            gearOut.CentreDistanceIncrementFactor = y; // Centre Distance Increment Factor
            pinionOut.CentreDistanceIncrementFactor = y; // Centre Distance Increment Factor

            var invAlpha = CalculateInvoluteFunction(_designInputParams); // Involute Function 
            gearOut.InvoluteFunction = invAlpha.Item2; // Involute Function of Gear
            pinionOut.InvoluteFunction = invAlpha.Item1; // Involute Function of Pinion

            var epsilonAlpha = CalculateContactRatioAlpha(_designInputParams); // Contact Ratio
            gearOut.ContactRatioAlpha = epsilonAlpha; // Contact Ratio
            pinionOut.ContactRatioAlpha = epsilonAlpha; // Contact Ratio

            var epsilonBeta = CalculateContactRatioBeta(_designInputParams); // Contact Ratio
            gearOut.ContactRatioBeta = epsilonBeta; // Contact Ratio
            pinionOut.ContactRatioBeta = epsilonBeta; // Contact Ratio
            
            var epsilonGamma = CalculateContactRatioGamma(_designInputParams); // Contact Ratio
            gearOut.ContactRatioGamma = epsilonGamma; // Contact Ratio
            pinionOut.ContactRatioGamma = epsilonGamma; // Contact Ratio

            var mt = CalculateRadialModule(_designInputParams); // Radial Module
            gearOut.RadialModule = mt; // Radial Module
            pinionOut.RadialModule = mt; // Radial Module

            var alphaT = CalculateRadialPressureAngle(_designInputParams); // Radial Pressure Angle
            gearOut.RadialPressureAngle = alphaT; // Radial Pressure Angle
            pinionOut.RadialPressureAngle = alphaT; // Radial Pressure Angle

            var invAlphaT = CalculateRadialInvoluteFunction(_designInputParams); // Radial Involute Function
            gearOut.RadialInvoluteFunction = invAlphaT; // Radial Involute Function
            pinionOut.RadialInvoluteFunction = invAlphaT; // Radial Involute Function

            var h = CalculateWholeDepth(_designInputParams); // Whole Depth of Pinion and Gear
            pinionOut.WholeDepth = h; // Whole Depth of Pinion
            gearOut.WholeDepth = h; // Whole Depth of GearGearDesignOutput

            var dw = CalculateWorkingPitchDiameter(_designInputParams); // Working Pitch Diameter of Pinion and Gear
            pinionOut.WorkingPitchDiameter = dw.Item1; // Working Pitch Diameter of Pinion
            gearOut.WorkingPitchDiameter = dw.Item2; // Working Pitch Diameter of Gear

            var hf = CalculateDedendum(_designInputParams); // Dedendum of Pinion and Gear
            pinionOut.Dedendum = hf.Item1; // Dedendum of Pinion
            gearOut.Dedendum = hf.Item2; // Dedendum of Gear

            var ha = CalculateAddendum(_designInputParams); // Addendum of Pinion and Gear
            pinionOut.Addendum = ha.Item1; // Addendum of Pinion
            gearOut.Addendum = ha.Item2; // Addendum of Gear

            var df = CalculateRootDiameter(_designInputParams); // Root Diameter of Pinion and Gear
            pinionOut.RootCircleDiameter = df.Item1; // Root Diameter of Pinion
            gearOut.RootCircleDiameter = df.Item2; // Root Diameter of Gear

            var da = CalculateOutsideDiameter(_designInputParams); // Outside Diameter of Pinion and Gear
            pinionOut.OutsideDiameter = da.Item1; // Outside Diameter of Pinion
            gearOut.OutsideDiameter = da.Item2; // Outside Diameter of Gear

            var db = CalculateBaseDiameter(_designInputParams); // Base Diameter of Pinion and Gear
            pinionOut.BaseCircleDiameter = db.Item1; // Base Diameter of Pinion
            gearOut.BaseCircleDiameter = db.Item2; // Base Diameter of Gear

            var dp = CalculatePitchDiameter(_designInputParams); // Pitch Diameter of Pinion and Gear
            pinionOut.PitchCircleDiameter = dp.Item1; // Pitch Diameter of Pinion
            gearOut.PitchCircleDiameter = dp.Item2; // Pitch Diameter of Gear
        }

        private double CalculateContactRatioGamma(IGearPairDesignInputParams designInputParams)
        {
            var epsilonAlpha = CalculateContactRatioAlpha(designInputParams);
            var epsilonBeta = CalculateContactRatioBeta(designInputParams);
            return epsilonAlpha + epsilonBeta;
        }

        /// <summary>
        /// Calculates the profile shift modification for backlash.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns> profile shift modification</returns>
        public double CalculateProfileShiftModificationForBacklash(IGearPairDesignInputParams pairDesignInputParams)
        {
            var jt = pairDesignInputParams.Gear.CircularBacklash; // Circular Backlash required j_t
            var m = pairDesignInputParams.Gear.Module; // Module
            var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); // Radial Pressure Angle
            var alphaWt = Radians(CalculateRadialWorkingPressureAngle(pairDesignInputParams)); // Radial working pressure angle radians
            var num1 = jt / (2 * m * Math.Tan(alphaT));
            var num2 = Math.Cos(alphaWt) / Math.Cos(alphaT);
            var xMod = -(num1 * num2);
            return xMod;
        }

      

        /// <summary>
        /// Calculates the sum coefficient of profile shift based on the gear pair design input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>The sum coefficient of profile shift.</returns>
        public double CalculateSumCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var invAlphaWt = CalculateRadialWorkingInvoluteFunction(pairDesignInputParams);
            var invAlphaT = CalculateRadialInvoluteFunction(pairDesignInputParams); // Involute Function
            var sumX = (z1 + z2) * (invAlphaWt - invAlphaT) / (2 * Math.Tan(Radians(alpha))); // Sum of Coefficient of Profile Shift
            return sumX;
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateDifferenceCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the radial working pitch diameter for a given gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>
        /// A tuple containing the radial working pitch diameters for the two gears in the pair.
        /// The first item in the tuple is the working pitch diameter for the pinion gear.
        /// The second item in the tuple is the working pitch diameter for the gear.
        /// </returns>
        public (double, double) CalculateWorkingPitchDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaWt = Radians(CalculateRadialWorkingPressureAngle(pairDesignInputParams));
            var db = CalculateBaseDiameter(pairDesignInputParams);
            var dwt1 = db.Item1 / Math.Cos(alphaWt);
            var dwt2 = db.Item2 / Math.Cos(alphaWt);

            return (dwt1, dwt2);
        }

        /// <summary>
        /// Calculates the standard centre distance between two gears based on the given gear pair design input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>The standard centre distance between the two gears.</returns>
        public double CalculateCentreDistance(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var aX = (z1 + z2) / (2.0 * Math.Cos(Radians(beta))) * m;

            return aX;
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateWorkingPressureAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the whole depth of a gear pair design based on the input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>The whole depth value.</returns>
        public double CalculateWholeDepth(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var y = CalculateCentreDistanceIncrementFactor(pairDesignInputParams);
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var h = (2.25 + y - (x1 + x2)) * m; // Whole Depth
            return h;
        }

        /// <summary>
        /// Calculates the centre distance increment factor.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>The calculated centre distance increment factor.</returns>
        public double CalculateCentreDistanceIncrementFactor(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var ax = pairDesignInputParams.WorkingCentreDistance;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var y = ax / m - (z1 + z2) / (2 * Math.Cos(Radians(beta)));
            return y;
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateWorkingInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the involute function for a given set of gear pair design input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>The value of the involute function.</returns>
        public (double, double) CalculateInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = pairDesignInputParams.Gear.PressureAngle; // Pressure Angle
            var invAlpha = Math.Tan(Radians(alpha)) - Radians(alpha); // Involute Function
            return (invAlpha, invAlpha);
        }

        /// <summary>
        /// Calculate the dedendum values for a gear pair based on the given input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>A tuple containing the dedendum values for the pinion and gear.</returns>
        public (double, double) CalculateDedendum(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var y = CalculateCentreDistanceIncrementFactor(pairDesignInputParams);
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var ha1 = (1 + y - x2) * m; // Addendum of Pinion
            var ha2 = (1 + y - x1) * m; // Addendum of Gear
            var h = (2.25 + y - (x1 + x2)) * m; // Whole Depth
            var hf1 = h - ha1;
            var hf2 = h - ha2;
            return (hf1, hf2);
        }

        /// <summary>
        /// Calculates the addendum values for a gear pair based on the given gear design parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
        /// <returns>
        /// A tuple containing the calculated addendum values for the pinion and gear.
        /// </returns>
        public (double, double) CalculateAddendum(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var y = CalculateCentreDistanceIncrementFactor(pairDesignInputParams);
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var ha1 = (1 + y - x2) * m; // Addendum of Pinion
            var ha2 = (1 + y - x1) * m; // Addendum of Gear
            return (ha1, ha2);
        }

        /// <summary>
        /// Calculates the root diameter of the pinion and gear based on the given gear pair design input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>
        /// A tuple containing the root diameter of the pinion and gear calculated from the input parameters.
        /// </returns>
        public (double, double) CalculateRootDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var y = CalculateCentreDistanceIncrementFactor(pairDesignInputParams); // Centre Distance Increment Factor
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var da = CalculateOutsideDiameter(pairDesignInputParams); //Outside Diameter
            var h = (2.25 + y - (x1 + x2)) * m; // Whole Depth
            var df1 = da.Item1 - (2 * h);
            var df2 = da.Item2 - (2 * h);
            return (df1, df2);
        }

        /// <summary>
        /// Calculates the outside diameter of the pinion and gear of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>
        /// Tuple containing the outside diameter of the pinion and gear.
        /// </returns>
        public (double, double) CalculateOutsideDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var ha = CalculateAddendum(pairDesignInputParams); // Addendum
            var d = CalculatePitchDiameter(pairDesignInputParams);
            var da1 = d.Item1 + (2 * ha.Item1);
            var da2 = d.Item2 + (2 * ha.Item2);
            return (da1, da2);
        }

        /// <summary>
        /// Calculates the base diameter of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>
        /// The base diameters of the gears in the pair, represented as a tuple (db1, db2).
        /// </returns>
        public (double, double) CalculateBaseDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); //radial pressure angle in radians
            var d = CalculatePitchDiameter(pairDesignInputParams); //pitch diameter
            var db1 = d.Item1 * Math.Cos(alphaT);
            var db2 = d.Item2 * Math.Cos(alphaT);
            return (db1, db2);
        }

        /// <summary>
        /// Calculates the pitch diameter for a gear pair based on the input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>A tuple containing the pitch diameters for the pinion and gear.</returns>
        public (double, double) CalculatePitchDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var d1 = z1 * m / Math.Cos(Radians(beta));
            var d2 = z2 * m / Math.Cos(Radians(beta));
            return (d1, d2);
        }

        /// <summary>
        /// Calculates the contact ratio alpha for a given gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>The contact ratio alpha.</returns>
        public double CalculateContactRatioAlpha(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); //radial pressure angle in radians
            var mt = CalculateRadialModule(pairDesignInputParams);
            var ax = pairDesignInputParams.WorkingCentreDistance;
            var alphaWt = Radians(CalculateRadialWorkingPressureAngle(pairDesignInputParams)); // Working Pressure Angle in Radians
            var db = CalculateBaseDiameter(pairDesignInputParams);
            var da = CalculateOutsideDiameter(pairDesignInputParams);
            var num1 = Math.Sqrt(Math.Pow(da.Item1 / 2, 2) - Math.Pow(db.Item1 / 2, 2));
            var num2 = Math.Sqrt(Math.Pow(da.Item2 / 2, 2) - Math.Pow(db.Item2 / 2, 2));
            var num3 = ax * Math.Sin(alphaWt);
            var num4 = Math.PI * mt * Math.Cos(alphaT);
            var epsilonAlpha = (num1 + num2 - num3) / num4;
            return epsilonAlpha;
        }

        /// <summary>
        /// Calculates the contact ratio beta for a given gear pair design input.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>The contact ratio beta.</returns>
        public double CalculateContactRatioBeta(IGearPairDesignInputParams pairDesignInputParams)
        {
            var b1 = pairDesignInputParams.Pinion.Height;
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var epsilonBeta = (b1 * Math.Sin(Radians(beta))) / (Math.PI * m);
            return epsilonBeta;
        }

        /// <summary>
        /// Calculates the radial module for a gear pair design input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>The calculated radial module.</returns>
        public double CalculateRadialModule(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var mT = m / Math.Cos(Radians(beta));
            return mT;
        }

        /// <summary>
        /// Calculates the radial pressure angle.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
        /// <returns>The calculated radial pressure angle.</returns>
        public double CalculateRadialPressureAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var alphaT = Degrees(Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta))));
            return alphaT;
        }

        /// <summary>
        /// Calculates the radial involute function. </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters object.</param>
        /// <returns>The calculated radial involute function value.</returns>
        public double CalculateRadialInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); // this is the radial pressure angle in radians
            var invAlphaT = Math.Tan(alphaT) - alphaT;
            return invAlphaT;
        }

        /// <summary>
        /// Calculates the radial working involute function.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>The calculated radial working involute function value.</returns>
        public double CalculateRadialWorkingInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaWt = Radians(CalculateRadialWorkingPressureAngle(pairDesignInputParams));
            var invAlphaWt = Math.Tan(alphaWt) - alphaWt;
            return invAlphaWt;
        }

        /// <summary>
        /// Calculates the radial working pressure angle.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
        /// <returns>The calculated radial working pressure angle.</returns>
        public double CalculateRadialWorkingPressureAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); //radians
            var y =  CalculateCentreDistanceIncrementFactor(pairDesignInputParams);
            var alphaWt = Degrees(Math.Acos(((z1 + z2) * Math.Cos(alphaT)) / ((z1 + z2) + (2 * y * Math.Cos(Radians(beta))))));
            return alphaWt;
        }

        /// <summary>
        /// Calculates the axial pitch of the pinion and gear.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>a tuple item 1 axial pitch of pinion, item 2 axial pitch of gear</returns>
        /// <exception cref="NotImplementedException"></exception>
        public (double, double) CalculateAxialPitch(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            var mT = m / Math.Cos(beta);
            var pX = mT / Math.Cos(beta) * Math.PI / Math.Tan(beta);
            return (pX, pX);
        }

        /// <summary>
        /// Calculates the helix pitch length for the specified gear.
        /// In Alibre this is used to define the pitch of the helical boss extruded to form an individual tooth 
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>a tuple item1: helix pitch length of pinion, item 2 helix pitch length of gear</returns>
        public (double, double) CalculateHelixPitchLength(IGearPairDesignInputParams pairDesignInputParams)
        {
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            var mT = CalculateRadialModule(pairDesignInputParams);
            var pX = mT / Math.Cos(beta) * Math.PI / Math.Tan(beta);
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var lX1 = pX * z1;
            var lX2 = pX * z2;
            return (lX1, lX2);
        }

        /// <summary>
        /// Calculates the small angle between the point at which the involute starts on the base circle and the
        /// point at which the involute crosses the reference pitch diameter.
        /// The formula used is
        /// phi = (sqrt((dp^2 - db^2)) /dp) - alphaT
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>a tuple containing the angles for the pinion and gear as item1 and item2 respectively</returns>
        public (double, double) CalculatePhi(IGearPairDesignInputParams pairDesignInputParams)
        {
           var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); //radians
            var d = CalculatePitchDiameter(pairDesignInputParams); //pitch diameter
            var db = CalculateBaseDiameter(pairDesignInputParams); //base diameter
            var phi1 = Math.Sqrt(Math.Pow(d.Item1, 2) - Math.Pow(db.Item1, 2)) / db.Item1 * 180 / Math.PI - Degrees(alphaT);
            var phi2 = Math.Sqrt(Math.Pow(d.Item2, 2) - Math.Pow(db.Item2, 2)) / db.Item2 * 180 / Math.PI - Degrees(alphaT);
            return (phi1, phi2);
        }

        /// <summary>
        /// Half Tooth Angle At Reference Diameter (Pitch circle) with allowance for backlash and profile shift
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        public (double, double) CalculateTheta(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaT =  Radians(CalculateRadialPressureAngle(pairDesignInputParams)); //radians
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var xMod = CalculateProfileShiftModificationForBacklash(pairDesignInputParams);
            var theta1 = 90 / z1 + 360 * (x1 + xMod) * Math.Tan(alphaT) / (Math.PI * z1);
            var theta2 = 90 / z2 + 360 * (x2 + xMod) * Math.Tan(alphaT) / (Math.PI * z2);
            return (theta1, theta2);
        }

        /// <summary>
        /// Angle by which involute has to be rotated to form opposing tooth flank
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>A tuple containing calculated values for pinion (item1) and gear (item2)</returns>
        public (double, double) CalculateKappa(IGearPairDesignInputParams pairDesignInputParams)
        {
            var phi = CalculatePhi(pairDesignInputParams);
            var theta = CalculateTheta(pairDesignInputParams);
            var kappa1 = (theta.Item1 + phi.Item1) * 2;
            var kappa2 = (theta.Item2 + phi.Item2) * 2;

            return (kappa1, kappa2);
        }

        public (double, double) CalculateHalfToothAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            return (360 / (2 * z1), 360 / (2 * z2));
        }

        public (double, double) CalculateToothAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            return (360 / z1, 360 / z2);
        }

        public (double, double) CalculateTipReliefRadius(IGearPairDesignInputParams designInputParams)
        {
            var radius = designInputParams.Gear.AddendumFilletFactor * designInputParams.Gear.Module;
            return (radius, radius);
        }

        public (double, double) CalculateRootReliefDiameter(IGearPairDesignInputParams designInputParams)
        {
            var diameter = designInputParams.Gear.RootFilletFactor * designInputParams.Gear.Module;
            return (diameter, diameter);
        }

        public (double, double) CalculateRootReliefRadius(IGearPairDesignInputParams designInputParams)
        {
            var radius = designInputParams.Gear.RootFilletFactor * designInputParams.Gear.Module / 2;
            return (radius, radius);
        }

        public (double, double) CalculateOuterRingDiameter(IGearPairDesignInputParams designInputParams)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GearData> BuildGearData(IGearPairDesignInputParams pairDesignInputParams, IGearPairDesignOutputParams pairDesignOutputParams)
        {
            Calculate();
            var pinionIn = pairDesignInputParams.Pinion;
            var pinionOut = pairDesignOutputParams.PinionDesignOutput;
            var gearIn = pairDesignInputParams.Gear;
            var gearOut = pairDesignOutputParams.GearDesignOutput;
            var gearData = new List<GearData>();
            gearData.Add(new GearData("Pinion: " + pinionIn.Style, null, null, null, false));
            gearData.Add(new GearData("Module", pinionIn.Module.ToString("0.000"), (25.4 / pinionIn.Module).ToString("0.0000 in DP"), (Math.PI / (25.4 / pinionIn.Module)).ToString("0.0000 in CP"), IsError(pinionIn.Module)));
            gearData.Add(new GearData("Radial Module", pinionOut.RadialModule.ToString("0.000"), (25.4 / pinionOut.RadialModule).ToString("0.0000 in DP"), (Math.PI / (25.4 / pinionOut.RadialModule)).ToString("0.0000 in CP"), IsError(pinionOut.RadialModule)));
            gearData.Add(new GearData("Teeth: ", pinionIn.Teeth.ToString("0"), null, null, false));
            gearData.Add(new GearData("Pressure Angle: ", pinionIn.PressureAngle.ToString("0.000°"), pinionIn.PressureAngle.ToString("0.000°"), null, IsError(pinionIn.PressureAngle)));
            gearData.Add(new GearData("Coefficient of Profile Shift: ", pinionIn.CoefficientOfProfileShift.ToString("0.0000"), pinionIn.CoefficientOfProfileShift.ToString("0.0000"), null,IsError(pinionIn.CoefficientOfProfileShift)));
            gearData.Add(new GearData("Pitch Diameter: ", pinionOut.PitchCircleDiameter.ToString("0.000 mm"), (pinionOut.PitchCircleDiameter / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.PitchCircleDiameter)));
            gearData.Add(new GearData("Working Pitch Diameter: ", pinionOut.WorkingPitchDiameter.ToString("0.000 mm"), (pinionOut.WorkingPitchDiameter / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.WorkingPitchDiameter)));
            gearData.Add(new GearData("Base Diameter: ", pinionOut.BaseCircleDiameter.ToString("0.000 mm"), (pinionOut.BaseCircleDiameter / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.BaseCircleDiameter)));
            gearData.Add(new GearData("Outside Diameter: ", pinionOut.OutsideDiameter.ToString("0.000 mm"), (pinionOut.OutsideDiameter / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.OutsideDiameter)));
            gearData.Add(new GearData("Root Diameter: ", pinionOut.RootCircleDiameter.ToString("0.000 mm"), (pinionOut.RootCircleDiameter / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.RootCircleDiameter)));
            gearData.Add(new GearData("Addendum: ", pinionOut.Addendum.ToString("0.000 mm"), (pinionOut.Addendum / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.Addendum)));
            gearData.Add(new GearData("Dedendum: ", pinionOut.Dedendum.ToString("0.000 mm"), (pinionOut.Dedendum / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.Dedendum)));
            gearData.Add(new GearData("Whole Depth: ", pinionOut.WholeDepth.ToString("0.000 mm"), (pinionOut.WholeDepth / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.WholeDepth)));
            gearData.Add(new GearData("Phi: ", pinionOut.Phi.ToString("0.000°"), pinionOut.Phi.ToString("0.000°"), null,IsError(pinionOut.Theta)));
            gearData.Add(new GearData("Theta: ", pinionOut.Theta.ToString("0.000°"), pinionOut.Theta.ToString("0.000°"), null,IsError(pinionOut.Theta)));
            gearData.Add(new GearData("Kappa: ", pinionOut.Kappa.ToString("0.000"), pinionOut.Kappa.ToString("0.000"), null,IsError(pinionOut.Kappa)));
            gearData.Add(new GearData(" ", null, null, null, false));
            gearData.Add(new GearData("Gear: " + gearIn.Style, null, null, null, false));
            gearData.Add(new GearData("Module", gearIn.Module.ToString("0.000"), (25.4 / gearIn.Module).ToString("0.0000 in DP"), (Math.PI / (25.4 / gearIn.Module)).ToString("0.0000 in CP"),false));
            gearData.Add(new GearData("Radial Module", gearOut.RadialModule.ToString("0.000"), (25.4 / gearOut.RadialModule).ToString("0.0000 in DP"), (Math.PI / (25.4 / gearOut.RadialModule)).ToString("0.0000 in CP"),IsError(gearOut.RadialModule)));

            gearData.Add(new GearData("Teeth: ", gearIn.Teeth.ToString("0"), null, null, false));
            gearData.Add(new GearData("Pressure Angle: ", gearIn.PressureAngle.ToString("0.000°"), gearIn.PressureAngle.ToString("0.000°"), null,IsError(gearIn.PressureAngle)));
            gearData.Add(new GearData("Coefficient of Profile Shift: ", gearIn.CoefficientOfProfileShift.ToString("0.0000"), gearIn.CoefficientOfProfileShift.ToString("0.0000"), null,IsError(gearIn.CoefficientOfProfileShift)));
            gearData.Add(new GearData("Pitch Diameter: ", gearOut.PitchCircleDiameter.ToString("0.000 mm"), (gearOut.PitchCircleDiameter / 25.4).ToString("0.0000 in"), null,IsError(gearOut.PitchCircleDiameter)));
            gearData.Add(new GearData("Working Pitch Diameter: ", gearOut.WorkingPitchDiameter.ToString("0.000 mm"), (gearOut.WorkingPitchDiameter / 25.4).ToString("0.0000 in"), null,IsError(gearOut.WorkingPitchDiameter)));
            gearData.Add(new GearData("Base Diameter: ", gearOut.BaseCircleDiameter.ToString("0.000 mm"), (gearOut.BaseCircleDiameter / 25.4).ToString("0.0000 in"), null,IsError(gearOut.BaseCircleDiameter)));
            gearData.Add(new GearData("Outside Diameter: ", gearOut.OutsideDiameter.ToString("0.000 mm"), (gearOut.OutsideDiameter / 25.4).ToString("0.0000 in"), null,IsError(gearOut.OutsideDiameter)));
            gearData.Add(new GearData("Root Diameter: ", gearOut.RootCircleDiameter.ToString("0.000 mm"), (gearOut.RootCircleDiameter / 25.4).ToString("0.0000 in"), null,IsError(gearOut.RootCircleDiameter)));
            gearData.Add(new GearData("Addendum: ", gearOut.Addendum.ToString("0.000 mm"), (gearOut.Addendum / 25.4).ToString("0.0000 in"), null,IsError(gearOut.Addendum)));
            gearData.Add(new GearData("Dedendum: ", gearOut.Dedendum.ToString("0.000 mm"), (gearOut.Dedendum / 25.4).ToString("0.0000 in"), null,IsError(gearOut.Dedendum)));
            gearData.Add(new GearData("Whole Depth: ", gearOut.WholeDepth.ToString("0.000 mm"), (gearOut.WholeDepth / 25.4).ToString("0.0000 in"), null,IsError(gearOut.WholeDepth)));
            gearData.Add(new GearData("Phi: ", gearOut.Phi.ToString("0.000°"), gearOut.Phi.ToString("0.000°"), null,IsError(gearOut.Phi)));
            gearData.Add(new GearData("Theta: ", gearOut.Theta.ToString("0.000°"), gearOut.Theta.ToString("0.000°"), null,IsError(gearOut.Theta)));
            gearData.Add(new GearData("Kappa: ", gearOut.Kappa.ToString("0.000"), gearOut.Kappa.ToString("0.000"), null,IsError(gearOut.Kappa)));
            gearData.Add(new GearData(" ", null, null, null, false));
            gearData.Add(new GearData("Gear Pair", null, null, null, false));
            gearData.Add(new GearData("Working Centre Distance: ", pairDesignInputParams.WorkingCentreDistance.ToString("0.000 mm"), (pairDesignInputParams.WorkingCentreDistance / 25.4).ToString("0.0000 in"), null,IsError(pairDesignInputParams.WorkingCentreDistance)));
            gearData.Add(new GearData("Standard Centre Distance: ", gearOut.CentreDistance.ToString("0.000 mm"), (gearOut.CentreDistance / 25.4).ToString("0.0000 in"), null,IsError(gearOut.CentreDistance)));
            gearData.Add(new GearData("Centre Distance Increment Factor: ", gearOut.CentreDistanceIncrementFactor.ToString("0.0000"), gearOut.CentreDistanceIncrementFactor.ToString("0.0000"), null,IsError(gearOut.CentreDistanceIncrementFactor)));
            gearData.Add(new GearData("Diff Coefficient Of Profile Shift: ", gearOut.DifferenceCoefficientOfProfileShift.ToString("0.0000"), gearOut.DifferenceCoefficientOfProfileShift.ToString("0.0000"), null,IsError(gearOut.DifferenceCoefficientOfProfileShift)));
            gearData.Add(new GearData("Circular Backlash Required: ", gearIn.CircularBacklash.ToString("0.0000"), gearIn.CircularBacklash.ToString("0.0000"), null,IsError(gearIn.CircularBacklash)));
            gearData.Add(new GearData("Backlash Adjustment Factor: ", gearOut.BacklashAdjustmentFactorXMod.ToString("0.0000"), gearOut.BacklashAdjustmentFactorXMod.ToString("0.0000"), null,IsError(gearOut.BacklashAdjustmentFactorXMod)));
            gearData.Add(new GearData("Radial Involute Function: ", gearOut.RadialInvoluteFunction.ToString("0.0000"), gearOut.RadialInvoluteFunction.ToString("0.0000"), null,IsError(gearOut.RadialInvoluteFunction)));
            gearData.Add(new GearData("Radial Working Involute Function: ", gearOut.RadialWorkingInvoluteFunction.ToString("0.0000"), gearOut.RadialWorkingInvoluteFunction.ToString("0.0000"), null,IsError(gearOut.RadialWorkingInvoluteFunction)));
            gearData.Add(new GearData("Radial Pressure Angle: ", gearOut.RadialPressureAngle.ToString("0.000°"), gearOut.RadialPressureAngle.ToString("0.000°"), null,IsError(gearOut.RadialPressureAngle)));
            gearData.Add(new GearData("Radial Working Pressure Angle: ", gearOut.RadialWorkingPressureAngle.ToString("0.000°"), gearOut.RadialWorkingPressureAngle.ToString("0.000°"), null,IsError(gearOut.RadialWorkingPressureAngle)));
            gearData.Add(new GearData("Axial Pitch: ", gearOut.AxialPitch.ToString("0.000 mm"), (gearOut.AxialPitch / 25.4).ToString("0.0000 in"), null,IsError(gearOut.AxialPitch)));
            gearData.Add(new GearData("Working Pressure Angle: ", gearOut.WorkingPressureAngle.ToString("0.000°"), gearOut.WorkingPressureAngle.ToString("0.000°"), null,IsError(gearOut.WorkingPressureAngle)));
            gearData.Add(new GearData("Working Involute Function: ", gearOut.WorkingInvoluteFunction.ToString("0.0000"), gearOut.WorkingInvoluteFunction.ToString("0.0000"), null,IsError(gearOut.WorkingInvoluteFunction)));
            gearData.Add(new GearData("ContactRatio alpha: ", gearOut.ContactRatioAlpha.ToString("0.0000"), gearOut.ContactRatioAlpha.ToString("0.0000"), null,IsError(gearOut.ContactRatioAlpha)));
            gearData.Add(new GearData("ContactRatio beta: ", gearOut.ContactRatioBeta.ToString("0.0000"), gearOut.ContactRatioBeta.ToString("0.0000"), null,IsError(gearOut.ContactRatioBeta)));
            gearData.Add(new GearData("ContactRatio gamma: ", gearOut.ContactRatioGamma.ToString("0.0000"), gearOut.ContactRatioGamma.ToString("0.0000"), null,IsError(gearOut.ContactRatioGamma)));
            return gearData;
        }

        private static bool IsError(double d)
        {
            return !(!double.IsNaN(d) && !double.IsInfinity(d));

        }

        public (string, string) CalculateFileName(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var jt = pairDesignInputParams.Gear.CircularBacklash; // Circular Backlash required j_t

            StringBuilder sb1 = new StringBuilder();
            sb1.Append("M_");
            sb1.Append(m);
            sb1.Append("_A_");
            sb1.Append(alpha);
            sb1.Append("_B_");
            sb1.Append(beta);
            sb1.Append("_Z_");
            sb1.Append(z1);
            sb1.Append("_X_");
            sb1.Append(x1);
            sb1.Append("_J_");
            sb1.Append(jt);

            StringBuilder sb2 = new StringBuilder();
            sb2.Append("M_");
            sb2.Append(m);
            sb2.Append("_A_");
            sb2.Append(alpha);
            sb2.Append("_B_");
            sb2.Append(beta);
            sb2.Append("_Z_");
            sb2.Append(z2);
            sb2.Append("_X_");
            sb2.Append(x2);
            sb2.Append("_J_");
            sb2.Append(jt);

            return (sb1.ToString(), sb2.ToString());
        }
    }
}