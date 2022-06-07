using System;
using Bolsover.AlibreDataViewer;

namespace Bolsover.Involute
{
    public class InvoluteGearAddOnCommandTerminateEventArgs : EventArgs
    {
        public InvoluteGearAddOnCommandTerminateEventArgs(InvoluteGearAddOnCommand involuteGearAddOnCommand)
        {
            this.involuteGearAddOnCommand = involuteGearAddOnCommand;
        }

        public InvoluteGearAddOnCommand involuteGearAddOnCommand { get; }
    }
}