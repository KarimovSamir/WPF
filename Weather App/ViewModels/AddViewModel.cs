using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using Weather_App.Messages;
using Weather_App.Services;

namespace Weather_App.ViewModels
{
    class AddViewModel : ViewModelBase
    {
        private readonly IMessenger messenger;
        private readonly IWeatherApiClient weatherApiClient;
        private readonly IForecastStorage forecastStorage;

        public AddViewModel(IMessenger messenger, IWeatherApiClient weatherApiClient, IForecastStorage forecastStorage)
        {
            this.messenger = messenger;
            this.weatherApiClient = weatherApiClient;
            this.forecastStorage = forecastStorage;

            this.messenger.Register<LocationMessage>(this, message =>
            {
                Longitude = message.Longitude.ToString();
                Latitude = message.Latitude.ToString();
            });
        }

        private string cityName;
        public string CityName 
        { 
            get => cityName;
            set
            {
                Set(ref cityName, value);
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private string latitude;
        public string Latitude
        {
            get => latitude;
            set
            {
                Set(ref latitude, value);
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private string longitude;
        public string Longitude
        {
            get => longitude;
            set
            {
                Set(ref longitude, value);
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private bool findByName = true;
        public bool FindByName
        {
            get => findByName;
            set
            {
                Set(ref findByName, value);
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private bool findByGeoLocation;
        public bool FindByGeoLocation
        {
            get => findByGeoLocation;
            set
            {
                Set(ref findByGeoLocation, value);
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private RelayCommand okCommand;
        public RelayCommand OkCommand => okCommand ??= new RelayCommand(
            () =>
            {
                if (FindByName)
                {
                    var forecast = weatherApiClient.GetForecastByCityName(CityName);
                    forecastStorage.AddForecast(forecast);
                }
                else
                {
                    var latitude = double.Parse(Latitude);
                    var longitude = double.Parse(Longitude);
                    var forecast = weatherApiClient.GetForecastByGeoLocation(latitude, longitude);
                    forecastStorage.AddForecast(forecast);
                }
                this.messenger.Send(new NavigationMessage { ViewModelType = typeof(HomeViewModel) });

            },
                ()=> (FindByName && !string.IsNullOrWhiteSpace(CityName)) || (FindByGeoLocation && !string.IsNullOrWhiteSpace(Latitude) && !string.IsNullOrWhiteSpace(Longitude))
        );

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand => cancelCommand ??= new RelayCommand(
            () =>
            {
                this.messenger.Send(new NavigationMessage { ViewModelType = typeof(HomeViewModel) });
            }
        );

        
    }
}
