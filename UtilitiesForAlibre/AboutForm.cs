using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Bolsover
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            Icon = Globals.Icon;
            label1.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var sInfo = new ProcessStartInfo("http://bolsover.com/utilitiesforalibre/utilities-for-alibre.html");
            Process.Start(sInfo);
        }
    }
}