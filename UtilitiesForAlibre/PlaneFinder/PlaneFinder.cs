using System;
using System.Diagnostics;
using System.Windows.Forms;
using AlibreX;


namespace Bolsover.PlaneFinder
{
    public partial class PlaneFinder : UserControl
    {
        private IADSession session;
        private IADSketch sketch;


        public PlaneFinder(IADSession session)
        {
            this.session = session;
            InitializeComponent();
        }

        private void getPlaneForSketch(IADSketch sketch)
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
            get => sketch;
            set
            {
                sketch = value;
                sketchTextBox.Text = sketch.Name;
                getPlaneForSketch(sketch);
            }
        }
    }
}