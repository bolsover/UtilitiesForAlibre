using System;
using System.Text;
using Bolsover.Involute.Model;
using static Bolsover.Utils.ConversionUtils;

namespace Bolsover.Involute.Calculator
{
    public class ProfileShiftedExternalSpurGearCalculator : IGearCalculator
    {
        public IGearPairDesignInputParams DesignInputParams;
        public IGearPairDesignOutputParams DesignOutputParams;
        public event EventHandler OnGearPairOutputParamsUpdated;

        public ProfileShiftedExternalSpurGearCalculator(IGearPairDesignInputParams designInputParams, IGearPairDesignOutputParams designOutputParams)
        {
            DesignInputParams = designInputParams;
            DesignOutputParams = designOutputParams;
            // DesignOutputParams.GearPairDesignInputParams = designInputParams;
            SetupEventListeners();
        }

        private void SetupEventListeners()
        {
            DesignInputParams.PropertyChanged += (sender, args) => Calculate();
        }

        /// <summary>
        /// Calculates the gear design parameters from the design inputs.
        /// </summary>
        public void Calculate()
        {
            DesignOutputParams.Reset();
            
            
            
            var gearOut = DesignOutputParams.GearDesignOutput;
            var pinionOut = DesignOutputParams.PinionDesignOutput;
            
            var tipReliefRadius = CalculateTipReliefRadius(DesignInputParams); // Tip Relief Radius
            gearOut.TipReliefRadius = tipReliefRadius.Item2; // Tip Relief Radius
            pinionOut.TipReliefRadius = tipReliefRadius.Item1; // Tip Relief Radius
            
            var rootReliefDiameter = CalculateRootReliefDiameter(DesignInputParams); // Root Relief Diameter
            gearOut.RootFilletDiameter = rootReliefDiameter.Item2; // Root Relief Diameter
            pinionOut.RootFilletDiameter = rootReliefDiameter.Item1; // Root Relief Diameter
            
            var rootReliefRadius = CalculateRootReliefRadius(DesignInputParams); // Root Relief Radius
            gearOut.RootFilletRadius = rootReliefRadius.Item2; // Root Relief Radius
            pinionOut.RootFilletRadius = rootReliefRadius.Item1; // Root Relief Radius
            

            var kappa = CalculateKappa(DesignInputParams); // Kappa
            gearOut.Kappa = kappa.Item2; // Kappa
            pinionOut.Kappa = kappa.Item1; // Kappa

            var theta = CalculateTheta(DesignInputParams); // Theta
            gearOut.Theta = theta.Item2; // Theta
            pinionOut.Theta = theta.Item1; // Theta

            var phi = CalculatePhi(DesignInputParams); // Phi
            gearOut.Phi = phi.Item2; // Phi
            pinionOut.Phi = phi.Item1; // Phi

            var xMod = CalculateProfileShiftModificationForBacklash(DesignInputParams); // Profile Shift Modification for Backlash
            gearOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash
            pinionOut.BacklashAdjustmentFactorXMod = xMod; // Profile Shift Modification for Backlash

            var sumX = CalculateSumCoefficientOfProfileShift(DesignInputParams);
            gearOut.SumCoefficientOfProfileShift = sumX; // Sum of Coefficient of Profile Shift
            pinionOut.SumCoefficientOfProfileShift = sumX; // Sum of Coefficient of Profile Shift

            var a = CalculateCentreDistance(DesignInputParams); //Centre Distance (standard)
            gearOut.CentreDistance = a; //Centre Distance (standard)
            pinionOut.CentreDistance = a; //Centre Distance (standard)

            var y = CalculateCentreDistanceIncrementFactor(DesignInputParams); // Centre Distance Increment Factor
            gearOut.CentreDistanceIncrementFactor = y; // Centre Distance Increment Factor
            pinionOut.CentreDistanceIncrementFactor = y; // Centre Distance Increment Factor

            var invAlpha = CalculateInvoluteFunction(DesignInputParams); // Involute Function 
            gearOut.InvoluteFunction = invAlpha.Item2; // Involute Function of Gear
            pinionOut.InvoluteFunction = invAlpha.Item1; // Involute Function of Pinion

            var alphaW = CalculateWorkingPressureAngle(DesignInputParams); // Working Pressure Angle
            gearOut.WorkingPressureAngle = alphaW; // Working Pressure Angle of Gear
            pinionOut.WorkingPressureAngle = alphaW; // Working Pressure Angle of Pinion

            var invAlphaW = CalculateWorkingInvoluteFunction(DesignInputParams); // Working Involute Function
            gearOut.WorkingInvoluteFunction = invAlphaW; // Working Involute Function of Gear
            pinionOut.WorkingInvoluteFunction = invAlphaW; // Working Involute Function of Pinion     

            var epsilonAlpha = CalculateContactRatioAlpha(DesignInputParams); // Contact Ratio
            gearOut.ContactRatioAlpha = epsilonAlpha; // Contact Ratio
            pinionOut.ContactRatioAlpha = epsilonAlpha; // Contact Ratio

            var epsilonBeta = 0d; // Axial Contact Ratio not relevant for spur gears
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


            //      OnGearPairOutputParamsUpdated?.Invoke(this, EventArgs.Empty);
        }

        public (double, double)  CalculateTipReliefRadius(IGearPairDesignInputParams designInputParams)
        {
            var radius = designInputParams.Gear.AddendumFilletFactor * designInputParams.Gear.Module;
            return (radius, radius);           
        }
        
        public (double, double)  CalculateRootReliefDiameter(IGearPairDesignInputParams designInputParams)
        {
            var diameter = designInputParams.Gear.RootFilletFactor * designInputParams.Gear.Module ;
            return (diameter, diameter);         
        }
        
        public (double, double)  CalculateRootReliefRadius(IGearPairDesignInputParams designInputParams)
        {
            var radius = designInputParams.Gear.RootFilletFactor * designInputParams.Gear.Module /2 ;
            return (radius, radius);         
        }

        public (double, double) CalculateOuterRingDiameter(IGearPairDesignInputParams designInputParams)
        {
            throw new NotImplementedException();
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
            var y = ax / m - (z1 + z2) / 2; // Centre Distance Increment Factor
            var alphaW = Math.Acos((z1 + z2) * Math.Cos(alpha) / (2 * y + z1 + z2)); // Working Pressure Angle in radians
            var num1 = jt / (2 * m * Math.Tan(alpha));
            var num2 = Math.Cos(alphaW) / Math.Cos(alpha);
            var xMod = -(num1 * num2);
            return xMod;
        }

        #region Positive Shifted External Gear Calculations

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
            sb.AppendLine("Item ".PadRight(41) + "Metric".PadRight(21) + "Imperial");
            sb.AppendLine("Module".PadRight(41) + pinionIn.Module.ToString("0.000").PadRight(21) +
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
            AppendLineWithDegFormat(sb, "Phi: ", pinionOut.Phi);
            AppendLineWithDegFormat(sb, "Theta: ", pinionOut.Theta);
            AppendLineWithDegFormat(sb, "Kappa: ", pinionOut.Kappa);

            sb.AppendLine();
            sb.AppendLine("Gear");
            sb.AppendLine("Gear Type: " + gearIn.Style.ToString());
            sb.AppendLine("Item ".PadRight(41) + "Metric".PadRight(21) + "Imperial");
            sb.AppendLine("Module".PadRight(41) + gearIn.Module.ToString("0.000").PadRight(21) +
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
            AppendLineWithDegFormat(sb, "Phi: ", gearOut.Phi);
            AppendLineWithDegFormat(sb, "Theta: ", gearOut.Theta);
            AppendLineWithDegFormat(sb, "Kappa: ", gearOut.Kappa);

            sb.AppendLine();
            sb.AppendLine("Gear Pair");
            AppendLineWithMmInFormat(sb, "Working Centre Distance: ", pairDesignInputParams.WorkingCentreDistance, 25.4);
            AppendLineWithMmInFormat(sb, "Standard Centre Distance: ", gearOut.CentreDistance, 25.4);
            AppendLineWithDefaultFormat(sb, "Centre Distance Increment Factor: ", gearOut.CentreDistanceIncrementFactor);
            AppendLineWithDefaultFormat(sb, "Sum Coefficient Of Profile Shift: ", gearOut.SumCoefficientOfProfileShift);
            AppendLineWithDefaultFormat(sb, "Circular Backlash Required: ", gearIn.CircularBacklash);
            AppendLineWithDefaultFormat(sb, "Backlash Adjustment Factor: ", gearOut.BacklashAdjustmentFactorXMod);
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
        /// Calculates the sum of the coefficient of profile shift.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>The sum of the coefficient of profile shift.</returns>
        public double CalculateSumCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var alpha = pairDesignInputParams.Gear.PressureAngle; // Pressure Angle
            var alphaW = Degrees(Math.Acos((z1 + z2) * Math.Cos(Radians(alpha)) / (2 * y + z1 + z2))); // Working Pressure Angle in degrees
            var invAlphaW = Math.Tan(Radians(alphaW)) - Radians(alphaW); // Working Involute Function  
            var invAlpha = Math.Tan(Radians(alpha)) - Radians(alpha); // Involute Function
            var x1x2 = (z1 + z2) * (invAlphaW - invAlpha) / (2 * Math.Tan(Radians(alpha))); // Sum of Coefficient of Profile Shift
            return x1x2;
        }

        public double CalculateDifferenceCoefficientOfProfileShift(IGearPairDesignInputParams pairDesignInputParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the working pitch diameter of the gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>returns a tuple of double values representing the pinion (1st) and gear (2nd) working pitch diameters</returns>
        public (double, double) CalculateWorkingPitchDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var alpha = pairDesignInputParams.Gear.PressureAngle; // Pressure Angle
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var alphaW = Math.Acos(((z1 + z2) * Math.Cos(Radians(alpha))) / ((2 * y) + z1 + z2)); // Working Pressure Angle in radians
            var db1 = z1 * m * Math.Cos(Radians(alpha)); // Base Diameter of Pinion
            var db2 = z2 * m * Math.Cos(Radians(alpha)); // Base Diameter of Gear
            var dw1 = db1 / Math.Cos(alphaW); // Working Pitch Diameter of Pinion
            var dw2 = db2 / Math.Cos(alphaW); // Working Pitch Diameter of Gear
            return (dw1, dw2);
        }

        /// <summary>
        /// Calculates the centre distance of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>The centre distance of the gear pair.</returns>
        public double CalculateCentreDistance(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var a = (z1 + z2) / 2 * m;
            return a;
        }

        /// <summary>
        /// Calculates the working pressure angle of the gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns>Working pressure angle in degrees</returns>
        public double CalculateWorkingPressureAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var alpha = pairDesignInputParams.Gear.PressureAngle; // Pressure Angle
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var alphaW = Degrees(Math.Acos(((z1 + z2) * Math.Cos(Radians(alpha))) / ((2 * y) + z1 + z2))); // Working Pressure Angle in degrees
            return alphaW;
        }

        /// <summary>
        /// Calculates the whole depth of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>The whole depth of the gear pair.</returns>
        public double CalculateWholeDepth(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var h = (2.25 + y - (x1 + x2)) * m; // Whole Depth
            return h;
        }

        /// <summary>
        /// Calculates the centre distance increment factor of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>The centre distance increment factor of the gear pair.</returns>
        public double CalculateCentreDistanceIncrementFactor(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            return y;
        }

        /// <summary>
        /// Calculates the working involute function of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>The working involute function of the gear pair.</returns>
        public double CalculateWorkingInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var alpha = pairDesignInputParams.Gear.PressureAngle; // Pressure Angle
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var alphaW = Degrees(Math.Acos(((z1 + z2) * Math.Cos(Radians(alpha))) / ((2 * y) + z1 + z2))); // Working Pressure Angle in degrees
            var invAlphaW = Math.Tan(Radians(alphaW)) - Radians(alphaW); // Involute Function
            return invAlphaW;
        }

        /// <summary>
        /// Calculates the involute function of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>The involute function of the gear pair.</returns>
        public (double, double) CalculateInvoluteFunction(IGearPairDesignInputParams pairDesignInputParams)
        {
            var alpha = pairDesignInputParams.Gear.PressureAngle; // Pressure Angle
            var invAlpha = Math.Tan(Radians(alpha)) - Radians(alpha); // Involute Function
            return (invAlpha, invAlpha);
        }

        /// <summary>
        /// Calculates the dedendum of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>A tuple containing the dedendum of the pinion (1st item) and the dedendum of the gear (2nd item).</returns>
        public (double, double) CalculateDedendum(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var h = (2.25 + y - (x1 + x2)) * m; // Whole Depth
            var ha1 = (1 + y - x2) * m; // Addendum of Pinion
            var ha2 = (1 + y - x1) * m; // Addendum of Gear

            var hf1 = h - ha1; // Dedendum of Pinion
            var hf2 = h - ha2; // Dedendum of Gear

            return (hf1, hf2);
        }

        /// <summary>
        /// Calculates the addedendum of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>A tuple containing the addedendum of the pinion (1st item) and the dedendum of the gear (2nd item).</returns>
        public (double, double) CalculateAddendum(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var ha1 = (1 + y - x2) * m; // Addendum of Pinion
            var ha2 = (1 + y - x1) * m; // Addendum of Gear
            return (ha1, ha2);
        }

        /// <summary>
        /// Calculates the root diameters of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>A tuple containing the root diameters of the pinion (1st item) and the dedendum of the gear (2nd item).</returns>
        public (double, double) CalculateRootDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var d1 = z1 * m; // Pitch Diameter of Pinion
            var d2 = z2 * m; // Pitch Diameter of Gear
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var ha1 = (1 + y - x2) * m; // Addendum of Pinion
            var ha2 = (1 + y - x1) * m; // Addendum of Gear

            var da1 = d1 + (2 * ha1); // Outside Diameter of Pinion
            var da2 = d2 + (2 * ha2); // Outside Diameter of Gear

            var h = (2.25 + y - (x1 + x2)) * m; // Whole Depth

            var df1 = da1 - (2 * h); // Root Diameter of Pinion
            var df2 = da2 - (2 * h); // Root Diameter of Gear

            return (df1, df2);
        }

        /// <summary>
        /// Calculates the outside diameters of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>A tuple containing the outside diameters of the pinion (1st item) and the dedendum of the gear (2nd item).</returns>
        public (double, double) CalculateOutsideDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var d1 = z1 * m; // Pitch Diameter of Pinion
            var d2 = z2 * m; // Pitch Diameter of Gear
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var ha1 = (1 + y - x2) * m; // Addendum of Pinion
            var ha2 = (1 + y - x1) * m; // Addendum of Gear

            var da1 = d1 + (2 * ha1); // Outside Diameter of Pinion
            var da2 = d2 + (2 * ha2); // Outside Diameter of Gear

            return (da1, da2);
        }

        /// <summary>
        /// Calculates the base diameters of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>A tuple containing the base diameters of the pinion (1st item) and the dedendum of the gear (2nd item).</returns>
        public (double, double) CalculateBaseDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var d1 = z1 * m;
            var d2 = z2 * m;
            var alpha = pairDesignInputParams.Gear.PressureAngle; // Pressure Angle

            var db1 = d1 * Math.Cos(Radians(alpha)); // Base Diameter of Pinion
            var db2 = d2 * Math.Cos(Radians(alpha)); // Base Diameter of Gear

            return (db1, db2);
        }

        /// <summary>
        /// Calculates the pitch diameters of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>A tuple containing the pitch diameters of the pinion (1st item) and the dedendum of the gear (2nd item).</returns>
        public (double, double) CalculatePitchDiameter(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var d1 = z1 * m;
            var d2 = z2 * m;
            return (d1, d2);
        }

        /// <summary>
        /// Calculates the contact ratio of a gear pair.
        /// </summary>
        /// <param name="pairDesignInputParams">The input parameters of the gear pair.</param>
        /// <returns>The contact ratio of the gear pair.</returns>
        public double CalculateContactRatioAlpha(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module; // Module
            var z2 = pairDesignInputParams.Gear.Teeth; // Teeth
            var z1 = pairDesignInputParams.Pinion.Teeth; // Teeth
            var d1 = z1 * m; // Pitch Diameter of Pinion
            var d2 = z2 * m; // Pitch Diameter of Gear
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle); // Pressure Angle radians

            var db1 = d1 * Math.Cos(alpha); // Base Diameter of Pinion
            var db2 = d2 * Math.Cos(alpha); // Base Diameter of Gear
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift; // Coefficient of Profile Shift of Pinion
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift; // Coefficient of Profile Shift of Gear
            var ha1 = (1 + y - x2) * m; // Addendum of Pinion
            var ha2 = (1 + y - x1) * m; // Addendum of Gear
            var alphaW = Math.Acos(((z1 + z2) * Math.Cos(alpha)) / ((2 * y) + z1 + z2)); // Working Pressure Angle in radians

            var da1 = d1 + (2 * ha1); // Outside Diameter of Pinion
            var da2 = d2 + (2 * ha2); // Outside Diameter of Gear

            var num1 = Math.Sqrt(Math.Pow(da1 / 2, 2) - Math.Pow(db1 / 2, 2));
            var num2 = Math.Sqrt(Math.Pow(da2 / 2, 2) - Math.Pow(db2 / 2, 2));
            var num3 = ax * Math.Sin(alphaW);
            var num4 = Math.PI * m * Math.Cos(alpha);
            var epsilon = (num1 + num2 - num3) / num4;
            return epsilon;
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
            var m = pairDesignInputParams.Gear.Module;
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var d1 = z1 * m;
            var d2 = z2 * m;
            var db1 = d1 * Math.Cos(alpha);
            var db2 = d2 * Math.Cos(alpha);
            var phi1 = Math.Sqrt(Math.Pow(d1, 2) - Math.Pow(db1, 2)) / db1 * 180 / Math.PI - Degrees(alpha);
            var phi2 = Math.Sqrt(Math.Pow(d2, 2) - Math.Pow(db2, 2)) / db2 * 180 / Math.PI - Degrees(alpha);

            return (phi1, phi2);
        }

        /// <summary>
        /// Half Tooth Angle At Reference Diameter (Pitch circle) with allowance for backlash and profile shift
        /// </summary>
        /// <param name="pairDesignInputParams"></param>
        /// <returns></returns>
        public (double, double) CalculateTheta(IGearPairDesignInputParams pairDesignInputParams)
        {
            // 90 / gear.TeethZ + 360 * (gear.ProfileShiftX + XMod(gear)) *
            //     Math.Tan(Radians(AlphaT(gear))) /
            //     (Math.PI * gear.TeethZ);

            var m = pairDesignInputParams.Gear.Module;
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
        
          
           
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;

            var jt = pairDesignInputParams.Gear.CircularBacklash; // Circular Backlash required j_t
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var alphaW = Math.Acos(((z1 + z2) * Math.Cos(alpha)) / ((2 * y) + z1 + z2)); // Working Pressure Angle in radians
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
        /// <param name="g"></param>
        /// <returns>A tuple containing calculated values for pinion (item1) and gear (item2)</returns>
        public (double, double) CalculateKappa(IGearPairDesignInputParams pairDesignInputParams)
        {
            var m = pairDesignInputParams.Gear.Module;
            var alpha = Radians(pairDesignInputParams.Gear.PressureAngle);
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            var d1 = z1 * m;
            var d2 = z2 * m;
            var db1 = d1 * Math.Cos(alpha);
            var db2 = d2 * Math.Cos(alpha);
            var phi1 = Math.Sqrt(Math.Pow(d1, 2) - Math.Pow(db1, 2)) / db1 * 180 / Math.PI - Degrees(alpha);
            var phi2 = Math.Sqrt(Math.Pow(d2, 2) - Math.Pow(db2, 2)) / db2 * 180 / Math.PI - Degrees(alpha);
            var x1 = pairDesignInputParams.Pinion.CoefficientOfProfileShift;
            var x2 = pairDesignInputParams.Gear.CoefficientOfProfileShift;

            var jt = pairDesignInputParams.Gear.CircularBacklash; // Circular Backlash required j_t
            var ax = pairDesignInputParams.WorkingCentreDistance; // Working Centre Distance
            var y = (ax / m) - ((z1 + z2) / 2); // Centre Distance Increment Factor
            var alphaW = Math.Acos(((z1 + z2) * Math.Cos(alpha)) / ((2 * y) + z1 + z2)); // Working Pressure Angle in radians
            var num1 = jt / (2 * m * Math.Tan(alpha));
            var num2 = Math.Cos(alphaW) / Math.Cos(alpha);
            var xMod = -(num1 * num2);

            var theta1 = 90 / z1 + 360 * (x1 + xMod) * Math.Tan(alpha) / (Math.PI * z1);
            var theta2 = 90 / z2 + 360 * (x2 + xMod) * Math.Tan(alpha) / (Math.PI * z2);

            var kappa1 = (theta1 + phi1) * 2;
            var kappa2 = (theta2 + phi2) * 2;

            return (kappa1, kappa2);
        }
        
        public (double, double) CalculateHalfToothAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            return (360/(2*z1), 360/(2*z2));
        }
        
        public (double, double) CalculateToothAngle(IGearPairDesignInputParams pairDesignInputParams)
        {
            var z1 = pairDesignInputParams.Pinion.Teeth;
            var z2 = pairDesignInputParams.Gear.Teeth;
            return (360/z1, 360/z2);
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

        #endregion
    }
}