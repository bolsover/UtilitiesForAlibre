using System;
using System.Windows.Forms;
using AlibreAddOn;
using AlibreX;
using Bolsover;


namespace AlibreAddOnAssembly
{
    public static class AlibreAddOn
    {
        private static IADRoot AlibreRoot { get; set; }
        private static IntPtr _parentWinHandle;
        private static Bolsover.UtilitiesForAlibre _utilitiesForAlibre;


        public static void AddOnLoad(IntPtr hwnd, IAutomationHook pAutomationHook, IntPtr unused)
        {
            AlibreRoot = (IADRoot) pAutomationHook.Root;
            _parentWinHandle = hwnd;
            // var version = AlibreRoot.Version.Replace("PRODUCTVERSION ", "");
            // var versionarr = version.Split(',');
            // var majorVersion = int.Parse(versionarr[0]);
            // if (majorVersion < 27)
            //     MessageBox.Show(Globals.AppName + "requires a newer version of Alibre Design", "Error");

            _utilitiesForAlibre = new Bolsover.UtilitiesForAlibre(AlibreRoot, _parentWinHandle);
        }

        public static IADRoot GetRoot()
        {
            return AlibreRoot;
        }

        public static void AddOnInvoke(
            IntPtr hwnd,
            IntPtr pAutomationHook,
            string sessionName,
            bool isLicensed,
            int reserved1,
            int reserved2)
        {
        }


        public static void AddOnUnload(
            IntPtr hwnd,
            bool forceUnload,
            ref bool cancel,
            int reserved1,
            int reserved2)
        {
        }


        public static IAlibreAddOn GetAddOnInterface()
        {
            return  _utilitiesForAlibre;
        }
    }
}