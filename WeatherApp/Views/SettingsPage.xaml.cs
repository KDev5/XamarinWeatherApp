using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.ViewModels;
using Xamarin.Essentials;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = new SettingsPageViewModel();
        }

        

        private void unitsSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            bool unitPreference = Preferences.Get("Units", true);
            if (unitPreference)
            {
                unitsLabel.Text = "Metric";
            }
            else
            {
                unitsLabel.Text = "Imperial";

            }
        }

        private void ThemeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                themeLabel.Text = "Light mode";
            }
            else
            {
                themeLabel.Text = "Dark mode";
            }
        }
    }
}