using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class WeatherInfo
    {
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }

        }//end of coord class

        public class weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }

        }//end of weather class

        public class wind
        {
            public double speed { get; set; }
        }
        public class main
        {
            public double temp { get; set; }
            public string main1 { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
        }// end of main class

        public class sys
        {
            public string country { get; set; }

        }// end of sys class

        public class root
        {
            public string name { get; set; }

            public sys sys { get; set; }
           
            public double dt { get; set; }
            public wind wind { get; set; }
            public main main { get; set; }
            public List<weather> weatherList { get; set; }
            public coord coordinate { get; set; }
        }
    }
}
