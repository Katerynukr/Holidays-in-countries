using CountryHolidaySolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Models.Base
{
    public class CustomCountry
    {
        public int Id { get; set; }
        public CountryCode CountryCode { get; set; }
    }
}
