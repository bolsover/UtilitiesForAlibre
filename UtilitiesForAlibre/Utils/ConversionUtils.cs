using System;

namespace Bolsover.Utils
{
    public static class ConversionUtils
    {
        /// <summary>
        /// Converts the given angle in Degrees ° to Radians
        /// Uses the formula Radians = Degrees * Pi/180
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double Radians(double angle)
        {
            return angle * (Math.PI / 180.0);
        }

        /// <summary>
        /// Converts the given angle in Radians to Degrees
        /// Uses the formula Degrees = Radians * 180/Pi
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static double Degrees(double radians)
        {
            return radians * (180.0 / Math.PI);
        }
    }
}