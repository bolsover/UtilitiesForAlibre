using System.Collections.Generic;

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
            Points = new Dictionary<int, ToothPoint>();
            for (var i = 0; i <= 21; i++)
            {
                Points.Add(i, new ToothPoint(i, GetDescription(i), new GearPoint(0, 0)));
            }
            RhsInvolute = new List<GearPoint>();
            LhsInvolute = new List<GearPoint>();
        }
        
       
        private static string GetDescription(int index)
        {
            return index switch
            {
                0 => "Centre of Gear",
                1 => "RHS Mid point between adjacent teeth on root diameter",
                2 => "RHS Start of root relief arc",
                3 => "RHS Centre of root relief arc",
                4 => "RHS End of root relief arc",
                5 => "RHS Start of involute",
                6 => "RHS Start of tip relief arc",
                7 => "RHS Centre of tip relief arc",
                8 => "RHS End of tip relief arc",
                9 => "Centre point on outside diameter",
                10 => "LHS End of tip relief arc",
                11 => "LHS Centre of tip relief arc",
                12 => "LHS Start of tip relief arc",
                13 => "LHS Start of involute",
                14 => "LHS End of root relief arc",
                15 => "LHS Centre of root relief arc",
                16 => "LHS start of root relief arc",
                17 => "LHS Mid point between adjacent teeth on root diameter",
                18 => "RHS Mid tooth point outer ring diameter",
                19 => "LHS Mid tooth point outer ring diameter",
                20 => "RHS Mid Base diameter",
                21 => "LHS Mid Base diameter",
                _ => ""
            };
        }

        public Dictionary<int, ToothPoint> Points { get; set; }

        public List<GearPoint> LhsInvolute { get; set; }

        public List<GearPoint> RhsInvolute { get; set; }
    }
}