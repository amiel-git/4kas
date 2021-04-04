using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
    }


    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
    }


    public class WeatherRoot
    {
        public Coord coord { get; set; }
        public IList<Weather> weather { get; set; }
        public Main main { get; set; }
        public Sys sys { get; set; }
        public string name { get; set; }
    }

}
