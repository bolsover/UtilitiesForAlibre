using System;

namespace Bolsover.Sample
{
    public class SampleAddonCommandTerminateEventArgs : EventArgs
    {
        public SampleAddonCommandTerminateEventArgs(SampleAddOnCommand sampleAddOnCommand)
        {
            SampleAddOnCommand = sampleAddOnCommand;
        }

        public SampleAddOnCommand SampleAddOnCommand { get; }
    }
}