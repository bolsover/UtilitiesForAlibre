using System;
using System.Drawing;
using System.Windows.Forms;
using UtilitiesForAlibre.Properties;

namespace Bolsover.Shortcuts.View
{
    public partial class ColorPreferences : UserControl
    {
        
        public ColorPreferences()
        {
            InitializeComponent();
            GetColors();
        }

        private void GetColors()
        {
           CtrlAltShiftButton.BackColor = Properties.Settings.Default.CtrlAltShiftColor;
           CtrlAltButton.BackColor = Properties.Settings.Default.CtrlAltColor;
           CtrlShiftButton.BackColor = Properties.Settings.Default.CtrlShiftColor;
           AltShiftButton.BackColor = Properties.Settings.Default.AltShiftColor;
           CtrlButton.BackColor = Properties.Settings.Default.CtrlColor;
           AltButton.BackColor = Properties.Settings.Default.AltColor;
           ShiftButton.BackColor = Properties.Settings.Default.ShiftColor;
           NoModifierButton.BackColor = Properties.Settings.Default.NoModifierColor;
           ModifierKeyButton.BackColor = Properties.Settings.Default.ModifierKeyColor;
           textColorButton.ForeColor = Properties.Settings.Default.TextColor;
           textSizeUpDown.Value =  Properties.Settings.Default.KeyTextSize;
           iconScaleUpDown.Value = (decimal) Properties.Settings.Default.AlibreIcon;
           hintTextUpDown.Value = Properties.Settings.Default.HintTextSize;
        }
        

        private void CtrlAltShiftButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Properties.Settings.Default.CtrlAltShiftColor = colorDialog.Color;
            Properties.Settings.Default.Save();
            CtrlAltShiftButton.BackColor = colorDialog.Color;
        }

        private void CtrlAltButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Properties.Settings.Default.CtrlAltColor = colorDialog.Color;
            Properties.Settings.Default.Save();
            CtrlAltButton.BackColor = colorDialog.Color;
        }

        private void CtrlShiftButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Properties.Settings.Default.CtrlShiftColor = colorDialog.Color;
            Properties.Settings.Default.Save();
            CtrlShiftButton.BackColor = colorDialog.Color;
        }

        private void AltShiftButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Properties.Settings.Default.AltShiftColor = colorDialog.Color;
            Properties.Settings.Default.Save();
            AltShiftButton.BackColor = colorDialog.Color;
        }

        private void CtrlButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Properties.Settings.Default.CtrlColor = colorDialog.Color;
            Properties.Settings.Default.Save();
            CtrlButton.BackColor = colorDialog.Color;
        }

        private void AltButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Properties.Settings.Default.AltColor = colorDialog.Color;
            Properties.Settings.Default.Save();
            AltButton.BackColor = colorDialog.Color;
        }

        private void ShiftButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Properties.Settings.Default.ShiftColor = colorDialog.Color;
            Properties.Settings.Default.Save();
            ShiftButton.BackColor = colorDialog.Color;
        }

        private void NoModifierButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Properties.Settings.Default.NoModifierColor = colorDialog.Color;
            Properties.Settings.Default.Save();
            NoModifierButton.BackColor = colorDialog.Color;
        }

        private void ModifierKeyButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Properties.Settings.Default.ModifierKeyColor = colorDialog.Color;
            Properties.Settings.Default.Save();
            ModifierKeyButton.BackColor = colorDialog.Color;
        }

        private void ResetDefaultsButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CtrlAltShiftColor = Color.Red;
            Properties.Settings.Default.CtrlAltColor = Color.Orange;
            Properties.Settings.Default.CtrlShiftColor = Color.Gold;
            Properties.Settings.Default.AltShiftColor = Color.Chartreuse;
            Properties.Settings.Default.CtrlColor = Color.CornflowerBlue;
            Properties.Settings.Default.AltColor = Color.MediumOrchid;
            Properties.Settings.Default.ShiftColor = Color.Violet;
            Properties.Settings.Default.NoModifierColor = Color.Bisque;
            Properties.Settings.Default.ModifierKeyColor = Color.Bisque;
            Properties.Settings.Default.TextColor = Color.Black;
            Properties.Settings.Default.KeyTextSize = 9;
            Properties.Settings.Default.HintTextSize = 13;
            Properties.Settings.Default.AlibreIcon = 0.6;
            Properties.Settings.Default.Save();
            GetColors();
        }

      

    

        private void textSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown numericUpDown) return;
            var newValue = (short) numericUpDown.Value;
            Properties.Settings.Default.KeyTextSize = newValue;
        }

        private void textColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            Properties.Settings.Default.TextColor = colorDialog.Color;
            Properties.Settings.Default.Save();
            textColorButton.ForeColor = colorDialog.Color;
        }

        private void iconScaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown numericUpDown) return;
            var newValue = (double) numericUpDown.Value;
            Properties.Settings.Default.AlibreIcon = newValue;
        }

        private void hintTextUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown numericUpDown) return;
            var newValue = (short) numericUpDown.Value;
            Properties.Settings.Default.HintTextSize = newValue;
        }
    }
}