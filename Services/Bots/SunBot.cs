using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoring.Interfaces;
using WeatherMonitoring.Models;

namespace WeatherMonitoring.Services.Bots
{
    public class SunBot : IWeatherBotObserver
    {
        private readonly double _threshold;
        private readonly string _message;

        public SunBot(double threshold, string message)
        {
            _threshold = threshold;
            _message = message;
        }
        public void Activate(WeatherData data)
        {
            if (data.Temperature > _threshold)
            {
                Console.WriteLine("SunBot activated");
                Console.WriteLine(_message);
            }
        }
    }
}
