using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoring.Interfaces;
using WeatherMonitoring.Services.Bots;
using WeatherMonitoring.Models.Enums;
using WeatherMonitoring.Models;

namespace WeatherMonitoring.Services
{
    public class WeatherBotFactory : IWeatherBotFactory
    {
        private readonly Dictionary<WeatherBots, BotConfig> _config;

        public WeatherBotFactory(Dictionary<WeatherBots, BotConfig> botConfigurations)
        {
            _config = botConfigurations;
        }
        public IWeatherBotObserver CreateBot(WeatherBots botType)
        {
            if (!_config.ContainsKey(botType))
                throw new ArgumentException("Invalid bot type");

            var config = _config[botType];
            if (!config.Enabled) return null;

            return botType switch
            {
                WeatherBots.RainBot => new RainBot(config.Threshold, config.Message),
                WeatherBots.SunBot => new SunBot(config.Threshold, config.Message),
                WeatherBots.SnowBot => new SnowBot(config.Threshold, config.Message),
                _ => throw new ArgumentException("Invalid bot type")
            };
        }
    }
}
