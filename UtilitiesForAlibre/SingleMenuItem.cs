using System;
using System.Collections.Generic;
using AlibreAddOn;
using AlibreX;
using Bolsover.Sample;


namespace Bolsover
{
    public class SingleMenuItem : IAlibreAddOn
    {
        private const int MENU_ID_ROOT = 401;
        private const int MENU_ID_SAMPLE = 402;

        private int[] MENU_IDS_BASE = new int[1]
        {
            MENU_ID_SAMPLE
        };

        private IADRoot alibreRoot;
        private IntPtr parentWinHandle;

        public SingleMenuItem(IADRoot alibreRoot, IntPtr parentWinHandle)
        {
            this.alibreRoot = alibreRoot;
            this.parentWinHandle = parentWinHandle;
            // DoSample(null);
        }

        #region Menus

        /// <summary>
        /// Returns the menu ID of the add-on's root menu item
        /// </summary>
        public int RootMenuItem => MENU_ID_ROOT;


        /// <summary>
        /// Description("Returns Whether the given Menu ID has any sub menus")
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public bool HasSubMenus(int menuID)
        {
            //   return false;
            return menuID == MENU_ID_ROOT;
        }

        /// <summary>
        /// Returns the ID's of sub menu items under a popup menu item; the menu ID of a 'leaf' menu becomes its command ID
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public Array SubMenuItems(int menuID)
        {
            return MENU_IDS_BASE;
        }

        /// <summary>
        /// Returns the display name of a menu item; a menu item with text of a single dash (“-“) is a separator
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public string MenuItemText(int menuID)
        {
            return "Sample";
        }

        /// <summary>
        /// Returns True if input menu item has sub menus // seems odd given name of method
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public bool PopupMenu(int menuID)
        {
            return true;
        }

        /// <summary>
        /// Returns property bits providing information about the state of a menu item
        /// ADDON_MENU_ENABLED = 1,
        /// ADDON_MENU_GRAYED = 2,
        /// ADDON_MENU_CHECKED = 3,
        /// ADDON_MENU_UNCHECKED = 4,
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="sessionIdentifier"></param>
        /// <returns></returns>
        public ADDONMenuStates MenuItemState(int menuID, string sessionIdentifier)
        {
            return ADDONMenuStates.ADDON_MENU_ENABLED;
        }

        /// <summary>
        /// Returns a tool tip string if input menu ID is that of a 'leaf' menu item
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public string MenuItemToolTip(int menuID)
        {
            return "Utilities";
        }

        /// <summary>
        /// Returns the icon name (with extension) for a menu item; the icon will be searched under the folder where the add-on's .adc file is present
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public string MenuIcon(int menuID)
        {
            return "nexus.ico";
        }

        /// <summary>
        /// Returns True if AddOn has updated Persistent Data
        /// </summary>
        /// <param name="sessionIdentifier"></param>
        /// <returns></returns>
        public bool HasPersistentDataToSave(string sessionIdentifier)
        {
            return false;
        }

        /// <summary>
        /// Invokes the add-on command identified by menu ID; returning the add-on command interface is optional
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="sessionIdentifier"></param>
        /// <returns></returns>
        public IAlibreAddOnCommand InvokeCommand(int menuID, string sessionIdentifier)
        {
            var session = alibreRoot.Sessions.Item(sessionIdentifier);

            return DoSample(session);
        }

        #endregion


        #region Sample

        /// <summary>
        /// A dictionary to keep track of currently open EmptyAddOnCommand object.
        /// </summary>
        private readonly Dictionary<string, SampleAddOnCommand> emptyAddOnCommands = new();

        private IAlibreAddOnCommand DoSample(IADSession session)
        {
            SampleAddOnCommand sampleViewerAddOnCommand;
            if (!emptyAddOnCommands.ContainsKey(session.Identifier))
            {
                sampleViewerAddOnCommand = new SampleAddOnCommand(session);
                sampleViewerAddOnCommand.SampleUserControl.Visible = true;
                sampleViewerAddOnCommand.Terminate += SampleAddOnCommandOnTerminate;
                emptyAddOnCommands.Add(session.Identifier, sampleViewerAddOnCommand);
            }
            else
            {
                if (emptyAddOnCommands.TryGetValue(session.Identifier, out sampleViewerAddOnCommand))
                {
                    sampleViewerAddOnCommand.UserRequestedClose();
                    emptyAddOnCommands.Remove(session.Identifier);
                    return null;
                }
            }

            return sampleViewerAddOnCommand;
        }

        private void SampleAddOnCommandOnTerminate(object sender, SampleAddonCommandTerminateEventArgs e)
        {
            SampleAddOnCommand sampleAddOnCommand;
            if (emptyAddOnCommands.TryGetValue(e.SampleAddOnCommand.session.Identifier, out sampleAddOnCommand))
            {
                emptyAddOnCommands.Remove(e.SampleAddOnCommand.session.Identifier);
            }
        }

        #endregion


        /// <summary>
        /// Loads Data from AddOn
        /// </summary>
        /// <param name="pCustomData"></param>
        /// <param name="sessionIdentifier"></param>
        public void LoadData(IStream pCustomData, string sessionIdentifier)
        {
        }

        /// <summary>
        /// Saves Data to AddOn
        /// </summary>
        /// <param name="pCustomData"></param>
        /// <param name="sessionIdentifier"></param>
        public void SaveData(IStream pCustomData, string sessionIdentifier)
        {
        }

        /// <summary>
        /// Sets the IsLicensed bit for the tightly coupled Add-on
        /// </summary>
        /// <param name="isLicensed"></param>
        public void setIsAddOnLicensed(bool isLicensed)
        {
        }

        /// <summary>
        /// Returns True if the AddOn needs to use a Dedicated Ribbon Tab
        /// </summary>
        /// <returns></returns>
        public bool UseDedicatedRibbonTab()
        {
            return true;
        }
    }
}