using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeatherMonitoring.Interfaces;
using WeatherMonitoring.Models;

namespace WeatherMonitoring.Services
{
    public class WeatherDataParser : IWeatherDataParser
    {
        public WeatherData Convert(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input data cannot be empty or null.");
            }

            input = input.Trim();

            if (input.StartsWith("{"))
            {
                try
                {
                    return JsonSerializer.Deserialize<WeatherData>(input);
                }
                catch (JsonException ex)
                {
                    throw new FormatException($"Invalid JSON format: {ex.Message}");
                }
            }
            else if (input.StartsWith("<"))
            {
                try
                {
                    var xml = XElement.Parse(input);
                    return new WeatherData
                    {
                        Location = xml.Element("Location")?.Value,
                        Temperature = double.Parse(xml.Element("Temperature")?.Value ?? "0"),
                        Humidity = double.Parse(xml.Element("Humidity")?.Value ?? "0")
                    };
                }
                catch (Exception ex)
                {
                    throw new FormatException($"Invalid XML format: {ex.Message}");
                }
            }

            throw new FormatException("Unsupported data format. Expected JSON or XML.");
        }
    }
}