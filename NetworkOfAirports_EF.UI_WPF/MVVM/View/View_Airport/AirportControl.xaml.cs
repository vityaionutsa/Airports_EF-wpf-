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

namespace NetworkOfAirports_EF.UI_WPF.MVVM.View.View_Airport
{
    /// <summary>
    /// Логика взаимодействия для AirportControl.xaml
    /// </summary>
    public partial class AirportControl : UserControl
    {
        AirportVM vm { get; set; }
        public AirportControl()
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
            new Add_Airport().ShowDialog();
            Init();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var item = (AirportDTO)itemsList.SelectedItem;
            new Edit_Airport(item).Show();
        }
        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = (AirportDTO)itemsList.SelectedItem;
            if (item is AirportDTO)
            {
                var response = await vm.DeleteAsync(item.AirportId);
                if (response) Init();
            }
        }
    }
}
