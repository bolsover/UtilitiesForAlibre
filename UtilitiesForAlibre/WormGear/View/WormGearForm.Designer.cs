using System.ComponentModel;

namespace Bolsover.WormGear.View
{
    partial class WormGearForm
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
            this.wormGearView = new Bolsover.WormGear.View.WormGearView();
            this.SuspendLayout();
            // 
            // wormGearView
            // 
            this.wormGearView.AutoSize = true;
            this.wormGearView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wormGearView.Location = new System.Drawing.Point(0, 0);
            this.wormGearView.Margin = new System.Windows.Forms.Padding(4);
            this.wormGearView.Name = "wormGearView";
            this.wormGearView.Size = new System.Drawing.Size(911, 743);
            this.wormGearView.TabIndex = 0;
            // 
            // WormGearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 743);
            this.Controls.Add(this.wormGearView);
            this.Name = "WormGearForm";
            this.Text = "Worm Gears";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Bolsover.WormGear.View.WormGearView wormGearView;
        #endregion
    }
}