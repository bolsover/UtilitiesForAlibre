using System.Windows.Forms;
using AlibreX;

namespace Bolsover.EmptyShell
{
    public partial class EmptyUserControl : UserControl
    {

        private IADSession session;
        public EmptyUserControl(IADSession session)
        {
            this.session = session;
            InitializeComponent();
        }

        public void AppendText(string text)
        {
            textBox.AppendText(text + "\n");
            textBox.ScrollToCaret();
            if (textBox.Text.Length > 5000)
            {
                textBox.Text = textBox.Text.Substring(4000, textBox.Text.Length - 4000);
            }
        }
    }
}