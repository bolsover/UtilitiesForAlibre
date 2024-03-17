
using System;
using System.Windows.Forms;
using Bolsover.RackPinion.Presenter;

namespace Bolsover.RackPinion.View
{
    public partial class RackPinionView : UserControl
    {
        private RackPinionPresenter _presenter;
        public event EventHandler BuildRackEvent;
        public event EventHandler BuildPinionEvent;
        public event EventHandler CancelEvent;
                public event EventHandler EditModuleEvent;
                public event EventHandler EditPressureAngleEvent;
                public event EventHandler EditPinionNumberOfTeethEvent;
                public event EventHandler EditGearNumberOfTeethEvent;
                public event EventHandler EditHelixAngleEvent;
                public event EventHandler EditGearHeightEvent;
                
        public RackPinionView()
        { 
            InitializeComponent();
            _presenter = new RackPinionPresenter(this);
            
        }


        private void rackButton_Click(object sender, EventArgs e)
        {
            BuildRackEvent?.Invoke(sender, e);
        }


        private void pinionButton_Click(object sender, EventArgs e)
        {
            BuildPinionEvent?.Invoke(sender, e);
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

        private void pinionTeethNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditPinionNumberOfTeethEvent?.Invoke(sender, e);
        }

        private void gearTeethNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditGearNumberOfTeethEvent?.Invoke(sender, e);
        }

        private void widthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditGearHeightEvent?.Invoke(sender, e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelEvent?.Invoke(sender, e);
        }
    }
}