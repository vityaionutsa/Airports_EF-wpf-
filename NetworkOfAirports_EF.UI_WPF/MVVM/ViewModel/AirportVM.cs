using NetworkOfAirports_EF.BLL.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.UI_WPF.MVVM.ViewModel
{
    internal class AirportVM
    {
        HttpClient Client = new();
        public AirportVM()
        {
            Client.BaseAddress = new Uri("http://localhost:5275/efcore/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<AirportDTO>?> GetAllAsync()
        {
            var response = await Client.GetAsync("airport");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var temp = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<ObservableCollection<AirportDTO>>(temp);
                return list;
            }
            throw new Exception("GetAll -> Response is not SuccessStatusCode!");
        }
        public async Task<Guid> CreateAsync(AirportCreateDTO entity)
        {
            var response = await Client.PostAsJsonAsync("airport/", entity);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var temp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Guid>(temp);
                return result;
            }
            return Guid.Empty;
        }
        public async Task<bool> UpdateAsync(AirportUpdateDTO entity)
        {
            var response = await Client.PutAsJsonAsync("airport/" + entity.AirportId, entity);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await Client.DeleteAsync("airport/" + id.ToString());
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
