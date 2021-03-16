using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Weather_App.Model;

namespace Weather_App.Services
{
    class ForecastStorage : IForecastStorage
    {
        private List<Forecast> forecasts = new List<Forecast>();
        private const string FileName = "forecasts.json";
        private readonly ILogger logger;

        public ForecastStorage(ILogger logger)
        {
            Load();
            this.logger = logger;
        }

        public void AddForecast(Forecast forecast)
        {
            forecasts.Add(forecast);
            Save();
        }

        public IEnumerable<Forecast> GetAllForecast()
        {
            return forecasts;
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(forecasts);
            File.WriteAllText(FileName, json);
        }

        private void Load()
        {
            if(File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                forecasts = JsonSerializer.Deserialize<List<Forecast>>(json);
            }
        }
    }
}
