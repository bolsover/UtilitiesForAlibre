using System;
using AlibreAddOn;

namespace Bolsover
{
    public class UtilitiesForAlibreAddOnCommand : IAlibreAddOnCommand
    {
        /// <summary>
        /// Called to find out if this add-on command is a two-way toggle command
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsTwoWayToggle()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns True if add-on wants to show any UI controls in Alibre's left pane window
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddTab()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called to get the add-on to show its UI inside its special tab page window
        /// </summary>
        /// <param name="hWnd"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnShowUI(long hWnd)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when use makes a selection change on the editor; actual selection can be obtained using seperate API
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnSelectionChange()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when Alibre terminates the add-on command; add-on should make sure to release all references to its CommandSite
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnTerminate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when Alibre has successfully initiated this command; gives it a chance to perform any initializations
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnComplete()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when user holds down the key, passing the keycode as the ASCII value of the key
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnKeyDown(int keycode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when user releases the key, passing the keycode as the ASCII value of the key
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnKeyUp(int keycode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when escape key is pressed by the user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnEscape()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when mouse wheel is rotated by the user, delta is the magnitude of wheel movement
        /// </summary>
        /// <param name="delta"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool OnMouseWheel(double delta)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called to get the add-on to render its DirectX graphics into Alibre's graphics canvas
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void On3DRender()
        {
            throw new NotImplementedException();
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