using System.Windows.Forms;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Presenters;
using Bolsover.Bevel.Views;
using NUnit.Framework;

namespace UnitTests.Bevel
{
    public class BevelGerViewTests
    {
        [Test]
        public void TestFrame()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var bevelGearView = new BevelGearView();
            var pinion = new BevelGear
            {
                ShaftAngle = 90d,
                SpiralAngle = 0d,
                Module = 3.0d,
                PressureAngle = 20.0d,
                FaceWidth = 22.0d,
                NumberOfTeeth = 20.0d,
                Hand = "L",
                GearType = "Standard"
            };
            var gear = new BevelGear
            {
                ShaftAngle = 90d,
                SpiralAngle = 0d,
                Module = 3.0d,
                PressureAngle = 20.0d,
                FaceWidth = 22.0d,
                NumberOfTeeth = 40.0d,
                Hand = "R",
                GearType = "Standard"
            };

            var presenter = new BevelGearPresenter(bevelGearView, pinion, gear);

            Application.Run(new BevelGearForm(bevelGearView));
        }
    }
}