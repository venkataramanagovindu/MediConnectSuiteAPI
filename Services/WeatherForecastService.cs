using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices;

namespace Services
{
    public class WeatherForecastService: IWeatherForeCast
    {
        public string GetString()
        {
            var str = String.Empty;
            throw new NotImplementedException();
        }

    }
}
