using Bolsover.Utils;
using Bolsover.WormGear.Calculator;
using NUnit.Framework;

namespace UnitTests.Worm
{
    public class WormGearCalculatorTests
    {
        [Test]
        public void Calculate_ShouldCalculateGearDimensionsCorrectly()
        {
            // Arrange
            var calculator = new WormGearCalculator
            {
                WormPitchDiameter = 23.719,
                WormThreads = 2.0,
                Module = 3.0,
                PressureAngle = 20.0,
                GearTeeth = 30.0
            };
            
            var expectedPitch = 9.424777;
            var expectedLeadAngle = 14.195846;
            var expectedGearPitchDiameter = 90.0;
            var expectedCentreDistance = 56.859499;
            var expectedAddendum = 3.0;
            var expectedDedendum = 3.75;
            var expectedWholeDepth = 6.75;
            var expectedWormOutsideDiameter = 29.719000;
            var expectedGearOutsideDiameter = 99.0;
            var expectedWormRootDiameter = 16.219000;
            var expectedGearRootDiameter = 82.5;
            var expectedThroatDiameter = 96.0;
            var expectedThroatSurfaceRadius = 8.859500;
            var expectedWormLength = 48.066367;
            var expectedGearBlankWidth = 17.906088;
            var expectedWormEstimatedPitchDiameter1 = 23.719467;
            
            // Act
            calculator.Calculate();
            
            // Assert
            Assert.AreEqual(expectedPitch, calculator.Pitch, 1e-6);
            Assert.AreEqual(expectedLeadAngle, ConversionUtils.Degrees(calculator.CalculatedLeadAngle), 1e-6);
            Assert.AreEqual(expectedGearPitchDiameter, calculator.GearPitchDiameter, 1e-6);
            Assert.AreEqual(expectedCentreDistance, calculator.EstimatedCentreDistance, 1e-6);
            Assert.AreEqual(expectedAddendum, calculator.Addendum, 1e-6);
            Assert.AreEqual(expectedDedendum, calculator.Dedendum, 1e-6);
            Assert.AreEqual(expectedWholeDepth, calculator.WholeDepth, 1e-6);
            Assert.AreEqual(expectedWormOutsideDiameter, calculator.WormOutsideDiameter, 1e-6);
            Assert.AreEqual(expectedGearOutsideDiameter, calculator.GearOutsideDiameter, 1e-6);
            Assert.AreEqual(expectedWormRootDiameter, calculator.WormRootDiameter, 1e-6);
            Assert.AreEqual(expectedGearRootDiameter, calculator.GearRootDiameter, 1e-6);
            Assert.AreEqual(expectedThroatDiameter, calculator.ThroatDiameter, 1e-6);
            Assert.AreEqual(expectedThroatSurfaceRadius, calculator.ThroatSurfaceRadius, 1e-6);
            Assert.AreEqual(expectedWormLength, calculator.WormLength, 1e-6);
            Assert.AreEqual(expectedGearBlankWidth, calculator.GearBlankWidth, 1e-6);
            Assert.AreEqual(expectedWormEstimatedPitchDiameter1, calculator.WormEstimatedPitchDiameter1, 1e-6);
        }
    }
}