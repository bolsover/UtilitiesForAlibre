using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Bolsover.Gear
{
    public partial class GearForm : Form
    {
        private static GearForm instance;

        public static GearForm Instance()
        {
            if (instance == null)
            {
                instance = new GearForm();
            }

            instance.Visible = true;
            return instance;
        }

        private GearForm()
        {
            InitializeComponent();
            // icon should really be loaded from resources!!
            var FilePath = (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Alibre Design Add-Ons\",
                "{305297BD-DE8D-4F36-86A4-AA5E69538A69}", null);
            Icon myIcon = new Icon(FilePath + "\\nexus.ico");
            this.Icon = myIcon;
            FormClosing += (sender, args) =>
            {
                ((GearForm) sender).Visible = false;
                args.Cancel = true;
            };
        }
    }
}