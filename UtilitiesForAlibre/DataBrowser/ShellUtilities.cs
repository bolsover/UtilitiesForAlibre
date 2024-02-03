using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Bolsover.DataBrowser
{
    /// <summary>
    ///     This helper class allows listviews and tree views to use image from the system image list.
    /// </summary>
    /// <remarks>
    ///     Instances of this helper class know how to retrieve icon from the Windows shell for
    ///     a given file path. These icons are then added to the imagelist on the given control. ListViews need
    ///     special handling since they have two image lists which need to be kept in sync.
    /// </remarks>
    public class SysImageListHelper
    {
        private ObjectListView _listView;
        protected TreeView TreeView;


        /// <summary>
        ///     Create a SysImageListHelper that will fetch images for the given listview control.
        /// </summary>
        /// <param name="listView">The listview that will use the images</param>
        /// <remarks>
        ///     Listviews manage two image lists, but each item can only have one image index.
        ///     This means that the image for an item must occur at the same index in the two lists.
        ///     SysImageListHelper instances handle this requirement. However, if the listview already
        ///     has image lists installed, they <b>must</b> be of the same length.
        /// </remarks>
        public SysImageListHelper(ObjectListView listView)
        {
            if (listView.SmallImageList == null)
            {
                listView.SmallImageList = new ImageList();
                listView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
                listView.SmallImageList.ImageSize = new Size(16, 16);
            }

            if (listView.LargeImageList == null)
            {
                listView.LargeImageList = new ImageList();
                listView.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
                listView.LargeImageList.ImageSize = new Size(32, 32);
            }

            _listView = listView;
        }

        private ImageList.ImageCollection SmallImageCollection
        {
            get
            {
                return _listView != null ? _listView.SmallImageList.Images : TreeView?.ImageList.Images;
            }
        }

        protected ImageList.ImageCollection LargeImageCollection
        {
            get => _listView?.LargeImageList.Images;
        }

        private ImageList SmallImageList
        {
            get
            {
                if (_listView != null)
                {
                    return _listView.SmallImageList;
                }

                return TreeView?.ImageList;
            }
        }

        private ImageList LargeImageList => _listView?.LargeImageList;

        /// <summary>
        ///     Return the index of the image that has the Shell Icon for the given file/directory.
        /// </summary>
        /// <param name="path">The full path to the file/directory</param>
        /// <returns>The index of the image or -1 if something goes wrong.</returns>
        public int GetImageIndex(string path)
        {
            if (Directory.Exists(path))
            {
                path = Environment.SystemDirectory; // optimization! give all directories the same image
            }
            else if (Path.HasExtension(path))
            {
                path = Path.GetExtension(path);
            }

            if (SmallImageCollection.ContainsKey(path))
            {
                return SmallImageCollection.IndexOfKey(path);
            }

            try
            {
                AddImageToCollection(path, SmallImageList, ShellUtilities.GetFileIcon(path, true, true));
                AddImageToCollection(path, LargeImageList, ShellUtilities.GetFileIcon(path, false, true));
            }
            catch (ArgumentNullException)
            {
                return -1;
            }

            return SmallImageCollection.IndexOfKey(path);
        }

        private void AddImageToCollection(string key, ImageList imageList, Icon image)
        {
            if (imageList == null)
            {
                return;
            }

            if (imageList.ImageSize == image.Size)
            {
                imageList.Images.Add(key, image);
                return;
            }

            using (var imageAsBitmap = image.ToBitmap())
            {
                var bm = new Bitmap(imageList.ImageSize.Width, imageList.ImageSize.Height);
                var g = Graphics.FromImage(bm);
                g.Clear(imageList.TransparentColor);
                var size = imageAsBitmap.Size;
                var x = Math.Max(0, (bm.Size.Width - size.Width) / 2);
                var y = Math.Max(0, (bm.Size.Height - size.Height) / 2);
                g.DrawImage(imageAsBitmap, x, y, size.Width, size.Height);
                imageList.Images.Add(key, bm);
            }
        }
    }

    /// <summary>
    ///     ShellUtilities contains routines to interact with the Windows Shell.
    /// </summary>
    public static class ShellUtilities
    {
        /// <summary>
        ///     Execute the default verb on the file or directory identified by the given path.
        ///     For documents, this will open them with their normal application. For executables,
        ///     this will cause them to run.
        /// </summary>
        /// <param name="path">The file or directory to be executed</param>
        /// <returns>Values &lt; 31 indicate some sort of error. See ShellExecute() documentation for specifics.</returns>
        /// <remarks>The same effect can be achieved by <code>System.Diagnostics.Process.Start(path)</code>.</remarks>
        public static int Execute(string path)
        {
            return Execute(path, "");
        }

        /// <summary>
        ///     Execute the given operation on the file or directory identified by the given path.
        ///     Example operations are "edit", "print", "explore".
        /// </summary>
        /// <param name="path">The file or directory to be operated on</param>
        /// <param name="operation">What operation should be performed</param>
        /// <returns>Values &lt; 31 indicate some sort of error. See ShellExecute() documentation for specifics.</returns>
        public static int Execute(string path, string operation)
        {
            var result = ShellExecute(0, operation, path, "", "", SwShownormal);
            return result.ToInt32();
        }

        /// <summary>
        ///     Get the string that describes the file's type.
        /// </summary>
        /// <param name="path">The file or directory whose type is to be fetched</param>
        /// <returns>A string describing the type of the file, or an empty string if something goes wrong.</returns>
        public static string GetFileType(string path)
        {
            var shfi = new Shfileinfo();
            var flags = ShgfiTypename;
            var result = SHGetFileInfo(path, 0, out shfi, Marshal.SizeOf(shfi), flags);
            if (result.ToInt32() == 0)
            {
                return string.Empty;
            }

            return shfi.szTypeName;
        }

        /// <summary>
        ///     Return the icon for the given file/directory.
        /// </summary>
        /// <param name="path">The full path to the file whose icon is to be returned</param>
        /// <param name="isSmallImage">True if the small (16x16) icon is required, otherwise the 32x32 icon will be returned</param>
        /// <param name="useFileType">If this is true, only the file extension will be considered</param>
        /// <returns>The icon of the given file, or null if something goes wrong</returns>
        public static Icon GetFileIcon(string path, bool isSmallImage, bool useFileType)
        {
            var flags = ShgfiIcon;
            if (isSmallImage)
            {
                flags |= ShgfiSmallicon;
            }

            var fileAttributes = 0;
            if (useFileType)
            {
                flags |= ShgfiUsefileattributes;
                fileAttributes = Directory.Exists(path) ? FileAttributeDirectory : FileAttributeNormal;
            }

            var shfi = new Shfileinfo();
            var result = SHGetFileInfo(path, fileAttributes, out shfi, Marshal.SizeOf(shfi), flags);
            return result.ToInt32() == 0 ? null : Icon.FromHandle(shfi.hIcon);
        }

        /// <summary>
        ///     Return the index into the system image list of the image that represents the given file.
        /// </summary>
        /// <param name="path">The full path to the file or directory whose icon is required</param>
        /// <returns>The index of the icon, or -1 if something goes wrong</returns>
        /// <remarks>
        ///     This is only useful if you are using the system image lists directly. Since there is
        ///     no way to do that in .NET, it isn't a very useful.
        /// </remarks>
        public static int GetSysImageIndex(string path)
        {
            var shfi = new Shfileinfo();
            const int flags = ShgfiIcon | ShgfiSysiconindex;
            var result = SHGetFileInfo(path, 0, out shfi, Marshal.SizeOf(shfi), flags);
            if (result.ToInt32() == 0)
            {
                return -1;
            }

            return shfi.iIcon;
        }

        #region Native methods

        private const int ShgfiIcon = 0x00100; // get icon
        private const int ShgfiDisplayname = 0x00200; // get display name
        private const int ShgfiTypename = 0x00400; // get type name
        private const int ShgfiAttributes = 0x00800; // get attributes
        private const int ShgfiIconlocation = 0x01000; // get icon location
        private const int ShgfiExetype = 0x02000; // return exe type
        private const int ShgfiSysiconindex = 0x04000; // get system icon index
        private const int ShgfiLinkoverlay = 0x08000; // put a link overlay on icon
        private const int ShgfiSelected = 0x10000; // show icon in selected state
        private const int ShgfiAttrSpecified = 0x20000; // get only specified attributes
        private const int ShgfiLargeicon = 0x00000; // get large icon
        private const int ShgfiSmallicon = 0x00001; // get small icon
        private const int ShgfiOpenicon = 0x00002; // get open icon
        private const int ShgfiShelliconsize = 0x00004; // get shell size icon
        private const int ShgfiPidl = 0x00008; // pszPath is a pidl

        private const int ShgfiUsefileattributes = 0x00010; // use passed dwFileAttribute

        //if (_WIN32_IE >= 0x0500)
        private const int ShgfiAddoverlays = 0x00020; // apply the appropriate overlays
        private const int ShgfiOverlayindex = 0x00040; // Get the index of the overlay

        private const int FileAttributeNormal = 0x00080; // Normal file
        private const int FileAttributeDirectory = 0x00010; // Directory

        private const int MaxPath = 260;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct Shfileinfo
        {
            public readonly IntPtr hIcon;
            public readonly int iIcon;
            public readonly int dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)]
            public readonly string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public readonly string szTypeName;
        }

        private const int SwShownormal = 1;

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr ShellExecute(int hwnd, string lpOperation, string lpFile,
            string lpParameters, string lpDirectory, int nShowCmd);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes,
            out Shfileinfo psfi, int cbFileInfo, int uFlags);

        #endregion
    }
}