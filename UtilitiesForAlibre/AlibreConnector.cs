using System;
using System.Runtime.CompilerServices;
using AlibreX;

namespace Bolsover
{
    public class AlibreConnector
    {
        private static IADRoot root;
        private static AlibreConnector instance = null;


        /// <summary>
        /// Static constructor; initialises the AutomationHook and IADRoot.
        /// </summary>
        static AlibreConnector()
        {
            root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
        }


        /// <summary>
        /// Terminates the root connection to Alibre - called when the application quits
        /// </summary>
        public static void TerminateAll()
        {
            root.TerminateAll();
        }

        public static IADRoot GetRoot()
        {
            return root;
        }

        /// <summary>
        /// Returns the collection of IADMaterialLibraries
        /// </summary>
        /// <returns></returns>
        public static IADMaterialLibraries RetrieveMaterialLibrariesForRoot()
        {
            return root.MaterialLibraries;
        }

        /// <summary>
        /// Returns an IADDesignSession by opening the file associated with the AlibreFileSystem property
        /// </summary>
        /// <param name="alibreFileSystem"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IADDesignSession RetrieveSessionForFile(AlibreFileSystem alibreFileSystem)
        {
            return (IADDesignSession) root.OpenFileEx(alibreFileSystem.FullName, false);
        }


        /// <summary>
        /// Returns an IADDrawingSession by opening the file associated with the AlibreFileSystem property
        /// </summary>
        /// <param name="alibreFileSystem"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IADDrawingSession RetrieveDrawingSessionForFile(AlibreFileSystem alibreFileSystem)
        {
            return (IADDrawingSession) root.OpenFileEx(alibreFileSystem.FullName, false);
        }
    }
}