using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TestApp.Shared.Models;

namespace TestApp.WPF.Services
{
    public class TestService : ITestService
    {
        private readonly HttpClient _httpClient;
        public TestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Information> AddInformation(Information information)
        {
            var response = await _httpClient.PostAsJsonAsync<Information>($"/api", information);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Information>();
            }
            else
                return null;
        }

        public async Task<bool> DeleteInformation(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/{id}");
            if (response.IsSuccessStatusCode)
            {
                var isPassed = await response.Content.ReadAsStringAsync();
                return isPassed.ToLower() == "true";
            }
            else
                return false;
        }

        public async Task<IEnumerable<Information>> GetAllInformations()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Information>>("/api/all");
        }

        public async Task<Information> GetInformationById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Information>($"/api/{id}");
        }

        public async Task<Information> UpdateInformation(int id, Information information)
        {
            var response = await _httpClient.PutAsJsonAsync<Information>($"/api/{id}", information);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Information>();
            }
            else
                return null;
        }
    }
}
