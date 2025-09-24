using System;

namespace Bolsover.Utils
{
    public static class ConversionUtils
    {
        public static string ToInchFormat(double mm)
        {
            return ToInches(mm).ToString("0.000 in");
        }
        
        
        public static string ToDegreeFormat(double angle)
        {
            return angle.ToString("0.000°");
        }
        
        public static string ToMmFormat(double mm)
        {
            return mm.ToString("0.000 mm");
        }
        
        
        public static double ToInches(double mm)
        {
            return mm / 25.4;
        }
        
        public static string ToFormat(double d, string format)
        {
            return d.ToString(format);
        }
        
        /// <summary>
        ///     Converts the given angle in Degrees ° to Radians
        ///     Uses the formula Radians = Degrees * Pi/180
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double Radians(double angle)
        {
            return angle * (Math.PI / 180.0);
        }
        
        /// <summary>
        ///     Converts the given angle in Radians to Degrees
        ///     Uses the formula Degrees = Radians * 180/Pi
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static double Degrees(double radians)
        {
            return radians * (180.0 / Math.PI);
        }
        
        /// <summary>
        ///     Converts the given length in millimeters to inches.
        ///     Uses the formula Inches = Millimeters / 25.4.
        /// </summary>
        /// <param name="mm">The length in millimeters to be converted.</param>
        /// <returns>The length in inches.</returns>
        public static double MillimetersToInches(double mm)
        {
            return mm / 25.4;
        }
        
        /// <summary>
        ///     Converts the given length in inches to millimeters.
        ///     Uses the formula Millimeters = Inches * 25.4.
        /// </summary>
        /// <param name="inches">The length in inches to be converted.</param>
        /// <returns>The length in millimeters.</returns>
        public static double InchesToMillimeters(double inches)
        {
            return inches * 25.4;
        }
        
        /// <summary>
        ///     Converts the given module to diametral pitch.
        ///     Uses the formula DiametralPitch = 25.4 / module.
        /// </summary>
        /// <param name="module">The module to be converted.</param>
        /// <returns>The diametral pitch value.</returns>
        public static double ModuleToDiametralPitch(double module)
        {
            return 25.4 / module;
        }
        
        /// <summary>
        ///     Converts the given diametral pitch value to module.
        ///     Uses the formula Module = 25.4 / diametralPitch.
        /// </summary>
        /// <param name="diametralPitch">The diametral pitch value to be converted.</param>
        /// <returns>The module value.</returns>
        public static double DiametralPitchToModule(double diametralPitch)
        {
            return 25.4 / diametralPitch;
        }
        
        /// <summary>
        ///     Converts the given pitch in millimeters to module.
        ///     Uses the formula Module = PitchMillimeters / Pi.
        /// </summary>
        /// <param name="pitchMillimeters">The pitch in millimeters to be converted.</param>
        /// <returns>The module value.</returns>
        public static double PitchMillimetersToModule(double pitchMillimeters)
        {
            return pitchMillimeters / Math.PI;
        }
        
        /// <summary>
        ///     Converts the given module to pitch in inches.
        ///     Uses the formula PitchInches = Pi * module / 25.4.
        /// </summary>
        /// <param name="module">The module to be converted.</param>
        /// <returns>The pitch value in inches.</returns>
        public static double ModuleToPitchInches(double module)
        {
            return Math.PI * module / 25.4;
        }
        
        /// <summary>
        ///     Converts the given pitch in inches to module.
        ///     Uses the formula Module = PitchInches * 25.4 / Pi.
        /// </summary>
        /// <param name="pitchInches">The pitch in inches to be converted.</param>
        /// <returns>The module value.</returns>
        public static double PitchInchesToModule(double pitchInches)
        {
            return pitchInches * 25.4 / Math.PI;
        }
        
        /// <summary>
        ///     Converts the given module to circular pitch.
        ///     Uses the formula CircularPitch = Math.PI * module.
        /// </summary>
        /// <param name="module">The module to be converted.</param>
        /// <returns>The circular pitch value.</returns>
        public static double ModuleToCircularPitch(double module)
        {
            return Math.PI * module;
        }
        
        /// <summary>
        ///     Converts the given worm normal module to axial module based on the given helix angle.
        ///     The formula used is AxialModule = NormalModule / Cos(helixAngle).
        /// </summary>
        /// <param name="normalModule">The normal module value to convert.</param>
        /// <param name="helixAngle">The helix angle in radians.</param>
        /// <returns>The converted axial module value.</returns>
        public static double WormNormalModuleToAxialModule(double normalModule, double helixAngle)
        {
            return normalModule / Math.Cos(helixAngle);
        }
        
        /// <summary>
        ///     Converts the given worm axial module to normal module based on the helix angle
        /// </summary>
        /// <param name="axialModule">The axial module to be converted</param>
        /// <param name="helixAngle">The helix angle in degrees</param>
        /// <returns>The converted normal module</returns>
        public static double WormAxialModuleToNormalModule(double axialModule, double helixAngle)
        {
            return axialModule * Math.Cos(helixAngle);
        }
        
        /// <summary>
        ///     Converts the given worm normal module to radial module.
        ///     The radial module is calculated using the formula: radialModule = normalModule / Sin(helixAngle).
        /// </summary>
        /// <param name="normalModule">The normal module to be converted.</param>
        /// <param name="helixAngle">The helix angle (in radians).</param>
        /// <returns>The calculated radial module.</returns>
        public static double WormNormalModuleToRadialModule(double normalModule, double helixAngle)
        {
            return normalModule / Math.Sin(helixAngle);
        }
        
        /// Converts the given worm radial module to the corresponding normal module.
        /// The formula used is NormalModule = RadialModule * Sin(HelixAngle).
        /// where RadialModule is the radial distance from the axis of the gear to the pitch circle, in millimeters,
        /// and HelixAngle is the angle between the helix and the gear axis, in radians.
        /// </summary>
        /// <param name="radialModule">The radial module of the gear.</param>
        /// <param name="helixAngle">The angle between the helix and the gear axis, in radians.</param>
        /// <returns>The corresponding normal module of the gear.</returns>
        public static double WormRadialModuleToNormalModule(double radialModule, double helixAngle)
        {
            return radialModule * Math.Sin(helixAngle);
        }
        
        /// <summary>
        ///     Converts the given worm radial module to the corresponding axial module.
        ///     The formula used is:
        ///     AxialModule = NormalModuleToAxialModule(RadialModuleToNormalModule(radialModule, helixAngle), helixAngle)
        ///     where RadialModule is the radial distance from the axis of the gear to the pitch circle, in millimeters,
        ///     and HelixAngle is the angle between the helix and the gear axis, in radians.
        /// </summary>
        /// <param name="radialModule">The radial module of the gear.</param>
        /// <param name="helixAngle">The angle between the helix and the gear axis, in radians.</param>
        /// <returns>The corresponding axial module of the gear.</returns>
        public static double WormRadialModuleToAxialModule(double radialModule, double helixAngle)
        {
            var mx = WormNormalModuleToAxialModule(WormRadialModuleToNormalModule(radialModule, helixAngle), helixAngle);
            return mx;
        }
        
        /// <summary>
        ///     Converts the given worm axial module to radial module.
        ///     The radial module is calculated using the formula: radialModule = normalModule / Sin(helixAngle).
        /// </summary>
        /// <param name="axialModule">The axial module to be converted.</param>
        /// <param name="helixAngle">The helix angle (in radians).</param>
        /// <returns>The calculated radial module.</returns>
        public static double WormAxialModuleToRadialModule(double axialModule, double helixAngle)
        {
            var mt = WormNormalModuleToRadialModule(WormAxialModuleToNormalModule(axialModule, helixAngle), helixAngle);
            return mt;
        }
    }
}