using System;
using System.Reflection;
using System.Windows.Forms;

namespace Bolsover
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            label1.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var customAttributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            label2.Text = customAttributes.Length == 0
                ? ""
                : ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}