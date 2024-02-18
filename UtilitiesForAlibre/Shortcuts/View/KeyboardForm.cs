using System.Reflection;
using System.Windows.Forms;
using Shortcuts;

namespace Bolsover.Shortcuts.View
{
    public partial class KeyboardForm : Form
    {
        
        private static KeyboardForm _instance;
        private KeyboardForm()
        {
            InitializeComponent();
            Icon = Globals.Icon;
          
          Text = "Keyboard Shortcuts";
          
            FormClosing += (sender, args) =>
            {
                ((KeyboardForm) sender).Visible = false;
                args.Cancel = true;
            };
        }
        
        public static KeyboardForm Instance()
        {
            _instance ??= new KeyboardForm();

            _instance.Visible = true;

            return _instance;
        }

    }
}