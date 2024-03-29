namespace UtilitiesForAlibre.Properties
{
    public abstract class Properties
    {
        internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
        {
            private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

            public static Settings Default
            {
                get
                {
                    return defaultInstance;
                }
            }
            
          

            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("Red")]
            public global::System.Drawing.Color CtrlAltShiftColor
            {
                get
                {
                    return ((global::System.Drawing.Color)(this["CtrlAltShiftColor"]));
                }
                set
                {
                    this["CtrlAltShiftColor"] = value;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("Gold")]
            public global::System.Drawing.Color CtrlShiftColor
            {
                get
                {
                    return ((global::System.Drawing.Color)(this["CtrlShiftColor"]));
                }
                set
                {
                    this["CtrlShiftColor"] = value;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("Orange")]
            public global::System.Drawing.Color CtrlAltColor
            {
                get
                {
                    return ((global::System.Drawing.Color)(this["CtrlAltColor"]));
                }
                set
                {
                    this["CtrlAltColor"] = value;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("Chartreuse")]
            public global::System.Drawing.Color AltShiftColor
            {
                get
                {
                    return ((global::System.Drawing.Color)(this["AltShiftColor"]));
                }
                set
                {
                    this["AltShiftColor"] = value;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("CornflowerBlue")]
            public global::System.Drawing.Color CtrlColor
            {
                get
                {
                    return ((global::System.Drawing.Color)(this["CtrlColor"]));
                }
                set
                {
                    this["CtrlColor"] = value;
                }
            } 
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("MediumOrchid")]
            public global::System.Drawing.Color AltColor
            {
                get
                {
                    return ((global::System.Drawing.Color)(this["AltColor"]));
                }
                set
                {
                    this["AltColor"] = value;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("Violet")]
            public global::System.Drawing.Color ShiftColor
            {
                get
                {
                    return ((global::System.Drawing.Color)(this["ShiftColor"]));
                }
                set
                {
                    this["ShiftColor"] = value;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("Bisque")]
            public global::System.Drawing.Color NoModifierColor
            {
                get
                {
                    return ((global::System.Drawing.Color)(this["NoModifierColor"]));
                }
                set
                {
                    this["NoModifierColor"] = value;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("Bisque")]
            public global::System.Drawing.Color ModifierKeyColor
            {
                get
                {
                    return ((global::System.Drawing.Color)(this["ModifierKeyColor"]));
                }
                set
                {
                    this["ModifierKeyColor"] = value;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("Black")]
            public global::System.Drawing.Color TextColor {
                get {
                    return ((global::System.Drawing.Color)(this["TextColor"]));
                }
                set {
                    this["TextColor"] = value;
                }
            }
        
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("9")]
            public short KeyTextSize {
                get {
                    return ((short)(this["KeyTextSize"]));
                }
                set {
                    this["KeyTextSize"] = value;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("0.6")]
            public double AlibreIcon {
                get {
                    return ((double)(this["AlibreIcon"]));
                }
                set {
                    this["AlibreIcon"] = value;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("13")]
            public short HintTextSize {
                get {
                    return ((short)(this["HintTextSize"]));
                }
                set {
                    this["HintTextSize"] = value;
                }
            }
        }
    }
}