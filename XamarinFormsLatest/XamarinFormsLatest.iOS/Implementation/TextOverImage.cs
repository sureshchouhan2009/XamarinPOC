using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace XamarinFormsLatest.iOS.Implementation
{
   public class TextOverImage
    {
        public static UIImage DrawText(UIImage uiImage, string sText, UIColor textColor, int iFontSize)
        {
            nfloat fWidth = uiImage.Size.Width;
            nfloat fHeight = uiImage.Size.Height;

            CGColorSpace colorSpace = CGColorSpace.CreateDeviceRGB();

            using (CGBitmapContext ctx = new CGBitmapContext(IntPtr.Zero, (nint)fWidth, (nint)fHeight, 8, 4 * (nint)fWidth, CGColorSpace.CreateDeviceRGB(), CGImageAlphaInfo.PremultipliedFirst))
            {
                ctx.DrawImage(new CGRect(0, 0, (double)fWidth, (double)fHeight), uiImage.CGImage);

                ctx.SelectFont("Helvetica", iFontSize, CGTextEncoding.MacRoman);

                //Measure the text's width - This involves drawing an invisible string to calculate the X position difference
                float start, end, textWidth;

                //Get the texts current position
                start = (float)ctx.TextPosition.X;
                //Set the drawing mode to invisible
                ctx.SetTextDrawingMode(CGTextDrawingMode.Invisible);
                //Draw the text at the current position
                ctx.ShowText(sText);
                //Get the end position
                end = (float)ctx.TextPosition.X;
                //Subtract start from end to get the text's width
                textWidth = end - start;

                nfloat fRed;
                nfloat fGreen;
                nfloat fBlue;
                nfloat fAlpha;
                //Set the fill color to black. This is the text color.
                textColor.GetRGBA(out fRed, out fGreen, out fBlue, out fAlpha);
                ctx.SetFillColor(fRed, fGreen, fBlue, fAlpha);

                //Set the drawing mode back to something that will actually draw Fill for example
                ctx.SetTextDrawingMode(CGTextDrawingMode.Fill);

                //Draw the text at given coords.
                ctx.ShowTextAtPoint(8, 17, sText);

                return UIImage.FromImage(ctx.ToImage());
            }
        }





    }
}