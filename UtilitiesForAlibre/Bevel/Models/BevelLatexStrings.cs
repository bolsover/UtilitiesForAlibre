namespace Bolsover.Bevel.Models
{
    public static class BevelLatexStrings
    {
        public const string ShaftAngleLatex = @"\Sigma";
        public const string ModuleLatex = @"m";
        public const string PressureAngleLatex = @"\alpha";
        public const string SpiralAngleLatex = @"\beta";
        public const string RadialPressureAngleLatex = @"\alpha_{t}";
        public const string RadialPressureAngleFormulaLatex = @"tan^{-1} \left(\frac{tan\alpha}{cos\beta}\right) ";
        public const string NumberOfTeethLatex = @"z_{1}, z_{2}";
        public const string PitchDiameterLatex = @"d";
        public const string PitchDiameterFormulaLatex = @"zm";
        public const string PitchConeAngle1Latex = @"\delta_{1}";
        public const string PitchConeAngle2Latex = @"\delta_{2}";

        public const string PitchConeAngle1FormulaLatex =
            @"tan^{-1} \left(\frac{sin\Sigma}{\left(\frac{z_{1}}{z_{2}}\right)+cos\Sigma}\right) ";

        public const string PitchConeAngle2FormulaLatex = @"\Sigma - \delta_{1}";
        public const string ConeDistanceLatex = @"R_{e}";
        public const string ConeDistanceFormulaLatex = @"\frac{d_{2}}{2sin\delta_{2}}";
        public const string FaceWidthLatex = @"b";
        public const string FaceWidthFormulaLatex = @"Should\:be\:less\:than\:R_{e}/3\:or\:10m";
        public const string Addendum1Latex = @"h_{a1}";
        public const string Addendum2Latex = @"h_{a2}";

        // Gleason spiral and zerol types
        public const string AddendumHa1GleasonSpiralFormulaLatex = @"1.700m - h_{a2}";

        public const string AddendumHa2GleasonSpiralFormulaLatex =
            @"0.460m + \frac{0.390m}{\left(\frac{Z_{2}cos\delta_{1}}{Z_{1}cos\delta_{2}}\right)}";

        public const string DedendumGleasonSpiralFormulaLatex = @"1.888m -h_(a)";

        // Gleason straight types
        public const string AddendumHa1GleasonStraightFormulaLatex = @"2.000m - h_{a2}";

        public const string AddendumHa2GleasonStraightFormulaLatex =
            @"0.540m + \frac{0.460m}{\left(\frac{Z_{2}cos\delta_{1}}{Z_{1}cos\delta_{2}}\right)}";

        public const string DedendumHfGleasonStraightFormulaLatex = @"2.188m -h_(a)";

        // Standard types
        public const string StandardAddendumHaFormulaLatex = @"1.000m ";
        public const string StandardAddendumHa2FormulaLatex = @"1.000m ";
        public const string StandardDedendumHfFormulaLatex = @"1.25m";

        public const string DedendumLatex = @"h_{f}";


        public const string DedendumAngleLatex = @"\Theta_{f}";
        public const string DedendumAngleFormulaLatex = @"tan^{-1}\left(\frac{h_{f}}{R_{e}}\right)";
        public const string AddendumAngle1Latex = @"\Theta_{a1}";
        public const string AddendumAngle1FormulaLatex = @"\Theta_{f2}";
        public const string AddendumAngle2Latex = @"\Theta_{a2}";
        public const string AddendumAngle2FormulaLatex = @"\Theta_{f1}";
        public const string OuterConeAngleLatex = @"\delta_{a}";
        public const string OuterConeAngleFormulaLatex = @"\delta + \Theta_{a}";
        public const string RootConeAngleLatex = @"\delta_{f}";
        public const string RootConeAngleFormulaLatex = @"\delta - \Theta_{f}";
        public const string OutsideDiameterLatex = @"d_{a}";
        public const string OutsideDiameterFormulaLatex = @"d + 2h_{a}cos\delta";
        public const string PitchApexToCrownLatex = @"X";
        public const string PitchApexToCrownFormulaLatex = @"R_{e}cos\delta - h_{a}sin\delta";
        public const string AxialFaceWidthLatex = @"X_{b}";
        public const string AxialFaceWidthFormulaLatex = @"\frac{b cos\delta_{a}}{cos\Theta_{a}}";
        public const string InnerOutsideDiameterLatex = @"d_{i}";
        public const string InnerOutsideDiameterFormulaLatex = @"d_{a} - \frac{2b sin\delta_{a}}{cos\Theta_{a}}";
    }
}