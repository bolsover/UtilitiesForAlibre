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
            this.GearTextBox = new System.Windows.Forms.TextBox();
            this.PinionTextBox = new System.Windows.Forms.TextBox();
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
            this.Label15 = new System.Windows.Forms.Label();
            this.FaceWidthLabel = new System.Windows.Forms.Label();
            this.FaceWidthFormulaLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.PinionButton = new System.Windows.Forms.Button();
            this.BuildGearButton = new System.Windows.Forms.Button();
            this.FaceWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.TableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfTeethGearNumericUpDown)).BeginInit();
            this.TableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfTeethPinionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShaftAngleNnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureAngleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaceWidthNumericUpDown)).BeginInit();
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
            this.TabPage1.Controls.Add(this.GearTextBox);
            this.TabPage1.Controls.Add(this.PinionTextBox);
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
            // GearTextBox
            // 
            this.GearTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GearTextBox.Location = new System.Drawing.Point(532, 339);
            this.GearTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.GearTextBox.Multiline = true;
            this.GearTextBox.Name = "GearTextBox";
            this.GearTextBox.Size = new System.Drawing.Size(492, 610);
            this.GearTextBox.TabIndex = 3;
            // 
            // PinionTextBox
            // 
            this.PinionTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PinionTextBox.Location = new System.Drawing.Point(9, 339);
            this.PinionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PinionTextBox.Multiline = true;
            this.PinionTextBox.Name = "PinionTextBox";
            this.PinionTextBox.Size = new System.Drawing.Size(491, 610);
            this.PinionTextBox.TabIndex = 2;
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
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel4, 4, 5);
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel3, 3, 5);
            this.TableLayoutPanel1.Controls.Add(this.Label9, 0, 4);
            this.TableLayoutPanel1.Controls.Add(this.PressureAngleLabel, 1, 4);
            this.TableLayoutPanel1.Controls.Add(this.Label11, 0, 5);
            this.TableLayoutPanel1.Controls.Add(this.Label3, 4, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label2, 3, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label6, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label18, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.NumberOfTeethLabel, 1, 5);
            this.TableLayoutPanel1.Controls.Add(this.ShaftAngleLabel, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label4, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.Label7, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.ModuleLabel, 1, 3);
            this.TableLayoutPanel1.Controls.Add(this.ShaftAngleNnumericUpDown, 3, 2);
            this.TableLayoutPanel1.Controls.Add(this.ModuleNumericUpDown, 3, 3);
            this.TableLayoutPanel1.Controls.Add(this.PressureAngleNumericUpDown, 3, 4);
            this.TableLayoutPanel1.Controls.Add(this.FaceWidthLabel, 1, 6);
            this.TableLayoutPanel1.Controls.Add(this.FaceWidthFormulaLabel, 2, 6);
            this.TableLayoutPanel1.Controls.Add(this.CancelButton, 0, 7);
            this.TableLayoutPanel1.Controls.Add(this.PinionButton, 3, 7);
            this.TableLayoutPanel1.Controls.Add(this.BuildGearButton, 4, 7);
            this.TableLayoutPanel1.Controls.Add(this.FaceWidthNumericUpDown, 3, 6);
            this.TableLayoutPanel1.Controls.Add(this.Label15, 0, 6);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 8;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1043, 325);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // TableLayoutPanel4
            // 
            this.TableLayoutPanel4.ColumnCount = 2;
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel4.Controls.Add(this.NumberOfTeethGearNumericUpDown, 0, 0);
            this.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel4.Location = new System.Drawing.Point(878, 195);
            this.TableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayoutPanel4.Name = "TableLayoutPanel4";
            this.TableLayoutPanel4.RowCount = 1;
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel4.Size = new System.Drawing.Size(160, 29);
            this.TableLayoutPanel4.TabIndex = 2;
            // 
            // NumberOfTeethGearNumericUpDown
            // 
            this.NumberOfTeethGearNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberOfTeethGearNumericUpDown.Location = new System.Drawing.Point(4, 4);
            this.NumberOfTeethGearNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.NumberOfTeethGearNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.NumberOfTeethGearNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
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
            this.TableLayoutPanel3.Location = new System.Drawing.Point(712, 195);
            this.TableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 1;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel3.Size = new System.Drawing.Size(157, 29);
            this.TableLayoutPanel3.TabIndex = 2;
            // 
            // NumberOfTeethPinionNumericUpDown
            // 
            this.NumberOfTeethPinionNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberOfTeethPinionNumericUpDown.Location = new System.Drawing.Point(4, 4);
            this.NumberOfTeethPinionNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.NumberOfTeethPinionNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.NumberOfTeethPinionNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.NumberOfTeethPinionNumericUpDown.Name = "NumberOfTeethPinionNumericUpDown";
            this.NumberOfTeethPinionNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.NumberOfTeethPinionNumericUpDown.TabIndex = 103;
            this.NumberOfTeethPinionNumericUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
            this.NumberOfTeethPinionNumericUpDown.ValueChanged += new System.EventHandler(this.numberOfTeethPinionNumericUpDown_ValueChanged);
            // 
            // Label9
            // 
            this.Label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label9.Location = new System.Drawing.Point(5, 153);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(220, 37);
            this.Label9.TabIndex = 9;
            this.Label9.Text = "Pressure Angle";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PressureAngleLabel
            // 
            this.PressureAngleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PressureAngleLabel.Location = new System.Drawing.Point(234, 153);
            this.PressureAngleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PressureAngleLabel.Name = "PressureAngleLabel";
            this.PressureAngleLabel.Size = new System.Drawing.Size(95, 37);
            this.PressureAngleLabel.TabIndex = 10;
            // 
            // Label11
            // 
            this.Label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label11.Location = new System.Drawing.Point(5, 191);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(220, 37);
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
            this.Label3.Size = new System.Drawing.Size(160, 37);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Gear";
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label2.Location = new System.Drawing.Point(712, 1);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(157, 37);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Pinion";
            // 
            // Label6
            // 
            this.Label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label6.Location = new System.Drawing.Point(234, 1);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(95, 37);
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
            this.Label18.Size = new System.Drawing.Size(365, 37);
            this.Label18.TabIndex = 18;
            this.Label18.Text = "Formula";
            // 
            // NumberOfTeethLabel
            // 
            this.NumberOfTeethLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumberOfTeethLabel.Location = new System.Drawing.Point(234, 191);
            this.NumberOfTeethLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NumberOfTeethLabel.Name = "NumberOfTeethLabel";
            this.NumberOfTeethLabel.Size = new System.Drawing.Size(95, 37);
            this.NumberOfTeethLabel.TabIndex = 19;
            // 
            // ShaftAngleLabel
            // 
            this.ShaftAngleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShaftAngleLabel.Location = new System.Drawing.Point(234, 77);
            this.ShaftAngleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShaftAngleLabel.Name = "ShaftAngleLabel";
            this.ShaftAngleLabel.Size = new System.Drawing.Size(95, 37);
            this.ShaftAngleLabel.TabIndex = 61;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(5, 1);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(220, 37);
            this.Label1.TabIndex = 64;
            this.Label1.Text = "Item";
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label4.Location = new System.Drawing.Point(5, 115);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(220, 37);
            this.Label4.TabIndex = 96;
            this.Label4.Text = "Module";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            this.Label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label7.Location = new System.Drawing.Point(5, 77);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(220, 37);
            this.Label7.TabIndex = 97;
            this.Label7.Text = "Shaft Angle";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModuleLabel
            // 
            this.ModuleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleLabel.Location = new System.Drawing.Point(234, 115);
            this.ModuleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModuleLabel.Name = "ModuleLabel";
            this.ModuleLabel.Size = new System.Drawing.Size(95, 37);
            this.ModuleLabel.TabIndex = 98;
            // 
            // ShaftAngleNnumericUpDown
            // 
            this.ShaftAngleNnumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.ShaftAngleNnumericUpDown, 2);
            this.ShaftAngleNnumericUpDown.DecimalPlaces = 3;
            this.ShaftAngleNnumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.ShaftAngleNnumericUpDown.Location = new System.Drawing.Point(712, 84);
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
            this.ModuleNumericUpDown.Location = new System.Drawing.Point(712, 122);
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
            this.PressureAngleNumericUpDown.Location = new System.Drawing.Point(712, 160);
            this.PressureAngleNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.PressureAngleNumericUpDown.Maximum = new decimal(new int[] { 35, 0, 0, 0 });
            this.PressureAngleNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.PressureAngleNumericUpDown.Name = "PressureAngleNumericUpDown";
            this.PressureAngleNumericUpDown.Size = new System.Drawing.Size(326, 22);
            this.PressureAngleNumericUpDown.TabIndex = 102;
            this.PressureAngleNumericUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
            this.PressureAngleNumericUpDown.ValueChanged += new System.EventHandler(this.pressureAngleNumericUpDown_ValueChanged);
            // 
            // Label15
            // 
            this.Label15.Location = new System.Drawing.Point(5, 229);
            this.Label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(180, 37);
            this.Label15.TabIndex = 15;
            this.Label15.Text = "Face Width";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FaceWidthLabel
            // 
            this.FaceWidthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FaceWidthLabel.Location = new System.Drawing.Point(234, 229);
            this.FaceWidthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FaceWidthLabel.Name = "FaceWidthLabel";
            this.FaceWidthLabel.Size = new System.Drawing.Size(95, 37);
            this.FaceWidthLabel.TabIndex = 23;
            // 
            // FaceWidthFormulaLabel
            // 
            this.FaceWidthFormulaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FaceWidthFormulaLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FaceWidthFormulaLabel.Location = new System.Drawing.Point(338, 229);
            this.FaceWidthFormulaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FaceWidthFormulaLabel.Name = "FaceWidthFormulaLabel";
            this.FaceWidthFormulaLabel.Size = new System.Drawing.Size(365, 37);
            this.FaceWidthFormulaLabel.TabIndex = 30;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(5, 277);
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
            this.PinionButton.Location = new System.Drawing.Point(712, 277);
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
            this.BuildGearButton.Location = new System.Drawing.Point(878, 277);
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
            this.FaceWidthNumericUpDown.Location = new System.Drawing.Point(712, 236);
            this.FaceWidthNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.FaceWidthNumericUpDown.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            this.FaceWidthNumericUpDown.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.FaceWidthNumericUpDown.Name = "FaceWidthNumericUpDown";
            this.FaceWidthNumericUpDown.Size = new System.Drawing.Size(326, 22);
            this.FaceWidthNumericUpDown.TabIndex = 122;
            this.FaceWidthNumericUpDown.Value = new decimal(new int[] { 22, 0, 0, 0 });
            this.FaceWidthNumericUpDown.ValueChanged += new System.EventHandler(this.faceWidthNumericUpDown_ValueChanged);
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
            this.TabPage1.PerformLayout();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfTeethGearNumericUpDown)).EndInit();
            this.TableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfTeethPinionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShaftAngleNnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureAngleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaceWidthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }


        public System.Windows.Forms.NumericUpDown FaceWidthNumericUpDown;
        private System.Windows.Forms.TabControl TabControl1;
private System.Windows.Forms.TabPage TabPage1;
public System.Windows.Forms.TextBox GearTextBox;
public System.Windows.Forms.TextBox PinionTextBox;
private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
private System.Windows.Forms.TableLayoutPanel TableLayoutPanel4;
private System.Windows.Forms.NumericUpDown NumberOfTeethGearNumericUpDown;
private System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
private System.Windows.Forms.NumericUpDown NumberOfTeethPinionNumericUpDown;
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