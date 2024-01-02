using System;
using System.Text;
using Bolsover.Gear.Calculators;

namespace Bolsover.Gear.Models
{
    public class InvoluteGear
    {
        private double _moduleM; // normal module
        private double _teethZ; // teeth
        private double _pressureAngleAlpha; //pressure angle in degrees
        private double _helixAngleBeta; // helix angle in degrees
        private double _rootFilletFactorRf; // root fillet factor 
        private double _addendumFilletFactorRa; // tip (addendum) fillet factor 
        private GearTypeEnum _gearTypeEnum;
        private double _circularBacklashBc; // circular backlash required
        private double _deltaX = 50; // distribution of profile shift X between g1, g2
        private double _workingCentreDistanceAw; //working centre distance
        private double _height = 10; //height of gear in mm


        public InvoluteGear(double moduleM, int teethZ, double pressureAngleAlpha, double helixAngleBeta,
            double profileShiftx)
        {
            _moduleM = moduleM;
            _teethZ = teethZ;
            _pressureAngleAlpha = pressureAngleAlpha;
            _helixAngleBeta = helixAngleBeta;
            ProfileShiftX = profileShiftx;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("**************************************\n");
            sb.Append("Gear Data has been copied to the clipboard..\n");
            sb.Append("**************************************\n");
            sb.Append("Gear 1\n");
            sb.Append("**************************************\n");
            sb.Append("Module " + ModeuleM + "\n");
            sb.Append("Teeth " + TeethZ + "\n");
            sb.Append("Pressure Angle " + PressureAngleAlpha + "\n");
            sb.Append("Helix Angle " + HelixAngleBeta + "\n");
            sb.Append("Reference Diameter D " + GearCalculations.ReferenceDiameterD(this) + "\n");
            sb.Append("Base Diameter Db " + GearCalculations.BaseDiameterDb(this) + "\n");
            sb.Append("Root Diameter Dr " + GearCalculations.RootDiameterDr(this) + "\n");
            sb.Append("Addendum Diameter Da " + GearCalculations.AddendumDiameterDa(this) + "\n");
            sb.Append("ProfileShiftX " + ProfileShiftX + "\n");
            sb.Append("Profile Shift WithoutUndercut X " + GearCalculations.ProfileShiftWithoutUndercutX(this) + "\n");
            sb.Append("Axial Pitch " + GearCalculations.AxialPitch(this) + "\n");
            sb.Append("Helix Pitch Length " + GearCalculations.HelixPitchLength(this) + "\n");
            sb.Append("Helical Pressure Angle " + GearCalculations.AlphaT(this) + "\n");
            sb.Append("Involute Function InvAlpha " + GearCalculations.InvAlpha(this) + "\n");
            sb.Append("Transverse Module Mt " + GearCalculations.TransverseModuleMt(this) + "\n");
            sb.Append("Root Fillet Diameter " + GearCalculations.RootFilletDiameter(this) + "\n");
            sb.Append("Tip Relief Radius " + GearCalculations.AddendumReliefRadiusRa(this) + "\n");

            sb.Append("**************************************\n");
            sb.Append("Gear 2\n");
            sb.Append("**************************************\n");
            sb.Append("Module " + MatingGear.ModeuleM + "\n");
            sb.Append("Teeth " + MatingGear.TeethZ + "\n");
            sb.Append("Pressure Angle " + MatingGear.PressureAngleAlpha + "\n");
            sb.Append("Helix Angle " + MatingGear.HelixAngleBeta + "\n");
            sb.Append("Reference Diameter D " + GearCalculations.ReferenceDiameterD(MatingGear) + "\n");
            sb.Append("Base Diameter Db " + GearCalculations.BaseDiameterDb(MatingGear) + "\n");
            sb.Append("Root Diameter Dr " + GearCalculations.RootDiameterDr(MatingGear) + "\n");
            sb.Append("Addendum Diameter Da " + GearCalculations.AddendumDiameterDa(MatingGear) + "\n");
            sb.Append("ProfileShiftX " + MatingGear.ProfileShiftX + "\n");
            sb.Append("Profile Shift WithoutUndercut X " + GearCalculations.ProfileShiftWithoutUndercutX(MatingGear) + "\n");
            sb.Append("Axial Pitch " + GearCalculations.AxialPitch(MatingGear) + "\n");
            sb.Append("Helix Pitch Length " + GearCalculations.HelixPitchLength(MatingGear) + "\n");
            sb.Append("Helical Pressure Angle " + GearCalculations.AlphaT(MatingGear) + "\n");
            sb.Append("Involute Function InvAlpha " + GearCalculations.InvAlpha(MatingGear) + "\n");
            sb.Append("Transverse Module Mt " + GearCalculations.TransverseModuleMt(MatingGear) + "\n");
            sb.Append("Root Fillet Diameter " + GearCalculations.RootFilletDiameter(MatingGear) + "\n");
            sb.Append("Tip Relief Radius " + GearCalculations.AddendumReliefRadiusRa(MatingGear) + "\n");

            sb.Append("**************************************\n");
            sb.Append("Gear Set\n");
            sb.Append("**************************************\n");
            sb.Append("Standard Centre Distance " + GearCalculations.StandardCentreDistanceA(this) + "\n");
            sb.Append("Operating Centre Distance " + WorkingCentreDistanceAw + "\n");
            sb.Append("Backlash " + CircularBacklashBc + "\n");
            sb.Append("Working Pressure Angle " + GearCalculations.AlphaW(this) + "\n");
            sb.Append("Centre Distance Increment Factor Y " + GearCalculations.CentreDistanceIncrementFactorY(this) +
                      "\n");
            sb.Append("Working Pitch Diameter Dw " + GearCalculations.WorkingPitchDiameterDw(this) + "\n");
            sb.Append("Contact Ratio " + GearCalculations.ContactRatio(this) + "\n");
            return sb.ToString();
        }
        
        /// <summary>
        /// Height.
        /// </summary>
        public double Height
        {
            get => _height;
            set
            {
                _height = value;
              
            }
        }


        /// <summary>
        /// Gear Type.
        /// </summary>
        public GearTypeEnum GearTypeEnum
        {
            get => _gearTypeEnum;
            set
            {
                _gearTypeEnum = value;
                Update();
            }
        }


        public event EventHandler Updated;

        private void Update()
        {
            OnUpdated();
        }

        private void OnUpdated()
        {
            Updated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets/Sets Normal Module
        /// </summary>
        public double ModeuleM
        {
            get => _moduleM;
            set
            {
                _moduleM = value;
                Update();
            }
        }

        /// <summary>
        /// Gets/Sets Tooth count not that this MUST always be an int value but is defined as a double to
        /// make some calculations simpler
        /// </summary>
        public double TeethZ
        {
            get => _teethZ;
            set
            {
                _teethZ = value;
                Update();
            }
        }

        /// <summary>
        /// The normal Pressure Angle
        /// </summary>
        public double PressureAngleAlpha
        {
            get => _pressureAngleAlpha;
            set
            {
                _pressureAngleAlpha = value;
                Update();
            }
        }

        /// <summary>
        /// The helix angle
        /// </summary>
        public double HelixAngleBeta
        {
            get => _helixAngleBeta;
            set
            {
                _helixAngleBeta = value;
                Update();
            }
        }

        /// <summary>
        /// The Root fillet factor note that this is specified in terms of normal Module size.
        /// </summary>
        public double RootFilletFactorRf
        {
            get => _rootFilletFactorRf;
            set
            {
                _rootFilletFactorRf = value;
                Update();
            }
        }

        /// <summary>
        /// The Profile shift 
        /// </summary>
        public double ProfileShiftX { get; set; }

        public double AddendumFilletFactorRa
        {
            get => _addendumFilletFactorRa;
            set
            {
                _addendumFilletFactorRa = value;
                Update();
            }
        }


        public InvoluteGear MatingGear { get; set; }

        public double CircularBacklashBc
        {
            get => _circularBacklashBc;
            set
            {
                _circularBacklashBc = value;
                Update();
            }
        }

        public double DeltaX
        {
            get => _deltaX;
            set
            {
                _deltaX = value;
                Update();
            }
        }

        public double WorkingCentreDistanceAw
        {
            get => _workingCentreDistanceAw;
            set
            {
                _workingCentreDistanceAw = value;
                Update();
            }
        }
    }

    public enum GearTypeEnum
    {
        Internal,
        External
    }
}