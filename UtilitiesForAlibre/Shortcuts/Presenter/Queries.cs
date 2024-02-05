using System.Collections.Generic;
using System.Linq;
using Bolsover.Shortcuts.Model;

namespace Bolsover.Shortcuts.Presenter
{
    public class Queries
    {
        
        public static List<AlibreShortcut> RetrieveShortcutsByModifierType(IEnumerable<AlibreShortcut> shortcuts, ShortcutModifierType shortcutModifierType)
        {
            var shortcutQuery = from shortcut in shortcuts
                where shortcut.ShortcutModifierType == shortcutModifierType && !string.IsNullOrEmpty(shortcut.Hint) && shortcut.NonModifierCode != 0 
                select shortcut;
            return shortcutQuery.ToList();
        }
        
        
    }
}