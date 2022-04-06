using System;

namespace Bolsover.AlibreDataViewer
{
    public class AlibreDataViewerAddOnCommandTerminateEventArgs :EventArgs
    {
        public AlibreDataViewerAddOnCommandTerminateEventArgs(AlibreDataViewerAddOnCommand alibreDataViewerAddOnCommand)
        {
            this.alibreDataViewerAddOnCommand = alibreDataViewerAddOnCommand;
        }

        public AlibreDataViewerAddOnCommand alibreDataViewerAddOnCommand { get; }
    }
}