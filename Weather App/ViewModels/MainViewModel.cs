using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Weather_App.Messages;
using Weather_App.Services;

namespace Weather_App.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set => Set(ref currentViewModel, value);
        }

        public MainViewModel(IMessenger messenger)
        {
            messenger.Register<NavigationMessage>(this, message=>
            {
                var viewModel = App.Services.GetInstance(message.ViewModelType) as ViewModelBase;
                CurrentViewModel = viewModel;
            });
        }
    }
}
