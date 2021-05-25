using CountryHolidaySolution.Domain.Enums;
using CountryHolidaySolution.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Models
{
    public class SupportedCountry
    {
        public int Id { get; set; }
        public CountryCode CountryCode { get; set; }
        public List<RegionCode>  Regions { get; set; }
        public List<HolidayType> HolidayTypes { get; set; }
        public string FullName { get; set; }
        public FromDate FromDate { get; set; }
        public ToDate ToDate { get; set; }
    }
}
