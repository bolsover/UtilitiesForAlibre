using Bolsover.Bevel.Calculator;
using MathNet.Numerics.LinearAlgebra;
using NUnit.Framework;

namespace UnitTests
{
    public class KFactorTests
    {
        private ConsoleIO io = new();
        [Test]
        public void TestKFactor()
        {
            var kfc = new Bolsover.Bevel.Calculator.KfactorCalculator();
            Vector<double> result = kfc.Calculate();
            io.WriteLine(result.ToString());
        }
        
        
        [Test]
        public void TestKFactor2()
        {
            var kfc = new Bolsover.Bevel.Calculator.KfactorCalculator();
            double result = kfc.TestKFactor(0.14);
            io.WriteLine(result.ToString());
        }
        
       [ Test]
        public void TestKFactor3()
        {
         
            double result = KFactorDictionary.GetKFactor(16, 0.3);
            io.WriteLine(result.ToString());
        }
        
        
    }
}