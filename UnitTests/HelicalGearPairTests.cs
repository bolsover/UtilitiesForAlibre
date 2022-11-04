using Bolsover.Gear;
using NUnit.Framework;

namespace UnitTests
{
    public class HelicalGearPairTests
    {
        private InvoluteGear g1 = null!;
        private InvoluteGear g2 = null!;


        [SetUp]
        public void Setup()
        {
            g1 = new InvoluteGear(3, 12, 20, 30, 0.6);
            g2 = new InvoluteGear(3, 60, 20, 30, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.WorkingCentreDistanceAw = 125;
            g2.WorkingCentreDistanceAw = 125;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            g1.DeltaX = 50;
            g2.DeltaX = 50;

            g1.ProfileShiftX = 0.6;
            g2.ProfileShiftX = 35;
            g1.GearType = GearType.External;
            g2.GearType = GearType.External;
        }


        [Test]
        public void CentreDistanceIncrementFactorY()
        {
            var expectedResult = 0.09745;

            Assert.AreEqual(expectedResult, GearCalculations.CentreDistanceIncrementFactorY(g1), 0.0001);
        }


        [Test]
        public void Db1()
        {
            var expectedResult = 38.3222;

            Assert.AreEqual(expectedResult, GearCalculations.BaseDiameterDb(g1), 0.0001);
        }

        [Test]
        public void Db2()
        {
            var expectedResult = 191.6114;

            Assert.AreEqual(expectedResult, GearCalculations.BaseDiameterDb(g2), 0.0001);
        }

        // [Test]
        // public void Da1()
        // {
        //     var expectedResult = 48.1539;
        //
        //     Assert.AreEqual(expectedResult, GearCalculations.AddendumDiameterDa(g1), 0.0001);
        // }
        //
        // [Test]
        // public void Da2()
        // {
        //     var expectedResult = 213.842;
        //
        //     Assert.AreEqual(expectedResult, GearCalculations.AddendumDiameterDa(g2), 0.0001);
        // }
        //
        // [Test]
        // public void Df1()
        // {
        //     var expectedResult = 34.657;
        //
        //     Assert.AreEqual(expectedResult, GearCalculations.RootDiameterDr(g1), 0.0001);
        // }
        //
        // [Test]
        // public void Df2()
        // {
        //     var expectedResult = 200.3460;
        //
        //     Assert.AreEqual(expectedResult, GearCalculations.RootDiameterDr(g1), 0.0001);
        // }

        [Test]
        public void AlphaT()
        {
            var expectedResult = 22.7959;

            Assert.AreEqual(expectedResult, GearCalculations.AlphaT(g1), 0.0001);
        }

        [Test]
        public void AlphaW()
        {
            var expectedResult = 23.1126;

            Assert.AreEqual(expectedResult, GearCalculations.AlphaW(g1), 0.0001);
        }

        [Test]
        public void InvAlphaW()
        {
            var expectedResult = 0.023405;

            Assert.AreEqual(expectedResult, GearCalculations.InvAlphaW(g1), 0.0001);
        }

        [Test]
        public void Dw1()
        {
            var expectedResult = 41.6666;

            Assert.AreEqual(expectedResult, GearCalculations.WorkingPitchDiameterDw(g1), 0.0001);
        }

        [Test]
        public void Dw2()
        {
            var expectedResult = 208.3333;

            Assert.AreEqual(expectedResult, GearCalculations.WorkingPitchDiameterDw(g2), 0.0001);
        }

        // [Test]
        // public void SigmaX()
        // {
        //     var expectedResult = 0.09809;
        //
        //     Assert.AreEqual(expectedResult, GearCalculations.SigmaX(g2), 0.0001);
        // }


        [Test]
        public void XMod()
        {
            var expectedResult = 0.0;

            Assert.AreEqual(expectedResult, GearCalculations.XMod(g2), 0.0001);
        }
    }
}