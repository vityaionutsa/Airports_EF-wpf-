﻿using NetworkOfAirports_EF.BLL.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class AirlineVM
    {
        HttpClient Client = new();
        public AirlineVM() 
        {
            Client.BaseAddress = new Uri("http://localhost:5275/efcore/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<AirlineDTO>?> GetAllAsync()
        {
            var response = await Client.GetAsync("airline");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var temp = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<ObservableCollection<AirlineDTO>>(temp);
                return list;
            }
            throw new Exception("GetAll -> Response is not SuccessStatusCode!");
        }
        public async Task<Guid> CreateAsync(AirlineDTO entity)
        {
            var response = await Client.PostAsJsonAsync("airline/", entity);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var temp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Guid>(temp);
                return result;
            }
            return Guid.Empty;
        }
        public async Task<bool> UpdateAsync(AirlineUpdateDTO entity)
        {
            var response = await Client.PutAsJsonAsync("airline/" + entity.AirlineId, entity);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await Client.DeleteAsync("airline/" + id.ToString());
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
