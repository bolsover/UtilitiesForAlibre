using System.Windows.Forms;

namespace Bolsover.Bevel.Views
{
    public partial class BevelGearForm : Form
    {
        private BevelGearView _bevelGearView;

        public BevelGearForm(BevelGearView view)
        {
            _bevelGearView = view;
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