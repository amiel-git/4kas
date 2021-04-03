using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Helper;
using Helper.Logic;
using System.Net.Http;
using Newtonsoft.Json;
using Models;

namespace _4kas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var weatherData = await GetWeatherData();

            tempLabel.Text = ConvertToCelcius(weatherData.main.temp).ToString();
            tempTypeLabel.IsVisible = true;
            conditionLabel.Text = weatherData.weather[0].main;
            locationLabel.Text = weatherData.sys.country;


        }


        private int ConvertToCelcius(double temp)
        {
            return Convert.ToInt32(temp - 273.15);
        }

        private async Task<string> ConstructURL()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var url = new Constants().GetURL(position.Latitude,position.Longitude);

            return url;
        }

        private async Task<WeatherRoot> GetWeatherData()
        {
            string url = await ConstructURL();
            WeatherRoot weatherData = new WeatherRoot();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();

                    weatherData = JsonConvert.DeserializeObject<WeatherRoot>(json);

                    
                }
            }
            catch(Exception e)
            {
                await DisplayAlert("Error Fetching Weather Data", e.Message, "Ok");
            }

            return weatherData;

        }

    }
}
