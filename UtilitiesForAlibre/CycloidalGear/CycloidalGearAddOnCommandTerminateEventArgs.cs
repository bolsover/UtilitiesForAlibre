using System;

namespace Bolsover.CycloidalGear
{
    public class CycloidalGearAddOnCommandTerminateEventArgs : EventArgs
    {
        public CycloidalGearAddOnCommandTerminateEventArgs(CycloidalGearAddOnCommand cycloidalGearAddOnCommand)
        {
            this.CycloidalGearAddOnCommand = cycloidalGearAddOnCommand;
        }

        public CycloidalGearAddOnCommand CycloidalGearAddOnCommand { get; }
    }
}