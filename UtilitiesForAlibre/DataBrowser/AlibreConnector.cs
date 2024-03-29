﻿using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AlibreX;

namespace Bolsover.DataBrowser
{
    public class AlibreConnector
    {
        private static IADRoot _root;
        // private static AlibreConnector instance = null;


        /// <summary>
        /// Static constructor; initialises the IADRoot.
        /// </summary>
        static AlibreConnector()
        {
            _root = AlibreAddOnAssembly.AlibreAddOn.GetRoot();
        }


        /// <summary>
        /// Terminates the root connection to Alibre - called when the application quits
        /// </summary>
        public static void TerminateAll()
        {
            _root.TerminateAll();
        }

        public static IADRoot GetRoot()
        {
            return _root;
        }

        /// <summary>
        /// Returns the collection of IADMaterialLibraries
        /// </summary>
        /// <returns></returns>
        public static IADMaterialLibraries RetrieveMaterialLibrariesForRoot()
        {
            return _root.MaterialLibraries;
        }

        /// <summary>
        /// Returns an IADDesignSession by opening the file associated with the AlibreFileSystem property
        /// </summary>
        /// <param name="alibreFileSystem"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IADDesignSession RetrieveSessionForFile(AlibreFileSystem alibreFileSystem)
        {
            IADDesignSession session;
            try
            {
                session = (IADDesignSession) _root.OpenFileEx(alibreFileSystem.FullName, false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show("Error opening file " + alibreFileSystem.FullName, "Error");
                return null;
            }

            return session;
        }


        /// <summary>
        /// Returns an IADDrawingSession by opening the file associated with the AlibreFileSystem property
        /// </summary>
        /// <param name="alibreFileSystem"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IADDrawingSession RetrieveDrawingSessionForFile(AlibreFileSystem alibreFileSystem)
        {
            IADDrawingSession session;
            try
            {
                session = (IADDrawingSession) _root.OpenFileEx(alibreFileSystem.FullName, false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show("Error opening file " + alibreFileSystem.FullName, "Error");
                return null;
            }

            return session;
        }
    }
}