﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using AlibreAddOn;
using AlibreX;
using Bolsover.AlibreDataViewer;
using com.alibre.automation;

namespace Bolsover.Involute
{
    public class InvoluteGearAddOnCommand : IAlibreAddOnCommand
    {
        public IADSession session { get; }
        private long PanelHandle { get; set; }
        public int PanelPosition { get; set; }

        public InvoluteGear InvoluteGear;

        public InvoluteGearAddOnCommand(IADSession session)
        {
            this.session = session;
            PanelPosition = (int) ADDockStyle.AD_RIGHT;
            InvoluteGear = new InvoluteGear(session);
        }

        /// <summary>
        /// Actions to take when closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UserRequestedClose()
        {
            InvoluteGear.Dispose();
            CommandSite.RemoveDockedPanel(DockedPanelHandle);
            DockedPanelHandle = (long) IntPtr.Zero;
            CommandSite = null;
        }


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
                        InvoluteGear.Parent = control;
                        InvoluteGear.Dock = DockStyle.Fill;
                        InvoluteGear.AutoSize = true;
                        InvoluteGear.Show();
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
        /// <exception cref="NotImplementedException"></exception>
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
        /// <exception cref="NotImplementedException"></exception>
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
        /// <exception cref="NotImplementedException"></exception>
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
        /// <exception cref="NotImplementedException"></exception>
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
        /// <exception cref="NotImplementedException"></exception>
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
        /// <exception cref="NotImplementedException"></exception>
        public bool OnMouseUp(int screenX, int screenY, ADDONMouseButtons buttons)
        {
            Debug.WriteLine("OnMouseUp X: " + screenX + " Y: " + screenY + " Button: " + buttons);
            return false;
        }

        /// <summary>
        /// Called when use makes a selection change on the editor; actual selection can be obtained using seperate API
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnSelectionChange()
        {
            if (session.SelectedObjects.Count == 1)
            {
                var proxy = (IADTargetProxy) session.SelectedObjects.Item(0);
                try
                {
                    if (proxy.Target.GetType() == typeof(AlibreDesignPlane))
                    {
                        InvoluteGear.DesignPlane = proxy.Target as IADDesignPlane;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public event EventHandler<InvoluteGearAddOnCommandTerminateEventArgs> Terminate;

        /// <summary>
        /// Called when Alibre terminates the add-on command; add-on should make sure to release all references to its CommandSite
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnTerminate()
        {
            Debug.WriteLine("OnTerminate");
            if (InvoluteGear != null)
            {
                InvoluteGear.Dispose();
            }

            if (CommandSite != null)
            {
                CommandSite.RemoveDockedPanel(DockedPanelHandle);
                DockedPanelHandle = (long) IntPtr.Zero;
                CommandSite = null;
            }

            var args = new InvoluteGearAddOnCommandTerminateEventArgs(this);
            Terminate.Invoke(this, args);

            Debug.WriteLine("OnTerminate Done");
        }

        /// <summary>
        /// Called when Alibre has successfully initiated this command; gives it a chance to perform any initializations
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnComplete()
        {
            Debug.WriteLine("OnComplete Starting");
            try
            {
                DockedPanelHandle = CommandSite.AddDockedPanel(PanelPosition, "Involute Gear Generator");
            }
            catch (Exception ex)
            {
                var num = (int) MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                throw ex;
            }

            Debug.WriteLine("OnComplete Done");
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
            return false;
        }

        /// <summary>
        /// Called to get the add-on to render its DirectX graphics into Alibre's graphics canvas
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
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