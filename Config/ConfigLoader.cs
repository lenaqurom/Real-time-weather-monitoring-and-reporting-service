using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Text.Json;
using WeatherMonitoring.Models;
using WeatherMonitoring.Models.Enums;

namespace WeatherMonitoring.Configuration
{
    public static class ConfigLoader
    {
        public static Dictionary<WeatherBots, BotConfig> LoadFromFile(string filePath)
        {
            var result = new Dictionary<WeatherBots, BotConfig>();

            try
            {
                var json = File.ReadAllText(filePath);
                var Configs = JsonConvert.DeserializeObject<Dictionary<string, BotConfig>>(json);

                foreach (var x in Configs)
                {
                    if (Enum.TryParse(x.Key, out WeatherBots botType))
                    {
                        result[botType] = x.Value;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: The file at path '{filePath}' was not found. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return result;
        }
    }
}
