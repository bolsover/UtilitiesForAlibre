using System;


namespace Bolsover.EmptyShell
{
    public class EmptyAddonCommandTerminateEventArgs : EventArgs
    {
        public EmptyAddonCommandTerminateEventArgs(EmptyAddOnCommand emptyAddOnCommand)
        {
            this.emptyAddOnCommand = emptyAddOnCommand;
        }

        public EmptyAddOnCommand emptyAddOnCommand { get; }
    }
}