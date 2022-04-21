using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Services;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Linq;

namespace WeatherApp.ViewModels
{
    class SettingsPageViewModel : BindableObject
    {
        public bool IsMetricUnits
        {
            get => Preferences.Get("Units", false);
            set
            {
                Preferences.Set("Units", value);
                OnPropertyChanged();
            }
        }

        public string isMetricUnitsLabel;
        public string IsMetricUnitsLabel
        {
            get => isMetricUnitsLabel;
            set
            {
                isMetricUnitsLabel = value;
                OnPropertyChanged();

            }
        }

        public SettingsPageViewModel()
        {
            if (Preferences.Get("Units", true))
            {

                IsMetricUnitsLabel = "Metric";
            }

            else
            {
                IsMetricUnitsLabel = "Imperial";
            }
        }


    }
}
