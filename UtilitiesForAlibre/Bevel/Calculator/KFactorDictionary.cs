using System;
using System.Collections.Generic;

namespace Bolsover.Bevel.Calculator
{
    public static class KFactorDictionary
    {
        private static Dictionary<int, KFactor> KFactors = new()
        {
            { 13, new KFactor { Teeth = 13, KCoefficients = new double[] { 0.113248, -0.0860757, -0.144655 } } },
            { 14, new KFactor { Teeth = 14, KCoefficients = new double[] { 0.102608, -0.0926794, -0.132172 } } },
            { 15, new KFactor { Teeth = 15, KCoefficients = new double[] { 0.0930929, -0.10764, -0.101659 } } },
            { 16, new KFactor { Teeth = 16, KCoefficients = new double[] { 0.0853713, -0.126877, -0.0563896 } } },
            { 17, new KFactor { Teeth = 17, KCoefficients = new double[] { 0.0738815, -0.11399, -0.0697084 } } },
            { 18, new KFactor { Teeth = 18, KCoefficients = new double[] { 0.0653775, -0.117627, -0.0530723 } } },
            { 19, new KFactor { Teeth = 19, KCoefficients = new double[] { 0.0570359, -0.111934, -0.0575795 } } },
            { 20, new KFactor { Teeth = 20, KCoefficients = new double[] { 0.048194, -0.103158, -0.0746135 } } },
            { 21, new KFactor { Teeth = 21, KCoefficients = new double[] { 0.0390239, -0.0768547, -0.137744 } } },
            { 22, new KFactor { Teeth = 22, KCoefficients = new double[] { 0.0292487, -0.0654519, -0.163111 } } },
            { 23, new KFactor { Teeth = 23, KCoefficients = new double[] { 0.0226875, -0.056163, -0.119816 } } },
            { 24, new KFactor { Teeth = 24, KCoefficients = new double[] { 0.0188031, -0.0874672, -0.0984252 } } }
        };
        
        public static double GetKFactor(int teeth, double ratio)
        {
            if (teeth > 24)
            {
                return 0;
            }
            var kFactor = KFactors[teeth];
            var p = kFactor.KCoefficients;
            var y = Polynomial(ratio);
            return y;

            double Polynomial(double x) => p[0] + p[1] * x + p[2] * Math.Pow(x, 2);
        }

    }

    public class KFactor
    {
        public int Teeth { get; set; }
        public double[] KCoefficients { get; set; }
    }
}