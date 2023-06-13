using System;
using System.Diagnostics;
using System.Windows.Forms;
using AlibreX;


namespace Bolsover.PlaneFinder
{
    public partial class PlaneFinder : UserControl
    {
        private IADSession _session;
        private IADSketch _sketch;


        public PlaneFinder(IADSession session)
        {
            this._session = session;
            InitializeComponent();
        }

        private void GetPlaneForSketch(IADSketch sketch)
        {
            IADTargetProxy targetProxy = null;
            try
            {
                targetProxy = sketch.SketchPlane;
                planeTextBox.Text = targetProxy.DisplayName;
            }
            catch (Exception ex)
            {
                planeTextBox.Text = "Error: Plane Not found";
                Debug.WriteLine(ex.ToString());
            }
        }

        public IADSketch Sketch
        {
            get => _sketch;
            set
            {
                _sketch = value;
                sketchTextBox.Text = _sketch.Name;
                GetPlaneForSketch(_sketch);
            }
        }
    }
}