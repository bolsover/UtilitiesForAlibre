using System;
using Bolsover.Involute.Model;
using Bolsover.Involute.Presenter;
using Bolsover.Involute.View;
using NUnit.Framework;

namespace UnitTests.Involute
{
    [TestFixture]
    public class GearViewPresenterTests
    {
        [Test]
        public void TestModuleNumericUpDown()
        {
            var gearView = new GearView();
            var presenter = new GearViewPresenter(gearView);
            gearView.moduleNumericUpDown.Value = 1.0M;
            Assert.AreEqual(1, presenter.Model.Gear.Module);
            gearView.moduleNumericUpDown.Value = 100.0M;
            Assert.AreEqual(100, presenter.Model.Gear.Module);
        }

        [Test]
        public void TestPressureAngleNumericUpDown()
        {
            var gearView = new GearView();
            var presenter = new GearViewPresenter(gearView);
            gearView.pressureAngleNumericUpDown.Value = 20.0M;
            Assert.AreEqual(20, presenter.Model.Gear.PressureAngle);
            gearView.pressureAngleNumericUpDown.Value = 14.5M;
            Assert.AreEqual(14.5, presenter.Model.Gear.PressureAngle);
        }

        [Test]
        public void TestHelixAngleNumericUpDown()
        {
            var gearView = new GearView();
            var presenter = new GearViewPresenter(gearView);
            gearView.helixAngleNumericUpDown.Value = 00.0M;
            Assert.AreEqual(0, presenter.Model.Gear.HelixAngle);
            Assert.AreEqual(false, presenter.Model.Gear.Style.HasFlag(GearStyle.Helical));
            gearView.helixAngleNumericUpDown.Value = 25M;
            Assert.AreEqual(25, presenter.Model.Gear.HelixAngle);
            Assert.AreEqual(true, presenter.Model.Gear.Style.HasFlag(GearStyle.Helical));
            gearView.helixAngleNumericUpDown.Value = 00.0M;
            Assert.AreEqual(0, presenter.Model.Gear.HelixAngle);
            Assert.AreEqual(false, presenter.Model.Gear.Style.HasFlag(GearStyle.Helical));
            Assert.AreEqual(true, presenter.Model.Gear.Style.HasFlag(GearStyle.Spur));
        }

        [Test]
        public void TestGearTeethNumericUpDown()
        {
            var gearView = new GearView();
            var presenter = new GearViewPresenter(gearView);
            gearView.gearTeethNumericUpDown.Value = 20.0M;
            Assert.AreEqual(20, presenter.Model.Gear.Teeth);
            gearView.gearTeethNumericUpDown.Value = 22;
            Assert.AreEqual(22, presenter.Model.Gear.Teeth);
        }

        [Test]
        public void TestPinionTeethNumericUpDown()
        {
            var gearView = new GearView();
            var presenter = new GearViewPresenter(gearView);
            gearView.pinionTeethNumericUpDown.Value = 15;
            Assert.AreEqual(15, presenter.Model.Pinion.Teeth);
            gearView.pinionTeethNumericUpDown.Value = 200;
            Assert.AreEqual(200, presenter.Model.Pinion.Teeth);
        }

        [Test]
        public void TestIntExtRadioButtons()
        {
            var gearView = new GearView();
            var presenter = new GearViewPresenter(gearView);
            gearView.intRadioButton.Checked = false;
            Assert.AreEqual(false, gearView.intRadioButton.Checked);
            Assert.AreEqual(true, gearView.extRadioButton.Checked);
            gearView.intRadioButton.Checked = false;
            Assert.AreEqual(false, gearView.intRadioButton.Checked);
            Assert.AreEqual(false, presenter.Model.Gear.Style.HasFlag(GearStyle.Internal));
            gearView.intRadioButton.Checked = true;
            Assert.AreEqual(true, presenter.Model.Gear.Style.HasFlag(GearStyle.Internal));
            gearView.extRadioButton.Checked = true;
            Assert.AreEqual(true, presenter.Model.Gear.Style.HasFlag(GearStyle.External));
            gearView.extRadioButton.Checked = false;
            Assert.AreEqual(false, presenter.Model.Gear.Style.HasFlag(GearStyle.External));
        }

        [Test]
        public void TestRootFilletFactorNumericUpDown()
        {
            var gearView = new GearView();
            var presenter = new GearViewPresenter(gearView);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { gearView.rootFilletFactorNumericUpDown.Value = 0; });
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { gearView.rootFilletFactorNumericUpDown.Value = 1; });
            Assert.DoesNotThrow(() => { gearView.rootFilletFactorNumericUpDown.Value = 0.5M; });
            Assert.AreEqual(0.5, presenter.Model.Gear.RootFilletFactor);
            Assert.DoesNotThrow(() => { gearView.rootFilletFactorNumericUpDown.Value = 0.001M; });
            Assert.AreEqual(0.001, presenter.Model.Gear.RootFilletFactor);
        }

        [Test]
        public void TestAddendumFilletFactorNumericUpDown()
        {
            var gearView = new GearView();
            var presenter = new GearViewPresenter(gearView);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { gearView.addendumFilletFactorNumericUpDown.Value = 0; });
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { gearView.addendumFilletFactorNumericUpDown.Value = 1; });
            Assert.DoesNotThrow(() => { gearView.addendumFilletFactorNumericUpDown.Value = 0.5M; });
            Assert.AreEqual(0.5, presenter.Model.Gear.AddendumFilletFactor);
            Assert.DoesNotThrow(() => { gearView.addendumFilletFactorNumericUpDown.Value = 0.001M; });
            Assert.AreEqual(0.001, presenter.Model.Gear.AddendumFilletFactor);
        }

        /// <summary>
        /// tests initial state of button and input controls
        /// toggles the button and checks that the controls are enabled/disabled
        /// </summary>
        [Test]
        public void TestAutomaticButton()
        {
            var gearView = new GearView();
            var presenter = new GearViewPresenter(gearView);
            var model = presenter.Model;
            Assert.AreEqual(false, gearView.operatingCentreDistanceNumericUpDown.Enabled);
            Assert.AreEqual(false, gearView.pinionProfileShiftNumericUpDown.Enabled);
            Assert.AreEqual(false, gearView.gearProfileShiftNumericUpDown.Enabled);
            Assert.AreEqual(false, gearView.normalBacklashNumericUpDown.Enabled);
            gearView.autoManualButton.PerformClick();
            Assert.AreEqual(false, model.Auto);
            Assert.AreEqual(true, gearView.operatingCentreDistanceNumericUpDown.Enabled);
            Assert.AreEqual(true, gearView.pinionProfileShiftNumericUpDown.Enabled);
            Assert.AreEqual(true, gearView.gearProfileShiftNumericUpDown.Enabled);
            Assert.AreEqual(true, gearView.normalBacklashNumericUpDown.Enabled);
            gearView.autoManualButton.PerformClick();
            Assert.AreEqual(true, model.Auto);
            Assert.AreEqual(false, gearView.operatingCentreDistanceNumericUpDown.Enabled);
            Assert.AreEqual(false, gearView.pinionProfileShiftNumericUpDown.Enabled);
            Assert.AreEqual(false, gearView.gearProfileShiftNumericUpDown.Enabled);
            Assert.AreEqual(false, gearView.normalBacklashNumericUpDown.Enabled);
        }
    }
}