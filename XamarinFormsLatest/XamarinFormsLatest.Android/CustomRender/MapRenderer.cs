using Android.App;
using Android.Content;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using XamarinFormsLatest.CustomControls;
using XamarinFormsLatest.Droid.CustomRender;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]

namespace XamarinFormsLatest.Droid.CustomRender
{
    public class CustomMapRenderer : MapRenderer
    {
        public CustomMapRenderer(Context context) : base(context)
        {


        }


        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                
                // Unsubscribe from event handlers
            }

            if (e.NewElement != null)
            {
                // Configure the native control and subscribe to event handlers
            }
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);//iconspin.png
            var fg = BitmapDescriptorFactory.FromPath(BitmapGeneration());//.FromBitmap(BitmapGeneration());
            marker.SetIcon(fg);
            //marker.SetIcon(BitmapDescriptorFactory.FromResource(2131165318));
            return marker;
        }

         string sCardFileName = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myimage.jpg");
        Context _cContext = Android.App.Application.Context;
        private string _sFirstName = "Suresh";

        public String BitmapGeneration()
        {
            string sMemberName = this._sFirstName;
            

            var test = BitmapFactory.DecodeResource(this._cContext.Resources, Resource.Drawable.iconspin);

            using (Bitmap bmCard = test.Copy(Bitmap.Config.Argb8888, true))
            {
                float fScale = this._cContext.Resources.DisplayMetrics.Density;
                
                Canvas cCanvas = new Canvas(bmCard);
                cCanvas.Save();

                float py = bmCard.Height / 2.0f;
                float px = bmCard.Width / 2.0f;

                
                //member name
                Paint pMemberNamePaint = new Paint(PaintFlags.AntiAlias);
                pMemberNamePaint.SetStyle(Paint.Style.Fill);
                pMemberNamePaint.Color = Android.Graphics.Color.Red;
                pMemberNamePaint.TextSize = 20 * fScale;
                //if (sMemberName.Length > (iNameLimit - 3))
                //{
                //    sMemberName = sMemberName.Substring(0, iNameLimit) + "...";
                //}

                Android.Graphics.Rect rMemberNameBounds = new Android.Graphics.Rect();
                string sMemberNameText = sMemberName;
               // pCardNumberPaint.GetTextBounds(sMemberNameText, 0, sMemberNameText.Length, rMemberNameBounds);
                int iMemberNameX = 0;
                int iMemberNameY = (int)((bmCard.Height + rMemberNameBounds.Height()) * .2);
                cCanvas.DrawText(sMemberNameText, iMemberNameX, iMemberNameY, pMemberNamePaint);

                //if (File.Exists(sCardFileName))
                //{
                //    File.Delete(sCardFileName);
                //}

                using (FileStream swStreamWriter = File.Create(sCardFileName))
                {
                    bmCard.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 80, swStreamWriter);
                    swStreamWriter.Flush();
                }

                return sCardFileName;
            }

        }
    }
}
