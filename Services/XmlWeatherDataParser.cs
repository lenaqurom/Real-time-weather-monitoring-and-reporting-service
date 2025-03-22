using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeatherMonitoring.Interfaces;
using WeatherMonitoring.Models;

namespace WeatherMonitoring.Services
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Convert(string input)
        {
            var xml = XElement.Parse(input);
            return new WeatherData
            {
                Location = xml.Element("Location")?.Value,
                Temperature = double.Parse(xml.Element("Temperature")?.Value ?? "0"),
                Humidity = double.Parse(xml.Element("Humidity")?.Value ?? "0")
            };
        }
    }
}
