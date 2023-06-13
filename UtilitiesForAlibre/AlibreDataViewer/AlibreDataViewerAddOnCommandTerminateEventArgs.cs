using System;

namespace Bolsover.AlibreDataViewer
{
    public class AlibreDataViewerAddOnCommandTerminateEventArgs : EventArgs
    {
        public AlibreDataViewerAddOnCommandTerminateEventArgs(AlibreDataViewerAddOnCommand alibreDataViewerAddOnCommand)
        {
            this.AlibreDataViewerAddOnCommand = alibreDataViewerAddOnCommand;
        }

        public AlibreDataViewerAddOnCommand AlibreDataViewerAddOnCommand { get; }
    }
}