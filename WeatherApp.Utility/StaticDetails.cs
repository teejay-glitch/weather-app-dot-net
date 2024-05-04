using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Utility
{
    public static class StaticDetails
    {
        private static readonly string apiKey = ConfigurationHelper._configuration.GetSection("WeatherApiKey:ApiKey").Value;
        public static string GetWeatherUrl(double latitude, double longitude)
        {
            return $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}";
        }
    }
}
