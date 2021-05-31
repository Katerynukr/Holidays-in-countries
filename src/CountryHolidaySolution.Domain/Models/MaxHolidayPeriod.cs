using CountryHolidaySolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Models
{
    public class MaxHolidayPeriod
    {
        public int Id { get; set; }
        public CountryCode Country { get; set; }
        public int Year { get; set; }
        public int MaxHolidayLength { get; set; }
    }
}
