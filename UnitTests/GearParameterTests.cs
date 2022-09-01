using Bolsover.Gears;
using NUnit.Framework;


namespace UnitTests
{
    public class GearParameterTests
    {
        private ProfileShiftSpurGearParameters parameters = new();


        [SetUp]
        public void Setup()
        {
            standardParameters();
        }

        private void filletParameters()
        {
            parameters.Type = GearType.EXTERNAL_SPUR;
            parameters.TeethZ1 = 18;
            parameters.TeethZ2 = 18;

            parameters.Centre = new Point(0, 0);
            parameters.ModuleMn = 1;
            parameters.PressureAngleAlpha = 20;


            parameters.WorkingCentreDistanceAw = 18;
            parameters.CircularBacklashReqdBc = 0;
            parameters.DistributionOfProfileShift = 50;
        }

        private void standardParameters()
        {
            parameters.Type = GearType.EXTERNAL_SPUR;
            parameters.TeethZ1 = 12;
            parameters.TeethZ2 = 24;

            parameters.Centre = new Point(0, 0);
            parameters.ModuleMn = 3;
            parameters.PressureAngleAlpha = 20;


            parameters.WorkingCentreDistanceAw = 56.49987;
            parameters.CircularBacklashReqdBc = 0;
            parameters.DistributionOfProfileShift = 62.5;
        }

        private void toothThicknessParameters()
        {
            parameters.Type = GearType.EXTERNAL_SPUR;
            parameters.TeethZ1 = 12;
            parameters.TeethZ2 = 24;

            parameters.Centre = new Point(0, 0);
            parameters.ModuleMn = 10;
            parameters.PressureAngleAlpha = 20;
            parameters.WorkingCentreDistanceAw = 190;
            parameters.CircularBacklashReqdBc = 0;
            parameters.DistributionOfProfileShift = 25.462;
        }

        private void contactRatioParameters()
        {
            parameters.Type = GearType.EXTERNAL_SPUR;
            parameters.TeethZ1 = 47;
            parameters.TeethZ2 = 50;

            parameters.Centre = new Point(0, 0);
            parameters.ModuleMn = 2.5;
            parameters.PressureAngleAlpha = 20;
            parameters.WorkingCentreDistanceAw = 122.0;
            parameters.CircularBacklashReqdBc = 0.0;
            parameters.DistributionOfProfileShift = 50;
        }

        [Test]
        public void Alpha1()
        {
            standardParameters();
            var expectedResult = 0.85395;

            Assert.AreEqual(expectedResult, parameters.Alpha1, 0.0001);
        }


        // [Test]
        // public void AngleToFilletCentre1()
        // {
        //     filletParameters();
        //     var expectedResult = 1.371188579;
        //
        //     Assert.AreEqual(expectedResult, parameters.AngleToFilletCentre1, 0.000001);
        // }

        [Test]
        public void RootFilletXa1()
        {
            filletParameters();
            var expectedResult = 7.747780781;

            Assert.AreEqual(expectedResult, parameters.RootFilletXa1, 0.0001);
        }


        [Test]
        public void RootFilletYa1()
        {
            filletParameters();
            var expectedResult = -0.185453401;

            Assert.AreEqual(expectedResult, parameters.RootFilletYa1, 0.0001);
        }

        [Test]
        public void RootFilletYd1()
        {
            filletParameters();
            var expectedResult = -0.19;

            Assert.AreEqual(expectedResult, parameters.RootFilletYd1, 0.0001);
        }

        [Test]
        public void RootFilletXd1()
        {
            filletParameters();
            var expectedResult = 7.937726375;

            Assert.AreEqual(expectedResult, parameters.RootFilletXd1, 0.0001);
        }

        [Test]
        public void RootFilletYe1()
        {
            filletParameters();
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, parameters.RootFilletYe1, 0.0001);
        }

        // [Test]
        // public void RootFilletXe1()
        // {
        //     filletParameters();
        //     var expectedResult = 8.070794791;
        //
        //     Assert.AreEqual(expectedResult, parameters.RootFilletXe1, 0.0001);
        // }

        [Test]
        public void Alpha2()
        {
            standardParameters();
            var expectedResult = 0.85395;

            Assert.AreEqual(expectedResult, parameters.Alpha2, 0.0001);
        }


        // [Test]
        // public void ContactRatio()
        // {
        //     contactRatioParameters();
        //     var expectedResult = 1.68634;
        //
        //     Assert.AreEqual(expectedResult, parameters.ContactRatio(), 0.0001);
        // }

        [Test]
        public void ProfileShiftWithoutUndercutX1()
        {
            standardParameters();
            var expectedResult = 0.29813;

            Assert.AreEqual(expectedResult, parameters.ProfileShiftWithoutUndercutX1, 0.0001);
        }

        [Test]
        public void ProfileShiftWithoutUndercutX2()
        {
            standardParameters();
            var expectedResult = -0.40373;

            Assert.AreEqual(expectedResult, parameters.ProfileShiftWithoutUndercutX2, 0.0001);
        }


        [Test]
        public void ProfileShiftXMod()
        {
            standardParameters();
            var expectedResult = -0.0;

            Assert.AreEqual(expectedResult, parameters.ProfileShiftXMod, 0.0001);
        }


        [Test]
        public void CentreDistanceIncrementFactorY()
        {
            standardParameters();
            var expectedResult = 0.83329;

            Assert.AreEqual(expectedResult, parameters.CentreDistanceIncrementFactorY, 0.0001);
        }

        [Test]
        public void WorkingPressureAngleAw()
        {
            standardParameters();
            var expectedResult = 26.0886;

            Assert.AreEqual(expectedResult, parameters.WorkingPressureAngleAw, 0.0001);
        }

        [Test]
        public void StandardCentreDistanceA()
        {
            standardParameters();
            double expectedResult = 54;

            Assert.AreEqual(expectedResult, parameters.StandardCentreDistanceA, 0.0001);
        }

        // [Test]
        // public void CircularToothThicknessS1()
        // {
        //     toothThicknessParameters();
        //     var expectedResult = 17.8918;
        //
        //     Assert.AreEqual(expectedResult, parameters.CircularToothThicknessS1, 0.0001);
        //     standardParameters();
        // }

        // [Test]
        // public void ChordalToothThicknessSj1()
        // {
        //     toothThicknessParameters();
        //     var expectedResult = 17.8256;
        //
        //     Assert.AreEqual(expectedResult, parameters.ChordalToothThicknessSj1, 0.0001);
        //     standardParameters();
        // }

        [Test]
        public void HalfToothAngleAtPitchCircleTheta1()
        {
            toothThicknessParameters();
            var expectedResult = 8.54270;

            Assert.AreEqual(expectedResult, parameters.HalfToothAngleAtPitchCircleTheta1, 0.0001);
            standardParameters();
        }

        // [Test]
        // public void TeethWithoutUndercutZc1()
        // {
        //     standardParameters();
        //     var expectedResult = 6.8389;
        //
        //     Assert.AreEqual(expectedResult, parameters.TeethWithoutUndercutZc1, 0.0001);
        // }

        [Test]
        public void SumCoefficientOfProfileShift()
        {
            standardParameters();
            var expectedResult = 0.9600;

            Assert.AreEqual(expectedResult, parameters.SumCoefficientOfProfileShift, 0.001);
        }

        [Test]
        public void WorkingPitchDiameterDw2()
        {
            standardParameters();
            var expectedResult = 75.333;

            Assert.AreEqual(expectedResult, parameters.WorkingPitchDiameterDw2, 0.001);
        }

        [Test]
        public void WorkingPitchDiameterDw1()
        {
            standardParameters();
            var expectedResult = 37.667;

            Assert.AreEqual(expectedResult, parameters.WorkingPitchDiameterDw1, 0.001);
        }


        // [Test]
        // public void OperatingCentreDistanceAw()
        // {
        //     standardParameters();
        //     var expectedResult = 56.49987;
        //
        //     Assert.AreEqual(expectedResult, parameters.OperatingCentreDistanceAw, 0.0001);
        // }
       

        [Test]
        public void InvoluteFunctionInvAlpha()
        {
            standardParameters();
            var expectedResult = 0.014904384;

            Assert.AreEqual(expectedResult, parameters.InvoluteFunctionInvAlpha, 0.00001);
        }


        [Test]
        public void InvoluteFunctionInvAlphaW()
        {
            standardParameters();
            var expectedResult = 0.034316;

            Assert.AreEqual(expectedResult, parameters.InvoluteFunctionInvAlphaW, 0.00001);
        }

        [Test]
        public void PitchDiameter()
        {
            standardParameters();
            double expectedResult = 36;

            Assert.AreEqual(expectedResult, parameters.ReferenceDiameterD1, 0.1);
        }

        [Test]
        public void BaseDiameter()
        {
            standardParameters();
            var expectedResult = 33.8289;

            Assert.AreEqual(expectedResult, parameters.BaseDiameterDb1, 0.0001);
        }

        // [Test]
        // public void TipDiameter()
        // {
        //     standardParameters();
        //     var expectedResult = 44.840;
        //
        //     Assert.AreEqual(expectedResult, parameters.TipDiameterDa1, 0.001);
        // }
    }
}