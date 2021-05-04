using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace XamarinFormsLatest.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomisedClusterMapComponent : ContentView
    {

        private readonly Position currentPosition = new Position(17.3850, 78.4867);
        public CustomisedClusterMapComponent()
        {
            InitializeComponent();
            PrepareClusterMap();
            
        }

       

        //public static readonly BindableProperty ClusterPinsProperty =
        //    BindableProperty.Create(
        //        propertyName: nameof(BindablePins),
        //        returnType: typeof(List<Pin>),
        //        defaultBindingMode: BindingMode.TwoWay,
        //        defaultValue: new List<Pin>(),
        //        declaringType:typeof(CustomisedClusterMapComponent)

        //        );



        //public  List<Pin> BindablePins
        //{
        //    get => (List<Pin>)GetValue(ClusterPinsProperty);
        //    set => SetValue(ClusterPinsProperty, value);
        //}

        public List<Pin> ItemSource
        {
            get { return (List<Pin>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }
        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(
            nameof(ItemSource),
            typeof(List<Pin>),
            typeof(CustomisedClusterMapComponent),
            defaultValue: new List<Pin>(),
            defaultBindingMode: BindingMode.TwoWay);




        private void PrepareClusterMap()
        {
            ClusterMap.MoveToRegion(MapSpan.FromCenterAndRadius(currentPosition,Distance.FromMeters(100)));
            ItemSource.ForEach((p) =>
            {
                ClusterMap.Pins.Add(p);
            });
            ClusterMap.Cluster();
        }
    }
}