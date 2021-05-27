using CountryHolidaySolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Models
{
    public class HolidayName
    {
        public int Id { get; set; }
        public LanguageCode Lang { get; set; }
        public string Text { get; set; }
    }
}
