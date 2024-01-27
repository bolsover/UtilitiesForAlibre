using System.Collections;
using System.Reflection;
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
            _session = session;
            InitializeComponent();
            SetupColumns();
            SetupTree();
        }


        public void SetRootObject(object rootObject)
        {
            RootObject = rootObject;
            var roots = new ArrayList();
            var infos = rootObject.GetType().GetProperties();
            foreach (var t in infos)
            {
                var child = new AlibreData(rootObject)
                {
                    PropertyName = t.Name,
                    ClassType = t.PropertyType.Name
                };
                child.PropertyValue = AlibreData.IsPrimitiveType(child.GetPropertyValue(rootObject, t.Name))
                    ? child.GetPropertyValue(rootObject, t.Name)
                    : "";
                child.Value = child.GetPropertyValue(rootObject, t.Name);

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