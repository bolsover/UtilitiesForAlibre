using System.ComponentModel;

namespace Bolsover.DataBrowser.Materials
{
    partial class MaterialPicker
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
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.olvColumnName = new BrightIdeasSoftware.OLVColumn();
            ((System.ComponentModel.ISupportInitialize) (this.treeListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvColumnName);
            this.treeListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.treeListView1.CellEditUseWholeCell = false;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.olvColumnName});
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView1.Location = new System.Drawing.Point(3, 3);
            this.treeListView1.MultiSelect = false;
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(231, 300);
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.UseHotItem = true;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "Name";
            this.olvColumnName.IsTileViewColumn = true;
            this.olvColumnName.Text = "Name";
            this.olvColumnName.Width = 241;
            // 
            // MaterialPicker
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.treeListView1);
            this.Name = "MaterialPicker";
            this.Size = new System.Drawing.Size(241, 307);
            ((System.ComponentModel.ISupportInitialize) (this.treeListView1)).EndInit();
            this.ResumeLayout(false);
        }

        private BrightIdeasSoftware.TreeListView treeListView1;
        private BrightIdeasSoftware.OLVColumn olvColumnName;

        #endregion
    }
}