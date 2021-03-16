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
using Weather_App.ViewModels;

namespace Weather_App.Views
{
    /// <summary>
    /// Interaction logic for DetailesView.xaml
    /// </summary>
    public partial class DetailesView : UserControl
    {
        public DetailesView()
        {
            InitializeComponent();
        }

        //private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    var location = Map.ViewportPointToLocation(e.GetPosition(Map));
        //}
    }
}
