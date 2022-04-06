using System;
using System.Collections;
using System.Diagnostics;
using com.alibre.automation;

namespace Bolsover.DataBrowser
{
    public class AlibreData

    {
        private string classType;
        private ArrayList children = new();
        private string propertyName;
        private object propertyValue;
        private object value;
        private object parent;

        public AlibreData(object parent)
        {
            this.parent = parent;
        }

        public IEnumerable GetChildData(object parent)
        {
            try
            {
                if (parent is EnumVariant)
                {
                    var i = 0;
                    while (((EnumVariant) parent).HasMoreElements())
                    {
                        var o = ((EnumVariant) parent).NextElement();

                        CreateChild(parent, ref i, o);
                    }
                }

                else if (parent is ArrayList)
                {
                    var i = 0;
                    foreach (var o in (ArrayList) parent)
                        CreateChild(parent, ref i, o);
                    
                }
                else if (parent is IEnumerable)
                {
                    var i = 0;
                    foreach (var o in (IEnumerable) parent)
                        CreateChild(parent, ref i, o);
                    
                }
                else
                {
                    var infos = parent.GetType().GetProperties();
                    for (var i = 0; i < infos.Length; i++)
                    {
                        var child = new AlibreData(parent);
                        var info = infos[i];
                        child.PropertyName = info.Name;
                        child.ClassType = info.PropertyType.Name;
                        child.Value = GetPropertyValue(parent, info.Name);
                        child.PropertyValue = IsPrimitiveType(GetPropertyValue(parent, info.Name))
                            ? GetPropertyValue(parent, info.Name)
                            : "";
                        children.Add(child);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(parent);
            }

            return children;
        }

        private void CreateChild(object parent, ref int i, object o)
        {
            var child = new AlibreData(parent);
            child.PropertyName = "Entry " + i++;
            child.ClassType = o.GetType().Name;
            child.Value = o;
            child.PropertyValue = IsPrimitiveType(o) ? o : "";
            children.Add(child);
        }

        public static bool IsPrimitiveType(object o)
        {
            if (o is bool | o is byte | o is sbyte | o is char | o is decimal
                | o is double | o is float | o is int | o is uint | o is nint
                | o is nuint | o is long | o is ulong | o is short | o is ushort
                | o is ushort | o is string | o is Enum | o is String)
                return true;
            return false;
        }


        public object GetPropertyValue(object obj, string propName)
        {
            object o = null;
            try
            {
                o = obj.GetType().GetProperty(propName).GetValue(obj, null);
            }
            catch (Exception ex)
            {
                o = "Exception thrown getting " + propName;
            }

            return o;
        }


        public string ClassType
        {
            get => classType;
            set => classType = value;
        }

        public ArrayList Children
        {
            get => children;
            set => children = value;
        }

        public string PropertyName
        {
            get => propertyName;
            set => propertyName = value;
        }

        public object PropertyValue
        {
            get => propertyValue;
            set => propertyValue = value;
        }

        public object Parent
        {
            get => parent;
            set => parent = value;
        }

        public object Value
        {
            get => value;
            set => this.value = value;
        }

        public bool HasChildren()
        {
            return children.Count > 0;
        }
    }
}