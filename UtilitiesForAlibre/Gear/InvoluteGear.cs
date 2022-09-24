using System;

namespace Bolsover.Gear
{
    public class InvoluteGear
    {
        private double modulem; // normal module
        private double teethz; // teeth
        private double pressureAnglealpha; //pressure angle in degrees
        private double helixAnglebeta; // helix angle in degrees
        private double rootFilletFactorrf; // root fillet factor 
        private double addendumFilletFactorra; // tip (addendum) fillet factor 
        private double profileShiftx; // profile shift

        protected InvoluteGear()
        {
        }

        public InvoluteGear(double modulem, int teethz, double pressureAnglealpha, double helixAnglebeta, double profileShiftx)
        {
            this.modulem = modulem;
            this.teethz = teethz;
            this.pressureAnglealpha = pressureAnglealpha;
            this.helixAnglebeta = helixAnglebeta;
            this.profileShiftx = profileShiftx;
        }


        public event EventHandler Updated;

        public void Update()
        {
            OnUpdated();
        }

        protected void OnUpdated()
        {
            Updated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets/Sets Normal Module
        /// </summary>
        public double ModeuleM
        {
            get => modulem;
            set
            {
                modulem = value;
                Update();
            }
        }

        /// <summary>
        /// Gets/Sets Tooth count not that this MUST always be an int value but is defined as a double to
        /// make some calculations simpler
        /// </summary>
        public double TeethZ
        {
            get => teethz;
            set
            {
                teethz = value;
                Update();
            }
        }

        /// <summary>
        /// The normal Pressure Angle
        /// </summary>
        public double PressureAngleAlpha
        {
            get => pressureAnglealpha;
            set
            {
                pressureAnglealpha = value;
                Update();
            }
        }

        /// <summary>
        /// The helix angle
        /// </summary>
        public double HelixAngleBeta
        {
            get => helixAnglebeta;
            set
            {
                helixAnglebeta = value;
                Update();
            }
        }

        /// <summary>
        /// The Root fillet factor note that this is specified in terms of normal Module size.
        /// </summary>
        public double RootFilletFactorRf
        {
            get => rootFilletFactorrf;
            set
            {
                rootFilletFactorrf = value;
                Update();
            }
        }

        /// <summary>
        /// The Profile shift 
        /// </summary>
        public double ProfileShiftX
        {
            get => profileShiftx;
            set
            {
                profileShiftx = value;
                //Update();
            }
        }

        public double AddendumFilletFactorRa
        {
            get => addendumFilletFactorra;
            set
            {
                addendumFilletFactorra = value;
                Update();
            }
        }


        public double Alpha1 => Degrees(
            Math.Sqrt(ReferenceDiameterD * ReferenceDiameterD - BaseDiameterDb * BaseDiameterDb) /
            BaseDiameterDb) - AlphaT;

        /// <summary>
        /// The Transverse module size
        /// </summary>
        public double TransverseModuleMt => ModeuleM / Math.Cos(Radians(HelixAngleBeta));

        /// <summary>
        /// The Transverse or helical Pressure Angle
        /// </summary>
        public double AlphaT => Degrees(Math.Atan(Math.Tan(Radians(PressureAngleAlpha)) / Math.Cos(Radians(HelixAngleBeta))));

        public double ReferenceDiameterD => ModeuleM * TeethZ / Math.Cos(Radians(HelixAngleBeta));

        /// <summary>
        /// Base Diameter
        /// </summary>
        /// <returns></returns>
        public double BaseDiameterDb => ReferenceDiameterD * Math.Cos(Radians(AlphaT));

        /// <summary>
        /// Base Radius
        /// </summary>
        public double BaseRadiusRb => BaseDiameterDb / 2;


        /// <summary>
        /// Root Diameter
        /// </summary>
        /// <returns></returns>
        public double RootDiameterDr =>
            ReferenceDiameterD + 2 * ModeuleM * (-1.25 + ProfileShiftX);


        public double AxialPitch =>
            TransverseModuleMt / Math.Cos(Point.Radians(HelixAngleBeta)) * Math.PI / Math.Tan(Point.Radians(HelixAngleBeta));


        public double HelixPitchLength => AxialPitch * TeethZ;

        public double ProfileShiftWithoutUndercutX =>
            1 - TeethZ / 2 * Math.Pow(Math.Sin(Point.Radians(PressureAngleAlpha)), 2);


        /// <summary>
        /// Involute function for standard pressure angle
        /// </summary>
        public double InvAlpha => Math.Tan(Radians(AlphaT)) - Radians(AlphaT);

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