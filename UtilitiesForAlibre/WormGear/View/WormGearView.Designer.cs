using System.ComponentModel;

namespace Bolsover.WormGear.View
{
    partial class WormGearView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.normalRadio = new System.Windows.Forms.RadioButton();
            this.axialRadio = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.alphaSymbolLabel = new System.Windows.Forms.Label();
            this.moduleSymbolLabel = new System.Windows.Forms.Label();
            this.moduleUpDown = new System.Windows.Forms.NumericUpDown();
            this.pressureAngleUpDown = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.wormButton = new System.Windows.Forms.Button();
            this.gearButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.wormLengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.gearWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn2 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn3 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn4 = new BrightIdeasSoftware.OLVColumn();
            this.threadsTeethSymbolLabel = new System.Windows.Forms.Label();
            this.threadsUpDown = new System.Windows.Forms.NumericUpDown();
            this.teethUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.wormPdUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureAngleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wormLengthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gearWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teethUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wormPdUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.normalRadio);
            this.groupBox1.Controls.Add(this.axialRadio);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 74);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Module Type";
            // 
            // normalRadio
            // 
            this.normalRadio.Location = new System.Drawing.Point(6, 50);
            this.normalRadio.Name = "normalRadio";
            this.normalRadio.Size = new System.Drawing.Size(231, 24);
            this.normalRadio.TabIndex = 1;
            this.normalRadio.Text = "Normal Module";
            this.normalRadio.UseVisualStyleBackColor = true;
            // 
            // axialRadio
            // 
            this.axialRadio.Location = new System.Drawing.Point(6, 21);
            this.axialRadio.Name = "axialRadio";
            this.axialRadio.Size = new System.Drawing.Size(231, 24);
            this.axialRadio.TabIndex = 0;
            this.axialRadio.Text = "Axial Module";
            this.axialRadio.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(241, 37);
            this.label8.TabIndex = 7;
            this.label8.Text = "Threads, Teeth";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(241, 37);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pressure Angle";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 37);
            this.label5.TabIndex = 4;
            this.label5.Text = "Module";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(736, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "Worm Gear";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(529, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Worm";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Symbol";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.91689F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.08311F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.alphaSymbolLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.moduleSymbolLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.moduleUpDown, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.pressureAngleUpDown, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.wormButton, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.gearButton, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.wormLengthUpDown, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.gearWidthUpDown, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.objectListView1, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.threadsTeethSymbolLabel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.threadsUpDown, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.teethUpDown, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.wormPdUpDown, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 773);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // alphaSymbolLabel
            // 
            this.alphaSymbolLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alphaSymbolLabel.Location = new System.Drawing.Point(250, 154);
            this.alphaSymbolLabel.Name = "alphaSymbolLabel";
            this.alphaSymbolLabel.Size = new System.Drawing.Size(273, 37);
            this.alphaSymbolLabel.TabIndex = 10;
            this.alphaSymbolLabel.Text = "alpha symbol";
            this.alphaSymbolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // moduleSymbolLabel
            // 
            this.moduleSymbolLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduleSymbolLabel.Location = new System.Drawing.Point(250, 117);
            this.moduleSymbolLabel.Name = "moduleSymbolLabel";
            this.moduleSymbolLabel.Size = new System.Drawing.Size(273, 37);
            this.moduleSymbolLabel.TabIndex = 9;
            this.moduleSymbolLabel.Text = "module symbol";
            this.moduleSymbolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // moduleUpDown
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.moduleUpDown, 2);
            this.moduleUpDown.DecimalPlaces = 3;
            this.moduleUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduleUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.moduleUpDown.Location = new System.Drawing.Point(529, 120);
            this.moduleUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            this.moduleUpDown.Name = "moduleUpDown";
            this.moduleUpDown.Size = new System.Drawing.Size(399, 22);
            this.moduleUpDown.TabIndex = 12;
            this.moduleUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            this.moduleUpDown.ValueChanged += new System.EventHandler(this.moduleUpDown_ValueChanged);
            // 
            // pressureAngleUpDown
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pressureAngleUpDown, 2);
            this.pressureAngleUpDown.DecimalPlaces = 3;
            this.pressureAngleUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pressureAngleUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.pressureAngleUpDown.Location = new System.Drawing.Point(529, 157);
            this.pressureAngleUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.pressureAngleUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.pressureAngleUpDown.Name = "pressureAngleUpDown";
            this.pressureAngleUpDown.Size = new System.Drawing.Size(399, 22);
            this.pressureAngleUpDown.TabIndex = 13;
            this.pressureAngleUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
            this.pressureAngleUpDown.ValueChanged += new System.EventHandler(this.pressureAngleUpDown_ValueChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.Location = new System.Drawing.Point(3, 305);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(241, 31);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // wormButton
            // 
            this.wormButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wormButton.Location = new System.Drawing.Point(529, 305);
            this.wormButton.Name = "wormButton";
            this.wormButton.Size = new System.Drawing.Size(201, 31);
            this.wormButton.TabIndex = 17;
            this.wormButton.Text = "Build Worm";
            this.wormButton.UseVisualStyleBackColor = true;
            this.wormButton.Click += new System.EventHandler(this.wormButton_Click);
            // 
            // gearButton
            // 
            this.gearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gearButton.Location = new System.Drawing.Point(736, 305);
            this.gearButton.Name = "gearButton";
            this.gearButton.Size = new System.Drawing.Size(192, 31);
            this.gearButton.TabIndex = 18;
            this.gearButton.Text = "Build Gear";
            this.gearButton.UseVisualStyleBackColor = true;
            this.gearButton.Click += new System.EventHandler(this.gearButton_Click);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 37);
            this.label7.TabIndex = 19;
            this.label7.Text = "Worm Length, Gear Width";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wormLengthUpDown
            // 
            this.wormLengthUpDown.DecimalPlaces = 3;
            this.wormLengthUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wormLengthUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.wormLengthUpDown.Location = new System.Drawing.Point(529, 268);
            this.wormLengthUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.wormLengthUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.wormLengthUpDown.Name = "wormLengthUpDown";
            this.wormLengthUpDown.Size = new System.Drawing.Size(201, 22);
            this.wormLengthUpDown.TabIndex = 20;
            this.wormLengthUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            this.wormLengthUpDown.ValueChanged += new System.EventHandler(this.wormLengthUpDown_ValueChanged);
            // 
            // gearWidthUpDown
            // 
            this.gearWidthUpDown.DecimalPlaces = 3;
            this.gearWidthUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gearWidthUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.gearWidthUpDown.Location = new System.Drawing.Point(736, 268);
            this.gearWidthUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.gearWidthUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.gearWidthUpDown.Name = "gearWidthUpDown";
            this.gearWidthUpDown.Size = new System.Drawing.Size(192, 22);
            this.gearWidthUpDown.TabIndex = 21;
            this.gearWidthUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            this.gearWidthUpDown.ValueChanged += new System.EventHandler(this.gearWidthUpDown_ValueChanged);
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.AllColumns.Add(this.olvColumn3);
            this.objectListView1.AllColumns.Add(this.olvColumn4);
            this.objectListView1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.olvColumn1, this.olvColumn2, this.olvColumn3, this.olvColumn4 });
            this.tableLayoutPanel1.SetColumnSpan(this.objectListView1, 4);
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.HideSelection = false;
            this.objectListView1.Location = new System.Drawing.Point(3, 342);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(925, 428);
            this.objectListView1.TabIndex = 22;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColumn1.Text = "Item";
            this.olvColumn1.Width = 274;
            // 
            // olvColumn2
            // 
            this.olvColumn2.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColumn2.Text = "Metric";
            this.olvColumn2.Width = 129;
            // 
            // olvColumn3
            // 
            this.olvColumn3.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColumn3.Text = "Imperial";
            this.olvColumn3.Width = 138;
            // 
            // olvColumn4
            // 
            this.olvColumn4.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColumn4.Text = "Notes";
            this.olvColumn4.Width = 185;
            // 
            // threadsTeethSymbolLabel
            // 
            this.threadsTeethSymbolLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threadsTeethSymbolLabel.Location = new System.Drawing.Point(250, 191);
            this.threadsTeethSymbolLabel.Name = "threadsTeethSymbolLabel";
            this.threadsTeethSymbolLabel.Size = new System.Drawing.Size(273, 37);
            this.threadsTeethSymbolLabel.TabIndex = 11;
            this.threadsTeethSymbolLabel.Text = "threads teeth symbol";
            this.threadsTeethSymbolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // threadsUpDown
            // 
            this.threadsUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threadsUpDown.Location = new System.Drawing.Point(529, 194);
            this.threadsUpDown.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            this.threadsUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.threadsUpDown.Name = "threadsUpDown";
            this.threadsUpDown.Size = new System.Drawing.Size(201, 22);
            this.threadsUpDown.TabIndex = 14;
            this.threadsUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.threadsUpDown.ValueChanged += new System.EventHandler(this.threadsUpDown_ValueChanged);
            // 
            // teethUpDown
            // 
            this.teethUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teethUpDown.Location = new System.Drawing.Point(736, 194);
            this.teethUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.teethUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.teethUpDown.Name = "teethUpDown";
            this.teethUpDown.Size = new System.Drawing.Size(192, 22);
            this.teethUpDown.TabIndex = 15;
            this.teethUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            this.teethUpDown.ValueChanged += new System.EventHandler(this.teethUpDown_ValueChanged);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(241, 37);
            this.label9.TabIndex = 23;
            this.label9.Text = "Worm Pitch Dia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(250, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(273, 37);
            this.label10.TabIndex = 24;
            this.label10.Text = "worm pitch dia symbol";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wormPdUpDown
            // 
            this.wormPdUpDown.DecimalPlaces = 3;
            this.wormPdUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wormPdUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.wormPdUpDown.Location = new System.Drawing.Point(529, 231);
            this.wormPdUpDown.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.wormPdUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.wormPdUpDown.Name = "wormPdUpDown";
            this.wormPdUpDown.Size = new System.Drawing.Size(201, 22);
            this.wormPdUpDown.TabIndex = 25;
            this.wormPdUpDown.Value = new decimal(new int[] { 37, 0, 0, 0 });
            // 
            // WormGearView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "WormGearView";
            this.Size = new System.Drawing.Size(931, 773);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moduleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureAngleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wormLengthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gearWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teethUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wormPdUpDown)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown wormPdUpDown;

        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.Label label9;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown wormLengthUpDown;
        private System.Windows.Forms.NumericUpDown gearWidthUpDown;
        private System.Windows.Forms.NumericUpDown moduleUpDown;
        private System.Windows.Forms.NumericUpDown pressureAngleUpDown;
        private System.Windows.Forms.NumericUpDown threadsUpDown;
        private System.Windows.Forms.NumericUpDown teethUpDown;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button wormButton;
        private System.Windows.Forms.Button gearButton;
        public System.Windows.Forms.Label moduleSymbolLabel;
        public System.Windows.Forms.Label alphaSymbolLabel;
        public System.Windows.Forms.Label threadsTeethSymbolLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton axialRadio;
        private System.Windows.Forms.RadioButton normalRadio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        
        #endregion
    }
}