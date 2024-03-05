using System;
using System.Linq;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

using MathNet.Numerics.LinearRegression;

namespace Bolsover.Bevel.Calculator
{
    public class KfactorCalculator
    {
        //24
        double[] xdata = new double[] {0.18,   0.16, 0.13, 0.1 };
        double[] ydata = new double[] {0.000,  0.002, 0.006, 0.009 };

        public Vector<double> Calculate()
        {
// Generate the vandermonde matrix
            var design = Matrix<double>.Build.DenseOfRowArrays(xdata.Select(x => Powers(x, 2)));

// Fit result
            var p = MultipleRegression.QR(design, Vector<double>.Build.Dense(ydata));
            return p;
// The coefficients of the polynomial are in the p vector
// p[0] is the intercept, p[1] is the linear term, p[2] is the quadratic term
        }
        
        public static double[] Powers(double value, int degree)
        {
            double[] powers = new double[degree + 1];
            for (int i = 0; i <= degree; i++)
            {
                powers[i] = Math.Pow(value, i);
            }
            return powers;
        }
        
        public double TestKFactor(double x)
        {
            // double[] p = {0.1122, -0.0766429, -0.160714 }; // Assume this array contains the coefficients obtained from the regression.
            double[] p = Calculate().ToArray();
            
// Construct the polynomial equation.
            Func<double, double> polynomial = x => p[0] + p[1] * x + p[2] * Math.Pow(x, 2);

// Use the polynomial equation to predict the y-value for a given x-value.
         //   double x = 0.45; // This is the x-value for which we want to predict the y-value.
            double y = polynomial(x);
            return y;
           // Console.WriteLine($"The predicted y-value for x={x} is {y}");
        }
    }
}