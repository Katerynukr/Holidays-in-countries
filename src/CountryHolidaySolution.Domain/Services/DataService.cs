using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Services
{
    public class DataService
    {
        private HttpClient _client { get; set; }

        public DataService()
        {
            _client = new();
        }

        public async Task<string> GetData(string url)
        {
           return await _client.GetStringAsync(url);
        }
    }
}
