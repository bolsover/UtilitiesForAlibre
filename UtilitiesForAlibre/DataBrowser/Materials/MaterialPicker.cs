using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using AlibreX;
using BrightIdeasSoftware;

namespace Bolsover.DataBrowser.Materials
{
    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    [DefaultBindingProperty("Value")]
    public partial class MaterialPicker : UserControl
    {
        private MaterialNode Root;
        private string originalValue = null;
        private MaterialNode value = null;


        public MaterialPicker(string value)
        {
            Console.WriteLine(value);
            originalValue = value;
            InitializeComponent();
            Root = PrepareMaterialsTree();
            setupColumns();
            setupTree();
            // actually uses cellEditStarting to detect when an item has been selected
            treeListView1.CellEditStarting += HandleCellEditStarting;
        }


        /*
          * Event handler used when a material item has been selected
          */
        public event EventHandler<SelectedItemEventArgs> ItemHasBeenSelected;

        private void HandleCellEditStarting(object sender, CellEditEventArgs e)
        {
            value = (MaterialNode) e.RowObject;
            // Pass onto ItemHasBeenSelected handler
            var handler = ItemHasBeenSelected;
            if (handler != null)
            {
                handler(this, new SelectedItemEventArgs
                    {SelectedChoice = value});
            }

            // dispose the MaterialPicker
            Dispose();
        }


        /*
         * Initial preparation of the materials tree
         * Creates the root object and immediate subordinate libraries
         * Adds all material entries at the library level including material name and guid.
         * Materials at the library level will subsequently be filtered to remove duplicates found in subdirectories
         * Call to recursive WalkMaterials method to add detail from subdirectories
         */
        private MaterialNode PrepareMaterialsTree()
        {
            var libraries = AlibreConnector.RetrieveMaterialLibrariesForRoot();
            Root = new MaterialNode("Material Library");
            foreach (IADMaterialLibrary library in libraries)
            {
                var child = new MaterialNode(library.Name);
                Root.AddChild(child);
                foreach (IADMaterial material in library.Materials)
                {
                    var materialNode = new MaterialNode(material.Name);
                    materialNode.Material = material;
                    materialNode.Guid = GetAlibreMaterialGuid(material);
                    child.AddChild(materialNode);
                }

                WalkMaterials(library, child, child);
            }

            return Root;
        }


        /*
         * Recursive routine to add all materials in library folders.
         * Grr... hate this next bit
         * Also removes any materials from top level libraries also found at lower levels.
         */
        private void WalkMaterials(IADMaterialLibrary library, MaterialNode parent, MaterialNode toplevel)
        {
            foreach (IADMaterialLibraryFolder folder in library.Folders)
            {
                var f = new MaterialNode(folder.Name);
                parent.AddChild(f);

                foreach (IADMaterial material in folder.Materials)
                {
                    var subMaterial = new MaterialNode(material.Name);
                    subMaterial.Material = material;
                    subMaterial.Guid = GetAlibreMaterialGuid(material);
                    f.AddChild(subMaterial);
                    // if this subMaterial is also in the toplevel materials remove from top level
                    toplevel.RemoveChild(subMaterial);
                }

                foreach (IADMaterialLibrary subLibrary in folder.SubFolders)
                {
                    WalkMaterials(subLibrary, f, toplevel);
                }
            }
        }

        /*
         * Nasty routine to obtain material guid.
         */
        private string GetAlibreMaterialGuid(object obj)
        {
            var t = obj.GetType();
            var fieldInfo = t.GetField("alibreMaterial",
                BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                BindingFlags.Static);
            var alibreMaterial = fieldInfo.GetValue(obj);
            var t2 = alibreMaterial.GetType();
            var propertyInfo2 = t2.GetProperty("Guid",
                BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                BindingFlags.Static);
            var guid = propertyInfo2.GetValue(alibreMaterial);
            return (string) guid;
        }

        private void setupColumns()
        {
            ConfigureAspectGetters();
        }


        private void ConfigureAspectGetters()
        {
            olvColumnName.AspectGetter = rowObject => ((MaterialNode) rowObject).NodeName;
        }


        private void setupTree()
        {
            treeListView1.CanExpandGetter = rowObject => ((MaterialNode) rowObject).CanExpand;
            treeListView1.ChildrenGetter = rowObject =>
            {
                try
                {
                    return ((MaterialNode) rowObject).ChList;
                }
                catch (UnauthorizedAccessException)
                {
                    BeginInvoke((MethodInvoker) delegate { treeListView1.Collapse(rowObject); });
                    return new ArrayList();
                }
            };
            var roots = new ArrayList();
            roots.Add(PrepareMaterialsTree());
            treeListView1.Roots = roots;
        }

        public class SelectedItemEventArgs : EventArgs
        {
            public MaterialNode SelectedChoice { get; set; }
        }
    }
}