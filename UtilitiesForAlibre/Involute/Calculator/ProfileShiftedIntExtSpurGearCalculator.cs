using System;
using System.Text;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Calculator
{
    public class ProfileShiftedIntExtSpurGearCalculator : IGearCalculator
    {
        public IGearPairDesignInputParams DesignInputParams;
        public IGearPairDesignOutputParams DesignOutputParams;
        public event EventHandler OnGearPairOutputParamsUpdated;

        public ProfileShiftedIntExtSpurGearCalculator(IGearPairDesignInputParams designInputParams, IGearPairDesignOutputParams designOutputParams)
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
        /// Calculates various design output parameters of gears based on the design input parameters.
        /// </summary>
        public void Calculate()
        {
            DesignOutputParams.Reset();
            var gearOut = DesignOutputParams.GearDesignOutput;
            var pinionOut = DesignOutputParams.PinionDesignOutput;
            
            var xMod = CalculateProfileShiftModificationForBacklash(DesignInputParams); // Profile Shift Modification for Backlash
            gearOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash
            pinionOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash
            
            var diffX = CalculateDifferenceCoefficientOfProfileShift(DesignInputParams);
            gearOut.DifferenceCoefficientOfProfileShift = diffX; // Difference of Coefficient of Profile Shift
            pinionOut.DifferenceCoefficientOfProfileShift = diffX; // Difference of Coefficient of Profile Shift

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

            var alphaW = CalculateWorkingPressureAngle(DesignInputParams); // Working Pressure Angle
            gearOut.WorkingPressureAngle = alphaW; // Working Pressure Angle of Gear
            pinionOut.WorkingPressureAngle = alphaW; // Working Pressure Angle of Pinion

            var invAlphaW = CalculateWorkingInvoluteFunction(DesignInputParams); // Working Involute Function
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
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z2 - z1) / 2 ); // Centre distance increment factor
            var alphaW = Math.Acos(((z2 - z1) * Math.Cos(alpha)) / ((2 * y) + z2 - z1)); // Working Pressure Angle in radians
            var num1 = jt / (2 * m * Math.Tan(alpha));
            var num2 = Math.Cos(alphaW) / Math.Cos(alpha);
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
            sb.AppendLine("Item  ".PadRight(41) + "Metric".PadRight(21) + "Imperial");
            sb.AppendLine("Module  ".PadRight(41) + pinionIn.Module.ToString("0.000").PadRight(21) +
                          (25.4 / pinionIn.Module).ToString("0.0000 in DP") + ", " +
                          (Math.PI / (25.4 / pinionIn.Module)).ToString("0.0000 in CP"));

            AppendLineWithDefaultFormat(sb, "Teeth: ", pinionIn.Teeth);
            AppendLineWithDegFormat(sb, "Pressure Angle: ", pinionIn.PressureAngle);
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
            sb.AppendLine("Item  ".PadRight(41) + "Metric".PadRight(21) + "Imperial");
            sb.AppendLine("Module  ".PadRight(41) + gearIn.Module.ToString("0.000").PadRight(21) +
                          (25.4 / gearIn.Module).ToString("0.0000 in DP") + ", " +
                          (Math.PI / (25.4 / gearIn.Module)).ToString("0.0000 in CP"));

            AppendLineWithDefaultFormat(sb, "Teeth: ", gearIn.Teeth);
            AppendLineWithDegFormat(sb, "Pressure Angle: ", gearIn.PressureAngle);
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
            AppendLineWithDefaultFormat(sb, "Involute Function: ", gearOut.InvoluteFunction);
            AppendLineWithDegFormat(sb, "Working Pressure Angle: ", gearOut.WorkingPressureAngle);
            AppendLineWithDefaultFormat(sb, "Working Involute Function: ", gearOut.WorkingInvoluteFunction);
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
        /// Calculates the Difference Coefficient of Profile Shift for a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>The difference coefficient of profile shift.</returns>
        public double CalculateDifferenceCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams)
        {
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working centre distance
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth on gear
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth on pinion
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure angle in radians

            var y = (ax / m) - ((z2 - z1) / 2); // Centre distance increment factor

            var aw = Math.Acos(((z2 - z1) * Math.Cos(alpha)) / ((2 * y) + z2 - z1)); // Working pressure angle radians
            var invAlpha = Math.Tan(alpha) - alpha;
            var invAlphaW = Math.Tan(aw) - aw; // Working involute function
            var diff = ((z2 - z1) * (invAlphaW - invAlpha)) / (2 * Math.Tan(alpha));
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
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working centre distance
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth on gear
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth on pinion
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure angle in radians

            var y = (ax / m) - ((z2 - z1) / 2); // Centre distance increment factor

            var aw = Math.Acos(((z2 - z1) * Math.Cos(alpha)) / ((2 * y) + z2 - z1)); // Working pressure angle radians
            var db1 = z1 * m * Math.Cos(alpha);
            var db2 = z2 * m * Math.Cos(alpha);
            var dw1 = db1 / Math.Cos(aw);
            var dw2 = db2 / Math.Cos(aw);
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
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working centre distance
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth on gear
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth on pinion
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure angle in radians

            var y = (ax / m) - ((z2 - z1) / 2); // Centre distance increment factor

            var aw = Degrees(Math.Acos(((z2 - z1) * Math.Cos(alpha)) / ((2 * y) + z2 - z1))); // Working pressure angle degrees
            return aw;
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

            var y = (ax / m) - ((z2 - z1) / 2);
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
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working centre distance
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth on gear
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth on pinion
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure angle in radians

            var y = (ax / m) - ((z2 - z1) / 2); // Centre distance increment factor

            var aw = Math.Acos(((z2 - z1) * Math.Cos(alpha)) / ((2 * y) + z2 - z1)); // Working pressure angle radians

            var invAw = Math.Tan(aw) - aw; // Working involute function
            return invAw;
        }

        /// <summary>
        /// Calculates the involute function value.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for gear pair design.</param>
        /// <returns>
        /// The involute function value.
        /// </returns>
        public double CalculateInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var invAlpha = Math.Tan(alpha) - alpha;
            return invAlpha;
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
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var ha1 = (1 + x1) * m;
            var ha2 = (1 - x2) * m;
            var hf1 = h - ha1;
            var hf2 = h - ha2;
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
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var m = pairDesignInputParams.Gear.Module;
            var ha1 = (1 + x1) * m;
            var ha2 = (1 - x2) * m;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var d1 = z1 * m;
            var d2 = z2 * m;
            var da1 = d1 + (2 * ha1);
            var da2 = d2 - (2 * ha2);
            var h = 2.25 * m;
            var df1 = da1 - (2 * h);
            var df2 = da2 + (2 * h);
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
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var m = pairDesignInputParams.Gear.Module;
            var ha1 = (1 + x1) * m;
            var ha2 = (1 - x2) * m;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var d1 = z1 * m;
            var d2 = z2 * m;
            var da1 = d1 + (2 * ha1);
            var da2 = d2 - (2 * ha2);
            return (da1, da2);
        }

        /// <summary>
        /// Calculates the base diameter for the pinion and gear in a gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>A tuple containing the base diameter for the pinion and gear.</returns>
        public (double, double) CalculateBaseDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;
            var d1 = z1 * m;
            var d2 = z2 * m;
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var db1 = d1 * Math.Cos(alpha);
            var db2 = d2 * Math.Cos(alpha);
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
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;
            var d1 = z1 * m;
            var d2 = z2 * m;
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var db1 = d1 * Math.Cos(alpha);
            var db2 = d2 * Math.Cos(alpha);
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;
            var ha1 = (1 + x1) * m;
            var ha2 = (1 - x2) * m;
            var da1 = d1 + (2 * ha1);
            var da2 = d2 - (2 * ha2);
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working centre distance
            var y = (ax / m) - ((z2 - z1) / 2); // Centre distance increment factor
            var alphaW = Math.Acos(((z2 - z1) * Math.Cos(alpha)) / ((2 * y) + z2 - z1)); // Working pressure angle radians

            var num1 = Math.Sqrt(Math.Pow(da1 / 2, 2) - Math.Pow(db1 / 2, 2));
            var num2 = Math.Sqrt(Math.Pow(da2 / 2, 2) - Math.Pow(db2 / 2, 2));
            var num3 = ax * Math.Sin(alphaW);
            var num4 = Math.PI * m * Math.Cos(alpha);

            var epsilon_alpha = (num1 - num2 + num3) / num4;


            return epsilon_alpha;
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateContactRatioBeta(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialModule(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialPressureAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new System.NotImplementedException();
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
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialWorkingInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Not applicable to this type of gear
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double CalculateRadialWorkingPressureAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new System.NotImplementedException();
        }
        
        // <summary>
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
    }
}