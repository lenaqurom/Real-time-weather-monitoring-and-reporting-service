using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherMonitoring.Interfaces;
using WeatherMonitoring.Models;

namespace WeatherMonitoring.Services
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Convert(string input)
        {
            return JsonSerializer.Deserialize<WeatherData>(input);
        }
    }
}
