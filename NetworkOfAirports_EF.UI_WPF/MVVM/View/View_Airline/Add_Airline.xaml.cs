using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.UI_WPF.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NetworkOfAirports_EF.UI_WPF.MVVM.View.View_Airline
{
    /// <summary>
    /// Логика взаимодействия для Add_Airline.xaml
    /// </summary>
    public partial class Add_Airline : Window
    {
        AirlineVM vm { get; set; }
        public Add_Airline()
        {
            vm = new();
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var entity = new AirlineDTO
            {
                AirlineId = Guid.NewGuid(),
                AirlineName = AirlineName.Text
            };
            var response = await vm.CreateAsync(entity);
            if (response != Guid.Empty) this.Close();
        }
    }
}
