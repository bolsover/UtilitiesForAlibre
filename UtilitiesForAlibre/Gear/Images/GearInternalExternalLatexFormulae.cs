using System.Drawing;
using System.IO;
using WpfMath;
using WpfMath.Parsers;
using XamlMath;

namespace Bolsover.Gear.Images
{
    public class GearInternalExternalLatexFormulae
    {
        public const string ModuleSymbol = @"m";
        public const string NormalModuleSymbol = @"m_{n}";
        public const string PressureAngleSymbol = @"\alpha";
        public const string InvoluteFunctionSymbol = @"inv\alpha_{w}";
        public const string InvoluteAlphaFunctionFormula = @"tan\alpha-\alpha";
        public const string InvoluteFunctionFormula = @"2\,tan\alpha\left(\frac{x_{2}-x_{1}}{z_{2}-z_{1}}\right)+ inv\alpha";
        public const string WorkingPressureAngleSymbol = @"\alpha_{w}";
        public const string WorkingPressureAngleFormula = @"From\,  involute\,  function\,  table\\";
        public const string CentreDistanceIncrementFactorSymbol = @"y";

        public const string CentreDistanceIncrementFactorFormula =
            @"\frac{z_{2}-z_{1}}{2}\left(\frac{cos\alpha}{cos\alpha_{w}}-1\right)";

        public const string CentreDistanceSymbol = @"a_{x}";
        public const string CentreDistanceFormula = @"\left(\frac{z_{2}-z_{1}}{2}+y\right)m";
        public const string CoefficientOfProfileShiftSymbol = @"x_{1}, x_{2}";
        public const string SpiralAngleSymbol = @"\beta";
        public const string RadialPressureAngleSymbol = @"\alpha_{t}";
        public const string NumberOfTeethSymbol = @"z_{1}, z_{2}";
        public const string PitchDiameterSymbol = @"d";
        public const string PitchDiameterFormula = @"zm";
        public const string BaseCircleDiameterSymbol = @"d_{b}";
        public const string BaseCircleDiameterFormula = @"d\,cos\alpha";
        public const string WorkingPitchDiameterSymbol = @"d_{w}";
        public const string WorkingPitchDiameterFormula = @"\frac{d_{b}}{cos\alpha_{w}}";
        public const string Addendum1Symbol = @"h_{a1}";
        public const string Addendum2Symbol = @"h_{a2}";
        public const string Addendum1Formula = @"\left( 1 + x_{1}\right)m";
        public const string Addendum2Formula = @"\left( 1 - x_{2}\right)m";
        public const string WholeDepthSymbol = @"h";
        public const string WholeDepthFormula = @"2.25m";
        public const string OutsideDiameter1Symbol = @"d_{a1}";
        public const string OutsideDiameter1Formula = @"d_{1}+2h_{a1}";
        public const string OutsideDiameter2Symbol = @"d_{a2}";
        public const string OutsideDiameter2Formula = @"d_{2}-2h_{a2}";
        public const string RootDiameter1Symbol = @"d_{f1}";
        public const string RootDiameter1Formula = @"d_{a1}-2h";
        public const string RootDiameter2Symbol = @"d_{f2}";
        public const string RootDiameter2Formula = @"d_{a2}+2h";


        private static readonly TexFormulaParser Parser = WpfTeXFormulaParser.Instance;


        private static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            try
            {
                var ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                returnImage = Image.FromStream(ms, true, false); //Exception occurs here
            }
            catch
            {
            }

            return returnImage;
        }


        public static Image CreateImageFromLatex(string latex)
        {
            var formula = Parser.Parse(latex);
            var pngBytes = formula.RenderToPng(15.0, 0.0, 0.0, "Cambria");

            return ByteArrayToImage(pngBytes);
        }
    }
}