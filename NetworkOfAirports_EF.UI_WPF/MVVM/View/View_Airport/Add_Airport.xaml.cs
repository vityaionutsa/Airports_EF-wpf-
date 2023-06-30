using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.UI_WPF.MVVM.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Add_Airport.xaml
    /// </summary>
    public partial class Add_Airport : Window
    {
        AirportVM vm { get; set; }
        public Add_Airport()
        {
            vm = new();
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var entity = new AirportCreateDTO
            {
                AirportCode = AirportCode.Text,
                AirportName = AirportName.Text,
                CityId = new Guid(CityId.Text),
            };
            var response = await vm.CreateAsync(entity);
            if (response != Guid.Empty) this.Close();
        }
    }
}
