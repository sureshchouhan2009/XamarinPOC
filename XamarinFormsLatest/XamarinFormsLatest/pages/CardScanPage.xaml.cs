using Plugin.PayCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsLatest.Helpers;
using XamarinFormsLatest.Interfaces;

namespace XamarinFormsLatest.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardScanPage : ContentPage
    {
        public CardScanPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var cardInfo = await CrossPayCards.Current.ScanAsync();
                CardNumberEntry.Text = cardInfo.CardNumber;
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //var data=  TextToIconTextGenerator.GetIcon("ABC");

         //var caller=   DependencyService.Get<ITextOverImage>().BitmapGeneration(); 
         //   caller.BitmapGeneration();

            //var result = data;
        }
    }
}