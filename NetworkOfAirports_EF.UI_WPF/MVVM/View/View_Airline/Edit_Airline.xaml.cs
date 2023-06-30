using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.DAL.Entitites;
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
    /// Логика взаимодействия для Edit_Airline.xaml
    /// </summary>
    public partial class Edit_Airline : Window
    {
        AirlineVM vm { get; set; }
        private AirlineDTO airline { get; set; }
        public Edit_Airline(AirlineDTO entity)
        {
            vm = new();
            InitializeComponent();

            airline = entity;
            DataContext = entity;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            var updateEntity = new AirlineUpdateDTO
            {
                AirlineId = airline.AirlineId,
                AirlineName = airline.AirlineName,
            };
            var response = await vm.UpdateAsync(updateEntity);
            if (response) this.Close();
        }
    }
}
