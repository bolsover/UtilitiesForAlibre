using System.Windows.Forms;
using Bolsover.Gear.Views;
using NUnit.Framework;

namespace UnitTests.Gear
{
    public class StandardGearViewTests
    {
        [Test]
        public void TestFrame()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StandardGearForm());
        }
    }
}