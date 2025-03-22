using WeatherMonitoring.Configuration;
using WeatherMonitoring.Interfaces;
using WeatherMonitoring.Models;
using WeatherMonitoring.Services;
using WeatherMonitoring.Utilities;

namespace WeatherMonitoring
{
    public class Program
    {
        static void Main(string[] args)
        {
            var configPath = "C:\\Users\\ZBOOK\\source\\repos\\WeatherMonitoring\\Config\\botconfig.json";

            var botConfigs = ConfigLoader.LoadFromFile(configPath);
            var botFactory = new WeatherBotFactory(botConfigs);
            var bots = botConfigs.Keys.Where(botType => botConfigs[botType].Enabled).Select(botFactory.CreateBot).ToList();

            var weatherService = new WeatherService(bots);
            var jsonConverter = new JsonWeatherDataParser();
            var xmlConverter = new XmlWeatherDataParser();
            var menu = new MainMenu(weatherService, jsonConverter, xmlConverter);
            menu.ShowMenu();
        }
    }
}