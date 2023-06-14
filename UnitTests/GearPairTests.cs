using System;
using Bolsover.Gear;
using NUnit.Framework;

namespace UnitTests
{
    public class GearPairTests
    {
        private InvoluteGear g1 = null!;
        private InvoluteGear g2 = null!;


        [SetUp]
        public void Setup()
        {
            g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            g1.GearType = GearType.External;
            g2.GearType = GearType.External;
        }


        [Test]
        public void Alpha1()
        {
            var expectedResult = 0.85395;

            Assert.AreEqual(expectedResult, GearCalculations.Alpha1(g1), 0.0001);
        }

        [Test]
        public void Y()
        {
            var expectedResult = 0.8333;

            Assert.AreEqual(expectedResult, GearCalculations.CentreDistanceIncrementFactorY(g1), 0.0001);
        }

        [Test]
        public void InvAlpha()
        {
            var expectedResult = 0.014904;

            Assert.AreEqual(expectedResult, GearCalculations.InvAlpha(g1), 0.0001);
        }

        [Test]
        public void Db1()
        {
            var expectedResult = 33.8289;

            Assert.AreEqual(expectedResult, GearCalculations.BaseDiameterDb(g1), 0.0001);
        }

        [Test]
        public void Db2()
        {
            var expectedResult = 67.6579;

            Assert.AreEqual(expectedResult, GearCalculations.BaseDiameterDb(g2), 0.0001);
        }

        [Test]
        public void Da1()
        {
            var expectedResult = 44.8398;

            Assert.AreEqual(expectedResult, GearCalculations.AddendumDiameterDa(g1), 0.0001);
        }

        [Test]
        public void Da2()
        {
            var expectedResult = 79.3998;

            Assert.AreEqual(expectedResult, GearCalculations.AddendumDiameterDa(g2), 0.0001);
        }

        [Test]
        public void Df1()
        {
            var expectedResult = 32.100;

            Assert.AreEqual(expectedResult, GearCalculations.RootDiameterDr(g1), 0.0001);
        }

        [Test]
        public void Df2()
        {
            var expectedResult = 66.660;

            Assert.AreEqual(expectedResult, GearCalculations.RootDiameterDr(g2), 0.0001);
        }

        [Test]
        public void AlphaT()
        {
            var expectedResult = 20;

            Assert.AreEqual(expectedResult, GearCalculations.AlphaT(g1), 0.0001);
        }

        [Test]
        public void AlphaW()
        {
            var expectedResult = 26.0886;

            Assert.AreEqual(expectedResult, GearCalculations.AlphaW(g2), 0.0001);
        }

        [Test]
        public void InvAlphaW()
        {
            var expectedResult = 0.034316;

            Assert.AreEqual(expectedResult, GearCalculations.InvAlphaW(g2), 0.0001);
        }

        [Test]
        public void Dw1()
        {
            var expectedResult = 37.66659;

            Assert.AreEqual(expectedResult, GearCalculations.WorkingPitchDiameterDw(g1), 0.0001);
        }

        [Test]
        public void Dw2()
        {
            var expectedResult = 75.33319;

            Assert.AreEqual(expectedResult, GearCalculations.WorkingPitchDiameterDw(g2), 0.0001);
        }

        [Test]
        public void SigmaX()
        {
            var expectedResult = 0.9600;

            Assert.AreEqual(expectedResult, GearCalculations.SigmaX(g2), 0.0001);
        }

        [Test]
        public void ContactRatio()
        {
            var expectedResult = 1.20210;

            Assert.AreEqual(expectedResult, GearCalculations.ContactRatio(g2), 0.0001);
        }

        [Test]
        public void Theta1()
        {
            var expectedResult = 9.58539;

            Assert.AreEqual(expectedResult, GearCalculations.Theta(g1), 0.0001);
        }


        [Test]
        public void RotateDegrees1()
        {
            var expectedResult = 20.878708;

            Assert.AreEqual(expectedResult, GearCalculations.RotateDegrees(g1), 0.0001);
        }


        [Test]
        public void XMod()
        {
            var expectedResult = 0.0;

            Assert.AreEqual(expectedResult, GearCalculations.XMod(g1), 0.0001);
        }


        [Test]
        public void AngleToFilletCentre()
        {
            var expectedResult = 0.034302;

            Assert.AreEqual(expectedResult, GearCalculations.AngleToFilletCentre(g1), 0.0001);
        }

        [Test]
        public void PointA()
        {
            var expectedResultx = 16.04055;
            var expectedResulty = -0.55045;
            GearPoint gearPointA = GearCalculations.RootFilletStartPoint(g1);
            Assert.AreEqual(expectedResultx, gearPointA.X, 0.0001);
            Assert.AreEqual(expectedResulty, gearPointA.Y, 0.0001);
        }

        [Test]
        public void PointD()
        {
            var expectedResultx = 16.61022;
            var expectedResulty = -0.57000;
            GearPoint gearPointD = GearCalculations.RootFilletCentrePoint(g1);
            Assert.AreEqual(expectedResultx, gearPointD.X, 0.0001);
            Assert.AreEqual(expectedResulty, gearPointD.Y, 0.0001);
        }

        [Test]
        public void PointE()
        {
            var expectedResultx = 16.61022;
            var expectedResulty = -0;
            GearPoint gearPointE = GearCalculations.RootFilletEndPoint(g1);
            Assert.AreEqual(expectedResultx, gearPointE.X, 0.0001);
            Assert.AreEqual(expectedResulty, gearPointE.Y, 0.0001);
        }

        [Test]
        public void AxialPitch()
        {
            g1.HelixAngleBeta = 15;
            var expectedResult = 37.69911;

            Assert.AreEqual(expectedResult, GearCalculations.AxialPitch(g1), 0.0001);
            g1.HelixAngleBeta = 0;
        }

        [Test]
        public void HelixPitchLength()
        {
            g1.HelixAngleBeta = 15;
            var expectedResult = 37.69911 * g1.TeethZ;

            Assert.AreEqual(expectedResult, GearCalculations.HelixPitchLength(g1), 0.0001);
            g1.HelixAngleBeta = 0;
        }

        [Test]
        public void CoordinateIntersectionCircleWithInvoluteX()
        {
            var expectedResultX = 9.7363;
            Assert.AreEqual(expectedResultX, Geometry.PointOnInvolute(16.914 / 2, 19.5 / 2).X, 0.0001);
        }

        [Test]
        public void CoordinateIntersectionCircleWithInvoluteY()
        {
            var expectedResultX = 0.5150;
            Assert.AreEqual(expectedResultX, Geometry.PointOnInvolute(16.914 / 2, 19.5 / 2).Y, 0.0001);
        }

        [Test]
        public void CoordinateIntersectionCircleWithInvoluteX1()
        {
            var expectedResultX = 9.97681;
            Assert.AreEqual(expectedResultX, Geometry.PointOnInvolute(16.914 / 2, 20 / 2).X, 0.0001);
        }

        [Test]
        public void CoordinateIntersectionCircleWithInvoluteY1()
        {
            var expectedResultX = 0.68052;
            Assert.AreEqual(expectedResultX, Geometry.PointOnInvolute(16.914 / 2, 20 / 2).Y, 0.0001);
        }

        // [Test]
        // public void Update()
        // {
        //     g1.M = 13;
        // }
    }
}