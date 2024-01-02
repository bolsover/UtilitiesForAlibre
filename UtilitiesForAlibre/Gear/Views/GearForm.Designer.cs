using System.ComponentModel;

namespace Bolsover.Gear.Views
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GearForm));
            this._gearUserControl1 = new GearUserControl();
            this.SuspendLayout();
            // 
            // _gearUserControl1
            // 
            this._gearUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._gearUserControl1.Location = new System.Drawing.Point(12, 12);
            this._gearUserControl1.Name = "_gearUserControl1";
            this._gearUserControl1.Size = new System.Drawing.Size(1095, 810);
            this._gearUserControl1.TabIndex = 0;
            // 
            // GearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 836);
            this.Controls.Add(this._gearUserControl1);
         //   this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "GearForm";
            this.Text = "Gear Generator";
            this.ResumeLayout(false);
        }

        private GearUserControl _gearUserControl1;

        #endregion
    }
}