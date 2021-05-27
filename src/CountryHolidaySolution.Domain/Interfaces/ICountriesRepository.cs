using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Interfaces
{
    public interface ICountriesRepository
    {
        Task<IEnumerable<SupportedCountry>> GetAll();
        Task<IEnumerable<Holiday>> GetCountryHolidaysForYear(int year, string country);
        Task UpdateContryHolidaysForYear(IEnumerable<Holiday> holiday, string country);
    }
}
