using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace Bolsover
{
    public partial class AlibreDataViewer : Form
    {
        
        public object rootObject{ get; set; }
        
        public AlibreDataViewer(object rootObject)
        {
            this.rootObject = rootObject;
            InitializeComponent();
            setupColumns();
            setupTree();
        }
        
        

        private void setupTree()
        {
            treeListView.CanExpandGetter = rowObject => ((AlibreData) rowObject).HasChildren() | !AlibreData.IsPrimitiveType(((AlibreData) rowObject).Value);
            treeListView.ChildrenGetter = rowObject => ((AlibreData) rowObject).GetChildData(((AlibreData) rowObject).Value);
            var roots = new ArrayList();
            PropertyInfo[] infos = rootObject.GetType().GetProperties();
            for (int i = 0; i < infos.Length; i++)
            {
                AlibreData child = new AlibreData(rootObject);
                PropertyInfo info = infos[i];
                child.PropertyName = info.Name;
                child.ClassType = info.PropertyType.Name;
                child.PropertyValue = AlibreData.IsPrimitiveType(child.GetPropertyValue(rootObject, info.Name)) ? child.GetPropertyValue(rootObject, info.Name) : "";
                child.Value = child.GetPropertyValue(rootObject, info.Name);
               
                roots.Add(child);
            }

            treeListView.Roots = roots;
            
        }

        private void setupColumns()
        {
            this.olvColumnProperty.AspectGetter =
                rowObject => ((AlibreData) rowObject).PropertyName;
            this.olvColumnType.AspectGetter =
                rowObject => ((AlibreData) rowObject).ClassType;
            this.olvColumnValue.AspectGetter =
                rowObject => ((AlibreData) rowObject).PropertyValue;
        }

    }
}