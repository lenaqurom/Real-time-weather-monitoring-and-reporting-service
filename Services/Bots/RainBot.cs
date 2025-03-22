using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoring.Interfaces;
using WeatherMonitoring.Models;

namespace WeatherMonitoring.Services.Bots
{
    public class RainBot : IWeatherBotObserver
    {
        private readonly double _threshold;
        private readonly string _message;

        public RainBot(double threshold, string message)
        {
            _threshold = threshold;
            _message = message;
        }
        public void Activate(WeatherData data)
        {
            if (data.Humidity > _threshold)
            {
                Console.WriteLine("RainBot activated");
                Console.WriteLine(_message);
            }
        }
    }
}
