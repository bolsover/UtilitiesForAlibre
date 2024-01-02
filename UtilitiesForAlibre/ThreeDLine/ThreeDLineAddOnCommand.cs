using System;
using System.Diagnostics;
using System.Windows.Forms;
using AlibreAddOn;
using AlibreX;

namespace Bolsover.ThreeDLine
{
    public class ThreeDLineAddOnCommand : IAlibreAddOnCommand
    {
        public IADSession Session { get; }
        private long PanelHandle { get; set; }
        private int PanelPosition { get; }

        public ThreeDLineUserControl ThreeDLineUserControl;

        // private IAD3DSketch ad3DSketch;


        public ThreeDLineAddOnCommand(IADSession session)
        {
            this.Session = session; // a reference to the current design session
            PanelPosition = (int) ADDockStyle.AD_RIGHT; // where do you want the docked panel
            ThreeDLineUserControl = new ThreeDLineUserControl(session); // finally get to create your user control
        }

        private IAD3DSketch Get3DSketch()
        {
            IAD3DSketch myAd3DSketch = null;
            if (Session.SessionType == ADObjectSubType.AD_PART)
            {
                myAd3DSketch = ((IADPartSession) Session).Sketches3D.Add3DSketch("My3DSketch");
            }

            return myAd3DSketch;
        }


        /// <summary>
        /// Actions to take when closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UserRequestedClose()
        {
            ThreeDLineUserControl.Dispose();
            CommandSite.RemoveDockedPanel(DockedPanelHandle);
            DockedPanelHandle = (long) IntPtr.Zero;
            CommandSite = null;
        }


        /// <summary>
        /// Get/Set the PanelHandle
        /// set adds the User control to the Parent, docks and autosizes.
        /// </summary>
        public virtual long DockedPanelHandle
        {
            get => PanelHandle;
            set
            {
                Debug.WriteLine(value);

                if (value != (long) IntPtr.Zero)
                {
                    var control = Control.FromHandle((IntPtr) value);
                    if (control != null)
                    {
                        ThreeDLineUserControl.Parent = control;
                        ThreeDLineUserControl.Dock = DockStyle.Fill;
                        ThreeDLineUserControl.AutoSize = true;
                        ThreeDLineUserControl.Show();
                        control.Show();
                        PanelHandle = value;
                    }
                }
            }
        }


        /// <summary>
        /// Called to find out if this add-on command is a two-way toggle command
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsTwoWayToggle()
        {
            return false;
        }

        /// <summary>
        /// Returns True if add-on wants to show any UI controls in Alibre's left pane window
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddTab()
        {
            return false;
        }

        /// <summary>
        /// Called to get the add-on to show its UI inside its special tab page window
        /// </summary>
        /// <param name="hWnd"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnShowUI(long hWnd)
        {
        }

        /// <summary>
        /// Called to get the add-on to render its GDI graphics into Alibre's graphics canvas;the origin and size of the view rectangle are passed in.
        /// </summary>
        /// <param name="hDc"></param>
        /// <param name="clipRectX"></param>
        /// <param name="clipRectY"></param>
        /// <param name="clipRectWidth"></param>
        /// <param name="clipRectHeight"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnRender(int hDc, int clipRectX, int clipRectY, int clipRectWidth, int clipRectHeight)
        {
        }


        /// <summary>
        /// Called when left mouse button is clicked
        /// </summary>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnClick(int screenX, int screenY, ADDONMouseButtons buttons)
        {
            return false;
        }

        /// <summary>
        /// Called when left mouse button is double-clicked
        /// </summary>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnDoubleClick(int screenX, int screenY)
        {
            return false;
        }

        /// <summary>
        /// Called when mouse button is depressed; TODO: Describe 'buttons' constants
        /// </summary>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnMouseDown(int screenX, int screenY, ADDONMouseButtons buttons)
        {
            return false;
        }

        /// <summary>
        /// Called when mouse is moved; TODO: Describe 'buttons' constants
        /// </summary>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnMouseMove(int screenX, int screenY, ADDONMouseButtons buttons)
        {
            return false;
        }

        /// <summary>
        /// Called when mouse button is released; TODO: Describe 'buttons' constants
        /// </summary>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnMouseUp(int screenX, int screenY, ADDONMouseButtons buttons)
        {
            return false;
        }

        /// <summary>
        /// Called when use makes a selection change on the editor; actual selection can be obtained using seperate API
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnSelectionChange()
        {
            Debug.WriteLine("OnSelectionChange");
            if (Session.SelectedObjects.Count == 1)
            {
                var proxy = (IADTargetProxy) Session.SelectedObjects.Item(0);
                try
                {
                    Debug.WriteLine(proxy.DisplayName);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public event EventHandler<ThreeDLineAddOnCommandTerminateEventArgs> Terminate;

        /// <summary>
        /// Called when Alibre terminates the add-on command; add-on should make sure to release all references to its CommandSite
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnTerminate()
        {
            if (ThreeDLineUserControl != null)
            {
                ThreeDLineUserControl.Dispose();
            }

            if (CommandSite != null)
            {
                CommandSite.RemoveDockedPanel(DockedPanelHandle);
                DockedPanelHandle = (long) IntPtr.Zero;
                CommandSite = null;
            }

            var args = new ThreeDLineAddOnCommandTerminateEventArgs(this);
            Terminate.Invoke(this, args);
        }

        /// <summary>
        /// Called when Alibre has successfully initiated this command; gives it a chance to perform any initializations
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnComplete()
        {
            try
            {
                DockedPanelHandle = CommandSite.AddDockedPanel(PanelPosition, "3D Line Add On");
            }
            catch (Exception ex)
            {
                var num = (int) MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                throw ex;
            }
        }

        /// <summary>
        /// Called when user holds down the key, passing the keycode as the ASCII value of the key
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnKeyDown(int keycode)
        {
            return false;
        }

        /// <summary>
        /// Called when user releases the key, passing the keycode as the ASCII value of the key
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnKeyUp(int keycode)
        {
            return false;
        }

        /// <summary>
        /// Called when escape key is pressed by the user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnEscape()
        {
            return false;
        }

        /// <summary>
        /// Called when mouse wheel is rotated by the user, delta is the magnitude of wheel movement
        /// </summary>
        /// <param name="delta"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnMouseWheel(double delta)
        {
            return false;
        }

        /// <summary>
        /// Called to get the add-on to render its DirectX graphics into Alibre's graphics canvas
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void On3DRender()
        {
        }

        /// <summary>
        /// Sets the command site object on the add-on command
        /// </summary>
        public IADAddOnCommandSite CommandSite { get; set; }

        /// <summary>
        /// Specifies tab name. Needed only if this command returned True when the AddTab method was called
        /// </summary>
        public string TabName { get; }

        /// <summary>
        /// Returns min and max bounding box points of geometry rendered by addon; used for computing front/back clipping planes
        /// </summary>
        public Array Extents { get; }
    }
}