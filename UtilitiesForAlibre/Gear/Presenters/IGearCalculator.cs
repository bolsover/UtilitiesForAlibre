using Bolsover.Gear.Models;

namespace Bolsover.Gear.Presenters
{
    public interface IGearCalculator
    {
        double CalculateStandardCentreDistance(IGearPair gearPair);

    //    double CalculateStandardCentreDistance(double module, double numberOfTeeth1, double numberOfTeeth2, double helixAngle);
        double CalculateWorkingCentreDistance(double standardCentreDistance, double profileShift, double module);
        double CalculateWorkingPressureAngle(double pressureAngle, double numberOfTeeth);
        double CalculateWorkingPitchDiameter(double module, double numberOfTeeth);
        double CalculateTransverseModule(double module, double helixAngle);
        double CalculateTipReliefRadius(double module, double numberOfTeeth);
        double CalculateRootFilletFactor(double module, double numberOfTeeth);
        double CalculateTransverseWorkingPressureAngle(double workingPressureAngle, double helixAngle);
        double CalculateTransverseWorkingCentreDistance(double workingCentreDistance, double helixAngle);
        double CalculateTransverseWorkingPitchDiameter(double workingPitchDiameter, double helixAngle);
        double CalculateTransverseTipReliefRadius(double tipReliefRadius, double helixAngle);
        double CalculateTransverseRootFilletFactor(double rootFilletFactor, double helixAngle);
        double CalculateTransverseStandardCentreDistance(double standardCentreDistance, double helixAngle);
        double CalculateInvoluteAlpha(double pressureAngle,double helixAngle);

        double CalculateInvoluteFunction(double pressureAngle,double helixAngle, double pinionNumberOfTeeth, double gearNumberOfTeeth,
            double pinionCoefficientOfProfileShift, double gearCoefficientOfProfileShift);

        double CalculateCoefficientOfProfileShift(double pressureAngle, double workingInvoluteFunction,
            double involuteFunction, double pinionNumberOfTeeth, double gearNumberOfTeeth);

        double CalculateStandardCoefficientOfProfileShift();
        double CalculatePitchDiameter(double module, double numberOfTeeth, double helixAngle);
        double CalculateBaseDiameter(double module, double numberOfTeeth, double PressureAngle, double helixAngle);

        double CalculateAddendum(double module);
        double CalculateDedendum(double module);
        double CalculateWholeDepth(double module);
        double CalculateOutsideDiameter(double pitchDiameter, double addendum, double helixAngle);
        double CalculateRootDiameter(double pitchDiameter, double dedendum, double helixAngle);
    }
}