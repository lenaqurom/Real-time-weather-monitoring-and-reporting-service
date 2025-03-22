using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoring.Models;

namespace WeatherMonitoring.Interfaces
{
    public interface IWeatherDataParser
    {
        WeatherData Convert(string input);
    }
}
