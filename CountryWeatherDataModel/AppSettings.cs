using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryWeatherDataModel
{
    public class AppSettings
    {
        public string SecretKey { get; set; }
        public string OpenWeatherApiUri { get; set; }
        public string OpenWeatherMapKey { get; set; }
    }
}
