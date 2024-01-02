﻿using System.Collections;
using System.Windows.Forms;
using AlibreX;
using Bolsover.DataBrowser;

namespace Bolsover.AlibreDataViewer
{
    public partial class AlibreDataViewer : UserControl
    {
        public object RootObject { get; set; }
        private IADSession _session;


        public AlibreDataViewer(IADSession session)
        {
            this._session = session;
            InitializeComponent();
            SetupColumns();
            SetupTree();
        }


        public void SetRootObject(object rootObject)
        {
            this.RootObject = rootObject;
            var roots = new ArrayList();
            var infos = rootObject.GetType().GetProperties();
            for (var i = 0; i < infos.Length; i++)
            {
                var child = new AlibreData(rootObject);
                var info = infos[i];
                child.PropertyName = info.Name;
                child.ClassType = info.PropertyType.Name;
                child.PropertyValue = AlibreData.IsPrimitiveType(child.GetPropertyValue(rootObject, info.Name))
                    ? child.GetPropertyValue(rootObject, info.Name)
                    : "";
                child.Value = child.GetPropertyValue(rootObject, info.Name);

                roots.Add(child);
            }

            treeListView.SetObjects(roots);
        }


        private void SetupTree()
        {
            treeListView.CanExpandGetter = rowObject =>
                ((AlibreData) rowObject).HasChildren() | !AlibreData.IsPrimitiveType(((AlibreData) rowObject).Value);
            treeListView.ChildrenGetter =
                rowObject => ((AlibreData) rowObject).GetChildData(((AlibreData) rowObject).Value);
        }

        private void SetupColumns()
        {
            olvColumnProperty.AspectGetter =
                rowObject => ((AlibreData) rowObject).PropertyName;
            olvColumnType.AspectGetter =
                rowObject => ((AlibreData) rowObject).ClassType;
            olvColumnValue.AspectGetter =
                rowObject => ((AlibreData) rowObject).PropertyValue;
        }
    }
}