using CountryHolidaySolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Services
{
    public class InputValidationService
    {
        public bool IsValidDate(int day, int month, int year)
        {
            try
            {
                var isValidDate = DateTime.TryParse($"{day}/{month}/{year}", out DateTime d);
                return isValidDate;
            }
            catch (Exception)
            { 
                return false;
            }
        }

        public bool IsValidCountryCode(string countryCode)
        {
            try{
                Enum.Parse<CountryCode>(countryCode);
                return true;
            }
            catch (Exception)
            { 
                return false;
            }
        }
    }
}
