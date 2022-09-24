using Bolsover.Gear;
using NUnit.Framework;

namespace UnitTests
{
    public class GearToothPointTests
    {
        private InvoluteGear g1 = null!;
        private InvoluteGear g2 = null!;
        private GearPair gearPair = null!;
        private ConsoleIO io = new();
        private GearToothPoints gearToothPoints = null!;

        [SetUp]
        public void Setup()
        {
            g1 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g2 = new InvoluteGear(3, 12, 20, 0, 0.6);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            gearPair = new GearPair(g1, g2, 56.4999, 0);
            // gearPair.Updated += GearPairOnUpdated;
            GearBuilder gearBuilder = new GearBuilder();
            gearToothPoints = gearBuilder.BuildGearToothPoints(gearPair, false);
            io.WriteLine(gearToothPoints.ToString());
        }

        [Test]
        public void GearCentreX()
        {
            var expectedResult = 0;
            Assert.AreEqual(expectedResult, gearToothPoints.GearCentre.X, 0.0);
        }

        [Test]
        public void GearCentreY()
        {
            var expectedResult = 0;
            Assert.AreEqual(expectedResult, gearToothPoints.GearCentre.X, 0.0);
        }

        [Test]
        public void RightInvolute0X()
        {
            var expectedResult = 16.91;
            Assert.AreEqual(expectedResult, gearToothPoints.RightInvolute[0].X, 0.02);
        }

        [Test]
        public void RightInvolute0Y()
        {
            var expectedResult = 0.0;
            Assert.AreEqual(expectedResult, gearToothPoints.RightInvolute[0].Y, 0.0);
        }

        [Test]
        public void RightInvolute10X()
        {
            var expectedResult = 19.09;
            Assert.AreEqual(expectedResult, gearToothPoints.RightInvolute[10].X, 0.01);
        }

        [Test]
        public void RightInvolute10Y()
        {
            var expectedResult = 0.800;
            Assert.AreEqual(expectedResult, gearToothPoints.RightInvolute[10].Y, 0.01);
        }

        [Test]
        public void RightInvoluteMaxX()
        {
            var expectedResult = 22.08;
            int count = gearToothPoints.RightInvolute.Count - 1;
            Assert.AreEqual(expectedResult, gearToothPoints.RightInvolute[count].X, 0.01);
        }

        [Test]
        public void RightInvoluteMaxY()
        {
            var expectedResult = 3.35;
            int count = gearToothPoints.RightInvolute.Count - 1;
            Assert.AreEqual(expectedResult, gearToothPoints.RightInvolute[count].Y, 0.01);
        }

        [Test]
        public void RightTipReliefStartX()
        {
            var expectedResultX = 22.08;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightTipReliefStart.X, 0.01);
        }

        [Test]
        public void RightTipReliefStartY()
        {
            var expectedResultX = 3.35;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightTipReliefStart.Y, 0.01);
        }

        [Test]
        public void RightTipReliefCentreX()
        {
            var expectedResultX = 21.88;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightTipReliefCentre.X, 0.01);
        }

        [Test]
        public void RightTipReliefCentreY()
        {
            var expectedResultX = 3.51;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightTipReliefCentre.Y, 0.01);
        }

        [Test]
        public void RightTipReliefEndX()
        {
            var expectedResultX = 22.14;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightTipReliefEnd.X, 0.01);
        }

        [Test]
        public void RightTipReliefEndY()
        {
            var expectedResultX = 3.56;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightTipReliefEnd.Y, 0.01);
        }

        [Test]
        public void RightMidRootX()
        {
            var expectedResultX = 15.99;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightMidRoot.X, 0.01);
        }


        [Test]
        public void RightMidRootY()
        {
            var expectedResultX = -1.27;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightMidRoot.Y, 0.01);
        }

        [Test]
        public void LeftMidRootX()
        {
            var expectedResultX = 14.49;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftMidRoot.X, 0.01);
        }


        [Test]
        public void LeftMidRootY()
        {
            var expectedResultX = 6.89;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftMidRoot.Y, 0.01);
        }


        [Test]
        public void RightRootFilletStartX()
        {
            var expectedResultX = 16.04;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightRootFilletStart.X, 0.01);
        }

        [Test]
        public void RightRootFilletStartY()
        {
            var expectedResultX = -0.55;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightRootFilletStart.Y, 0.01);
        }

        [Test]
        public void RightRootFilletCentreX()
        {
            var expectedResultX = 16.61;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightRootFilletCentre.X, 0.01);
        }

        [Test]
        public void RightRootFilletCentreY()
        {
            var expectedResultX = -0.57;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightRootFilletCentre.Y, 0.01);
        }

        [Test]
        public void RightRootFilletEndX()
        {
            var expectedResultX = 16.61;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightRootFilletEnd.X, 0.01);
        }

        [Test]
        public void RightRootFilletEndY()
        {
            var expectedResultX = 0.0;
            Assert.AreEqual(expectedResultX, gearToothPoints.RightRootFilletEnd.Y, 0.01);
        }

        [Test]
        public void LeftInvolute0X()
        {
            var expectedResult = 15.81;
            Assert.AreEqual(expectedResult, gearToothPoints.LeftInvolute[0].X, 0.02);
        }

        [Test]
        public void LeftInvolute0Y()
        {
            var expectedResult = 6.028;
            Assert.AreEqual(expectedResult, gearToothPoints.LeftInvolute[0].Y, 0.01);
        }

        [Test]
        public void LeftInvolute10X()
        {
            var expectedResult = 18.13;
            Assert.AreEqual(expectedResult, gearToothPoints.LeftInvolute[10].X, 0.01);
        }

        [Test]
        public void LeftInvolute10Y()
        {
            var expectedResult = 6.05;
            Assert.AreEqual(expectedResult, gearToothPoints.LeftInvolute[10].Y, 0.01);
        }

        [Test]
        public void LeftInvoluteMaxX()
        {
            var expectedResult = 21.82;
            int count = gearToothPoints.LeftInvolute.Count - 1;
            Assert.AreEqual(expectedResult, gearToothPoints.LeftInvolute[count].X, 0.01);
        }

        [Test]
        public void LeftInvoluteMaxY()
        {
            var expectedResult = 4.73;
            int count = gearToothPoints.LeftInvolute.Count - 1;
            Assert.AreEqual(expectedResult, gearToothPoints.LeftInvolute[count].Y, 0.01);
        }

        [Test]
        public void LeftRootFilletStartX()
        {
            var expectedResultX = 14.79;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftRootFilletStart.X, 0.01);
        }

        [Test]
        public void LeftRootFilletStartY()
        {
            var expectedResultX = 6.23;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftRootFilletStart.Y, 0.01);
        }

        [Test]
        public void LeftRootFilletCentreX()
        {
            var expectedResultX = 15.31;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftRootFilletCentre.X, 0.01);
        }

        [Test]
        public void LeftRootFilletCentreY()
        {
            var expectedResultX = 6.45;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftRootFilletCentre.Y, 0.01);
        }

        [Test]
        public void LeftRootFilletEndX()
        {
            var expectedResultX = 15.51;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftRootFilletEnd.X, 0.01);
        }

        [Test]
        public void LeftRootFilletEndY()
        {
            var expectedResultX = 5.91;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftRootFilletEnd.Y, 0.01);
        }

        [Test]
        public void LeftTipReliefStartX()
        {
            var expectedResultX = 21.82;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftTipReliefStart.X, 0.01);
        }

        [Test]
        public void LeftTipReliefStartY()
        {
            var expectedResultX = 4.74;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftTipReliefStart.Y, 0.01);
        }

        [Test]
        public void LeftTipReliefCentreX()
        {
            var expectedResultX = 21.70;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftTipReliefCentre.X, 0.01);
        }

        [Test]
        public void LeftTipReliefCentreY()
        {
            var expectedResultX = 4.51;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftTipReliefCentre.Y, 0.01);
        }

        [Test]
        public void LeftTipReliefEndX()
        {
            var expectedResultX = 21.94;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftTipReliefEnd.X, 0.01);
        }

        [Test]
        public void LeftTipReliefEndY()
        {
            var expectedResultX = 4.57;
            Assert.AreEqual(expectedResultX, gearToothPoints.LeftTipReliefEnd.Y, 0.01);
        }
    }
}