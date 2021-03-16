using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Weather_App.Messages;
using Weather_App.Model;
using Weather_App.Services;

namespace Weather_App.ViewModels
{
    class DetailesViewModel : ViewModelBase
    {
        private readonly IMessenger messenger;
        public DetailesViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
            this.messenger.Register<ForecastInfoMessage>(this, message =>
            {
                CityName = message.Forecast.Name;
                Temperature = message.Forecast.Main.Temperature.ToString();
                var icon = message.Forecast.Weather[0].Icon;
                Image = $"http://openweathermap.org/img/wn/{icon}@2x.png";
                Location = new Location(message.Forecast.Coord.lat, message.Forecast.Coord.lon);
            });
        }

        private string cityNme;
        public string CityName 
        { 
            get => cityNme; 
            set => Set(ref cityNme, value); 
        }

        private string image;
        public string Image
        {
            get => image;
            set => Set(ref image, value);
        }

        private string temperature;
        public string Temperature
        {
            get => temperature;
            set => Set(ref temperature, value);
        }

        private Location location;
        public Location Location
        {
            get => location;
            set => Set(ref location, value);
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand => backCommand ??= new RelayCommand(
            () =>
            {
                messenger.Send(new NavigationMessage { ViewModelType = typeof(HomeViewModel) });
            }
        );
    }
}
