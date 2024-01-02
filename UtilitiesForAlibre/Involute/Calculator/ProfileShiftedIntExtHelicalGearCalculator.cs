using System;
using System.Text;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Calculator
{
    public class ProfileShiftedIntExtHelicalGearCalculator : IGearCalculator
    {
        public IGearPairDesignInputParams DesignInputParams;
        public IGearPairDesignOutputParams DesignOutputParams;
        public event EventHandler OnGearPairOutputParamsUpdated;

        public ProfileShiftedIntExtHelicalGearCalculator(IGearPairDesignInputParams designInputParams, IGearPairDesignOutputParams designOutputParams)
        {
            DesignInputParams = designInputParams;
            DesignOutputParams = designOutputParams;
            if (DesignOutputParams.PinionDesignOutput == null)
                DesignOutputParams.PinionDesignOutput = new GearDesignOutputParams();
            if (DesignOutputParams.GearDesignOutput == null)
                DesignOutputParams.GearDesignOutput = new GearDesignOutputParams();
            SetupEventListeners();
        }

        /// <summary>
        /// Calculate all the gear parameters
        /// </summary>
        public void Calculate()
        {
            DesignOutputParams.Reset();
            var gearOut = DesignOutputParams.GearDesignOutput;
            var pinionOut = DesignOutputParams.PinionDesignOutput;
            
            var pX = CalculateAxialPitch(DesignInputParams); // Axial Pitch
            gearOut.AxialPitch = pX.Item2; // Axial Pitch
            pinionOut.AxialPitch = pX.Item1; // Axial Pitch
            
            var xMod = CalculateProfileShiftModificationForBacklash(DesignInputParams); // Profile Shift Modification for Backlash
            gearOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash
            pinionOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash
            
            var diffX = CalculateDifferenceCoefficientOfProfileShift(DesignInputParams);
            gearOut.DifferenceCoefficientOfProfileShift = diffX; // Difference of Coefficient of Profile Shift
            pinionOut.DifferenceCoefficientOfProfileShift = diffX; // Difference of Coefficient of Profile Shift

            var mT = CalculateRadialModule(DesignInputParams); // Radial Module
            gearOut.RadialModule = mT; // Radial Module
            pinionOut.RadialModule = mT; // Radial Module

            var a = CalculateCentreDistance(DesignInputParams); //Centre Distance (standard)
            gearOut.CentreDistance = a; //Centre Distance (standard)
            pinionOut.CentreDistance = a; //Centre Distance (standard)

            var y = CalculateCentreDistanceIncrementFactor(DesignInputParams); // Centre Distance Increment Factor
            gearOut.CentreDistanceIncrementFactor = y; // Centre Distance Increment Factor
            pinionOut.CentreDistanceIncrementFactor = y; // Centre Distance Increment Factor

            var invAlpha = CalculateInvoluteFunction(DesignInputParams); // Involute Function 
            gearOut.InvoluteFunction = invAlpha; // Involute Function of Gear
            pinionOut.InvoluteFunction = invAlpha; // Involute Function of Pinion

            var epsilonAlpha = CalculateContactRatioAlpha(DesignInputParams); // Contact Ratio
            gearOut.ContactRatioAlpha = epsilonAlpha; // Contact Ratio
            pinionOut.ContactRatioAlpha = epsilonAlpha; // Contact Ratio

            var epsilonBeta = CalculateContactRatioBeta(DesignInputParams); // Contact Ratio
            gearOut.ContactRatioBeta = epsilonBeta; // Contact Ratio
            pinionOut.ContactRatioBeta = epsilonBeta; // Contact Ratio

            var h = CalculateWholeDepth(DesignInputParams); // Whole Depth of Pinion and Gear
            pinionOut.WholeDepth = h; // Whole Depth of Pinion
            gearOut.WholeDepth = h; // Whole Depth of Gear

            var dw = CalculateWorkingPitchDiameter(DesignInputParams); // Working Pitch Diameter of Pinion and Gear
            pinionOut.WorkingPitchDiameter = dw.Item1; // Working Pitch Diameter of Pinion
            gearOut.WorkingPitchDiameter = dw.Item2; // Working Pitch Diameter of Gear

            var hf = CalculateDedendum(DesignInputParams); // Dedendum of Pinion and Gear
            pinionOut.Dedendum = hf.Item1; // Dedendum of Pinion
            gearOut.Dedendum = hf.Item2; // Dedendum of Gear

            var ha = CalculateAddendum(DesignInputParams); // Addendum of Pinion and Gear
            pinionOut.Addendum = ha.Item1; // Addendum of Pinion
            gearOut.Addendum = ha.Item2; // Addendum of Gear

            var df = CalculateRootDiameter(DesignInputParams); // Root Diameter of Pinion and Gear
            pinionOut.RootCircleDiameter = df.Item1; // Root Diameter of Pinion
            gearOut.RootCircleDiameter = df.Item2; // Root Diameter of Gear

            var da = CalculateOutsideDiameter(DesignInputParams); // Outside Diameter of Pinion and Gear
            pinionOut.OutsideDiameter = da.Item1; // Outside Diameter of Pinion
            gearOut.OutsideDiameter = da.Item2; // Outside Diameter of Gear

            var db = CalculateBaseDiameter(DesignInputParams); // Base Diameter of Pinion and Gear
            pinionOut.BaseCircleDiameter = db.Item1; // Base Diameter of Pinion
            gearOut.BaseCircleDiameter = db.Item2; // Base Diameter of Gear

            var dp = CalculatePitchDiameter(DesignInputParams); // Pitch Diameter of Pinion and Gear
            pinionOut.PitchCircleDiameter = dp.Item1; // Pitch Diameter of Pinion
            gearOut.PitchCircleDiameter = dp.Item2; // Pitch Diameter of Gear

            var alphaWt = CalculateRadialWorkingPressureAngle(DesignInputParams);
            pinionOut.RadialWorkingPressureAngle = alphaWt;
            gearOut.RadialWorkingPressureAngle = alphaWt;

            var invAlphaWt = CalculateRadialWorkingInvoluteFunction(DesignInputParams);
            pinionOut.RadialWorkingInvoluteFunction = invAlphaWt;
            gearOut.RadialWorkingInvoluteFunction = invAlphaWt;

            var alphaT = CalculateRadialPressureAngle(DesignInputParams);
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
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            var y = (ax / m) - ((z2 - z1) / (2 * Math.Cos(beta))); // Centre distance increment factor
            var alphaT = Math.Atan(Math.Tan(alpha) / Math.Cos(beta));
            var alphaWt = Math.Acos((z2 - z1) * Math.Cos(alphaT) / ((z2 - z1) + ((2 * y) * Math.Cos(beta)))); // Working pressure angle radians
            var num1 = jt / (2 * m * Math.Tan(alphaT));
            var num2 = Math.Cos(alphaWt) / Math.Cos(alphaT);
            var xMod = num1 * num2;
            return -xMod;
        }

        private void SetupEventListeners()
        {
            DesignInputParams.PropertyChanged += (sender, args) => Calculate();
        }

        /// <summary>
        /// Generates a custom string containing the gear design parameters.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <param name="pairDesignOutputParams"></param>
        /// <returns>string containing the gear design parameters</returns>
        public string CalculateGearString(IGearPairDesignInputParams pairDesignInputParams, IGearPairDesignOutputParams pairDesignOutputParams)
        {
            var pinionIn = pairDesignInputParams.Pinion;
            var pinionOut = pairDesignOutputParams.PinionDesignOutput;
            var gearIn = pairDesignInputParams.Gear;
            var gearOut = pairDesignOutputParams.GearDesignOutput;
            StringBuilder sb = new StringBuilder();
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
            // + pairDesignOutputParams.PinionDesignOutput.RadialModule.ToString("F3"));
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

            sb.AppendLine();
            sb.AppendLine("Gear Pair");
            AppendLineWithMmInFormat(sb, "Working Centre Distance: ", pairDesignInputParams.WorkingCentreDistance, 25.4);
            AppendLineWithMmInFormat(sb, "Standard Centre Distance: ", gearOut.CentreDistance, 25.4);
            AppendLineWithDefaultFormat(sb, "Centre Distance Increment Factor: ", gearOut.CentreDistanceIncrementFactor);
            AppendLineWithDefaultFormat(sb, "Diff Coefficient Of Profile Shift: ", gearOut.DifferenceCoefficientOfProfileShift);
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
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculate the difference of the coefficient of profile shift
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>Difference Coefficient Of ProfileShift xDiff</returns>
        public double CalculateDifferenceCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams)
        {
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working centre distance
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth on gear
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth on pinion
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure angle in radians
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            var y = (ax / m) - ((z2 - z1) / (2 * Math.Cos(beta))); // Centre distance increment factor
            var alphaT = Math.Atan(Math.Tan(alpha) / Math.Cos(beta)); //Radial pressure angle radians
            var alphaWt = Math.Acos((z2 - z1) * Math.Cos(alphaT) / ((z2 - z1) + ((2 * y) * Math.Cos(beta))));
            var invAlphaT = Math.Tan(alphaT) - alphaT;
            var invAlphaW = Math.Tan(alphaWt) - alphaWt; // Working involute function
            var diff = ((z2 - z1) * (invAlphaW - invAlphaT)) / (2 * Math.Tan(alphaT));
            return diff;
        }

        /// <summary>
        /// Calculate the working pitch diameter of the pinion and gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>WorkingPitchDiameters of pinion and gear dw</returns>
        public (double, double) CalculateWorkingPitchDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var ax = pairDesignInputParams.WorkingCentreDistance;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var d1 = z1 * m / Math.Cos(Radians(beta));
            var d2 = z2 * m / Math.Cos(Radians(beta));
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var y = (ax / m) - ((z2 - z1) / (2 * Math.Cos(Radians(beta)))); // Centre distance increment factor
            var alphaT = Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta)));
            var db1 = d1 * Math.Cos(alphaT);
            var db2 = d2 * Math.Cos(alphaT);
            var alphaWt = Math.Acos((z2 - z1) * Math.Cos(alphaT) / ((z2 - z1) + ((2 * y) * Math.Cos(Radians(beta))))); // Radial Working pressure angle radians
            var dw1 = db1 / Math.Cos(alphaWt);
            var dw2 = db2 / Math.Cos(alphaWt);
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
            throw new System.NotImplementedException();
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

            var y = (ax / m) - ((z2 - z1) / (2 * Math.Cos(Radians(beta))));
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
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculate the involute function
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>Involute Function</returns>
        public double CalculateInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var invAlpha = Math.Tan(alpha) - alpha;
            return invAlpha;
        }

        /// <summary>
        /// Calcualte the dedendum of the pinion and gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>Dedendum of pinion and gear</returns>
        public (double, double) CalculateDedendum(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var h = 2.25 * m;
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var ha1 = (1 + x1) * m;
            var ha2 = (1 - x2) * m;
            var hf1 = h - ha1;
            var hf2 = h - ha2;
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
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var m = pairDesignInputParams.Gear.Module;
            var ha1 = (1 + x1) * m;
            var ha2 = (1 - x2) * m;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            var d1 = z1 * m / Math.Cos(beta);
            var d2 = z2 * m / Math.Cos(beta);
            var da1 = d1 + (2 * ha1);
            var da2 = d2 - (2 * ha2);
            var h = 2.25 * m;
            var df1 = da1 - (2 * h);
            var df2 = da2 + (2 * h);
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
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var m = pairDesignInputParams.Gear.Module;
            var ha1 = (1 + x1) * m;
            var ha2 = (1 - x2) * m;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            var d1 = z1 * m / Math.Cos(beta);
            var d2 = z2 * m / Math.Cos(beta);
            var da1 = d1 + (2 * ha1);
            var da2 = d2 - (2 * ha2);
            return (da1, da2);
        }

        /// <summary>
        /// Calculates the base diameters of two gears in a gear pair design based on the input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>A tuple containing the base diameter of the pinion (db1) and the base diameter of the gear (db2).</returns>
        public (double, double) CalculateBaseDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var d1 = z1 * m / Math.Cos(Radians(beta));
            var d2 = z2 * m / Math.Cos(Radians(beta));

            var alpha = pairDesignInputParams.Gear.PressureAngle;

            var alphaT = Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta)));
            var db1 = d1 * Math.Cos(alphaT);
            var db2 = d2 * Math.Cos(alphaT);
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
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle); // Helix angle in radians
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure angle in radians
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working centre distance
            var alphaT = Math.Atan(Math.Tan(alpha) / Math.Cos(beta)); // Radial pressure angle radians

            var d1 = z1 * m / Math.Cos(beta); // Pitch diameter of pinion
            var d2 = z2 * m / Math.Cos(beta); // Pitch diameter of gear

            var db1 = d1 * Math.Cos(alphaT); // Base diameter of pinion
            var db2 = d2 * Math.Cos(alphaT); // Base diameter of gear

            var ha1 = (1 + x1) * m; // Addendum of pinion
            var ha2 = (1 - x2) * m; // Addendum of gear
            var da1 = d1 + (2 * ha1); // Outside diameter of pinion
            var da2 = d2 - (2 * ha2); // Outside diameter of gear

            var y = (ax / m) - ((z2 - z1) / (2 * (Math.Cos(beta)))); // Centre distance increment factor
            var alphaWt = Math.Acos((z2 - z1) * Math.Cos(alphaT) / (z2 - z1 + 2 * y * Math.Cos(beta))); // Radial Working pressure angle radians

            var mt = m / Math.Cos(beta); // Transverse (Radial) module

            var num1 = Math.Sqrt(Math.Pow(da1 / 2, 2) - Math.Pow(db1 / 2, 2));
            var num2 = Math.Sqrt(Math.Pow(da2 / 2, 2) - Math.Pow(db2 / 2, 2));
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
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculates the radial working involute function.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
        /// <returns>The calculated radial working involute function.</returns>
        public double CalculateRadialWorkingInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var alphaT = Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta))); //radial pressure angle radians
            var ax = pairDesignInputParams.WorkingCentreDistance;
            var m = pairDesignInputParams.Gear.Module;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var y = (ax / m) - ((z2 - z1) / (2 * Math.Cos(Radians(beta)))); // Centre distance increment factor
            var alphaWt = Math.Acos((z2 - z1) * Math.Cos(alphaT) / ((z2 - z1) + ((2 * y) * Math.Cos(Radians(beta))))); // Working pressure angle radians
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
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var alphaT = Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta))); //radial pressure angle radians
            var ax = pairDesignInputParams.WorkingCentreDistance;
            var m = pairDesignInputParams.Gear.Module;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var y = (ax / m) - ((z2 - z1) / (2 * Math.Cos(Radians(beta)))); // Centre distance increment factor
            var alphaWt = Degrees(Math.Acos((z2 - z1) * Math.Cos(alphaT) / ((z2 - z1) + ((2 * y) * Math.Cos(Radians(beta))))));
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
            var pX = mT/Math.Cos(beta) * Math.PI / Math.Tan(beta);
            
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
            var pX = mT/Math.Cos(beta) * Math.PI / Math.Tan(beta);
            
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            
            var lX1 = pX * z1;
            var lX2 = pX * z2;
            return (lX1, lX2);
        }
    }
}