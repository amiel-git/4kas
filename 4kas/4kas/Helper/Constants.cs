using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public class Constants
    {
        public static string token = "e0e0f8904bb4755a17c64418355c7cca";
        public static string baseURL = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}";
        public static string baseURLByCity = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}";


        public string GetURL(double lat, double lon)
        {
            return string.Format(baseURL, lat, lon, token);
        }

        public string GetURLByCity(string city)
        {
            return string.Format(baseURLByCity,city, token);
        }
    }



}
