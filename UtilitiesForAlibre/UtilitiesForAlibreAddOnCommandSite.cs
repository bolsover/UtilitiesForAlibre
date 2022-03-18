using System;
using AlibreAddOn;

namespace Bolsover
{
    //Interface to a Site object of an Alibre Design: Add-on command
    public class UtilitiesForAlibreAddOnCommandSite : IADAddOnCommandSite
    {
        /// <summary>
        /// Allows active add-on command to covert point in model coordinates to screen coordinates
        /// </summary>
        /// <param name="pXYZCoordinates"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Array WorldToScreen(ref Array pXYZCoordinates)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows active add-on command to covert point in screen coordinates to model coordinates
        /// </summary>
        /// <param name="pXYCoordinates"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Array ScreenToWorld(ref Array pXYCoordinates)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows active add-on command to signal to Alibre that it is about to start changing the model
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void StartChangingModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows active add-on command to signal to Alibre that it has finished changing the model
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void StopChangingModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows active add-on command to trigger an asyncronous refresh of the graphics canvas
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void InvalidateCanvas()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows active add-on command to signal to Alibre to terminate the command
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Terminate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set to True if add-on wants to suppress Alibre's standard rendering to canvas and do GDI-based rendering
        /// </summary>
        /// <param name="bOverrideRender"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OverrideRender(bool bOverrideRender)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows active add-on command to trigger a synchronous refresh of the graphics canvas
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateCanvas()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows active add-on command to refresh Alibre's toolbar button states; this is an expensive call, so to be used sparingly
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateToolbars()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the IUnknown pointer corresponding to the LPDIRECT3DEVICE9 object set up by AD.  This function is only available during the OnRender and On3DRender events.
        /// </summary>
        /// <param name="bClearViewPort"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Begin3DDisplay(bool bClearViewPort)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ends 3D Display on DirectX context by this Add-on.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void End3DDisplay()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Invokes new Add-On Command
        /// </summary>
        /// <param name="pCommand"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void InvokeNewCommand(IAlibreAddOnCommand pCommand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows an add-on command to start or stop receiving OnRender calls from Alibre Design.
        /// </summary>
        /// <param name="bEnableRender"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void EnableOnRenderCallback(bool bEnableRender)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows an add-on command to instruct Alibre Design to query extents from add-on command prior to rendering
        /// </summary>
        /// <param name="bEnableExtents"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void EnableExtentsCallback(bool bEnableExtents)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set to True if add-on wants to suppress Alibre's standard rendering to canvas and do DirectX-based rendering
        /// </summary>
        /// <param name="bOverrideRender"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Override3DRender(bool bOverrideRender)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows an add-on command to start or stop receiving On3DRender calls from Alibre Design.
        /// </summary>
        /// <param name="bEnableRender"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void EnableOn3DRenderCallback(bool bEnableRender)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the Hwnd of the viewport.  This function is only available during the OnRender and On3DRender events.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetViewportHwnd()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Enables individual sketch figure selection on mouse click. If true, clicking on a sketch will select the sketch figure at that location. If false, clicking on a sketch will select the entire sketch.
        /// </summary>
        /// <param name="bEnableFigures"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void EnableSketchFigureSelection(bool bEnableFigures)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a new docked panel.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="panelName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public long AddDockedPanel(int position, string panelName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove a docked panel.
        /// </summary>
        /// <param name="handle"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveDockedPanel(long handle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Change the position of the docked panel to the Top, Bottom or Right.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateDockedPanelPosition(long handle, int position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update the state of an Menu Item. This will end up calling the MenuItemState method in IAlibreAddOn interface.
        /// </summary>
        /// <param name="menuID"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateMenuItemState(int menuID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find out if the legacy, DirectX 9.0c based rendering engine is being used to render.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool LegacyRenderingEngine()
        {
            throw new NotImplementedException();
        }
    }
}