//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace XamarinFormsLatest.pages
//{
//    class HelloBitmapPage
//    {
//    }
//}
//using System;

//using Xamarin.Forms;

//using SkiaSharp;
//using SkiaSharp.Views.Forms;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Xamarin.Forms;

namespace XamarinFormsLatest.pages
{
    public partial class HelloBitmapPage : ContentPage
    {

        public HelloBitmapPage()
        {
           
        }
        //public static void Page_Load()
        //{
        //    //Load the Image to be written on.
        //    Bitmap bitMapImage = new System.Drawing.Bitmap("iconspin.png");
        //    Graphics graphicImage = Graphics.FromImage(bitMapImage);

        //    //Smooth graphics is nice.
        //    graphicImage.SmoothingMode = SmoothingMode.AntiAlias;

        //    //I am drawing a oval around my text.
        //    graphicImage.DrawArc(new Pen(System.Drawing.Color.Red, 3), 90, 235, 150, 50, 0, 360);

        //    //Write your text.
        //    graphicImage.DrawString("That's", new System.Drawing.Font("Arial", 12, FontStyle.Bold), SystemBrushes.WindowText, new System.Drawing.Point(100, 250));

            
        //    //Set the content type
        //    Response.ContentType = "image/jpeg";
        //    graphicImage.
        //    //Save the new image to the response output stream.
        //    bitMapImage.Save(Response.OutputStream, ImageFormat.Png);

        //    //Clean house.
        //    graphicImage.Dispose();
        //    bitMapImage.Dispose();
        //}




























        //const string TEXT = "Hello, Bitmap!";
        //SKBitmap helloBitmap;

        //public HelloBitmapPage()
        //{
        //    Title = TEXT;

        //    // Create bitmap and draw on it
        //    using (SKPaint textPaint = new SKPaint { TextSize = 48 })
        //    {
        //        SKRect bounds = new SKRect();
        //        textPaint.MeasureText(TEXT, ref bounds);

        //        helloBitmap = new SKBitmap((int)bounds.Right,
        //                                   (int)bounds.Height);

        //        using (SKCanvas bitmapCanvas = new SKCanvas(helloBitmap))
        //        {
        //            bitmapCanvas.Clear();
        //            bitmapCanvas.DrawText(TEXT, 0, -bounds.Top, textPaint);
        //        }
        //    }

        //    // Create SKCanvasView to view result
        //    SKCanvasView canvasView = new SKCanvasView();
        //    canvasView.PaintSurface += OnCanvasViewPaintSurface;
        //    Content = canvasView;
        //}

        //void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        //{
        //    SKImageInfo info = args.Info;
        //    SKSurface surface = args.Surface;
        //    SKCanvas canvas = surface.Canvas;

        //    canvas.Clear(SKColors.Aqua);

        //    //for (float y = 0; y < info.Height; y += helloBitmap.Height)
        //    //    for (float x = 0; x < info.Width; x += helloBitmap.Width)
        //    //    {
        //    //        canvas.DrawBitmap(helloBitmap, x, y);
        //    //    }
        //}
    }
}
