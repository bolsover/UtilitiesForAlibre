using System;
using System.Reflection;
using System.Windows.Forms;
using Bolsover.Involute.Images;
using Bolsover.Utils;

namespace UnitTests
{
    public class LatexImageForm : Form
    {
        // private IContainer components = null;
        private readonly FieldInfo[] _props;
        private int _index = 0;
        private readonly GearLatexStrings _instance = new();
        private Button _nextbutton;
        private Button _previousbutton;


        private Label _latexLabel;
        private FieldInfo _info;

        public LatexImageForm()
        {
            InitializeComponent();
            _props = typeof(GearLatexStrings).GetFields();
            _latexLabel.Text = "Click next to check Latex formulae";
        }


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _latexLabel = new Label();
            _nextbutton = new Button();
            _previousbutton = new Button();
            SuspendLayout();
            // 
            // latexLabel
            // 
            _latexLabel.Location = new System.Drawing.Point(86, 80);
            _latexLabel.Name = "_latexLabel";
            _latexLabel.Size = new System.Drawing.Size(268, 138);
            _latexLabel.TabIndex = 0;
            // 
            // nextbutton
            // 
            _nextbutton.Location = new System.Drawing.Point(124, 259);
            _nextbutton.Name = "_nextbutton";
            _nextbutton.Size = new System.Drawing.Size(75, 23);
            _nextbutton.TabIndex = 2;
            _nextbutton.Text = "Next";
            _nextbutton.UseVisualStyleBackColor = true;
            _nextbutton.Click += new System.EventHandler(this.NextbuttonClick);
            // 
            // previousbutton
            // 
            _previousbutton.Location = new System.Drawing.Point(50, 259);
            _previousbutton.Name = "_previousbutton";
            _previousbutton.Size = new System.Drawing.Size(75, 23);
            _previousbutton.TabIndex = 1;
            _previousbutton.Text = "Previous";
            _previousbutton.UseVisualStyleBackColor = true;
            _previousbutton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // LatexImageForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(this._nextbutton);
            Controls.Add(this._previousbutton);
            Controls.Add(this._latexLabel);
            Name = "LatexImageForm";
            Text = "GearsForm";
            ResumeLayout(false);
        }


        

        private void NextbuttonClick(object sender, EventArgs e)
        {
            if (_index >= _props.Length - 1) return;
            _info = _props[_index++];
            var value = _info.Name;
            var property = _instance.GetType().GetField(value).GetValue(_instance);

            if (property == null) return;
            _latexLabel.Text = value;
            _latexLabel.Image = LatexUtils.CreateImageFromLatex(property.ToString());
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (_index <= 0) return;
            _info = _props[_index--];
            var value = _info.Name;
            var property = _instance.GetType().GetField(value).GetValue(_instance);

            if (property == null) return;
            _latexLabel.Text = value;
            _latexLabel.Image = LatexUtils.CreateImageFromLatex(property.ToString());
        }
    }
}