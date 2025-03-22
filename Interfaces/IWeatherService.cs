using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoring.Interfaces
{
    public interface IWeatherService
    {
        void ProcessWeatherData(string inputData, IWeatherDataParser Convert);
    }
}
