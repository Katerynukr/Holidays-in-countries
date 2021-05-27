using CountryHolidaySolution.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Infrastructure.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DataContext>();

            using (HttpClient client = new HttpClient())
            {
                var content = await client.GetStringAsync("https://kayaposoft.com/enrico/json/v2.0/?action=getSupportedCountries");

                var countries = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<SupportedCountry>>(content);
                foreach (var country in countries)
                {
                   context.Countries.Add(country);
                    
                } 
            }
            try
            {
                await context.SaveChangesAsync();
            }
            catch(Exception e)
            {
            }
        }
    }
}
