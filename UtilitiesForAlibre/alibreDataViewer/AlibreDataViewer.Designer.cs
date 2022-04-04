using System.ComponentModel;

namespace Bolsover.alibreDataViewer
{
    partial class AlibreDataViewer
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
            this.components = new System.ComponentModel.Container();
            this.treeListView = new BrightIdeasSoftware.TreeListView();
            this.olvColumnProperty = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnType = new BrightIdeasSoftware.OLVColumn();
            this.olvColumnValue = new BrightIdeasSoftware.OLVColumn();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.treeListView)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListView
            // 
            this.treeListView.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeListView.CellEditUseWholeCell = false;
            this.treeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.olvColumnProperty, this.olvColumnType, this.olvColumnValue});
            this.treeListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView.GridLines = true;
            this.treeListView.Location = new System.Drawing.Point(3, -1);
            this.treeListView.Name = "treeListView";
            this.treeListView.ShowGroups = false;
            this.treeListView.Size = new System.Drawing.Size(377, 555);
            this.treeListView.TabIndex = 1;
            this.treeListView.UseCompatibleStateImageBehavior = false;
            this.treeListView.UseFiltering = true;
            this.treeListView.View = System.Windows.Forms.View.Details;
            this.treeListView.VirtualMode = true;
            // 
            // olvColumnProperty
            // 
            this.olvColumnProperty.Text = "Property";
            this.olvColumnProperty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnProperty.Width = 88;
            // 
            // olvColumnType
            // 
            this.olvColumnType.Text = "Type";
            this.olvColumnType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnType.Width = 110;
            // 
            // olvColumnValue
            // 
            this.olvColumnValue.Text = "Value";
            this.olvColumnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnValue.Width = 150;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(296, 571);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // AlibreDataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.treeListView);
            this.Name = "AlibreDataViewer";
            this.Size = new System.Drawing.Size(383, 610);
            ((System.ComponentModel.ISupportInitialize) (this.treeListView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button closeButton;

        private BrightIdeasSoftware.TreeListView treeListView;
        private BrightIdeasSoftware.OLVColumn olvColumnProperty;
        private BrightIdeasSoftware.OLVColumn olvColumnType;
        private BrightIdeasSoftware.OLVColumn olvColumnValue;

     

        #endregion
    }
}