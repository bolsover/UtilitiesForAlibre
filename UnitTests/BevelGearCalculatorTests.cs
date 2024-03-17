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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculatePitchDiameter(pinion, gear).Item1, 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculatePitchDiameter(pinion,gear).Item2, 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculatePitchConeAngle(pinion, gear).Item1,
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculatePitchConeAngle(pinion, gear).Item2, 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculatePitchConeDistance(pinion, gear).Item2, 0.00001);
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
            pinion.GearType = BevelGearType.Standard;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;
            gear.GearType = BevelGearType.Standard;

            var expectedResult1 = 67.08204;
            var expectedResult2 = 67.08204;
            Assert.AreEqual(expectedResult1, BevelGearCalculator.CalculatePitchConeDistance(pinion, gear).Item1, 0.00001);
            Assert.AreEqual(expectedResult2, BevelGearCalculator.CalculatePitchConeDistance(pinion, gear).Item2, 0.00001);
            pinion.GearType = BevelGearType.Gleason;
            gear.GearType = BevelGearType.Gleason;
            var expectedResult3 = 67.082039;
            var expectedResult4 = 67.082039;
            Assert.AreEqual(expectedResult3, BevelGearCalculator.CalculatePitchConeDistance(pinion, gear).Item1, 0.00001);
            Assert.AreEqual(expectedResult4, BevelGearCalculator.CalculatePitchConeDistance(pinion, gear).Item2, 0.00001);
        }

        
        [Test]
        public void CalculateAddendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.GearType = BevelGearType.Standard;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;
            gear.GearType = BevelGearType.Standard;
            
            var expectedResult1 = 3.0;
            var expectedResult2 = 3.0;
            
            Assert.AreEqual(expectedResult1, BevelGearCalculator.CalculateAddendum(pinion, gear).Item1, 0.00001);
            Assert.AreEqual(expectedResult2, BevelGearCalculator.CalculateAddendum(pinion, gear).Item2, 0.00001);
            
            pinion.GearType = BevelGearType.Gleason;
            gear.GearType = BevelGearType.Gleason;
            var expectedResult3 = 4.03500;
            var expectedResult4 = 1.9650;
            Assert.AreEqual(expectedResult3, BevelGearCalculator.CalculateAddendum(pinion, gear).Item1, 0.00001);
            Assert.AreEqual(expectedResult4, BevelGearCalculator.CalculateAddendum(pinion, gear).Item2, 0.00001);
        }
        
        [Test]
        public void CalculateDedendum()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.GearType = BevelGearType.Standard;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;
            gear.GearType = BevelGearType.Standard;

            var expectedResult1 = 3.75;
            var expectedResult2 = 3.75;
            Assert.AreEqual(expectedResult1, BevelGearCalculator.CalculateDedendum(pinion, gear).Item1, 0.00001);
            Assert.AreEqual(expectedResult2, BevelGearCalculator.CalculateDedendum(pinion, gear).Item2, 0.00001);
            
            pinion.GearType = BevelGearType.Gleason;
            gear.GearType = BevelGearType.Gleason;
            var expectedResult3 = 2.528999;
            var expectedResult4 = 4.59900;
            Assert.AreEqual(expectedResult3, BevelGearCalculator.CalculateDedendum(pinion, gear).Item1, 0.00001);
            Assert.AreEqual(expectedResult4, BevelGearCalculator.CalculateDedendum(pinion, gear).Item2, 0.00001);
        }


       

        [Test]
        public void CalculateDedendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.GearType = BevelGearType.Standard;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;
            gear.GearType = BevelGearType.Standard;

            var expectedResult1 = 3.19960;
            var expectedResult2 = 3.19960;
            Assert.AreEqual(expectedResult1, BevelGearCalculator.CalculateDedendumAngle(pinion, gear).Item1, 0.00001);
            Assert.AreEqual(expectedResult2, BevelGearCalculator.CalculateDedendumAngle(pinion, gear).Item2, 0.00001);
            
            pinion.GearType = BevelGearType.Gleason;
            gear.GearType = BevelGearType.Gleason;
            var expectedResult3 = 2.15903;
            var expectedResult4 = 3.92194;
            Assert.AreEqual(expectedResult3, BevelGearCalculator.CalculateDedendumAngle(pinion, gear).Item1, 0.00001);
            Assert.AreEqual(expectedResult4, BevelGearCalculator.CalculateDedendumAngle(pinion, gear).Item2, 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateDedendumAngle(pinion, gear).Item2, 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateAddendumAngle(pinion, gear).Item2, 0.00001);
        }

        [Test]
        public void CalculateAddendumAngle()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.GearType = BevelGearType.Standard;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;
            gear.GearType = BevelGearType.Standard;

            var expectedResult1 = 2.560638;
            var expectedResult2 = 2.560638;
            Assert.AreEqual(expectedResult1, BevelGearCalculator.CalculateAddendumAngle(pinion, gear).Item1, 0.00001);
            Assert.AreEqual(expectedResult2, BevelGearCalculator.CalculateAddendumAngle(pinion, gear).Item2, 0.00001);
            
            pinion.GearType = BevelGearType.Gleason;
            gear.GearType = BevelGearType.Gleason;
            var expectedResult3 = 3.92194;
            var expectedResult4 = 2.15903;
            Assert.AreEqual(expectedResult3, BevelGearCalculator.CalculateAddendumAngle(pinion, gear).Item1, 0.00001);
            Assert.AreEqual(expectedResult4, BevelGearCalculator.CalculateAddendumAngle(pinion, gear).Item2, 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateOuterConeAngle(pinion, gear).Item2, 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateOuterConeAngle(pinion, gear).Item1,
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateRootConeAngle(pinion, gear).Item1, 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateRootConeAngle(pinion, gear).Item2, 0.00001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculatePitchApexToCrown(pinion, gear).Item1,
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculatePitchApexToCrown(pinion, gear).Item2, 0.0001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateAxialFaceWidth(pinion, gear).Item1, 0.0001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateAxialFaceWidth(pinion, gear).Item2, 0.0001);
        }

      

        [Test]
        public void CalculateOutsideDiameter()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 3;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 20;
            pinion.FaceWidth = 22;
            pinion.GearType = BevelGearType.Standard;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 3;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 40;
            gear.FaceWidth = 22;
            gear.GearType = BevelGearType.Standard;

            var expectedResult1 =  65.36656;
            var expectedResult2 = 122.6833;
            Assert.AreEqual(expectedResult1, BevelGearCalculator.CalculateOutsideDiameter(pinion, gear).Item1, 0.0001);
            Assert.AreEqual(expectedResult2, BevelGearCalculator.CalculateOutsideDiameter(pinion, gear).Item2, 0.0001);
            
            pinion.GearType = BevelGearType.Gleason;
            gear.GearType = BevelGearType.Gleason;
            var expectedResult3 = 67.21803;
            var expectedResult4 = 121.75755;
            Assert.AreEqual(expectedResult3, BevelGearCalculator.CalculateOutsideDiameter(pinion, gear).Item1, 0.0001);
            Assert.AreEqual(expectedResult4, BevelGearCalculator.CalculateOutsideDiameter(pinion, gear).Item2, 0.0001);
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateOutsideDiameter(pinion, gear).Item1,
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateInnerOutsideDiameter(pinion, gear).Item1,
                0.0001);
        }
        
        // [Test]
        // public void CalculateStandardPinionBackConeDistance()
        // {
        //     BevelGear pinion = new BevelGear();
        //     pinion.ShaftAngle = 90;
        //     pinion.Module = 3;
        //     pinion.PressureAngle = 20;
        //     pinion.NumberOfTeeth = 20;
        //     pinion.FaceWidth = 22;
        //
        //     BevelGear gear = new BevelGear();
        //     gear.ShaftAngle = 90;
        //     gear.Module = 3;
        //     gear.PressureAngle = 20;
        //     gear.NumberOfTeeth = 40;
        //     gear.FaceWidth = 22;
        //
        //     var expectedResult = 33.54;
        //     Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardBackConeDistance(pinion, gear).Item1,
        //         0.0001);
        // }
        
        // [Test]
        // public void CalculateStandardGearBackConeDistance()
        // {
        //     BevelGear pinion = new BevelGear();
        //     pinion.ShaftAngle = 90;
        //     pinion.Module = 3;
        //     pinion.PressureAngle = 20;
        //     pinion.NumberOfTeeth = 20;
        //     pinion.FaceWidth = 22;
        //
        //     BevelGear gear = new BevelGear();
        //     gear.ShaftAngle = 90;
        //     gear.Module = 3;
        //     gear.PressureAngle = 20;
        //     gear.NumberOfTeeth = 40;
        //     gear.FaceWidth = 22;
        //
        //     var expectedResult = 30.00;
        //     Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateStandardBackConeDistance(pinion, gear).Item2,
        //         0.0001);
        // }

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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateInnerOutsideDiameter(pinion, gear).Item2,
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateTredgoldEquivalentPitchDiameter(pinion, gear).Item1,
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateTredgoldEquivalentPitchDiameter(pinion, gear).Item2,
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateTredgoldEquivalentToothCount(pinion, gear).Item1,
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateTredgoldEquivalentToothCount(pinion, gear).Item2,
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
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateRadialPressureAngle(pinion, gear).Item1, 0.00001);
        }

        // [Test]
        // public void CalculateStandardPinionBackConeAngle()
        // {
        //     var o = 30;
        //     var a = 10.39;
        //     var result = Degrees(Math.Atan(o / a));
        //     Assert.AreEqual(70.8973, result, 0.00001);
        // }
        
        [Test]
        public void CalculateStandardPinionBackConeAngle()
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

            var expectedResult = 63.43494;
            Assert.AreEqual(expectedResult, BevelGearCalculator.CalculateBackConeAngle(pinion, gear).Item1, 0.00001);
        }


        [Test]
        public void CalculateCircularThickness()
        {
            BevelGear pinion = new BevelGear();
            pinion.ShaftAngle = 90;
            pinion.Module = 5.08;
            pinion.PressureAngle = 20;
            pinion.NumberOfTeeth = 16;
            pinion.FaceWidth = 22;
            pinion.GearType = BevelGearType.Gleason;

            BevelGear gear = new BevelGear();
            gear.ShaftAngle = 90;
            gear.Module = 5.08;
            gear.PressureAngle = 20;
            gear.NumberOfTeeth = 49;
            gear.FaceWidth = 22;
            gear.GearType = BevelGearType.Gleason;

            var expectedResult1 = 9.46765;
            var expectedResult2 = 6.49163;
            Assert.AreEqual(expectedResult1, BevelGearCalculator.CalculateCircularThickness(pinion, gear).Item1, 0.0001);
            Assert.AreEqual(expectedResult2, BevelGearCalculator.CalculateCircularThickness(pinion, gear).Item2, 0.0001);
        }
        
        
    }
}