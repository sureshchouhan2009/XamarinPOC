using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using XamarinFormsLatest.CustomControls;

namespace XamarinFormsLatest.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicMapp : ContentPage
    {
        CustomMap map;
        public BasicMapp()
        {
            map = new CustomMap
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            // You can use MapSpan.FromCenterAndRadius   
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(17.3850, 78.4867), Distance.FromMiles(0.3)));
            // or create a new MapSpan object directly  
            //map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));  
            // add the slider  
            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) =>
            {
                var zoomLevel = e.NewValue; // between 1 and 18  
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                Debug.WriteLine(zoomLevel + " -> " + latlongdegrees);
                if (map.VisibleRegion != null) map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };
            // create map style buttons  
            var street = new Button
            {
                Text = "Street"
            };
            var hybrid = new Button
            {
                Text = "Hybrid"
            };
            var satellite = new Button
            {
                Text = "Satellite"
            };
            street.Clicked += HandleClicked;
            hybrid.Clicked += HandleClicked;
            satellite.Clicked += HandleClicked;
            var segments = new StackLayout
            {
                Spacing = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = {
                        street,
                        hybrid,
                        satellite
                    }
            };
            // put the page together  
            var stack = new StackLayout
            {
                Spacing = 0
            };
            stack.Children.Add(map);
            //stack.Children.Add(slider);
            //stack.Children.Add(segments);
            Content = stack;
            // for debugging output only  
            map.PropertyChanged += (sender, e) =>
            {
                Debug.WriteLine(e.PropertyName + " just changed!");
                if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null) CalculateBoundingCoordinates(map.VisibleRegion);
            };

           
            
            map.MapClicked += Map_MapClicked;
           
            map.Pins.Add(new Pin
            {
                Label = "KTG",
                Address = "address",
                Position = new Position(latitude: 21.7705, longitude: 79.8045),
                Type = PinType.Place,
            }); 
            
            map.Pins.Add(new Pin
            {
                 
                Label = "HYD",
                Address = "hyd add",
                Position = new Position(latitude: 17.3850, longitude: 78.4867),
                Type = PinType.Generic,
                 
            }); 
            map.Pins.Add(new Pin
            {
                
                Label = "BOM",
                Address = "BOM add",
                Position = new Position(latitude:19.0896,longitude:72.8656),
                Type = PinType.Generic,
            }); 
            
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(37.79752, -122.40183),
                Label = "Xamarin San Francisco Office",
                Address = "394 Pacific Ave, San Francisco CA",
                //Name = "Xamarin",
                //Url = "http://xamarin.com/about/"
            });
        }

        private async void Map_MapClicked(object sender, MapClickedEventArgs e)
        {
            await DisplayAlert(String.Format("Selected Location"), String.Format("Lat: {0} , long: {1}", e.Position.Latitude, e.Position.Longitude), "Cancel");

        }

        void HandleClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Street":
                    map.MapType = MapType.Street;
                    break;
                case "Hybrid":
                    map.MapType = MapType.Hybrid;
                    break;
                case "Satellite":
                    map.MapType = MapType.Satellite;
                    break;
            }
        }
        /// <summary>  
        /// In response to this forum question http://forums.xamarin.com/discussion/22493/maps-visibleregion-bounds  
        /// Useful if you need to send the bounds to a web service or otherwise calculate what  
        /// pins might need to be drawn inside the currently visible viewport.  
        /// </summary>  
        static void CalculateBoundingCoordinates(MapSpan region)
        {
            // WARNING: I haven't tested the correctness of this exhaustively!  
            var center = region.Center;
            var halfheightDegrees = region.LatitudeDegrees / 2;
            var halfwidthDegrees = region.LongitudeDegrees / 2;
            var left = center.Longitude - halfwidthDegrees;
            var right = center.Longitude + halfwidthDegrees;
            var top = center.Latitude + halfheightDegrees;
            var bottom = center.Latitude - halfheightDegrees;
            // Adjust for Internation Date Line (+/- 180 degrees longitude)  
            if (left < -180) left = 180 + (180 + left);
            if (right > 180) right = (right - 180) - 180;
            // I don't wrap around north or south; I don't think the map control allows this anyway  
            Debug.WriteLine("Bounding box:");
            Debug.WriteLine(" " + top);
            Debug.WriteLine(" " + left + " " + right);
            Debug.WriteLine(" " + bottom);
        }

    }
}