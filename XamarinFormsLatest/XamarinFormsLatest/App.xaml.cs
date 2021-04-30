using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsLatest.pages;

namespace XamarinFormsLatest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new TabbedPage()
            //{
            //    Children =
            //    {
            //        new MapsPage(),
            //        new PinPage(),
            //        new MapsApi()
            //    }
            //};
              MainPage = new CalendarPage();
            //MainPage = new ClusterPage();
            //MainPage = new HelloBitmapPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts  
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps  
        }

        protected override void OnResume()
        {
            // Handle when your app resumes  
        }
    }
}
