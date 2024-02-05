using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bolsover.Shortcuts.Model
{
    public class KeyCodes
    {
        public int KeyCode { get; private set; }
        public string KeyName { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public string KeyImage { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("KeyCode: " + KeyCode);
            sb.Append(" KeyName: " + KeyName);
            sb.Append(" Code: " + Code);
            sb.Append(" Description: " + Description);
            sb.Append(" KeyStrings: " + KeyImage);
            return sb.ToString();
        }

        

        public static Dictionary<int, KeyCodes> KeyCodesDictionaryByIndex() => new()
        {
            {8, new KeyCodes() {KeyCode = 8, KeyName = "BackspaceKey", Description = "Backspace", Code = "Backspace", KeyImage = KeyStrings.BackspaceKey}},
            {9, new KeyCodes() {KeyCode = 9, KeyName = "TabKey", Description = "Tab", Code = "Tab", KeyImage = KeyStrings.TabKey}},
            {13, new KeyCodes() {KeyCode = 13, KeyName = "EnterKey", Description = "Enter", Code = "Enter", KeyImage = KeyStrings.EnterKey}},
            {16, new KeyCodes() {KeyCode = 16, KeyName = "LeftShiftKey", Description = "LeftShift", Code = "LeftShift", KeyImage = KeyStrings.LeftShiftKey}},
            {17, new KeyCodes() {KeyCode = 17, KeyName = "RightCtrlKey", Description = "RightCtrl", Code = "RightCtrl", KeyImage = KeyStrings.RightCtrlKey}},
            // {13, new KeyCodes() { KeyCode = 13, KeyName = "NumEnterKey", Description = "NumpadEnter", Code = "NumpadEnter", KeyImage = KeyStrings.NumEnterKey } },
            // {16, new KeyCodes() { KeyCode = 16, KeyName = "RightShiftKey", Description = "RightShift", Code = "RightShift", KeyImage = KeyStrings.RightShiftKey } },
            // {17, new KeyCodes() { KeyCode = 17, KeyName = "LeftCtrlKey", Description = "LeftCtrl", Code = "LeftCtrl", KeyImage = KeyStrings.LeftCtrlKey } },
            // {18, new KeyCodes() {KeyCode = 18, KeyName = "AltGrKey", Description = "AltGr", Code = "AltGr", KeyImage = KeyStrings.AltGrKey}},
            {18, new KeyCodes() {KeyCode = 18, KeyName = "LeftAltKey", Description = "LeftAlt", Code = "LeftAlt", KeyImage = KeyStrings.LeftAltKey}},
            {19, new KeyCodes() {KeyCode = 19, KeyName = "PauseBreakKey", Description = "PauseBreak", Code = "PauseBreak", KeyImage = KeyStrings.PauseBreakKey}},
            {20, new KeyCodes() {KeyCode = 20, KeyName = "CapsLockKey", Description = "CapsLock", Code = "CapsLock", KeyImage = KeyStrings.CapsLockKey}},
            {27, new KeyCodes() {KeyCode = 27, KeyName = "EscapeKey", Description = "Escape", Code = "Escape", KeyImage = KeyStrings.EscapeKey}},
            {32, new KeyCodes() {KeyCode = 32, KeyName = "SpaceKey", Description = "Space", Code = "Space", KeyImage = KeyStrings.SpaceKey}},
            {33, new KeyCodes() {KeyCode = 33, KeyName = "PageUpKey", Description = "PageUp", Code = "PageUp", KeyImage = KeyStrings.PageUpKey}},
            {34, new KeyCodes() {KeyCode = 34, KeyName = "PageDownKey", Description = "PageDown", Code = "PageDown", KeyImage = KeyStrings.PageDownKey}},
            {35, new KeyCodes() {KeyCode = 35, KeyName = "EndKey", Description = "End", Code = "End", KeyImage = KeyStrings.EndKey}},
            {36, new KeyCodes() {KeyCode = 36, KeyName = "HomeKey", Description = "Home", Code = "Home", KeyImage = KeyStrings.HomeKey}},
            {37, new KeyCodes() {KeyCode = 37, KeyName = "LeftKey", Description = "Left", Code = "Left", KeyImage = KeyStrings.LeftKey}},
            {38, new KeyCodes() {KeyCode = 38, KeyName = "UpKey", Description = "Up", Code = "Up", KeyImage = KeyStrings.UpKey}},
            {39, new KeyCodes() {KeyCode = 39, KeyName = "RightKey", Description = "Right", Code = "Right", KeyImage = KeyStrings.RightKey}},
            {40, new KeyCodes() {KeyCode = 40, KeyName = "DownKey", Description = "Down", Code = "Down", KeyImage = KeyStrings.DownKey}},
            {44, new KeyCodes() {KeyCode = 44, KeyName = "PrintScreenKey", Description = "PrintScreen", Code = "PrintScreen", KeyImage = KeyStrings.PrintScreenKey}},
            {45, new KeyCodes() {KeyCode = 45, KeyName = "InsertKey", Description = "Insert", Code = "Insert", KeyImage = KeyStrings.InsertKey}},
            {46, new KeyCodes() {KeyCode = 46, KeyName = "DeleteKey", Description = "Delete", Code = "Delete", KeyImage = KeyStrings.DeleteKey}},
            {48, new KeyCodes() {KeyCode = 48, KeyName = "ZeroKey", Description = "Zero", Code = "Zero", KeyImage = KeyStrings.ZeroKey}},
            {49, new KeyCodes() {KeyCode = 49, KeyName = "OneKey", Description = "One", Code = "One", KeyImage = KeyStrings.OneKey}},
            {50, new KeyCodes() {KeyCode = 50, KeyName = "TwoKey", Description = "Two", Code = "Two", KeyImage = KeyStrings.TwoKey}},
            {51, new KeyCodes() {KeyCode = 51, KeyName = "ThreeKey", Description = "Three", Code = "Three", KeyImage = KeyStrings.ThreeKey}},
            {52, new KeyCodes() {KeyCode = 52, KeyName = "FourKey", Description = "Four", Code = "Four", KeyImage = KeyStrings.FourKey}},
            {53, new KeyCodes() {KeyCode = 53, KeyName = "FiveKey", Description = "Five", Code = "Five", KeyImage = KeyStrings.FiveKey}},
            {54, new KeyCodes() {KeyCode = 54, KeyName = "SixKey", Description = "Six", Code = "Six", KeyImage = KeyStrings.SixKey}},
            {55, new KeyCodes() {KeyCode = 55, KeyName = "SevenKey", Description = "Seven", Code = "Seven", KeyImage = KeyStrings.SevenKey}},
            {56, new KeyCodes() {KeyCode = 56, KeyName = "EightKey", Description = "Eight", Code = "Eight", KeyImage = KeyStrings.EightKey}},
            {57, new KeyCodes() {KeyCode = 57, KeyName = "NineKey", Description = "Nine", Code = "Nine", KeyImage = KeyStrings.NineKey}},
            {65, new KeyCodes() {KeyCode = 65, KeyName = "AKey", Description = "A", Code = "A", KeyImage = KeyStrings.AKey}},
            {66, new KeyCodes() {KeyCode = 66, KeyName = "BKey", Description = "B", Code = "B", KeyImage = KeyStrings.BKey}},
            {67, new KeyCodes() {KeyCode = 67, KeyName = "CKey", Description = "C", Code = "C", KeyImage = KeyStrings.CKey}},
            {68, new KeyCodes() {KeyCode = 68, KeyName = "DKey", Description = "D", Code = "D", KeyImage = KeyStrings.DKey}},
            {69, new KeyCodes() {KeyCode = 69, KeyName = "EKey", Description = "E", Code = "E", KeyImage = KeyStrings.EKey}},
            {70, new KeyCodes() {KeyCode = 70, KeyName = "FKey", Description = "F", Code = "F", KeyImage = KeyStrings.FKey}},
            {71, new KeyCodes() {KeyCode = 71, KeyName = "GKey", Description = "G", Code = "G", KeyImage = KeyStrings.GKey}},
            {72, new KeyCodes() {KeyCode = 72, KeyName = "HKey", Description = "H", Code = "H", KeyImage = KeyStrings.HKey}},
            {73, new KeyCodes() {KeyCode = 73, KeyName = "IKey", Description = "I", Code = "I", KeyImage = KeyStrings.IKey}},
            {74, new KeyCodes() {KeyCode = 74, KeyName = "JKey", Description = "J", Code = "J", KeyImage = KeyStrings.JKey}},
            {75, new KeyCodes() {KeyCode = 75, KeyName = "KKey", Description = "K", Code = "K", KeyImage = KeyStrings.KKey}},
            {76, new KeyCodes() {KeyCode = 76, KeyName = "LKey", Description = "L", Code = "L", KeyImage = KeyStrings.LKey}},
            {77, new KeyCodes() {KeyCode = 77, KeyName = "MKey", Description = "M", Code = "M", KeyImage = KeyStrings.MKey}},
            {78, new KeyCodes() {KeyCode = 78, KeyName = "NKey", Description = "N", Code = "N", KeyImage = KeyStrings.NKey}},
            {79, new KeyCodes() {KeyCode = 79, KeyName = "OKey", Description = "O", Code = "O", KeyImage = KeyStrings.OKey}},
            {80, new KeyCodes() {KeyCode = 80, KeyName = "PKey", Description = "P", Code = "P", KeyImage = KeyStrings.PKey}},
            {81, new KeyCodes() {KeyCode = 81, KeyName = "QKey", Description = "Q", Code = "Q", KeyImage = KeyStrings.QKey}},
            {82, new KeyCodes() {KeyCode = 82, KeyName = "RKey", Description = "R", Code = "R", KeyImage = KeyStrings.RKey}},
            {83, new KeyCodes() {KeyCode = 83, KeyName = "SKey", Description = "S", Code = "S", KeyImage = KeyStrings.SKey}},
            {84, new KeyCodes() {KeyCode = 84, KeyName = "TKey", Description = "T", Code = "T", KeyImage = KeyStrings.TKey}},
            {85, new KeyCodes() {KeyCode = 85, KeyName = "UKey", Description = "U", Code = "U", KeyImage = KeyStrings.UKey}},
            {86, new KeyCodes() {KeyCode = 86, KeyName = "VKey", Description = "V", Code = "V", KeyImage = KeyStrings.VKey}},
            {87, new KeyCodes() {KeyCode = 87, KeyName = "WKey", Description = "W", Code = "W", KeyImage = KeyStrings.WKey}},
            {88, new KeyCodes() {KeyCode = 88, KeyName = "XKey", Description = "X", Code = "X", KeyImage = KeyStrings.XKey}},
            {89, new KeyCodes() {KeyCode = 89, KeyName = "YKey", Description = "Y", Code = "Y", KeyImage = KeyStrings.YKey}},
            {90, new KeyCodes() {KeyCode = 90, KeyName = "ZKey", Description = "Z", Code = "Z", KeyImage = KeyStrings.ZKey}},
            {91, new KeyCodes() {KeyCode = 91, KeyName = "WindowKey", Description = "Window", Code = "Window", KeyImage = KeyStrings.WindowKey}},
            {92, new KeyCodes() {KeyCode = 92, KeyName = "RightWindowKey", Description = "RightWindow", Code = "RightWindow", KeyImage = KeyStrings.RightWindowKey}},
            {93, new KeyCodes() {KeyCode = 93, KeyName = "FnKey", Description = "Fn", Code = "Fn", KeyImage = KeyStrings.FnKey}},
            {96, new KeyCodes() {KeyCode = 96, KeyName = "Num0Key", Description = "Num0", Code = "Num0", KeyImage = KeyStrings.Num0Key}},
            {97, new KeyCodes() {KeyCode = 97, KeyName = "Num1Key", Description = "Num1", Code = "Num1", KeyImage = KeyStrings.Num1Key}},
            {98, new KeyCodes() {KeyCode = 98, KeyName = "Num2Key", Description = "Num2", Code = "Num2", KeyImage = KeyStrings.Num2Key}},
            {99, new KeyCodes() {KeyCode = 99, KeyName = "Num3Key", Description = "Num3", Code = "Num3", KeyImage = KeyStrings.Num3Key}},
            {100, new KeyCodes() {KeyCode = 100, KeyName = "Num4Key", Description = "Num4", Code = "Num4", KeyImage = KeyStrings.Num4Key}},
            {101, new KeyCodes() {KeyCode = 101, KeyName = "Num5Key", Description = "Num5", Code = "Num5", KeyImage = KeyStrings.Num5Key}},
            {102, new KeyCodes() {KeyCode = 102, KeyName = "Num6Key", Description = "Num6", Code = "Num6", KeyImage = KeyStrings.Num6Key}},
            {103, new KeyCodes() {KeyCode = 103, KeyName = "Num7Key", Description = "Num7", Code = "Num7", KeyImage = KeyStrings.Num7Key}},
            {104, new KeyCodes() {KeyCode = 104, KeyName = "Num8Key", Description = "Num8", Code = "Num8", KeyImage = KeyStrings.Num8Key}},
            {105, new KeyCodes() {KeyCode = 105, KeyName = "Num9Key", Description = "Num9", Code = "Num9", KeyImage = KeyStrings.Num9Key}},
            {106, new KeyCodes() {KeyCode = 106, KeyName = "NumMultiplyKey", Description = "NumMultiply", Code = "NumMultiply", KeyImage = KeyStrings.NumMultiplyKey}},
            {107, new KeyCodes() {KeyCode = 107, KeyName = "NumPlusKey", Description = "NumPlus", Code = "NumPlus", KeyImage = KeyStrings.NumPlusKey}},
            {109, new KeyCodes() {KeyCode = 109, KeyName = "NumMinusKey", Description = "NumMinus", Code = "NumMinus", KeyImage = KeyStrings.NumMinusKey}},
            {110, new KeyCodes() {KeyCode = 110, KeyName = "NumDecimalKey", Description = "NumDecimal", Code = "NumDecimal", KeyImage = KeyStrings.NumDecimalKey}},
            {111, new KeyCodes() {KeyCode = 111, KeyName = "NumDivideKey", Description = "NumDivide", Code = "NumDivide", KeyImage = KeyStrings.NumDivideKey}},
            {112, new KeyCodes() {KeyCode = 112, KeyName = "F1Key", Description = "F1", Code = "F1", KeyImage = KeyStrings.F1Key}},
            {113, new KeyCodes() {KeyCode = 113, KeyName = "F2Key", Description = "F2", Code = "F2", KeyImage = KeyStrings.F2Key}},
            {114, new KeyCodes() {KeyCode = 114, KeyName = "F3Key", Description = "F3", Code = "F3", KeyImage = KeyStrings.F3Key}},
            {115, new KeyCodes() {KeyCode = 115, KeyName = "F4Key", Description = "F4", Code = "F4", KeyImage = KeyStrings.F4Key}},
            {116, new KeyCodes() {KeyCode = 116, KeyName = "F5Key", Description = "F5", Code = "F5", KeyImage = KeyStrings.F5Key}},
            {117, new KeyCodes() {KeyCode = 117, KeyName = "F6Key", Description = "F6", Code = "F6", KeyImage = KeyStrings.F6Key}},
            {118, new KeyCodes() {KeyCode = 118, KeyName = "F7Key", Description = "F7", Code = "F7", KeyImage = KeyStrings.F7Key}},
            {119, new KeyCodes() {KeyCode = 119, KeyName = "F8Key", Description = "F8", Code = "F8", KeyImage = KeyStrings.F8Key}},
            {120, new KeyCodes() {KeyCode = 120, KeyName = "F9Key", Description = "F9", Code = "F9", KeyImage = KeyStrings.F9Key}},
            {121, new KeyCodes() {KeyCode = 121, KeyName = "F10Key", Description = "F10", Code = "F10", KeyImage = KeyStrings.F10Key}},
            {122, new KeyCodes() {KeyCode = 122, KeyName = "F11Key", Description = "F11", Code = "F11", KeyImage = KeyStrings.F11Key}},
            {123, new KeyCodes() {KeyCode = 123, KeyName = "F12Key", Description = "F12", Code = "F12", KeyImage = KeyStrings.F12Key}},
            {144, new KeyCodes() {KeyCode = 144, KeyName = "NumLockKey", Description = "NumLock", Code = "NumLock", KeyImage = KeyStrings.NumLockKey}}, 
            {145, new KeyCodes() {KeyCode = 145, KeyName = "ScrollLockKey", Description = "ScrollLock", Code = "ScrollLock", KeyImage = KeyStrings.ScrollLockKey}},
            {173, new KeyCodes() {KeyCode = 173, KeyName = "AudioVolumeMuteKey", Description = "AudioVolumeMute", Code = "AudioVolumeMute", KeyImage = KeyStrings.AudioVolumeMuteKey}},
            {174, new KeyCodes() {KeyCode = 174, KeyName = "AudioVolumeDownKey", Description = "AudioVolumeDown", Code = "AudioVolumeDown", KeyImage = KeyStrings.AudioVolumeDownKey}},
            {175, new KeyCodes() {KeyCode = 175, KeyName = "AudioVolumeUpKey", Description = "AudioVolumeUpKey", Code = "AudioVolumeUpKey", KeyImage = KeyStrings.AudioVolumeUpKey}},
            {181, new KeyCodes() {KeyCode = 181, KeyName = "LaunchMediaPlayerKey", Description = "LaunchMediaPlayer", Code = "LaunchMediaPlayer", KeyImage = KeyStrings.LaunchMediaPlayerKey}},
            {182, new KeyCodes() {KeyCode = 182, KeyName = "LaunchApplication1Key", Description = "LaunchApplication1", Code = "LaunchApplication1", KeyImage = KeyStrings.LaunchApplication1Key}},
            {183, new KeyCodes() {KeyCode = 183, KeyName = "LaunchApplication2Key", Description = "LaunchApplication2", Code = "LaunchApplication2", KeyImage = KeyStrings.LaunchApplication2Key}},
            {186, new KeyCodes() {KeyCode = 186, KeyName = "SemicolonKey", Description = "Semicolon", Code = "Semicolon", KeyImage = KeyStrings.SemicolonKey}},
            {187, new KeyCodes() {KeyCode = 187, KeyName = "EqualKey", Description = "Equal", Code = "Equal", KeyImage = KeyStrings.EqualKey}},
            {188, new KeyCodes() {KeyCode = 188, KeyName = "CommaKey", Description = "Comma", Code = "Comma", KeyImage = KeyStrings.CommaKey}},
            {189, new KeyCodes() {KeyCode = 189, KeyName = "MinusKey", Description = "Minus", Code = "Minus", KeyImage = KeyStrings.MinusKey}},
            {190, new KeyCodes() {KeyCode = 190, KeyName = "PeriodKey", Description = "Period", Code = "Period", KeyImage = KeyStrings.PeriodKey}},
            {191, new KeyCodes() {KeyCode = 191, KeyName = "SlashKey", Description = "Slash", Code = "Slash", KeyImage = KeyStrings.SlashKey}},
            {223, new KeyCodes() {KeyCode = 223, KeyName = "GraveKey", Description = "Grave", Code = "Grave", KeyImage = KeyStrings.GraveKey}},
            {219, new KeyCodes() {KeyCode = 219, KeyName = "LeftBracketKey", Description = "LeftBracket", Code = "LeftBracket", KeyImage = KeyStrings.LeftBracketKey}},
            {220, new KeyCodes() {KeyCode = 220, KeyName = "BackslashKey", Description = "Backslash", Code = "Backslash", KeyImage = KeyStrings.BackslashKey}},
            {221, new KeyCodes() {KeyCode = 221, KeyName = "RightBracketKey", Description = "RightBracket", Code = "RightBracket", KeyImage = KeyStrings.RightBracketKey}},
            {192, new KeyCodes() {KeyCode = 192, KeyName = "ApostropheKey", Description = "Apostrophe", Code = "Apostrophe", KeyImage = KeyStrings.ApostropheKey}},
            {222, new KeyCodes() {KeyCode = 222, KeyName = "HashKey", Description = "Hash", Code = "Hash", KeyImage = KeyStrings.HashKey}}
        };

        public static ArrayList DeconstructKeyCode(int keycode)
        {
            const int meta = 1048576;
            const int alt = 262144;
            const int ctrl = 131072;
            const int shift = 65536;

            ArrayList keycodes = new ArrayList();
            if (keycode >= meta)
            {
                keycodes.Add(91); // Keycode for Windows/Command key
                keycode -= meta;
            }

            if (keycode >= alt)
            {
                keycodes.Add(18); // Keycode for Alt
                keycode -= alt;
            }

            if (keycode >= ctrl)
            {
                keycodes.Add(17); // Keycode for Control
                keycode -= ctrl;
            }

            if (keycode >= shift)
            {
                keycodes.Add(16); // Keycode for Shift
                keycode -= shift;
            }


            // Remaining value is the ASCII value of the key pressed
            keycodes.Add(keycode);

            return keycodes;
        }
    }
}