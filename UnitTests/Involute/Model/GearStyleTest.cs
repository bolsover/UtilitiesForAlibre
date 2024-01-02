using Bolsover.Involute.Model;
using NUnit.Framework;

namespace UnitTests.Involute.Model
{
    public class GearStyleTest
    {
        
        private ConsoleIO io = new();
        [Test]
        public void GearStyleValuesTest()
        {
            Assert.AreEqual(1, (int)GearStyle.Spur);
            Assert.AreEqual(2, (int)GearStyle.Helical);
            Assert.AreEqual(4, (int)GearStyle.Rack);
            Assert.AreEqual(8, (int)GearStyle.Internal);
            Assert.AreEqual(16, (int)GearStyle.External);
            Assert.AreEqual(32, (int)GearStyle.Worm);
            Assert.AreEqual(64, (int)GearStyle.WormWheel);
            Assert.AreEqual(128, (int)GearStyle.Bevel);
            Assert.AreEqual(256, (int)GearStyle.Crown);
            Assert.AreEqual(512, (int)GearStyle.Planetary);
            Assert.AreEqual(1024, (int)GearStyle.Cycloidal);
        }
        
        [Test]
        public void GearStyleTest2()
        {
            GearStyle gearStyle = GearStyle.Helical | GearStyle.External;
            Assert.AreEqual(18, (int)GearStyle.Helical | (int) GearStyle.External);
            Assert.AreEqual(true, gearStyle.HasFlag(GearStyle.Helical));
            Assert.AreEqual(true, gearStyle.HasFlag(GearStyle.External));
            Assert.AreEqual(false, gearStyle.HasFlag(GearStyle.Bevel));
            // io.WriteLine(gearStyle.ToString());
            // io.WriteLine(gearStyle.HasFlag(GearStyle.Helical).ToString());
            // io.WriteLine(gearStyle.HasFlag(GearStyle.Bevel).ToString());



        }
    }
}