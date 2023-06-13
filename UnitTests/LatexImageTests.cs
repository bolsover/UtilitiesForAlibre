using System.ComponentModel;
using System.Windows.Forms;
using NUnit.Framework;
using System;
using System.Reflection;
using Bolsover.Bevel.Models;
using Bolsover.Gear.Images;

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