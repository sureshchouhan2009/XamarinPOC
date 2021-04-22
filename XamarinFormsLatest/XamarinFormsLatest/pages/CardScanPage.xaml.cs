using Plugin.PayCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}