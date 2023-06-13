using System.Windows.Forms;

namespace Bolsover.Bevel.Views
{
    public partial class BevelHelp : Form
    {
        public BevelHelp()
        {
            InitializeComponent();
            BackgroundImage = Globals.BevelGear;
            FormClosing += (sender, args) =>
            {
                ((BevelHelp) sender).Visible = false;
                args.Cancel = true;
            };
        }
    }
}