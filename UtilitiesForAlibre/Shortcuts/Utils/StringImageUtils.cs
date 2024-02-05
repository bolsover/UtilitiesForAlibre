using System.Drawing;
using System.IO;

namespace Bolsover.Shortcuts.Utils
{
    public class StringImageUtils

    {
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

        public static Image ConvertTextToPngImage(string text, string fontName, int fontSize, Color bgColor, Color fgColor)
        {
            // Create a bitmap with the size of the text
            SizeF textSize;
            using (Graphics g = Graphics.FromImage(new Bitmap(1, 1)))
            {
                textSize = g.MeasureString(text, new Font(fontName, fontSize));
            }

            Bitmap bmp = new Bitmap((int) textSize.Width, (int) textSize.Height);

            // Draw the text on the bitmap
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(bgColor); // Fill the background
                g.DrawString(text, new Font(fontName, fontSize), new SolidBrush(fgColor), 0, 0); // Draw the text
                g.Flush(); // Apply the changes
            }

            // Save the bitmap to a memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // You can choose other formats too
                byte[] bytes = ms.ToArray();
                return ByteArrayToImage(bytes); // Return the image
            }
        }
    }
}