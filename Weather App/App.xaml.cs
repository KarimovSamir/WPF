using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Weather_App.Services;
using Weather_App.ViewModels;

namespace Weather_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Services { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RegisterServices();
            InitializeWindow<HomeViewModel>();
        }
        private void RegisterServices()
        {
            Services = new Container();

            Services.RegisterSingleton<IMessenger, Messenger>();
            Services.Register<ILogger, Logger>();
            Services.Register<IWeatherApiClient, WeatherApiClient>();
            Services.Register<IForecastStorage, ForecastStorage>();
            Services.Register<HomeViewModel>();
            Services.Register<DetailesViewModel>();
            Services.Register<AddViewModel>();
            Services.RegisterSingleton<MainViewModel>();

            Services.Verify();
        }
        private void InitializeWindow<T>() where T : ViewModelBase
        {
            var windowViewModel = Services.GetInstance<MainViewModel>();
            windowViewModel.CurrentViewModel = Services.GetInstance<T>();

            var window = new MainWindow { DataContext = windowViewModel };
            window.ShowDialog();
        }
    }
}
