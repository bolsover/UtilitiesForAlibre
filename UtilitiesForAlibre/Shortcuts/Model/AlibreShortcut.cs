using System.Drawing;
using System.Drawing.Imaging;
using UtilitiesForAlibre.Properties;
using DevExpress.Utils.Svg;

namespace Bolsover.Shortcuts.Model
{
    public class AlibreShortcut
    {
        // Constructor for the Shortcut class
        public AlibreShortcut(string profile, string command, string hint, int keycode, string keyChar)
        {
            Profile = profile;
            Command = command;
            Hint = hint;
            Keycode = keycode;
            KeyChar = keyChar;
            CalcNonModifierCodeAndType();
        }

        // Properties of the Shortcut class
        public string Profile { get; set; }
        public string Command { get; set; }
        public string Hint { get; set; }
        public int Keycode { get; set; }
        public string KeyChar { get; set; }
        public ShortcutType ShortcutType { get; set; }
        
        public string TooltipText
        {
            get => Command + "\r\n" + Hint + "\r\n" + KeyChar;
        }
        
         public SvgImage SvgImage { get; set; }

        public ShortcutModifierType ShortcutModifierType { get; set; }
        
        public int NonModifierCode { get; set; }

        public override string ToString()
        {
            return $"{KeyChar} - {Hint}";
        }

        public Image SvgToIcon()
        {
            if (SvgImage == null) return null;
            var source = SvgBitmap.Create(SvgImage);
            var img = source.Render(null, Properties.Settings.Default.AlibreIcon);
           return img;
        }

        /// <summary>
        /// This method is used to calculate non-modifier code from the given code.
        /// It also sets the shortcutModifierType based on the given code.
        /// </summary>
        /// <param name="code">The code to get the non-modifier code from.</param>
        /// <param name="shortcutModifierType">The shortcut modifier type to be set.</param>
        /// <returns>The non-modifier code.</returns>
        private void CalcNonModifierCodeAndType()
        {
            const int meta = 1048576;
            const int alt = 262144;
            const int ctrl = 131072;
            const int shift = 65536;
            
            int code = Keycode;

            bool isMeta = SubtractIfGreater(ref code, meta);
            bool isAlt = SubtractIfGreater(ref code, alt);
            bool isCtrl = SubtractIfGreater(ref code, ctrl);
            bool isShift = SubtractIfGreater(ref code, shift);

            ShortcutModifierType = DetermineShortcutModifierType(isMeta, isCtrl, isAlt, isShift);
            NonModifierCode = code;
          }
        
        
        /// <summary>
        /// This method is used to subtract a value from the code if the code is greater than or equal to the value.
        /// </summary>
        /// <param name="code">The code to subtract from.</param>
        /// <param name="value">The value to subtract.</param>
        /// <returns>True if the subtraction was performed, false otherwise.</returns>
        private bool SubtractIfGreater(ref int code, int value)
        {
            if (code >= value)
            {
                code -= value;
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// This method is used to determine the shortcut modifier type based on the given boolean flags.
        /// </summary>
        /// <param name="isMeta">Flag indicating if the meta key was pressed.</param>
        /// <param name="isCtrl">Flag indicating if the control key was pressed.</param>
        /// <param name="isAlt">Flag indicating if the alt key was pressed.</param>
        /// <param name="isShift">Flag indicating if the shift key was pressed.</param>
        /// <returns>The determined shortcut modifier type.</returns>
        private ShortcutModifierType DetermineShortcutModifierType(bool isMeta, bool isCtrl, bool isAlt, bool isShift)
        {
            if (isMeta) return ShortcutModifierType.Meta;
            if (isCtrl && isAlt && isShift) return ShortcutModifierType.CtrlAltShift;
            if (isCtrl && isAlt) return ShortcutModifierType.CtrlAlt;
            if (isCtrl && isShift) return ShortcutModifierType.CtrlShift;
            if (isAlt && isShift) return ShortcutModifierType.AltShift;
            if (isCtrl) return ShortcutModifierType.Ctrl;
            if (isAlt) return ShortcutModifierType.Alt;
            if (isShift) return ShortcutModifierType.Shift;

            return ShortcutModifierType.None;
        }
    }
    public enum ShortcutType
    {
        Custom,
        Override,
        Default
    }
    
    public enum ShortcutModifierType
    {
        None,
        Ctrl,
        Alt,
        Shift,
        CtrlAlt,
        CtrlShift,
        AltShift,
        CtrlAltShift,
        Meta
     
    }
}