using System.Collections.Generic;
using System.Text;

namespace Bolsover.Gear
{
    public class GearToothPoints
    {
        private Point gearCentre;
        private List<Point> leftInvolute;
        private List<Point> rightInvolute;
        private Point rightMidRoot;
        private Point leftMidRoot;
        private Point rightRootFilletStart;
        private Point leftRootFilletStart;
        private Point rightRootFilletEnd;
        private Point leftRootFilletEnd;
        private Point rightRootFilletCentre;
        private Point leftRootFilletCentre;
        private Point rightInvoluteStart; // same as rightInvolute 0;
        private Point leftInvoluteStart; // same as leftInvolute 0;
        private Point rightTipReliefStart;
        private Point leftTipReliefStart;
        private Point rightTipReliefEnd;
        private Point leftTipReliefEnd;
        private Point rightTipReliefCentre;
        private Point leftTipReliefCentre;
        private Point toothTipCentre;
        private string templateFilePath;
        private bool isHelical;
        private bool isPinion;
        private GearPair gearPair;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("gearCentre " + gearCentre.X + "," + gearCentre.Y + "\n");
            sb.Append("\n");
            sb.Append("rightMidRoot " + rightMidRoot.X + "," + rightMidRoot.Y + "\n");
            sb.Append("\n");
            sb.Append("rightRootFilletStart " + rightRootFilletStart.X + "," + rightRootFilletStart.Y + "\n");
            sb.Append("rightRootFilletCentre " + rightRootFilletCentre.X + "," + rightRootFilletCentre.Y + "\n");
            sb.Append("rightRootFilletEnd " + rightRootFilletEnd.X + "," + rightRootFilletEnd.Y + "\n");
            sb.Append("\n");
            sb.Append("rightInvolute " + rightInvolute[0].X + "," + rightInvolute[0].Y + "\n");
            sb.Append("rightInvolute " + rightInvolute.Count + " points \n");
            sb.Append("rightInvolute " + rightInvolute[rightInvolute.Count - 1].X + "," + rightInvolute[rightInvolute.Count - 1].Y + "\n");
            sb.Append("\n");
            sb.Append("rightTipReliefStart " + rightTipReliefStart.X + "," + rightTipReliefStart.Y + "\n");
            sb.Append("rightTipReliefCentre " + rightTipReliefCentre.X + "," + rightTipReliefCentre.Y + "\n");
            sb.Append("rightTipReliefEnd " + rightTipReliefEnd.X + "," + rightTipReliefEnd.Y + "\n");
            sb.Append("\n");
            sb.Append("toothTipCentre " + toothTipCentre.X + "," + toothTipCentre.Y + "\n");
            sb.Append("\n");
            sb.Append("leftTipReliefEnd " + leftTipReliefEnd.X + "," + leftTipReliefEnd.Y + "\n");
            sb.Append("leftTipReliefCentre " + leftTipReliefCentre.X + "," + leftTipReliefCentre.Y + "\n");
            sb.Append("leftTipReliefStart " + leftTipReliefStart.X + "," + leftTipReliefStart.Y + "\n");
            sb.Append("\n");
            sb.Append("leftInvolute " + leftInvolute[leftInvolute.Count - 1].X + "," + leftInvolute[leftInvolute.Count - 1].Y + "\n");
            sb.Append("leftInvolute " + leftInvolute.Count + " points \n");
            sb.Append("leftInvolute " + leftInvolute[0].X + "," + leftInvolute[0].Y + "\n");
            sb.Append("\n");
            sb.Append("leftRootFilletEnd " + leftRootFilletEnd.X + "," + leftRootFilletEnd.Y + "\n");
            sb.Append("leftRootFilletCentre " + leftRootFilletCentre.X + "," + leftRootFilletCentre.Y + "\n");
            sb.Append("leftRootFilletStart " + leftRootFilletStart.X + "," + leftRootFilletStart.Y + "\n");
            sb.Append("\n");
            sb.Append("leftMidRoot " + leftMidRoot.X + "," + leftMidRoot.Y + "\n");

            return sb.ToString();
        }

        public Point GearCentre
        {
            get => gearCentre;
            set => gearCentre = value;
        }

        public List<Point> LeftInvolute
        {
            get => leftInvolute;
            set => leftInvolute = value;
        }

        public List<Point> RightInvolute
        {
            get => rightInvolute;
            set => rightInvolute = value;
        }

        public Point RightMidRoot
        {
            get => rightMidRoot;
            set => rightMidRoot = value;
        }

        public Point LeftMidRoot
        {
            get => leftMidRoot;
            set => leftMidRoot = value;
        }

        public Point RightRootFilletStart
        {
            get => rightRootFilletStart;
            set => rightRootFilletStart = value;
        }

        public Point LeftRootFilletStart
        {
            get => leftRootFilletStart;
            set => leftRootFilletStart = value;
        }

        public Point RightRootFilletEnd
        {
            get => rightRootFilletEnd;
            set => rightRootFilletEnd = value;
        }

        public Point LeftRootFilletEnd
        {
            get => leftRootFilletEnd;
            set => leftRootFilletEnd = value;
        }

        public Point RightRootFilletCentre
        {
            get => rightRootFilletCentre;
            set => rightRootFilletCentre = value;
        }

        public Point LeftRootFilletCentre
        {
            get => leftRootFilletCentre;
            set => leftRootFilletCentre = value;
        }

        public Point RightInvoluteStart
        {
            get => rightInvoluteStart;
            set => rightInvoluteStart = value;
        }

        public Point LeftInvoluteStart
        {
            get => leftInvoluteStart;
            set => leftInvoluteStart = value;
        }

        public Point RightTipReliefStart
        {
            get => rightTipReliefStart;
            set => rightTipReliefStart = value;
        }

        public Point LeftTipReliefStart
        {
            get => leftTipReliefStart;
            set => leftTipReliefStart = value;
        }

        public Point RightTipReliefEnd
        {
            get => rightTipReliefEnd;
            set => rightTipReliefEnd = value;
        }

        public Point LeftTipReliefEnd
        {
            get => leftTipReliefEnd;
            set => leftTipReliefEnd = value;
        }

        public Point RightTipReliefCentre
        {
            get => rightTipReliefCentre;
            set => rightTipReliefCentre = value;
        }

        public Point LeftTipReliefCentre
        {
            get => leftTipReliefCentre;
            set => leftTipReliefCentre = value;
        }

        public Point ToothTipCentre
        {
            get => toothTipCentre;
            set => toothTipCentre = value;
        }

        public string TemplateFilePath
        {
            get => templateFilePath;
            set => templateFilePath = value;
        }

        public bool IsHelical
        {
            get => isHelical;
            set => isHelical = value;
        }

        public bool IsPinion
        {
            get => isPinion;
            set => isPinion = value;
        }

        public GearPair Pair
        {
            get => gearPair;
            set => gearPair = value;
        }
    }
}