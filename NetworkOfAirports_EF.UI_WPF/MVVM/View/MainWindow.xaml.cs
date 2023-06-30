using NetworkOfAirports_EF.UI_WPF.MVVM.View.View_Airline;
using NetworkOfAirports_EF.UI_WPF.MVVM.View.View_Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetworkOfAirports_EF.UI_WPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += AirlineSelect;
        }


        private void AirlineSelect(object sender, RoutedEventArgs e)
        {
            MainWindowContent.Content = new AirlineControl();
        }
        private void AirportSelect(object sender, RoutedEventArgs e)
        {
            MainWindowContent.Content = new AirportControl();
        }
    }
}
