using System;
using System.Windows.Forms;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Presenters;


namespace Bolsover.Bevel.Views
{
    public partial class BevelGearView : UserControl, IBevelGearView
    {
        
        private BevelGearPresenter _bevelGearPresenter;
        public BevelGearView()
        {
            InitializeComponent();
            _bevelGearPresenter = new BevelGearPresenter(this);
          
        }

        IBevelGear IBevelGearView.Pinion { get; set; }
        IBevelGear IBevelGearView.Gear { get; set; }
        private event EventHandler BuildPinionEvent;

        event EventHandler IBevelGearView.BuildPinionEvent
        {
            add => BuildPinionEvent += value;
            remove => BuildPinionEvent -= value;
        }

        private event EventHandler BuildGearEvent;
        private event EventHandler CancelEvent;

        event EventHandler IBevelGearView.CancelEvent
        {
            add => CancelEvent += value;
            remove => CancelEvent -= value;
        }

        event EventHandler IBevelGearView.BuildGearEvent
        {
            add => BuildGearEvent += value;
            remove => BuildGearEvent -= value;
        }

        private event EventHandler EditModuleEvent;

        event EventHandler IBevelGearView.EditModuleEvent
        {
            add => EditModuleEvent += value;
            remove => EditModuleEvent -= value;
        }

        private event EventHandler EditShaftAngleEvent;

        event EventHandler IBevelGearView.EditShaftAngleEvent
        {
            add => EditShaftAngleEvent += value;
            remove => EditShaftAngleEvent -= value;
        }

        private event EventHandler EditPressureAngleEvent;

        event EventHandler IBevelGearView.EditPressureAngleEvent
        {
            add => EditPressureAngleEvent += value;
            remove => EditPressureAngleEvent -= value;
        }

        private event EventHandler EditSpiralAngleEvent;

        event EventHandler IBevelGearView.EditSpiralAngleEvent
        {
            add => EditSpiralAngleEvent += value;
            remove => EditSpiralAngleEvent -= value;
        }

        private event EventHandler EditPinionNumberOfTeethEvent;

        event EventHandler IBevelGearView.EditPinionNumberOfTeethEvent
        {
            add => EditPinionNumberOfTeethEvent += value;
            remove => EditPinionNumberOfTeethEvent -= value;
        }

        private event EventHandler EditPinionHandEvent;

        event EventHandler IBevelGearView.EditPinionHandEvent
        {
            add => EditPinionHandEvent += value;
            remove => EditPinionHandEvent -= value;
        }

        private event EventHandler EditGearNumberOfTeethEvent;

        event EventHandler IBevelGearView.EditGearNumberOfTeethEvent
        {
            add => EditGearNumberOfTeethEvent += value;
            remove => EditGearNumberOfTeethEvent -= value;
        }

        private event EventHandler EditGearHandEvent;

        event EventHandler IBevelGearView.EditGearHandEvent
        {
            add => EditGearHandEvent += value;
            remove => EditGearHandEvent -= value;
        }

        private event EventHandler EditFaceWidthEvent;

        event EventHandler IBevelGearView.EditFaceWidthEvent
        {
            add => EditFaceWidthEvent += value;
            remove => EditFaceWidthEvent -= value;
        }

        private event EventHandler EditGearTypeEvent;


        event EventHandler IBevelGearView.EditGearTypeEvent
        {
            add => EditGearTypeEvent += value;
            remove => EditGearTypeEvent -= value;
        }


        private void pinionButton_Click(object sender, EventArgs e)
        {
            BuildPinionEvent?.Invoke(sender, e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelEvent?.Invoke(sender, e);
        }


        private void buildGearButton_Click(object sender, EventArgs e)
        {
            BuildGearEvent?.Invoke(sender, e);
        }

        private void gearTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditGearTypeEvent?.Invoke(sender, e);
        }

        private void shaftAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditShaftAngleEvent?.Invoke(sender, e);
        }

        private void moduleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditModuleEvent?.Invoke(sender, e);
        }

        private void pressureAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditPressureAngleEvent?.Invoke(sender, e);
        }

        private void spiralAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditSpiralAngleEvent?.Invoke(sender, e);
        }

        private void numberOfTeethPinionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditPinionNumberOfTeethEvent?.Invoke(sender, e);
        }

        private void pinionHandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditPinionHandEvent?.Invoke(sender, e);
        }

        private void numberOfTeethGearNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditGearNumberOfTeethEvent?.Invoke(sender, e);
        }

        private void gearHandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditGearHandEvent?.Invoke(sender, e);
        }

        private void faceWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EditFaceWidthEvent?.Invoke(sender, e);
        }

       
        private void gleasonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            EditGearTypeEvent?.Invoke(sender, e);
        }

        private void standardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            EditGearTypeEvent?.Invoke(sender, e);
        }

        
    }
}