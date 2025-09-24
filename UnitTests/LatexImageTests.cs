using System.Windows.Forms;
using NUnit.Framework;

namespace UnitTests
{
    public class LatexImageTests
    {
        [Test]
        public void TestFrame()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LatexImageForm());
        }
    }
}