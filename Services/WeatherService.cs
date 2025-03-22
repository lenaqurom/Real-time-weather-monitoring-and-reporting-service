using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoring.Interfaces;
using WeatherMonitoring.Models;
using WeatherMonitoring.Models.Enums;

namespace WeatherMonitoring.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly List<IWeatherBotObserver> _bots;

        public WeatherService(List<IWeatherBotObserver> bots)
        {
            _bots = bots;
        }

        public void ProcessWeatherData(string inputData, IWeatherDataParser converter)
        {
            var data = converter.Convert(inputData);
            NotifyBots(data);
        }

        private void NotifyBots(WeatherData data)
        {
            foreach (var bot in _bots)
            {
                if (bot != null)
                {
                    bot.Activate(data);
                }
            }
        }
    }
}
