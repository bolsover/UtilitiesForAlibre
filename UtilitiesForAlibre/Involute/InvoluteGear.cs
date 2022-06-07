using System;
using System.Linq;
using System.Windows.Forms;
using AlibreX;

namespace Bolsover.Involute
{
    public partial class InvoluteGear : UserControl
    {
        private InvoluteProperties properties = new();
        private IADDesignPlane designPlane;
        private IADDesignSession session;

        public InvoluteGear(IADSession session)
        {
            this.session = (IADDesignSession) session;
            initProperties();
            InitializeComponent();
            initBindings();
        }

        public IADDesignPlane DesignPlane
        {
            get => designPlane;
            set
            {
                designPlane = value;
                properties.Plane = designPlane;
                planeTextBox.Text = designPlane.Name;
            }
        }

        public IADDesignSession Session
        {
            get => session;
            set => session = value;
        }

        private void initProperties()
        {
            properties.Module = 1.0;
            properties.ToothCount = 10;
            properties.PressureAngle = 20;
            properties.Clearance = 0.167;
            properties.WheelCentreX = 0.0;
            properties.WheelCentreY = 0.0;
            properties.ProfileShiftFactor = 0.3;
            properties.RootClearance = 0.25;
            properties.FilletRadius = 0.38;
            properties.CountInvolutePoints = 40;
            properties.Session = Session;

            properties.Updated += PropertiesOnUpdated;
        }

        private void PropertiesOnUpdated(object sender, EventArgs e)
        {
            textBoxPitch.Text = properties.Pitch.ToString();
            textBoxPCD.Text = properties.PitchCircleDiameter.ToString();
            textBoxAddendum.Text = properties.AddendumCircleDiameter.ToString();
            textBoxClearance.Text = properties.Clearance.ToString();
            textBoxDedendum.Text = properties.DedendumCircleDiameter.ToString();
            textBoxBaseCircle.Text = properties.BaseCircleDiameter.ToString();
            textBoxAlpha.Text = properties.Alpha.ToString();
            textBoxBeta.Text = properties.Beta.ToString();
        }

        private void initBindings()
        {
            comboBoxModule.DataSource = properties.Series1Module.ToArray();
            comboBoxSeries.DataSource = properties.SeriesNames.ToArray();
            textBoxCentreX.Text = properties.WheelCentreX.ToString();
            textBoxCentreY.Text = properties.WheelCentreY.ToString();
            textBoxPressureAngle.Text = properties.PressureAngle.ToString();
        }


        private void numericUpDownToothCount_ValueChanged(object sender, EventArgs e)
        {
            properties.ToothCount = (int) ((NumericUpDown) sender).Value;
        }


        private void comboBoxModule_ValueChanged(object sender, EventArgs e)
        {
            properties.Module = (double) ((ComboBox) sender).SelectedValue;
        }


        private void comboBoxSeries_ValueChanged(object sender, EventArgs e)
        {
            if (((ComboBox) sender).SelectedValue != null &&
                ((string) ((ComboBox) sender).SelectedValue).Equals("Series 1"))
                comboBoxModule.DataSource = properties.Series1Module.ToArray();
            else
                comboBoxModule.DataSource = properties.Series2Module.ToArray();
        }

        private void textBoxCentreX_TextChanged(object sender, EventArgs e)
        {
            properties.WheelCentreX = double.Parse(((TextBox) sender).Text);
        }

        private void textBoxCentreY_TextChanged(object sender, EventArgs e)
        {
            properties.WheelCentreY = double.Parse(((TextBox) sender).Text);
        }


        private void textBoxPressureAngle_TextChanged(object sender, EventArgs e)
        {
            properties.PressureAngle = double.Parse(((TextBox) sender).Text);
        }

        private void textBoxCentreX_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnforceNumeric(sender, e);
        }

        private static void EnforceNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1) e.Handled = true;
        }

        private void textBoxPressureAngle_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnforceNumeric(sender, e);
        }

        private void textBoxCentreY_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnforceNumeric(sender, e);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (properties.Plane == null)
            {
                MessageBox.Show("Please select a Plane for the gear sketch.", "Error", MessageBoxButtons.OK);
                return;
            }

            var involute = new Involute(properties);
            involute.DrawGear2();
        }

        private void numericUpDownToothCount_MouseClick(object sender, MouseEventArgs e)
        {
            properties.ToothCount = (int) ((NumericUpDown) sender).Value;
        }

        private void numericUpDownToothCount_KeyUp(object sender, KeyEventArgs e)
        {
            properties.ToothCount = (int) ((NumericUpDown) sender).Value;
        }


        private void comboBoxModule_MouseClick(object sender, MouseEventArgs e)
        {
            properties.Module = (double) ((ComboBox) sender).SelectedValue;
        }
    }
}