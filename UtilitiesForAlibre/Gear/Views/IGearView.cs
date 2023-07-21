using System;

namespace Bolsover.Gear.Views
{
    public interface IGearView
    {
        event EventHandler BuildGearEvent;
        event EventHandler CancelEvent;
        event EventHandler EditModuleEvent;
        event EventHandler EditPressureAngleEvent;
        event EventHandler EditPinionNumberOfTeethEvent;
        event EventHandler EditGearNumberOfTeethEvent;
        event EventHandler EditHelixAngleEvent;
        event EventHandler EditGearHeightEvent;
    }
}