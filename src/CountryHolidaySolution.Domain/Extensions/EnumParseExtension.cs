using CountryHolidaySolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Extensions
{
    public static class EnumParseExtension
    {
        public static CountryCode ParseToCountryCodeEnum(this string countryCodeSrting)
        {
            return Enum.Parse<CountryCode>(countryCodeSrting);
        }
    }
}
