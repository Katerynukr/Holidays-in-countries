using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public HolidayDate Date { get; set; }
        public string HolidayType { get; set; }
        public List<HolidayName> Name { get; set; }
    }
}
