using System.Text;
using AlibreX;

namespace Bolsover.CycloidalGear
{
    public class CycloidalGearProperties
    {
       

        private double _pinionAddFactor = 0.0D;
        private double _practicalPinionAddendumFactor = 0.0D;


        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("plane: ");
            stringBuilder.Append(Plane.Name);
            stringBuilder.Append("\nmodule: ");
            stringBuilder.Append(Module);
            stringBuilder.Append("\nwheelCount: ");
            stringBuilder.Append(WheelCount);
            stringBuilder.Append("\npinionCount: ");
            stringBuilder.Append(PinionCount);
            stringBuilder.Append("\nwheelCentreHole: ");
            stringBuilder.Append(WheelCentreHole);
            stringBuilder.Append("\npinionCentreHole: ");
            stringBuilder.Append(PinionCentreHole);
            stringBuilder.Append("\ncustomSlop: ");
            stringBuilder.Append(CustomSlop);
            stringBuilder.Append("\ncustomSlopEnabled: ");
            stringBuilder.Append(CustomSlopEnabled);
            stringBuilder.Append("\ndrawWheel: ");
            stringBuilder.Append(DrawWheel);
            stringBuilder.Append("\ndrawPinion: ");
            stringBuilder.Append(DrawPinion);
            stringBuilder.Append("\nwheelAddFactor: ");
            stringBuilder.Append(WheelAddFactor);
            stringBuilder.Append("\npracticalWheelAddendumFactor: ");
            stringBuilder.Append(PracticalWheelAddendumFactor);
            stringBuilder.Append("\npinionAddFactor: ");
            stringBuilder.Append(_pinionAddFactor);
            stringBuilder.Append("\ngearRatio: ");
            stringBuilder.Append(GearRatio);
            stringBuilder.Append("\nwheelCircularPitch: ");
            stringBuilder.Append(WheelCircularPitch);
            stringBuilder.Append("\nwheelDedendum: ");
            stringBuilder.Append(WheelDedendum);
            stringBuilder.Append("\nwheelPitchDiameter: ");
            stringBuilder.Append(WheelPitchDiameter);
            stringBuilder.Append("\npinionPitchDiameter: ");
            stringBuilder.Append(PinionPitchDiameter);
            stringBuilder.Append("\nwheelAddendum: ");
            stringBuilder.Append(WheelAddendum);
            stringBuilder.Append("\npinionAddendum: ");
            stringBuilder.Append(PinionAddendum);
            stringBuilder.Append("\nwheelAddendumRadius: ");
            stringBuilder.Append(WheelAddendumRadius);
            stringBuilder.Append("\npinionAddendumRadius: ");
            stringBuilder.Append(PinionAddendumRadius);
            stringBuilder.Append("\npinionHalfToothAngle: ");
            stringBuilder.Append(PinionHalfToothAngle);

            return stringBuilder.ToString();
        }

        #region Getters and Setters

        public double WheelAddFactor { get; set; } 

        public double PracticalWheelAddendumFactor { get; set; }

       
        public double GearRatio { get; set; } 

        public double WheelCircularPitch { get; set; }

        public double WheelDedendum { get; set; }

        public double PinionDedendum { get; set; }

        public double WheelPitchDiameter { get; set; }

        public double PinionPitchDiameter { get; set; }

        public double WheelAddendum { get; set; }

        public double PinionAddendum { get; set; } 

        public double WheelAddendumRadius { get; set; } 

        public double PinionAddendumRadius { get; set; }

        public double PinionHalfToothAngle { get; set; } 

        public IADDesignPlane Plane { get; set; }

        public double Module { get; set; } = 4.0D;

        public int WheelCount { get; set; } = 30;

        public int PinionCount { get; set; } = 8;

        public double WheelCentreHole { get; set; } = 6.0D;

        public double PinionCentreHole { get; set; } = 3.0D;

        public double CustomSlop { get; set; } 

        public bool CustomSlopEnabled { get; set; }

        public bool DrawWheel { get; set; } = true;

        public bool DrawPinion { get; set; } = true;

        #endregion
    }
}