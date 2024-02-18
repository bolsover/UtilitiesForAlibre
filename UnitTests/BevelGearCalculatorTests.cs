using System;
using Bolsover.Bevel;
using Bolsover.Bevel.Calculator;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Presenters;
using NUnit.Framework;
using static Bolsover.Utils.ConversionUtils;

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
        public void CalculateGearConeDistance()
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateGearConeDistance(pinion, gear), 0.00001);
        }
        
        [Test]
        public void CalculatePinionConeDistance()
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculatePinionConeDistance(pinion, gear), 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionAddendum(pinion), 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearAddendum(gear), 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionDedendum(pinion), 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearDedendum(gear), 0.00001);
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
        public void CalculateStandardPinionBackConeDistance()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 30;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;

            var expectedResult = 33.75;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardPinionBackConeDistance(pinion, gear),
                0.0001);
        }
        
        [Test]
        public void CalculateStandardGearBackConeDistance()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 30;
            pinion.FaceWidth = 22;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 100;
            gear.FaceWidth = 22;

            var expectedResult = 500.00;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardGearBackConeDistance(pinion, gear),
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
        public void CalculateStandardPinionBackConeAngle()
        {
            var o = 30;
            var a = 10.39;
            var result = Degrees(Math.Atan(o / a));
            Assert.AreEqual(70, result, 0.00001);
        }

    }
}