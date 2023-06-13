using Bolsover.Gear.Calculators;
using Bolsover.Gear.Models;
using NUnit.Framework;

namespace UnitTests.Gear
{
    public class StandardExternalExternalSpurGearCalculatorTests
    {
        [Test]
        public void CalculateStandardInvoluteAlpha()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 20
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 40
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 0.014904;
            Assert.AreEqual(expectedResult, calculator.CalculateInvoluteAlpha(Pair), 0.00001);
        }
        
        [Test]
        public void CalculateCentreDistance()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 54d;
            Assert.AreEqual(expectedResult, calculator.CalculateCentreDistance(Pair), 0.00001);
        }
        
        [Test]
        public void CalculatePinionAddendum()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 4.41989;
            Assert.AreEqual(expectedResult, calculator.CalculatePinionAddendum(Pair), 0.00001);
        }
        
        [Test]
        public void CalculateGearAddendum()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult =3.69989;
            Assert.AreEqual(expectedResult, calculator.CalculateGearAddendum(Pair), 0.00001);
        }
        
        // [Test]
        // public void CalculateDedendum()
        // {
        //     StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
        //     Bolsover.Gear.Models.Gear Pinion = new()
        //     {
        //         Module = 3,
        //         PressureAngle = 20,
        //         NumberOfTeeth = 12
        //     };
        //
        //     Bolsover.Gear.Models.Gear gear = new ()
        //     {
        //         Module = 3,
        //         PressureAngle = 20,
        //         NumberOfTeeth = 24
        //     };
        //
        //     GearPair Pair = new GearPair();
        //     Pair.Pinion = Pinion;
        //     Pair.Gear = gear;
        //     var expectedResult = 3.75d;
        //     Assert.AreEqual(expectedResult, calculator.CalculateDedendum(gear), 0.00001);
        // }
        
        [Test]
        public void CalculatePinionWholeDepth()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();

            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 6.36989d;
            Assert.AreEqual(expectedResult, calculator.CalculatePinionWholeDepth(Pair), 0.00001);
        }
        
        [Test]
        public void CalculateGearWholeDepth()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();

            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 6.36989;
            Assert.AreEqual(expectedResult, calculator.CalculateGearWholeDepth(Pair), 0.00001);
        }
        
        [Test]
        public void CalculateWorkingPressureAngle()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 26.08862;
            Assert.AreEqual(expectedResult, calculator.CalculateWorkingPressureAngle(Pair), 0.00001);
        }
        
        [Test]
        public void CalculateInvoluteFunction()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 0.034316;
            Assert.AreEqual(expectedResult, calculator.CalculateInvoluteFunction(Pair), 0.00001);
        }
        
        [Test]
        public void CalculateCentreDistanceIncrementFactor()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 0.83329;
            Assert.AreEqual(expectedResult, calculator.CalculateCentreDistanceIncrementFactor(Pair), 0.00001);
        }
        
        
        
        [Test]
        public void CalculateGearPitchDiameter()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 72.0d;
            Assert.AreEqual(expectedResult, calculator.CalculateGearPitchDiameter(Pair), 0.00001);
        }
        
        [Test]
        public void CalculatePinionPitchDiameter()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 36.0d;
            Assert.AreEqual(expectedResult, calculator.CalculatePinionPitchDiameter(Pair), 0.00001);
        }
        
       
        
        [Test]
        public void CalculatePinionBaseDiameter()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 33.82893;
            Assert.AreEqual(expectedResult, calculator.CalculatePinionBaseDiameter(Pair), 0.00001);
        }
        
        [Test]
        public void CalculateGearBaseDiameter()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 67.65786;
            Assert.AreEqual(expectedResult, calculator.CalculateGearBaseDiameter(Pair), 0.00001);
        }
        
        [Test]
        public void CalculatePinionWorkingPitchDiameter()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 37.66659;
            Assert.AreEqual(expectedResult, calculator.CalculatePinionWorkingPitchDiameter(Pair), 0.00001);
        }
        
        [Test]
        public void CalculateGearWorkingPitchDiameter()
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 75.33319;
            Assert.AreEqual(expectedResult, calculator.CalculateGearWorkingPitchDiameter(Pair), 0.00001);
        }
        
        [Test]
        public void CalculatePinionOutsideDiameter()
        
            {
                StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
                Bolsover.Gear.Models.Gear Pinion = new()
                {
                    Module = 3,
                    PressureAngle = 20,
                    NumberOfTeeth = 12,
                    CoefficientOfProfileShift = 0.6,
                    WorkingCentreDistance = 56.4999
                };

                Bolsover.Gear.Models.Gear gear = new ()
                {
                    Module = 3,
                    PressureAngle = 20,
                    NumberOfTeeth = 24,
                    CoefficientOfProfileShift = 0.36,
                    WorkingCentreDistance = 56.4999
                };

                GearPair Pair = new GearPair();
                Pair.Pinion = Pinion;
                Pair.Gear = gear;
                var expectedResult = 44.83979;
                Assert.AreEqual(expectedResult, calculator.CalculatePinionOutsideDiameter(Pair), 0.00001);
            }
        
        [Test]
        public void CalculateGearOutsideDiameter()
        
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 79.39979;
            Assert.AreEqual(expectedResult, calculator.CalculateGearOutsideDiameter(Pair), 0.00001);
        }
        
         [Test]
        public void CalculatePinionRootDiameter()
        
            {
                StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
                Bolsover.Gear.Models.Gear Pinion = new()
                {
                    Module = 3,
                    PressureAngle = 20,
                    NumberOfTeeth = 12,
                    CoefficientOfProfileShift = 0.6,
                    WorkingCentreDistance = 56.4999
                };

                Bolsover.Gear.Models.Gear gear = new ()
                {
                    Module = 3,
                    PressureAngle = 20,
                    NumberOfTeeth = 24,
                    CoefficientOfProfileShift = 0.36,
                    WorkingCentreDistance = 56.4999
                };

                GearPair Pair = new GearPair();
                Pair.Pinion = Pinion;
                Pair.Gear = gear;
                var expectedResult = 32.09999;
                Assert.AreEqual(expectedResult, calculator.CalculatePinionRootDiameter(Pair), 0.00001);
            }
        
        [Test]
        public void CalculateGearRootDiameter()
        
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 66.659999;
            Assert.AreEqual(expectedResult, calculator.CalculateGearRootDiameter(Pair), 0.00001);
        }
        
        [Test]
        public void CalculateSumCoefficientOfProfileShift()
        
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 0.959999;
            Assert.AreEqual(expectedResult, calculator.CalculateSumCoefficientOfProfileShift(Pair), 0.00001);
        }
        
        [Test]
        public void CalculateGearBacklashModification()
        
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999,
                CircularBacklash = 0.1
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999,
                CircularBacklash = 0.1
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = -0.043765;
            Assert.AreEqual(expectedResult, calculator.CalculateGearBacklashModification(Pair), 0.00001);
        }
        
        [Test]
        public void CalculatePinionBacklashModification()
        
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999,
                CircularBacklash = 0.1
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999,
                CircularBacklash = 0.1
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = -0.043765;
            Assert.AreEqual(expectedResult, calculator.CalculatePinionBacklashModification(Pair), 0.00001);
        }

        [Test]
        public void CalculateGearHalfToothAngleAtPitchDiameter()
        
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999,
                CircularBacklash = 0.1
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999,
                CircularBacklash = 0.1
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 4.29956;
            Assert.AreEqual(expectedResult, calculator.CalculateGearHalfToothAngleAtPitchDiameter(Pair), 0.00001);
        }
        [Test]
        public void CalculatePinionHalfToothAngleAtPitchDiameter()
        
        {
            StandardExternalExternalSpurGearCalculator calculator = new StandardExternalExternalSpurGearCalculator();
            Bolsover.Gear.Models.Gear Pinion = new()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 12,
                CoefficientOfProfileShift = 0.6,
                WorkingCentreDistance = 56.4999,
                CircularBacklash = 0.1
            };

            Bolsover.Gear.Models.Gear gear = new ()
            {
                Module = 3,
                PressureAngle = 20,
                NumberOfTeeth = 24,
                CoefficientOfProfileShift = 0.36,
                WorkingCentreDistance = 56.4999,
                CircularBacklash = 0.1
            };

            GearPair Pair = new GearPair();
            Pair.Pinion = Pinion;
            Pair.Gear = gear;
            var expectedResult = 9.433282;
            Assert.AreEqual(expectedResult, calculator.CalculatePinionHalfToothAngleAtPitchDiameter(Pair), 0.00001);
        }
        
    }
}