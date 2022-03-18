using System.ComponentModel;

namespace Bolsover
{
    partial class PlaneFinderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaneFinderForm));
            this.label1 = new System.Windows.Forms.Label();
            this.sketchesComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.planeTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(34, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Sketch:";
            // 
            // sketchesComboBox
            // 
            this.sketchesComboBox.FormattingEnabled = true;
            this.sketchesComboBox.Location = new System.Drawing.Point(155, 19);
            this.sketchesComboBox.Name = "sketchesComboBox";
            this.sketchesComboBox.Size = new System.Drawing.Size(121, 21);
            this.sketchesComboBox.TabIndex = 1;
            this.sketchesComboBox.SelectedIndexChanged += new System.EventHandler(this.sketchesComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(34, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sketch Plane:";
            // 
            // planeTextBox
            // 
            this.planeTextBox.Location = new System.Drawing.Point(155, 65);
            this.planeTextBox.Name = "planeTextBox";
            this.planeTextBox.Size = new System.Drawing.Size(121, 20);
            this.planeTextBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PlaneFinderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 175);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.planeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sketchesComboBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "PlaneFinderForm";
            this.Text = "Plane Finder";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox planeTextBox;

        private System.Windows.Forms.ComboBox sketchesComboBox;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}