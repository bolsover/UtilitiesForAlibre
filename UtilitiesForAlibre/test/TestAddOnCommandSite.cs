using System;
using System.Diagnostics;
using AlibreAddOn;

namespace Bolsover.test
{
    public class TestAddOnCommandSite : IADAddOnCommandSite
    {
        public TestAddOnCommandSite()
        {
        }

        /// <summary>
        /// Allows active add-on command to covert point in model coordinates to screen coordinates
        /// </summary>
        /// <param name="pXYZCoordinates"></param>
        /// <returns></returns>
        public Array WorldToScreen(ref Array pXYZCoordinates)
        {
            Debug.WriteLine("WorldToScreen");
            return null;
        }

        /// <summary>
        /// Allows active add-on command to covert point in screen coordinates to model coordinates
        /// </summary>
        /// <param name="pXYCoordinates"></param>
        /// <returns></returns>
        public Array ScreenToWorld(ref Array pXYCoordinates)
        {
            Debug.WriteLine("ScreenToWorld");
            return null;
        }

        /// <summary>
        /// Allows active add-on command to signal to Alibre that it is about to start changing the model
        /// </summary>
        public void StartChangingModel()
        {
            Debug.WriteLine("StartChangingModel");
        }

        /// <summary>
        /// Allows active add-on command to signal to Alibre that it has finished changing the model
        /// </summary>
        public void StopChangingModel()
        {
            Debug.WriteLine("StopChangingModel");
        }

        /// <summary>
        /// Allows active add-on command to trigger an asyncronous refresh of the graphics canvas
        /// </summary>
        public void InvalidateCanvas()
        {
            Debug.WriteLine("InvalidateCanvas");
        }

        /// <summary>
        /// Allows active add-on command to signal to Alibre to terminate the command
        /// </summary>
        public void Terminate()
        {
            Debug.WriteLine("Terminate");
        }

        /// <summary>
        /// Set to True if add-on wants to suppress Alibre's standard rendering to canvas and do GDI-based rendering
        /// </summary>
        /// <param name="bOverrideRender"></param>
        public void OverrideRender(bool bOverrideRender)
        {
            Debug.WriteLine("OverrideRender");
        }

        /// <summary>
        /// Allows active add-on command to trigger a synchronous refresh of the graphics canvas
        /// </summary>
        public void UpdateCanvas()
        {
            Debug.WriteLine("UpdateCanvas");
        }

        /// <summary>
        /// Allows active add-on command to refresh Alibre's toolbar button states; this is an expensive call, so to be used sparingly
        /// </summary>
        public void UpdateToolbars()
        {
            Debug.WriteLine("UpdateToolbars");
        }

        /// <summary>
        /// Returns the IUnknown pointer corresponding to the LPDIRECT3DEVICE9 object set up by AD.  This function is only available during the OnRender and On3DRender events.
        /// </summary>
        /// <param name="bClearViewPort"></param>
        /// <returns></returns>
        public object Begin3DDisplay(bool bClearViewPort)
        {
            Debug.WriteLine("Begin3DDisplay");
            return null;
        }

        /// <summary>
        /// Ends 3D Display on DirectX context by this Add-on.
        /// </summary>
        public void End3DDisplay()
        {
            Debug.WriteLine("End3DDisplay");
        }

        /// <summary>
        /// Invokes new Add-On Command
        /// </summary>
        /// <param name="pCommand"></param>
        public void InvokeNewCommand(IAlibreAddOnCommand pCommand)
        {
            Debug.WriteLine("InvokeNewCommand");
        }

        /// <summary>
        /// Allows an add-on command to start or stop receiving OnRender calls from Alibre Design.
        /// </summary>
        /// <param name="bEnableRender"></param>
        public void EnableOnRenderCallback(bool bEnableRender)
        {
            Debug.WriteLine("EnableOnRenderCallback");
        }

        /// <summary>
        /// Allows an add-on command to instruct Alibre Design to query extents from add-on command prior to rendering
        /// </summary>
        /// <param name="bEnableExtents"></param>
        public void EnableExtentsCallback(bool bEnableExtents)
        {
            Debug.WriteLine("EnableExtentsCallback");
        }

        /// <summary>
        /// Set to True if add-on wants to suppress Alibre's standard rendering to canvas and do DirectX-based rendering
        /// </summary>
        /// <param name="bOverrideRender"></param>
        public void Override3DRender(bool bOverrideRender)
        {
            Debug.WriteLine("Override3DRender");
        }

        /// <summary>
        /// Allows an add-on command to start or stop receiving On3DRender calls from Alibre Design.
        /// </summary>
        /// <param name="bEnableRender"></param>
        public void EnableOn3DRenderCallback(bool bEnableRender)
        {
            Debug.WriteLine("EnableOn3DRenderCallback");
        }

        /// <summary>
        /// Returns the Hwnd of the viewport.  This function is only available during the OnRender and On3DRender events.
        /// </summary>
        /// <returns></returns>
        public int GetViewportHwnd()
        {
            Debug.WriteLine("GetViewportHwnd: ");
            return 0;
        }

        /// <summary>
        /// Enables individual sketch figure selection on mouse click. If true, clicking on a sketch will select the sketch figure at that location. If false, clicking on a sketch will select the entire sketch.
        /// </summary>
        /// <param name="bEnableFigures"></param>
        public void EnableSketchFigureSelection(bool bEnableFigures)
        {
            Debug.WriteLine("EnableSketchFigureSelection");
        }

        /// <summary>
        /// Add a new docked panel.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="panelName"></param>
        /// <returns></returns>
        public long AddDockedPanel(int position, string panelName)
        {
            Debug.WriteLine("AddDockedPanel");
            return 0l;
        }

        /// <summary>
        /// Remove a docked panel.
        /// </summary>
        /// <param name="handle"></param>
        public void RemoveDockedPanel(long handle)
        {
            Debug.WriteLine("RemoveDockedPanel");
        }

        /// <summary>
        /// Change the position of the docked panel to the Top, Bottom or Right.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool UpdateDockedPanelPosition(long handle, int position)
        {
            Debug.WriteLine("UpdateDockedPanelPosition");
            return false;
        }

        /// <summary>
        /// Update the state of an Menu Item. This will end up calling the MenuItemState method in IAlibreAddOn interface.
        /// </summary>
        /// <param name="menuID"></param>
        public void UpdateMenuItemState(int menuID)
        {
            Debug.WriteLine("UpdateMenuItemState");
        }

        /// <summary>
        /// Find out if the legacy, DirectX 9.0c based rendering engine is being used to render.
        /// </summary>
        /// <returns></returns>
        public bool LegacyRenderingEngine()
        {
            Debug.WriteLine("LegacyRenderingEngine");
            return false;
        }
    }
}