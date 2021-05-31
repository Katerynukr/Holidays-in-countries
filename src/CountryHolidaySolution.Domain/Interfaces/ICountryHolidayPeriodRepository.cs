using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Interfaces
{
    public interface ICountryHolidayPeriodRepository
    {
        Task<HolidayPeriod> GetMaxHolidayPeriod(int year, string country);
        Task PostMaxHolidayPeriod(HolidayPeriod holiday);
    }
}
