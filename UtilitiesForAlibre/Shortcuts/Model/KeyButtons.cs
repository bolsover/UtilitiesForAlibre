using System.Collections.Generic;
using System.Drawing;
using Bolsover.Shortcuts.View;

namespace Bolsover.Shortcuts.Model
{
    public class KeyButtons
    {
        private readonly KeyboardControl _view;
        private Dictionary<string, ShortcutButton> _buttonDictionary;
        private static KeyButtons _instance;

        private KeyButtons(KeyboardControl view)
        {
            _view = view;
            InitButtonDictionary();
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
            Dictionary<string, ShortcutButton> temp = new Dictionary<string, ShortcutButton>(GetInstance(view)._buttonDictionary);
           
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
            foreach (ShortcutButton button in buttons)
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

        public ShortcutButton PrintScreenKey
        {
            get => _view.PrintScreenKey;
        }

        public ShortcutButton ScrollLockKey
        {
            get => _view.ScrollLockKey;
        }

        public ShortcutButton PauseBreakKey
        {
            get => _view.PauseBreakKey;
        }

        public ShortcutButton InsertKey
        {
            get => _view.InsertKey;
        }

        public ShortcutButton HomeKey
        {
            get => _view.HomeKey;
        }

        public ShortcutButton PageUpKey
        {
            get => _view.PageUpKey;
        }

        public ShortcutButton DeleteKey
        {
            get => _view.DeleteKey;
        }

        public ShortcutButton EndKey
        {
            get => _view.EndKey;
        }

        public ShortcutButton PageDownKey
        {
            get => _view.PageDownKey;
        }

        public ShortcutButton UpKey
        {
            get => _view.UpKey;
        }

        public ShortcutButton LeftKey
        {
            get => _view.LeftKey;
        }

        public ShortcutButton DownKey
        {
            get => _view.DownKey;
        }

        public ShortcutButton RightKey
        {
            get => _view.RightKey;
        }

        public ShortcutButton F1Key
        {
            get => _view.F1Key;
        }

        public ShortcutButton F2Key
        {
            get => _view.F2Key;
        }

        public ShortcutButton F3Key
        {
            get => _view.F3Key;
        }

        public ShortcutButton F4Key
        {
            get => _view.F4Key;
        }

        public ShortcutButton F5Key
        {
            get => _view.F5Key;
        }

        public ShortcutButton F6Key
        {
            get => _view.F6Key;
        }

        public ShortcutButton F7Key
        {
            get => _view.F7Key;
        }

        public ShortcutButton F8Key
        {
            get => _view.F8Key;
        }

        public ShortcutButton F9Key
        {
            get => _view.F9Key;
        }

        public ShortcutButton F10Key
        {
            get => _view.F10Key;
        }

        public ShortcutButton F11Key
        {
            get => _view.F11Key;
        }

        public ShortcutButton F12Key
        {
            get => _view.F12Key;
        }

        public ShortcutButton EscapeKey
        {
            get => _view.EscapeKey;
        }

        public ShortcutButton HashKey
        {
            get => _view.HashKey;
        }

        public ShortcutButton LeftCtrlKey
        {
            get => _view.LeftCtrlKey;
        }

        public ShortcutButton QKey
        {
            get => _view.QKey;
        }

        public ShortcutButton WKey
        {
            get => _view.WKey;
        }

        public ShortcutButton EKey
        {
            get => _view.EKey;
        }

        public ShortcutButton RKey
        {
            get => _view.RKey;
        }

        public ShortcutButton TKey
        {
            get => _view.TKey;
        }

        public ShortcutButton YKey
        {
            get => _view.YKey;
        }

        public ShortcutButton RightBracketKey
        {
            get => _view.RightBracketKey;
        }

        public ShortcutButton LeftBracketKey
        {
            get => _view.LeftBracketKey;
        }

        public ShortcutButton PKey
        {
            get => _view.PKey;
        }

        public ShortcutButton OKey
        {
            get => _view.OKey;
        }

        public ShortcutButton IKey
        {
            get => _view.IKey;
        }

        public ShortcutButton UKey
        {
            get => _view.UKey;
        }

        public ShortcutButton TabKey
        {
            get => _view.TabKey;
        }

        public ShortcutButton ApostropheKey
        {
            get => _view.ApostropheKey;
        }

        public ShortcutButton SemicolonKey
        {
            get => _view.SemicolonKey;
        }

        public ShortcutButton LKey
        {
            get => _view.LKey;
        }

        public ShortcutButton KKey
        {
            get => _view.KKey;
        }

        public ShortcutButton JKey
        {
            get => _view.JKey;
        }

        public ShortcutButton HKey
        {
            get => _view.HKey;
        }

        public ShortcutButton GKey
        {
            get => _view.GKey;
        }

        public ShortcutButton FKey
        {
            get => _view.FKey;
        }

        public ShortcutButton DKey
        {
            get => _view.DKey;
        }

        public ShortcutButton SKey
        {
            get => _view.SKey;
        }

        public ShortcutButton AKey
        {
            get => _view.AKey;
        }

        public ShortcutButton SlashKey
        {
            get => _view.SlashKey;
        }

        public ShortcutButton PeriodKey
        {
            get => _view.PeriodKey;
        }

        public ShortcutButton CommaKey
        {
            get => _view.CommaKey;
        }

        public ShortcutButton MKey
        {
            get => _view.MKey;
        }

        public ShortcutButton NKey
        {
            get => _view.NKey;
        }

        public ShortcutButton BKey
        {
            get => _view.BKey;
        }

        public ShortcutButton VKey
        {
            get => _view.VKey;
        }

        public ShortcutButton CKey
        {
            get => _view.CKey;
        }

        public ShortcutButton XKey
        {
            get => _view.XKey;
        }

        public ShortcutButton ZKey
        {
            get => _view.ZKey;
        }

        public ShortcutButton CapsLockKey
        {
            get => _view.CapsLockKey;
        }

        public ShortcutButton LeftShiftKey
        {
            get => _view.LeftShiftKey;
        }

        public ShortcutButton BackslashKey
        {
            get => _view.BackslashKey;
        }

        public ShortcutButton RightShiftKey
        {
            get => _view.RightShiftKey;
        }

        public ShortcutButton BackspaceKey
        {
            get => _view.BackspaceKey;
        }

        public ShortcutButton EnterKey
        {
            get => _view.EnterKey;
        }

        public ShortcutButton GraveKey
        {
            get => _view.GraveKey;
        }

        public ShortcutButton ZeroKey
        {
            get => _view.ZeroKey;
        }

        public ShortcutButton NineKey
        {
            get => _view.NineKey;
        }

        public ShortcutButton EightKey
        {
            get => _view.EightKey;
        }

        public ShortcutButton SixKey
        {
            get => _view.SixKey;
        }

        public ShortcutButton FiveKey
        {
            get => _view.FiveKey;
        }

        public ShortcutButton FourKey
        {
            get => _view.FourKey;
        }

        public ShortcutButton ThreeKey
        {
            get => _view.ThreeKey;
        }

        public ShortcutButton TwoKey
        {
            get => _view.TwoKey;
        }

        public ShortcutButton OneKey
        {
            get => _view.OneKey;
        }

        public ShortcutButton SevenKey
        {
            get => _view.SevenKey;
        }

        public ShortcutButton EqualKey
        {
            get => _view.EqualKey;
        }

        public ShortcutButton MinusKey
        {
            get => _view.MinusKey;
        }

        public ShortcutButton Num4Key
        {
            get => _view.Num4Key;
        }

        public ShortcutButton Num5Key
        {
            get => _view.Num5Key;
        }

        public ShortcutButton Num6Key
        {
            get => _view.Num6Key;
        }

        public ShortcutButton Num9Key
        {
            get => _view.Num9Key;
        }

        public ShortcutButton Num8Key
        {
            get => _view.Num8Key;
        }

        public ShortcutButton Num7Key
        {
            get => _view.Num7Key;
        }

        public ShortcutButton NumDecimalKey
        {
            get => _view.NumDecimalKey;
        }

        public ShortcutButton Num0Key
        {
            get => _view.Num0Key;
        }

        public ShortcutButton Num3Key
        {
            get => _view.Num3Key;
        }

        public ShortcutButton Num2Key
        {
            get => _view.Num2Key;
        }

        public ShortcutButton Num1Key
        {
            get => _view.Num1Key;
        }

        public ShortcutButton NumMultiplyKey
        {
            get => _view.NumMultiplyKey;
        }

        public ShortcutButton NumDivideKey
        {
            get => _view.NumDivideKey;
        }

        public ShortcutButton NumMinusKey
        {
            get => _view.NumMinusKey;
        }

        public ShortcutButton NumPlusKey
        {
            get => _view.NumPlusKey;
        }

        public ShortcutButton NumEnterKey
        {
            get => _view.NumEnterKey;
        }

        public ShortcutButton SpaceKey
        {
            get => _view.SpaceKey;
        }

        public ShortcutButton WindowKey
        {
            get => _view.WindowKey;
        }

        public ShortcutButton FnKey
        {
            get => _view.FnKey;
        }

        public ShortcutButton LeftAltKey
        {
            get => _view.LeftAltKey;
        }

        public ShortcutButton RightCtrlKey
        {
            get => _view.RightCtrlKey;
        }

        public ShortcutButton AltGrKey
        {
            get => _view.AltGrKey;
        }

        public ShortcutButton NumLockKey
        {
            get => _view.NumLockKey;
        }
    }
}