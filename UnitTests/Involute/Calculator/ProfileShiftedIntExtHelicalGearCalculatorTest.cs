using Bolsover.Involute.Calculator;
using Bolsover.Involute.Model;
using NUnit.Framework;

namespace UnitTests.Involute.Calculator
{
    public class ProfileShiftedIntExtHelicalGearCalculatorTest
     {
        private IGearPairDesignInputParams _designInputParams;
        private IGearPairDesignOutputParams _designOutputParams;
        private ProfileShiftedIntExtHelicalGearCalculator _calculator;
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

           _designOutputParams = new GearPairDesignOutputParams();

            _calculator = new ProfileShiftedIntExtHelicalGearCalculator(_designInputParams, _designOutputParams);
        }

    

        [Test]
        public void CalculateCentreDistance()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 13.8564d;
            Assert.AreEqual(expected, _calculator.CalculateCentreDistance(_designInputParams), 0.001);
        }


        [Test]
        public void CalculateCentreDistanceIncrementFactor()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 0.0478645d;
            Assert.AreEqual(expected, _calculator.CalculateCentreDistanceIncrementFactor(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateCentreDistanceIncrementFactor1()
        {
            _designInputParams.WorkingCentreDistance = 12.2;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 10.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.005;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 10.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 0.004960d;
            Assert.AreEqual(expected, _calculator.CalculateCentreDistanceIncrementFactor(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculatePitchDiameter()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 =55.4256d;
            var expected2 = 83.1384d;
            var result = _calculator.CalculatePitchDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateBaseDiameter()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 = 51.0963d;
            var expected2 = 76.6445d;
            var result = _calculator.CalculateBaseDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        
        
        [Test]
        public void CalculateInvoluteFunction()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 0.01490;
            Assert.AreEqual(expected, _calculator.CalculateInvoluteFunction(_designInputParams).Item1, 0.001);
        }
        
        [Test]
        public void CalculateDifferenceCoefficientOfProfileShift()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 0.042633;
             Assert.AreEqual(expected, _calculator.CalculateDifferenceCoefficientOfProfileShift(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateRadialPressureAngle()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 22.79587;
            Assert.AreEqual(expected, _calculator.CalculateRadialPressureAngle(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateRadialWorkingInvoluteFunction()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 0.0268929;
            Assert.AreEqual(expected, _calculator.CalculateRadialWorkingInvoluteFunction(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateRadialWorkingPressureAngle()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 24.1558;
            Assert.AreEqual(expected, _calculator.CalculateRadialWorkingPressureAngle(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateAddendum()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 = 3.0d;
            var expected2 = 2.872d;
            var result = _calculator.CalculateAddendum(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateDedendum()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 = 3.75d;
            var expected2 = 3.8778d;
            var result = _calculator.CalculateDedendum(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateOutsideDiameter()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 = 61.4256d;
            var expected2 = 77.3942d;
            var result = _calculator.CalculateOutsideDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateRootDiameter()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 = 47.9256d;
            var expected2 = 90.8942d;
            var result = _calculator.CalculateRootDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateRootDiameter1()
        {
            _designInputParams.WorkingCentreDistance = 12.1852;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 10.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 10.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 = 41.2404d;
            var expected2 = 80.611d;
            var result = _calculator.CalculateRootDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateWorkingPitchDiameter()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 = 56.0d;
            var expected2 = 84.0d;
            var result = _calculator.CalculateWorkingPitchDiameter(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateContactRatioAlpha()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 1.7345;
            Assert.AreEqual(expected, _calculator.CalculateContactRatioAlpha(_designInputParams), 0.001);
          
        }
        
        [Test]
        public void CalculateContactRatioAlpha1()
        {
            _designInputParams.WorkingCentreDistance = 13;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 10.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.322;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 10.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 1.92100;
            Assert.AreEqual(expected, _calculator.CalculateContactRatioAlpha(_designInputParams), 0.001);
          
        }
        
        [Test]
        public void CalculateContactRatioBeta()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected = 1.0610;
            Assert.AreEqual(expected, _calculator.CalculateContactRatioBeta(_designInputParams), 0.001);
          
        }
        
        // [Test]
        // public void ToGearString()
        // {
        //     _designInputParams.WorkingCentreDistance = 14.000;
        //
        //     _designInputParams.Gear.Module = 3.0;
        //     _designInputParams.Gear.PressureAngle = 20.0;
        //     _designInputParams.Gear.HelixAngle = 30.0;
        //     _designInputParams.Gear.Teeth = 24.0;
        //     _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
        //     _designInputParams.Gear.AddendumFilletFactor = 0.25;
        //     _designInputParams.Gear.RootFilletFactor = 0.38;
        //     _designInputParams.Gear.CircularBacklash = 0.0;
        //     _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear
        //
        //     _designInputParams.Pinion.Module = 3.0;
        //     _designInputParams.Pinion.PressureAngle = 20.0;
        //     _designInputParams.Pinion.HelixAngle = 30.0;
        //     _designInputParams.Pinion.Teeth = 16.0;
        //     _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
        //     _designInputParams.Pinion.AddendumFilletFactor = 0.25;
        //     _designInputParams.Pinion.RootFilletFactor = 0.38;
        //     _designInputParams.Pinion.CircularBacklash = 0.0;
        //     _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        //
        //   _calculator.Calculate();
        //   io.WriteLine(_calculator.CalculateGearString(_designInputParams, _designOutputParams));
        //
        //
        // }
        
          // zero backlash specified
        [Test]
        public void CalculateProfileShiftModificationForBacklash()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected =0;
            var actual = _calculator.CalculateProfileShiftModificationForBacklash(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        // backlash specified
        [Test]
        public void CalculateProfileShiftModificationForBacklash1()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.1;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.1;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear


            var expected =-0.0392;
            var actual = _calculator.CalculateProfileShiftModificationForBacklash(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculateAxialPitch()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 = 21.7655d;
            var expected2 = 21.7655d;
            var result = _calculator.CalculateAxialPitch(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculateAxialPitch1()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 15;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 15;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 = 37.6991d;
            var expected2 = 37.6991d;
            var result = _calculator.CalculateAxialPitch(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        [Test]
        public void CalculatePhi()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.04263;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            var expected1 = 1.28419d;
            var expected2 = 1.28419d;
            var result = _calculator.CalculatePhi(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
    }
}