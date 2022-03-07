using System;
using System.Diagnostics;
using System.IO;
using AlibreAddOn;
using AlibreX;
using System.Windows.Forms;

namespace Bolsover
{
    public class UtilitiesForAlibre : IAlibreAddOn
    {
        private const int MENU_ID_ROOT = 401;
        private const int MENU_ID_FILE = 501;
        private const int SUBMENU_IDS_FILE_OPEN = 502;
        private const int SUBMENU_IDS_FILE_CLOSE = 503;
        private const int SUBMENU_IDS_FILE_EXIT = 504;
        private const int SUBMENU_IDS_DATA_BROWSER = 505;
        private const int MENU_ID_UTILS = 601;
        private const int SUBMENU_IDS_UTILS_CYCLOIDAL_GEAR = 602;

        private readonly int[] MENU_IDS_FILE;
        private readonly int[] MENU_IDS_UTILS;
        private readonly int[] MENU_IDS_ROOT;

        private IADRoot alibreRoot;
        //  private IntPtr parentWinHandle;

        public UtilitiesForAlibre(IADRoot alibreRoot)
        {
            this.alibreRoot = alibreRoot;
            //  this.parentWinHandle = parentWinHandle;
            MENU_IDS_FILE = new int[3]
            {
                SUBMENU_IDS_FILE_OPEN, SUBMENU_IDS_FILE_CLOSE, SUBMENU_IDS_FILE_EXIT
            };
            MENU_IDS_UTILS = new int[2]
            {
                SUBMENU_IDS_DATA_BROWSER, SUBMENU_IDS_UTILS_CYCLOIDAL_GEAR
            };
            MENU_IDS_ROOT = new int[2]
            {
                MENU_ID_FILE, MENU_ID_UTILS
            };
        }

        public bool HasSubMenus(int menuID)
        {
            switch (menuID)
            {
                case MENU_ID_ROOT: return true;
                case MENU_ID_FILE: return true;
                case MENU_ID_UTILS: return true;
            }

            return false;
        }

        public Array SubMenuItems(int menuID)
        {
            switch (menuID)
            {
                case MENU_ID_ROOT: return MENU_IDS_ROOT;
                case MENU_ID_FILE: return MENU_IDS_FILE;
                case MENU_ID_UTILS: return MENU_IDS_UTILS;
            }

            return null;
        }

        public string MenuItemText(int menuID)
        {
            switch (menuID)
            {
                case MENU_ID_ROOT: return "Utilities";
                case MENU_ID_FILE: return "File";
                case MENU_ID_UTILS: return "Utils";
                case SUBMENU_IDS_DATA_BROWSER: return "Data Browser";
                case SUBMENU_IDS_FILE_OPEN: return "Open";
                case SUBMENU_IDS_FILE_CLOSE: return "Save & Close";
                case SUBMENU_IDS_FILE_EXIT: return "Save All, Exit";
                case SUBMENU_IDS_UTILS_CYCLOIDAL_GEAR: return "Cycloidal Gear Generator";
            }

            return "";
        }

        public bool PopupMenu(int menuID)
        {
            return false;
        }

        public ADDONMenuStates MenuItemState(int menuID, string sessionIdentifier)
        {
            return ADDONMenuStates.ADDON_MENU_ENABLED;
        }

        public string MenuItemToolTip(int menuID)
        {
            switch (menuID)
            {
                case MENU_ID_ROOT: return "Utilities";
                case MENU_ID_FILE: return "File";
                case MENU_ID_UTILS: return "Utils";
                case SUBMENU_IDS_DATA_BROWSER: return "Opens the custom Data Browser";
                case SUBMENU_IDS_FILE_OPEN: return "Opens files from file explorer";
                case SUBMENU_IDS_FILE_CLOSE: return "Saves and closes the current file";
                case SUBMENU_IDS_FILE_EXIT: return "Saves all open files and quits Alibre";
                case SUBMENU_IDS_UTILS_CYCLOIDAL_GEAR: return "Cycloidal Gear Generator";
            }

            return "";
        }

        public bool HasPersistentDataToSave(string sessionIdentifier)
        {
            return false;
        }

        public IAlibreAddOnCommand InvokeCommand(int menuID, string sessionIdentifier)
        {
            var session = alibreRoot.Sessions.Item(sessionIdentifier);

            switch (menuID)
            {
                case SUBMENU_IDS_DATA_BROWSER:
                {
                    return DoDataBrowser();
                }
                case SUBMENU_IDS_FILE_OPEN:
                {
                    return DoFileOpen();
                }
                case SUBMENU_IDS_FILE_CLOSE:
                {
                    return DoFileClose(session);
                }
                case SUBMENU_IDS_FILE_EXIT:
                {
                    return DoFileExit();
                }
                case SUBMENU_IDS_UTILS_CYCLOIDAL_GEAR:
                {
                    return DoCycloidalGear(session);
                }
            }

            return null;
        }

        private IAlibreAddOnCommand DoCycloidalGear(IADSession session)
        {
            var cycliodalGearParametersForm = new CycliodalGearParametersForm(session);
            cycliodalGearParametersForm.Visible = true;
            return null;
        }

        private static IAlibreAddOnCommand DoDataBrowser()
        {
            var browserForm = DataBrowserForm.Instance();
            browserForm.Visible = true;
            return null;
        }

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

        private static IAlibreAddOnCommand DoFileClose(IADSession currentSession)
        {
            currentSession.Close(true);
            return null;
        }

        private IAlibreAddOnCommand DoFileExit()
        {
            foreach (IADSession session in alibreRoot.Sessions) session.Close(true);
            alibreRoot.Terminate();
            return null;
        }

        public void LoadData(IStream pCustomData, string sessionIdentifier)
        {
        }

        public void SaveData(IStream pCustomData, string sessionIdentifier)
        {
        }

        public void setIsAddOnLicensed(bool isLicensed)
        {
        }

        public string MenuIcon(int menuID)
        {
            return string.Empty;
        }

        public bool UseDedicatedRibbonTab()
        {
            return false;
        }

        public int RootMenuItem => MENU_ID_ROOT;

        public static void OpenWithDefaultProgram(string path)
        {
            using var fileopener = new Process();

            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + path + "\"";
            fileopener.Start();
        }
    }
}