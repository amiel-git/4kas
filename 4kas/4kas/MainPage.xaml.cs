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
                try
                {
                    var weatherData = await WeatherLogic.GetWeatherData();

                    tempLabel.Text = WeatherLogic.ConvertToCelcius(weatherData.main.temp).ToString();
                    tempTypeLabel.IsVisible = true;
                    conditionLabel.Text = weatherData.weather[0].main;
                    locationLabel.Text = $"{weatherData.name}, {weatherData.sys.country}";
                    weatherImage.Source = $"http://openweathermap.org/img/wn/{weatherData.weather[0].icon}@4x.png";

                    MainActivityIndicator.IsRunning = false;
                }

                catch (Exception e)
                {
                    await DisplayAlert("Problem fetching data", "Please turn your location on and restart the app", "Ok");
                }


        }


        public async void SearchWeather(object sender, EventArgs e)
        {
            MainActivityIndicator.IsRunning = true;
            string cityName = searchEntry.Text;

            var weatherData = await WeatherLogic.GetWeatherDataByCity(cityName);
            weatherImage.Source = $"http://openweathermap.org/img/wn/{weatherData.weather[0].icon}@4x.png";
            tempLabel.Text = WeatherLogic.ConvertToCelcius(weatherData.main.temp).ToString();
            tempTypeLabel.IsVisible = true;
            conditionLabel.Text = weatherData.weather[0].main;
            locationLabel.Text = $"{weatherData.name}, {weatherData.sys.country}";
            MainActivityIndicator.IsRunning = false;
        }



    }
}