using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.WPF.Services
{
    public class TestService : ITestService
    {
        private readonly HttpClient _httpClient;
        public TestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetData()
        {
            string result = await _httpClient.GetStringAsync("/api/all");
            return result;
        }
    }
}
