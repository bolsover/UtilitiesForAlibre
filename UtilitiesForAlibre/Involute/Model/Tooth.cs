using System.Collections.Generic;
using Bolsover.Gear.Models;

namespace Bolsover.Involute.Model
{
    public class Tooth
    {
        public Tooth()
        {
            Init();
        }

        private void Init()
        {
            Points = new Dictionary<int, ToothPoint>
            {
                {0, new ToothPoint(0, "Centre of Gear", new GearPoint(0, 0))},
                {1, new ToothPoint(1, "RHS Mid point between adjacent teeth on root diameter", new GearPoint(0, 0))},
                {2, new ToothPoint(2, "RHS Start of root relief arc", new GearPoint(0, 0))},
                {3, new ToothPoint(3, "RHS Centre of root relief arc", new GearPoint(0, 0))},
                {4, new ToothPoint(4, "RHS End of root relief arc", new GearPoint(0, 0))},
                {5, new ToothPoint(5, "RHS Start of involute", new GearPoint(0, 0))},
                {6, new ToothPoint(6, "RHS Start of tip relief arc", new GearPoint(0, 0))},
                {7, new ToothPoint(7, "RHS Centre of tip relief arc", new GearPoint(0, 0))},
                {8, new ToothPoint(8, "RHS End of tip relief arc", new GearPoint(0, 0))},
                {9, new ToothPoint(9, "Centre point on outside diameter", new GearPoint(0, 0))},
                {10, new ToothPoint(10, "LHS End of tip relief arc", new GearPoint(0, 0))},
                {11, new ToothPoint(11, "LHS Centre of tip relief arc", new GearPoint(0, 0))},
                {12, new ToothPoint(12, "LHS Start of tip relief arc", new GearPoint(0, 0))},
                {13, new ToothPoint(13, "LHS Start of involute", new GearPoint(0, 0))},
                {14, new ToothPoint(14, "LHS End of root relief arc", new GearPoint(0, 0))},
                {15, new ToothPoint(15, "LHS Centre of root relief arc", new GearPoint(0, 0))},
                {16, new ToothPoint(16, "LHS start of root relief arc", new GearPoint(0, 0))},
                {17, new ToothPoint(17, "LHS Mid point between adjacent teeth on root diameter", new GearPoint(0, 0))},
                {18, new ToothPoint(18, "RHS Mid tooth point outer ring diameter", new GearPoint(0, 0))},
                {19, new ToothPoint(19, "LHS Mid tooth point outer ring diameter", new GearPoint(0, 0))},
                {20, new ToothPoint(20, "RHS Mid Base diameter", new GearPoint(0, 0))},
                {21, new ToothPoint(21, "LHS Mid Base diameter", new GearPoint(0, 0))}

            };
            RhsInvolute = new List<GearPoint>();
            LhsInvolute = new List<GearPoint>();
        }
        
       

        public Dictionary<int, ToothPoint> Points { get; set; }

        public List<GearPoint> LhsInvolute { get; set; }

        public List<GearPoint> RhsInvolute { get; set; }
    }
}