using System.ComponentModel;

namespace Bolsover.ThreeDLine
{
    partial class ThreeDLineUserControl
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
            this.coordinatesDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.buttonImportExcel = new System.Windows.Forms.Button();
            this.textBoxExcel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.coordinatesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // coordinatesDataGridView
            // 
            this.coordinatesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.coordinatesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.coordinatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coordinatesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Column1, this.Column2, this.Column3});
            this.coordinatesDataGridView.Location = new System.Drawing.Point(3, 3);
            this.coordinatesDataGridView.MultiSelect = false;
            this.coordinatesDataGridView.Name = "coordinatesDataGridView";
            this.coordinatesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.coordinatesDataGridView.Size = new System.Drawing.Size(349, 469);
            this.coordinatesDataGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "X";
            this.Column1.HeaderText = "X";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Y";
            this.Column2.HeaderText = "Y";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Z";
            this.Column3.HeaderText = "Z";
            this.Column3.Name = "Column3";
            // 
            // buttonDraw
            // 
            this.buttonDraw.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDraw.Location = new System.Drawing.Point(277, 504);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(75, 23);
            this.buttonDraw.TabIndex = 1;
            this.buttonDraw.Text = "Draw Line";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddRow.Location = new System.Drawing.Point(196, 504);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(75, 23);
            this.buttonAddRow.TabIndex = 2;
            this.buttonAddRow.Text = "Add Row\r\n";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteRow.Location = new System.Drawing.Point(115, 504);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteRow.TabIndex = 3;
            this.buttonDeleteRow.Text = "Delete Row";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // buttonImportExcel
            // 
            this.buttonImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImportExcel.Location = new System.Drawing.Point(34, 478);
            this.buttonImportExcel.Name = "buttonImportExcel";
            this.buttonImportExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonImportExcel.TabIndex = 4;
            this.buttonImportExcel.Text = "Import Excel";
            this.buttonImportExcel.UseVisualStyleBackColor = true;
            this.buttonImportExcel.Click += new System.EventHandler(this.buttonImportExcel_Click);
            // 
            // textBoxExcel
            // 
            this.textBoxExcel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExcel.Location = new System.Drawing.Point(115, 478);
            this.textBoxExcel.Name = "textBoxExcel";
            this.textBoxExcel.Size = new System.Drawing.Size(237, 20);
            this.textBoxExcel.TabIndex = 5;
            // 
            // ThreeDLineUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textBoxExcel);
            this.Controls.Add(this.buttonImportExcel);
            this.Controls.Add(this.buttonDeleteRow);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.coordinatesDataGridView);
            this.Name = "ThreeDLineUserControl";
            this.Size = new System.Drawing.Size(355, 530);
            ((System.ComponentModel.ISupportInitialize) (this.coordinatesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxExcel;

        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.Button buttonImportExcel;

        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;

        private System.Windows.Forms.DataGridView coordinatesDataGridView;

        #endregion
    }
}