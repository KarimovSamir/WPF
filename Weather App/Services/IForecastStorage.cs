using System;
using System.Collections.Generic;
using System.Text;
using Weather_App.Model;

namespace Weather_App.Services
{
    interface IForecastStorage
    {
        void AddForecast(Forecast forecast);

        IEnumerable<Forecast> GetAllForecast();
    }
}
