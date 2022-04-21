using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.ViewModels;
using Rg.Plugins.Popup.Extensions;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            //BindingContext is for telling the view what viewmodel to use?
            //Basically for telling the xaml where it'll get its "Binding" from
            BindingContext = new WeatherPageViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new SearchPage());
        }

        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new SearchPage());
        }

        private void DrawerButton_Clicked(object sender, EventArgs e)
        {

        }

        //protected override void OnAppearing()
        //{

        //    base.OnAppearing();
        //    WeatherPageViewModel context = new WeatherPageViewModel();

        //}
    }
}