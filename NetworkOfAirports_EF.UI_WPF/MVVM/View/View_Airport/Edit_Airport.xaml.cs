using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.UI_WPF.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace NetworkOfAirports_EF.UI_WPF.MVVM.View.View_Airport
{
    /// <summary>
    /// Логика взаимодействия для Edit_Airport.xaml
    /// </summary>
    public partial class Edit_Airport : Window
    {
        AirportVM vm { get; set; }
        private AirportDTO airport { get; set; }
        public Edit_Airport(AirportDTO entity)
        {
            vm = new();

            InitializeComponent();

            airport = entity;
            DataContext = entity;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            var updateEntity = new AirportUpdateDTO
            {
                AirportId = airport.AirportId,
                AirportCode = AirportCode.Text,
                AirportName = AirportName.Text,
                CityId = new Guid(CityId.Text)
            };
            var response = await vm.UpdateAsync(updateEntity);
            if (response) this.Close();
        }
    }
}
