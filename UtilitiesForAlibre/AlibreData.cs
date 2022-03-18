using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using AlibreX;
using com.alibre.automation;


namespace Bolsover
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
                    int i = 0;
                    while (((EnumVariant)parent).HasMoreElements())
                    {
                        Object entry = ((EnumVariant) parent).NextElement();
                            
                        AlibreData child = new AlibreData(parent);
                        child.PropertyName = "Entry " + i++;
                        child.ClassType = entry.GetType().Name;
                        child.PropertyValue = IsPrimitiveType(entry) ? entry : "";

                        child.Value = entry;
                        children.Add(child);
                    }
                    
                }
                
                else if (parent is ArrayList)
                {
                    int i = 0;
                    foreach (var o in (ArrayList)parent)
                    {
                        AlibreData child = new AlibreData(parent);
                        child.PropertyName = "Entry " + i++;
                        child.ClassType = 0.GetType().Name;
                        child.Value = o;
                        child.PropertyValue = IsPrimitiveType(o) ? o : "";
                        children.Add(child);
                    }
                }
                else if (parent is IEnumerable)
                {
                    int i = 0;
                    foreach (var o in (IEnumerable)parent)
                    {
                        AlibreData child = new AlibreData(parent);
                        child.PropertyName = "Entry " + i++;
                        child.ClassType = o.GetType().Name;
                        child.Value = o;
                        child.PropertyValue = IsPrimitiveType(o) ? o : "";
                        children.Add(child);
                    }
                } else {
                
                
                var infos = parent.GetType().GetProperties();
                for (int i = 0; i < infos.Length; i++)
                {
                    AlibreData child = new AlibreData(parent);
                    PropertyInfo info = infos[i];
                    child.PropertyName = info.Name;
                    child.ClassType = info.PropertyType.Name;
                    child.Value = GetPropertyValue(parent, info.Name);
                    child.PropertyValue = IsPrimitiveType(GetPropertyValue(parent, info.Name)) ? GetPropertyValue(parent, info.Name) : "";
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

        public static bool IsPrimitiveType(object o)
        {
            if (o is bool | o is byte | o is sbyte | o is char | o is decimal 
                | o is double | o is float | o is int | o is uint | o is nint
                | o is nuint | o is long | o is ulong | o is short | o is ushort
                | o is ushort | o is string | o is Enum )
                return true;
            return false;
        }
        
       
        
        public object GetPropertyValue(object obj, string propName)
        {

            Object o = null;
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


        public String ClassType
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
            get =>  propertyValue;
            set => this. propertyValue = value;
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