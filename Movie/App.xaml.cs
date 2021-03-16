using Movie.Services;
using Movie.View;
using Movie.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Movie
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var movieSearch = new MovieSearch();

            var app = new AppView();
            app.DataContext = new AppViewModel(movieSearch);
            app.ShowDialog();
        }
    }
}
