using System.Collections.Generic;
using System.Text;

namespace Bolsover.Gear.Models
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
            sb.Append(
                $"rightInvolute {RightInvolute[RightInvolute.Count - 1].X},{RightInvolute[RightInvolute.Count - 1].Y}\n");
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

        public GearPoint GearCentre { get; set; }

        public List<GearPoint> LeftInvolute { get; set; }

        public List<GearPoint> RightInvolute { get; set; }

        public GearPoint RightAddendumFilletEnd { get; set; } // internal gears only

        public GearPoint RightAddendumFilletCentre { get; set; } // internal gears only

        public GearPoint RightAddendumFilletStart { get; set; } // internal gears only

        public GearPoint LeftAddendumFilletEnd { get; set; } // internal gears only

        public GearPoint LeftAddendumFilletCentre { get; set; } // internal gears only

        public GearPoint LeftAddendumFilletStart { get; set; } // internal gears only
        public GearPoint LeftInvoluteEnd { get; set; }

        public GearPoint RightInvoluteEnd { get; set; }

        public GearPoint RightMidRoot { get; set; }

        public GearPoint LeftMidRoot { get; set; }

        public GearPoint RightMidOuter { get; set; }

        public GearPoint LeftMidOuter { get; set; }

        public GearPoint RightMidBase { get; set; }

        public GearPoint LeftMidBase { get; set; }

        public GearPoint RightMidAddendum { get; set; }

        public GearPoint LeftMidAddendum { get; set; }

        public GearPoint RightRootFilletStart { get; set; }

        public GearPoint LeftRootFilletStart { get; set; }

        public GearPoint RightRootFilletEnd { get; set; }

        public GearPoint LeftRootFilletEnd { get; set; }

        public GearPoint RightRootFilletCentre { get; set; }

        public GearPoint LeftRootFilletCentre { get; set; }

        public GearPoint RightInvoluteStart { get; set; }

        public GearPoint LeftInvoluteStart { get; set; }

        public GearPoint RightTipReliefStart { get; set; }

        public GearPoint LeftTipReliefStart { get; set; }

        public GearPoint RightTipReliefEnd { get; set; }

        public GearPoint LeftTipReliefEnd { get; set; }

        public GearPoint RightTipReliefCentre { get; set; }

        public GearPoint LeftTipReliefCentre { get; set; }

        public GearPoint ToothTipCentre { get; set; }

        public string TemplateFilePath { get; set; }

        public bool IsHelical { get; set; }

        public bool IsPinion { get; set; }

        public InvoluteGear G1 { get; set; }
    }
}