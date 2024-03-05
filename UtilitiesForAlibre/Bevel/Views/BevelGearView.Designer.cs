using System.ComponentModel;
using System.Windows.Forms;

namespace Bolsover.Bevel.Views
{
    partial class BevelGearView
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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn2 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn3 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn4 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn5 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn6 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn7 = new BrightIdeasSoftware.OLVColumn();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.NumberOfTeethGearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.NumberOfTeethPinionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label9 = new System.Windows.Forms.Label();
            this.PressureAngleLabel = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.NumberOfTeethLabel = new System.Windows.Forms.Label();
            this.ShaftAngleLabel = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.ModuleLabel = new System.Windows.Forms.Label();
            this.ShaftAngleNnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ModuleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PressureAngleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FaceWidthLabel = new System.Windows.Forms.Label();
            this.FaceWidthFormulaLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.PinionButton = new System.Windows.Forms.Button();
            this.BuildGearButton = new System.Windows.Forms.Button();
            this.FaceWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label15 = new System.Windows.Forms.Label();
            this.gearTypeGroupBox1 = new System.Windows.Forms.GroupBox();
            this.standardRadioButton = new System.Windows.Forms.RadioButton();
            this.gleasonRadioButton = new System.Windows.Forms.RadioButton();
            this.standardLabel = new System.Windows.Forms.Label();
            this.gleasonLabel = new System.Windows.Forms.Label();
            this.NotesLabel = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            this.TableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfTeethGearNumericUpDown)).BeginInit();
            this.TableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfTeethPinionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShaftAngleNnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureAngleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaceWidthNumericUpDown)).BeginInit();
            this.gearTypeGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1059, 1009);
            this.TabControl1.TabIndex = 2;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.objectListView1);
            this.TabPage1.Controls.Add(this.TableLayoutPanel1);
            this.TabPage1.Location = new System.Drawing.Point(4, 25);
            this.TabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.TabPage1.Size = new System.Drawing.Size(1051, 980);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Settings";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.AllColumns.Add(this.olvColumn3);
            this.objectListView1.AllColumns.Add(this.olvColumn4);
            this.objectListView1.AllColumns.Add(this.olvColumn5);
            this.objectListView1.AllColumns.Add(this.olvColumn6);
            this.objectListView1.AllColumns.Add(this.olvColumn7);
            this.objectListView1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.olvColumn1, this.olvColumn2, this.olvColumn3, this.olvColumn4, this.olvColumn5, this.olvColumn6, this.olvColumn7 });
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.objectListView1.HideSelection = false;
            this.objectListView1.Location = new System.Drawing.Point(8, 473);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.ShowHeaderInAllViews = false;
            this.objectListView1.ShowItemToolTips = true;
            this.objectListView1.Size = new System.Drawing.Size(1034, 500);
            this.objectListView1.SortGroupItemsByPrimaryColumn = false;
            this.objectListView1.TabIndex = 66;
            this.objectListView1.UseAlternatingBackColors = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "Item";
            this.olvColumn1.Width = 123;
            // 
            // olvColumn2
            // 
            this.olvColumn2.Text = "Pinion Metric";
            this.olvColumn2.Width = 152;
            // 
            // olvColumn3
            // 
            this.olvColumn3.Text = "Pinion Imperial";
            this.olvColumn3.Width = 138;
            // 
            // olvColumn4
            // 
            this.olvColumn4.Text = "Pinion Notes";
            this.olvColumn4.Width = 138;
            // 
            // olvColumn5
            // 
            this.olvColumn5.Text = "Gear Metric";
            this.olvColumn5.Width = 179;
            // 
            // olvColumn6
            // 
            this.olvColumn6.Text = "Gear Imperial";
            this.olvColumn6.Width = 157;
            // 
            // olvColumn7
            // 
            this.olvColumn7.Text = "Gear Notes";
            this.olvColumn7.Width = 135;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TableLayoutPanel1.ColumnCount = 5;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel4, 4, 6);
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel3, 3, 6);
            this.TableLayoutPanel1.Controls.Add(this.Label9, 0, 5);
            this.TableLayoutPanel1.Controls.Add(this.PressureAngleLabel, 1, 5);
            this.TableLayoutPanel1.Controls.Add(this.Label11, 0, 6);
            this.TableLayoutPanel1.Controls.Add(this.Label3, 4, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label2, 3, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label6, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label18, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.NumberOfTeethLabel, 1, 6);
            this.TableLayoutPanel1.Controls.Add(this.ShaftAngleLabel, 1, 3);
            this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label4, 0, 4);
            this.TableLayoutPanel1.Controls.Add(this.Label7, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.ModuleLabel, 1, 4);
            this.TableLayoutPanel1.Controls.Add(this.ShaftAngleNnumericUpDown, 3, 3);
            this.TableLayoutPanel1.Controls.Add(this.ModuleNumericUpDown, 3, 4);
            this.TableLayoutPanel1.Controls.Add(this.PressureAngleNumericUpDown, 3, 5);
            this.TableLayoutPanel1.Controls.Add(this.FaceWidthLabel, 1, 7);
            this.TableLayoutPanel1.Controls.Add(this.FaceWidthFormulaLabel, 2, 7);
            this.TableLayoutPanel1.Controls.Add(this.CancelButton, 0, 8);
            this.TableLayoutPanel1.Controls.Add(this.PinionButton, 3, 8);
            this.TableLayoutPanel1.Controls.Add(this.BuildGearButton, 4, 8);
            this.TableLayoutPanel1.Controls.Add(this.FaceWidthNumericUpDown, 3, 7);
            this.TableLayoutPanel1.Controls.Add(this.Label15, 0, 7);
            this.TableLayoutPanel1.Controls.Add(this.gearTypeGroupBox1, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.standardLabel, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.gleasonLabel, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.NotesLabel, 1, 8);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 9;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1043, 460);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // TableLayoutPanel4
            // 
            this.TableLayoutPanel4.ColumnCount = 2;
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel4.Controls.Add(this.NumberOfTeethGearNumericUpDown, 0, 0);
            this.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel4.Location = new System.Drawing.Point(878, 281);
            this.TableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayoutPanel4.Name = "TableLayoutPanel4";
            this.TableLayoutPanel4.RowCount = 1;
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel4.Size = new System.Drawing.Size(160, 37);
            this.TableLayoutPanel4.TabIndex = 2;
            // 
            // NumberOfTeethGearNumericUpDown
            // 
            this.NumberOfTeethGearNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberOfTeethGearNumericUpDown.Location = new System.Drawing.Point(4, 7);
            this.NumberOfTeethGearNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.NumberOfTeethGearNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.NumberOfTeethGearNumericUpDown.Minimum = new decimal(new int[] { 13, 0, 0, 0 });
            this.NumberOfTeethGearNumericUpDown.Name = "NumberOfTeethGearNumericUpDown";
            this.NumberOfTeethGearNumericUpDown.Size = new System.Drawing.Size(72, 22);
            this.NumberOfTeethGearNumericUpDown.TabIndex = 104;
            this.NumberOfTeethGearNumericUpDown.Value = new decimal(new int[] { 40, 0, 0, 0 });
            this.NumberOfTeethGearNumericUpDown.ValueChanged += new System.EventHandler(this.numberOfTeethGearNumericUpDown_ValueChanged);
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.ColumnCount = 2;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.Controls.Add(this.NumberOfTeethPinionNumericUpDown, 0, 0);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(712, 281);
            this.TableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 1;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel3.Size = new System.Drawing.Size(157, 37);
            this.TableLayoutPanel3.TabIndex = 2;
            // 
            // NumberOfTeethPinionNumericUpDown
            // 
            this.NumberOfTeethPinionNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberOfTeethPinionNumericUpDown.Location = new System.Drawing.Point(4, 7);
            this.NumberOfTeethPinionNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.NumberOfTeethPinionNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.NumberOfTeethPinionNumericUpDown.Minimum = new decimal(new int[] { 13, 0, 0, 0 });
            this.NumberOfTeethPinionNumericUpDown.Name = "NumberOfTeethPinionNumericUpDown";
            this.NumberOfTeethPinionNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.NumberOfTeethPinionNumericUpDown.TabIndex = 103;
            this.NumberOfTeethPinionNumericUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
            this.NumberOfTeethPinionNumericUpDown.ValueChanged += new System.EventHandler(this.numberOfTeethPinionNumericUpDown_ValueChanged);
            // 
            // Label9
            // 
            this.Label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label9.Location = new System.Drawing.Point(5, 231);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(220, 45);
            this.Label9.TabIndex = 9;
            this.Label9.Text = "Pressure Angle";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PressureAngleLabel
            // 
            this.PressureAngleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PressureAngleLabel.Location = new System.Drawing.Point(234, 231);
            this.PressureAngleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PressureAngleLabel.Name = "PressureAngleLabel";
            this.PressureAngleLabel.Size = new System.Drawing.Size(95, 45);
            this.PressureAngleLabel.TabIndex = 10;
            // 
            // Label11
            // 
            this.Label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label11.Location = new System.Drawing.Point(5, 277);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(220, 45);
            this.Label11.TabIndex = 11;
            this.Label11.Text = "Number Of Teeth";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label3.Location = new System.Drawing.Point(878, 1);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(160, 45);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Gear";
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label2.Location = new System.Drawing.Point(712, 1);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(157, 45);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Pinion";
            // 
            // Label6
            // 
            this.Label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label6.Location = new System.Drawing.Point(234, 1);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(95, 45);
            this.Label6.TabIndex = 6;
            this.Label6.Text = "Symbol";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label18
            // 
            this.Label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label18.Location = new System.Drawing.Point(338, 1);
            this.Label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(365, 45);
            this.Label18.TabIndex = 18;
            this.Label18.Text = "Formula";
            // 
            // NumberOfTeethLabel
            // 
            this.NumberOfTeethLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumberOfTeethLabel.Location = new System.Drawing.Point(234, 277);
            this.NumberOfTeethLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NumberOfTeethLabel.Name = "NumberOfTeethLabel";
            this.NumberOfTeethLabel.Size = new System.Drawing.Size(95, 45);
            this.NumberOfTeethLabel.TabIndex = 19;
            // 
            // ShaftAngleLabel
            // 
            this.ShaftAngleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShaftAngleLabel.Location = new System.Drawing.Point(234, 139);
            this.ShaftAngleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShaftAngleLabel.Name = "ShaftAngleLabel";
            this.ShaftAngleLabel.Size = new System.Drawing.Size(95, 45);
            this.ShaftAngleLabel.TabIndex = 61;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(5, 1);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(220, 45);
            this.Label1.TabIndex = 64;
            this.Label1.Text = "Item";
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label4.Location = new System.Drawing.Point(5, 185);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(220, 45);
            this.Label4.TabIndex = 96;
            this.Label4.Text = "Module";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            this.Label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label7.Location = new System.Drawing.Point(5, 139);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(220, 45);
            this.Label7.TabIndex = 97;
            this.Label7.Text = "Shaft Angle";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModuleLabel
            // 
            this.ModuleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleLabel.Location = new System.Drawing.Point(234, 185);
            this.ModuleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModuleLabel.Name = "ModuleLabel";
            this.ModuleLabel.Size = new System.Drawing.Size(95, 45);
            this.ModuleLabel.TabIndex = 98;
            // 
            // ShaftAngleNnumericUpDown
            // 
            this.ShaftAngleNnumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.ShaftAngleNnumericUpDown, 2);
            this.ShaftAngleNnumericUpDown.DecimalPlaces = 3;
            this.ShaftAngleNnumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.ShaftAngleNnumericUpDown.Location = new System.Drawing.Point(712, 150);
            this.ShaftAngleNnumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.ShaftAngleNnumericUpDown.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            this.ShaftAngleNnumericUpDown.Name = "ShaftAngleNnumericUpDown";
            this.ShaftAngleNnumericUpDown.Size = new System.Drawing.Size(326, 22);
            this.ShaftAngleNnumericUpDown.TabIndex = 100;
            this.ShaftAngleNnumericUpDown.Value = new decimal(new int[] { 90, 0, 0, 0 });
            this.ShaftAngleNnumericUpDown.ValueChanged += new System.EventHandler(this.shaftAngleNumericUpDown_ValueChanged);
            // 
            // ModuleNumericUpDown
            // 
            this.ModuleNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.ModuleNumericUpDown, 2);
            this.ModuleNumericUpDown.DecimalPlaces = 3;
            this.ModuleNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.ModuleNumericUpDown.Location = new System.Drawing.Point(712, 196);
            this.ModuleNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.ModuleNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            this.ModuleNumericUpDown.Name = "ModuleNumericUpDown";
            this.ModuleNumericUpDown.Size = new System.Drawing.Size(326, 22);
            this.ModuleNumericUpDown.TabIndex = 101;
            this.ModuleNumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            this.ModuleNumericUpDown.ValueChanged += new System.EventHandler(this.moduleNumericUpDown_ValueChanged);
            // 
            // PressureAngleNumericUpDown
            // 
            this.PressureAngleNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.PressureAngleNumericUpDown, 2);
            this.PressureAngleNumericUpDown.DecimalPlaces = 3;
            this.PressureAngleNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.PressureAngleNumericUpDown.Location = new System.Drawing.Point(712, 242);
            this.PressureAngleNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.PressureAngleNumericUpDown.Maximum = new decimal(new int[] { 35, 0, 0, 0 });
            this.PressureAngleNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.PressureAngleNumericUpDown.Name = "PressureAngleNumericUpDown";
            this.PressureAngleNumericUpDown.Size = new System.Drawing.Size(326, 22);
            this.PressureAngleNumericUpDown.TabIndex = 102;
            this.PressureAngleNumericUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
            this.PressureAngleNumericUpDown.ValueChanged += new System.EventHandler(this.pressureAngleNumericUpDown_ValueChanged);
            // 
            // FaceWidthLabel
            // 
            this.FaceWidthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FaceWidthLabel.Location = new System.Drawing.Point(234, 323);
            this.FaceWidthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FaceWidthLabel.Name = "FaceWidthLabel";
            this.FaceWidthLabel.Size = new System.Drawing.Size(95, 45);
            this.FaceWidthLabel.TabIndex = 23;
            // 
            // FaceWidthFormulaLabel
            // 
            this.FaceWidthFormulaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FaceWidthFormulaLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FaceWidthFormulaLabel.Location = new System.Drawing.Point(338, 323);
            this.FaceWidthFormulaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FaceWidthFormulaLabel.Name = "FaceWidthFormulaLabel";
            this.FaceWidthFormulaLabel.Size = new System.Drawing.Size(365, 45);
            this.FaceWidthFormulaLabel.TabIndex = 30;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(5, 396);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(220, 36);
            this.CancelButton.TabIndex = 119;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // PinionButton
            // 
            this.PinionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PinionButton.Location = new System.Drawing.Point(712, 396);
            this.PinionButton.Margin = new System.Windows.Forms.Padding(4);
            this.PinionButton.Name = "PinionButton";
            this.PinionButton.Size = new System.Drawing.Size(157, 36);
            this.PinionButton.TabIndex = 120;
            this.PinionButton.Text = "Build Pinion";
            this.PinionButton.UseVisualStyleBackColor = true;
            this.PinionButton.Click += new System.EventHandler(this.pinionButton_Click);
            // 
            // BuildGearButton
            // 
            this.BuildGearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildGearButton.Location = new System.Drawing.Point(878, 396);
            this.BuildGearButton.Margin = new System.Windows.Forms.Padding(4);
            this.BuildGearButton.Name = "BuildGearButton";
            this.BuildGearButton.Size = new System.Drawing.Size(160, 36);
            this.BuildGearButton.TabIndex = 121;
            this.BuildGearButton.Text = "Build Gear";
            this.BuildGearButton.UseVisualStyleBackColor = true;
            this.BuildGearButton.Click += new System.EventHandler(this.buildGearButton_Click);
            // 
            // FaceWidthNumericUpDown
            // 
            this.FaceWidthNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.FaceWidthNumericUpDown, 2);
            this.FaceWidthNumericUpDown.DecimalPlaces = 3;
            this.FaceWidthNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            this.FaceWidthNumericUpDown.Location = new System.Drawing.Point(712, 334);
            this.FaceWidthNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.FaceWidthNumericUpDown.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            this.FaceWidthNumericUpDown.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.FaceWidthNumericUpDown.Name = "FaceWidthNumericUpDown";
            this.FaceWidthNumericUpDown.Size = new System.Drawing.Size(326, 22);
            this.FaceWidthNumericUpDown.TabIndex = 122;
            this.FaceWidthNumericUpDown.Value = new decimal(new int[] { 22, 0, 0, 0 });
            this.FaceWidthNumericUpDown.ValueChanged += new System.EventHandler(this.faceWidthNumericUpDown_ValueChanged);
            // 
            // Label15
            // 
            this.Label15.Location = new System.Drawing.Point(5, 323);
            this.Label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(180, 37);
            this.Label15.TabIndex = 15;
            this.Label15.Text = "Face Width";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gearTypeGroupBox1
            // 
            this.gearTypeGroupBox1.Controls.Add(this.standardRadioButton);
            this.gearTypeGroupBox1.Controls.Add(this.gleasonRadioButton);
            this.gearTypeGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gearTypeGroupBox1.Location = new System.Drawing.Point(4, 50);
            this.gearTypeGroupBox1.Name = "gearTypeGroupBox1";
            this.TableLayoutPanel1.SetRowSpan(this.gearTypeGroupBox1, 2);
            this.gearTypeGroupBox1.Size = new System.Drawing.Size(222, 85);
            this.gearTypeGroupBox1.TabIndex = 125;
            this.gearTypeGroupBox1.TabStop = false;
            this.gearTypeGroupBox1.Text = "Gear Type";
            // 
            // standardRadioButton
            // 
            this.standardRadioButton.Checked = true;
            this.standardRadioButton.Location = new System.Drawing.Point(6, 15);
            this.standardRadioButton.Name = "standardRadioButton";
            this.standardRadioButton.Size = new System.Drawing.Size(97, 24);
            this.standardRadioButton.TabIndex = 123;
            this.standardRadioButton.TabStop = true;
            this.standardRadioButton.Text = "Standard";
            this.standardRadioButton.UseVisualStyleBackColor = true;
            this.standardRadioButton.CheckedChanged += new System.EventHandler(this.standardRadioButton_CheckedChanged);
            // 
            // gleasonRadioButton
            // 
            this.gleasonRadioButton.Location = new System.Drawing.Point(6, 45);
            this.gleasonRadioButton.Name = "gleasonRadioButton";
            this.gleasonRadioButton.Size = new System.Drawing.Size(97, 24);
            this.gleasonRadioButton.TabIndex = 124;
            this.gleasonRadioButton.Text = "Gleason";
            this.gleasonRadioButton.UseVisualStyleBackColor = true;
            this.gleasonRadioButton.CheckedChanged += new System.EventHandler(this.gleasonRadioButton_CheckedChanged);
            // 
            // standardLabel
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.standardLabel, 4);
            this.standardLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standardLabel.Location = new System.Drawing.Point(233, 47);
            this.standardLabel.Name = "standardLabel";
            this.standardLabel.Size = new System.Drawing.Size(806, 45);
            this.standardLabel.TabIndex = 126;
            // 
            // gleasonLabel
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.gleasonLabel, 4);
            this.gleasonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gleasonLabel.Location = new System.Drawing.Point(233, 93);
            this.gleasonLabel.Name = "gleasonLabel";
            this.gleasonLabel.Size = new System.Drawing.Size(806, 45);
            this.gleasonLabel.TabIndex = 127;
            // 
            // NotesLabel
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.NotesLabel, 2);
            this.NotesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesLabel.Location = new System.Drawing.Point(233, 369);
            this.NotesLabel.Name = "NotesLabel";
            this.NotesLabel.Size = new System.Drawing.Size(471, 90);
            this.NotesLabel.TabIndex = 128;
            this.NotesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BevelGearView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BevelGearView";
            this.Size = new System.Drawing.Size(1059, 1009);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfTeethGearNumericUpDown)).EndInit();
            this.TableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfTeethPinionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShaftAngleNnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureAngleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaceWidthNumericUpDown)).EndInit();
            this.gearTypeGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public System.Windows.Forms.Label NotesLabel;

        public System.Windows.Forms.Label standardLabel;
        public System.Windows.Forms.Label gleasonLabel;
        public BrightIdeasSoftware.OLVColumn olvColumn1;
        public BrightIdeasSoftware.OLVColumn olvColumn2;
        public BrightIdeasSoftware.OLVColumn olvColumn3;
        public BrightIdeasSoftware.OLVColumn olvColumn4;
        public BrightIdeasSoftware.OLVColumn olvColumn5;
        public BrightIdeasSoftware.OLVColumn olvColumn6;
        public BrightIdeasSoftware.OLVColumn olvColumn7;

        
        public BrightIdeasSoftware.ObjectListView objectListView1;

        private System.Windows.Forms.GroupBox gearTypeGroupBox1;

        public System.Windows.Forms.RadioButton standardRadioButton;
        public System.Windows.Forms.RadioButton gleasonRadioButton;


        public System.Windows.Forms.NumericUpDown FaceWidthNumericUpDown;
        private System.Windows.Forms.TabControl TabControl1;
private System.Windows.Forms.TabPage TabPage1;
private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
private System.Windows.Forms.TableLayoutPanel TableLayoutPanel4;
public System.Windows.Forms.NumericUpDown NumberOfTeethGearNumericUpDown;
private System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
public System.Windows.Forms.NumericUpDown NumberOfTeethPinionNumericUpDown;
private System.Windows.Forms.Label Label9;
public System.Windows.Forms.Label PressureAngleLabel;
private System.Windows.Forms.Label Label11;
private System.Windows.Forms.Label Label3;
private System.Windows.Forms.Label Label2;
private System.Windows.Forms.Label Label6;
private System.Windows.Forms.Label Label18;
public System.Windows.Forms.Label NumberOfTeethLabel;
public System.Windows.Forms.Label ShaftAngleLabel;
private System.Windows.Forms.Label Label1;
private System.Windows.Forms.Label Label4;
private System.Windows.Forms.Label Label7;
public System.Windows.Forms.Label ModuleLabel;
private System.Windows.Forms.NumericUpDown ShaftAngleNnumericUpDown;
private System.Windows.Forms.NumericUpDown ModuleNumericUpDown;
private System.Windows.Forms.NumericUpDown PressureAngleNumericUpDown;
private System.Windows.Forms.Label Label15;
public System.Windows.Forms.Label FaceWidthLabel;
public System.Windows.Forms.Label FaceWidthFormulaLabel;
private System.Windows.Forms.Button CancelButton;
private System.Windows.Forms.Button PinionButton;
private System.Windows.Forms.Button BuildGearButton;

#endregion
    }
}