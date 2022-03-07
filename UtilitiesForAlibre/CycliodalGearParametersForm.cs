using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AlibreX;

namespace Bolsover
{
    public partial class CycliodalGearParametersForm : Form
    {
        private IADDesignSession session;
        private CycloidalGearProperties GearProperties = new();

        public CycliodalGearParametersForm(IADSession session)
        {
            this.session = (IADDesignSession) session;
            InitializeComponent();
            ListPlanes();
        }

        #region ChangeListeners

        private void moduleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GearProperties.Module = (double) ((NumericUpDown) sender).Value;
        }

        private void pinionToothCountUpDown_ValueChanged(object sender, EventArgs e)
        {
            GearProperties.PinionCount = (int) ((NumericUpDown) sender).Value;
        }

        private void wheelToothCountUpDwn_ValueChanged(object sender, EventArgs e)
        {
            GearProperties.WheelCount = (int) ((NumericUpDown) sender).Value;
        }

        private void wheelCenterHoleUpDown_ValueChanged(object sender, EventArgs e)
        {
            GearProperties.WheelCentreHole = (double) ((NumericUpDown) sender).Value;
        }

        private void pinionCenterHoleUpDown_ValueChanged(object sender, EventArgs e)
        {
            GearProperties.PinionCentreHole = (double) ((NumericUpDown) sender).Value;
        }

        private void customSlopUpDown_ValueChanged(object sender, EventArgs e)
        {
            GearProperties.CustomSlop = (double) ((NumericUpDown) sender).Value;
        }

        private void customSlopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GearProperties.CustomSlopEnabled = ((CheckBox) sender).Checked;
        }

        private void drawWheelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GearProperties.DrawWheel = ((CheckBox) sender).Checked;
        }

        private void drawPinionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GearProperties.DrawPinion = ((CheckBox) sender).Checked;
        }

        private void planesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GearProperties.Plane = ((KeyValuePair<IADDesignPlane, string>) ((ComboBox) sender).SelectedItem).Key;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (GearProperties.Plane == null)
                GearProperties.Plane = ((KeyValuePair<IADDesignPlane, string>) planesComboBox.Items[0]).Key;

            var builder = new CycloidalGearBuilder(GearProperties, session);
            MessageBox.Show(GearProperties.ToString(), "Gear Properties", MessageBoxButtons.OK);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion

        /// <summary>
        /// Returns the IADDesignPlanes collection from the current session.
        /// </summary>
        /// <returns></returns>
        private IADDesignPlanes DesignPanes()
        {
            return session.DesignPlanes;
        }

        /// <summary>
        /// Creates a dictionary of design planes existing in the current session and adds these to the planesComboBox.
        /// </summary>
        private void ListPlanes()
        {
            var comboSource = new Dictionary<IADDesignPlane, string>();
            foreach (IADDesignPlane designPlane in DesignPanes()) comboSource.Add(designPlane, designPlane.Name);

            planesComboBox.DataSource = new BindingSource(comboSource, null);
            planesComboBox.DisplayMember = "Value";
            planesComboBox.ValueMember = "Key";
        }
    }
}