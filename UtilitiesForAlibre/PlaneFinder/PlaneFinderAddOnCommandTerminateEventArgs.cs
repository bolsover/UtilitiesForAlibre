using System;

namespace Bolsover.PlaneFinder
{
    public class PlaneFinderAddOnCommandTerminateEventArgs : EventArgs
    {
        public PlaneFinderAddOnCommandTerminateEventArgs(PlaneFinderAddOnCommand planeFinderAddOnCommand)
        {
            this.planeFinderAddOnCommand = planeFinderAddOnCommand;
        }

        public PlaneFinderAddOnCommand planeFinderAddOnCommand { get; }
    }
}