using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.UI_WPF.MVVM.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

namespace NetworkOfAirports_EF.UI_WPF.MVVM.View.View_Airline
{
    /// <summary>
    /// Логика взаимодействия для AirlineControl.xaml
    /// </summary>
    public partial class AirlineControl : UserControl
    {
        AirlineVM vm { get; set; }
        public AirlineControl()
        {
            vm = new();
            InitializeComponent();
            Init();
        }

        public async void Init()
        {
            var list = await vm.GetAllAsync();
            itemsList.ItemsSource = list;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new Add_Airline().ShowDialog();
            Init();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var item = (AirlineDTO)itemsList.SelectedItem;
            new Edit_Airline(item).Show();
        }
        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = (AirlineDTO)itemsList.SelectedItem;
            if (item is AirlineDTO)
            {
                var response = await vm.DeleteAsync(item.AirlineId);
                if (response) Init();
            }
        }
    }
}
