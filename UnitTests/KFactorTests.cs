using Bolsover.Bevel.Calculator;
using NUnit.Framework;

namespace UnitTests
{
    public class KFactorTests
    {
        private readonly ConsoleIO io = new();
        
        [Test]
        public void TestKFactor()
        {
            var kfc = new KFactorCalculator();
            var result = kfc.Calculate();
            io.WriteLine(result.ToString());
        }
        
        
        [Test]
        public void TestKFactor2()
        {
            var kfc = new KFactorCalculator();
            var result = kfc.TestKFactor(0.14);
            io.WriteLine(result.ToString());
        }
        
        [Test]
        public void TestKFactor3()
        {
            var result = KFactorDictionary.GetKFactor(16, 0.3);
            io.WriteLine(result.ToString());
        }
    }
}