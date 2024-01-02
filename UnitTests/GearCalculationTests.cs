using System;
using Bolsover.Gear;
using Bolsover.Gear.Calculators;
using Bolsover.Gear.Models;
using NUnit.Framework;

namespace UnitTests
{
    public class GearCalculationTests
    {
        [Test]
        public void InternalGearCentreDistanceIncrementFactory()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.516);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            var expectedResultX = 0.38943;
            Assert.AreEqual(expectedResultX, GearCalculations.CentreDistanceIncrementFactorY(g1), 0.00001);
        }

        [Test]
        public void WorkingPressureAngleAlphaWTest1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.516);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            var expectedResultX = 31.09385;
            Assert.AreEqual(expectedResultX, GearCalculations.AlphaW(g1), 0.00001);
        }

        [Test]
        public void WorkingPressureAngleAlphaWTest2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.516);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            var expectedResultX = 31.09385;
            Assert.AreEqual(expectedResultX, GearCalculations.AlphaW(g2), 0.00001);
        }


        [Test]
        public void WorkingPressureAngleAlphaWTest3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            var expectedResultX = 26.08862;
            Assert.AreEqual(expectedResultX, GearCalculations.AlphaW(g1), 0.00001);
        }

        [Test]
        public void WorkingPressureAngleAlphaWTest4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;


            try
            {
                var result = GearCalculations.AlphaW(g1);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                string s = ex.Message;
                Assert.AreEqual("Both gears can't be internal!", s);
            }
        }

        [Test]
        public void SigmaXgTest1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.516);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            var expectedResultX = 0.500016;
            Assert.AreEqual(expectedResultX, GearCalculations.SigmaX(g1), 0.00001);
        }

        [Test]
        public void SigmaXgTest2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.516);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            var expectedResultX = 0.500016;
            Assert.AreEqual(expectedResultX, GearCalculations.SigmaX(g2), 0.00001);
        }

        [Test]
        public void SigmaXgTest3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;
            var expectedResultX = 0.96001;
            Assert.AreEqual(expectedResultX, GearCalculations.SigmaX(g1), 0.00001);
        }

        [Test]
        public void SigmaXgTest4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;


            try
            {
                var result = GearCalculations.SigmaX(g1);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                string s = ex.Message;
                Assert.AreEqual("Both gears can't be internal!", s);
            }
        }

        [Test]
        public void AddendumHa1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 3.0;
            Assert.AreEqual(expectedResultX, GearCalculations.AddendumHa(g1), 0.00001);
        }


        [Test]
        public void AddendumHa2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 1.5;
            Assert.AreEqual(expectedResultX, GearCalculations.AddendumHa(g2), 0.00001);
        }

        [Test]
        public void AddendumHa3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 4.419899;
            Assert.AreEqual(expectedResultX, GearCalculations.AddendumHa(g1), 0.00001);
        }

        [Test]
        public void AddendumHa4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 3.69989;
            Assert.AreEqual(expectedResultX, GearCalculations.AddendumHa(g2), 0.00001);
        }

        [Test]
        public void AddendumHa5()
        {
            // should throw an exception
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal; // both gears cant be internal
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;


            try
            {
                var result = GearCalculations.AddendumHa(g2);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }

        [Test]
        public void StandardCentreDistanceATest1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 54;
            Assert.AreEqual(expectedResultX, GearCalculations.StandardCentreDistanceA(g1), 0.00001);
        }

        [Test]
        public void StandardCentreDistanceATest2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 12;
            Assert.AreEqual(expectedResultX, GearCalculations.StandardCentreDistanceA(g1), 0.00001);
        }

        [Test]
        public void StandardCentreDistanceATest3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 12;
            Assert.AreEqual(expectedResultX, GearCalculations.StandardCentreDistanceA(g2), 0.00001);
        }

        [Test]
        public void StandardCentreDistanceATest4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            try
            {
                var result = GearCalculations.StandardCentreDistanceA(g1);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                string s = ex.Message;
                Assert.AreEqual("Both gears can't be internal!", s);
            }
        }

        [Test]
        public void AddendumDiameterDaTest1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 54.00000;
            Assert.AreEqual(expectedResultX, GearCalculations.AddendumDiameterDa(g1), 0.00001);
        }

        [Test]
        public void AddendumDiameterDaTest2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 69.00000;
            Assert.AreEqual(expectedResultX, GearCalculations.AddendumDiameterDa(g2), 0.00001);
        }

        [Test]
        public void AddendumDiameterDaTest3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 79.39979;
            Assert.AreEqual(expectedResultX, GearCalculations.AddendumDiameterDa(g2), 0.00001);
        }

        [Test]
        public void AddendumDiameterDaTest4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            try
            {
                var result = GearCalculations.AddendumDiameterDa(g1);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                string s = ex.Message;
                Assert.AreEqual("Both gears can't be internal!", s);
            }
        }

        [Test]
        public void AddendumDiameterDaTest5()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 30, 0.09809);
            InvoluteGear g2 = new InvoluteGear(3, 60, 20, 30, 0.0);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 125;
            g2.WorkingCentreDistanceAw = 125;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 213.84224;
            Assert.AreEqual(expectedResultX, GearCalculations.AddendumDiameterDa(g2), 0.00001);
        }

        [Test]
        public void AddendumDiameterDaTest6()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 30, 0.09809);
            InvoluteGear g2 = new InvoluteGear(3, 60, 20, 30, 0.0);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 125;
            g2.WorkingCentreDistanceAw = 125;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 48.15390;
            Assert.AreEqual(expectedResultX, GearCalculations.AddendumDiameterDa(g1), 0.00001);
        }

        [Test]
        public void CentreDistanceIncrementFactorYTest1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.389433;
            Assert.AreEqual(expectedResultX, GearCalculations.CentreDistanceIncrementFactorY(g1), 0.00001);
        }

        [Test]
        public void CentreDistanceIncrementFactorYTest2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.389433;
            Assert.AreEqual(expectedResultX, GearCalculations.CentreDistanceIncrementFactorY(g2), 0.00001);
        }

        [Test]
        public void CentreDistanceIncrementFactorYTest3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.83329;
            Assert.AreEqual(expectedResultX, GearCalculations.CentreDistanceIncrementFactorY(g2), 0.00001);
        }

        [Test]
        public void CentreDistanceIncrementFactorYTest4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            try
            {
                var result = GearCalculations.CentreDistanceIncrementFactorY(g1);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                string s = ex.Message;
                Assert.AreEqual("Both gears can't be internal!", s);
            }
        }

        [Test]
        public void CentreDistanceIncrementFactorYTest5()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 30, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 60, 20, 30, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 125;
            g2.WorkingCentreDistanceAw = 125;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.09744;
            Assert.AreEqual(expectedResultX, GearCalculations.CentreDistanceIncrementFactorY(g2), 0.00001);
        }

        [Test]
        public void BaseDiameterDbTest1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 45.10524;
            Assert.AreEqual(expectedResultX, GearCalculations.BaseDiameterDb(g1), 0.00001);
        }

        [Test]
        public void BaseDiameterDbTest2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 67.65786;
            Assert.AreEqual(expectedResultX, GearCalculations.BaseDiameterDb(g2), 0.00001);
        }

        [Test]
        public void BaseDiameterDbTest3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 67.65786;
            Assert.AreEqual(expectedResultX, GearCalculations.BaseDiameterDb(g2), 0.00001);
        }

        [Test]
        public void BaseDiameterDbTest4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            try
            {
                var result = GearCalculations.BaseDiameterDb(g1);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                string s = ex.Message;
                Assert.AreEqual("Both gears can't be internal!", s);
            }
        }

        [Test]
        public void BaseDiameterDbTest5()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 30, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 60, 20, 30, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 125;
            g2.WorkingCentreDistanceAw = 125;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 191.61145;
            Assert.AreEqual(expectedResultX, GearCalculations.BaseDiameterDb(g2), 0.00001);
        }

        [Test]
        public void RootDiameterDrTest1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 40.500;
            Assert.AreEqual(expectedResultX, GearCalculations.RootDiameterDr(g1), 0.00001);
        }

        [Test]
        public void RootDiameterDrTest2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 82.5000;
            Assert.AreEqual(expectedResultX, GearCalculations.RootDiameterDr(g2), 0.00001);
        }

        [Test]
        public void RootDiameterDrTest3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 66.66000;
            Assert.AreEqual(expectedResultX, GearCalculations.RootDiameterDr(g2), 0.00001);
        }

        [Test]
        public void RootDiameterDrTest4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            try
            {
                var result = GearCalculations.RootDiameterDr(g1);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                string s = ex.Message;
                Assert.AreEqual("Both gears can't be internal!", s);
            }
        }

        [Test]
        public void RootDiameterDrTest5()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 30, 0.09809);
            InvoluteGear g2 = new InvoluteGear(3, 60, 20, 30, 0.0);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 125;
            g2.WorkingCentreDistanceAw = 125;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 200.34609;
            Assert.AreEqual(expectedResultX, GearCalculations.RootDiameterDr(g2), 0.00001);
        }

        [Test]
        public void InvAlphaTest1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.014904;
            Assert.AreEqual(expectedResultX, GearCalculations.InvAlpha(g1), 0.00001);
        }

        [Test]
        public void InvAlphaTest2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.014904;
            Assert.AreEqual(expectedResultX, GearCalculations.InvAlpha(g2), 0.00001);
        }

        [Test]
        public void InvAlphaTest3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.014904;
            Assert.AreEqual(expectedResultX, GearCalculations.InvAlpha(g2), 0.00001);
        }

        [Test]
        public void InvAlphaTest4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            try
            {
                var result = GearCalculations.InvAlpha(g1);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                string s = ex.Message;
                Assert.AreEqual("Both gears can't be internal!", s);
            }
        }

        [Test]
        public void InvAlphaTest5()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 30, 0.09809);
            InvoluteGear g2 = new InvoluteGear(3, 60, 20, 30, 0.0);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 125;
            g2.WorkingCentreDistanceAw = 125;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.0224135;
            Assert.AreEqual(expectedResultX, GearCalculations.InvAlpha(g2), 0.00001);
        }

        [Test]
        public void InvAlphaWTest1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.06040214;
            Assert.AreEqual(expectedResultX, GearCalculations.InvAlphaW(g1), 0.00001);
        }

        [Test]
        public void InvAlphaWTest2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.06040214;
            Assert.AreEqual(expectedResultX, GearCalculations.InvAlphaW(g2), 0.00001);
        }

        [Test]
        public void InvAlphaWTest3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.034316;
            Assert.AreEqual(expectedResultX, GearCalculations.InvAlphaW(g2), 0.00001);
        }

        [Test]
        public void InvAlphaWTest4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            try
            {
                var result = GearCalculations.InvAlphaW(g1);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                string s = ex.Message;
                Assert.AreEqual("Both gears can't be internal!", s);
            }
        }

        [Test]
        public void InvAlphaWTest5()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 30, 0.09809);
            InvoluteGear g2 = new InvoluteGear(3, 60, 20, 30, 0.0);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 125;
            g2.WorkingCentreDistanceAw = 125;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 0.023405;
            Assert.AreEqual(expectedResultX, GearCalculations.InvAlphaW(g2), 0.00001);
        }

        [Test]
        public void WorkingPitchDiameterDwTest1()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 52.67320;
            Assert.AreEqual(expectedResultX, GearCalculations.WorkingPitchDiameterDw(g1), 0.00001);
        }

        [Test]
        public void WorkingPitchDiameterDwTest2()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 13.1683;
            g2.WorkingCentreDistanceAw = 13.1683;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 79.00980;
            Assert.AreEqual(expectedResultX, GearCalculations.WorkingPitchDiameterDw(g2), 0.00001);
        }

        [Test]
        public void WorkingPitchDiameterDwTest3()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 0, 0.6);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.36);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 75.33319;
            Assert.AreEqual(expectedResultX, GearCalculations.WorkingPitchDiameterDw(g2), 0.00001);
        }

        [Test]
        public void WorkingPitchDiameterDwTest4()
        {
            InvoluteGear g1 = new InvoluteGear(3, 16, 20, 0, 0.0);
            InvoluteGear g2 = new InvoluteGear(3, 24, 20, 0, 0.5);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.Internal;
            g2.GearTypeEnum = GearTypeEnum.Internal;
            g1.WorkingCentreDistanceAw = 56.4999;
            g2.WorkingCentreDistanceAw = 56.4999;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            try
            {
                var result = GearCalculations.WorkingPitchDiameterDw(g1);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                string s = ex.Message;
                Assert.AreEqual("Both gears can't be internal!", s);
            }
        }

        [Test]
        public void WorkingPitchDiameterDwTest5()
        {
            InvoluteGear g1 = new InvoluteGear(3, 12, 20, 30, 0.09809);
            InvoluteGear g2 = new InvoluteGear(3, 60, 20, 30, 0.0);
            g1.RootFilletFactorRf = 0.38;
            g2.RootFilletFactorRf = 0.38;
            g1.AddendumFilletFactorRa = 0.25;
            g2.AddendumFilletFactorRa = 0.25;
            g1.GearTypeEnum = GearTypeEnum.External;
            g2.GearTypeEnum = GearTypeEnum.External;
            g1.WorkingCentreDistanceAw = 125;
            g2.WorkingCentreDistanceAw = 125;
            g1.CircularBacklashBc = 0;
            g2.CircularBacklashBc = 0;
            g1.MatingGear = g2;
            g2.MatingGear = g1;

            var expectedResultX = 208.33333;
            Assert.AreEqual(expectedResultX, GearCalculations.WorkingPitchDiameterDw(g2), 0.00001);
        }
    }
}