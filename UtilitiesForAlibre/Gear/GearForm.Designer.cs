using System.ComponentModel;

namespace Bolsover.Gear
{
    partial class GearForm
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
            this.externalGearUserControl1 = new Bolsover.Gear.ExternalGearUserControl();
            this.SuspendLayout();
            // 
            // externalGearUserControl1
            // 
            this.externalGearUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.externalGearUserControl1.Location = new System.Drawing.Point(12, 12);
            this.externalGearUserControl1.Name = "externalGearUserControl1";
            this.externalGearUserControl1.Size = new System.Drawing.Size(1095, 810);
            this.externalGearUserControl1.TabIndex = 0;
            // 
            // GearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 836);
            this.Controls.Add(this.externalGearUserControl1);
            
            this.Name = "GearForm";
            this.Text = "Gear Generator";
            this.ResumeLayout(false);
        }

        private Bolsover.Gear.ExternalGearUserControl externalGearUserControl1;

        #endregion
    }
}