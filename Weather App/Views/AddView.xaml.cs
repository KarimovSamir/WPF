using GalaSoft.MvvmLight.Messaging;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Weather_App.Messages;

namespace Weather_App.Views
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        public AddView()
        {
            InitializeComponent();
        }

        private void Map_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var messenger = App.Services.GetInstance<IMessenger>();
            var location = Map.ViewportPointToLocation(e.GetPosition(Map));
            messenger.Send(new LocationMessage { Latitude = location.Latitude, Longitude = location.Longitude });
        }
    }
}
