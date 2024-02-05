using System;
using System.Windows.Forms;
using Bolsover.Shortcuts.Calculator;
using com.alibre.client;
using com.alibre.ui;

namespace Shortcuts.Shortcuts.View
{
    public partial class KeyboardShortcutForm : Form
    {
        private static KeyboardShortcutForm _instance;
        private readonly HtmlReport _htmlReport = new();

        private KeyboardShortcutForm()
        {
            InitializeComponent();
            Icon = Bolsover.Globals.Icon;
            InitDropDown();


            FormClosing += (sender, args) =>
            {
                ((KeyboardShortcutForm) sender).Visible = false;
                args.Cancel = true;
            };
        }

        /// <summary>
        /// Retrieves the list of workspace prefixes from the KeyboardShortcutsMediator and populates the drop down
        /// The list depends on user license type (Atom or Pro)
        /// </summary>
        private void InitDropDown()
        {
            var workspacePrefixes = ClientContext.Singleton.IsAtom
                ? KeyboardShortcutsMediator.ATOM_WORKSPACE_PREFIXES
                : KeyboardShortcutsMediator.ALL_WORKSPACE_PREFIXES;
            comboBox1.Items.AddRange(workspacePrefixes);
        }

        public static KeyboardShortcutForm Instance()
        {
            if (_instance == null)
            {
                _instance = new KeyboardShortcutForm();
            }

            _instance.Visible = true;

            return _instance;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profile = comboBox1.SelectedItem.ToString();

            var html = _htmlReport.BuildReport(profile);
            webBrowser1.DocumentText = html;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "HTML page|*.html";
            saveFileDialog1.Title = "Save as HTML Page";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream) saveFileDialog1.OpenFile();

                System.IO.Stream documentStream = webBrowser1.DocumentStream;
                if (documentStream != null)
                {
                    documentStream.CopyTo(fs);
                    documentStream.Close();
                }

                fs.Close();
            }
        }
    }
}