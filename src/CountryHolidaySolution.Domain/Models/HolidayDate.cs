using CountryHolidaySolution.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Models
{
    public class HolidayDate : CustomDate
    {
        public int DayOfWeek { get; set; }
    }
}
