using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoring.Models.Enums;

namespace WeatherMonitoring.Interfaces
{
    public interface IWeatherBotFactory
    {
            IWeatherBotObserver CreateBot(WeatherBots botType);
    }
}
