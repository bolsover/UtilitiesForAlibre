using System.Configuration;
using System.Diagnostics;
using System.Drawing;

namespace UtilitiesForAlibre.Properties
{
    public abstract class Properties
    {
        internal sealed class Settings : ApplicationSettingsBase
        {
            public static Settings Default { get; } = (Settings) Synchronized(new Settings());
            
            
            [UserScopedSetting]
            
            [DefaultSettingValue("Red")]
            public Color CtrlAltShiftColor
            {
                get => (Color) this["CtrlAltShiftColor"];
                set => this["CtrlAltShiftColor"] = value;
            }
            
            [UserScopedSetting]
            
            [DefaultSettingValue("Gold")]
            public Color CtrlShiftColor
            {
                get => (Color) this["CtrlShiftColor"];
                set => this["CtrlShiftColor"] = value;
            }
            
            [UserScopedSetting]
            
            [DefaultSettingValue("Orange")]
            public Color CtrlAltColor
            {
                get => (Color) this["CtrlAltColor"];
                set => this["CtrlAltColor"] = value;
            }
            
            [UserScopedSetting]
            
            [DefaultSettingValue("Chartreuse")]
            public Color AltShiftColor
            {
                get => (Color) this["AltShiftColor"];
                set => this["AltShiftColor"] = value;
            }
            
            [UserScopedSetting]
            
            [DefaultSettingValue("CornflowerBlue")]
            public Color CtrlColor
            {
                get => (Color) this["CtrlColor"];
                set => this["CtrlColor"] = value;
            }
            
            [UserScopedSetting]
           
            [DefaultSettingValue("MediumOrchid")]
            public Color AltColor
            {
                get => (Color) this["AltColor"];
                set => this["AltColor"] = value;
            }
            
            [UserScopedSetting]
            
            [DefaultSettingValue("Violet")]
            public Color ShiftColor
            {
                get => (Color) this["ShiftColor"];
                set => this["ShiftColor"] = value;
            }
            
            [UserScopedSetting]
           
            [DefaultSettingValue("Bisque")]
            public Color NoModifierColor
            {
                get => (Color) this["NoModifierColor"];
                set => this["NoModifierColor"] = value;
            }
            
            [UserScopedSetting]
            
            [DefaultSettingValue("Bisque")]
            public Color ModifierKeyColor
            {
                get => (Color) this["ModifierKeyColor"];
                set => this["ModifierKeyColor"] = value;
            }
            
            [UserScopedSetting]
           
            [DefaultSettingValue("Black")]
            public Color TextColor
            {
                get => (Color) this["TextColor"];
                set => this["TextColor"] = value;
            }
            
            [UserScopedSetting]
           
            [DefaultSettingValue("9")]
            public short KeyTextSize
            {
                get => (short) this["KeyTextSize"];
                set => this["KeyTextSize"] = value;
            }
            
            [UserScopedSetting]
           
            [DefaultSettingValue("1.0")]
            public double AlibreIcon
            {
                get => (double) this["AlibreIcon"];
                set => this["AlibreIcon"] = value;
            }
            
            [UserScopedSetting]
            
            [DefaultSettingValue("13")]
            public short HintTextSize
            {
                get => (short) this["HintTextSize"];
                set => this["HintTextSize"] = value;
            }
        }
    }
}