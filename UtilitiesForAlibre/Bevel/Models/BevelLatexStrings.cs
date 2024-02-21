namespace Bolsover.Bevel.Models
{
    public static class BevelLatexStrings
    {
        public const string ShaftAngleLatex = @"\Sigma";
        public const string ModuleLatex = @"m";
        public const string PressureAngleLatex = @"\alpha";
  
        public const string NumberOfTeethLatex = @"z_{1}, z_{2}";

        public const string FaceWidthLatex = @"b";
        public const string FaceWidthFormulaLatex = @"Should\:be\:less\:than\:R_{e}/3\:or\:10m";
 

        // Gleason spiral and zerol types
   

        // Gleason straight types
        public const string GleasonLatex = @"h_{a1} = 2.000m - h_{a2}\:, h_{a2} = 0.540m + \frac{0.460m}{\left(\frac{Z_{2}cos\delta_{1}}{Z_{1}cos\delta_{2}}\right)}\:, h_{f} = 2.188m -h_(a)";

        public const string AddendumHa2GleasonStraightFormulaLatex =
            @"h_{a2} = 0.540m + \frac{0.460m}{\left(\frac{Z_{2}cos\delta_{1}}{Z_{1}cos\delta_{2}}\right)}";

        public const string DedendumHfGleasonStraightFormulaLatex = @"h_{f} = 2.188m -h_(a)";

        // Standard types
        public const string StandardLatex = @"h_{a} = 1.000m\:, h_{f} = 1.25m";
       
      

    }
}