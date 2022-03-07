using System.ComponentModel;


namespace Bolsover
{
    partial class PartNoConfig
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.nextNumberSpinner = new System.Windows.Forms.NumericUpDown();
            this.stepSpinner = new System.Windows.Forms.NumericUpDown();
            this.textBoxSuffix = new System.Windows.Forms.TextBox();
            this.textBoxExample = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.nextNumberSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.stepSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prefix";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Next Number";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Step";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(3, 308);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel\r\n";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Suffix";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Example";
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(166, 8);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(120, 20);
            this.textBoxPrefix.TabIndex = 8;
            // 
            // nextNumberSpinner
            // 
            this.nextNumberSpinner.Location = new System.Drawing.Point(166, 42);
            this.nextNumberSpinner.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.nextNumberSpinner.Name = "nextNumberSpinner";
            this.nextNumberSpinner.Size = new System.Drawing.Size(120, 20);
            this.nextNumberSpinner.TabIndex = 9;
            // 
            // stepSpinner
            // 
            this.stepSpinner.Location = new System.Drawing.Point(166, 77);
            this.stepSpinner.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.stepSpinner.Name = "stepSpinner";
            this.stepSpinner.Size = new System.Drawing.Size(120, 20);
            this.stepSpinner.TabIndex = 10;
            // 
            // textBoxSuffix
            // 
            this.textBoxSuffix.Location = new System.Drawing.Point(166, 108);
            this.textBoxSuffix.Name = "textBoxSuffix";
            this.textBoxSuffix.Size = new System.Drawing.Size(120, 20);
            this.textBoxSuffix.TabIndex = 11;
            // 
            // textBoxExample
            // 
            this.textBoxExample.Location = new System.Drawing.Point(166, 143);
            this.textBoxExample.Name = "textBoxExample";
            this.textBoxExample.ReadOnly = true;
            this.textBoxExample.Size = new System.Drawing.Size(120, 20);
            this.textBoxExample.TabIndex = 12;
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(3, 183);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(283, 23);
            this.labelInfo.TabIndex = 13;
            this.labelInfo.Text = "Info";
            // 
            // PartNoConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.textBoxExample);
            this.Controls.Add(this.textBoxSuffix);
            this.Controls.Add(this.stepSpinner);
            this.Controls.Add(this.nextNumberSpinner);
            this.Controls.Add(this.textBoxPrefix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PartNoConfig";
            this.Size = new System.Drawing.Size(297, 334);
            ((System.ComponentModel.ISupportInitialize) (this.nextNumberSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.stepSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelInfo;

        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.NumericUpDown nextNumberSpinner;
        private System.Windows.Forms.NumericUpDown stepSpinner;
        private System.Windows.Forms.TextBox textBoxSuffix;
        private System.Windows.Forms.TextBox textBoxExample;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Button buttonCancel;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        #endregion
    }
}