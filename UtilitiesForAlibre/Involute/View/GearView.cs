using System;
using System.Windows.Forms;
using Bolsover.Involute.Presenter;

namespace Bolsover.Involute.View
{
    public partial class GearView : UserControl
    {
        public GearViewPresenter Presenter;
        public GearView()
        {
            InitializeComponent();
            Presenter = new GearViewPresenter(this);
        }
        
        public event EventHandler BuildGearEvent;
        public event EventHandler BuildPinionEvent;
        public event EventHandler CancelEvent;
        public event EventHandler EditModuleEvent;
        public event EventHandler EditPressureAngleEvent;
        public event EventHandler EditPinionNumberOfTeethEvent;
        public event EventHandler EditGearNumberOfTeethEvent;
        public event EventHandler EditHelixAngleEvent;
        public event EventHandler EditGearHeightEvent;
        public event EventHandler AutoManualEvent;
        public event EventHandler EditCentreDistanceEvent;
        public event EventHandler EditGearStyleEvent;
        public event EventHandler EditPinionStyleEvent;
        public event EventHandler EditPinionProfileShiftEvent;
        public event EventHandler EditGearProfileShiftEvent;
        public event EventHandler EditNormalBacklashEvent;
        public event EventHandler EditRootFilletFactorEvent;
        public event EventHandler EditAddendumFilletFactorEvent;

        private void teethNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditGearNumberOfTeethEvent?.Invoke(sender, e);
        }
        
        private void heightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditGearHeightEvent?.Invoke(sender, e);
        }

        private void moduleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditModuleEvent?.Invoke(sender, e);
        }

        private void pressureAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditPressureAngleEvent?.Invoke(sender, e);
        }

        private void helixAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditHelixAngleEvent?.Invoke(sender, e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelEvent?.Invoke(sender, e);
        }

        private void buildGearButton_Click(object sender, EventArgs e)
        {
            BuildGearEvent?.Invoke(sender, e);
        }

        private void autoManualButton_Click(object sender, EventArgs e)
        {
            AutoManualEvent?.Invoke(sender, e);
        }

        private void pinionTeethNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditPinionNumberOfTeethEvent?.Invoke(sender, e);
        }

        private void buildPinionButton_Click(object sender, EventArgs e)
        {
            BuildPinionEvent?.Invoke(sender, e);
        }
        private void intRadioButton_CheckedChanged(object sender, EventArgs e)
        {
           
            EditGearStyleEvent?.Invoke(sender, e);
        }
        private void extRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            EditGearStyleEvent?.Invoke(sender, e);
        }


        private void operatingCentreDistanceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditCentreDistanceEvent?.Invoke(sender, e);
        }

        private void pinionProfileShiftNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditPinionProfileShiftEvent?.Invoke(sender, e);
        }

        private void gearProfileShiftNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditGearProfileShiftEvent?.Invoke(sender, e);
        }

        private void normalBacklashNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditNormalBacklashEvent?.Invoke(sender, e);
        }

        private void rootFilletFactorNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditRootFilletFactorEvent?.Invoke(sender, e);
        }

        private void addendumFilletFactorNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditAddendumFilletFactorEvent?.Invoke(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}