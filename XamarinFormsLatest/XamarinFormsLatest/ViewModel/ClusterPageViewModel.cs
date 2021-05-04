using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms.GoogleMaps;

namespace XamarinFormsLatest.ViewModel
{
    public class ClusterPageViewModel : ViewModelBase
    {

        private const int ClusterItemsCount = 100;
        private const double Extent = 0.2;


        private readonly Position currentPosition = new Position(17.3850, 78.4867);
        private readonly Random random = new Random();

        private List<Pin> _clusterPins = new List<Pin>();
        public List<Pin> ClusterPins
        {
            get { return _clusterPins; }
            set { SetProperty(ref _clusterPins, value); }
        }
       

        public ClusterPageViewModel()
        {
            _clusterPins = FillPinsdata();
        }

        private List<Pin> FillPinsdata()
        {
            List<Pin> lstpins = new List<Pin>();
            for (var i = 0; i <= ClusterItemsCount; i++)
            {
                var lat = currentPosition.Latitude + Extent * GetRandomNumber(-1.0, 1.0);
                var lng = currentPosition.Longitude + Extent * GetRandomNumber(-1.0, 1.0);
                


                lstpins.Add(new Pin()
                {
                    Position = new Position(lat, lng),
                    Label = $"Item {i}",
                    //Icon = BitmapDescriptorFactory.FromBundle("image01.png")
                    //Icon = BitmapDescriptorFactory.FromView(contentView)
                    //Icon = BitmapDescriptorFactory.DefaultMarker(Color.GreenYellow),
                    Icon = BitmapDescriptorFactory.FromBundle("iconspin.png")
                });
            }

            return lstpins;

        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

      
    }
}
