using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Bolsover.Shortcuts.Calculator;
using Bolsover.Shortcuts.Model;
using Bolsover.Shortcuts.Utils;
using Bolsover.Shortcuts.View;
using com.alibre.client;
using com.alibre.ui;
using UtilitiesForAlibre.Properties;

namespace Bolsover.Shortcuts.Presenter
{
    public class KeyboardPresenter
    {
        private readonly KeyboardControl _view;

        // private readonly KeyText _keyText = new();
        private bool _isCtrlSelected;
        private bool _isAltSelected;
        private bool _isShiftSelected;
        private string _profile;

        private readonly ShortcutsCalculator _shortcutsCalculator = new();
        private List<AlibreShortcut> _shortcuts;

        public KeyboardPresenter(KeyboardControl view)
        {
            _view = view;
            SetupKeyImages("Arial Narrow", Properties.Settings.Default.KeyTextSize, Color.Empty, Properties.Settings.Default.TextColor);
            SetupColorControl();
            ClearDefaultText();
            DoDataBindings();
            DisabledKeys();
            DefaultBackColors();
            TextOverlayLocation();
            TextOverlayFont(new Font("Arial Narrow", Properties.Settings.Default.HintTextSize, FontStyle.Regular, GraphicsUnit.Pixel, 0));
            InitDropDown();
        }

        private void SetupColorControl()
        {
            var button = KeyButtons.GetButton(_view, "PauseBreakKey");
            button.Image = StringImageUtils.ConvertTextToPngImage("Add-on" +"\r\n"+"Prefs", "Arial Narrow", Properties.Settings.Default.KeyTextSize, Color.Empty, Properties.Settings.Default.TextColor);
        }

        /// <summary>
        /// Clears any existing background colors and text from the keyboard buttons passed in the dictionary.
        /// </summary>
        /// <param name="buttonDictionary"></param>
        private void ClearBackgroundColorsAndText(Dictionary<string, ShortcutButton> buttonDictionary)
        {
            foreach (var key in buttonDictionary)
            {
                key.Value.BackColor = Color.Empty;
                key.Value.Text = "";
                key.Value.AlibreShortcut = null;
            }
        }

        public void ProfileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _profile = _view.ProfileComboBox.SelectedItem.ToString();
            _shortcuts = _shortcutsCalculator.RetrieveUserShortcutsByProfile(_profile);
            // guard against null or empty list
            if (_shortcuts == null || _shortcuts.Count == 0)
            {
                _shortcuts = _shortcutsCalculator.RetrieveStandardShortcutsByProfile(_profile);
            }
            ShowShortcutsByModifierType();
        }

        /// <summary>
        /// Applies the background color and text to the keyboard buttons based on the shortcut list passed in.
        /// </summary>
        /// <param name="shortCutList">A dictionary of key-value pairs where the key is the key code and the value is the Shortcut object.</param>
        /// <param name="backColor">The background color to be applied to the keyboard buttons.</param>
        private void ApplyShortcutsBasedOnKeys(List<AlibreShortcut> shortCutList, Color backColor)
        {
            TextOverlayFont(new Font("Arial Narrow", Properties.Settings.Default.HintTextSize, FontStyle.Regular, GraphicsUnit.Pixel, 0));
            SetupKeyImages("Arial Narrow", Properties.Settings.Default.KeyTextSize, Color.Empty, Properties.Settings.Default.TextColor);
            SetupColorControl();
            // Get the dictionary of key codes by index
            var dictionary = KeyCodes.KeyCodesDictionaryByIndex();

            _view.toolTip1.RemoveAll();
            _view.toolTip1.ToolTipIcon = ToolTipIcon.Info;
            // Iterate over each item in the shortcut list
            foreach (var v in shortCutList)
            {
                // Try to get the KeyCodes object from the dictionary using the key from the shortcut list
                // If the key is not found in the dictionary, skip the current iteration
                // This is done because the Alibre user profile can contain 'broken' shortcuts that do not have a corresponding key code
                if (!dictionary.TryGetValue(v.NonModifierCode, out var kc))
                {
                    continue;
                }

                // Get the button corresponding to the key name from the KeyButtons class
                // If the button is not found, skip the current iteration
                Button button = KeyButtons.GetButton(_view, kc.KeyName);
                if (button == null)
                {
                    continue;
                }

                // Set the background color and text of the button
                button.BackColor = backColor;
                button.Text = v.Hint;
                if (v.SvgToIcon() != null)
                {
                    SetButtonImages(button, v.SvgToIcon(), button.Image);
                }

                _view.toolTip1.ToolTipTitle = _profile;
                _view.toolTip1.SetToolTip(button, v.TooltipText);
            }
        }

        /// <summary>
        /// Combines image1 and image2 into a single image and sets it as the image of the button.
        /// Sets the image alignment to bottom center. 
        /// </summary>
        /// <param name="button"></param>
        /// <param name="image1"></param>
        /// <param name="image2"></param>
        private void SetButtonImages(Button button, Image image1, Image image2)
        {
            var width = button.Width - button.Margin.Left - button.Margin.Right;
            var height = Math.Max(image1.Height, image2.Height);

            var bitmap = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bitmap))
            {
                // Draw image1 at bottom-left
                g.DrawImage(image1, 0, height - image1.Height);

                // Draw image2 at bottom-right
                g.DrawImage(image2, width - image2.Width, height - image2.Height);
            }

            button.Image = bitmap;
            button.ImageAlign = ContentAlignment.BottomCenter;
        }

        /// <summary>
        /// Clears any existing background color and text from the keyboard buttons.
        /// Sets the background color and text based on the modifier keys selected.
        /// </summary>
        private void ShowShortcutsByModifierType()
        {
            // clear all selections except modifier keys
            ClearBackgroundColorsAndText(KeyButtons.ButtonDictionaryExcModifiers(_view));
            var scs = Queries.RetrieveShortcutsByModifierType(_shortcuts, ShortcutModifierType.None);
            var backColor = Properties.Settings.Default.NoModifierColor;
            var buttons = new List<ShortcutButton>();
            var modifierText = "No Modifier";

            if (_isCtrlSelected && _isAltSelected && _isShiftSelected)
            {
                scs = Queries.RetrieveShortcutsByModifierType(_shortcuts, ShortcutModifierType.CtrlAltShift);
                backColor = Properties.Settings.Default.CtrlAltShiftColor;
                buttons = KeyButtons.CtrlAltShiftButtons();
                modifierText = "Ctrl+Alt+Shift+";
            }
            else if (_isCtrlSelected && _isAltSelected)
            {
                scs = Queries.RetrieveShortcutsByModifierType(_shortcuts, ShortcutModifierType.CtrlAlt);
                backColor = Properties.Settings.Default.CtrlAltColor;
                buttons = KeyButtons.CtrlAltButtons();
                modifierText = "Ctrl+Alt+";
            }
            else if (_isCtrlSelected && _isShiftSelected)
            {
                scs = Queries.RetrieveShortcutsByModifierType(_shortcuts, ShortcutModifierType.CtrlShift);
                backColor = Properties.Settings.Default.CtrlShiftColor;
                buttons = KeyButtons.CtrlShiftButtons();
                modifierText = "Ctrl+Shift+";
            }
            else if (_isAltSelected && _isShiftSelected)
            {
                scs = Queries.RetrieveShortcutsByModifierType(_shortcuts, ShortcutModifierType.AltShift);
                backColor = Properties.Settings.Default.AltShiftColor;
                buttons = KeyButtons.AltShiftButtons();
                modifierText = "Alt+Shift+";
            }
            else if (_isCtrlSelected)
            {
                scs = Queries.RetrieveShortcutsByModifierType(_shortcuts, ShortcutModifierType.Ctrl);
                backColor = Properties.Settings.Default.CtrlColor;
                buttons = KeyButtons.CtrlButtons();
                modifierText = "Ctrl+";
            }
            else if (_isAltSelected)
            {
                scs = Queries.RetrieveShortcutsByModifierType(_shortcuts, ShortcutModifierType.Alt);
                backColor = Properties.Settings.Default.AltColor;
                buttons = KeyButtons.AltButtons();
                modifierText = "Alt+";
            }
            else if (_isShiftSelected)
            {
                scs = Queries.RetrieveShortcutsByModifierType(_shortcuts, ShortcutModifierType.Shift);
                backColor = Properties.Settings.Default.ShiftColor;
                buttons = KeyButtons.ShiftButtons();
                modifierText = "Shift+";
            }

            ApplyShortcutsBasedOnKeys(scs, backColor);
            KeyButtons.ApplyBackgroundColor(buttons, backColor);
            _view.ModifierText.Text = modifierText;
        }

        /// <summary>
        /// Retrieves the list of workspace prefixes from the KeyboardShortcutsMediator and populates the drop down
        /// The list depends on user license type (Atom or Pro)
        /// </summary>
        private void InitDropDown()
        {
            var workspacePrefixes = ClientContext.Singleton.IsAtom
                ? KeyboardShortcutsMediator.ATOM_WORKSPACE_PREFIXES
                : KeyboardShortcutsMediator.ALL_WORKSPACE_PREFIXES;
            _view.ProfileComboBox.Items.AddRange(workspacePrefixes);
        }

        /// <summary>
        /// Sets the font of the text overlay on the key buttons.
        /// </summary>
        /// <param name="font"></param>
        private void TextOverlayFont(Font font)
        {
            foreach (var key in KeyButtons.ButtonDictionary(_view))
            {
                key.Value.Font = font;
            }
        }

        /// <summary>
        /// Sets the location of the text overlay on the key buttons to the top left.
        /// </summary>
        private void TextOverlayLocation()
        {
            foreach (var key in KeyButtons.ButtonDictionary(_view))
            {
                key.Value.TextAlign = ContentAlignment.TopLeft;
            }
        }

        public void ViewCtrl_Click(object sender, EventArgs e)
        {
            _isCtrlSelected = !_isCtrlSelected;
            if (!_isCtrlSelected)
            {
                _view.LeftCtrlKey.BackColor = Properties.Settings.Default.ModifierKeyColor;
                _view.RightCtrlKey.BackColor = Properties.Settings.Default.ModifierKeyColor;
            }

            ShowShortcutsByModifierType();
        }

        public void ViewAlt_Click(object sender, EventArgs e)
        {
            _isAltSelected = !_isAltSelected;
            if (!_isAltSelected)
            {
                _view.LeftAltKey.BackColor = Properties.Settings.Default.ModifierKeyColor;
                _view.AltGrKey.BackColor = Properties.Settings.Default.ModifierKeyColor;
            }

            ShowShortcutsByModifierType();
        }

        public void ViewShift_Click(object sender, EventArgs e)
        {
            _isShiftSelected = !_isShiftSelected;
            if (!_isShiftSelected)
            {
                _view.LeftShiftKey.BackColor = Properties.Settings.Default.ModifierKeyColor;
                _view.RightShiftKey.BackColor = Properties.Settings.Default.ModifierKeyColor;
            }

            ShowShortcutsByModifierType();
        }

        private void DefaultBackColors()
        {
            KeyButtons.ApplyBackgroundColor(KeyButtons.CtrlAltShiftButtons(), Properties.Settings.Default.ModifierKeyColor);
        }

        private void DisabledKeys()
        {
            KeyButtons.GetButton(_view, "CapsLockKey").Enabled = false;
            KeyButtons.GetButton(_view, "ScrollLockKey").Enabled = false;
            KeyButtons.GetButton(_view, "NumLockKey").Enabled = false;
            KeyButtons.GetButton(_view, "PrintScreenKey").Enabled = false;
            // KeyButtons.GetButton(_view, "PauseBreakKey").Enabled = false;
            KeyButtons.GetButton(_view, "FnKey").Enabled = false;
            KeyButtons.GetButton(_view, "WindowKey").Enabled = false;
            KeyButtons.GetButton(_view, "NumDivideKey").Enabled = false;
            KeyButtons.GetButton(_view, "NumMultiplyKey").Enabled = false;
            KeyButtons.GetButton(_view, "NumEnterKey").Enabled = false;
            KeyButtons.GetButton(_view, "TabKey").Enabled = false;
            KeyButtons.GetButton(_view, "WindowKey").Enabled = false;
        }

        private static void DoDataBinding(Control key, string keyTextName)
        {
            key.DataBindings.Add(new Binding("Text", new KeyText(), keyTextName, true, DataSourceUpdateMode.OnPropertyChanged));
        }

        /// <summary>
        /// Binds the text property of the key buttons to the KeyText class.
        /// </summary>
        private void DoDataBindings()
        {
            foreach (var key in KeyButtons.ButtonDictionary(_view))
            {
                DoDataBinding(key.Value, key.Key + "Text");
            }
        }

        /// <summary>
        /// Clears any default text from the keys.
        /// </summary>
        private void ClearDefaultText()
        {
            foreach (var key in KeyButtons.ButtonDictionary(_view))
            {
                key.Value.Text = "";
            }
        }

       
        /// <summary>
        /// Sets up the images for the keys on the keyboard.
        /// Sets the image alignment to bottom right.
        /// </summary>
        /// <param name="fontName">The name of the font to be used for the key images.</param>
        /// <param name="size">The size of the font to be used for the key images.</param>
        /// <param name="bgColor">The background color of the key images.</param>
        /// <param name="fgColor">The foreground color of the key images.</param>
        private void SetupKeyImages(string fontName, int size, Color bgColor, Color fgColor)
        {
            var keys = new List<string>
            {
                "F1Key", "F2Key", "F3Key", "F4Key", "F5Key", "F6Key", "F7Key", "F8Key", "F9Key", "F10Key", "F11Key", "F12Key",
                "AKey", "BKey", "CKey", "DKey", "EKey", "FKey", "GKey", "HKey", "IKey", "JKey", "KKey", "LKey", "MKey", "NKey",
                "OKey", "PKey", "QKey", "RKey", "SKey", "TKey", "UKey", "VKey", "WKey", "XKey", "YKey", "ZKey",
                "ZeroKey", "OneKey", "TwoKey", "ThreeKey", "FourKey", "FiveKey", "SixKey", "SevenKey", "EightKey", "NineKey",
                "SpaceKey", "TabKey", "EnterKey", "BackspaceKey", "EscapeKey", "LeftShiftKey", "RightShiftKey", "LeftCtrlKey",
                "RightCtrlKey", "LeftAltKey", "AltGrKey", "DeleteKey", "InsertKey", "HomeKey", "EndKey", "PageUpKey", "PageDownKey",
                "UpKey", "DownKey", "LeftKey", "RightKey", "NumLockKey", "Num0Key", "Num1Key", "Num2Key", "Num3Key", "Num4Key",
                "Num5Key", "Num6Key", "Num7Key", "Num8Key", "Num9Key", "NumPlusKey", "NumMinusKey", "NumMultiplyKey", "NumDivideKey",
                "NumDecimalKey", "NumEnterKey", "PrintScreenKey", "PauseBreakKey", "ScrollLockKey", "CapsLockKey", "MinusKey",
                "EqualKey", "BackslashKey", "LeftBracketKey", "RightBracketKey", "SemicolonKey", "CommaKey", "PeriodKey", "SlashKey",
                "WindowKey", "FnKey", "HashKey", "ApostropheKey", "GraveKey"
            };

            foreach (var key in keys)
            {
                var button = KeyButtons.GetButton(_view, key);
                var type = typeof(KeyStrings);
                var fieldInfo = type.GetField(key);
                var value = (string) fieldInfo.GetValue(null);
                button.Image = StringImageUtils.ConvertTextToPngImage(value, fontName, size, bgColor, fgColor);
                button.ImageAlign = ContentAlignment.BottomRight;
            }
        }
    }
}