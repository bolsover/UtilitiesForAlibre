using System;
using System.Collections.Generic;
using System.Diagnostics;
using AlibreAddOn;
using AlibreX;
using Bolsover.AlibreDataViewer;
using Bolsover.CycloidalGear;
using Bolsover.DataBrowser;
using Bolsover.Involute.View;
using Bolsover.PlaneFinder;

namespace Bolsover
{
    public class UtilitiesForAlibre : IAlibreAddOn
    {
        private const int MenuIdRoot = 401;

        private const int SubmenuIdDataBrowser = 505;
        private const int MenuIdGear = 506;
        private const int MenuIdUtils = 601;
        private const int SubmenuIdUtilsCycloidalGear = 602;
        private const int SubmenuIdUtilsPlaneFinder = 603;
        private const int SubmenuIdUtilsDataViewer = 604;
        private const int SubmenuIdUtilsStandardGear = 607;
        private const int SubmenuIdUtilsAdvancedGear = 609;
        private const int MenuIdHelp = 701;
        private const int SubmenuIdHelpAbout = 702;
        private int[] _menuIdsUtils;
        private int[] _menuIdsRoot;
        private int[] _menuIdsHelp;
        private int[] _menuIdsGear;

        private IADRoot _alibreRoot;
        private IntPtr _parentWinHandle;

        public UtilitiesForAlibre(IADRoot alibreRoot, IntPtr parentWinHandle)
        {
            this._alibreRoot = alibreRoot;
            this._parentWinHandle = parentWinHandle;
            BuildMenuTree();
        }

        #region Menus

        /// <summary>
        /// Returns the menu ID of the add-on's root menu item
        /// </summary>
        public int RootMenuItem => MenuIdRoot;

        /// <summary>
        /// Builds the menu tree
        /// </summary>
        private void BuildMenuTree()
        {
            _menuIdsUtils = new int[3]
            {
                SubmenuIdDataBrowser,
                SubmenuIdUtilsPlaneFinder,
                SubmenuIdUtilsDataViewer,
            };
            _menuIdsRoot = new int[3]
            {
                MenuIdUtils,
                MenuIdGear,
                MenuIdHelp
            };
            _menuIdsHelp = new int[1]
            {
                SubmenuIdHelpAbout
            };

            _menuIdsGear = new int[3]
            {
                SubmenuIdUtilsCycloidalGear,
                SubmenuIdUtilsStandardGear,
                SubmenuIdUtilsAdvancedGear
            };
        }

        /// <summary>
        /// Description("Returns Whether the given Menu ID has any sub menus")
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool HasSubMenus(int menuId)
        {
            switch (menuId)
            {
                case MenuIdRoot: return true;

                case MenuIdUtils: return true;
                case MenuIdHelp: return true;
                case MenuIdGear: return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the ID's of sub menu items under a popup menu item; the menu ID of a 'leaf' menu becomes its command ID
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public Array SubMenuItems(int menuId)
        {
            switch (menuId)
            {
                case MenuIdRoot: return _menuIdsRoot;
                case MenuIdGear: return _menuIdsGear;
                case MenuIdUtils: return _menuIdsUtils;
                case MenuIdHelp: return _menuIdsHelp;
            }

            return null;
        }

        /// <summary>
        /// Returns the display name of a menu item; a menu item with text of a single dash (“-“) is a separator
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public string MenuItemText(int menuId)
        {
            switch (menuId)
            {
                case MenuIdRoot: return "Utilities";
                case MenuIdUtils: return "Utilities";
                case MenuIdHelp: return "Help";
                case MenuIdGear: return "Gears";
                case SubmenuIdDataBrowser: return "Data Browser";
                case SubmenuIdUtilsCycloidalGear: return "Cycloidal Gears Open/Close";
                case SubmenuIdUtilsStandardGear: return "Standard Spur & Helical Gears";
                case SubmenuIdUtilsAdvancedGear: return "Advanced Spur & Helical Gears";
                case SubmenuIdHelpAbout: return "About";
                case SubmenuIdUtilsPlaneFinder: return "Sketch Plane Finder Open/Close";
                case SubmenuIdUtilsDataViewer: return "Property Viewer Open/Close";
            }

            return "";
        }

        /// <summary>
        /// Returns True if input menu item has sub menus // seems odd given name of method
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool PopupMenu(int menuId)
        {
            return false;
        }

        /// <summary>
        /// Returns property bits providing information about the state of a menu item
        /// ADDON_MENU_ENABLED = 1,
        /// ADDON_MENU_GRAYED = 2,
        /// ADDON_MENU_CHECKED = 3,
        /// ADDON_MENU_UNCHECKED = 4,
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="sessionIdentifier"></param>
        /// <returns></returns>
        public ADDONMenuStates MenuItemState(int menuId, string sessionIdentifier)
        {
            var session = _alibreRoot.Sessions.Item(sessionIdentifier);

            switch (session)
            {
                case IADDrawingSession:
                    switch (menuId)
                    {
                        case MenuIdRoot: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdUtils: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdDataBrowser: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsCycloidalGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsStandardGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsAdvancedGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsPlaneFinder: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsDataViewer: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdHelpAbout: return ADDONMenuStates.ADDON_MENU_GRAYED;
                    }

                    break;

                case IADAssemblySession:
                    switch (menuId)
                    {
                        case MenuIdRoot: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdUtils: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdDataBrowser: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsCycloidalGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsStandardGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsAdvancedGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsPlaneFinder: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsDataViewer: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdHelpAbout: return ADDONMenuStates.ADDON_MENU_ENABLED;
                    }

                    break;
                case IADPartSession:
                    switch (menuId)
                    {
                        case MenuIdRoot: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdUtils: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdGear: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdDataBrowser: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsCycloidalGear: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsStandardGear: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsAdvancedGear: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsPlaneFinder: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsDataViewer: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdHelpAbout: return ADDONMenuStates.ADDON_MENU_ENABLED;
                    }

                    break;
            }

            return ADDONMenuStates.ADDON_MENU_ENABLED;
        }

        /// <summary>
        /// Returns a tool tip string if input menu ID is that of a 'leaf' menu item
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public string MenuItemToolTip(int menuId)
        {
            switch (menuId)
            {
                case MenuIdRoot: return "Utilities";

                case MenuIdUtils: return "Utilities";
                case MenuIdGear: return "Gears";
                case SubmenuIdDataBrowser: return "Opens the custom Data Browser";
                case SubmenuIdUtilsCycloidalGear: return "Opens/Closes Cycloidal Gear Generator";
                case SubmenuIdUtilsStandardGear: return "Opens Standard Spur and Helical Gear Generator";
                case SubmenuIdUtilsAdvancedGear: return "Opens Advanced Spur and Helical Gear Generator";
                case SubmenuIdUtilsPlaneFinder: return "Finds the Plane on which a selected Sketch is drawn";
                case SubmenuIdUtilsDataViewer: return "Opens/Closes Property Viewer";
                case SubmenuIdHelpAbout: return "About Utilities for Alibre";
            }

            return "";
        }

        /// <summary>
        /// Returns the icon name (with extension) for a menu item; the icon will be searched under the folder where the add-on's .adc file is present
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public string MenuIcon(int menuId)
        {
            // if you want icons, reference them here...
            // switch (menuID)
            // {
            //     case SUBMENU_ID_HELP_ABOUT: return "icons/userquestion.ico";
            //     case SUBMENU_ID_DATA_BROWSER: return "icons/search.ico";
            //     case SUBMENU_ID_FILE_OPEN: return "icons/file-code-add.ico";
            //     case SUBMENU_ID_FILE_CLOSE: return "icons/file-code-star.ico";
            //     case SUBMENU_ID_FILE_EXIT: return "icons/file-code-question.ico";
            //     case SUBMENU_ID_UTILS_CYCLOIDAL_GEAR: return "icons/cog-double.ico";
            //     case SUBMENU_ID_UTILS_PLANE_FINDER: return "";
            //     case SUBMENU_ID_UTILS_DATA_VIEWER: return "";
            // }

            return string.Empty;
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
        /// <param name="menuId"></param>
        /// <param name="sessionIdentifier"></param>
        /// <returns></returns>
        public IAlibreAddOnCommand InvokeCommand(int menuId, string sessionIdentifier)
        {
            var session = _alibreRoot.Sessions.Item(sessionIdentifier);

            switch (menuId)
            {
                case SubmenuIdDataBrowser:
                {
                    return DoDataBrowser();
                }
                case SubmenuIdUtilsCycloidalGear:
                {
                    return DoCycloidalGear(session);
                }
                case SubmenuIdUtilsStandardGear:
                {
                    return DoStandardGear();
                }
                case SubmenuIdUtilsAdvancedGear:
                {
                    return DoAdvancedGear();
                }
                case SubmenuIdUtilsPlaneFinder:
                {
                    return DoPlaneFinder(session);
                }
                case SubmenuIdUtilsDataViewer:
                {
                    return DoAlibreDataViewer(session);
                }
                case SubmenuIdHelpAbout:
                {
                    return DoHelpAbout(session);
                }
            }

            return null;
        }

        #endregion

        #region DataViewer

        /// <summary>
        /// A dictionary to keep track of currently open AlibreDataViewerAddOnCommand object.
        /// </summary>
        private readonly Dictionary<string, AlibreDataViewerAddOnCommand> _dataViewerAddOnCommands = new();

        /// <summary>
        /// Toggles the viewer on/off
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        private IAlibreAddOnCommand DoAlibreDataViewer(IADSession session)
        {
            AlibreDataViewerAddOnCommand alibreDataViewerAddOnCommand;
            if (!_dataViewerAddOnCommands.ContainsKey(session.Identifier))
            {
                alibreDataViewerAddOnCommand = new AlibreDataViewerAddOnCommand(session);
                alibreDataViewerAddOnCommand.AlibreDataViewer.Visible = true;
                alibreDataViewerAddOnCommand.Terminate += AlibreDataViewerAddOnCommandOnTerminate;
                _dataViewerAddOnCommands.Add(session.Identifier, alibreDataViewerAddOnCommand);
            }
            else
            {
                if (_dataViewerAddOnCommands.TryGetValue(session.Identifier, out alibreDataViewerAddOnCommand))
                {
                    alibreDataViewerAddOnCommand.UserRequestedClose();
                    _dataViewerAddOnCommands.Remove(session.Identifier);
                    return null;
                }
            }

            return alibreDataViewerAddOnCommand;
        }

        private void AlibreDataViewerAddOnCommandOnTerminate(object sender,
            AlibreDataViewerAddOnCommandTerminateEventArgs e)
        {
            AlibreDataViewerAddOnCommand alibreDataViewerAddOnCommand;
            if (_dataViewerAddOnCommands.TryGetValue(e.AlibreDataViewerAddOnCommand.Session.Identifier,
                    out alibreDataViewerAddOnCommand))
            {
                _dataViewerAddOnCommands.Remove(e.AlibreDataViewerAddOnCommand.Session.Identifier);
            }
        }

        #endregion

        #region PlaneFinder

        /// <summary>
        /// A dictionary to keep track of currently open PlaneFinderAddOnCommand object.
        /// </summary>
        private readonly Dictionary<string, PlaneFinderAddOnCommand> _planeFinderAddOnCommands = new();

        private IAlibreAddOnCommand DoPlaneFinder(IADSession session)
        {
            PlaneFinderAddOnCommand planeFinderAddOnCommand;
            if (!_planeFinderAddOnCommands.ContainsKey(session.Identifier))
            {
                planeFinderAddOnCommand = new PlaneFinderAddOnCommand(session);
                planeFinderAddOnCommand.PlaneFinder.Visible = true;
                planeFinderAddOnCommand.Terminate += PlaneFinderAddOnCommandOnTerminate;
                _planeFinderAddOnCommands.Add(session.Identifier, planeFinderAddOnCommand);
            }
            else
            {
                if (_planeFinderAddOnCommands.TryGetValue(session.Identifier, out planeFinderAddOnCommand))
                {
                    planeFinderAddOnCommand.UserRequestedClose();
                    _planeFinderAddOnCommands.Remove(session.Identifier);
                    return null;
                }
            }

            return planeFinderAddOnCommand;
        }

        private void PlaneFinderAddOnCommandOnTerminate(object sender, PlaneFinderAddOnCommandTerminateEventArgs e)
        {
            PlaneFinderAddOnCommand planeFinderAddOnCommand;
            if (_planeFinderAddOnCommands.TryGetValue(e.PlaneFinderAddOnCommand.Session.Identifier,
                    out planeFinderAddOnCommand))
            {
                _planeFinderAddOnCommands.Remove(e.PlaneFinderAddOnCommand.Session.Identifier);
            }
        }

        #endregion

        #region CycloidalGear

        /// <summary>
        /// A dictionary to keep track of currently open AlibreDataViewerAddOnCommand object.
        /// </summary>
        private Dictionary<string, CycloidalGearAddOnCommand> _cycloidalGearAddOnCommands = new();

        /// <summary>
        /// Opens the Cycloidal Gear generator dialog.
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        private IAlibreAddOnCommand DoCycloidalGear(IADSession session)
        {
            CycloidalGearAddOnCommand cycloidalGearAddOnCommand;
            if (!_cycloidalGearAddOnCommands.ContainsKey(session.Identifier))
            {
                cycloidalGearAddOnCommand = new CycloidalGearAddOnCommand(session);
                cycloidalGearAddOnCommand.CycliodalGearParametersForm.Visible = true;
                cycloidalGearAddOnCommand.Terminate += CycloidalGearAddOnCommandOnTerminate;
                _cycloidalGearAddOnCommands.Add(session.Identifier, cycloidalGearAddOnCommand);
            }
            else
            {
                if (_cycloidalGearAddOnCommands.TryGetValue(session.Identifier, out cycloidalGearAddOnCommand))
                {
                    cycloidalGearAddOnCommand.UserRequestedClose();
                    _cycloidalGearAddOnCommands.Remove(session.Identifier);
                    return null;
                }
            }

            return cycloidalGearAddOnCommand;
        }

        private void CycloidalGearAddOnCommandOnTerminate(object sender, CycloidalGearAddOnCommandTerminateEventArgs e)
        {
            CycloidalGearAddOnCommand cycloidalGearAddOnCommand;
            if (_cycloidalGearAddOnCommands.TryGetValue(e.CycloidalGearAddOnCommand.Session.Identifier,
                    out cycloidalGearAddOnCommand))
            {
                _cycloidalGearAddOnCommands.Remove(e.CycloidalGearAddOnCommand.Session.Identifier);
            }
        }

        #endregion

        #region HelpAbout

        private IAlibreAddOnCommand DoHelpAbout(IADSession session)
        {
            var aboutForm = new AboutForm();
            aboutForm.Visible = true;
            return null;
        }

        #endregion

        #region DataBrowser

        /// <summary>
        /// Opens the DataBrowser.
        /// Note that the DataBrowser returned is a static instance.
        /// Any files already indexed by the DataBrowser will not show updated data if subsequently saved via Alibre. 
        /// </summary>
        /// <returns></returns>
        private static IAlibreAddOnCommand DoDataBrowser()
        {
            var browserForm = DataBrowserForm.Instance();
            browserForm.Visible = true;
            return null;
        }

        #endregion

        #region Bevel

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private IAlibreAddOnCommand DoStandardGear()
        {
            var form = new StandardGearForm();
            form.Show();
            return null;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private IAlibreAddOnCommand DoAdvancedGear()
        {
            var form = new InvoluteGearForm();
            form.Show();

            return null;
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
            return false;
        }
    }
}