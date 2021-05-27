using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Helpers
{
    public static class HolidayUrlHelper
    {
        public static string GenerateHolidayUrl(int year, string countryCode)
        {
            var url = $"https://kayaposoft.com/enrico/json/v2.0/?action=getHolidaysForYear&year={year}&country={countryCode}";
            return url;
        }
    }
}
