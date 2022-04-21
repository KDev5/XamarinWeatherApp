using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Diagnostics;

namespace WeatherApp.Services
{
    class LocationService
    {
        CancellationTokenSource cts;
        public LocationService()
        {
            
        }



        //Code is taken from microsoft documentation
        public async Task<Location> GetCurrentLocationCoords()
        {
            try
            {
                try
                {

                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    cts = new CancellationTokenSource();
                    var location = await Geolocation.GetLocationAsync(request, cts.Token);

                    if (location != null)
                    {
                        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                        return location;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Debug.WriteLine(fnsEx);
                return null;
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                Debug.WriteLine(fneEx);
                return null;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Debug.WriteLine(pEx);
                return null;
            }
            catch (Exception ex)
            {
                // Unable to get location
                Debug.WriteLine(ex);
                return null;
            }
            return null;
        }

    }
}
