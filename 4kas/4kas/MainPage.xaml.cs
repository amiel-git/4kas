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
                locationLabel.Text = weatherData.sys.country;

                MainActivityIndicator.IsRunning = false;
            }

            catch(Exception e)
            {
                await DisplayAlert("Problem fetching data", e.Message, "Ok");
            }


        }




    }
}