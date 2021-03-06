using CountryHolidaySolution.Domain.Enums;
using CountryHolidaySolution.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Models
{
    public class SupportedCountry : CustomCountry
    {
        public List<string> Regions { get; set; }
        public List<string> HolidayTypes { get; set; }
        public string FullName { get; set; }
        public FromDate FromDate { get; set; }
        public int FromDateId { get; set; }
        public ToDate ToDate { get; set; }
        public int ToDateId { get; set; }
        public List<CustomHoliday> Holidays { get; set; } = new(); 
    }
}
