using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Helpers
{
    public static class MappingHelper
    {
        public static IEnumerable<Holiday> MapHoliday(string jsonString)
        {
            var holidays = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Holiday>>(jsonString);
            return holidays;
        }

        public static CustomDayType MapDateType(string jsonString)
        {
            var holidays = Newtonsoft.Json.JsonConvert.DeserializeObject<CustomDayType>(jsonString);
            return holidays;
        }
    }
}
