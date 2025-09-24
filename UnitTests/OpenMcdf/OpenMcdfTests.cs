using System.Text;
using NUnit.Framework;
using OpenMcdf;

namespace UnitTests.OpenMcdf
{
    public class OpenMcdfTests
    {
        private readonly ConsoleIO console = new();
        private readonly string filepath = "D:\\01_Alibre\\01_Amplifier\\HousingAssy.AD_ASM";
        
        [Test]
        public void OpenAlibreFile()
        {
            var cf = new CompoundFile(filepath);
            console.WriteLine("Opened file " + filepath);
            
            for (var j = 1; j < cf.GetNumDirectories(); j++)
            {
                console.WriteLine("Directory " + j + ": " + cf.GetNameDirEntry(j));
                var constituents = cf.RootStorage.GetStream(cf.GetNameDirEntry(j)).GetData();
                var s = Encoding.Default.GetString(constituents);
                console.WriteLine(s);
            }
            
            
            cf.Close();
        }
    }
}