using System.Windows.Forms;

namespace Bolsover.Gear.Views
{
    public partial class GearForm : Form
    {
        private static GearForm _instance;

        public static GearForm Instance()
        {
            if (_instance == null)
            {
                _instance = new GearForm();
            }

            _instance.Visible = true;
            return _instance;
        }

        private GearForm()
        {
            InitializeComponent();
            // icon should really be loaded from resources!!


            Icon = Globals.Icon;
            FormClosing += (sender, args) =>
            {
                ((GearForm) sender).Visible = false;
                args.Cancel = true;
            };
        }
    }
}