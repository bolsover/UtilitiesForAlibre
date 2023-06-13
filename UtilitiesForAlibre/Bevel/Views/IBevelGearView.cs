using System;
using Bolsover.Bevel.Models;

namespace Bolsover.Bevel.Views
{
    public interface IBevelGearView
    {
        IBevelGear Pinion { get; set; }
        IBevelGear Gear { get; set; }


        event EventHandler BuildPinionEvent;
        event EventHandler BuildGearEvent;
        event EventHandler CancelEvent;
        event EventHandler EditModuleEvent;
        event EventHandler EditShaftAngleEvent;
        event EventHandler EditPressureAngleEvent;
        event EventHandler EditSpiralAngleEvent;
        event EventHandler EditPinionNumberOfTeethEvent;
        event EventHandler EditPinionHandEvent;
        event EventHandler EditGearNumberOfTeethEvent;
        event EventHandler EditGearHandEvent;
        event EventHandler EditFaceWidthEvent;
        event EventHandler EditGearTypeEvent;
    }
}