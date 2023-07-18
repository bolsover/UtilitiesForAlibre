using System.Windows.Forms;

namespace Bolsover.Bevel.Views
{
    public partial class BevelGearForm : Form
    {
        private BevelGearView bevelGearView;

        public BevelGearForm(BevelGearView view)
        {
            bevelGearView = view;
            InitializeComponent();

            FormClosing += (sender, args) =>
            {
                ((BevelGearForm) sender).Visible = false;
                args.Cancel = true;
            };
        }

        public BevelGearForm()
        {
            InitializeComponent();
            FormClosing += (sender, args) =>
            {
                ((BevelGearForm) sender).Visible = false;
                args.Cancel = true;
            };
        }
    }
}