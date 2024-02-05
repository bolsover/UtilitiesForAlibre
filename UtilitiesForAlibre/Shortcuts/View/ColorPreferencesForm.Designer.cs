using System.ComponentModel;

namespace Bolsover.Shortcuts.View
{
    partial class ColorPreferencesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorPreferences1 = new Bolsover.Shortcuts.View.ColorPreferences();
            this.SuspendLayout();
            // 
            // colorPreferences1
            // 
            this.colorPreferences1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPreferences1.Location = new System.Drawing.Point(0, 0);
            this.colorPreferences1.Name = "colorPreferences1";
            this.colorPreferences1.Size = new System.Drawing.Size(590, 577);
            this.colorPreferences1.TabIndex = 0;
            // 
            // ColorPreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 577);
            this.Controls.Add(this.colorPreferences1);
            this.Name = "ColorPreferencesForm";
            this.Text = "Preferences";
            this.ResumeLayout(false);
        }

        private Bolsover.Shortcuts.View.ColorPreferences colorPreferences1;

        #endregion
    }
}