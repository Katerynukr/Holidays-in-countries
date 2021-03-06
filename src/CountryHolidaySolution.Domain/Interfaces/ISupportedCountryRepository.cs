using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Interfaces
{
    public interface ISupportedCountryRepository
    {
        Task<IEnumerable<SupportedCountry>> GetAll();
        Task<IEnumerable<CustomHoliday>> GetCountryHolidaysByYear(int year, string country);
        Task UpdateContryHolidaysByYear(IEnumerable<CustomHoliday> holiday, string country);
    }
}
