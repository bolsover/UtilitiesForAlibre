using System;
using System.Diagnostics;
using System.Windows.Forms;
using AlibreAddOn;
using AlibreX;


namespace Bolsover.Sample
{
    public class SampleAddOnCommand : IAlibreAddOnCommand
    {
        public IADSession Session { get; }
        private long PanelHandle { get; set; }
        private int PanelPosition { get; }

        public SampleUserControl SampleUserControl;


        public SampleAddOnCommand(IADSession session)
        {
            this.Session = session; // a reference to the current design session
            PanelPosition = (int) ADDockStyle.AD_RIGHT; // where do you want the docked panel
            SampleUserControl = new SampleUserControl(session); // finally get to create your user control
        }

        private void WriteToUserControl(string text)
        {
            try
            {
                SampleUserControl?.AppendText(text);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        /// <summary>
        /// Actions to take when closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UserRequestedClose()
        {
            SampleUserControl.Dispose();
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
                        SampleUserControl.Parent = control;
                        SampleUserControl.Dock = DockStyle.Fill;
                        SampleUserControl.AutoSize = true;
                        SampleUserControl.Show();
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
            Debug.WriteLine("IsTwoWayToggle");
            WriteToUserControl("IsTwoWayToggle");
            return false;
        }

        /// <summary>
        /// Returns True if add-on wants to show any UI controls in Alibre's left pane window
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddTab()
        {
            Debug.WriteLine("AddTab");
            WriteToUserControl("AddTab");
            return false;
        }

        /// <summary>
        /// Called to get the add-on to show its UI inside its special tab page window
        /// </summary>
        /// <param name="hWnd"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnShowUI(long hWnd)
        {
            Debug.WriteLine("OnShowUI");
            WriteToUserControl("OnShowUI");
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
            Debug.WriteLine("OnRender hDC: " + hDc + ", clipRectX: " + clipRectX + ", clipRectY: " + clipRectY
                            + ", clipRectWidth: " + clipRectWidth + ", clipRectHeight: " + clipRectHeight);
            WriteToUserControl("OnRender hDC: " + hDc + ", clipRectX: " + clipRectX + ", clipRectY: " + clipRectY
                               + ", clipRectWidth: " + clipRectWidth + ", clipRectHeight: " + clipRectHeight);
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
            Debug.WriteLine("OnClick X: " + screenX + " Y: " + screenY + " Button: " + buttons);
            WriteToUserControl("OnClick X: " + screenX + " Y: " + screenY + " Button: " + buttons);
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
            Debug.WriteLine("OnDoubleClick X: " + screenX + " Y: " + screenY);
            WriteToUserControl("OnDoubleClick X: " + screenX + " Y: " + screenY);
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
            Debug.WriteLine("OnMouseDown X: " + screenX + " Y: " + screenY + " Button: " + buttons);
            WriteToUserControl("OnMouseDown X: " + screenX + " Y: " + screenY + " Button: " + buttons);

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
            Debug.WriteLine("OnMouseMove X: " + screenX + " Y: " + screenY + " Button: " + buttons);
            WriteToUserControl("OnMouseMove X: " + screenX + " Y: " + screenY + " Button: " + buttons);
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
            Debug.WriteLine("OnMouseUp X: " + screenX + " Y: " + screenY + " Button: " + buttons);
            WriteToUserControl("OnMouseUp X: " + screenX + " Y: " + screenY + " Button: " + buttons);
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
                    WriteToUserControl("OnSelectionChange " + proxy.DisplayName);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public event EventHandler<SampleAddonCommandTerminateEventArgs> Terminate;

        /// <summary>
        /// Called when Alibre terminates the add-on command; add-on should make sure to release all references to its CommandSite
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnTerminate()
        {
            Debug.WriteLine("OnTerminate");
            WriteToUserControl("OnTerminate");
            if (SampleUserControl != null)
            {
                SampleUserControl.Dispose();
            }

            if (CommandSite != null)
            {
                CommandSite.RemoveDockedPanel(DockedPanelHandle);
                DockedPanelHandle = (long) IntPtr.Zero;
                CommandSite = null;
            }

            var args = new SampleAddonCommandTerminateEventArgs(this);
            Terminate.Invoke(this, args);
        }

        /// <summary>
        /// Called when Alibre has successfully initiated this command; gives it a chance to perform any initializations
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnComplete()
        {
            Debug.WriteLine("OnComplete Starting");
            WriteToUserControl("OnComplete Starting");
            try
            {
                DockedPanelHandle = CommandSite.AddDockedPanel(PanelPosition, "Empty Add On");
            }
            catch (Exception ex)
            {
                var num = (int) MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                throw ex;
            }

            Debug.WriteLine("OnComplete Done");
            WriteToUserControl("OnComplete Done");
        }

        /// <summary>
        /// Called when user holds down the key, passing the keycode as the ASCII value of the key
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnKeyDown(int keycode)
        {
            Debug.WriteLine("OnKeyDown:" + keycode);
            WriteToUserControl("OnKeyDown:" + keycode);
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
            Debug.WriteLine("OnKeyUp:" + keycode);
            WriteToUserControl("OnKeyUp:" + keycode);
            return false;
        }

        /// <summary>
        /// Called when escape key is pressed by the user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnEscape()
        {
            Debug.WriteLine("OnEscape");
            WriteToUserControl("OnEscape:");
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
            Debug.WriteLine("OnMouseWheel: " + delta);
            WriteToUserControl("OnMouseWheel: " + delta);
            return false;
        }

        /// <summary>
        /// Called to get the add-on to render its DirectX graphics into Alibre's graphics canvas
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void On3DRender()
        {
            Debug.WriteLine("On3DRender");
            WriteToUserControl("On3DRender");
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