using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Extensions
{
    public static class IntergerParseExtension
    {
        public static DateTime ParseIntegerToDateTimeFrom(this int year)
        {
            var date = Convert.ToDateTime($"01/01/{year}");
            return date;
        }

        public static DateTime ParseIntegerToDateTimeTo(this int year)
        {
            var date = Convert.ToDateTime($"31/12/{year}");
            return date;
        }
    }
}
