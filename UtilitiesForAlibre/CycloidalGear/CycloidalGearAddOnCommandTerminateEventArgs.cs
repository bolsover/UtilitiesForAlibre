using System;

namespace Bolsover.CycloidalGear
{
    public class CycloidalGearAddOnCommandTerminateEventArgs : EventArgs
    {
        public CycloidalGearAddOnCommandTerminateEventArgs(CycloidalGearAddOnCommand cycloidalGearAddOnCommand)
        {
            CycloidalGearAddOnCommand = cycloidalGearAddOnCommand;
        }

        public CycloidalGearAddOnCommand CycloidalGearAddOnCommand { get; }
    }
}