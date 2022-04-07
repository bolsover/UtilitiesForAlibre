using System;
using System.Collections.Generic;
using System.Diagnostics;
using AlibreAddOn;
using AlibreX;
using System.Windows.Forms;
using Bolsover.AlibreDataViewer;
using Bolsover.CycloidalGear;
using Bolsover.DataBrowser;
using Bolsover.EmptyShell;
using Bolsover.PlaneFinder;

namespace Bolsover
{
    public class UtilitiesForAlibre : IAlibreAddOn
    {
        private const int MENU_ID_ROOT = 401;
        private const int MENU_ID_FILE = 501;
        private const int SUBMENU_ID_FILE_OPEN = 502;
        private const int SUBMENU_ID_FILE_CLOSE = 503;
        private const int SUBMENU_ID_FILE_EXIT = 504;
        private const int SUBMENU_ID_DATA_BROWSER = 505;
        private const int MENU_ID_UTILS = 601;
        private const int SUBMENU_ID_UTILS_CYCLOIDAL_GEAR = 602;
        private const int SUBMENU_ID_UTILS_PLANE_FINDER = 603;
        private const int SUBMENU_ID_UTILS_DATA_VIEWER = 604;
        private const int SUBMENU_ID_UTILS_EMPTY_SHELL = 605;
        private const int MENU_ID_HELP = 701;
        private const int SUBMENU_ID_HELP_ABOUT = 702;


        private readonly int[] MENU_IDS_FILE;
        private readonly int[] MENU_IDS_UTILS;
        private readonly int[] MENU_IDS_ROOT;
        private readonly int[] MENU_IDS_HELP;

        private IADRoot alibreRoot;
        private IntPtr parentWinHandle;


        public UtilitiesForAlibre(IADRoot alibreRoot, IntPtr parentWinHandle)
        {
            this.alibreRoot = alibreRoot;
            this.parentWinHandle = parentWinHandle;
            MENU_IDS_FILE = new int[3]
            {
                SUBMENU_ID_FILE_OPEN, SUBMENU_ID_FILE_CLOSE, SUBMENU_ID_FILE_EXIT
            };
            MENU_IDS_UTILS = new int[5]
            {
                SUBMENU_ID_DATA_BROWSER, SUBMENU_ID_UTILS_CYCLOIDAL_GEAR, SUBMENU_ID_UTILS_PLANE_FINDER,
                SUBMENU_ID_UTILS_DATA_VIEWER, SUBMENU_ID_UTILS_EMPTY_SHELL
            };
            MENU_IDS_ROOT = new int[3]
            {
                MENU_ID_FILE, MENU_ID_UTILS, MENU_ID_HELP
            };
            MENU_IDS_HELP = new int[1]
            {
                SUBMENU_ID_HELP_ABOUT
            };
        }

        /// <summary>
        /// Description("Returns Whether the given Menu ID has any sub menus")
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public bool HasSubMenus(int menuID)
        {
            switch (menuID)
            {
                case MENU_ID_ROOT: return true;
                case MENU_ID_FILE: return true;
                case MENU_ID_UTILS: return true;
                case MENU_ID_HELP: return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the ID's of sub menu items under a popup menu item; the menu ID of a 'leaf' menu becomes its command ID
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public Array SubMenuItems(int menuID)
        {
            switch (menuID)
            {
                case MENU_ID_ROOT: return MENU_IDS_ROOT;
                case MENU_ID_FILE: return MENU_IDS_FILE;
                case MENU_ID_UTILS: return MENU_IDS_UTILS;
                case MENU_ID_HELP: return MENU_IDS_HELP;
            }

            return null;
        }

        /// <summary>
        /// Returns the display name of a menu item; a menu item with text of a single dash (“-“) is a separator
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public string MenuItemText(int menuID)
        {
            switch (menuID)
            {
                case MENU_ID_ROOT: return "Utilities";
                case MENU_ID_FILE: return "File";
                case MENU_ID_UTILS: return "Utilities";
                case MENU_ID_HELP: return "Help";
                case SUBMENU_ID_DATA_BROWSER: return "Data Browser";
                case SUBMENU_ID_FILE_OPEN: return "Open";
                case SUBMENU_ID_FILE_CLOSE: return "Save & Close";
                case SUBMENU_ID_FILE_EXIT: return "Save All, Exit";
                case SUBMENU_ID_UTILS_CYCLOIDAL_GEAR: return "Cycloidal Gear Generator Open/Close";
                case SUBMENU_ID_HELP_ABOUT: return "About";
                case SUBMENU_ID_UTILS_PLANE_FINDER: return "Sketch Plane Finder Open/Close";
                case SUBMENU_ID_UTILS_DATA_VIEWER: return "Property Viewer Open/Close";
                case SUBMENU_ID_UTILS_EMPTY_SHELL: return "Empty Shell Open/Close";
            }

            return "";
        }

        /// <summary>
        /// Returns True if input menu item has sub menus // seems odd given name of method
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public bool PopupMenu(int menuID)
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
        /// <param name="menuID"></param>
        /// <param name="sessionIdentifier"></param>
        /// <returns></returns>
        public ADDONMenuStates MenuItemState(int menuID, string sessionIdentifier)
        {
            var session = alibreRoot.Sessions.Item(sessionIdentifier);

            switch (session)
            {
                case IADDrawingSession:
                    switch (menuID)
                    {
                        case MENU_ID_ROOT: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case MENU_ID_FILE: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case MENU_ID_UTILS: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_DATA_BROWSER: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_FILE_OPEN: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_FILE_CLOSE: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_FILE_EXIT: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_UTILS_CYCLOIDAL_GEAR: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_UTILS_PLANE_FINDER: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_UTILS_DATA_VIEWER: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_UTILS_EMPTY_SHELL: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_HELP_ABOUT: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        
                    }

                    break;

                case IADAssemblySession:
                    switch (menuID)
                    {
                        case MENU_ID_ROOT: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MENU_ID_FILE: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MENU_ID_UTILS: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_DATA_BROWSER: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_FILE_OPEN: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_FILE_CLOSE: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_FILE_EXIT: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_UTILS_CYCLOIDAL_GEAR: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_UTILS_PLANE_FINDER: return ADDONMenuStates.ADDON_MENU_GRAYED;
                        case SUBMENU_ID_UTILS_DATA_VIEWER: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_UTILS_EMPTY_SHELL: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_HELP_ABOUT: return ADDONMenuStates.ADDON_MENU_ENABLED;
                    }

                    break;
                case IADPartSession:
                    switch (menuID)
                    {
                        case MENU_ID_ROOT: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MENU_ID_FILE: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case MENU_ID_UTILS: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_DATA_BROWSER: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_FILE_OPEN: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_FILE_CLOSE: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_FILE_EXIT: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_UTILS_CYCLOIDAL_GEAR: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_UTILS_PLANE_FINDER: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_UTILS_DATA_VIEWER: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_UTILS_EMPTY_SHELL: return ADDONMenuStates.ADDON_MENU_ENABLED;
                        case SUBMENU_ID_HELP_ABOUT: return ADDONMenuStates.ADDON_MENU_ENABLED;
                    }

                    break;
            }

            return ADDONMenuStates.ADDON_MENU_ENABLED;
        }

        /// <summary>
        /// Returns a tool tip string if input menu ID is that of a 'leaf' menu item
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public string MenuItemToolTip(int menuID)
        {
            switch (menuID)
            {
                case MENU_ID_ROOT: return "Utilities";
                case MENU_ID_FILE: return "File";
                case MENU_ID_UTILS: return "Utilities";
                case SUBMENU_ID_DATA_BROWSER: return "Opens the custom Data Browser";
                case SUBMENU_ID_FILE_OPEN: return "Opens files from file explorer";
                case SUBMENU_ID_FILE_CLOSE: return "Saves and closes the current file";
                case SUBMENU_ID_FILE_EXIT: return "Saves all open files and quits Alibre";
                case SUBMENU_ID_UTILS_CYCLOIDAL_GEAR: return "Opens/Closes Cycloidal Gear Generator";
                case SUBMENU_ID_UTILS_PLANE_FINDER: return "Finds the Plane on which a selected Sketch is drawn";
                case SUBMENU_ID_UTILS_DATA_VIEWER: return "Opens/Closes Property Viewer";
                case SUBMENU_ID_UTILS_EMPTY_SHELL: return "Opens/Closes Demo Utility";
                case SUBMENU_ID_HELP_ABOUT: return "About Utilities for Alibre";
            }

            return "";
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

            switch (menuID)
            {
                case SUBMENU_ID_DATA_BROWSER:
                {
                    return DoDataBrowser();
                }
                case SUBMENU_ID_FILE_OPEN:
                {
                    return DoFileOpen();
                }
                case SUBMENU_ID_FILE_CLOSE:
                {
                    return DoFileClose(session);
                }
                case SUBMENU_ID_FILE_EXIT:
                {
                    return DoFileExit();
                }
                case SUBMENU_ID_UTILS_CYCLOIDAL_GEAR:
                {
                    return DoCycloidalGear(session);
                }
                case SUBMENU_ID_UTILS_PLANE_FINDER:
                {
                    return DoPlaneFinder(session);
                }
                case SUBMENU_ID_UTILS_DATA_VIEWER:
                {
                    return DoAlibreDataViewer(session);
                }
                case SUBMENU_ID_UTILS_EMPTY_SHELL:
                {
                    return DoEmptyShell(session);
                }
                case SUBMENU_ID_HELP_ABOUT:
                {
                    return DoHelpAbout(session);
                }
            }

            return null;
        }
        
        /// <summary>
        /// A dictionary to keep track of currently open EmptyAddOnCommand object.
        /// </summary>
        private readonly Dictionary<string, EmptyAddOnCommand> emptyAddOnCommands = new();

        private IAlibreAddOnCommand DoEmptyShell(IADSession session)
        {
            EmptyAddOnCommand emptyViewerAddOnCommand;
            if (!emptyAddOnCommands.ContainsKey(session.Identifier))
            {
                emptyViewerAddOnCommand = new EmptyAddOnCommand(session);
                emptyViewerAddOnCommand.EmptyUserControl.Visible = true;
                emptyViewerAddOnCommand.Terminate+= EmptyAddOnCommandOnTerminate;
                emptyAddOnCommands.Add(session.Identifier, emptyViewerAddOnCommand);
            }
            else
            {
                if (emptyAddOnCommands.TryGetValue(session.Identifier, out emptyViewerAddOnCommand))
                {
                    emptyViewerAddOnCommand.UserRequestedClose();
                    emptyAddOnCommands.Remove(session.Identifier);
                    return null;
                }
            }

            return emptyViewerAddOnCommand;
        }
        
        private void EmptyAddOnCommandOnTerminate(object sender, EmptyAddonCommandTerminateEventArgs e)
        {
            EmptyAddOnCommand emptyAddOnCommand;
            if (emptyAddOnCommands.TryGetValue(e.emptyAddOnCommand.session.Identifier, out emptyAddOnCommand))
            {
                emptyAddOnCommands.Remove(e.emptyAddOnCommand.session.Identifier); 
            }
        }

        /// <summary>
        /// A dictionary to keep track of currently open AlibreDataViewerAddOnCommand object.
        /// </summary>
        private readonly Dictionary<string, AlibreDataViewerAddOnCommand> dataViewerAddOnCommands = new();


        /// <summary>
        /// Toggles the viewer on/off
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        private IAlibreAddOnCommand DoAlibreDataViewer(IADSession session)
        {
            AlibreDataViewerAddOnCommand alibreDataViewerAddOnCommand;
            if (!dataViewerAddOnCommands.ContainsKey(session.Identifier))
            {
                alibreDataViewerAddOnCommand = new AlibreDataViewerAddOnCommand(session);
                alibreDataViewerAddOnCommand.alibreDataViewer.Visible = true;
                alibreDataViewerAddOnCommand.Terminate+= AlibreDataViewerAddOnCommandOnTerminate;
                dataViewerAddOnCommands.Add(session.Identifier, alibreDataViewerAddOnCommand);
            }
            else
            {
                if (dataViewerAddOnCommands.TryGetValue(session.Identifier, out alibreDataViewerAddOnCommand))
                {
                    alibreDataViewerAddOnCommand.UserRequestedClose();
                    dataViewerAddOnCommands.Remove(session.Identifier);
                    return null;
                }
            }

            return alibreDataViewerAddOnCommand;
        }

        private void AlibreDataViewerAddOnCommandOnTerminate(object sender, AlibreDataViewerAddOnCommandTerminateEventArgs e)
        {
            AlibreDataViewerAddOnCommand alibreDataViewerAddOnCommand;
            if (dataViewerAddOnCommands.TryGetValue(e.alibreDataViewerAddOnCommand.session.Identifier, out alibreDataViewerAddOnCommand))
            {
                dataViewerAddOnCommands.Remove(e.alibreDataViewerAddOnCommand.session.Identifier); 
            }
        }
        
        /// <summary>
        /// A dictionary to keep track of currently open PlaneFinderAddOnCommand object.
        /// </summary>
        private readonly Dictionary<string, PlaneFinderAddOnCommand> planeFinderAddOnCommands = new();

        private IAlibreAddOnCommand DoPlaneFinder(IADSession session)
        {
            PlaneFinderAddOnCommand planeFinderAddOnCommand;
            if (!planeFinderAddOnCommands.ContainsKey(session.Identifier))
            {
                planeFinderAddOnCommand = new PlaneFinderAddOnCommand(session);
                planeFinderAddOnCommand.PlaneFinder.Visible = true;
                planeFinderAddOnCommand.Terminate+= PlaneFinderAddOnCommandOnTerminate;
                planeFinderAddOnCommands.Add(session.Identifier, planeFinderAddOnCommand);
            }
            else
            {
                if (planeFinderAddOnCommands.TryGetValue(session.Identifier, out planeFinderAddOnCommand))
                {
                    planeFinderAddOnCommand.UserRequestedClose();
                    planeFinderAddOnCommands.Remove(session.Identifier);
                    return null;
                }
            }

            return planeFinderAddOnCommand;
        }
        
        private void PlaneFinderAddOnCommandOnTerminate(object sender, PlaneFinderAddOnCommandTerminateEventArgs e)
        {
            PlaneFinderAddOnCommand planeFinderAddOnCommand;
            if (planeFinderAddOnCommands.TryGetValue(e.planeFinderAddOnCommand.session.Identifier, out planeFinderAddOnCommand))
            {
                planeFinderAddOnCommands.Remove(e.planeFinderAddOnCommand.session.Identifier); 
            }
        }
        

        private IAlibreAddOnCommand DoHelpAbout(IADSession session)
        {
            var aboutForm = new AboutForm();
            aboutForm.Visible = true;
            return null;
        }
        
        /// <summary>
        /// A dictionary to keep track of currently open AlibreDataViewerAddOnCommand object.
        /// </summary>
        private Dictionary<string, CycloidalGearAddOnCommand> cycloidalGearAddOnCommands = new();

        /// <summary>
        /// Opens the Cycloidal Gear generator dialog.
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        private IAlibreAddOnCommand DoCycloidalGear(IADSession session)
        {
            CycloidalGearAddOnCommand cycloidalGearAddOnCommand;
            if (!cycloidalGearAddOnCommands.ContainsKey(session.Identifier))
            {
                cycloidalGearAddOnCommand = new CycloidalGearAddOnCommand(session);
                cycloidalGearAddOnCommand.CycliodalGearParametersForm.Visible = true;
                cycloidalGearAddOnCommand.Terminate+= CycloidalGearAddOnCommandOnTerminate;
                cycloidalGearAddOnCommands.Add(session.Identifier, cycloidalGearAddOnCommand);
            }
            else
            {
                if (cycloidalGearAddOnCommands.TryGetValue(session.Identifier, out cycloidalGearAddOnCommand))
                {
                    cycloidalGearAddOnCommand.UserRequestedClose();
                    cycloidalGearAddOnCommands.Remove(session.Identifier);
                    return null;
                }
            }

            return cycloidalGearAddOnCommand;
        }
        
        private void CycloidalGearAddOnCommandOnTerminate(object sender, CycloidalGearAddOnCommandTerminateEventArgs e)
        {
            CycloidalGearAddOnCommand cycloidalGearAddOnCommand;
            if (cycloidalGearAddOnCommands.TryGetValue(e.cycloidalGearAddOnCommand.session.Identifier, out cycloidalGearAddOnCommand))
            {
                cycloidalGearAddOnCommands.Remove(e.cycloidalGearAddOnCommand.session.Identifier); 
            }
        }

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
        /// Closes the current session, saving the file if required
        /// </summary>
        /// <param name="currentSession"></param>
        /// <returns></returns>
        private static IAlibreAddOnCommand DoFileClose(IADSession currentSession)
        {
            currentSession.Close(true);
            return null;
        }

        /// <summary>
        /// Saves and closes all open files, terminates the application
        /// </summary>
        /// <returns></returns>
        private IAlibreAddOnCommand DoFileExit()
        {
            foreach (IADSession session in alibreRoot.Sessions) session.Close(true);
            alibreRoot.Terminate();
            return null;
        }

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
        /// Returns the icon name (with extension) for a menu item; the icon will be searched under the folder where the add-on's .adc file is present
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public string MenuIcon(int menuID)
        {
            // if you want icons, reference then here...
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
        /// Returns True if the AddOn needs to use a Dedicated Ribbon Tab
        /// </summary>
        /// <returns></returns>
        public bool UseDedicatedRibbonTab()
        {
            return false;
        }

        /// <summary>
        /// Returns the menu ID of the add-on's root menu item
        /// </summary>
        public int RootMenuItem => MENU_ID_ROOT;

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
    }
}