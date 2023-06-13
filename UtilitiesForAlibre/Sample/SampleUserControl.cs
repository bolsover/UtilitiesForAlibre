using System.Windows.Forms;
using AlibreX;

namespace Bolsover.Sample
{
    public partial class SampleUserControl : UserControl
    {
        private IADSession _session;

        public SampleUserControl(IADSession session)
        {
            this._session = session;
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