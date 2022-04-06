using System.ComponentModel;

namespace Bolsover.PlaneFinder
{
    partial class PlaneFinder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.planeTextBox = new System.Windows.Forms.TextBox();
            this.sketchTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Sketch:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sketch Plane:";
            // 
            // planeTextBox
            // 
            this.planeTextBox.Location = new System.Drawing.Point(93, 82);
            this.planeTextBox.Name = "planeTextBox";
            this.planeTextBox.Size = new System.Drawing.Size(121, 20);
            this.planeTextBox.TabIndex = 3;
            // 
            // sketchTextBox
            // 
            this.sketchTextBox.Location = new System.Drawing.Point(93, 50);
            this.sketchTextBox.Name = "sketchTextBox";
            this.sketchTextBox.Size = new System.Drawing.Size(121, 20);
            this.sketchTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select Sketch from Design Explorer";
            // 
            // PlaneFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sketchTextBox);
            this.Controls.Add(this.planeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PlaneFinder";
            this.Size = new System.Drawing.Size(224, 136);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox sketchTextBox;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox planeTextBox;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}