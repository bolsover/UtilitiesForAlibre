using System;

namespace Bolsover.AlibreDataViewer
{
    public class AlibreDataViewerAddOnCommandTerminateEventArgs : EventArgs
    {
        public AlibreDataViewerAddOnCommandTerminateEventArgs(AlibreDataViewerAddOnCommand alibreDataViewerAddOnCommand)
        {
            AlibreDataViewerAddOnCommand = alibreDataViewerAddOnCommand;
        }

        public AlibreDataViewerAddOnCommand AlibreDataViewerAddOnCommand { get; }
    }
}