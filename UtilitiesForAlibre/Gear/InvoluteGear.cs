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
        private bool _isInternal;
        private GearPair _gearPair;


        protected InvoluteGear()
        {
        }

        public InvoluteGear(double modulem, int teethz, double pressureAnglealpha, double helixAnglebeta, double profileShiftx)
        {
            this.modulem = modulem;
            this.teethz = teethz;
            this.pressureAnglealpha = pressureAnglealpha;
            this.helixAnglebeta = helixAnglebeta;
            ProfileShiftX = profileShiftx;
        }


        public bool IsInternal
        {
            get => _isInternal;
            set => _isInternal = value;
        }


        public event EventHandler Updated;

        private void Update()
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
        public double ProfileShiftX { get; set; }

        public double AddendumFilletFactorRa
        {
            get => addendumFilletFactorra;
            set
            {
                addendumFilletFactorra = value;
                Update();
            }
        }

        public GearPair Pair
        {
            get => _gearPair;
            set => _gearPair = value;
        }
    }
}