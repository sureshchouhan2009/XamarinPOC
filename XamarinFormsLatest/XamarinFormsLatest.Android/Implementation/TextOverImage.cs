

using Android.Content;
using Android.Graphics;
using System;
using System.IO;
using Xamarin.Forms;
using XamarinFormsLatest.Droid.Implementation;
using XamarinFormsLatest.Interfaces;

[assembly: Dependency(typeof(TextOverImage))]
namespace XamarinFormsLatest.Droid.Implementation
{

    public class TextOverImage: ITextOverImage
    {
      //string  sCacheFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string sCardFileName = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myimage.jpg");
        Context _cContext = Android.App.Application.Context;
        private string _sFirstName = "Suresh";
        private string _sLastName = "chouhan";
        private int iDrawableID = 2131165318;
        private string _sVkrNumber = "5123456789012346";

        public void BitmapGeneration()
        {
            string sMemberName = this._sFirstName + " " + this._sLastName;

            int iCardLimit = 29;
            int iNameLimit = 28;

            var test = BitmapFactory.DecodeResource(this._cContext.Resources, Resource.Drawable.iconspin);

            using (Bitmap bmCard = test.Copy(Bitmap.Config.Argb8888, true))
            {
                float fScale = this._cContext.Resources.DisplayMetrics.Density;

                Canvas cCanvas = new Canvas(bmCard);
                cCanvas.Save();

                float py = bmCard.Height / 2.0f;
                float px = bmCard.Width / 2.0f;
                //cCanvas.Rotate(90, px, py);

                //card number
                Paint pCardNumberPaint = new Paint(PaintFlags.AntiAlias);
                pCardNumberPaint.SetStyle(Paint.Style.Fill);
                pCardNumberPaint.Color = Android.Graphics.Color.Black;
                pCardNumberPaint.TextSize = 60 * fScale;

                string sCardSpaces = " ";
                if ((iCardLimit) > this._sVkrNumber.Length)
                {
                    sCardSpaces = new String(' ', iCardLimit - this._sVkrNumber.Length);
                }
                Android.Graphics.Rect rCardNumberBounds = new Android.Graphics.Rect();
                string sCardNumberText = sCardSpaces + this._sVkrNumber;
                pCardNumberPaint.GetTextBounds(sCardNumberText, 0, sCardNumberText.Length, rCardNumberBounds);
                int iCardNumberX = (int)((bmCard.Width - rCardNumberBounds.Width()) / 2);
                int iCardNumberY = (int)((bmCard.Height + rCardNumberBounds.Height()) * .2);
                cCanvas.DrawText(sCardNumberText, iCardNumberX, iCardNumberY, pCardNumberPaint);

                //member name
                Paint pMemberNamePaint = new Paint(PaintFlags.AntiAlias);
                pMemberNamePaint.SetStyle(Paint.Style.Fill);
                pMemberNamePaint.Color = Android.Graphics.Color.Black;
                pMemberNamePaint.TextSize = 40 * fScale;

                if (sMemberName.Length > (iNameLimit - 3))
                {
                    sMemberName = sMemberName.Substring(0, iNameLimit) + "...";
                }

                Android.Graphics.Rect rMemberNameBounds = new Android.Graphics.Rect();
                string sMemberNameText = "  " + sMemberName;
                pCardNumberPaint.GetTextBounds(sMemberNameText, 0, sMemberNameText.Length, rMemberNameBounds);
                int iMemberNameX = 0;
                int iMemberNameY = (int)((bmCard.Height + rMemberNameBounds.Height()) * .2);
                cCanvas.DrawText(sMemberNameText, iMemberNameX, iMemberNameY, pMemberNamePaint);

                if (File.Exists(sCardFileName))
                {
                    File.Delete(sCardFileName);
                }

                using (FileStream swStreamWriter = File.Create(sCardFileName))
                {
                    bmCard.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 80, swStreamWriter);
                    swStreamWriter.Flush();
                }

                bmCard.Recycle();
                // MemoryCacheImage();
            }
        }



    }
}