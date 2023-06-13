using System.Text;
using AlibreX;

namespace Bolsover
{
    public class CycloidalGearProperties
    {
        #region Initial Parameters

        private IADDesignPlane _plane;
        private double _module = 4.0D;
        private int _wheelCount = 30;
        private int _pinionCount = 8;
        private double _wheelCentreHole = 6.0D;
        private double _pinionCentreHole = 3.0D;
        private double _customSlop = 0.0D;
        private bool _customSlopEnabled = false;
        private bool _drawWheel = true;
        private bool _drawPinion = true;

        #endregion

        #region Calculated Parameters

        private double _wheelAddFactor = 0.0D;
        private double _practicalWheelAddendumFactor = 0.0D;
        private double _pinionAddFactor = 0.0D;
        private double _practicalPinionAddendumFactor = 0.0D;
        private double _gearRatio = 0.0D;
        private double _wheelCircularPitch = 0.0D;
        private double _wheelDedendum = 0.0D;
        private double _pinionDedendum = 0.0D;
        private double _wheelPitchDiameter = 0.0D;
        private double _pinionPitchDiameter = 0.0D;
        private double _wheelAddendum = 0.0D;
        private double _pinionAddendum = 0.0D;
        private double _wheelAddendumRadius = 0.0D;
        private double _pinionAddendumRadius = 0.0D;
        private double _pinionHalfToothAngle = 0.0D;

        #endregion

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("plane: ");
            stringBuilder.Append(_plane.Name);
            stringBuilder.Append("\nmodule: ");
            stringBuilder.Append(_module);
            stringBuilder.Append("\nwheelCount: ");
            stringBuilder.Append(_wheelCount);
            stringBuilder.Append("\npinionCount: ");
            stringBuilder.Append(_pinionCount);
            stringBuilder.Append("\nwheelCentreHole: ");
            stringBuilder.Append(_wheelCentreHole);
            stringBuilder.Append("\npinionCentreHole: ");
            stringBuilder.Append(_pinionCentreHole);
            stringBuilder.Append("\ncustomSlop: ");
            stringBuilder.Append(_customSlop);
            stringBuilder.Append("\ncustomSlopEnabled: ");
            stringBuilder.Append(_customSlopEnabled);
            stringBuilder.Append("\ndrawWheel: ");
            stringBuilder.Append(_drawWheel);
            stringBuilder.Append("\ndrawPinion: ");
            stringBuilder.Append(_drawPinion);
            stringBuilder.Append("\nwheelAddFactor: ");
            stringBuilder.Append(_wheelAddFactor);
            stringBuilder.Append("\npracticalWheelAddendumFactor: ");
            stringBuilder.Append(_practicalWheelAddendumFactor);
            stringBuilder.Append("\npinionAddFactor: ");
            stringBuilder.Append(_pinionAddFactor);
            stringBuilder.Append("\ngearRatio: ");
            stringBuilder.Append(_gearRatio);
            stringBuilder.Append("\nwheelCircularPitch: ");
            stringBuilder.Append(_wheelCircularPitch);
            stringBuilder.Append("\nwheelDedendum: ");
            stringBuilder.Append(_wheelDedendum);
            stringBuilder.Append("\nwheelPitchDiameter: ");
            stringBuilder.Append(_wheelPitchDiameter);
            stringBuilder.Append("\npinionPitchDiameter: ");
            stringBuilder.Append(_pinionPitchDiameter);
            stringBuilder.Append("\nwheelAddendum: ");
            stringBuilder.Append(_wheelAddendum);
            stringBuilder.Append("\npinionAddendum: ");
            stringBuilder.Append(_pinionAddendum);
            stringBuilder.Append("\nwheelAddendumRadius: ");
            stringBuilder.Append(_wheelAddendumRadius);
            stringBuilder.Append("\npinionAddendumRadius: ");
            stringBuilder.Append(_pinionAddendumRadius);
            stringBuilder.Append("\npinionHalfToothAngle: ");
            stringBuilder.Append(_pinionHalfToothAngle);

            return stringBuilder.ToString();
        }

        #region Getters and Setters

        public double WheelAddFactor
        {
            get => _wheelAddFactor;
            set => _wheelAddFactor = value;
        }

        public double PracticalWheelAddendumFactor
        {
            get => _practicalWheelAddendumFactor;
            set => _practicalWheelAddendumFactor = value;
        }

        public double PinionAddFactor
        {
            get => _pinionAddFactor;
            set => _pinionAddFactor = value;
        }

        public double PracticalPinionAddendumFactor
        {
            get => _practicalPinionAddendumFactor;
            set => _practicalPinionAddendumFactor = value;
        }

        public double GearRatio
        {
            get => _gearRatio;
            set => _gearRatio = value;
        }

        public double WheelCircularPitch
        {
            get => _wheelCircularPitch;
            set => _wheelCircularPitch = value;
        }

        public double WheelDedendum
        {
            get => _wheelDedendum;
            set => _wheelDedendum = value;
        }

        public double PinionDedendum
        {
            get => _pinionDedendum;
            set => _pinionDedendum = value;
        }

        public double WheelPitchDiameter
        {
            get => _wheelPitchDiameter;
            set => _wheelPitchDiameter = value;
        }

        public double PinionPitchDiameter
        {
            get => _pinionPitchDiameter;
            set => _pinionPitchDiameter = value;
        }

        public double WheelAddendum
        {
            get => _wheelAddendum;
            set => _wheelAddendum = value;
        }

        public double PinionAddendum
        {
            get => _pinionAddendum;
            set => _pinionAddendum = value;
        }

        public double WheelAddendumRadius
        {
            get => _wheelAddendumRadius;
            set => _wheelAddendumRadius = value;
        }

        public double PinionAddendumRadius
        {
            get => _pinionAddendumRadius;
            set => _pinionAddendumRadius = value;
        }

        public double PinionHalfToothAngle
        {
            get => _pinionHalfToothAngle;
            set => _pinionHalfToothAngle = value;
        }

        public IADDesignPlane Plane
        {
            get => _plane;
            set => _plane = value;
        }

        public double Module
        {
            get => _module;
            set => _module = value;
        }

        public int WheelCount
        {
            get => _wheelCount;
            set => _wheelCount = value;
        }

        public int PinionCount
        {
            get => _pinionCount;
            set => _pinionCount = value;
        }

        public double WheelCentreHole
        {
            get => _wheelCentreHole;
            set => _wheelCentreHole = value;
        }

        public double PinionCentreHole
        {
            get => _pinionCentreHole;
            set => _pinionCentreHole = value;
        }

        public double CustomSlop
        {
            get => _customSlop;
            set => _customSlop = value;
        }

        public bool CustomSlopEnabled
        {
            get => _customSlopEnabled;
            set => _customSlopEnabled = value;
        }

        public bool DrawWheel
        {
            get => _drawWheel;
            set => _drawWheel = value;
        }

        public bool DrawPinion
        {
            get => _drawPinion;
            set => _drawPinion = value;
        }

        #endregion
    }
}