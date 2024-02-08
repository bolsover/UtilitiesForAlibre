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

        private ShortcutButton PrintScreenKey => _view.PrintScreenKey;

        private ShortcutButton ScrollLockKey => _view.ScrollLockKey;

        private ShortcutButton PauseBreakKey => _view.PauseBreakKey;

        private ShortcutButton InsertKey => _view.InsertKey;

        private ShortcutButton HomeKey => _view.HomeKey;

        private ShortcutButton PageUpKey => _view.PageUpKey;

        private ShortcutButton DeleteKey => _view.DeleteKey;

        private ShortcutButton EndKey => _view.EndKey;

        private ShortcutButton PageDownKey => _view.PageDownKey;

        private ShortcutButton UpKey => _view.UpKey;

        private ShortcutButton LeftKey => _view.LeftKey;

        private ShortcutButton DownKey => _view.DownKey;

        private ShortcutButton RightKey => _view.RightKey;

        private ShortcutButton F1Key => _view.F1Key;

        private ShortcutButton F2Key => _view.F2Key;

        private ShortcutButton F3Key => _view.F3Key;

        private ShortcutButton F4Key => _view.F4Key;

        private ShortcutButton F5Key => _view.F5Key;

        private ShortcutButton F6Key => _view.F6Key;

        private ShortcutButton F7Key => _view.F7Key;

        private ShortcutButton F8Key => _view.F8Key;

        private ShortcutButton F9Key => _view.F9Key;

        private ShortcutButton F10Key => _view.F10Key;

        private ShortcutButton F11Key => _view.F11Key;

        private ShortcutButton F12Key => _view.F12Key;

        private ShortcutButton EscapeKey => _view.EscapeKey;

        private ShortcutButton HashKey => _view.HashKey;

        private ShortcutButton LeftCtrlKey => _view.LeftCtrlKey;

        private ShortcutButton QKey => _view.QKey;

        private ShortcutButton WKey => _view.WKey;

        private ShortcutButton EKey => _view.EKey;

        private ShortcutButton RKey => _view.RKey;

        private ShortcutButton TKey => _view.TKey;

        private ShortcutButton YKey => _view.YKey;

        private ShortcutButton RightBracketKey => _view.RightBracketKey;

        private ShortcutButton LeftBracketKey => _view.LeftBracketKey;

        private ShortcutButton PKey => _view.PKey;

        private ShortcutButton OKey => _view.OKey;

        private ShortcutButton IKey => _view.IKey;

        private ShortcutButton UKey => _view.UKey;

        private ShortcutButton TabKey => _view.TabKey;

        private ShortcutButton ApostropheKey => _view.ApostropheKey;

        private ShortcutButton SemicolonKey => _view.SemicolonKey;

        private ShortcutButton LKey => _view.LKey;

        private ShortcutButton KKey => _view.KKey;

        private ShortcutButton JKey => _view.JKey;

        private ShortcutButton HKey => _view.HKey;

        private ShortcutButton GKey => _view.GKey;

        private ShortcutButton FKey => _view.FKey;

        private ShortcutButton DKey => _view.DKey;

        private ShortcutButton SKey => _view.SKey;

        private ShortcutButton AKey => _view.AKey;

        private ShortcutButton SlashKey => _view.SlashKey;

        private ShortcutButton PeriodKey => _view.PeriodKey;

        private ShortcutButton CommaKey => _view.CommaKey;

        private ShortcutButton MKey => _view.MKey;

        private ShortcutButton NKey => _view.NKey;

        private ShortcutButton BKey => _view.BKey;

        private ShortcutButton VKey => _view.VKey;

        private ShortcutButton CKey => _view.CKey;

        private ShortcutButton XKey => _view.XKey;

        private ShortcutButton ZKey => _view.ZKey;

        private ShortcutButton CapsLockKey => _view.CapsLockKey;

        private ShortcutButton LeftShiftKey => _view.LeftShiftKey;

        private ShortcutButton BackslashKey => _view.BackslashKey;

        private ShortcutButton RightShiftKey => _view.RightShiftKey;

        private ShortcutButton BackspaceKey => _view.BackspaceKey;

        private ShortcutButton EnterKey => _view.EnterKey;

        private ShortcutButton GraveKey => _view.GraveKey;

        private ShortcutButton ZeroKey => _view.ZeroKey;

        private ShortcutButton NineKey => _view.NineKey;

        private ShortcutButton EightKey => _view.EightKey;

        private ShortcutButton SixKey => _view.SixKey;

        private ShortcutButton FiveKey => _view.FiveKey;

        private ShortcutButton FourKey => _view.FourKey;

        private ShortcutButton ThreeKey => _view.ThreeKey;

        private ShortcutButton TwoKey => _view.TwoKey;

        private ShortcutButton OneKey => _view.OneKey;

        private ShortcutButton SevenKey => _view.SevenKey;

        private ShortcutButton EqualKey => _view.EqualKey;

        private ShortcutButton MinusKey => _view.MinusKey;

        private ShortcutButton Num4Key => _view.Num4Key;

        private ShortcutButton Num5Key => _view.Num5Key;

        private ShortcutButton Num6Key => _view.Num6Key;

        private ShortcutButton Num9Key => _view.Num9Key;

        private ShortcutButton Num8Key => _view.Num8Key;

        private ShortcutButton Num7Key => _view.Num7Key;

        private ShortcutButton NumDecimalKey => _view.NumDecimalKey;

        private ShortcutButton Num0Key => _view.Num0Key;

        private ShortcutButton Num3Key => _view.Num3Key;

        private ShortcutButton Num2Key => _view.Num2Key;

        private ShortcutButton Num1Key => _view.Num1Key;

        private ShortcutButton NumMultiplyKey => _view.NumMultiplyKey;

        private ShortcutButton NumDivideKey => _view.NumDivideKey;

        private ShortcutButton NumMinusKey => _view.NumMinusKey;

        private ShortcutButton NumPlusKey => _view.NumPlusKey;

        private ShortcutButton NumEnterKey => _view.NumEnterKey;

        private ShortcutButton SpaceKey => _view.SpaceKey;

        private ShortcutButton WindowKey => _view.WindowKey;

        private ShortcutButton FnKey => _view.FnKey;

        private ShortcutButton LeftAltKey => _view.LeftAltKey;

        private ShortcutButton RightCtrlKey => _view.RightCtrlKey;

        private ShortcutButton AltGrKey => _view.AltGrKey;

        private ShortcutButton NumLockKey => _view.NumLockKey;
    }
}