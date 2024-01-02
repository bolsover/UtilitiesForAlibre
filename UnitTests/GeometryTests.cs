using Bolsover.Gear;
using Bolsover.Gear.Calculators;
using Bolsover.Gear.Models;
using NUnit.Framework;

namespace UnitTests
{
    public class GeometryTests
    {
        [Test]
        public void LineLengthToInnerGearAddendumRelief1()
        {
            double addendumRadius = 10;
            double baseRadius = 8;
            double reliefRadius = 1;

            var expectedResultX = 7.549834;
            Assert.AreEqual(expectedResultX,
                GearCalculations.DistanceBaseTangentPointToInnerGearAddendumRelief(baseRadius, addendumRadius, reliefRadius),
                0.00001);
        }

        [Test]
        public void LineLengthToInnerGearAddendumRelief2()
        {
            double addendumRadius = 8;
            double baseRadius = 10;
            double reliefRadius = 1;

            var expectedResultX = 4.5825756;
            Assert.AreEqual(expectedResultX,
                GearCalculations.DistanceBaseTangentPointToInnerGearAddendumRelief(baseRadius, addendumRadius, reliefRadius),
                0.00001);
        }


        [Test]
        public void LineLengthToInnerGearAddendumRelief3()
        {
            double addendumRadius = 66 / 2d;
            double baseRadius = 67.65787 / 2;
            double reliefRadius = 1.14 / 2;

            var expectedResultX = 6.2361755;
            Assert.AreEqual(expectedResultX,
                GearCalculations.DistanceBaseTangentPointToInnerGearAddendumRelief(baseRadius, addendumRadius, reliefRadius),
                0.00001);
        }


        [Test]
        public void LineLengthToInnerGearAddendumRelief4()
        {
            // M3 Z1 = 16, Z2 = 40, a = 36, rf = .38 
            double addendumRadius = 114 / 2d;
            double baseRadius = 112.763 / 2;
            double reliefRadius = 1.14 / 2;

            var expectedResultX = 11.63749;
            Assert.AreEqual(expectedResultX,
                GearCalculations.DistanceBaseTangentPointToInnerGearAddendumRelief(baseRadius, addendumRadius, reliefRadius),
                0.00001);
        }

        [Test]
        public void InnerGearTipReliefCentreToBaseTangentAngle1()
        {
            InvoluteGear gear = new InvoluteGear(3, 40, 20, 0, 0);
            gear.GearTypeEnum = GearTypeEnum.Internal;
            gear.RootFilletFactorRf = .38;
            gear.MatingGear = new InvoluteGear(3, 16, 20, 0, 0);
            gear.MatingGear.GearTypeEnum = GearTypeEnum.External;
            gear.MatingGear.RootFilletFactorRf = .38;
            var expectedResultX = 78.33785;
            Assert.AreEqual(expectedResultX, GearCalculations.InnerGearTipReliefCentreToBaseTangentAngle(gear), 0.00001);
        }

        [Test]
        public void InnerGearTipReliefCentreToBaseTangentAngle2()
        {
            InvoluteGear gear = new InvoluteGear(3, 24, 20, 0, 0);
            gear.GearTypeEnum = GearTypeEnum.Internal;
            gear.RootFilletFactorRf = .38;
            gear.MatingGear = new InvoluteGear(3, 16, 20, 0, 0);
            gear.MatingGear.GearTypeEnum = GearTypeEnum.External;
            gear.MatingGear.RootFilletFactorRf = .38;
            var expectedResultX = 79.5551;
            Assert.AreEqual(expectedResultX, GearCalculations.InnerGearTipReliefCentreToBaseTangentAngle(gear), 0.00001);
        }


        [Test]
        public void CosineRuleAngle1()
        {
            var sideA = 3;
            var sideB = 4;
            var sideC = 5;
            var expectedResult = 90;
            var result = Geometry.CosineRuleAngle(sideC, sideA, sideB);
            Assert.AreEqual(expectedResult, result, 0.00001);
        }


        [Test]
        public void CalcAddendumFilletPoints()
        {
            InvoluteGear gear = new InvoluteGear(3, 40, 20, 0, 0);
            gear.GearTypeEnum = GearTypeEnum.Internal;
            gear.RootFilletFactorRf = .38;
            gear.MatingGear = new InvoluteGear(3, 16, 20, 0, 0);
            gear.MatingGear.GearTypeEnum = GearTypeEnum.External;
            gear.MatingGear.RootFilletFactorRf = .38;

            GearCalculations.CalcAddendumFilletPoints(gear);
        }
    }
}