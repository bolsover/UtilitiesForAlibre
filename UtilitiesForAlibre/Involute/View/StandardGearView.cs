using System;
using System.Windows.Forms;
using Bolsover.Involute.Presenter;

namespace Bolsover.Involute.View
{
    public partial class StandardGearView : UserControl
    {
        // private Form _parentForm;

        public StandardGearView()
        {
            InitializeComponent();
            new StandardGearPresenter(this);
        }

        public event EventHandler BuildGearEvent;
        
        public event EventHandler CancelEvent;
        public event EventHandler EditModuleEvent;
        public event EventHandler EditPressureAngleEvent;
        
        public event EventHandler EditGearNumberOfTeethEvent;
        public event EventHandler EditHelixAngleEvent;
        public event EventHandler EditGearHeightEvent;
       

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
    }
}