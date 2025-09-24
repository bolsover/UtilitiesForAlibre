using System.Text;
using System.Xml.Linq;
using Bolsover.Shortcuts.Calculator;
using com.alibre.utils;
using NUnit.Framework;

namespace UnitTests.Shortcuts
{
    public class ShortcutTests
    {
        private readonly ConsoleIO console = new();
        private readonly string filepath = "F:\\Downloads\\asd20240513\\User.NET.profile_24";
        [Test]
        
        public void ReadUserProfile()
        {
            ShortcutsCalculator shortcutsCalculator = new ShortcutsCalculator();
            
            Profile profile = shortcutsCalculator.ReadProfileFromFile(filepath);
            
            XElement xml = shortcutsCalculator.ProfileToXml(profile);
            
            console.WriteLine("zzz");
        }
        
    }
}