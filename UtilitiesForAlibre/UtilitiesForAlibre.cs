using System;
using System.Collections.Generic;
using System.Diagnostics;
using AlibreAddOn;
using AlibreX;
using System.Windows.Forms;
using Bolsover.AlibreDataViewer;
using Bolsover.Bevel.Models;
using Bolsover.Bevel.Presenters;
using Bolsover.Bevel.Views;
using Bolsover.CycloidalGear;
using Bolsover.DataBrowser;
using Bolsover.PlaneFinder;
using Bolsover.Sample;
using Bolsover.ThreeDLine;


namespace Bolsover
{
    public class UtilitiesForAlibre : IAlibreAddOn
    {
        private const int MenuIdRoot = 401;
        private const int MenuIdFile = 501;
        private const int SubmenuIdFileOpen = 502;
        private const int SubmenuIdFileClose = 503;
        private const int SubmenuIdFileExit = 504;
        private const int SubmenuIdDataBrowser = 505;
        private const int MenuIdGear = 506;
        private const int MenuIdUtils = 601;
        private const int SubmenuIdUtilsCycloidalGear = 602;
        private const int SubmenuIdUtilsPlaneFinder = 603;
        private const int SubmenuIdUtilsDataViewer = 604;
        private const int SubmenuIdUtils3Dline = 605;
        private const int SubmenuIdUtilsBevelGear = 607;
        private const int SubmenuIdUtilsSpurGear = 608;
        private const int SubmenuIdUtilsSample = 606;
        private const int MenuIdHelp = 701;
        private const int SubmenuIdHelpAbout = 702;
        private int[] _menuIdsFile;
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
            _menuIdsFile = new int[3]
            {
                SubmenuIdFileOpen, SubmenuIdFileClose, SubmenuIdFileExit
            };
            _menuIdsUtils = new int[5]
            {
                SubmenuIdDataBrowser,
                SubmenuIdUtilsPlaneFinder,
                SubmenuIdUtilsDataViewer,
                SubmenuIdUtils3Dline,
                SubmenuIdUtilsSample
            };
            _menuIdsRoot = new int[4]
            {
                MenuIdFile, MenuIdUtils, MenuIdGear, MenuIdHelp
            };
            _menuIdsHelp = new int[1]
            {
                SubmenuIdHelpAbout
            };

            _menuIdsGear = new int[3]
            {
                SubmenuIdUtilsCycloidalGear, SubmenuIdUtilsBevelGear, SubmenuIdUtilsSpurGear
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
                case MenuIdFile: return true;
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
                case MenuIdFile: return _menuIdsFile;
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
                case MenuIdFile: return "File";
                case MenuIdUtils: return "Utilities";
                case MenuIdHelp: return "Help";
                case MenuIdGear: return "Gears";
                case SubmenuIdDataBrowser: return "Data Browser";
                case SubmenuIdFileOpen: return "Open";
                case SubmenuIdFileClose: return "Save & Close";
                case SubmenuIdFileExit: return "Save All, Exit";
                case SubmenuIdUtilsCycloidalGear: return "Cycloidal Gears Open/Close";
                case SubmenuIdUtilsBevelGear: return "Bevel Gears";
                case SubmenuIdUtilsSpurGear: return "Spur & Helical Gears";
                case SubmenuIdHelpAbout: return "About";
                case SubmenuIdUtilsPlaneFinder: return "Sketch Plane Finder Open/Close";
                case SubmenuIdUtilsDataViewer: return "Property Viewer Open/Close";
                case SubmenuIdUtils3Dline: return "3DLine Open/Close";
                case SubmenuIdUtilsSample: return "Sample Open/Close";
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
                        case MenuIdFile: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdUtils: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdDataBrowser: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdFileOpen: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdFileClose: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdFileExit: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsCycloidalGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsBevelGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsSpurGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsPlaneFinder: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsDataViewer: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtils3Dline: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsSample: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdHelpAbout: return ADDONMenuStates.ADDON_MENU_GRAYED;
                    }

                    break;

                case IADAssemblySession:
                    switch (menuId)
                    {
                        case MenuIdRoot: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdFile: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdUtils: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdDataBrowser: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdFileOpen: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdFileClose: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdFileExit: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsCycloidalGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsBevelGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsSpurGear: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsPlaneFinder: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsDataViewer: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtils3Dline: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SubmenuIdUtilsSample: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdHelpAbout: return ADDONMenuStates.ADDON_MENU_ENABLED;
                    }

                    break;
                case IADPartSession:
                    switch (menuId)
                    {
                        case MenuIdRoot: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdFile: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdUtils: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MenuIdGear: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdDataBrowser: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdFileOpen: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdFileClose: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdFileExit: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsCycloidalGear: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsBevelGear: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsSpurGear: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsPlaneFinder: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsDataViewer: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtils3Dline: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SubmenuIdUtilsSample: return ADDONMenuStates.ADDON_MENU_ENABLED;
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
                case MenuIdFile: return "File";
                case MenuIdUtils: return "Utilities";
                case MenuIdGear: return "Gears";
                case SubmenuIdDataBrowser: return "Opens the custom Data Browser";
                case SubmenuIdFileOpen: return "Opens files from file explorer";
                case SubmenuIdFileClose: return "Saves and closes the current file";
                case SubmenuIdFileExit: return "Saves all open files and quits Alibre";
                case SubmenuIdUtilsCycloidalGear: return "Opens/Closes Cycloidal Gear Generator";
                case SubmenuIdUtilsBevelGear: return "Opens Bevel Gear Generator";
                case SubmenuIdUtilsSpurGear: return "Opens Spur/Helical Gear Generator";
                case SubmenuIdUtilsPlaneFinder: return "Finds the Plane on which a selected Sketch is drawn";
                case SubmenuIdUtilsDataViewer: return "Opens/Closes Property Viewer";
                case SubmenuIdUtils3Dline: return "Opens/Closes 3DLine Generator";
                case SubmenuIdUtilsSample: return "Opens/Closes Sample";
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
                case SubmenuIdFileOpen:
                {
                    return DoFileOpen();
                }
                case SubmenuIdFileClose:
                {
                    return DoFileClose(session);
                }
                case SubmenuIdFileExit:
                {
                    return DoFileExit();
                }
                case SubmenuIdUtilsCycloidalGear:
                {
                    return DoCycloidalGear(session);
                }
                case SubmenuIdUtilsBevelGear:
                {
                    return DoBevelGear();
                }

                case SubmenuIdUtilsSpurGear:
                {
                    return DoGears();
                }
                case SubmenuIdUtilsPlaneFinder:
                {
                    return DoPlaneFinder(session);
                }
                case SubmenuIdUtilsDataViewer:
                {
                    return DoAlibreDataViewer(session);
                }
                case SubmenuIdUtils3Dline:
                {
                    return Do3DLine(session);
                }
                case SubmenuIdUtilsSample:
                {
                    return DoSample(session);
                }
                case SubmenuIdHelpAbout:
                {
                    return DoHelpAbout(session);
                }
            }

            return null;
        }

        #endregion

        #region ThreeDLine

        private readonly Dictionary<string, ThreeDLineAddOnCommand> _threeDLineAddOnCommands = new();

        private IAlibreAddOnCommand Do3DLine(IADSession session)
        {
            ThreeDLineAddOnCommand threeDLineAddOnCommand;
            if (!_threeDLineAddOnCommands.ContainsKey(session.Identifier))
            {
                threeDLineAddOnCommand = new ThreeDLineAddOnCommand(session);
                threeDLineAddOnCommand.ThreeDLineUserControl.Visible = true;
                threeDLineAddOnCommand.Terminate += (sender, e) => ThreeDLineAddOnCommandOnTerminate(sender, e);
                _threeDLineAddOnCommands.Add(session.Identifier, threeDLineAddOnCommand);
            }
            else
            {
                if (_threeDLineAddOnCommands.TryGetValue(session.Identifier, out threeDLineAddOnCommand))
                {
                    threeDLineAddOnCommand.UserRequestedClose();
                    _threeDLineAddOnCommands.Remove(session.Identifier);
                    return null;
                }
            }

            return threeDLineAddOnCommand;
        }

        private void ThreeDLineAddOnCommandOnTerminate(object sender, ThreeDLineAddOnCommandTerminateEventArgs e)
        {
            ThreeDLineAddOnCommand threeDLineAddOnCommand;
            if (_threeDLineAddOnCommands.TryGetValue(e.ThreeDLineAddOnCommand.Session.Identifier,
                    out threeDLineAddOnCommand))
            {
                _threeDLineAddOnCommands.Remove(e.ThreeDLineAddOnCommand.Session.Identifier);
            }
        }

        #endregion

        #region Sample

        /// <summary>
        /// A dictionary to keep track of currently open EmptyAddOnCommand object.
        /// </summary>
        private readonly Dictionary<string, SampleAddOnCommand> _sampleAddOnCommands = new();

        private IAlibreAddOnCommand DoSample(IADSession session)
        {
            SampleAddOnCommand sampleViewerAddOnCommand;
            if (!_sampleAddOnCommands.ContainsKey(session.Identifier))
            {
                sampleViewerAddOnCommand = new SampleAddOnCommand(session);
                sampleViewerAddOnCommand.SampleUserControl.Visible = true;
                sampleViewerAddOnCommand.Terminate += SampleAddOnCommandOnTerminate;
                _sampleAddOnCommands.Add(session.Identifier, sampleViewerAddOnCommand);
            }
            else
            {
                if (_sampleAddOnCommands.TryGetValue(session.Identifier, out sampleViewerAddOnCommand))
                {
                    sampleViewerAddOnCommand.UserRequestedClose();
                    _sampleAddOnCommands.Remove(session.Identifier);
                    return null;
                }
            }

            return sampleViewerAddOnCommand;
        }

        private void SampleAddOnCommandOnTerminate(object sender, SampleAddonCommandTerminateEventArgs e)
        {
            SampleAddOnCommand sampleAddOnCommand;
            if (_sampleAddOnCommands.TryGetValue(e.SampleAddOnCommand.Session.Identifier, out sampleAddOnCommand))
            {
                _sampleAddOnCommands.Remove(e.SampleAddOnCommand.Session.Identifier);
            }
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
        private IAlibreAddOnCommand DoBevelGear()
        {
            var bevelGearView = new BevelGearView();
            var pinion = new BevelGear
            {
                ShaftAngle = 90d,
                SpiralAngle = 0d,
                Module = 3.0d,
                PressureAngle = 20.0d,
                FaceWidth = 22.0d,
                NumberOfTeeth = 20.0d,
                Hand = "L",
                GearType = "Standard"
            };
            var gear = new BevelGear
            {
                ShaftAngle = 90d,
                SpiralAngle = 0d,
                Module = 3.0d,
                PressureAngle = 20.0d,
                FaceWidth = 22.0d,
                NumberOfTeeth = 40.0d,
                Hand = "R",
                GearType = "Standard"
            };

            var presenter = new BevelGearPresenter(bevelGearView, pinion, gear);
            var form = new BevelGearForm(bevelGearView);

            form.Show();
            return null;
        }

        #endregion

        #region Gears

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private IAlibreAddOnCommand DoGears()
        {
            Gear.GearForm.Instance();

            return null;
        }

        #endregion

        #region FileOpen

        /// <summary>
        /// Opens a standard file dialog, opens the selected file or returns null if the user closes the dialog without selecting a file.
        /// </summary>
        /// <returns></returns>
        private static IAlibreAddOnCommand DoFileOpen()
        {
            var filePath = string.Empty;
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Alibre Files (*.AD_*)|*.AD_*|All files (*.*)|*.*";
            openFileDialog.Title = "Open Alibre File";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
                OpenWithDefaultProgram(filePath);
                return (IAlibreAddOnCommand) null;
            }

            // fall through if no file selected
            return (IAlibreAddOnCommand) null;
        }

        /// <summary>
        /// Helper method to open files with default program
        /// </summary>
        /// <param name="path"></param>
        public static void OpenWithDefaultProgram(string path)
        {
            using var fileopener = new Process();
            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + path + "\"";
            fileopener.Start();
        }

        #endregion

        #region FileClose

        /// <summary>
        /// Closes the current session, saving the file if required
        /// </summary>
        /// <param name="currentSession"></param>
        /// <returns></returns>
        private static IAlibreAddOnCommand DoFileClose(IADSession currentSession)
        {
            //    object path = "E:/test";
            // currentSession.SaveNew(ref path);
            //   currentSession.SaveAs(ref path , "mytestassembly" );
            currentSession.Close(true);
            return null;
        }

        #endregion

        #region FileExit

        /// <summary>
        /// Saves and closes all open files, terminates the application
        /// </summary>
        /// <returns></returns>
        private IAlibreAddOnCommand DoFileExit()
        {
            foreach (IADSession session in _alibreRoot.Sessions)
            {
                session.Close(true);
            }

            _alibreRoot.Terminate();
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