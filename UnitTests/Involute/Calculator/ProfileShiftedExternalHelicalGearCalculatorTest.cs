using Bolsover.Involute.Model;

namespace UnitTests.Involute.Calculator
{
    using Bolsover.Involute.Calculator;
    using NUnit.Framework;

    [TestFixture]
    public class ProfileShiftedExternalHelicalGearCalculatorTest
    {
        private IGearPairDesignInputParams _designInputParams;
        private IGearPairDesignOutputParams _designOutputParams;
        private ProfileShiftedExternalHelicalGearCalculator _calculator;
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

            _calculator = new ProfileShiftedExternalHelicalGearCalculator(_designInputParams, _designOutputParams);
        }
        
        [Test]
        public void CalculateRadialModule()
        {
            _designInputParams.WorkingCentreDistance = 125.0;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear

            var expected = 3.46410d;
            Assert.AreEqual(expected, _calculator.CalculateRadialModule(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateCentreDistance()
        {
            _designInputParams.WorkingCentreDistance =125.0;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear

            var expected = 124.70765d;
            Assert.AreEqual(expected, _calculator.CalculateCentreDistance(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateRadialPressureAngle()
        {
            _designInputParams.WorkingCentreDistance = 125.0;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear

            var expected = 22.7958d;
            Assert.AreEqual(expected, _calculator.CalculateRadialPressureAngle(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateRadialInvoluteFunction()
        {
            _designInputParams.WorkingCentreDistance = 125.0;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear

            var expected = 0.0224135d;
            Assert.AreEqual(expected, _calculator.CalculateRadialInvoluteFunction(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateCentreDistanceIncrementFactor()
        {
            _designInputParams.WorkingCentreDistance = 125.0;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear

            var expected = 0.097447d;
            Assert.AreEqual(expected, _calculator.CalculateCentreDistanceIncrementFactor(_designInputParams), 0.001);
        }

        [Test]
        public void CalculateRadialWorkingPressureAngle()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected = 23.11263d;
            Assert.AreEqual(expected, _calculator.CalculateRadialWorkingPressureAngle(_designInputParams), 0.001);
        }
        
        
        [Test]
        public void CalculateRadialWorkingInvoluteFunction()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected = 0.023405d;
            Assert.AreEqual(expected, _calculator.CalculateRadialWorkingInvoluteFunction(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculatePitchDiameter()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected1 = 41.5692d;
            var expected2 = 207.8460d;
            var actual = _calculator.CalculatePitchDiameter(_designInputParams);
            Assert.AreEqual(expected1, actual.Item1, 0.001);
            Assert.AreEqual(expected2, actual.Item2, 0.001);
        }
        
        [Test]
        public void CalculateBaseDiameter()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected1 = 38.3222d;
            var expected2 = 191.6114d;
            var actual = _calculator.CalculateBaseDiameter(_designInputParams);
            Assert.AreEqual(expected1, actual.Item1, 0.001);
            Assert.AreEqual(expected2, actual.Item2, 0.001);
        }
        
        [Test]
        public void CalculateWorkingPitchDiameter()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected1 = 41.6666d;
            var expected2 = 208.3333d;
            var actual = _calculator.CalculateWorkingPitchDiameter(_designInputParams);
            Assert.AreEqual(expected1, actual.Item1, 0.001);
            Assert.AreEqual(expected2, actual.Item2, 0.001);
        }
        
        [Test]
        public void CalculateAddendum()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected1 = 3.2923d;
            var expected2 = 2.9980d;
            var actual = _calculator.CalculateAddendum(_designInputParams);
            Assert.AreEqual(expected1, actual.Item1, 0.001);
            Assert.AreEqual(expected2, actual.Item2, 0.001);
        }
        
        [Test]
        public void CalculateWholeDepth()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected = 6.7480d;
            Assert.AreEqual(expected, _calculator.CalculateWholeDepth(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateDedendum()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected1 = 3.4557d;
            var expected2 = 3.7500d;
            var actual = _calculator.CalculateDedendum(_designInputParams);
            Assert.AreEqual(expected1, actual.Item1, 0.001);
            Assert.AreEqual(expected2, actual.Item2, 0.001);
        }
        
        [Test]
        public void CalculateOutsideDiameter()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected1 = 48.1539d;
            var expected2 = 213.8422d;
            var actual = _calculator.CalculateOutsideDiameter(_designInputParams);
            Assert.AreEqual(expected1, actual.Item1, 0.001);
            Assert.AreEqual(expected2, actual.Item2, 0.001);
        }
        
        [Test]
        public void CalculateRootDiameter()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected1 = 34.657d;
            var expected2 = 200.346d;
            var actual = _calculator.CalculateRootDiameter(_designInputParams);
            Assert.AreEqual(expected1, actual.Item1, 0.001);
            Assert.AreEqual(expected2, actual.Item2, 0.001);
        }
        
        [Test]
        public void CalculateContactRatioAlpha()
        {
            _designInputParams.WorkingCentreDistance = 125;
        
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected = 1.2939d;
            Assert.AreEqual(expected, _calculator.CalculateContactRatioAlpha(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateContactRatioBeta()
        {
            _designInputParams.WorkingCentreDistance = 125;
            _designInputParams.Gear.Height = 20.0;
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Height = 20.0;
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected = 1.061d;
            Assert.AreEqual(expected, _calculator.CalculateContactRatioBeta(_designInputParams), 0.001);
        }
        
        [Test]
        public void CalculateSumCoefficientOfProfileShift()
        {
            _designInputParams.WorkingCentreDistance = 125;
            _designInputParams.Gear.Height = 20.0;
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Height = 20.0;
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        
            var expected = 0.098089d;
            Assert.AreEqual(expected, _calculator.CalculateSumCoefficientOfProfileShift(_designInputParams), 0.001);
        }
        
        // [Test]
        // public void ToGearString()
        // {
        //     _designInputParams.WorkingCentreDistance = 125;
        //     _designInputParams.Gear.Height = 20.0;
        //     _designInputParams.Gear.Module = 3.0;
        //     _designInputParams.Gear.PressureAngle = 20.0;
        //     _designInputParams.Gear.HelixAngle = 30.0;
        //     _designInputParams.Gear.Teeth = 60.0;
        //     _designInputParams.Gear.CoefficientOfProfileShift = 0;
        //     _designInputParams.Gear.AddendumFilletFactor = 0.25;
        //     _designInputParams.Gear.RootFilletFactor = 0.38;
        //     _designInputParams.Gear.CircularBacklash = 0.1;
        //     _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        //
        //     _designInputParams.Pinion.Height = 20.0;
        //     _designInputParams.Pinion.Module = 3.0;
        //     _designInputParams.Pinion.PressureAngle = 20.0;
        //     _designInputParams.Pinion.HelixAngle = 30.0;
        //     _designInputParams.Pinion.Teeth = 12.0;
        //     _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
        //     _designInputParams.Pinion.AddendumFilletFactor = 0.25;
        //     _designInputParams.Pinion.RootFilletFactor = 0.38;
        //     _designInputParams.Pinion.CircularBacklash = 0.1;
        //     _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
        //     _calculator.Calculate();
        //     io.WriteLine(_calculator.CalculateGearString(_designInputParams, _designOutputParams));
        //  
        // }
        
         // zero backlash specified
        [Test]
        public void CalculateProfileShiftModificationForBacklash()
        {
            _designInputParams.WorkingCentreDistance = 125;
            _designInputParams.Gear.Height = 20.0;
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Height = 20.0;
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear
            var expected =0;
            var actual = _calculator.CalculateProfileShiftModificationForBacklash(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        // backlash specified
        [Test]
        public void CalculateProfileShiftModificationForBacklash1()
        {
            _designInputParams.WorkingCentreDistance = 125;
            _designInputParams.Gear.Height = 20.0;
            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30.0;
            _designInputParams.Gear.Teeth = 60.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.1;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external helical gear
        
            _designInputParams.Pinion.Height = 20.0;
            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30.0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.09809;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.1;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Helical; // configures the gear as an external spur gear

            var expected =-0.03956;
            var actual = _calculator.CalculateProfileShiftModificationForBacklash(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculatePhi()
        {
            _designInputParams.WorkingCentreDistance = 14.000;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 30;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.Internal | GearStyle.Helical; // configures the gear as an external helical gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 30;
            _designInputParams.Pinion.Teeth = 16.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
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