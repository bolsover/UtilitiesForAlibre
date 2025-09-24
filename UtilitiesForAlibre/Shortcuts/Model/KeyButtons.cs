using System.Collections.Generic;
using System.Drawing;
using Bolsover.Shortcuts.View;

namespace Bolsover.Shortcuts.Model
{
    public class KeyButtons
    {
        private static KeyButtons _instance;
        private readonly KeyboardControl _view;
        private Dictionary<string, ShortcutButton> _buttonDictionary;
        
        private KeyButtons(KeyboardControl view)
        {
            _view = view;
            InitButtonDictionary();
        }
        
        private ShortcutButton PrintScreenKey
        {
            get => _view.PrintScreenKey;
        }
        
        private ShortcutButton ScrollLockKey
        {
            get => _view.ScrollLockKey;
        }
        
        private ShortcutButton PauseBreakKey
        {
            get => _view.PauseBreakKey;
        }
        
        private ShortcutButton InsertKey
        {
            get => _view.InsertKey;
        }
        
        private ShortcutButton HomeKey
        {
            get => _view.HomeKey;
        }
        
        private ShortcutButton PageUpKey
        {
            get => _view.PageUpKey;
        }
        
        private ShortcutButton DeleteKey
        {
            get => _view.DeleteKey;
        }
        
        private ShortcutButton EndKey
        {
            get => _view.EndKey;
        }
        
        private ShortcutButton PageDownKey
        {
            get => _view.PageDownKey;
        }
        
        private ShortcutButton UpKey
        {
            get => _view.UpKey;
        }
        
        private ShortcutButton LeftKey
        {
            get => _view.LeftKey;
        }
        
        private ShortcutButton DownKey
        {
            get => _view.DownKey;
        }
        
        private ShortcutButton RightKey
        {
            get => _view.RightKey;
        }
        
        private ShortcutButton F1Key
        {
            get => _view.F1Key;
        }
        
        private ShortcutButton F2Key
        {
            get => _view.F2Key;
        }
        
        private ShortcutButton F3Key
        {
            get => _view.F3Key;
        }
        
        private ShortcutButton F4Key
        {
            get => _view.F4Key;
        }
        
        private ShortcutButton F5Key
        {
            get => _view.F5Key;
        }
        
        private ShortcutButton F6Key
        {
            get => _view.F6Key;
        }
        
        private ShortcutButton F7Key
        {
            get => _view.F7Key;
        }
        
        private ShortcutButton F8Key
        {
            get => _view.F8Key;
        }
        
        private ShortcutButton F9Key
        {
            get => _view.F9Key;
        }
        
        private ShortcutButton F10Key
        {
            get => _view.F10Key;
        }
        
        private ShortcutButton F11Key
        {
            get => _view.F11Key;
        }
        
        private ShortcutButton F12Key
        {
            get => _view.F12Key;
        }
        
        private ShortcutButton EscapeKey
        {
            get => _view.EscapeKey;
        }
        
        private ShortcutButton HashKey
        {
            get => _view.HashKey;
        }
        
        private ShortcutButton LeftCtrlKey
        {
            get => _view.LeftCtrlKey;
        }
        
        private ShortcutButton QKey
        {
            get => _view.QKey;
        }
        
        private ShortcutButton WKey
        {
            get => _view.WKey;
        }
        
        private ShortcutButton EKey
        {
            get => _view.EKey;
        }
        
        private ShortcutButton RKey
        {
            get => _view.RKey;
        }
        
        private ShortcutButton TKey
        {
            get => _view.TKey;
        }
        
        private ShortcutButton YKey
        {
            get => _view.YKey;
        }
        
        private ShortcutButton RightBracketKey
        {
            get => _view.RightBracketKey;
        }
        
        private ShortcutButton LeftBracketKey
        {
            get => _view.LeftBracketKey;
        }
        
        private ShortcutButton PKey
        {
            get => _view.PKey;
        }
        
        private ShortcutButton OKey
        {
            get => _view.OKey;
        }
        
        private ShortcutButton IKey
        {
            get => _view.IKey;
        }
        
        private ShortcutButton UKey
        {
            get => _view.UKey;
        }
        
        private ShortcutButton TabKey
        {
            get => _view.TabKey;
        }
        
        private ShortcutButton ApostropheKey
        {
            get => _view.ApostropheKey;
        }
        
        private ShortcutButton SemicolonKey
        {
            get => _view.SemicolonKey;
        }
        
        private ShortcutButton LKey
        {
            get => _view.LKey;
        }
        
        private ShortcutButton KKey
        {
            get => _view.KKey;
        }
        
        private ShortcutButton JKey
        {
            get => _view.JKey;
        }
        
        private ShortcutButton HKey
        {
            get => _view.HKey;
        }
        
        private ShortcutButton GKey
        {
            get => _view.GKey;
        }
        
        private ShortcutButton FKey
        {
            get => _view.FKey;
        }
        
        private ShortcutButton DKey
        {
            get => _view.DKey;
        }
        
        private ShortcutButton SKey
        {
            get => _view.SKey;
        }
        
        private ShortcutButton AKey
        {
            get => _view.AKey;
        }
        
        private ShortcutButton SlashKey
        {
            get => _view.SlashKey;
        }
        
        private ShortcutButton PeriodKey
        {
            get => _view.PeriodKey;
        }
        
        private ShortcutButton CommaKey
        {
            get => _view.CommaKey;
        }
        
        private ShortcutButton MKey
        {
            get => _view.MKey;
        }
        
        private ShortcutButton NKey
        {
            get => _view.NKey;
        }
        
        private ShortcutButton BKey
        {
            get => _view.BKey;
        }
        
        private ShortcutButton VKey
        {
            get => _view.VKey;
        }
        
        private ShortcutButton CKey
        {
            get => _view.CKey;
        }
        
        private ShortcutButton XKey
        {
            get => _view.XKey;
        }
        
        private ShortcutButton ZKey
        {
            get => _view.ZKey;
        }
        
        private ShortcutButton CapsLockKey
        {
            get => _view.CapsLockKey;
        }
        
        private ShortcutButton LeftShiftKey
        {
            get => _view.LeftShiftKey;
        }
        
        private ShortcutButton BackslashKey
        {
            get => _view.BackslashKey;
        }
        
        private ShortcutButton RightShiftKey
        {
            get => _view.RightShiftKey;
        }
        
        private ShortcutButton BackspaceKey
        {
            get => _view.BackspaceKey;
        }
        
        private ShortcutButton EnterKey
        {
            get => _view.EnterKey;
        }
        
        private ShortcutButton GraveKey
        {
            get => _view.GraveKey;
        }
        
        private ShortcutButton ZeroKey
        {
            get => _view.ZeroKey;
        }
        
        private ShortcutButton NineKey
        {
            get => _view.NineKey;
        }
        
        private ShortcutButton EightKey
        {
            get => _view.EightKey;
        }
        
        private ShortcutButton SixKey
        {
            get => _view.SixKey;
        }
        
        private ShortcutButton FiveKey
        {
            get => _view.FiveKey;
        }
        
        private ShortcutButton FourKey
        {
            get => _view.FourKey;
        }
        
        private ShortcutButton ThreeKey
        {
            get => _view.ThreeKey;
        }
        
        private ShortcutButton TwoKey
        {
            get => _view.TwoKey;
        }
        
        private ShortcutButton OneKey
        {
            get => _view.OneKey;
        }
        
        private ShortcutButton SevenKey
        {
            get => _view.SevenKey;
        }
        
        private ShortcutButton EqualKey
        {
            get => _view.EqualKey;
        }
        
        private ShortcutButton MinusKey
        {
            get => _view.MinusKey;
        }
        
        private ShortcutButton Num4Key
        {
            get => _view.Num4Key;
        }
        
        private ShortcutButton Num5Key
        {
            get => _view.Num5Key;
        }
        
        private ShortcutButton Num6Key
        {
            get => _view.Num6Key;
        }
        
        private ShortcutButton Num9Key
        {
            get => _view.Num9Key;
        }
        
        private ShortcutButton Num8Key
        {
            get => _view.Num8Key;
        }
        
        private ShortcutButton Num7Key
        {
            get => _view.Num7Key;
        }
        
        private ShortcutButton NumDecimalKey
        {
            get => _view.NumDecimalKey;
        }
        
        private ShortcutButton Num0Key
        {
            get => _view.Num0Key;
        }
        
        private ShortcutButton Num3Key
        {
            get => _view.Num3Key;
        }
        
        private ShortcutButton Num2Key
        {
            get => _view.Num2Key;
        }
        
        private ShortcutButton Num1Key
        {
            get => _view.Num1Key;
        }
        
        private ShortcutButton NumMultiplyKey
        {
            get => _view.NumMultiplyKey;
        }
        
        private ShortcutButton NumDivideKey
        {
            get => _view.NumDivideKey;
        }
        
        private ShortcutButton NumMinusKey
        {
            get => _view.NumMinusKey;
        }
        
        private ShortcutButton NumPlusKey
        {
            get => _view.NumPlusKey;
        }
        
        private ShortcutButton NumEnterKey
        {
            get => _view.NumEnterKey;
        }
        
        private ShortcutButton SpaceKey
        {
            get => _view.SpaceKey;
        }
        
        private ShortcutButton WindowKey
        {
            get => _view.WindowKey;
        }
        
        private ShortcutButton FnKey
        {
            get => _view.FnKey;
        }
        
        private ShortcutButton LeftAltKey
        {
            get => _view.LeftAltKey;
        }
        
        private ShortcutButton RightCtrlKey
        {
            get => _view.RightCtrlKey;
        }
        
        private ShortcutButton AltGrKey
        {
            get => _view.AltGrKey;
        }
        
        private ShortcutButton NumLockKey
        {
            get => _view.NumLockKey;
        }
        
        private static KeyButtons GetInstance(KeyboardControl view)
        {
            if (_instance == null)
            {
                _instance = new KeyButtons(view);
            }
            
            return _instance;
        }
        
        public static ShortcutButton GetButton(KeyboardControl view, string key)
        {
            return GetInstance(view)._buttonDictionary[key];
        }
        
        public static Dictionary<string, ShortcutButton> ButtonDictionary(KeyboardControl view)
        
        {
            return GetInstance(view)._buttonDictionary;
        }
        
        public static Dictionary<string, ShortcutButton> ButtonDictionaryExcModifiers(KeyboardControl view)
        
        {
            var temp = new Dictionary<string, ShortcutButton>(GetInstance(view)._buttonDictionary);
            
            temp.Remove("LeftCtrlKey");
            temp.Remove("RightCtrlKey");
            temp.Remove("LeftShiftKey");
            temp.Remove("RightShiftKey");
            temp.Remove("LeftAltKey");
            temp.Remove("AltGrKey");
            
            return temp;
        }
        
        public static List<ShortcutButton> CtrlButtons()
        {
            var ctrlButtons = new List<ShortcutButton>
            {
                _instance.LeftCtrlKey,
                _instance.RightCtrlKey
            };
            return ctrlButtons;
        }
        
        public static List<ShortcutButton> ShiftButtons()
        {
            var shiftButtons = new List<ShortcutButton>
            {
                _instance.LeftShiftKey,
                _instance.RightShiftKey
            };
            return shiftButtons;
        }
        
        public static List<ShortcutButton> AltButtons()
        {
            var altButtons = new List<ShortcutButton>
            {
                _instance.LeftAltKey,
                _instance.AltGrKey
            };
            return altButtons;
        }
        
        public static List<ShortcutButton> CtrlAltShiftButtons()
        {
            var modifierButtons = new List<ShortcutButton>();
            modifierButtons.AddRange(CtrlButtons());
            modifierButtons.AddRange(ShiftButtons());
            modifierButtons.AddRange(AltButtons());
            return modifierButtons;
        }
        
        public static List<ShortcutButton> CtrlAltButtons()
        {
            var modifierButtons = new List<ShortcutButton>();
            modifierButtons.AddRange(CtrlButtons());
            modifierButtons.AddRange(AltButtons());
            return modifierButtons;
        }
        
        public static List<ShortcutButton> CtrlShiftButtons()
        {
            var modifierButtons = new List<ShortcutButton>();
            modifierButtons.AddRange(CtrlButtons());
            modifierButtons.AddRange(ShiftButtons());
            return modifierButtons;
        }
        
        public static List<ShortcutButton> AltShiftButtons()
        {
            var modifierButtons = new List<ShortcutButton>();
            modifierButtons.AddRange(ShiftButtons());
            modifierButtons.AddRange(AltButtons());
            return modifierButtons;
        }
        
        public static void ApplyBackgroundColor(List<ShortcutButton> buttons, Color backColor)
        {
            foreach (var button in buttons)
            {
                button.BackColor = backColor;
            }
        }
        
        private void InitButtonDictionary()
        {
            _buttonDictionary = new Dictionary<string, ShortcutButton>();
            _buttonDictionary.Add("PrintScreenKey", PrintScreenKey);
            _buttonDictionary.Add("ScrollLockKey", ScrollLockKey);
            _buttonDictionary.Add("PauseBreakKey", PauseBreakKey);
            _buttonDictionary.Add("InsertKey", InsertKey);
            _buttonDictionary.Add("HomeKey", HomeKey);
            _buttonDictionary.Add("PageUpKey", PageUpKey);
            _buttonDictionary.Add("DeleteKey", DeleteKey);
            _buttonDictionary.Add("EndKey", EndKey);
            _buttonDictionary.Add("PageDownKey", PageDownKey);
            _buttonDictionary.Add("UpKey", UpKey);
            _buttonDictionary.Add("LeftKey", LeftKey);
            _buttonDictionary.Add("DownKey", DownKey);
            _buttonDictionary.Add("RightKey", RightKey);
            _buttonDictionary.Add("F1Key", F1Key);
            _buttonDictionary.Add("F2Key", F2Key);
            _buttonDictionary.Add("F3Key", F3Key);
            _buttonDictionary.Add("F4Key", F4Key);
            _buttonDictionary.Add("F5Key", F5Key);
            _buttonDictionary.Add("F6Key", F6Key);
            _buttonDictionary.Add("F7Key", F7Key);
            _buttonDictionary.Add("F8Key", F8Key);
            _buttonDictionary.Add("F9Key", F9Key);
            _buttonDictionary.Add("F10Key", F10Key);
            _buttonDictionary.Add("F11Key", F11Key);
            _buttonDictionary.Add("F12Key", F12Key);
            _buttonDictionary.Add("EscapeKey", EscapeKey);
            _buttonDictionary.Add("HashKey", HashKey);
            _buttonDictionary.Add("LeftCtrlKey", LeftCtrlKey);
            _buttonDictionary.Add("QKey", QKey);
            _buttonDictionary.Add("WKey", WKey);
            _buttonDictionary.Add("EKey", EKey);
            _buttonDictionary.Add("RKey", RKey);
            _buttonDictionary.Add("TKey", TKey);
            _buttonDictionary.Add("YKey", YKey);
            _buttonDictionary.Add("RightBracketKey", RightBracketKey);
            _buttonDictionary.Add("LeftBracketKey", LeftBracketKey);
            _buttonDictionary.Add("PKey", PKey);
            _buttonDictionary.Add("OKey", OKey);
            _buttonDictionary.Add("IKey", IKey);
            _buttonDictionary.Add("UKey", UKey);
            _buttonDictionary.Add("TabKey", TabKey);
            _buttonDictionary.Add("ApostropheKey", ApostropheKey);
            _buttonDictionary.Add("SemicolonKey", SemicolonKey);
            _buttonDictionary.Add("LKey", LKey);
            _buttonDictionary.Add("KKey", KKey);
            _buttonDictionary.Add("JKey", JKey);
            _buttonDictionary.Add("HKey", HKey);
            _buttonDictionary.Add("GKey", GKey);
            _buttonDictionary.Add("FKey", FKey);
            _buttonDictionary.Add("DKey", DKey);
            _buttonDictionary.Add("SKey", SKey);
            _buttonDictionary.Add("AKey", AKey);
            _buttonDictionary.Add("SlashKey", SlashKey);
            _buttonDictionary.Add("PeriodKey", PeriodKey);
            _buttonDictionary.Add("CommaKey", CommaKey);
            _buttonDictionary.Add("MKey", MKey);
            _buttonDictionary.Add("NKey", NKey);
            _buttonDictionary.Add("BKey", BKey);
            _buttonDictionary.Add("VKey", VKey);
            _buttonDictionary.Add("CKey", CKey);
            _buttonDictionary.Add("XKey", XKey);
            _buttonDictionary.Add("ZKey", ZKey);
            _buttonDictionary.Add("CapsLockKey", CapsLockKey);
            _buttonDictionary.Add("LeftShiftKey", LeftShiftKey);
            _buttonDictionary.Add("BackslashKey", BackslashKey);
            _buttonDictionary.Add("RightShiftKey", RightShiftKey);
            _buttonDictionary.Add("BackspaceKey", BackspaceKey);
            _buttonDictionary.Add("EnterKey", EnterKey);
            _buttonDictionary.Add("GraveKey", GraveKey);
            _buttonDictionary.Add("ZeroKey", ZeroKey);
            _buttonDictionary.Add("NineKey", NineKey);
            _buttonDictionary.Add("EightKey", EightKey);
            _buttonDictionary.Add("SixKey", SixKey);
            _buttonDictionary.Add("FiveKey", FiveKey);
            _buttonDictionary.Add("FourKey", FourKey);
            _buttonDictionary.Add("ThreeKey", ThreeKey);
            _buttonDictionary.Add("TwoKey", TwoKey);
            _buttonDictionary.Add("OneKey", OneKey);
            _buttonDictionary.Add("SevenKey", SevenKey);
            _buttonDictionary.Add("EqualKey", EqualKey);
            _buttonDictionary.Add("MinusKey", MinusKey);
            _buttonDictionary.Add("Num4Key", Num4Key);
            _buttonDictionary.Add("Num5Key", Num5Key);
            _buttonDictionary.Add("Num6Key", Num6Key);
            _buttonDictionary.Add("Num9Key", Num9Key);
            _buttonDictionary.Add("Num8Key", Num8Key);
            _buttonDictionary.Add("Num7Key", Num7Key);
            _buttonDictionary.Add("NumDecimalKey", NumDecimalKey);
            _buttonDictionary.Add("Num0Key", Num0Key);
            _buttonDictionary.Add("Num3Key", Num3Key);
            _buttonDictionary.Add("Num2Key", Num2Key);
            _buttonDictionary.Add("Num1Key", Num1Key);
            _buttonDictionary.Add("NumMultiplyKey", NumMultiplyKey);
            _buttonDictionary.Add("NumDivideKey", NumDivideKey);
            _buttonDictionary.Add("NumMinusKey", NumMinusKey);
            _buttonDictionary.Add("NumPlusKey", NumPlusKey);
            _buttonDictionary.Add("NumEnterKey", NumEnterKey);
            _buttonDictionary.Add("SpaceKey", SpaceKey);
            _buttonDictionary.Add("WindowKey", WindowKey);
            _buttonDictionary.Add("FnKey", FnKey);
            _buttonDictionary.Add("LeftAltKey", LeftAltKey);
            _buttonDictionary.Add("RightCtrlKey", RightCtrlKey);
            _buttonDictionary.Add("AltGrKey", AltGrKey);
            _buttonDictionary.Add("NumLockKey", NumLockKey);
        }
    }
}