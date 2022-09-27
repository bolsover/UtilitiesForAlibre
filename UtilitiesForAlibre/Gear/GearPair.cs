using System;


namespace Bolsover.Gear
{
    public class GearPair
    {
        private InvoluteGear g1;
        private InvoluteGear g2;
        private double deltaX = 50; // distribution of profile shift X between g1, g2
        private double circularBacklashbc; // circular backlash required
        private double workingCentreDistanceaw; //working centre distance

        public GearPair(InvoluteGear g1, InvoluteGear g2, double aw, double circularBacklashBc)
        {
            this.g1 = g1;
            this.g2 = g2;
            g1.Pair = this;
            g2.Pair = this;
            workingCentreDistanceaw = aw;
            circularBacklashbc = circularBacklashBc;
            this.g1.Updated += OnUpdated;
            this.g2.Updated += OnUpdated;
        }


        public event EventHandler Updated;

        private void OnUpdated(object sender, EventArgs e)
        {
            Updated?.Invoke(this, EventArgs.Empty);
        }


        public InvoluteGear G1
        {
            get => g1;
            set
            {
                g1 = value;

                OnUpdated(this, null);
            }
        }

        public InvoluteGear G2
        {
            get => g2;
            set
            {
                g2 = value;
                OnUpdated(this, null);
            }
        }


        public double DeltaX // distribution of profile shift X between g1, g2
        {
            get => deltaX;
            set
            {
                deltaX = value;
                OnUpdated(this, null);
            }
        }

        public double CircularBacklashBc // circular backlash required
        {
            get => circularBacklashbc;
            set
            {
                circularBacklashbc = value;
                OnUpdated(this, null);
            }
        }

        public double WorkingCentreDistanceAw // working centre distance
        {
            get => workingCentreDistanceaw;
            set
            {
                workingCentreDistanceaw = value;
                OnUpdated(this, null);
            }
        }
    }
}