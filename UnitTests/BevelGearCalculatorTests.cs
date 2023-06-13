using System;
using Bolsover.Bevel;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Presenters;
using NUnit.Framework;

namespace UnitTests
{
    public class BevelGearCalculatorTests
    {
        [Test]
        public void CalculateStandardPinionPitchDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 60;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionPitchDiameter(pinion), 0.00001);
        }

        [Test]
        public void CalculateStandardGearPitchDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 120;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearPitchDiameter(gear), 0.00001);
        }

        [Test]
        public void CalculateStandardPinionPitchConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 26.56505;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionPitchConeAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateStandardGearPitchConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 63.43495;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearPitchConeAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateConeDistance()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 67.08204;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateConeDistance(pinion, gear), 0.00001);
        }


        [Test]
        public void CalculateGleasonPinionAddendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 4.035;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonPinionAddendum(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonGearAddendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 1.965;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonGearAddendum(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateStandardPinionAddendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 3.0;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionAddendum(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateStandardGearAddendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 3.0;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearAddendum(pinion, gear), 0.00001);
        }


        [Test]
        public void CalculateStandardPinionDedendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 3.75;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionDedendum(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateStandardGearDedendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 3.75;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearDedendum(pinion, gear), 0.00001);
        }


        [Test]
        public void CalculateGleasonPinionDedendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 2.529;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonPinionDedendum(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonGearDedendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 4.599;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonGearDedendum(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonPinionDedendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 2.15903;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonPinionDedendumAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonGearDedendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 3.92194;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonGearDedendumAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateStandardPinionDedendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 3.19960;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionDedendumAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateStandardGearDedendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 3.19960;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearDedendumAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonPinionAddendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 3.92194;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonPinionAddendumAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonGearAddendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 2.15903;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonGearAddendumAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonGearOuterConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 65.59398;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonGearOuterConeAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonPinionOuterConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 30.48699;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonPinionOuterConeAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateStandardGearAddendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 2.56064;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearAddendumAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateStandardPinionAddendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 2.56064;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionAddendumAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateStandardGearOuterConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 65.99559;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearOuterConeAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateStandardPinionOuterConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 29.12569;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionOuterConeAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateStandardPinionRootConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 23.36545;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionRootConeAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateStandardGearRootConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 60.23535;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearRootConeAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonPinionRootConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 24.40602;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonPinionRootConeAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonGearRootConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 59.51301;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonGearRootConeAngle(pinion, gear), 0.00001);
        }


        [Test]
        public void CalculateGleasonPinionPitchApexToCrown()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 58.1955;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonPinionPitchApexToCrown(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonGearPitchApexToCrown()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 28.2425;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonGearPitchApexToCrown(pinion, gear), 0.0001);
        }

        [Test]
        public void CalculateStandardPinionPitchApexToCrown()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 58.6584;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionPitchApexToCrown(pinion, gear),
                0.0001);
        }

        [Test]
        public void CalculateStandardGearPitchApexToCrown()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 27.3167;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearPitchApexToCrown(pinion, gear), 0.0001);
        }

        [Test]
        public void CalculateStandardPinionAxialFaceWidth()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 19.2374;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionAxialFaceWidth(pinion, gear), 0.0001);
        }

        [Test]
        public void CalculateStandardGearAxialFaceWidth()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 8.9587;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearAxialFaceWidth(pinion, gear), 0.0001);
        }

        [Test]
        public void CalculateGleasonPinionAxialFaceWidth()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 19.0029;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonPinionAxialFaceWidth(pinion, gear), 0.0001);
        }

        [Test]
        public void CalculateGleasonGearAxialFaceWidth()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 9.0969;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonGearAxialFaceWidth(pinion, gear), 0.0001);
        }

        [Test]
        public void CalculateGleasonGearOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 121.7575;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonGearOutsideDiameter(pinion, gear), 0.0001);
        }

        [Test]
        public void CalculateGleasonPinionOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 67.2180;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonPinionOutsideDiameter(pinion, gear), 0.0001);
        }

        [Test]
        public void CalculateStandardGearOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 122.6833;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearOutsideDiameter(pinion, gear), 0.0001);
        }

        [Test]
        public void CalculateStandardPinionOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 65.3666;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionOutsideDiameter(pinion, gear),
                0.0001);
        }


        [Test]
        public void CalculateStandardPinionInnerOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 43.9292;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionInnerOutsideDiameter(pinion, gear),
                0.0001);
        }

        [Test]
        public void CalculateStandardGearInnerOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 82.4485;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearInnerOutsideDiameter(pinion, gear),
                0.0001);
        }

        [Test]
        public void CalculateGleasonPinionInnerOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 44.8425;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonPinionInnerOutsideDiameter(pinion, gear),
                0.0001);
        }

        [Test]
        public void CalculateGleasonGearInnerOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 81.6609;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonGearInnerOutsideDiameter(pinion, gear),
                0.0001);
        }

        [Test]
        public void CalculateTredgoldPinionEquivalentPitchDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 67.082;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateTredgoldPinionEquivalentPitchDiameter(pinion, gear),
                0.0001);
        }

        [Test]
        public void CalculateTredgoldGearEquivalentPitchDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 268.3281;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateTredgoldGearEquivalentPitchDiameter(pinion, gear),
                0.0001);
        }

        [Test]
        public void CalculateTredgoldPinionEquivalentToothCount()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 22.3606;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateTredgoldPinionEquivalentToothCount(pinion, gear),
                0.0001);
        }

        [Test]
        public void CalculateTredgoldGearEquivalentToothCount()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22
            };

            var expectedResult = 89.4427;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateTredgoldGearEquivalentToothCount(pinion, gear),
                0.0001);
        }

        [Test]
        public void CalculatePinionRadialPressureAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 23.95680;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculatePinionRadialPressureAngle(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralGearAddendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 1.6725;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearAddendum(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionAddendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 3.42749;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralPinionAddendum(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionDedendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 2.23650;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralPinionDedendum(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralGearDedendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 3.99149;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearDedendum(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionDedendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 1.90952;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralPinionDedendumAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionAddendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 3.405185;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralPinionAddendumAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralGearDedendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 3.405185;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearDedendumAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralGearAddendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 1.90952;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearAddendumAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralGearOuterConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 65.344469;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearOuterConeAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionOuterConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 29.970236;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralPinionOuterConeAngle(pinion, gear),
                0.00001);
        }


        [Test]
        public void CalculateGleasonSpiralGearPitchConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 63.434948;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearPitchConeAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralGearRootConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 60.02976;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearRootConeAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionPitchConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 26.56505;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralPinionPitchConeAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionRootConeAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 24.65553;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralPinionRootConeAngle(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralGearOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 121.495929;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearOutsideDiameter(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 66.13129;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralPinionOutsideDiameter(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralGearPitchApexToCrown()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 28.50407;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearPitchApexToCrown(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionPitchApexToCrown()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 22,
                SpiralAngle = 35
            };

            var expectedResult = 58.46717;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralPinionPitchApexToCrown(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionInnerOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 20;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 20,
                SpiralAngle = 35
            };

            var expectedResult = 46.11395;
            Assert.AreEqual(expectedResult,
                BevelGearCalculator.CalculateGleasonSpiralPinionInnerOutsideDiameter(pinion, gear), 0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralGearInnerOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 20;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 20,
                SpiralAngle = 35
            };

            var expectedResult = 85.12244;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearInnerOutsideDiameter(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralGearAxialFaceWidth()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 20;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 20,
                SpiralAngle = 35
            };

            var expectedResult = 8.34787;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralGearAxialFaceWidth(pinion, gear),
                0.00001);
        }

        [Test]
        public void CalculateGleasonSpiralPinionAxialFaceWidth()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 20;
            pinion.SpiralAngle = 35;

            BevelGear gear = new BevelGear
            {
                ShaftAngle = 90,
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40,
                FaceWidth = 20,
                SpiralAngle = 35
            };

            var expectedResult = 17.35634;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGleasonSpiralPinionAxialFaceWidth(pinion, gear),
                0.00001);
        }
    }
}