using System.Drawing;
using Microsoft.Win32;

namespace Bolsover
{
    public class Globals
    {
        public static string InstallPath = (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Alibre Design Add-Ons\",
            "{305297BD-DE8D-4F36-86A4-AA5E69538A69}", null);
        public static Icon Icon =new Icon(InstallPath + "\\nexus.ico");

        public static Image cycloidalGear = Image.FromFile(InstallPath + "\\icons\\CycloidalGear.png");

    }
}