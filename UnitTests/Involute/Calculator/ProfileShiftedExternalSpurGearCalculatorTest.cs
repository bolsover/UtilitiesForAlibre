using System;
using Bolsover.Involute.Model;

namespace UnitTests.Involute.Calculator
{
    using Bolsover.Involute.Calculator;
    using NUnit.Framework;

    [TestFixture]
    public class ProfileShiftedExternalSpurGearCalculatorTest
    {
        private IGearPairDesignInputParams _designInputParams;
        private IGearPairDesignOutputParams _designOutputParams;
        private ProfileShiftedExternalSpurGearCalculator _calculator;
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

            _calculator = new ProfileShiftedExternalSpurGearCalculator(_designInputParams, _designOutputParams);
        }

        [Test]
        public void CalculateSumCoefficientOfProfileShift()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected = 0.9600d;
            Assert.AreEqual(expected, _calculator.CalculateSumCoefficientOfProfileShift(_designInputParams), 0.001);
        }

        [Test]
        public void CalculateWorkingPitchDiameter()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expectedTuple = new Tuple<double, double>(37.667, 75.333);
            var actualTuple = _calculator.CalculateWorkingPitchDiameter(_designInputParams);
            Assert.AreEqual(expectedTuple.Item1, actualTuple.Item1, 0.001);
            Assert.AreEqual(expectedTuple.Item2, actualTuple.Item2, 0.001);
        }


        [Test]
        public void CalculateCentreDistanceIncrementFactor()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected = 0.83329;
            var actual = _calculator.CalculateCentreDistanceIncrementFactor(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [Test]
        public void CalculateWorkingInvoluteFunction()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected = 0.034316;
            var actual = _calculator.CalculateWorkingInvoluteFunction(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculateWorkingPressureAngle()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected = 26.089;
            var actual = _calculator.CalculateWorkingPressureAngle(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculateInvoluteFunction()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected = .014904;
            var actual = _calculator.CalculateInvoluteFunction(_designInputParams).Item1;
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculateAddendum()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

           
            var expectedTuple = new Tuple<double, double>(4.420, 3.700);
            var actualTuple = _calculator.CalculateAddendum(_designInputParams);
            Assert.AreEqual(expectedTuple.Item1, actualTuple.Item1, 0.001);
            Assert.AreEqual(expectedTuple.Item2, actualTuple.Item2, 0.001);
        }
        
        [Test]
        public void CalculateCentreDistance()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected = 54.0d;
            var actual = _calculator.CalculateCentreDistance(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculateWholeDepth()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected = 6.369;
            var actual = _calculator.CalculateWholeDepth(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculateDedendum()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

           
            var expectedTuple = new Tuple<double, double>(1.9500, 2.670);
            var actualTuple = _calculator.CalculateDedendum(_designInputParams);
            Assert.AreEqual(expectedTuple.Item1, actualTuple.Item1, 0.001);
            Assert.AreEqual(expectedTuple.Item2, actualTuple.Item2, 0.001);
        }
        
        [Test]
        public void CalculatePitchDiameter()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

           
            var expectedTuple = new Tuple<double, double>(36.000, 72.000);
            var actualTuple = _calculator.CalculatePitchDiameter(_designInputParams);
            Assert.AreEqual(expectedTuple.Item1, actualTuple.Item1, 0.001);
            Assert.AreEqual(expectedTuple.Item2, actualTuple.Item2, 0.001);
        }
        
        [Test]
        public void CalculateOutsideDiameter()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

           
            var expectedTuple = new Tuple<double, double>(44.840, 79.400);
            var actualTuple = _calculator.CalculateOutsideDiameter(_designInputParams);
            Assert.AreEqual(expectedTuple.Item1, actualTuple.Item1, 0.001);
            Assert.AreEqual(expectedTuple.Item2, actualTuple.Item2, 0.001);
        }
        
        [Test]
        public void CalculateRootDiameter()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

           
            var expectedTuple = new Tuple<double, double>(32.100, 66.660);
            var actualTuple = _calculator.CalculateRootDiameter(_designInputParams);
            Assert.AreEqual(expectedTuple.Item1, actualTuple.Item1, 0.001);
            Assert.AreEqual(expectedTuple.Item2, actualTuple.Item2, 0.001);
        }
        
        [Test]
        public void CalculateBaseDiameter()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

           
            var expectedTuple = new Tuple<double, double>(33.829, 67.658);
            var actualTuple = _calculator.CalculateBaseDiameter(_designInputParams);
            Assert.AreEqual(expectedTuple.Item1, actualTuple.Item1, 0.001);
            Assert.AreEqual(expectedTuple.Item2, actualTuple.Item2, 0.001);
        }
        
        // [Test]
        // public void ToGearString()
        // {
        //     _designInputParams.WorkingCentreDistance = 56.4999;
        //
        //     _designInputParams.Gear.Module = 3.0;
        //     _designInputParams.Gear.PressureAngle = 20.0;
        //     _designInputParams.Gear.HelixAngle = 0;
        //     _designInputParams.Gear.Teeth = 24.0;
        //     _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
        //     _designInputParams.Gear.AddendumFilletFactor = 0.25;
        //     _designInputParams.Gear.RootFilletFactor = 0.38;
        //     _designInputParams.Gear.CircularBacklash = 0.0;
        //     _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear
        //
        //     _designInputParams.Pinion.Module = 3.0;
        //     _designInputParams.Pinion.PressureAngle = 20.0;
        //     _designInputParams.Pinion.HelixAngle = 0;
        //     _designInputParams.Pinion.Teeth = 12.0;
        //     _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
        //     _designInputParams.Pinion.AddendumFilletFactor = 0.25;
        //     _designInputParams.Pinion.RootFilletFactor = 0.38;
        //     _designInputParams.Pinion.CircularBacklash = 0.0;
        //     _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear
        //     _calculator.Calculate();
        //    
        //   io.WriteLine(_calculator.CalculateGearString(_designInputParams, _designOutputParams));
        // }
        
        [Test]
        public void CalculateContactRatio()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected = 1.202;
            var actual = _calculator.CalculateContactRatioAlpha(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        // zero backlash specified
        [Test]
        public void CalculateProfileShiftModificationForBacklash()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
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
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.1;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.1;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected =-0.0437;
            var actual = _calculator.CalculateProfileShiftModificationForBacklash(_designInputParams);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
       
        
        [Test]
        public void CalculatePhi()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.1;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.1;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            var expected1 = 0.85395;
            var expected2 = 0.85395;
            var result = _calculator.CalculatePhi(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
        
        // backlash specified
        [Test]
        public void CalculateTheta()
        {
            _designInputParams.WorkingCentreDistance = 56.4999;

            _designInputParams.Gear.Module = 3.0;
            _designInputParams.Gear.PressureAngle = 20.0;
            _designInputParams.Gear.HelixAngle = 0;
            _designInputParams.Gear.Teeth = 24.0;
            _designInputParams.Gear.CoefficientOfProfileShift = 0.36;
            _designInputParams.Gear.AddendumFilletFactor = 0.25;
            _designInputParams.Gear.RootFilletFactor = 0.38;
            _designInputParams.Gear.CircularBacklash = 0.0;
            _designInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designInputParams.Pinion.Module = 3.0;
            _designInputParams.Pinion.PressureAngle = 20.0;
            _designInputParams.Pinion.HelixAngle = 0;
            _designInputParams.Pinion.Teeth = 12.0;
            _designInputParams.Pinion.CoefficientOfProfileShift = 0.6;
            _designInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designInputParams.Pinion.RootFilletFactor = 0.38;
            _designInputParams.Pinion.CircularBacklash = 0.0;
            _designInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear


            var expected1 = 9.585395;
            var expected2 = 4.375618;
            var result = _calculator.CalculateTheta(_designInputParams);
            Assert.AreEqual(expected1, result.Item1, 0.001);
            Assert.AreEqual(expected2, result.Item2, 0.001);
        }
    }
}