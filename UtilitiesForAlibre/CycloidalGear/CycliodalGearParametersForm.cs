using System;
using System.Windows.Forms;
using AlibreX;

namespace Bolsover.CycloidalGear
{
    public partial class CycliodalGearParametersForm : UserControl
    {
        private IADDesignSession session;
        private CycloidalGearProperties GearProperties = new();
        private IADDesignPlane designPlane;
       

        public CycliodalGearParametersForm(IADSession session)
        {
            this.session = (IADDesignSession) session;
            InitializeComponent();
            initParameters();
        }

        public IADDesignPlane DesignPlane
        {
            get => designPlane;
            
            set{
                designPlane = value;
                GearProperties.Plane = DesignPlane;
                planeTextBox.Text = designPlane.Name;
            }
            
        }

  

        private void initParameters()
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

     
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (GearProperties.Plane == null)
            {
                MessageBox.Show("Please select a Plane for the gear sketch.", "Error", MessageBoxButtons.OK); 
                return;
            }
            
            var builder = new CycloidalGearBuilder(GearProperties, session);
            MessageBox.Show(GearProperties.ToString(), "Gear Properties", MessageBoxButtons.OK);
        }

      

        #endregion

       
    }
}