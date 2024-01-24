using Bolsover.Involute.Calculator;
using Bolsover.Involute.Model;
using NUnit.Framework;

namespace UnitTests.Involute.Calculator
{
    public class ProfileShiftedIntExtSpurGearCalculatorTest
    {
        private IGearPairDesignInputParams _designInputParams;
        private IGearPairDesignOutputParams _designPairOutputParams;
        private ProfileShiftedIntExtSpurGearCalculator _calculator;
        private ConsoleIO io = new();

        [SetUp]
        public void SetUp()
        {
            _designInputParams = new GearPairDesignInputParams();

            var gear = new GearDesignInputParams();
            var pinion = new GearDesignInputParams();
            _designInputParams.Gear = gear;
            _designInputParams.Pinion = pinion;
            gear.GearPairDesign = _designInputParams;
            pinion.GearPairDesign = _designInputParams;

            _designInputParams.Auto = true;

            _designPairOutputParams = new GearPairDesignOutputParams();

            _calculator = new ProfileShiftedIntExtSpurGearCalculator(_designInputParams, _designPairOutputParams);
        }

    

        [Test]
        public void CalculateCentreDistance()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 12.0d;
            Assert.AreEqual(expected, _calculator.CalculateCentreDistance(_designInputParams), 0.001);
        }


        [Test]
        public void CalculateCentreDistanceIncrementFactor()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 0.38943;
            Assert.AreEqual(expected, _calculator.CalculateCentreDistanceIncrementFactor(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculatePitchDiameter()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 48.0d;
            var expected2 = 72.0d;
            var result = _calculator.CalculatePitchDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateBaseDiameter()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 45.1052;
            var expected2 = 67.6578;
            var result = _calculator.CalculateBaseDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateWorkingPressureAngle()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected =31.0938;
            Assert.AreEqual(expected, _calculator.CalculateWorkingPressureAngle(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateWorkingInvoluteFunction()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 0.060401;
            Assert.AreEqual(expected, _calculator.CalculateWorkingInvoluteFunction(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateInvoluteFunction()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 0.01490;
            Assert.AreEqual(expected, _calculator.CalculateInvoluteFunction(_designInputParams).Item1, 0.001);
        }
        
        [Test]
        public void CalculateDifferenceCoefficientOfProfileShift()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 0.5000;
             Assert.AreEqual(expected, _calculator.CalculateDifferenceCoefficientOfProfileShift(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateAddendum()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 3.0d;
            var expected2 = 1.5d;
            var result = _calculator.CalculateAddendum(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateDedendum()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 3.75d;
            var expected2 = 5.25d;
            var result = _calculator.CalculateDedendum(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateOutsideDiameter()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 54.0d;
            var expected2 = 69.0d;
            var result = _calculator.CalculateOutsideDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateRootDiameter()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 40.5d;
            var expected2 = 82.5d;
            var result = _calculator.CalculateRootDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateWorkingPitchDiameter()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 52.6731d;
            var expected2 = 79.0097d;
            var result = _calculator.CalculateWorkingPitchDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateContactRatioAlpha()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 1.6795;
            Assert.AreEqual(expected, _calculator.CalculateContactRatioAlpha(_designInputParams), 0.001);
          
        }
        
        [Test]
        public void ToGearString()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

          _calculator.Calculate();
          io.WriteLine(_calculator.CalculateGearString(_designInputParams, _designPairOutputParams));


        }
        
        // zero backlash specified
        [Test]
        public void CalculateProfileShiftModificationForBacklash()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected =0;
            var actual = _calculator.CalculateProfileShiftModificationForBacklash(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        // backlash specified
        [Test]
        public void CalculateProfileShiftModificationForBacklash1()
        {
            _designInputParams.WorkingCentreDistance = 13.1683;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.1;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.1;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected =-0.04172;
            var actual = _calculator.CalculateProfileShiftModificationForBacklash(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculatePhi()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external helical gear

            var expected1 = 0.85395d;
            var expected2 = 0.85395d;
            var result = _calculator.CalculatePhi(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
    }
}