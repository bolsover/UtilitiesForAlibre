using System;
using System.Windows.Forms;
using AlibreAddOn;
using AlibreX;
using Bolsover;

namespace AlibreAddOnAssembly
{
    public static class AlibreAddOn
    {
        private static IntPtr _parentWinHandle;
        private static Bolsover.UtilitiesForAlibre _utilitiesForAlibre;
        private static IADRoot AlibreRoot { get; set; }
        
        
        public static void AddOnLoad(IntPtr hwnd, IAutomationHook pAutomationHook, IntPtr unused)
        {
            AlibreRoot = (IADRoot) pAutomationHook.Root;
            _parentWinHandle = hwnd;
            var version = AlibreRoot.Version.Replace("PRODUCTVERSION ", "");
            var versionarr = version.Split(',');
            Globals.MajorVersion = int.Parse(versionarr[0]);
            var message = Globals.AppName + "requires a newer version of Alibre Design";
            var caption = "Utilities For Alibre - Error";
            if (Globals.MajorVersion < 27)
            {
                  MessageBox.Show(message, caption);
            }
            
              
            
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
            return _utilitiesForAlibre;
        }
    }
}