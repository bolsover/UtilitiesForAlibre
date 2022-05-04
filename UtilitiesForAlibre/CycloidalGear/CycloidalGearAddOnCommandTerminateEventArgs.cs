using System;
using Bolsover.AlibreDataViewer;

namespace Bolsover.CycloidalGear
{
    public class CycloidalGearAddOnCommandTerminateEventArgs : EventArgs
    {
        public CycloidalGearAddOnCommandTerminateEventArgs(CycloidalGearAddOnCommand cycloidalGearAddOnCommand)
        {
            this.cycloidalGearAddOnCommand = cycloidalGearAddOnCommand;
        }

        public CycloidalGearAddOnCommand cycloidalGearAddOnCommand { get; }
    }
}