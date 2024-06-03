using System;
using System.Collections;
using System.Diagnostics;
using com.alibre.automation;

namespace Bolsover.DataBrowser
{
    public class AlibreData
    
    {
        public AlibreData(object parent)
        {
            Parent = parent;
        }
        
        
        public string ClassType { get; set; }
        
        public ArrayList Children { get; set; } = new();
        
        public string PropertyName { get; set; }
        
        public object PropertyValue { get; set; }
        
        public object Parent { get; set; }
        
        public object Value { get; set; }
        
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
                    {
                        CreateChild(parent, ref i, o);
                    }
                }
                else if (parent is IEnumerable)
                {
                    var i = 0;
                    foreach (var o in (IEnumerable) parent)
                    {
                        CreateChild(parent, ref i, o);
                    }
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
                        Children.Add(child);
                    }
                }
            }
            catch (Exception)
            {
                Debug.WriteLine(parent);
            }
            
            return Children;
        }
        
        private void CreateChild(object parent, ref int i, object o)
        {
            var child = new AlibreData(parent);
            child.PropertyName = "Entry " + i++;
            child.ClassType = o.GetType().Name;
            child.Value = o;
            child.PropertyValue = IsPrimitiveType(o) ? o : "";
            Children.Add(child);
        }
        
        public static bool IsPrimitiveType(object o)
        {
            if (o is bool | o is byte | o is sbyte | o is char | o is decimal
                | o is double | o is float | o is int | o is uint | o is nint
                | o is nuint | o is long | o is ulong | o is short | o is ushort
                | o is ushort | o is string | o is Enum | o is string)
            {
                return true;
            }
            
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
                o = "Exception thrown getting " + propName + " " + ex.Message;
            }
            
            return o;
        }
        
        public bool HasChildren()
        {
            return Children.Count > 0;
        }
    }
}