using System.ComponentModel;

namespace Bolsover.Bevel.Views
{
    partial class BevelGearForm
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
            
            
           
            this.SuspendLayout();
            // 
            // bevelGearUserControl1
            // 
            this.bevelGearView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bevelGearView.Location = new System.Drawing.Point(0, 0);
            this.bevelGearView.Name = "bevelGearView";
            this.bevelGearView.Size = new System.Drawing.Size(798, 829);
            this.bevelGearView.TabIndex = 0;
            
            // 
            // BevelGearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 829);
            this.Controls.Add(this.bevelGearView);
            this.Name = "BevelGearForm";
            this.Text = "Bevel Gears";
            this.ResumeLayout(false);
        }

       
        private BevelGearView bevelGearView;

        #endregion
    }
}