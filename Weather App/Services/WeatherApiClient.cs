using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Windows;
using Weather_App.Model;

namespace Weather_App.Services
{    
    //http://api.openweathermap.org/data/2.5/weather?q=baku&appid=5a4ce2a8ae57aa2b133298afe95c08f9&units=metric
    
    class WeatherApiClient : IWeatherApiClient
    {
        private readonly ILogger logger;
        private readonly WebClient webClient;

        private string apiId = "5a4ce2a8ae57aa2b133298afe95c08f9";
        private string units = "metric";
        private string apiUrl = "http://api.openweathermap.org/data/2.5";
        public WeatherApiClient(ILogger logger)
        {
            this.logger = logger;
            webClient = new WebClient();
        }

        public Forecast GetForecastByCityName(string cityName)
        {
            try
            {
                var json = webClient.DownloadString($"{apiUrl}/weather?q={cityName}&appid={apiId}&units={units}");
                var forecast = JsonSerializer.Deserialize<Forecast>(json, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return forecast;
            }
            catch (Exception e)
            {
                logger.LogError("Internet connection problem", e);
                throw;
            }
        }

        public Forecast GetForecastByGeoLocation(double latitude, double longitude)
        {
            try
            {
                var json = webClient.DownloadString($"{apiUrl}/weather?lat={latitude}&lon={longitude}&appid={apiId}&units={units}");
                var forecast = JsonSerializer.Deserialize<Forecast>(json, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return forecast;
            }
            catch (Exception e)
            {
                logger.LogError("Internet connection problem", e);
                throw;
            }
        }
    }
}
