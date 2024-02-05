using System.ComponentModel;
using Bolsover.Shortcuts.View;

namespace Bolsover.Shortcuts.View
{
    partial class KeyboardForm
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
            this.keyboardControl1 = new Bolsover.Shortcuts.View.KeyboardControl();
            this.SuspendLayout();
            // 
            // keyboardControl1
            // 
            this.keyboardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardControl1.Location = new System.Drawing.Point(0, 0);
            this.keyboardControl1.Name = "keyboardControl1";
            this.keyboardControl1.Size = new System.Drawing.Size(1591, 431);
            this.keyboardControl1.TabIndex = 0;
         
            // 
            // KeyboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1591, 431);

            this.Controls.Add(this.keyboardControl1);
            this.Name = "KeyboardForm";
            this.Text = "Keyboard Shortcuts";
            this.ResumeLayout(false);
        }

        public KeyboardControl keyboardControl1;

        #endregion
    }
}