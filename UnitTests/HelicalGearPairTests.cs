using Bolsover.Gear;
using NUnit.Framework;

namespace UnitTests
{
    public class HelicalGearPairTests
    {
        private InvoluteGear g1 = null!;
        private InvoluteGear g2 = null!;
        private GearPair gearPair = null!;

        [SetUp]
        public void Setup()
        {
            g1 = new InvoluteGear(3, 12, 20, 30, 0.6);
            g2 = new InvoluteGear(3, 60, 20, 30, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            gearPair = new GearPair(g1, g2, 125, 0);
            g1.ProfileShiftX = 0.9809;
            g2.ProfileShiftX = 0;
            // gearPair.Updated += GearPairOnUpdated;
        }

        // private void GearPairOnUpdated(object sender, EventArgs e)
        // {
        //     double expectedResult = 13;
        //
        //     Assert.AreEqual(expectedResult, g1.M, 0.0001);
        // }


        // [Test]
        // public void Alpha1()
        // {
        //     var expectedResult = 0.85395;
        //
        //     Assert.AreEqual(expectedResult, g1.Alpha1, 0.0001);
        // }

        [Test]
        public void CentreDistanceIncrementFactorY()
        {
            var expectedResult = 0.09745;

            Assert.AreEqual(expectedResult, gearPair.CentreDistanceIncrementFactorY, 0.0001);
        }
        //
        // [Test]
        // public void InvAlpha()
        // {
        //     var expectedResult = 0.014904;
        //
        //     Assert.AreEqual(expectedResult, g1.InvAlpha, 0.0001);
        // }

        [Test]
        public void Db1()
        {
            var expectedResult = 38.3222;

            Assert.AreEqual(expectedResult, g1.BaseDiameterDb, 0.0001);
        }

        [Test]
        public void Db2()
        {
            var expectedResult = 191.6114;

            Assert.AreEqual(expectedResult, g2.BaseDiameterDb, 0.0001);
        }

        [Test]
        public void Da1()
        {
            var expectedResult = 48.1539;

            Assert.AreEqual(expectedResult, gearPair.AddendumDiameterDa(g1, g2), 0.0001);
        }

        [Test]
        public void Da2()
        {
            var expectedResult = 213.842;

            Assert.AreEqual(expectedResult, gearPair.AddendumDiameterDa(g2, g1), 0.0001);
        }

        [Test]
        public void Df1()
        {
            var expectedResult = 34.657;

            Assert.AreEqual(expectedResult, g1.RootDiameterDr, 0.0001);
        }

        [Test]
        public void Df2()
        {
            var expectedResult = 200.3460;

            Assert.AreEqual(expectedResult, g2.RootDiameterDr, 0.0001);
        }

        [Test]
        public void AlphaT()
        {
            var expectedResult = 22.7959;

            Assert.AreEqual(expectedResult, g1.AlphaT, 0.0001);
        }

        [Test]
        public void AlphaW()
        {
            var expectedResult = 23.1126;

            Assert.AreEqual(expectedResult, gearPair.AlphaW, 0.0001);
        }

        [Test]
        public void InvAlphaW()
        {
            var expectedResult = 0.023405;

            Assert.AreEqual(expectedResult, gearPair.InvAlphaW, 0.0001);
        }

        [Test]
        public void Dw1()
        {
            var expectedResult = 41.6666;

            Assert.AreEqual(expectedResult, gearPair.WorkingPitchDiameterDw(g1), 0.0001);
        }

        [Test]
        public void Dw2()
        {
            var expectedResult = 208.3333;

            Assert.AreEqual(expectedResult, gearPair.WorkingPitchDiameterDw(g2), 0.0001);
        }

        [Test]
        public void SigmaX()
        {
            var expectedResult = 0.09809;

            Assert.AreEqual(expectedResult, gearPair.SigmaX, 0.0001);
        }

        // [Test]
        // public void ContactRatio()
        // {
        //     var expectedResult = 1.20210;
        //
        //     Assert.AreEqual(expectedResult, gearPair.ContactRatio(), 0.0001);
        // }

        // [Test]
        // public void Theta1()
        // {
        //     var expectedResult = 9.58539;
        //
        //     Assert.AreEqual(expectedResult, gearPair.Theta(g1), 0.0001);
        // }
        //
        //
        // [Test]
        // public void RotateDegrees1()
        // {
        //     var expectedResult = 20.878708;
        //
        //     Assert.AreEqual(expectedResult, gearPair.RotateDegrees(g1), 0.0001);
        // }


        [Test]
        public void XMod()
        {
            var expectedResult = 0.0;

            Assert.AreEqual(expectedResult, gearPair.XMod, 0.0001);
        }


        // [Test]
        // public void AngleToFilletCentre()
        // {
        //     var expectedResult = 0.034302;
        //
        //     Assert.AreEqual(expectedResult, gearPair.AngleToFilletCentre(g1), 0.0001);
        // }
        //
        // [Test]
        // public void PointA()
        // {
        //     var expectedResultx = 16.04055;
        //     var expectedResulty = -0.55045;
        //     Point pointA = gearPair.RootFilletStartPoint(g1);
        //     Assert.AreEqual(expectedResultx, pointA.X, 0.0001);
        //     Assert.AreEqual(expectedResulty, pointA.Y, 0.0001);
        // }
        //
        // [Test]
        // public void PointD()
        // {
        //     var expectedResultx = 16.61022;
        //     var expectedResulty = -0.57000;
        //     Point pointD = gearPair.RootFilletCentrePoint(g1);
        //     Assert.AreEqual(expectedResultx, pointD.X, 0.0001);
        //     Assert.AreEqual(expectedResulty, pointD.Y, 0.0001);
        // }
        //
        // [Test]
        // public void PointE()
        // {
        //     var expectedResultx = 16.61022;
        //     var expectedResulty = -0;
        //     Point pointE = gearPair.RootFilletEndPoint(g1);
        //     Assert.AreEqual(expectedResultx, pointE.X, 0.0001);
        //     Assert.AreEqual(expectedResulty, pointE.Y, 0.0001);
        // }

        // [Test]
        // public void AxialPitch()
        // {
        //     g1.HelixAngleBeta = 15;
        //     var expectedResult = 37.69911;
        //
        //     Assert.AreEqual(expectedResult, g1.AxialPitch, 0.0001);
        //     g1.HelixAngleBeta = 0;
        // }
        //
        // [Test]
        // public void HelixPitchLength()
        // {
        //     g1.HelixAngleBeta = 15;
        //     var expectedResult = 37.69911 * g1.TeethZ;
        //
        //     Assert.AreEqual(expectedResult, g1.HelixPitchLength, 0.0001);
        //     g1.HelixAngleBeta = 0;
        // }
        //
        // [Test]
        // public void CoordinateIntersectionCircleWithInvoluteX()
        // {
        //     var expectedResultX = 9.7363;
        //     Assert.AreEqual(expectedResultX, gearPair.CoordinateIntersectionCircleWithInvolute(16.914 / 2, 19.5 / 2).X, 0.0001);
        // }
        //
        // [Test]
        // public void CoordinateIntersectionCircleWithInvoluteY()
        // {
        //     var expectedResultX = 0.5150;
        //     Assert.AreEqual(expectedResultX, gearPair.CoordinateIntersectionCircleWithInvolute(16.914 / 2, 19.5 / 2).Y, 0.0001);
        // }
        //
        // [Test]
        // public void CoordinateIntersectionCircleWithInvoluteX1()
        // {
        //     var expectedResultX = 9.97681;
        //     Assert.AreEqual(expectedResultX, gearPair.CoordinateIntersectionCircleWithInvolute(16.914 / 2, 20 / 2).X, 0.0001);
        // }
        //
        // [Test]
        // public void CoordinateIntersectionCircleWithInvoluteY1()
        // {
        //     var expectedResultX = 0.68052;
        //     Assert.AreEqual(expectedResultX, gearPair.CoordinateIntersectionCircleWithInvolute(16.914 / 2, 20 / 2).Y, 0.0001);
        // }

        // [Test]
        // public void Update()
        // {
        //     g1.M = 13;
        // }
    }
}