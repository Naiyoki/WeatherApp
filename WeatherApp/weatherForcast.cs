using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class weatherForcast
    {
        public city city { get; set; }
        public List<list> list { get; set; }//forcast list
    }

    public class temp
    {
        public double day { get; set; }
    }
    public class weather
    {
        public string main { get; set; }
        public string description { get; set; }
    }
    public class city
    {
        public string name { get; set; }
    }
    public class list
    {
        public double dt { get; set; }// day in milliseconds
        public double pressure { get; set; }// pressure in hpa
        public double humidity { get; set; }// humidity in percentage
        public double speed { get; set; }// wind speed in km/h
        public temp temp { get; set; }
        public List<weather> weather { get; set; }// weather list
    }
}
