using System.Drawing;
using System.IO;
using WpfMath;
using WpfMath.Parsers;
using XamlMath;

namespace Bolsover.Gear.Images
{
    public class GearLatexStrings
    {
        public const string ModuleSymbol = @"m";
        public const string NormalModuleSymbol = @"m_{n}";
        public const string PressureAngleSymbol = @"\alpha_{n}";
        public const string NormalPressureAngleSymbol = @"\alpha_{n}";
        public const string HelixAngleSymbol = @"\beta";
        public const string TransverseInvoluteFunctionSymbol = @"inv\,\alpha_{t}";
        public const string WorkingInvoluteFunctionSymbol = @"inv\,\alpha_{w}";
        public const string TransverseInvoluteFunctionFormula = @"tan\alpha-\alpha_{t}";

        public const string WorkingInvoluteFunctionFormula =
            @"2\,tan\alpha\left(\frac{x_{2}-x_{1}}{z_{2}-z_{1}}\right)+ inv\alpha";

        public const string WorkingPressureAngleSymbol = @"\alpha_{wt}";
        public const string WorkingPressureAngleFormula = @"From\,  involute\,  function\,  table\\";

        public const string WorkingPressureAngleFormula2 =
            @"cos^{-1}\left[\frac{\left(z_{1}+z_{2}\right)cos\alpha}{2y+z_{1}+z_{2}}\right]";

        public const string StandardWorkingPressureAngleFormula = @"N\backslash A";
        public const string CentreDistanceIncrementFactorSymbol = @"y";

        public const string CentreDistanceIncrementFactorFormula =
            @"\frac{z_{2}-z_{1}}{2}\left(\frac{cos\alpha}{cos\alpha_{w}}-1\right)";

        public const string StandardCentreDistanceIncrementFactorFormula =
            @"0\, for\, standard\, gears";

        public const string CentreDistanceSymbol = @"a_{x}";
        public const string CentreDistanceFormula = @"\left(\frac{z_{2}-z_{1}}{2}+y\right)m";
        public const string StandardCentreDistanceFormula = @"N\backslash A";
        public const string StandardCoefficientOfProfileShiftSymbol = @"x";
        public const string StandardCoefficientOfProfileShiftFormula = @"0\, for\, standard\, gears";
        public const string CoefficientOfProfileShiftSymbol = @"x_{1}, x_{2}";
        public const string SpiralAngleSymbol = @"\beta";
        public const string RadialPressureAngleSymbol = @"\alpha_{t}";
        public const string NumberOfTeethSymbol = @"z";
        public const string NumberOfTeethSymbol2 = @"z_{1}, z_{2}";
        public const string PitchDiameterSymbol = @"d";
        public const string PitchDiameterFormula = @"\frac{zm}{cos\beta}";
        public const string BaseDiameterSymbol = @"d_{b}";
        public const string BaseDiameterFormula = @"d\,cos\alpha_{t}";
        public const string RadialWorkingPitchDiameterSymbol = @"d_{wt}";
        public const string WorkingPitchDiameterSymbol = @"d_{w}";
        public const string StandardWorkingPitchDiameterFormula = @"N\backslash A\, calculated\, from\, gear\, pair";
        public const string WorkingPitchDiameterFormula = @"\frac{d_{b}}{cos\alpha_{w}}";
        public const string AddendumSymbol = @"h_{a}";
        public const string Addendum1Symbol = @"h_{a1}";
        public const string Addendum2Symbol = @"h_{a2}";
        public const string DedendumSymbol = @"h_{f}";
        public const string Dedendum1Symbol = @"h_{f1}";
        public const string Dedendum2Symbol = @"h_{f2}";
        public const string AddendumFormula = @"1m";
        public const string Addendum1Formula = @"\left( 1 + x_{1}\right)m";
        public const string Addendum2Formula = @"\left( 1 - x_{2}\right)m";
        public const string DedendumFormula = @"1.25m";
        public const string Dedendum1Formula = @"\left( 1.25 + x_{1}\right)m";
        public const string Dedendum2Formula = @"\left( 1.25 - x_{2}\right)m";
        public const string WholeDepthSymbol = @"h";
        public const string WholeDepthFormula = @"2.25m";
        public const string OutsideDiameterSymbol = @"d_{a}";
        public const string OutsideDiameter1Symbol = @"d_{a1}";
        public const string OutsideDiameterFormula = @"d+2h_{a}";
        public const string OutsideDiameter1Formula = @"d_{1}+2h_{a1}";
        public const string OutsideDiameter2Symbol = @"d_{a2}";
        public const string OutsideDiameter2Formula = @"d_{2}-2h_{a2}";
        public const string RootDiameterSymbol = @"d_{f}";
        public const string RootDiameter1Symbol = @"d_{f1}";
        public const string RootDiameterFormula = @"d_{a}-2h";
        public const string RootDiameter1Formula = @"d_{a1}-2h";
        public const string RootDiameter2Symbol = @"d_{f2}";
        public const string RootDiameter2Formula = @"d_{a2}+2h";
    }
}