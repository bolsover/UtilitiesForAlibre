using System.Drawing;
using System.IO;
using WpfMath;
using WpfMath.Parsers;
using XamlMath;

namespace Bolsover.Utils
{
    public class LatexUtils
    {
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