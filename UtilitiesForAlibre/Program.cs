using System;
using System.Windows.Forms;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Presenters;
using Bolsover.Bevel.Views;

namespace Bolsover
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new BevelGearForm());

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

            BevelGearPresenter presenter = new BevelGearPresenter(bevelGearView, pinion, gear);
            Application.Run(new BevelGearForm(bevelGearView));
            //form.FormClosing += delegate(object sender, FormClosingEventArgs args) {  };
            // form.Show();
        }
    }
}