using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherApp.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WeatherApp.Services
{
    class WeatherService
    {
        private string BASE_URL = "https://api.openweathermap.org/data/2.5/onecall?";
        private string API_KEY = "API KEY HERE";

        HttpClient client;

        public WeatherService()
        {
            client = new HttpClient();
        }

        public async Task<Root> GetWeatherApiData(double? latitude, double? longitude)
        {
            try
            {
                if (latitude != null && longitude != null)
                {
                    var json = await client.GetAsync($"{BASE_URL}lat={latitude}&lon={longitude}&appid={API_KEY}&units={selectedUnits()}");
                    if (json.IsSuccessStatusCode)
                    {
                        var content = await json.Content.ReadAsStringAsync();
                        var weatherContent = JsonConvert.DeserializeObject<Root>(content);
                        return weatherContent;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        string selectedUnits()
        {
            if (Preferences.Get("Units", true))
            {
                return "metric";
            }
            else
            {
                return "imperial";
            }
        }


    }
}
