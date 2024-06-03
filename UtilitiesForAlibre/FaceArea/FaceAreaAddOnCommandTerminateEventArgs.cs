using System;

namespace Bolsover.FaceArea
{
    public class FaceAreaAddOnCommandTerminateEventArgs : EventArgs
    {
        public FaceAreaAddOnCommandTerminateEventArgs(FaceAreaAddOnCommand faceAreaAddOnCommand)
        {
            FaceAreaAddOnCommand = faceAreaAddOnCommand;
        }
        
        public FaceAreaAddOnCommand FaceAreaAddOnCommand { get; }
    }
}