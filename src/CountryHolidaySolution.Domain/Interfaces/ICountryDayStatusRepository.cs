using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Interfaces
{
    public interface ICountryDayStatusRepository
    {
        Task<CountryDayStatus> GetCountryDayStatus(int day, int month, int year, string country);
        Task PostCountryDayStatus(CountryDayStatus countryDayStatus);
    }
}
