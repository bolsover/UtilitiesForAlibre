using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bolsover.Shortcuts.Model;

namespace Bolsover.Shortcuts.View
{
    public class ShortcutButton : Button
    {
        private AlibreShortcut _alibreShortcut;
        
        public AlibreShortcut AlibreShortcut  {
            get => _alibreShortcut;
            set => SetField(ref _alibreShortcut, value);
        }
        
        
        private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        
    }
    
   
    
}