using System.Drawing;
using Microsoft.Win32;

namespace Bolsover
{
    public static class Globals
    {
        public static readonly string InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Alibre Design Add-Ons\",
            "{305297BD-DE8D-4F36-86A4-AA5E69538A69}", "");

        public static readonly Icon Icon = new(InstallPath + "\\nexus.ico");
        public static readonly Image CycloidalGear = Image.FromFile(InstallPath + "\\icons\\CycloidalGear.png");
        public static readonly Image BevelGear = Image.FromFile(InstallPath + "\\bevel\\images\\Symbols.png");
        public static readonly string AppName = "Utilities for Alibre";

        //    public static string Version = "1.4.0.0";
    }
}