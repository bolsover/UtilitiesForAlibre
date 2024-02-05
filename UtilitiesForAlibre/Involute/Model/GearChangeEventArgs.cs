using System;
using System.ComponentModel;

namespace Bolsover.Involute.Model
{
    public class GearChangeEventArgs: EventArgs
    {
        public readonly string Property;
        public readonly object Value;

        public GearChangeEventArgs(string property, object value)
        {
            Property = property;
            Value = value;
        }
    }
}