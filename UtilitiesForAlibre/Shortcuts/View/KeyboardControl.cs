using System;
using System.Windows.Forms;
using Bolsover.Shortcuts.Presenter;


namespace Bolsover.Shortcuts.View
{
    public partial class KeyboardControl : UserControl
    {
        
     
     private readonly KeyboardPresenter _keyboardPresenter;
    
        public KeyboardControl()
        {
            InitializeComponent();
            _keyboardPresenter = new KeyboardPresenter(this);
           
        }

        private void LeftCtrlKey_Click(object sender, EventArgs e)
        {
            _keyboardPresenter.ViewCtrl_Click(sender, e);
        }

        private void RightCtrlKey_Click(object sender, EventArgs e)
        {
            _keyboardPresenter.ViewCtrl_Click(sender, e);
        }

        private void LeftShiftKey_Click(object sender, EventArgs e)
        {
            _keyboardPresenter.ViewShift_Click(sender, e);
        }

        private void RightShiftKey_Click(object sender, EventArgs e)
        {
            _keyboardPresenter.ViewShift_Click(sender, e);
        }

        private void LeftAltKey_Click(object sender, EventArgs e)
        {
            _keyboardPresenter.ViewAlt_Click(sender, e);
        }

        private void AltGrKey_Click(object sender, EventArgs e)
        {
            _keyboardPresenter.ViewAlt_Click(sender, e);
        }

        private void ProfileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _keyboardPresenter.ProfileComboBox_SelectedIndexChanged(sender, e);
        }

        private void PauseBreakKey_Click(object sender, EventArgs e)
        {
            ColorPreferencesForm colorPreferencesForm = new ColorPreferencesForm();
            
            colorPreferencesForm.TopMost = true;
            colorPreferencesForm.ShowDialog();
        }

       
    }
}