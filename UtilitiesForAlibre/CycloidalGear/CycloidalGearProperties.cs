using System.Text;
using AlibreX;

namespace Bolsover
{
    public class CycloidalGearProperties
    {
        #region Initial Parameters

        private IADDesignPlane plane;
        private double module = 4.0D;
        private int wheelCount = 30;
        private int pinionCount = 8;
        private double wheelCentreHole = 6.0D;
        private double pinionCentreHole = 3.0D;
        private double customSlop = 0.0D;
        private bool customSlopEnabled = false;
        private bool drawWheel = true;
        private bool drawPinion = true;

        #endregion

        #region Calculated Parameters

        private double wheelAddFactor = 0.0D;
        private double practicalWheelAddendumFactor = 0.0D;
        private double pinionAddFactor = 0.0D;
        private double practicalPinionAddendumFactor = 0.0D;
        private double gearRatio = 0.0D;
        private double wheelCircularPitch = 0.0D;
        private double wheelDedendum = 0.0D;
        private double pinionDedendum = 0.0D;
        private double wheelPitchDiameter = 0.0D;
        private double pinionPitchDiameter = 0.0D;
        private double wheelAddendum = 0.0D;
        private double pinionAddendum = 0.0D;
        private double wheelAddendumRadius = 0.0D;
        private double pinionAddendumRadius = 0.0D;
        private double pinionHalfToothAngle = 0.0D;

        #endregion

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("plane: ");
            stringBuilder.Append(plane.Name);
            stringBuilder.Append("\nmodule: ");
            stringBuilder.Append(module);
            stringBuilder.Append("\nwheelCount: ");
            stringBuilder.Append(wheelCount);
            stringBuilder.Append("\npinionCount: ");
            stringBuilder.Append(pinionCount);
            stringBuilder.Append("\nwheelCentreHole: ");
            stringBuilder.Append(wheelCentreHole);
            stringBuilder.Append("\npinionCentreHole: ");
            stringBuilder.Append(pinionCentreHole);
            stringBuilder.Append("\ncustomSlop: ");
            stringBuilder.Append(customSlop);
            stringBuilder.Append("\ncustomSlopEnabled: ");
            stringBuilder.Append(customSlopEnabled);
            stringBuilder.Append("\ndrawWheel: ");
            stringBuilder.Append(drawWheel);
            stringBuilder.Append("\ndrawPinion: ");
            stringBuilder.Append(drawPinion);
            stringBuilder.Append("\nwheelAddFactor: ");
            stringBuilder.Append(wheelAddFactor);
            stringBuilder.Append("\npracticalWheelAddendumFactor: ");
            stringBuilder.Append(practicalWheelAddendumFactor);
            stringBuilder.Append("\npinionAddFactor: ");
            stringBuilder.Append(pinionAddFactor);
            stringBuilder.Append("\ngearRatio: ");
            stringBuilder.Append(gearRatio);
            stringBuilder.Append("\nwheelCircularPitch: ");
            stringBuilder.Append(wheelCircularPitch);
            stringBuilder.Append("\nwheelDedendum: ");
            stringBuilder.Append(wheelDedendum);
            stringBuilder.Append("\nwheelPitchDiameter: ");
            stringBuilder.Append(wheelPitchDiameter);
            stringBuilder.Append("\npinionPitchDiameter: ");
            stringBuilder.Append(pinionPitchDiameter);
            stringBuilder.Append("\nwheelAddendum: ");
            stringBuilder.Append(wheelAddendum);
            stringBuilder.Append("\npinionAddendum: ");
            stringBuilder.Append(pinionAddendum);
            stringBuilder.Append("\nwheelAddendumRadius: ");
            stringBuilder.Append(wheelAddendumRadius);
            stringBuilder.Append("\npinionAddendumRadius: ");
            stringBuilder.Append(pinionAddendumRadius);
            stringBuilder.Append("\npinionHalfToothAngle: ");
            stringBuilder.Append(pinionHalfToothAngle);

            return stringBuilder.ToString();
        }

        #region Getters and Setters

        public double WheelAddFactor
        {
            get => wheelAddFactor;
            set => wheelAddFactor = value;
        }

        public double PracticalWheelAddendumFactor
        {
            get => practicalWheelAddendumFactor;
            set => practicalWheelAddendumFactor = value;
        }

        public double PinionAddFactor
        {
            get => pinionAddFactor;
            set => pinionAddFactor = value;
        }

        public double PracticalPinionAddendumFactor
        {
            get => practicalPinionAddendumFactor;
            set => practicalPinionAddendumFactor = value;
        }

        public double GearRatio
        {
            get => gearRatio;
            set => gearRatio = value;
        }

        public double WheelCircularPitch
        {
            get => wheelCircularPitch;
            set => wheelCircularPitch = value;
        }

        public double WheelDedendum
        {
            get => wheelDedendum;
            set => wheelDedendum = value;
        }

        public double PinionDedendum
        {
            get => pinionDedendum;
            set => pinionDedendum = value;
        }

        public double WheelPitchDiameter
        {
            get => wheelPitchDiameter;
            set => wheelPitchDiameter = value;
        }

        public double PinionPitchDiameter
        {
            get => pinionPitchDiameter;
            set => pinionPitchDiameter = value;
        }

        public double WheelAddendum
        {
            get => wheelAddendum;
            set => wheelAddendum = value;
        }

        public double PinionAddendum
        {
            get => pinionAddendum;
            set => pinionAddendum = value;
        }

        public double WheelAddendumRadius
        {
            get => wheelAddendumRadius;
            set => wheelAddendumRadius = value;
        }

        public double PinionAddendumRadius
        {
            get => pinionAddendumRadius;
            set => pinionAddendumRadius = value;
        }

        public double PinionHalfToothAngle
        {
            get => pinionHalfToothAngle;
            set => pinionHalfToothAngle = value;
        }

        public IADDesignPlane Plane
        {
            get => plane;
            set => plane = value;
        }

        public double Module
        {
            get => module;
            set => module = value;
        }

        public int WheelCount
        {
            get => wheelCount;
            set => wheelCount = value;
        }

        public int PinionCount
        {
            get => pinionCount;
            set => pinionCount = value;
        }

        public double WheelCentreHole
        {
            get => wheelCentreHole;
            set => wheelCentreHole = value;
        }

        public double PinionCentreHole
        {
            get => pinionCentreHole;
            set => pinionCentreHole = value;
        }

        public double CustomSlop
        {
            get => customSlop;
            set => customSlop = value;
        }

        public bool CustomSlopEnabled
        {
            get => customSlopEnabled;
            set => customSlopEnabled = value;
        }

        public bool DrawWheel
        {
            get => drawWheel;
            set => drawWheel = value;
        }

        public bool DrawPinion
        {
            get => drawPinion;
            set => drawPinion = value;
        }

        #endregion
    }
}