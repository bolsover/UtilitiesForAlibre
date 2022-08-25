using System.Diagnostics;
using Bolsover.Gears;
using NUnit.Framework;

namespace UnitTests
{
    public class TrochoidTests
    {
        private Trochoid trochoid = new();
        private ConsoleIO io = new();

        [SetUp]
        public void Setup()
        {
            trochoid.FixedCircleRadius = 8;
            trochoid.RollingCircleRadius = 3;
            trochoid.TracePoint = 2;
        }

        [Test]
        public void EpiTrochoidX()
        {
            // var expectedResult = 5;
            //
            // Assert.AreEqual(expectedResult, trochoid.EpiTrochoidX(0), 0.0001);


            for (int i = 0; i < 1080;)
            {
                io.WriteLine(trochoid.HypoTrochoidX(i).ToString("##0.000") + "," + trochoid.HypoTrochoidY(i).ToString("##0.000"));
                i = i + 10;
            }
        }
    }
}