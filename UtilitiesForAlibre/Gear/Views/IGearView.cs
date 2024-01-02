using System;

namespace Bolsover.Gear.Views
{
    public interface IGearView
    {
        event EventHandler BuildGearEvent;
        event EventHandler BuildPinionEvent;
        event EventHandler CancelEvent;
        event EventHandler EditModuleEvent;
        event EventHandler EditPressureAngleEvent;
        event EventHandler EditPinionNumberOfTeethEvent;
        event EventHandler EditGearNumberOfTeethEvent;
        event EventHandler EditHelixAngleEvent;
        event EventHandler EditGearHeightEvent;
        event EventHandler AutoCalculateCentreDistanceEvent;
        event EventHandler EditCentreDistanceEvent;
        event EventHandler EditGearTypeEvent;
        event EventHandler EditPinionTypeEvent;
        event EventHandler EditPinionProfileShiftEvent;
        event EventHandler EditGearProfileShiftEvent;
        event EventHandler EditNormalBacklashEvent;
    }
}