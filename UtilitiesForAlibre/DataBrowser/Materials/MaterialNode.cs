using System.Collections;
using AlibreX;

namespace Bolsover.DataBrowser.Materials
{
    public class MaterialNode
    {
        public MaterialNode(string nodeName)
        {
            NodeName = nodeName;
        }

        public string Guid { get; set; }

        public IADMaterial Material { get; set; }
        public string NodeName { get; set; }

        public bool CanExpand => ChList != null;

        public ArrayList ChList { get; set; }

        public void AddChild(MaterialNode childNode)
        {
            if (ChList is null) ChList = new ArrayList();

            ChList.Add(childNode);
        }

        /*
     * Removes MaterialNode childNode from the ChList.
     */
        public void RemoveChild(MaterialNode childNode)
        {
            var j = -1;
            if (ChList != null)

                for (var i = 0; i < ChList.Count; i++)
                {
                    var node = (MaterialNode) ChList[i];
                    if (node.NodeName.Equals(childNode.NodeName))
                    {
                        j = i;
                        break;
                    }
                }

            if (j > -1) ChList.RemoveAt(j);
        }
    }
}