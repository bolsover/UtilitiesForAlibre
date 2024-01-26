using System.ComponentModel;

namespace Bolsover.Involute.Model
{
    public interface IGearDesignInputParams
    {
        double Height { get; set; } // height of gear
        double Module { get; set; } // normal module
        double Teeth { get; set; } // teeth
        double PressureAngle { get; set; } //pressure angle in degrees
        double HelixAngle { get; set; } // helix angle in degrees
        double RootFilletFactor { get; set; } // root fillet factor 
        double AddendumFilletFactor { get; set; } // tip (addendum) fillet factor 
      
        double CircularBacklash { get; set; } // circular backlash required j_t

        double CoefficientOfProfileShift { get; set; }

        double HeightOfPitchLine { get; set; } // height of pitch line of rack gear

        GearStyle Style { get; set; }

        IGearPairDesignInputParams GearPairDesign { get; set; }

        void SetDefaults();

        event PropertyChangedEventHandler PropertyChanged;
    }
}