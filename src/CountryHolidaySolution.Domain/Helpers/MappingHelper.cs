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
        public static IEnumerable<CustomHoliday> MapHoliday(string jsonString)
        {
            var holidays = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CustomHoliday>>(jsonString);
            return holidays;
        }

        public static WorkDay MapIsWorkingDayType(string jsonString)
        {
            var holidays = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkDay>(jsonString);
            return holidays;
        }

        public static PublicHoliday MapIsHolidayDayType(string jsonString)
        {
            var holidays = Newtonsoft.Json.JsonConvert.DeserializeObject<PublicHoliday>(jsonString);
            return holidays;
        }
    }
}
