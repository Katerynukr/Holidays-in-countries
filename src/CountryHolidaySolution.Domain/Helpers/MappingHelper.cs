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

        public static WorkDayType MapIsWorkingDateType(string jsonString)
        {
            var holidays = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkDayType>(jsonString);
            return holidays;
        }

        public static PublicHolidayDayType MapIsHolidayDateType(string jsonString)
        {
            var holidays = Newtonsoft.Json.JsonConvert.DeserializeObject<PublicHolidayDayType>(jsonString);
            return holidays;
        }
    }
}
