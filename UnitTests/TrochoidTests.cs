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
        
        [Test]
        public void PolarToCartesian()
        {
            var expectedResultx = 0.70711;
            var expectedResulty = 0.70711;
            Assert.AreEqual(expectedResultx, trochoid.PolarToCartesian(1, Point.Radians(45)).X, 0.0001);
            Assert.AreEqual(expectedResulty, trochoid.PolarToCartesian(1, Point.Radians(45)).Y, 0.0001);

        }
        
        [Test]
        public void PolarRinv()
        {
            var expectedResult = 0.5075583;
            
            Assert.AreEqual(expectedResult, trochoid.PolarRinv(1, Point.Radians(10)), 0.0001);
           

        }
        
        [Test]
        public void PolarEtaInv()
        {
            var expectedResult = 0.001740;
            
            Assert.AreEqual(expectedResult, trochoid.PolarEtaInv(Point.Radians(10)), 0.0001);
           }
        
        [Test]
        public void PolarRtro()
        {
            var expectedResult = 1.0;
            
            Assert.AreEqual(expectedResult, trochoid.PolarRtro(2, 0, 0), 0.0001);
        }
        
        [Test]
        public void PolarEtatro()
        {
            var expectedResult = 3;
            
            Assert.AreEqual(expectedResult, trochoid.PolarEtaTro(1, 1, 1), 0.0001);
        }
    }
}