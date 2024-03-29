﻿using System;
using System.Collections.Generic;
using System.Text;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Calculator
{
    public class ProfileShiftedIntExtSpurGearCalculator : IGearCalculator
    {
        private readonly IGearPairDesignInputParams _designInputParams;
        private readonly IGearPairDesignOutputParams _designOutputParams;


        public ProfileShiftedIntExtSpurGearCalculator(IGearPairDesignInputParams designInputParams, IGearPairDesignOutputParams designOutputParams)
        {
            _designInputParams = designInputParams;
            _designOutputParams = designOutputParams;
            _designOutputParams.PinionDesignOutput ??= new GearDesignOutputParams();
            _designOutputParams.GearDesignOutput ??= new GearDesignOutputParams();
            SetupEventListeners();
        }

        /// <summary>
        /// Calculates various design output parameters of gears based on the design input parameters.
        /// </summary>
        public void Calculate()
        {
            _designOutputParams.Reset();
            var gearOut = _designOutputParams.GearDesignOutput;
            var pinionOut = _designOutputParams.PinionDesignOutput;

            var outerRingDia = CalculateOuterRingDiameter(_designInputParams);
            gearOut.OuterRingDiameter = outerRingDia.Item2; // Outside Diameter of Gear
            pinionOut.OuterRingDiameter = outerRingDia.Item1; // Outside Diameter of Pinion

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

            var xMod = CalculateProfileShiftModificationForBacklash(_designInputParams); // Profile Shift Modification for Backlash
            gearOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash
            pinionOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash

            var diffX = CalculateDifferenceCoefficientOfProfileShift(_designInputParams);
            gearOut.DifferenceCoefficientOfProfileShift = diffX; // Difference of Coefficient of Profile Shift
            pinionOut.DifferenceCoefficientOfProfileShift = diffX; // Difference of Coefficient of Profile Shift

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
            
            var epsilonGamma = CalculateContactRatioAlpha(_designInputParams); // Contact Ratio gamma ia always equal to alpha
            gearOut.ContactRatioGamma = epsilonGamma; // Contact Ratio
            pinionOut.ContactRatioGamma = epsilonGamma; // Contact Ratio

            var h = CalculateWholeDepth(_designInputParams); // Whole Depth of Pinion and Gear
            pinionOut.WholeDepth = h; // Whole Depth of Pinion
            gearOut.WholeDepth = h; // Whole Depth of Gear

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

            var alphaW = CalculateWorkingPressureAngle(_designInputParams); // Working Pressure Angle
            gearOut.WorkingPressureAngle = alphaW; // Working Pressure Angle of Gear
            pinionOut.WorkingPressureAngle = alphaW; // Working Pressure Angle of Pinion

            var invAlphaW = CalculateWorkingInvoluteFunction(_designInputParams); // Working Involute Function
            gearOut.WorkingInvoluteFunction = invAlphaW; // Working Involute Function of Gear
            pinionOut.WorkingInvoluteFunction = invAlphaW; // Working Involute Function of Pinion     
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
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure Angle radians
            var alphaW = Radians(CalculateWorkingPressureAngle(pairDesignInputParams)); // Working Pressure Angle in radians
            var num1 = jt / (2 * m * Math.Tan(alpha));
            var num2 = Math.Cos(alphaW) / Math.Cos(alpha);
            var xMod = num1 * num2;
            return -xMod;
        }

        private void SetupEventListeners()
        {
            _designInputParams.GearChanged += (_, _) => Calculate();
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
            gearData.Add(new GearData("Module", pinionIn.Module.ToString("0.000"), (25.4 / pinionIn.Module).ToString("0.0000 in DP"), (Math.PI / (25.4 / pinionIn.Module)).ToString("0.0000 in CP"),false));
            gearData.Add(new GearData("Teeth: ", pinionIn.Teeth.ToString("0"), null, null, false));
            gearData.Add(new GearData("Pressure Angle: ", pinionIn.PressureAngle.ToString("0.000°"), pinionIn.PressureAngle.ToString("0.000°"), null,IsError(pinionIn.PressureAngle)));
            gearData.Add(new GearData("Coefficient of Profile Shift: ", pinionIn.CoefficientOfProfileShift.ToString("0.0000"), pinionIn.CoefficientOfProfileShift.ToString("0.0000"), null,IsError(pinionIn.CoefficientOfProfileShift)));
            gearData.Add(new GearData("Pitch Diameter: ", pinionOut.PitchCircleDiameter.ToString("0.000 mm"), (pinionOut.PitchCircleDiameter / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.PitchCircleDiameter)));
            gearData.Add(new GearData("Working Pitch Diameter: ", pinionOut.WorkingPitchDiameter.ToString("0.000 mm"), (pinionOut.WorkingPitchDiameter / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.WorkingPitchDiameter)));
            gearData.Add(new GearData("Base Diameter: ", pinionOut.BaseCircleDiameter.ToString("0.000 mm"), (pinionOut.BaseCircleDiameter / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.BaseCircleDiameter)));
            gearData.Add(new GearData("Outside Diameter: ", pinionOut.OutsideDiameter.ToString("0.000 mm"), (pinionOut.OutsideDiameter / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.OutsideDiameter)));
            gearData.Add(new GearData("Root Diameter: ", pinionOut.RootCircleDiameter.ToString("0.000 mm"), (pinionOut.RootCircleDiameter / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.RootCircleDiameter)));
            gearData.Add(new GearData("Addendum: ", pinionOut.Addendum.ToString("0.000 mm"), (pinionOut.Addendum / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.Addendum)));
            gearData.Add(new GearData("Dedendum: ", pinionOut.Dedendum.ToString("0.000 mm"), (pinionOut.Dedendum / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.Dedendum)));
            gearData.Add(new GearData("Whole Depth: ", pinionOut.WholeDepth.ToString("0.000 mm"), (pinionOut.WholeDepth / 25.4).ToString("0.0000 in"), null,IsError(pinionOut.WholeDepth)));
            gearData.Add(new GearData("Phi: ", pinionOut.Phi.ToString("0.000°"), pinionOut.Phi.ToString("0.000°"), null,IsError(pinionOut.Phi)));
            gearData.Add(new GearData("Theta: ", pinionOut.Theta.ToString("0.000°"), pinionOut.Theta.ToString("0.000°"), null,IsError(pinionOut.Theta)));
            gearData.Add(new GearData("Kappa: ", pinionOut.Kappa.ToString("0.000"), pinionOut.Kappa.ToString("0.000"), null,IsError(pinionOut.Kappa)));
            gearData.Add(new GearData(" ", null, null, null, false));
            gearData.Add(new GearData("Gear: " + gearIn.Style, null, null, null, false));
            gearData.Add(new GearData("Module", gearIn.Module.ToString("0.000"), (25.4 / gearIn.Module).ToString("0.0000 in DP"), (Math.PI / (25.4 / gearIn.Module)).ToString("0.0000 in CP"), false));
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
            gearData.Add(new GearData(" ", null, null, null,false));
            gearData.Add(new GearData("Gear Pair", null, null, null, false));
            gearData.Add(new GearData("Working Centre Distance: ", pairDesignInputParams.WorkingCentreDistance.ToString("0.000 mm"), (pairDesignInputParams.WorkingCentreDistance / 25.4).ToString("0.0000 in"), null,IsError(pairDesignInputParams.WorkingCentreDistance)));
            gearData.Add(new GearData("Standard Centre Distance: ", gearOut.CentreDistance.ToString("0.000 mm"), (gearOut.CentreDistance / 25.4).ToString("0.0000 in"), null,IsError(gearOut.CentreDistance)));
            gearData.Add(new GearData("Centre Distance Increment Factor: ", gearOut.CentreDistanceIncrementFactor.ToString("0.0000"), gearOut.CentreDistanceIncrementFactor.ToString("0.0000"), null,IsError(gearOut.CentreDistanceIncrementFactor)));
            gearData.Add(new GearData("Diff Coefficient Of Profile Shift: ", gearOut.DifferenceCoefficientOfProfileShift.ToString("0.0000"), gearOut.DifferenceCoefficientOfProfileShift.ToString("0.0000"), null,IsError(gearOut.DifferenceCoefficientOfProfileShift)));
            gearData.Add(new GearData("Circular Backlash Required: ", gearIn.CircularBacklash.ToString("0.0000"), gearIn.CircularBacklash.ToString("0.0000"), null,IsError(gearIn.CircularBacklash)));
            gearData.Add(new GearData("Backlash Adjustment Factor: ", gearOut.BacklashAdjustmentFactorXMod.ToString("0.0000"), gearOut.BacklashAdjustmentFactorXMod.ToString("0.0000"), null,IsError(gearOut.BacklashAdjustmentFactorXMod)));
            gearData.Add(new GearData("Involute Function: ", gearOut.InvoluteFunction.ToString("0.0000"), gearOut.InvoluteFunction.ToString("0.0000"), null,IsError(gearOut.InvoluteFunction)));
            gearData.Add(new GearData("Working Pressure Angle: ", gearOut.WorkingPressureAngle.ToString("0.000°"), gearOut.WorkingPressureAngle.ToString("0.000°"), null,IsError(gearOut.WorkingPressureAngle)));
            gearData.Add(new GearData("Working Involute Function: ", gearOut.WorkingInvoluteFunction.ToString("0.0000"), gearOut.WorkingInvoluteFunction.ToString("0.0000"), null,IsError(gearOut.WorkingInvoluteFunction)));
            gearData.Add(new GearData("ContactRatio gamma: ", gearOut.ContactRatioGamma.ToString("0.0000"), gearOut.ContactRatioGamma.ToString("0.0000"), null,IsError(gearOut.ContactRatioGamma)));
            return gearData;
            
        }
        
        private static bool IsError(double d)
        {
            return !(!double.IsNaN(d) && !double.IsInfinity(d));

        }

      

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateSumCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the Difference Coefficient of Profile Shift for a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>The difference coefficient of profile shift.</returns>
        public double CalculateDifferenceCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth on gear
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth on pinion
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure angle in radians
            var invAlpha = CalculateInvoluteFunction(pairDesignInputParams);
            var invAlphaW = CalculateWorkingInvoluteFunction(_designInputParams);
            var diff = (z2 - z1) * (invAlphaW - invAlpha.Item1) / (2 * Math.Tan(alpha));
            return diff;
        }

        /// <summary>
        /// Calculates the working pitch diameter for a gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>
        /// A tuple containing the working pitch diameters for the pinion and gear.
        /// </returns>
        public (double, double) CalculateWorkingPitchDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaW = Radians(CalculateWorkingPressureAngle(pairDesignInputParams)); // Working Pressure Angle in radians
            var db = CalculateBaseDiameter(pairDesignInputParams);
            var dw1 = db.Item1 / Math.Cos(alphaW);
            var dw2 = db.Item2 / Math.Cos(alphaW);
            return (dw1, dw2);
        }

        /// <summary>
        /// Calculates the distance between the centers of two gears in a gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>The distance between the centers of the two gears.</returns>
        public double CalculateCentreDistance(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;

            var a = ((z2 - z1) / 2) * m;
            return a;
        }

        /// <summary>
        /// Calculates the working pressure angle based on the gear pair design input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>The calculated working pressure angle in degrees.</returns>
        public double CalculateWorkingPressureAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth on gear
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth on pinion
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure angle in radians
            var y = CalculateCentreDistanceIncrementFactor(pairDesignInputParams); // Centre distance increment factor
            var alphaW = Degrees(Math.Acos((z2 - z1) * Math.Cos(alpha) / (2 * y + z2 - z1))); // Working pressure angle degrees
            return alphaW;
        }

        /// <summary>
        /// Calculates the whole depth of a gear pair based on the given input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>The calculated whole depth.</returns>
        public double CalculateWholeDepth(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var h = 2.25 * m;
            return h;
        }

        /// <summary>
        /// Calculates the standard centre distance increment factor.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>The calculated standard centre distance increment factor.</returns>
        public double CalculateCentreDistanceIncrementFactor(IGearPairDesignInputParams pairDesignInputParams)
        {
            var ax = pairDesignInputParams.WorkingCentreDistance;
            var m = pairDesignInputParams.Gear.Module;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var y = ax / m - (z2 - z1) / 2;
            return y;
        }

        /// <summary>
        /// Calculates the working involute function.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
        /// <returns>
        /// The working involute function.
        /// </returns>
        public double CalculateWorkingInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaW = Radians(CalculateWorkingPressureAngle(pairDesignInputParams)); // Working Pressure Angle in radians
            var invAw = Math.Tan(alphaW) - alphaW; // Working involute function
            return invAw;
        }

        /// <summary>
        /// Calculates the involute function value.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
        /// <returns>
        /// The involute function value.
        /// </returns>
        public (double, double) CalculateInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var invAlpha = Math.Tan(alpha) - alpha;
            return (invAlpha, invAlpha);
        }

        /// <summary>
        /// Calculates the dedendum of a gear pair based on the input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>A tuple containing the dedendum values for both gears in the pair.</returns>
        public (double, double) CalculateDedendum(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var h = 2.25 * m;
            var ha = CalculateAddendum(pairDesignInputParams);
            var hf1 = h - ha.Item1;
            var hf2 = h - ha.Item2;
            return (hf1, hf2);
        }

        /// <summary>
        /// Calculates the addendum of a gear pair based on the input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>
        /// A tuple containing the addendum values for the pinion and gear.
        /// </returns>
        public (double, double) CalculateAddendum(IGearPairDesignInputParams pairDesignInputParams)
        {
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var m = pairDesignInputParams.Gear.Module;
            var ha1 = (1 + x1) * m;
            var ha2 = (1 - x2) * m;
            return (ha1, ha2);
        }

        /// <summary>
        /// Calculates the root diameter of the pinion and gear in a gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>
        /// A tuple containing the root diameter of the pinion and gear, respectively.
        /// </returns>
        public (double, double) CalculateRootDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var da = CalculateOutsideDiameter(pairDesignInputParams);
            var h = 2.25 * m;
            var df1 = da.Item1 - 2 * h;
            var df2 = da.Item2 + 2 * h;
            return (df1, df2);
        }

        /// <summary>
        /// Calculates the outside diameter of a gear pair based on the given input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
        /// <returns>
        /// A tuple containing the outside diameter of the pinion gear (da1) and the gear (da2).
        /// </returns>
        public (double, double) CalculateOutsideDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var ha = CalculateAddendum(pairDesignInputParams);
            var d = CalculatePitchDiameter(pairDesignInputParams);
            var da1 = d.Item1 + 2 * ha.Item1;
            var da2 = d.Item2 - 2 * ha.Item2;
            return (da1, da2);
        }

        /// <summary>
        /// Calculates the base diameter for the pinion and gear in a gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>A tuple containing the base diameter for the pinion and gear.</returns>
        public (double, double) CalculateBaseDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var d = CalculatePitchDiameter(pairDesignInputParams);
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var db1 = d.Item1 * Math.Cos(alpha);
            var db2 = d.Item2 * Math.Cos(alpha);
            return (db1, db2);
        }

        /// <summary>
        /// Calculates the pitch diameter for a pair of gears.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>
        /// A tuple containing the pitch diameters of the pinion and gear.
        /// </returns>
        public (double, double) CalculatePitchDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;
            var d1 = z1 * m;
            var d2 = z2 * m;
            return (d1, d2);
        }

        /// <summary>
        /// Calculates the contact ratio alpha for a given gear pair design input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>The contact ratio alpha.</returns>
        public double CalculateContactRatioAlpha(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var db = CalculateBaseDiameter(pairDesignInputParams);
            var da = CalculateOutsideDiameter(pairDesignInputParams);
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working centre distance
            var alphaW = Radians(CalculateWorkingPressureAngle(pairDesignInputParams)); // Working Pressure Angle in radians
            var num1 = Math.Sqrt(Math.Pow(da.Item1 / 2, 2) - Math.Pow(db.Item1 / 2, 2));
            var num2 = Math.Sqrt(Math.Pow(da.Item2 / 2, 2) - Math.Pow(db.Item2 / 2, 2));
            var num3 = ax * Math.Sin(alphaW);
            var num4 = Math.PI * m * Math.Cos(alpha);

            var epsilonAlpha = (num1 - num2 + num3) / num4;


            return epsilonAlpha;
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateContactRatioBeta(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialModule(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialPressureAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialWorkingInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialWorkingPressureAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public (double, double) CalculateAxialPitch(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public (double, double) CalculateHelixPitchLength(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the small angle between the point at which the involute starts on the base circle and the
        /// point at which the involute crosses the reference pitch diameter
        /// /// The formula used is
        /// phi = (sqrt((dp^2 - db^2)) /dp) - alpha
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>a tuple containing the angles for the pinion and gear as item1 and item2 respectively</returns>
        public (double, double) CalculatePhi(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var d = CalculatePitchDiameter(pairDesignInputParams);
            var db = CalculateBaseDiameter(pairDesignInputParams);
            var phi1 = Math.Sqrt(Math.Pow(d.Item1, 2) - Math.Pow(db.Item1, 2)) / db.Item1 * 180 / Math.PI - Degrees(alpha);
            var phi2 = Math.Sqrt(Math.Pow(d.Item2, 2) - Math.Pow(db.Item2, 2)) / db.Item2 * 180 / Math.PI - Degrees(alpha);

            return (phi1, phi2);
        }

        /// <summary>
        /// Half Tooth Angle At Reference Diameter (Pitch circle) with allowance for backlash and profile shift
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        public (double, double) CalculateTheta(IGearPairDesignInputParams pairDesignInputParams)
        {
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var jt = pairDesignInputParams.Gear.CircularBacklash; // Circular Backlash required j_t
            var m = pairDesignInputParams.Gear.Module; // Module
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure Angle radians
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var alphaW = CalculateWorkingPressureAngle(pairDesignInputParams); // Working pressure angle degrees
            var num1 = jt / (2 * m * Math.Tan(alpha));
            var num2 = Math.Cos(alphaW) / Math.Cos(alpha);
            var xMod = -(num1 * num2);
            var theta1 = 90 / z1 + 360 * (x1 + xMod) * Math.Tan(alpha) / (Math.PI * z1);
            var theta2 = 90 / z2 + 360 * (x2 + xMod) * Math.Tan(alpha) / (Math.PI * z2);
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

        public (double, double) CalculateOuterRingDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var df = CalculateRootDiameter(pairDesignInputParams);
            var outerRingDiameter1 = Math.Ceiling(df.Item1) + m;
            var outerRingDiameter2 = Math.Ceiling(df.Item2) + m;
            return (outerRingDiameter1, outerRingDiameter2);
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

            var sb1 = new StringBuilder();
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

            var sb2 = new StringBuilder();
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