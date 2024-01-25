using Bolsover.Involute.Builder;
using static Bolsover.Utils.ConversionUtils;
using Bolsover.Involute.Calculator;
using Bolsover.Involute.Model;
using NUnit.Framework;

namespace UnitTests.Involute.Builder
{
    
   
    
    
    [TestFixture]
    [TestOf(typeof(ExternalSpurHelicalToothBuilder))]
    public class ExternalSpurHelicalToothBuilderTest
    {
        
        private ExternalSpurHelicalToothBuilder _externalSpurHelicalToothBuilder;
        private IGearPairDesignInputParams _designPairInputParams;
        private IGearPairDesignOutputParams _designPairOutputParams;
        private ProfileShiftedExternalSpurGearCalculator _calculator;
        private ConsoleIO io = new();

        [SetUp]
        public void Setup()
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

            _calculator = new ProfileShiftedExternalSpurGearCalculator(_designPairInputParams, _designPairOutputParams);
            _externalSpurHelicalToothBuilder = new ExternalSpurHelicalToothBuilder();
            
            _designPairInputParams.WorkingCentreDistance = 56.4999;

            _designPairInputParams.Gear.Module = 3.0;
            _designPairInputParams.Gear.PressureAngle = 20.0;
            _designPairInputParams.Gear.HelixAngle = 0;
            _designPairInputParams.Gear.Teeth = 24.0;
            _designPairInputParams.Gear.CoefficientOfProfileShift = 0;
            _designPairInputParams.Gear.AddendumFilletFactor = 0.25;
            _designPairInputParams.Gear.RootFilletFactor = 0.38;
            _designPairInputParams.Gear.CircularBacklash = 0.0;
            _designPairInputParams.Gear.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear

            _designPairInputParams.Pinion.Module = 3.0;
            _designPairInputParams.Pinion.PressureAngle = 20.0;
            _designPairInputParams.Pinion.HelixAngle = 0;
            _designPairInputParams.Pinion.Teeth = 12.0;
            _designPairInputParams.Pinion.CoefficientOfProfileShift = 0;
            _designPairInputParams.Pinion.AddendumFilletFactor = 0.25;
            _designPairInputParams.Pinion.RootFilletFactor = 0.38;
            _designPairInputParams.Pinion.CircularBacklash = 0.0;
            _designPairInputParams.Pinion.Style = GearStyle.External | GearStyle.Spur; // configures the gear as an external spur gear
            
            _calculator.Calculate();
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        [Test]
        public void TestBuildTooth(double testParameter)
        {
          
            // Execute
            var result = _externalSpurHelicalToothBuilder.Build(_designPairOutputParams.GearDesignOutput);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Tooth>(result);
            Assert.IsTrue(result.Points.Count == 18);
            Assert.IsNotNull(result.LhsInvolute);
            Assert.IsNotNull(result.RhsInvolute);
        }
        
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        [Test]
        public void TestRotateInvolute(double testParameter)
        {
          
            // Execute
            var tooth = _externalSpurHelicalToothBuilder.Build(_designPairOutputParams.GearDesignOutput);

            var kappa = _calculator.CalculateKappa(_designPairInputParams);
            var kappaRadians = Radians(kappa.Item2);
             

            // Assert
            Assert.IsNotNull(tooth);
            Assert.IsInstanceOf<Tooth>(tooth);
            Assert.IsTrue(tooth.Points.Count == 18);
            Assert.IsNotNull(tooth.LhsInvolute);
            Assert.IsNotNull(tooth.RhsInvolute);
        }

        // Additional tests for other methods following the same pattern...
    }
}