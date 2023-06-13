using System;
using System.Windows.Forms;
using AlibreX;

namespace Bolsover.CycloidalGear
{
    public partial class CycliodalGearParametersForm : UserControl
    {
        private IADDesignSession _session;
        private CycloidalGearProperties _gearProperties = new();
        private IADDesignPlane _designPlane;


        public CycliodalGearParametersForm(IADSession session)
        {
            this._session = (IADDesignSession) session;
            InitializeComponent();
            InitParameters();
        }

        public IADDesignPlane DesignPlane
        {
            get => _designPlane;

            set
            {
                _designPlane = value;
                _gearProperties.Plane = DesignPlane;
                planeTextBox.Text = _designPlane.Name;
            }
        }


        private void InitParameters()
        {
            moduleNumericUpDown.Value = (decimal) 4.0;
            wheelToothCountUpDwn.Value = 30;
            pinionToothCountUpDown.Value = 8;
            wheelCenterHoleUpDown.Value = (decimal) 6.0;
            pinionCenterHoleUpDown.Value = (decimal) 3.0;
            customSlopUpDown.Value = (decimal) 0.0;
            customSlopCheckBox.Checked = false;
            drawWheelCheckBox.Checked = true;
            drawPinionCheckBox.Checked = true;
        }

        #region ChangeListeners

        private void moduleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _gearProperties.Module = (double) ((NumericUpDown) sender).Value;
        }

        private void pinionToothCountUpDown_ValueChanged(object sender, EventArgs e)
        {
            _gearProperties.PinionCount = (int) ((NumericUpDown) sender).Value;
        }

        private void wheelToothCountUpDwn_ValueChanged(object sender, EventArgs e)
        {
            _gearProperties.WheelCount = (int) ((NumericUpDown) sender).Value;
        }

        private void wheelCenterHoleUpDown_ValueChanged(object sender, EventArgs e)
        {
            _gearProperties.WheelCentreHole = (double) ((NumericUpDown) sender).Value;
        }

        private void pinionCenterHoleUpDown_ValueChanged(object sender, EventArgs e)
        {
            _gearProperties.PinionCentreHole = (double) ((NumericUpDown) sender).Value;
        }

        private void customSlopUpDown_ValueChanged(object sender, EventArgs e)
        {
            _gearProperties.CustomSlop = (double) ((NumericUpDown) sender).Value;
        }

        private void customSlopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _gearProperties.CustomSlopEnabled = ((CheckBox) sender).Checked;
        }

        private void drawWheelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _gearProperties.DrawWheel = ((CheckBox) sender).Checked;
        }

        private void drawPinionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _gearProperties.DrawPinion = ((CheckBox) sender).Checked;
        }


        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (_gearProperties.Plane == null)
            {
                MessageBox.Show("Please select a Plane for the gear sketch.", "Error", MessageBoxButtons.OK);
                return;
            }

            var builder = new CycloidalGearBuilder(_gearProperties, _session);
            MessageBox.Show(_gearProperties.ToString(), "Gear Properties", MessageBoxButtons.OK);
        }

        #endregion
    }
}