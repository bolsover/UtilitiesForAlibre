using System;
using System.Text;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Calculator
{
    public class ProfileShiftedIntExtHelicalGearCalculator : IGearCalculator
    {
        private readonly IGearPairDesignInputParams _designInputParams;
        private readonly IGearPairDesignOutputParams _designOutputParams;


        public ProfileShiftedIntExtHelicalGearCalculator(IGearPairDesignInputParams designInputParams,
            IGearPairDesignOutputParams designOutputParams)
        {
            _designInputParams = designInputParams;
            _designOutputParams = designOutputParams;
            _designOutputParams.PinionDesignOutput ??= new GearDesignOutputParams();
            _designOutputParams.GearDesignOutput ??= new GearDesignOutputParams();
            SetupEventListeners();
        }

        /// <summary>
        /// Calculate all the gear parameters
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

            var pX = CalculateAxialPitch(_designInputParams); // Axial Pitch
            gearOut.AxialPitch = pX.Item2; // Axial Pitch
            pinionOut.AxialPitch = pX.Item1; // Axial Pitch

            var ph = CalculateHelixPitchLength(_designInputParams); //Helix Pitch Length
            gearOut.HelixPitchLength = ph.Item2; // Helix Pitch Length
            pinionOut.HelixPitchLength = ph.Item1; // Helix Pitch Length

            var xMod = CalculateProfileShiftModificationForBacklash(
                _designInputParams); // Profile Shift Modification for Backlash
            gearOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash
            pinionOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash

            var diffX = CalculateDifferenceCoefficientOfProfileShift(_designInputParams);
            gearOut.DifferenceCoefficientOfProfileShift = diffX; // Difference of Coefficient of Profile Shift
            pinionOut.DifferenceCoefficientOfProfileShift = diffX; // Difference of Coefficient of Profile Shift

            var mT = CalculateRadialModule(_designInputParams); // Radial Module
            gearOut.RadialModule = mT; // Radial Module
            pinionOut.RadialModule = mT; // Radial Module

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

            var alphaWt = CalculateRadialWorkingPressureAngle(_designInputParams);
            pinionOut.RadialWorkingPressureAngle = alphaWt;
            gearOut.RadialWorkingPressureAngle = alphaWt;

            var invAlphaWt = CalculateRadialWorkingInvoluteFunction(_designInputParams);
            pinionOut.RadialWorkingInvoluteFunction = invAlphaWt;
            gearOut.RadialWorkingInvoluteFunction = invAlphaWt;

            var alphaT = CalculateRadialPressureAngle(_designInputParams);
            pinionOut.RadialPressureAngle = alphaT;
            gearOut.RadialPressureAngle = alphaT;
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
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            var alphaT = Math.Atan(Math.Tan(alpha) / Math.Cos(beta));
            var alphaWt =
                Radians(CalculateRadialWorkingPressureAngle(pairDesignInputParams)); // Working pressure angle radians
            var num1 = jt / (2 * m * Math.Tan(alphaT));
            var num2 = Math.Cos(alphaWt) / Math.Cos(alphaT);
            var xMod = -(num1 * num2);
            return xMod;
        }

        private void SetupEventListeners()
        {
            _designInputParams.PropertyChanged += (_, _) => Calculate();
        }

        /// <summary>
        /// Generates a custom string containing the gear design parameters.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <param name="pairDesignOutputParams"></param>
        /// <returns>string containing the gear design parameters</returns>
        public string CalculateGearString(IGearPairDesignInputParams pairDesignInputParams,
            IGearPairDesignOutputParams pairDesignOutputParams)
        {
            var pinionIn = pairDesignInputParams.Pinion;
            var pinionOut = pairDesignOutputParams.PinionDesignOutput;
            var gearIn = pairDesignInputParams.Gear;
            var gearOut = pairDesignOutputParams.GearDesignOutput;
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("Pinion");
            sb.AppendLine("Gear Type: " + pinionIn.Style.ToString());
            sb.AppendLine("Item:  ".PadRight(41) + "Metric".PadRight(21) + "Imperial");
            sb.AppendLine("Module:  ".PadRight(41) + pinionIn.Module.ToString("0.000").PadRight(21) +
                          (25.4 / pinionIn.Module).ToString("0.0000 in DP") + ", " +
                          (Math.PI / (25.4 / pinionIn.Module)).ToString("0.0000 in CP"));
            sb.AppendLine("Radial Module:  ".PadRight(41) + pinionOut.RadialModule.ToString("0.000").PadRight(21) +
                          (25.4 / pinionOut.RadialModule).ToString("0.0000 in DP") + ", " +
                          (Math.PI / (25.4 / pinionOut.RadialModule)).ToString("0.0000 in CP"));
            AppendLineWithDefaultFormat(sb, "Teeth: ", pinionIn.Teeth);
            AppendLineWithDegFormat(sb, "Pressure Angle: ", pinionIn.PressureAngle);
            AppendLineWithDegFormat(sb, "Helix Angle beta: ", pinionIn.HelixAngle);
            AppendLineWithDefaultFormat(sb, "Coefficient of Profile Shift: ", pinionIn.CoefficientOfProfileShift);
            AppendLineWithMmInFormat(sb, "Pitch Diameter: ", pinionOut.PitchCircleDiameter, 25.4);
            AppendLineWithMmInFormat(sb, "Working Pitch Diameter: ", pinionOut.WorkingPitchDiameter, 25.4);
            AppendLineWithMmInFormat(sb, "Base Diameter: ", pinionOut.BaseCircleDiameter, 25.4);
            AppendLineWithMmInFormat(sb, "Outside Diameter: ", pinionOut.OutsideDiameter, 25.4);
            AppendLineWithMmInFormat(sb, "Root Diameter: ", pinionOut.RootCircleDiameter, 25.4);
            AppendLineWithMmInFormat(sb, "Addendum: ", pinionOut.Addendum, 25.4);
            AppendLineWithMmInFormat(sb, "Dedendum: ", pinionOut.Dedendum, 25.4);
            AppendLineWithMmInFormat(sb, "Whole Depth: ", pinionOut.WholeDepth, 25.4);
            AppendLineWithDegFormat(sb, "Phi: ", pinionOut.Phi);
            AppendLineWithDegFormat(sb, "Theta: ", pinionOut.Theta);
            AppendLineWithDegFormat(sb, "Kappa: ", pinionOut.Kappa);

            sb.AppendLine();
            sb.AppendLine("Gear");
            sb.AppendLine("Gear Type: " + gearIn.Style.ToString());
            sb.AppendLine("Item:  ".PadRight(41) + "Metric".PadRight(21) + "Imperial");
            sb.AppendLine("Module:  ".PadRight(41) + gearIn.Module.ToString("0.000").PadRight(21) +
                          (25.4 / gearIn.Module).ToString("0.0000 in DP") + ", " +
                          (Math.PI / (25.4 / gearIn.Module)).ToString("0.0000 in CP"));
            sb.AppendLine("Radial Module:  ".PadRight(41) + gearOut.RadialModule.ToString("0.000").PadRight(21) +
                          (25.4 / gearOut.RadialModule).ToString("0.0000 in DP") + ", " +
                          (Math.PI / (25.4 / gearOut.RadialModule)).ToString("0.0000 in CP"));
            AppendLineWithDefaultFormat(sb, "Teeth: ", gearIn.Teeth);
            AppendLineWithDegFormat(sb, "Pressure Angle: ", gearIn.PressureAngle);
            AppendLineWithDegFormat(sb, "Helix Angle beta: ", gearIn.HelixAngle);
            AppendLineWithDefaultFormat(sb, "Coefficient of Profile Shift: ", gearIn.CoefficientOfProfileShift);
            AppendLineWithMmInFormat(sb, "Pitch Diameter: ", gearOut.PitchCircleDiameter, 25.4);
            AppendLineWithMmInFormat(sb, "Working Pitch Diameter: ", gearOut.WorkingPitchDiameter, 25.4);
            AppendLineWithMmInFormat(sb, "Base Diameter: ", gearOut.BaseCircleDiameter, 25.4);
            AppendLineWithMmInFormat(sb, "Outside Diameter: ", gearOut.OutsideDiameter, 25.4);
            AppendLineWithMmInFormat(sb, "Root Diameter: ", gearOut.RootCircleDiameter, 25.4);
            AppendLineWithMmInFormat(sb, "Addendum:", gearOut.Addendum, 25.4);
            AppendLineWithMmInFormat(sb, "Dedendum: ", gearOut.Dedendum, 25.4);
            AppendLineWithMmInFormat(sb, "Whole Depth: ", gearOut.WholeDepth, 25.4);
            AppendLineWithDegFormat(sb, "Phi: ", gearOut.Phi);
            AppendLineWithDegFormat(sb, "Theta: ", gearOut.Theta);
            AppendLineWithDegFormat(sb, "Kappa: ", gearOut.Kappa);

            sb.AppendLine();
            sb.AppendLine("Gear Pair");
            AppendLineWithMmInFormat(sb, "Working Centre Distance: ", pairDesignInputParams.WorkingCentreDistance, 25.4);
            AppendLineWithMmInFormat(sb, "Standard Centre Distance: ", gearOut.CentreDistance, 25.4);
            AppendLineWithDefaultFormat(sb, "Centre Distance Increment Factor: ", gearOut.CentreDistanceIncrementFactor);
            AppendLineWithDefaultFormat(sb, "Diff Coefficient Of Profile Shift: ",
                gearOut.DifferenceCoefficientOfProfileShift);
            AppendLineWithDefaultFormat(sb, "Circular Backlash Required: ", gearIn.CircularBacklash);
            AppendLineWithDefaultFormat(sb, "Backlash Adjustment Factor: ", gearOut.BacklashAdjustmentFactorXMod);
            AppendLineWithDefaultFormat(sb, "Involute Function: ", gearOut.InvoluteFunction);
            AppendLineWithDefaultFormat(sb, "Radial Involute Function: ", gearOut.RadialInvoluteFunction);
            AppendLineWithDefaultFormat(sb, "Radial Working Involute Function: ", gearOut.RadialWorkingInvoluteFunction);
            AppendLineWithDegFormat(sb, "Radial Pressure Angle: ", gearOut.RadialPressureAngle);
            AppendLineWithDegFormat(sb, "Radial Working Pressure Angle: ", gearOut.RadialWorkingPressureAngle);
            AppendLineWithDefaultFormat(sb, "Axial Pitch: ", gearOut.AxialPitch);
            AppendLineWithDefaultFormat(sb, "ContactRatio alpha: ", gearOut.ContactRatioAlpha);
            AppendLineWithDefaultFormat(sb, "ContactRatio beta: ", gearOut.ContactRatioBeta);
            AppendLineWithDefaultFormat(sb, "ContactRatio gamma: ", gearOut.ContactRatioGamma);


            return sb.ToString();
        }

        private static void AppendLineWithDefaultFormat(StringBuilder sb, string label, double value)
        {
            sb.AppendLine($"{label,-40} {value,-20:0.0000} {value:0.0000}");
        }

        private static void AppendLineWithDegFormat(StringBuilder sb, string label, double value)
        {
            sb.AppendLine($"{label,-40} {value,-20:0.0000°} {value:0.0000°}");
        }

        private static void AppendLineWithMmInFormat(StringBuilder sb, string label, double value, double coefficient = 1)
        {
            sb.AppendLine($"{label,-40} {value,-20:0.0000 mm} {value / coefficient:0.0000 in}");
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
        /// Calculate the difference of the coefficient of profile shift
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>Difference Coefficient Of ProfileShift xDiff</returns>
        public double CalculateDifferenceCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth on gear
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth on pinion
           var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams));//Radial pressure angle radians
            var alphaWt = Radians(CalculateRadialWorkingPressureAngle(pairDesignInputParams)); // Working pressure angle radians
            var invAlphaT = CalculateRadialInvoluteFunction(pairDesignInputParams);
            var invAlphaW = Math.Tan(alphaWt) - alphaWt; // Working involute function
            var diff = (z2 - z1) * (invAlphaW - invAlphaT) / (2 * Math.Tan(alphaT));
            return diff;
        }

        /// <summary>
        /// Calculate the working pitch diameter of the pinion and gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>WorkingPitchDiameters of pinion and gear dw</returns>
        public (double, double) CalculateWorkingPitchDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var db = CalculateBaseDiameter(pairDesignInputParams);

            var alphaWt =
                Radians(CalculateRadialWorkingPressureAngle(pairDesignInputParams)); // Working pressure angle radians
            var dw1 = db.Item1 / Math.Cos(alphaWt);
            var dw2 = db.Item2 / Math.Cos(alphaWt);
            return (dw1, dw2);
        }

        /// <summary>
        /// Calculate the standard centre distance of the pinion and gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>Standard Centre Distance a</returns>
        public double CalculateCentreDistance(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var a = (z2 - z1) / (2 * Math.Cos(Radians(beta))) * m;
            return a;
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
        /// Calculate the whole depth of the pinion and gear teeth
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns> Whole Depth h</returns>
        public double CalculateWholeDepth(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var h = 2.25 * m;
            return h;
        }

        /// <summary>
        /// Calculate the centre distance increment factor
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>CentreDistanceIncrementFactor y</returns>
        public double CalculateCentreDistanceIncrementFactor(IGearPairDesignInputParams pairDesignInputParams)
        {
            var ax = pairDesignInputParams.WorkingCentreDistance;
            var m = pairDesignInputParams.Gear.Module;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var y = ax / m - (z2 - z1) / (2 * Math.Cos(Radians(beta)));
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
        /// Calculate the involute function
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>Involute Function</returns>
        public (double, double) CalculateInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var invAlpha = Math.Tan(alpha) - alpha;
            return (invAlpha, invAlpha);
        }

        /// <summary>
        /// Calculate the dedendum of the pinion and gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>Dedendum of pinion and gear</returns>
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
        /// Calculate the addendum of the pinion and gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>addendum of the pinion and gear</returns>
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
        /// Calculate the root diameter of the pinion and gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>root diameter of the pinion and gear</returns>
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
        /// Calculates the outside diameter of a gear pair based on the given input parameters. </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>
        /// A tuple containing the outside diameter of the pinion gear and the outside diameter of the gear. </returns>
        /// <remarks> The outside diameter is the diameter of the gear measured from the outside of the teeth. </remarks>
        public (double, double) CalculateOutsideDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var ha = CalculateAddendum(pairDesignInputParams);
            var d = CalculatePitchDiameter(pairDesignInputParams); //pitch Diameters
            var da1 = d.Item1 + 2 * ha.Item1;
            var da2 = d.Item2 - 2 * ha.Item2;
            return (da1, da2);
        }

        /// <summary>
        /// Calculates the base diameters of two gears in a gear pair design based on the input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>A tuple containing the base diameter of the pinion (db1) and the base diameter of the gear (db2).</returns>
        public (double, double) CalculateBaseDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var d = CalculatePitchDiameter(pairDesignInputParams); //pitch Diameters
            var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); // Radial pressure angle
            var db1 = d.Item1 * Math.Cos(alphaT);
            var db2 = d.Item2 * Math.Cos(alphaT);
            return (db1, db2);
        }

        /// <summary>
        /// Calculates the pitch diameter for a gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">An object containing the gear pair design input parameters.</param>
        /// <returns>
        /// A tuple containing the pitch diameter of the pinion and gear, in millimeters.
        /// </returns>
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
        /// Calculates the contact ratio alpha for a gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>The calculated contact ratio alpha.</returns>
        public double CalculateContactRatioAlpha(IGearPairDesignInputParams pairDesignInputParams)
        {
            
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working centre distance
            var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); // Radial pressure angle
            var db = CalculateBaseDiameter(pairDesignInputParams);
            var da = CalculateOutsideDiameter(pairDesignInputParams);
            var alphaWt =
                Radians(CalculateRadialWorkingPressureAngle(pairDesignInputParams)); // Working pressure angle radians
            var mt = CalculateRadialModule(pairDesignInputParams); // Transverse (Radial) module
            var num1 = Math.Sqrt(Math.Pow(da.Item1 / 2, 2) - Math.Pow(db.Item1 / 2, 2));
            var num2 = Math.Sqrt(Math.Pow(da.Item2 / 2, 2) - Math.Pow(db.Item2 / 2, 2));
            var num3 = ax * Math.Sin(alphaWt);
            var num4 = Math.PI * mt * Math.Cos(alphaT);
            var epsilonAlpha = (num1 - num2 + num3) / num4;

            return epsilonAlpha;
        }

        /// <summary>
        /// Calculates the contact ratio beta for a given gear pair design input.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
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
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialModule(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var mT = m / Math.Cos(Radians(beta));
            return mT;
        }

        /// <summary>
        /// Calculates the radial pressure angle based on the given gear pair design input parameters.
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
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); // Radial pressure angle radians
            var invAlphaT = Math.Tan(alphaT) - alphaT;
            return invAlphaT;
        }

        /// <summary>
        /// Calculates the radial working involute function.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
        /// <returns>The calculated radial working involute function.</returns>
        public double CalculateRadialWorkingInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaWt =
                Radians(CalculateRadialWorkingPressureAngle(pairDesignInputParams)); // Working pressure angle radians
            var invAlphaWt = Math.Tan(alphaWt) - alphaWt;
            return invAlphaWt;
        }

        /// <summary>
        /// Calculates the radial working pressure angle for a gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
        /// <returns>The radial working pressure angle in degrees.</returns>
        public double CalculateRadialWorkingPressureAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); // Radial pressure angle
            var z2 = pairDesignInputParams.Gear.Teeth;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var y = CalculateCentreDistanceIncrementFactor(pairDesignInputParams);
            var alphaWt = Degrees(Math.Acos((z2 - z1) * Math.Cos(alphaT) / (z2 - z1 + 2 * y * Math.Cos(Radians(beta)))));
            return alphaWt;
        }


        /// <summary>
        /// Calculates the axial pitch of the pinion and gear.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>item 1 axial pitch of pinion, item 2 axial pitch of gear</returns>
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
        /// <returns>item1: helix pitch length of pinion, item 2 helix pitch length of gear</returns>
        public (double, double) CalculateHelixPitchLength(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            var mT = m / Math.Cos(beta);
            var pX = mT / Math.Cos(beta) * Math.PI / Math.Tan(beta);
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var lX1 = pX * z1;
            var lX2 = pX * z2;
            return (lX1, lX2);
        }

        /// <summary>
        /// Calculates the small angle between the point at which the involute starts on the base circle and the
        /// point at which the involute crosses the reference pitch diameter
        /// /// The formula used is
        /// phi = (sqrt((dp^2 - db^2)) /dp) - alphaT
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>a tuple containing the angles for the pinion and gear as item1 and item2 respectively</returns>
        public (double, double) CalculatePhi(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alphaT = CalculateRadialPressureAngle(pairDesignInputParams); // Radial pressure angle degrees
          var d = CalculatePitchDiameter(pairDesignInputParams); //pitch Diameters
            var db = CalculateBaseDiameter(pairDesignInputParams);
            var phi1 = Math.Sqrt(Math.Pow(d.Item1, 2) - Math.Pow(db.Item1, 2)) / db.Item1 * 180 / Math.PI - alphaT;
            var phi2 = Math.Sqrt(Math.Pow(d.Item2, 2) - Math.Pow(db.Item2, 2)) / db.Item2 * 180 / Math.PI - alphaT;
            return (phi1, phi2);
        }

        /// <summary>
        /// Half Tooth Angle At Reference Diameter (Pitch circle) with allowance for backlash and profile shift
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        public (double, double) CalculateTheta(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
           var alphaT = Radians(CalculateRadialPressureAngle(pairDesignInputParams)); // Radial pressure angle radians
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var jt = pairDesignInputParams.Gear.CircularBacklash; // Circular Backlash required j_t
            var alphaWt =
                Radians(CalculateRadialWorkingPressureAngle(pairDesignInputParams)); // Working pressure angle radians
            var num1 = jt / (2 * m * Math.Tan(alphaT));
            var num2 = Math.Cos(alphaWt) / Math.Cos(alphaT);
            var xMod = -(num1 * num2);
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

        public (double, double) CalculateOuterRingDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            // var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            // var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var m = pairDesignInputParams.Gear.Module;
            // var ha1 = (1 + x1) * m;
            // var ha2 = (1 - x2) * m;
            // var z1 = pairDesignInputParams.Pinion.Teeth;
            // var z2 = pairDesignInputParams.Gear.Teeth;
            // var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            // var d1 = z1 * m / Math.Cos(beta);
            // var d2 = z2 * m / Math.Cos(beta);
            // var da1 = d1 + 2 * ha1;
            // var da2 = d2 - 2 * ha2;
            // var h = 2.25 * m;
            // var df1 = da1 - 2 * h;
            // var df2 = da2 + 2 * h;
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