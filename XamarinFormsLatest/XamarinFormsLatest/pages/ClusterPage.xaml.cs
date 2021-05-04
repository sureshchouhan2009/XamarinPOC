using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Clustering;
using Xamarin.Forms.Xaml;
using XamarinFormsLatest.Interfaces;

namespace XamarinFormsLatest.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClusterPage
    {
        private const int ClusterItemsCount = 100;
        private const double Extent = 0.2;
       
        
        private readonly Position currentPosition= new Position(17.3850, 78.4867);

        

        private readonly Random random = new Random();

        public ClusterPage()
        {
            InitializeComponent();

            //mainStack.Children.Add(stackLayout);



            Map.MoveToRegion(MapSpan.FromCenterAndRadius(currentPosition, Distance.FromMeters(100)));

            for (var i = 0; i <= ClusterItemsCount; i++)
            {
                var lat = currentPosition.Latitude + Extent * GetRandomNumber(-1.0, 1.0);
                var lng = currentPosition.Longitude + Extent * GetRandomNumber(-1.0, 1.0);
                //  var iconimg = DependencyService.Get<ITextOverImage>().BitmapGeneration();
                ContentView contentView = new ContentView();
                contentView.BackgroundColor = Color.Transparent;
                Image iconImage1 = new Image
                {

                    Source = "iconspin.png",
                    HeightRequest = 40,
                    WidthRequest = 20,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                };
                Label iconLabel = new Label
                {
                    Text = "Day",
                    BackgroundColor = Color.Yellow,
                    FontSize = 12,
                    TextColor = Color.Black,
                };


                contentView.HeightRequest = 50;
                contentView.WidthRequest = 25;
                StackLayout stackLayout = new StackLayout();
                stackLayout.Orientation = StackOrientation.Vertical;
                stackLayout.Padding = 0;
                stackLayout.Children.Add(iconLabel);
                stackLayout.Children.Add(iconImage1);
                contentView.Content = stackLayout;

                Map.Pins.Add(new Pin()
                {
                    Position = new Position(lat, lng),
                    Label = $"Item {i}",
                    //Icon = BitmapDescriptorFactory.FromBundle("image01.png")
                    //Icon = BitmapDescriptorFactory.FromView(contentView)
                    //Icon = BitmapDescriptorFactory.DefaultMarker(Color.GreenYellow),
                    Icon = BitmapDescriptorFactory.FromBundle("iconspin.png")
                    
                });
            }

            Map.PinClicked += MapOnPinClicked;
            Map.ClusterClicked += MapOnClusterClicked;
            Map.InfoWindowClicked += MapOnInfoWindowClicked;
            Map.InfoWindowLongClicked += MapOnInfoWindowLongClicked;

            Map.Cluster();

            
        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new CalendarPopup(pagedate:DateTime.Now,false));

            //await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.(new CalendarPopup());
        }

        private async void MapOnClusterClicked(object sender, ClusterClickedEventArgs e)
        {
            await DisplayAlert("Cluster clicked", $"{e.ItemsCount} pins \n{e.Position.Latitude} {e.Position.Longitude}", "Cancel");
        }

        private async void MapOnPinClicked(object sender, PinClickedEventArgs e)
        {
            await DisplayAlert("Pin clicked", e.Pin?.Label, "Cancel");
        }

        private async void MapOnInfoWindowClicked(object sender, InfoWindowClickedEventArgs e)
        {
            await DisplayAlert("Info clicked", $"{e.Pin?.Position.Latitude} {e.Pin?.Position.Longitude}", "Cancel");
        }

        private async void MapOnInfoWindowLongClicked(object sender, InfoWindowLongClickedEventArgs e)
        {
            await DisplayAlert("Info long clicked", $"{e.Pin?.Position.Latitude} {e.Pin?.Position.Longitude}", "Cancel");
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
          await  Navigation.PushAsync(new BasicMapp());
        }
    }
}