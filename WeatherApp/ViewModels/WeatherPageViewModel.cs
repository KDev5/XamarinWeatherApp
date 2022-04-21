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
    class WeatherPageViewModel : BindableObject
    {
        #region fields
        //Fields --------------------------------------

        private Root weatherData;
        private Placemark weatherAdress;
        private string temperatureUnitSymbol;
        private string locationSearchQuery;

        #endregion
        #region Properties
        //Properties --------------------------------------

        public string LocationSearchQuery
        {
            get => locationSearchQuery;
            set
            {
                locationSearchQuery = value;
                OnPropertyChanged();
            }
        }

        public string TemperatureUnitSymbol
        {
            get => temperatureUnitSymbol;
            set
            {
                temperatureUnitSymbol = value;
                OnPropertyChanged();
            }
        }

        public Root WeatherData
        {
            get => weatherData;
            set
            {
                weatherData = value;
                OnPropertyChanged();
            }
        }

        public Placemark WeatherAdress
        {
            get => weatherAdress;
            set
            {
                weatherAdress = value;
                OnPropertyChanged();
            }
        }
        public Location CurrentLocation { get; set; }

        public ICommand GetWeatherData { get; }
        public ICommand GetWeatherAdress { get; }

        public ICommand GetSearchedWeatherData { get; }

        #endregion

        public WeatherPageViewModel()
        {
            GetWeatherData = new Command(LoadWeatherData);
            GetWeatherAdress = new Command(GetPlacemarkFromCoods);
            GetSearchedWeatherData = new Command(LoadSearchedWeatherData);
            //For running the method when the page appears lol
            //Uncomment this when you want to use it, so you don't waste the api usage

            Task.Run(() => LoadWeatherData());
        }


        WeatherService weatherService = new WeatherService();
        LocationService locationService = new LocationService();

        /// <summary>
        /// Fetches current GPS coordinates and then uses the lat long data to fetch weather data based on location.
        /// After that, gets placemark based on the coordinates for view display, and sets the unit symbol based on the user's preference
        /// </summary>
        async void LoadWeatherData()
        {
            try
            {
                var locationData = await locationService.GetCurrentLocationCoords();
                CurrentLocation = locationData;
                var dataFromAPI = await weatherService.GetWeatherApiData(locationData.Latitude, locationData.Longitude);
                if (dataFromAPI != null)
                {
                    WeatherData = dataFromAPI;

                    //So that it gets the coords from weatherData and loads it directly after
                    GetPlacemarkFromCoods();
                    SetUnitSymbol();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Fetches data using user search query and then converts the query to lat long data by using the Placemark class
        /// Then uses the lat long data to fetch weather data
        /// </summary>
        async void LoadSearchedWeatherData()
        {
            try
            {
                var locationData = await GetCoordsFromPlacemark();
                CurrentLocation = locationData;
                var dataFromAPI = await weatherService.GetWeatherApiData(locationData.Latitude, locationData.Longitude);
                if (dataFromAPI != null)
                {
                    WeatherData = dataFromAPI;

                    GetPlacemarkFromCoods();
                    SetUnitSymbol();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Uses the Geocoding api to convert lat long data into a Placemark variable.
        /// For use to display the weather address
        /// </summary>
        async void GetPlacemarkFromCoods()
        {
            try
            {
                var placemarks = await Geocoding.GetPlacemarksAsync(weatherData.lat, weatherData.lon);
                Placemark placemark = placemarks.FirstOrDefault();
                if (placemark != null)
                {
                    WeatherAdress = placemark;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Gets coordinates based on the Geocoding class which takes a string search query and outputs lat long coordinates
        /// </summary>
        /// <returns></returns>
        async Task<Location> GetCoordsFromPlacemark()
        {
            var coords = await Geocoding.GetLocationsAsync(locationSearchQuery);
            var coord = coords.FirstOrDefault();
            if(coords != null)
            {
                return coord;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the temperature unit symbol based on the user's set preference.
        /// </summary>
        void SetUnitSymbol()
        {
            if(Preferences.Get("Units", true))
            {
                TemperatureUnitSymbol = "°C";
            }
            else
            {
                TemperatureUnitSymbol = "°F";
            }
        }

    }
}
