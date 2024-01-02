using Bolsover.Involute.Calculator;
using Bolsover.Involute.Model;
using NUnit.Framework;

namespace UnitTests.Involute.Calculator
{
    public class ProfileShiftedIntExtSpurGearCalculatorTest
    {
        private IGearPairDesignInputParams _designPairInputParams;
        private IGearPairDesignOutputParams _designPairOutputParams;
        private ProfileShiftedIntExtSpurGearCalculator _calculator;
        private ConsoleIO io = new();

        [SetUp]
        public void SetUp()
        {
            _designPairInputParams = new GearPairDesignInputParams();

            var gear = new GearDesignInputParams();
            var pinion = new GearDesignInputParams();
            _designPairInputParams.Gear = gear;
            _designPairInputParams.Pinion = pinion;
            gear.GearPairDesign = _designPairInputParams;
            pinion.GearPairDesign = _designPairInputParams;

            _designPairInputParams.Auto = true;

            _designPairOutputParams = new GearPairDesignOutputParams();

            _calculator = new ProfileShiftedIntExtSpurGearCalculator(_designPairInputParams, _designPairOutputParams);
        }

    

        [Test]
        public void CalculateCentreDistance()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 12.0d;
            Assert.AreEqual(expected, _calculator.CalculateCentreDistance(_designPairInputParams), 0.001);
        }


        [Test]
        public void CalculateCentreDistanceIncrementFactor()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 0.38943;
            Assert.AreEqual(expected, _calculator.CalculateCentreDistanceIncrementFactor(_designPairInputParams), 0.001);
        }
        
        [Test]
        public void CalculatePitchDiameter()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 48.0d;
            var expected2 = 72.0d;
            var result = _calculator.CalculatePitchDiameter(_designPairInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateBaseDiameter()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 45.1052;
            var expected2 = 67.6578;
            var result = _calculator.CalculateBaseDiameter(_designPairInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateWorkingPressureAngle()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected =31.0938;
            Assert.AreEqual(expected, _calculator.CalculateWorkingPressureAngle(_designPairInputParams), 0.001);
        }
        
        [Test]
        public void CalculateWorkingInvoluteFunction()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 0.060401;
            Assert.AreEqual(expected, _calculator.CalculateWorkingInvoluteFunction(_designPairInputParams), 0.001);
        }
        
        [Test]
        public void CalculateInvoluteFunction()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 0.01490;
            Assert.AreEqual(expected, _calculator.CalculateInvoluteFunction(_designPairInputParams), 0.001);
        }
        
        [Test]
        public void CalculateDifferenceCoefficientOfProfileShift()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 0.5000;
             Assert.AreEqual(expected, _calculator.CalculateDifferenceCoefficientOfProfileShift(_designPairInputParams), 0.001);
        }
        
        [Test]
        public void CalculateAddendum()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 3.0d;
            var expected2 = 1.5d;
            var result = _calculator.CalculateAddendum(_designPairInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateDedendum()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 3.75d;
            var expected2 = 5.25d;
            var result = _calculator.CalculateDedendum(_designPairInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateOutsideDiameter()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 54.0d;
            var expected2 = 69.0d;
            var result = _calculator.CalculateOutsideDiameter(_designPairInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateRootDiameter()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 40.5d;
            var expected2 = 82.5d;
            var result = _calculator.CalculateRootDiameter(_designPairInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateWorkingPitchDiameter()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 52.6731d;
            var expected2 = 79.0097d;
            var result = _calculator.CalculateWorkingPitchDiameter(_designPairInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateContactRatioAlpha()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 1.6795;
            Assert.AreEqual(expected, _calculator.CalculateContactRatioAlpha(_designPairInputParams), 0.001);
          
        }
        
        [Test]
        public void ToGearString()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

          _calculator.Calculate();
          io.WriteLine(_calculator.CalculateGearString(_designPairInputParams, _designPairOutputParams));


        }
        
        // zero backlash specified
        [Test]
        public void CalculateProfileShiftModificationForBacklash()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected =0;
            var actual = _calculator.CalculateProfileShiftModificationForBacklash(_designPairInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        // backlash specified
        [Test]
        public void CalculateProfileShiftModificationForBacklash1()
        {
            _designPairInputParams.WorkingCentreDistance = 13.1683;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0.0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0.5;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.1;
            _designPairInputParams.Gear.Style = GearStyle.Internal | GearStyle.Spur; // configures the gear as an external helical gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0.0;
            _designPairInputParams.Pinion.Teeth = 16.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.1;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected =-0.04172;
            var actual = _calculator.CalculateProfileShiftModificationForBacklash(_designPairInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}