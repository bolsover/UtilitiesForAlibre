using System;
using AlibreX;

namespace Bolsover.Involute
{
    public class InvoluteProperties
    {
        private IADDesignPlane plane;

        private IADDesignSession session;

        //pitch/pi = Module is the unit size indicated in millimeter (mm). The value is calculated from dividing the reference pitch by Pi (π)
        private double module;

        //number of teeth on gear.
        private int toothCount = 0;

        //module*pi Reference Pitch is the distance between corresponding points on adjacent teeth. The value is calculated from multiplying Module m by Pi(π).
        private double pitch;

        private double pitchCircleDiameter;

        //degrees std:20, alt:14.5, or 17.5  The angle of a gear tooth leaning against a normal reference line.
        private double pressureAngle;

        //1.0*module The distance between reference line and tooth tip.
        private double addendum;

        //1.25*module The distance between reference line and tooth root.
        private double dedendum;

        //2.25*module The distance between tooth tip and tooth root.
        private double toolDepth;

        //2.0*module Depth of tooth meshed with the mating gear.
        private double workingDepth;

        //0.25*module The distance (clearance) between tooth root and the tooth tip of mating gear.
        private double rootClearance;

        //0.38*module The radius of curvature between tooth surface and the tooth root.
        private double filletRadius;


        private double clearance;

        private double baseCircleDiameter;
        private double addendumCircleDiameter;
        private double dedendumCircleDiameter;
        private double profileShiftFactor;
        private int countInvolutePoints;

        private string[] seriesNames = new[] {"Series 1", "Series 2"};

        private double[] series1module = new[]
        {
            0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.8, 1.0, 1.25, 1.5, 2.0, 2.5, 3.0, 4.0, 5.0, 6.0, 8, 10, 12, 16, 20, 25, 32,
            40, 50
        };

        private double[] series2module = new[]
        {
            0.15, 0.25, 0.35, 0.45, 0.55, 0.7, 0.75, 0.9, 1.125, 1.375, 1.75, 2.25, 2.75, 3.5, 4.5, 5.5, 6.5, 7, 9, 11,
            14, 18, 22, 28, 36, 45
        };


        private double wheelCentreX;
        private double wheelCentreY;

        // alpha is the angle between a line drawn from the centre to the base of the involute curve and a line drawn


        // from the centre to the intersection of the involute curve and the pitch circle.
        private double alpha;

        private double beta;

        public event EventHandler Updated;

        private void recalculate()
        {
            Pitch = Module * Math.PI;
            PitchCircleDiameter = Module * ToothCount;
            Addendum = Module;
            Dedendum = Module + Module * Clearance;
            WorkingDepth = Module * 2.0;
            ToolDepth = Addendum + Dedendum;
            RootClearance = Module * 0.25;
            FilletRadius = Module * 0.38;
            BaseCircleDiameter = PitchCircleDiameter * Math.Cos(PressureAngle * Math.PI / 180);
            AddendumCircleDiameter = PitchCircleDiameter + 2 * Addendum;
            DedendumCircleDiameter = PitchCircleDiameter - 2 * Dedendum;
            Alpha = Math.Sqrt(PitchCircleDiameter * PitchCircleDiameter - BaseCircleDiameter * BaseCircleDiameter) /
                (BaseCircleDiameter / 180 * Math.PI) - PressureAngle;
            Beta = 360 / (4 * (double) ToothCount) - Alpha;

            OnUpdated();
        }

        public double Module
        {
            get => module;
            set
            {
                module = value;
                recalculate();
            }
        }

        public int ToothCount
        {
            get => toothCount;
            set
            {
                toothCount = value;
                recalculate();
            }
        }

        public double Pitch
        {
            get => pitch;
            set => pitch = value;
        }

        public double PressureAngle
        {
            get => pressureAngle;
            set
            {
                pressureAngle = value;
                recalculate();
            }
        }

        public double Addendum
        {
            get => addendum;
            set => addendum = value;
        }

        public double Dedendum
        {
            get => dedendum;
            set => dedendum = value;
        }

        public double ToolDepth
        {
            get => toolDepth;
            set => toolDepth = value;
        }

        public double WorkingDepth
        {
            get => workingDepth;
            set => workingDepth = value;
        }

        public double RootClearance
        {
            get => rootClearance;
            set => rootClearance = value;
        }

        public double FilletRadius
        {
            get => filletRadius;
            set => filletRadius = value;
        }

        public double[] Series1Module
        {
            get => series1module;
            set => series1module = value;
        }

        public double[] Series2Module
        {
            get => series2module;
            set => series2module = value;
        }

        public double WheelCentreX
        {
            get => wheelCentreX;
            set => wheelCentreX = value;
        }

        public double WheelCentreY
        {
            get => wheelCentreY;
            set => wheelCentreY = value;
        }

        public string[] SeriesNames
        {
            get => seriesNames;
            set => seriesNames = value;
        }

        public double PitchCircleDiameter
        {
            get => pitchCircleDiameter;
            set => pitchCircleDiameter = value;
        }

        public double BaseCircleDiameter
        {
            get => baseCircleDiameter;
            set => baseCircleDiameter = value;
        }

        public double DedendumCircleDiameter
        {
            get => dedendumCircleDiameter;
            set => dedendumCircleDiameter = value;
        }

        public double AddendumCircleDiameter
        {
            get => addendumCircleDiameter;
            set => addendumCircleDiameter = value;
        }


        public double ProfileShiftFactor
        {
            get => profileShiftFactor;
            set => profileShiftFactor = value;
        }

        public int CountInvolutePoints
        {
            get => countInvolutePoints;
            set => countInvolutePoints = value;
        }

        public IADDesignPlane Plane
        {
            get => plane;
            set => plane = value;
        }

        public IADDesignSession Session
        {
            get => session;
            set => session = value;
        }

        public double Alpha
        {
            get => alpha;
            set => alpha = value;
        }

        public double Beta
        {
            get => beta;
            set => beta = value;
        }

        public double Clearance
        {
            get => clearance;
            set => clearance = value;
        }

        protected virtual void OnUpdated()
        {
            Updated?.Invoke(this, EventArgs.Empty);
        }
    }
}