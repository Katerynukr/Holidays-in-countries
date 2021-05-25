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



            context.Countries.Add(new Domain.Models.SupportedCountry()
            {
                FullName = "ADS",
                Regions = new() {new RegionCode(){ Region = "sffd" } },
                ToDate = new ToDate()
                {
                    Day = 1,
                    Month = 2,
                    Year = 2
                },
                FromDate = new FromDate()
                {
                    Day = 1,
                    Month = 2,
                    Year = 2
                },
                CountryCode = Domain.Enums.CountryCode.ago,
                    HolidayTypes = new()
                    {
                        new HolidayType()
                        {
                            Type = Domain.Enums.Holiday.extra_working_day
                        }
                    }


            });

            await context.SaveChangesAsync();

        }
    }
}
