using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using AlibreAddOn;
using AlibreX;


namespace Bolsover.test
{
    public class TestAddOnCommand : IAlibreAddOnCommand
    {
        private IADSession session;

        public TestAddOnCommand(IADSession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Called to find out if this add-on command is a two-way toggle command
        /// </summary>
        /// <returns></returns>
        public bool IsTwoWayToggle()
        {
            return false;
        }

        /// <summary>
        /// Returns True if add-on wants to show any UI controls in Alibre's left pane window
        /// </summary>
        /// <returns></returns>
        public bool AddTab()
        {
            return false;
        }

        /// <summary>
        /// Called to get the add-on to show its UI inside its special tab page window
        /// </summary>
        /// <param name="hWnd"></param>
        public void OnShowUI(long hWnd)
        {
            Debug.WriteLine("OnShowUI");
        }

        /// <summary>
        /// Called to get the add-on to render its GDI graphics into Alibre's graphics canvas;the origin and size of the view rectangle are passed in.
        /// </summary>
        /// <param name="hDC"></param>
        /// <param name="clipRectX"></param>
        /// <param name="clipRectY"></param>
        /// <param name="clipRectWidth"></param>
        /// <param name="clipRectHeight"></param>
        public void OnRender(int hDC, int clipRectX, int clipRectY, int clipRectWidth, int clipRectHeight)
        {
            Debug.WriteLine("OnRender hDC: " + hDC + ", clipRectX: " + clipRectX + ", clipRectY: " + clipRectY
                            + ", clipRectWidth: " + clipRectWidth + ", clipRectHeight: " + clipRectHeight);
        }


        /// <summary>
        /// Called when left mouse button is clicked
        /// </summary>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public bool OnClick(int screenX, int screenY, ADDONMouseButtons buttons)
        {
            Debug.WriteLine("OnClick X: " + screenX + " Y: " + screenY + " Button: " + buttons);
            return false;
        }

        /// <summary>
        /// Called when left mouse button is double-clicked
        /// </summary>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <returns></returns>
        public bool OnDoubleClick(int screenX, int screenY)
        {
            Debug.WriteLine("OnDoubleClick X: " + screenX + " Y: " + screenY);
            return false;
        }

        /// <summary>
        /// Called when mouse button is depressed; TODO: Describe 'buttons' constants
        /// </summary>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public bool OnMouseDown(int screenX, int screenY, ADDONMouseButtons buttons)
        {
            Debug.WriteLine("OnMouseDown X: " + screenX + " Y: " + screenY + " Button: " + buttons);
            return false;
        }

        /// <summary>
        /// Called when mouse is moved; TODO: Describe 'buttons' constants
        /// </summary>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public bool OnMouseMove(int screenX, int screenY, ADDONMouseButtons buttons)
        {
            Debug.WriteLine("OnMouseMove X: " + screenX + " Y: " + screenY + " Button: " + buttons);
            return false;
        }

        /// <summary> 
        /// Called when mouse button is released; TODO: Describe 'buttons' constants
        /// </summary>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public bool OnMouseUp(int screenX, int screenY, ADDONMouseButtons buttons)
        {
            Debug.WriteLine("OnMouseUp X: " + screenX + " Y: " + screenY + " Button: " + buttons);
            return false;
        }

        /// <summary>
        /// Called when use makes a selection change on the editor; actual selection can be obtained using seperate API
        /// </summary>
        public void OnSelectionChange()
        {
          
            if (session.SelectedObjects.Count == 1)
            {
                var proxy = (IADTargetProxy) session.SelectedObjects.Item(0);
                showMessageBoxData(proxy.Target);

            }

        }

        private void showMessageBoxData(object o)
        {
            StringBuilder sb = new StringBuilder();
            PropertyInfo[] infos = o.GetType().GetProperties();
            for (int i = 0; i < infos.Length; i++)
            {
                PropertyInfo info = infos[i];
                try
                {
                    sb.Append(info.Name + ": " + GetPropertyValue(o, info.Name) + "\n");
                }
                catch (Exception e)
                {
                    sb.Append(info.Name + ": returned an exception \n");
                }
                
            }

         //   MessageBox.Show(sb.ToString(), o.GetType().Name, MessageBoxButtons.OK);
            AlibreDataViewer alibreDataViewer = new AlibreDataViewer(o);
            alibreDataViewer.Show();
            alibreDataViewer.TopMost = true;
        }

        public static string GetPropertyValue(object obj, string propName)
        {
            return obj.GetType().GetProperty(propName).GetValue(obj, null).ToString();
        }

        /// <summary>
        /// Called when Alibre terminates the add-on command; add-on should make sure to release all references to its CommandSite
        /// </summary>
        public void OnTerminate()
        {
            Debug.WriteLine("OnTerminate");
        }

        /// <summary>
        /// Called when Alibre has successfully initiated this command; gives it a chance to perform any initializations
        /// </summary>
        public void OnComplete()
        {
            Debug.WriteLine("OnComplete");
        }

        /// <summary>
        /// Called when user holds down the key, passing the keycode as the ASCII value of the key
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        public bool OnKeyDown(int keycode)
        {
            Debug.WriteLine("OnKeyDown:" + keycode);
            return false;
        }

        /// <summary>
        /// Called when user releases the key, passing the keycode as the ASCII value of the key
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        public bool OnKeyUp(int keycode)
        {
            Debug.WriteLine("OnKeyUp:" + keycode);
            return false;
        }

        /// <summary>
        /// Called when escape key is pressed by the user
        /// </summary>
        /// <returns></returns>
        public bool OnEscape()
        {
            Debug.WriteLine("OnEscape");
            return false;
        }

        /// <summary>
        /// Called when mouse wheel is rotated by the user, delta is the magnitude of wheel movement
        /// </summary>
        /// <param name="delta"></param>
        /// <returns></returns>
        public bool OnMouseWheel(double delta)
        {
            Debug.WriteLine("OnMouseWheel: " + delta);
            return false;
        }

        /// <summary>
        /// Called to get the add-on to render its DirectX graphics into Alibre's graphics canvas
        /// </summary>
        public void On3DRender()
        {
            Debug.WriteLine("On3DRender");
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