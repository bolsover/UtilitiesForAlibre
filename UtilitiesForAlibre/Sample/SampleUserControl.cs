using System.Windows.Forms;
using AlibreX;

namespace Bolsover.Sample
{
    public partial class SampleUserControl : UserControl
    {
        private IADSession session;

        public SampleUserControl(IADSession session)
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