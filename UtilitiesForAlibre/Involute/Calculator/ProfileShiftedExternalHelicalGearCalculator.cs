using System;
using System.Text;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Calculator
{
    public class ProfileShiftedExternalHelicalGearCalculator : IGearCalculator
    {
        public IGearPairDesignInputParams DesignInputParams;
        public IGearPairDesignOutputParams DesignOutputParams;
        public event EventHandler OnGearPairOutputParamsUpdated;

        public ProfileShiftedExternalHelicalGearCalculator(IGearPairDesignInputParams designInputParams, IGearPairDesignOutputParams designOutputParams)
        {
            DesignInputParams = designInputParams;
            DesignOutputParams = designOutputParams;
            if (DesignOutputParams.PinionDesignOutput == null)
                DesignOutputParams.PinionDesignOutput = new GearDesignOutputParams();
            if (DesignOutputParams.GearDesignOutput == null)
                DesignOutputParams.GearDesignOutput = new GearDesignOutputParams();
            SetupEventListeners();
        }

        private void SetupEventListeners()
        {
            DesignInputParams.PropertyChanged += (sender, args) => Calculate();
        }

        /// <summary>
        /// Calculates various design parameters for gear and pinion.
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
            
            var sumX = CalculateSumCoefficientOfProfileShift(DesignInputParams);
            gearOut.SumCoefficientOfProfileShift = sumX; // Sum of Coefficient of Profile Shift
            pinionOut.SumCoefficientOfProfileShift = sumX; // Sum of Coefficient of Profile Shift

            var alphaWt = CalculateRadialWorkingPressureAngle(DesignInputParams);
            gearOut.RadialWorkingPressureAngle = alphaWt; // Radial Pressure Angle
            pinionOut.RadialWorkingPressureAngle = alphaWt; // Radial Pressure Angle

            var invAlphaWt = CalculateRadialWorkingInvoluteFunction(DesignInputParams);
            gearOut.RadialWorkingInvoluteFunction = invAlphaWt; // Radial Involute Function
            pinionOut.RadialWorkingInvoluteFunction = invAlphaWt; // Radial Involute Function

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

            var mt = CalculateRadialModule(DesignInputParams); // Radial Module
            gearOut.RadialModule = mt; // Radial Module
            pinionOut.RadialModule = mt; // Radial Module

            var alphaT = CalculateRadialPressureAngle(DesignInputParams); // Radial Pressure Angle
            gearOut.RadialPressureAngle = alphaT; // Radial Pressure Angle
            pinionOut.RadialPressureAngle = alphaT; // Radial Pressure Angle

            var invAlphaT = CalculateRadialInvoluteFunction(DesignInputParams); // Radial Involute Function
            gearOut.RadialInvoluteFunction = invAlphaT; // Radial Involute Function
            pinionOut.RadialInvoluteFunction = invAlphaT; // Radial Involute Function

            var h = CalculateWholeDepth(DesignInputParams); // Whole Depth of Pinion and Gear
            pinionOut.WholeDepth = h; // Whole Depth of Pinion
            gearOut.WholeDepth = h; // Whole Depth of GearGearDesignOutput

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
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var beta = Radians(pairDesignInputParams.Gear.HelixAngle);
            var alphaT = Math.Atan(Math.Tan(alpha) / Math.Cos(beta));
            var alphaWt = Math.Acos((z2 - z1) * Math.Cos(alphaT) / ((z2 + z1) + ((2 * y) * Math.Cos(beta)))); // Working pressure angle radians
            var num1 = jt / (2 * m * Math.Tan(alphaT));
            var num2 = Math.Cos(alphaWt) / Math.Cos(alphaT);
            var xMod = num1 * num2;
            return -xMod;
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
            AppendLineWithDefaultFormat(sb, "Sum Coefficient Of Profile Shift: ", gearOut.SumCoefficientOfProfileShift);
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
        /// Calculates the sum coefficient of profile shift based on the gear pair design input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>The sum coefficient of profile shift.</returns>
        public double CalculateSumCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var alphaT = Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta))); //radians
            var aX = pairDesignInputParams.WorkingCentreDistance;
            var m = pairDesignInputParams.Gear.Module;
            var y = aX / m - (z1 + z2) / (2 * Math.Cos(Radians(beta)));
            var alphaWt = Math.Acos(((z1 + z2) * Math.Cos(alphaT)) / ((z1 + z2) + (2 * y * Math.Cos(Radians(beta)))));
            var invAlphaWt = Math.Tan(alphaWt) - alphaWt;
            var invAlphaT = Math.Tan(alphaT) - alphaT; // Involute Function
            var x1x2 = ((z1 + z2) * (invAlphaWt - invAlphaT)) / (2 * Math.Tan(Radians(alpha))); // Sum of Coefficient of Profile Shift
            return x1x2;
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
        /// Calculates the working pitch diameter for a given gear pair design.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>
        /// A tuple containing the working pitch diameters for the two gears in the pair.
        /// The first item in the tuple is the working pitch diameter for the pinion gear.
        /// The second item in the tuple is the working pitch diameter for the gear.
        /// </returns>
        public (double, double) CalculateWorkingPitchDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var alphaT = Degrees(Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta))));
            var d1 = z1 * m / Math.Cos(Radians(beta));
            var d2 = z2 * m / Math.Cos(Radians(beta));
            var db1 = d1 * Math.Cos(Radians(alphaT));
            var db2 = d2 * Math.Cos(Radians(alphaT));
            var aX = pairDesignInputParams.WorkingCentreDistance;
            var y = aX / m - (z1 + z2) / (2 * Math.Cos(Radians(beta)));
            var alphaWt = Math.Acos(((z1 + z2) * Math.Cos(Radians(alphaT))) / ((z1 + z2) + (2 * y * Math.Cos(Radians(beta)))));

            var dwt1 = db1 / Math.Cos(alphaWt);
            var dwt2 = db2 / Math.Cos(alphaWt);

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
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculates the whole depth of a gear pair design based on the input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>The whole depth value.</returns>
        public double CalculateWholeDepth(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var ax = pairDesignInputParams.WorkingCentreDistance;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var y = ax / m - (z1 + z2) / (2 * Math.Cos(Radians(beta)));
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
            var a_x = pairDesignInputParams.WorkingCentreDistance;
            var z_1 = pairDesignInputParams.Pinion.Teeth;
            var z_2 = pairDesignInputParams.Gear.Teeth;
            var y = a_x / m - (z_1 + z_2) / (2 * Math.Cos(Radians(beta)));
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
        /// Calculates the involute function for a given set of gear pair design input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The gear pair design input parameters.</param>
        /// <returns>The value of the involute function.</returns>
        public double CalculateInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = pairDesignInputParams.Gear.PressureAngle; // Pressure Angle
            var invAlpha = Math.Tan(Radians(alpha)) - Radians(alpha); // Involute Function
            return invAlpha;
        }

        /// <summary>
        /// Calculate the dedendum values for a gear pair based on the given input parameters.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters for the gear pair design.</param>
        /// <returns>A tuple containing the dedendum values for the pinion and gear.</returns>
        public (double, double) CalculateDedendum(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var beta = pairDesignInputParams.Gear.HelixAngle; // Helix Angle
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = ax / m - (z1 + z2) / (2 * Math.Cos(Radians(beta)));
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
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var beta = pairDesignInputParams.Gear.HelixAngle; // Helix Angle
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = ax / m - (z1 + z2) / (2 * Math.Cos(Radians(beta)));
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
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var beta = pairDesignInputParams.Gear.HelixAngle; // Helix Angle
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = ax / m - (z1 + z2) / (2 * Math.Cos(Radians(beta)));
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var ha1 = (1 + y - x2) * m; // Addendum of Pinion
            var ha2 = (1 + y - x1) * m; // Addendum of Gear
            var d1 = z1 * m / Math.Cos(Radians(beta));
            var d2 = z2 * m / Math.Cos(Radians(beta));
            var da1 = d1 + (2 * ha1);
            var da2 = d2 + (2 * ha2);
            var h = (2.25 + y - (x1 + x2)) * m; // Whole Depth
            var df1 = da1 - (2 * h);
            var df2 = da2 - (2 * h);
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
            var m = pairDesignInputParams.Gear.Module;
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var beta = pairDesignInputParams.Gear.HelixAngle; // Helix Angle
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = ax / m - (z1 + z2) / (2 * Math.Cos(Radians(beta)));
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var ha1 = (1 + y - x2) * m; // Addendum of Pinion
            var ha2 = (1 + y - x1) * m; // Addendum of Gear
            var d1 = z1 * m / Math.Cos(Radians(beta));
            var d2 = z2 * m / Math.Cos(Radians(beta));
            var da1 = d1 + (2 * ha1);
            var da2 = d2 + (2 * ha2);
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
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var m = pairDesignInputParams.Gear.Module;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var alphat = Degrees(Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta))));
            var d1 = z1 * m / Math.Cos(Radians(beta));
            var d2 = z2 * m / Math.Cos(Radians(beta));
            var db1 = d1 * Math.Cos(Radians(alphat));
            var db2 = d2 * Math.Cos(Radians(alphat));
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
            var alpha = pairDesignInputParams.Gear.PressureAngle; // Pressure Angle
            var beta = pairDesignInputParams.Gear.HelixAngle; // Helix Angle
            var alphat = Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta))); //radial pressure angle in radians
            var m = pairDesignInputParams.Gear.Module; // Module
            var mt = m / Math.Cos(Radians(beta)); // Transverse Module
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance;
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear

            var y = ax / m - (z1 + z2) / (2 * Math.Cos(Radians(beta))); // Centre Distance Increment Factor
            var alphaWt = Math.Acos(((z1 + z2) * Math.Cos(alphat)) / ((z1 + z2) + (2 * y * Math.Cos(Radians(beta))))); // Working Pressure Angle in Radians


            var d1 = z1 * m / Math.Cos(Radians(beta)); // Pitch Diameter of Pinion
            var d2 = z2 * m / Math.Cos(Radians(beta)); // Pitch Diameter of Gear
            var db1 = d1 * Math.Cos(alphat); // Base Diameter of Pinion
            var db2 = d2 * Math.Cos(alphat); // Base Diameter of Gear


            var ha1 = (1 + y - x2) * m; // Addendum of Pinion
            var ha2 = (1 + y - x1) * m; // Addendum of Gear

            var da1 = d1 + (2 * ha1); // Outside Diameter of Pinion
            var da2 = d2 + (2 * ha2); // Outside Diameter of Gear

            var num1 = Math.Sqrt(Math.Pow(da1 / 2, 2) - Math.Pow(db1 / 2, 2));
            var num2 = Math.Sqrt(Math.Pow(da2 / 2, 2) - Math.Pow(db2 / 2, 2));
            var num3 = ax * Math.Sin(alphaWt);
            var num4 = Math.PI * mt * Math.Cos(alphat);
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
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var alphaT = Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta))); // this is the radial pressure angle in radians
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
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var alphaT = Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta))); //radians
            var aX = pairDesignInputParams.WorkingCentreDistance;
            var m = pairDesignInputParams.Gear.Module;
            var y = aX / m - (z1 + z2) / (2 * Math.Cos(Radians(beta)));
            var alphaWt = Math.Acos(((z1 + z2) * Math.Cos(alphaT)) / ((z1 + z2) + (2 * y * Math.Cos(Radians(beta)))));
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
            var alpha = pairDesignInputParams.Gear.PressureAngle;
            var beta = pairDesignInputParams.Gear.HelixAngle;
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var alphaT = Math.Atan(Math.Tan(Radians(alpha)) / Math.Cos(Radians(beta))); //radians
            var aX = pairDesignInputParams.WorkingCentreDistance;
            var m = pairDesignInputParams.Gear.Module;
            var y = aX / m - (z1 + z2) / (2 * Math.Cos(Radians(beta)));
            var alphaWt = Degrees(Math.Acos(((z1 + z2) * Math.Cos(alphaT)) / ((z1 + z2) + (2 * y * Math.Cos(Radians(beta))))));
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