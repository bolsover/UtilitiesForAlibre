using System.ComponentModel;

namespace Bolsover.RackPinion.View
{
    partial class RackPinionForm
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
            this.rackPinionControl1 = new Bolsover.RackPinion.View.RackPinionView();
            this.SuspendLayout();
            // 
            // rackPinionControl1
            // 
            this.rackPinionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rackPinionControl1.Location = new System.Drawing.Point(0, 0);
            this.rackPinionControl1.Margin = new System.Windows.Forms.Padding(10);
            this.rackPinionControl1.Name = "rackPinionControl1";
            this.rackPinionControl1.Padding = new System.Windows.Forms.Padding(5);
            this.rackPinionControl1.Size = new System.Drawing.Size(688, 915);
            this.rackPinionControl1.TabIndex = 0;
            // 
            // RackPinionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 915);
            this.Controls.Add(this.rackPinionControl1);
            this.Name = "RackPinionForm";
            this.Text = "Rack and Pinion";
            this.ResumeLayout(false);
        }

        private Bolsover.RackPinion.View.RackPinionView rackPinionControl1;

        #endregion
    }
}