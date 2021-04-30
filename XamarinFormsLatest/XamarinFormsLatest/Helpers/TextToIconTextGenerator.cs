


using System.Drawing;

namespace XamarinFormsLatest.Helpers
{
   public class TextToIconTextGenerator
    {

        public static Icon GetIcon(string text)
        {
            //Create bitmap, kind of canvas
            Bitmap bitmap = new Bitmap(32, 32);

            Icon icon = new Icon(@"Images\PomoDomo.png");
            System.Drawing.Font drawFont = new System.Drawing.Font("Calibri", 19, FontStyle.Bold);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(Color.White);

            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);

            graphics.DrawIcon(icon, 0, 0);
            graphics.DrawString(text, drawFont, drawBrush, 0, 0);

            //To Save icon to disk
            bitmap.Save("icon.png", System.Drawing.Imaging.ImageFormat.Png);

            Icon createdIcon = Icon.FromHandle(bitmap.GetHicon());

            drawFont.Dispose();
            drawBrush.Dispose();
            graphics.Dispose();
            bitmap.Dispose();

            return createdIcon;
        }
    }
}
