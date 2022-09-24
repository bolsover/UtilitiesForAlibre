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
           
            Icon applicationIcon = Globals.Icon;
            this.Icon = applicationIcon;
            FormClosing += (sender, args) =>
            {
                ((GearForm) sender).Visible = false;
                args.Cancel = true;
            };
        }
    }
}