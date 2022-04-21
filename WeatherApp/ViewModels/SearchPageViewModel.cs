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
using System.ComponentModel;

namespace WeatherApp.ViewModels
{
    class SearchPageViewModel : BindableObject, INotifyPropertyChanged
    {
        private string searchLocationInput;
        public string SearchLocationInput
        {
            get => searchLocationInput;
            set
            {
                searchLocationInput = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetSearchedLocation { get; }
        public ICommand GetCurrentLocation { get; }
        public Location CurrentLocation { get; set; }


        WeatherService weatherService = new WeatherService();
        LocationService locationService = new LocationService();

        public SearchPageViewModel()
        {

        }

        //async void LoadSearchedLocation()
        //{

        //}



        

    }
}
