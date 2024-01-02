using Bolsover.Gear.Calculators;
using Bolsover.Gear.Models;

using NUnit.Framework;

namespace UnitTests.Gear
{
    public class StandardHelicalGearCalculatorTests
    {

        [Test]
        public void CalculateRadialPressureAngle()
        {
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 22.79587;
            var actual = calculator.CalculateRadialPressureAngle(gearPair);
            Assert.AreEqual(expected, actual, 0.00001);

        }

        [Test]
        public void CalculateWorkingRadialPressureAngle()
        {
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 23.112632;
            var actual = calculator.CalculateWorkingRadialPressureAngle(gearPair);
            Assert.AreEqual(expected, actual, 0.00001);

        }



        [Test]
        public void CalculateProfileShiftedCentreDistanceIncrementFactor()
        {
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 0.0974472;
            var actual = calculator.CalculateProfileShiftedCentreDistanceIncrementFactor(gearPair);
            Assert.AreEqual(expected, actual, 0.00001);

        }


        

        [Test]
        public void CalculateTransverseInvoluteAlpha()
        {
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 0.0224135;
            var actual = calculator.CalculateTransverseInvoluteAlpha(gearPair);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculateTransverseInvoluteFunction(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 0.023405;
            var actual = calculator.CalculateTransverseInvoluteFunction(gearPair);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculateGearAddendum(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 2.9980;
            var actual = calculator.CalculateGearAddendum(gearPair);
            Assert.AreEqual(expected, actual, 0.001);
            }
        
        [Test]
        public void CalculatePinionAddendum(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 3.2923;
            var actual = calculator.CalculatePinionAddendum(gearPair);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculateGearDedendum(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 3.7480;
            var actual = calculator.CalculateGearDedendum(gearPair);
            Assert.AreEqual(expected, actual, 0.001);
            }
        
        [Test]
        public void CalculatePinionDedendum(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 4.0423;
            var actual = calculator.CalculatePinionDedendum(gearPair);
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void CalculateWholeDepth(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 6.7480;
            var actual = calculator.CalculateWholeDepth(gearPair);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [Test]
        public void CheckGearDedendum()
        {
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;
            
            gearPair.Gear = gear;
            gearPair.Pinion = pinion;

            var ha2 = calculator.CalculateGearAddendum(gearPair);
            var h = calculator.CalculateWholeDepth(gearPair);
            
            var expected = calculator.CalculateGearDedendum(gearPair);
            var actual = h - ha2;
            Assert.AreEqual(expected, actual, 0.002);

        }
        
        [Test]
        public void CalculateGearStandardPitchDiameter(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 207.8460;
            var actual = calculator.CalculateGearStandardPitchDiameter(gearPair);
            Assert.AreEqual(expected, actual, 0.0001);
        }
        
        [Test]
        public void CalculatePinionStandardPitchDiameter(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 41.56921;
            var actual = calculator.CalculatePinionStandardPitchDiameter(gearPair);
            Assert.AreEqual(expected, actual, 0.0001);
        }
        
        [Test]
        public void CalculateGearBaseDiameter(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 191.6114;
            var actual = calculator.CalculateGearBaseDiameter(gearPair);
            Assert.AreEqual(expected, actual, 0.0001);
        }
        
        [Test]
        public void CalculatePinionBaseDiameter(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 38.32229;
            var actual = calculator.CalculatePinionBaseDiameter(gearPair);
            Assert.AreEqual(expected, actual, 0.0001);
        }
        
        [Test]
        public void CalculateGearOutsideDiameter(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 213.84224;
            var actual = calculator.CalculateGearOutsideDiameter(gearPair);
            Assert.AreEqual(expected, actual, 0.0001);
        }
        
        [Test]
        public void CalculatePinionOutsideDiameter(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 48.15390;
            var actual = calculator.CalculatePinionOutsideDiameter(gearPair);
            Assert.AreEqual(expected, actual, 0.0001);
        }
        
        [Test]
        public void CalculateGearRootDiameter(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 200.34609;
            var actual = calculator.CalculateGearRootDiameter(gearPair);
            Assert.AreEqual(expected, actual, 0.0001);
        }
        
        [Test]
        public void CalculatePinionRootDiameter(){
            StandardHelicalGearCalculator calculator = new StandardHelicalGearCalculator();
            IGearPair gearPair = new GearPair();
            IGear gear = new Bolsover.Gear.Models.Gear();
            gear.NumberOfTeeth = 60;
            gear.NormalModule = 3;
            gear.NormalPressureAngle = 20;
            gear.HelixAngle = 30;
            gear.WorkingCentreDistance = 125;
            gear.NormalCoefficientOfProfileShift = 0;

            IGear pinion = new Bolsover.Gear.Models.Gear();
            pinion.NumberOfTeeth = 12;
            pinion.NormalModule = 3;
            pinion.NormalPressureAngle = 20;
            pinion.HelixAngle = 30;
            pinion.WorkingCentreDistance = 125;
            pinion.NormalCoefficientOfProfileShift = 0.09809;

            gearPair.Gear = gear;
            gearPair.Pinion = pinion;


            var expected = 34.65775;
            var actual = calculator.CalculatePinionRootDiameter(gearPair);
            Assert.AreEqual(expected, actual, 0.0001);
        }
    }
}