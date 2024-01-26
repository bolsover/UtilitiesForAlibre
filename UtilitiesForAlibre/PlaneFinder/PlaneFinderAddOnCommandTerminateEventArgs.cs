using System;

namespace Bolsover.PlaneFinder
{
    public class PlaneFinderAddOnCommandTerminateEventArgs : EventArgs
    {
        public PlaneFinderAddOnCommandTerminateEventArgs(PlaneFinderAddOnCommand planeFinderAddOnCommand)
        {
            PlaneFinderAddOnCommand = planeFinderAddOnCommand;
        }

        public PlaneFinderAddOnCommand PlaneFinderAddOnCommand { get; }
    }
}