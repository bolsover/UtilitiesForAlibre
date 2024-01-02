using System.ComponentModel;

namespace Bolsover.Involute.View
{
    partial class InvoluteGearForm
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
            this.gearView = new Bolsover.Involute.View.GearView();
            this.SuspendLayout();
            // 
            // gearView
            // 
            this.gearView.AutoSize = true;
            this.gearView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gearView.Location = new System.Drawing.Point(0, 0);
            this.gearView.Margin = new System.Windows.Forms.Padding(4);
            this.gearView.Name = "gearView";
            this.gearView.Size = new System.Drawing.Size(1634, 855);
            this.gearView.TabIndex = 0;
            // 
            // InvoluteGearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1634, 855);
            this.Controls.Add(this.gearView);
            this.Name = "InvoluteGearForm";
            this.Text = "InvoluteGearForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Bolsover.Involute.View.GearView gearView;

        #endregion
    }
}