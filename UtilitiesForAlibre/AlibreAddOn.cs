using System;
using AlibreAddOn;
using AlibreX;
using Bolsover;


namespace AlibreAddOnAssembly
{
    public static class AlibreAddOn
    {
        private static IADRoot alibreRoot { get; set; }
        private static IntPtr parentWinHandle;
        private static UtilitiesForAlibre _utilitiesForAlibre;

        public static void AddOnLoad(IntPtr hwnd, IAutomationHook pAutomationHook, IntPtr unused)
        {
            alibreRoot = (IADRoot) pAutomationHook.Root;
            parentWinHandle = hwnd;
            _utilitiesForAlibre = new UtilitiesForAlibre(alibreRoot, parentWinHandle);
        }

        public static IADRoot GetRoot()
        {
            return alibreRoot;
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
           return (IAlibreAddOn) _utilitiesForAlibre;
        }
    }
}