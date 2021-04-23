using Android.App;
using Android.Content;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
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
            marker.SetIcon(BitmapDescriptorFactory.FromResource(2131165318));
            return marker;
        }
    }
}