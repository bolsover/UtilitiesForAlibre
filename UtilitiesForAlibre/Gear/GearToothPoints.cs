using System.Collections.Generic;
using System.Text;

namespace Bolsover.Gear
{
    public class GearToothPoints
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"gearCentre {GearCentre.X},{GearCentre.Y}\n");
            sb.Append("\n");
            sb.Append($"rightMidRoot {RightMidRoot.X},{RightMidRoot.Y}\n");
            sb.Append("\n");
            sb.Append($"rightRootFilletStart {RightRootFilletStart.X},{RightRootFilletStart.Y}\n");
            sb.Append($"rightRootFilletCentre {RightRootFilletCentre.X},{RightRootFilletCentre.Y}\n");
            sb.Append($"rightRootFilletEnd {RightRootFilletEnd.X},{RightRootFilletEnd.Y}\n");
            sb.Append("\n");
            sb.Append($"rightInvolute {RightInvolute[0].X},{RightInvolute[0].Y}\n");
            sb.Append($"rightInvolute {RightInvolute.Count} points \n");
            sb.Append($"rightInvolute {RightInvolute[RightInvolute.Count - 1].X},{RightInvolute[RightInvolute.Count - 1].Y}\n");
            sb.Append("\n");
            sb.Append($"rightTipReliefStart {RightTipReliefStart.X},{RightTipReliefStart.Y}\n");
            sb.Append($"rightTipReliefCentre {RightTipReliefCentre.X},{RightTipReliefCentre.Y}\n");
            sb.Append($"rightTipReliefEnd {RightTipReliefEnd.X},{RightTipReliefEnd.Y}\n");
            sb.Append("\n");
            sb.Append($"toothTipCentre {ToothTipCentre.X},{ToothTipCentre.Y}\n");
            sb.Append("\n");
            sb.Append($"leftTipReliefEnd {LeftTipReliefEnd.X},{LeftTipReliefEnd.Y}\n");
            sb.Append($"leftTipReliefCentre {LeftTipReliefCentre.X},{LeftTipReliefCentre.Y}\n");
            sb.Append($"leftTipReliefStart {LeftTipReliefStart.X},{LeftTipReliefStart.Y}\n");
            sb.Append("\n");
            sb.Append($"leftInvolute {LeftInvolute[LeftInvolute.Count - 1].X},{LeftInvolute[LeftInvolute.Count - 1].Y}\n");
            sb.Append($"leftInvolute {LeftInvolute.Count} points \n");
            sb.Append($"leftInvolute {LeftInvolute[0].X},{LeftInvolute[0].Y}\n");
            sb.Append("\n");
            sb.Append($"leftRootFilletEnd {LeftRootFilletEnd.X},{LeftRootFilletEnd.Y}\n");
            sb.Append($"leftRootFilletCentre {LeftRootFilletCentre.X},{LeftRootFilletCentre.Y}\n");
            sb.Append($"leftRootFilletStart {LeftRootFilletStart.X},{LeftRootFilletStart.Y}\n");
            sb.Append("\n");
            sb.Append($"leftMidRoot {LeftMidRoot.X},{LeftMidRoot.Y}\n");

            return sb.ToString();
        }

        public Point GearCentre { get; set; }

        public List<Point> LeftInvolute { get; set; }

        public List<Point> RightInvolute { get; set; }

        public Point RightMidRoot { get; set; }

        public Point LeftMidRoot { get; set; }

        public Point RightRootFilletStart { get; set; }

        public Point LeftRootFilletStart { get; set; }

        public Point RightRootFilletEnd { get; set; }

        public Point LeftRootFilletEnd { get; set; }

        public Point RightRootFilletCentre { get; set; }

        public Point LeftRootFilletCentre { get; set; }

        public Point RightInvoluteStart { get; set; }

        public Point LeftInvoluteStart { get; set; }

        public Point RightTipReliefStart { get; set; }

        public Point LeftTipReliefStart { get; set; }

        public Point RightTipReliefEnd { get; set; }

        public Point LeftTipReliefEnd { get; set; }

        public Point RightTipReliefCentre { get; set; }

        public Point LeftTipReliefCentre { get; set; }

        public Point ToothTipCentre { get; set; }

        public string TemplateFilePath { get; set; }

        public bool IsHelical { get; set; }

        public bool IsPinion { get; set; }

        public GearPair Pair { get; set; }
    }
}