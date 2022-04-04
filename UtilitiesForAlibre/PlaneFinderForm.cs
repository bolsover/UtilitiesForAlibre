using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using AlibreX;

namespace Bolsover
{
    public partial class PlaneFinderForm : Form
    {
        private IADPartSession session;


        public PlaneFinderForm(IADPartSession session)
        {
            this.session = session;
            InitializeComponent();

            sketchesComboBox.SelectedIndexChanged += new EventHandler(sketchesComboBox_SelectedIndexChanged);
            retrieveSketchesFromSession();
            // retrieveRootEventManager();
        }


        // private EventManager retrieveRootEventManager()
        // {
        //     var eventManager = (EventManager) session.Root.EventManager;
        //     eventManager.OnSessionOpen+= EventManagerOnOnSessionOpen;
        //     return eventManager;
        // }
        //
        // private void EventManagerOnOnSessionOpen(IADSession psession)
        // {
        //     psession.
        // }


        private void retrieveSketchesFromSession()
        {
            var sketches = session.Sketches;
            var comboSource = new Dictionary<IADSketch, string>();
            for (var i = 0; i < sketches.Count; i++) comboSource.Add(sketches.Item(i), sketches.Item(i).Name);
            sketchesComboBox.DataSource = new BindingSource(comboSource, null);
            sketchesComboBox.DisplayMember = "Value";
            sketchesComboBox.ValueMember = "Key";
            if (sketchesComboBox.Items.Count >= 1)
                sketchesComboBox.SelectedIndex = 0;
        }

        private void sketchesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IADSketch sketch = null;
            IADTargetProxy targetProxy = null;
            try
            {
                var y = (KeyValuePair<IADSketch, string>) ((ComboBox) sender).SelectedItem;
                sketch = y.Key;
                targetProxy = sketch.SketchPlane;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                var buttons = MessageBoxButtons.OK;
                MessageBox.Show(
                    "Error finding plane for sketch " + sketch != null ? sketch.Name : "?" + "\n" + ex.ToString(),
                    "Error", buttons);
            }

            if (targetProxy != null)
                planeTextBox.Text = targetProxy.DisplayName;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}