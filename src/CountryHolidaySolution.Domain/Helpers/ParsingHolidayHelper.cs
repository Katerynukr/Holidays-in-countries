using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Helpers
{
    public static class ParsingHolidayHelper
    {
        public static IEnumerable<Holiday> GenerateHelodays(string jsonString)
        {
            var holidays = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Holiday>>(jsonString);
            return holidays;
        }
    }
}
