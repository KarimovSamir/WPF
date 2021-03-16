using System;
using System.Collections.Generic;
using System.Text;
using Weather_App.Model;

namespace Weather_App.Services
{
    interface IWeatherApiClient
    {
        Forecast GetForecastByCityName(string cityName);
        Forecast GetForecastByGeoLocation(double latitude, double longitude);

    }
}
