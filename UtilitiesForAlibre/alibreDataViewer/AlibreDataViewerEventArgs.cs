using System;
using AlibreX;

namespace Bolsover.alibreDataViewer
{
    public class AlibreDataViewerEventArgs : EventArgs
    {
        public AlibreDataViewerEventArgs(IADSession session)
        {
                
            this.session = session;
        }
      
        public IADSession session { get; }
    }
}