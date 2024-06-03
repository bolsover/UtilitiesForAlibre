using System;
using System.Windows.Forms;
using Bolsover.WormGear.Presenter;

namespace Bolsover.WormGear.View
{
    public partial class WormGearView : UserControl
    {
        private WormGearPresenter _presenter;
        
        public WormGearView()
        {
            InitializeComponent();
            _presenter = new WormGearPresenter(this);
        }
        
        public event EventHandler CancelEvent;
        public event EventHandler EditModuleEvent;
        public event EventHandler EditPressureAngleEvent;
        public event EventHandler EditWormThreadsEvent;
        public event EventHandler EditGearTeethEvent;
        
        public event EventHandler BuildWormEvent;
        public event EventHandler BuildGearEvent;
        public event EventHandler WormLengthEvent;
        public event EventHandler GearWidthEvent;
        public event EventHandler WormPdEvent;
        
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelEvent?.Invoke(sender, e);
        }
        
        private void wormButton_Click(object sender, EventArgs e)
        {
            BuildWormEvent?.Invoke(sender, e);
        }
        
        private void gearButton_Click(object sender, EventArgs e)
        {
            BuildGearEvent?.Invoke(sender, e);
        }
        
        private void moduleUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditModuleEvent?.Invoke(sender, e);
        }
        
        private void pressureAngleUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditPressureAngleEvent?.Invoke(sender, e);
        }
        
        private void threadsUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditWormThreadsEvent?.Invoke(sender, e);
        }
        
        private void teethUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditGearTeethEvent?.Invoke(sender, e);
        }
        
        
        private void wormLengthUpDown_ValueChanged(object sender, EventArgs e)
        {
            WormLengthEvent?.Invoke(sender, e);
        }
        
        private void gearWidthUpDown_ValueChanged(object sender, EventArgs e)
        {
            GearWidthEvent?.Invoke(sender, e);
        }
        
        private void wormPdUpDown_ValueChanged(object sender, EventArgs e)
        {
            WormPdEvent?.Invoke(sender, e);
        }
    }
}