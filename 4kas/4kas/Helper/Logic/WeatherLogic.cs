using Models;
using Newtonsoft.Json;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Logic
{
    public static class WeatherLogic
    {
        public static int ConvertToCelcius(double temp)
        {
            return Convert.ToInt32(temp - 273.15);
        }

        public static async Task<string> ConstructURL()
        {
            string url = "";
            var locator = CrossGeolocator.Current;

            if (locator.IsGeolocationAvailable)
            {
                var position = await locator.GetPositionAsync();

                url = new Constants().GetURL(position.Latitude, position.Longitude);
            }

            return url;
        }

        public static async Task<WeatherRoot> GetWeatherData()
        {
            string url = await ConstructURL();
            WeatherRoot weatherData = new WeatherRoot();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                weatherData = JsonConvert.DeserializeObject<WeatherRoot>(json);


            }
            
            return weatherData;

        }

        public static async Task<WeatherRoot> GetWeatherDataByCity(string city)
        {
            string url = new Constants().GetURLByCity(city);
            WeatherRoot weatherData = new WeatherRoot();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                weatherData = JsonConvert.DeserializeObject<WeatherRoot>(json);


            }

            return weatherData;

        }
    }
}
