using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Weather_App.Messages;
using Weather_App.Model;
using Weather_App.Services;

namespace Weather_App.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<Forecast> forecasts;
        
        private readonly IForecastStorage forecastStorage;
        private readonly IMessenger messenger;
        public ObservableCollection<Forecast> Forecasts
        {
            get => forecasts;
            set
            {
                Set(ref forecasts, value);
            }
        }
        public HomeViewModel(IForecastStorage forecastStorage, IMessenger messenger)
        {
            this.forecastStorage = forecastStorage;
            this.messenger = messenger;
            Forecasts = new ObservableCollection<Forecast>(forecastStorage.GetAllForecast());
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand => addCommand ??= new RelayCommand(
            () =>
            {
                messenger.Send(new NavigationMessage { ViewModelType = typeof(AddViewModel) });                
            }
        );

        private RelayCommand<Forecast> detailesCommand;
        public RelayCommand<Forecast> DetailesCommand => detailesCommand ??= new RelayCommand<Forecast>(
            param =>
            {
                messenger.Send(new NavigationMessage { ViewModelType = typeof(DetailesViewModel) });
                messenger.Send(new ForecastInfoMessage { Forecast = param });

            }
        );
        
    }
}
