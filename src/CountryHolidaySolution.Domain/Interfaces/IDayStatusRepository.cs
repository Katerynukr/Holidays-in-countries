using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Interfaces
{
    public interface IDayStatusRepository
    {
        Task<DayStatus> GetDayStatus(int day, int month, int year, string country);
        Task PostDayStatus(DayStatus countryDayStatus);
    }
}
