using System;

namespace Bolsover.ThreeDLine
{
    public class ThreeDLineAddOnCommandTerminateEventArgs : EventArgs
    {
        public ThreeDLineAddOnCommandTerminateEventArgs(ThreeDLineAddOnCommand threeDLineAddOnCommand)
        {
            ThreeDLineAddOnCommand = threeDLineAddOnCommand;
        }

        public ThreeDLineAddOnCommand ThreeDLineAddOnCommand { get; }
    }
}