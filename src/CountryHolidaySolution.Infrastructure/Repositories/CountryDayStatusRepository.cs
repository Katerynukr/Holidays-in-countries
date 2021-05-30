using CountryHolidaySolution.Domain.Extensions;
using CountryHolidaySolution.Domain.Interfaces;
using CountryHolidaySolution.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Infrastructure.Repositories
{
    public class CountryDayStatusRepository : ICountryDayStatusRepository
    {
        private readonly DataContext _context;
        public CountryDayStatusRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CountryDayStatus> GetCountryDayStatus(int day, int month, int year, string country)
        {
            var countryCode = country.ParseToCountryCodeEnum();
            var countryDayStatus = await _context.DayStatuses.Where(c => c.CountryCode == countryCode &&
                                                                    c.Day == day && c.Month == month
                                                                     && c.Year == year).FirstOrDefaultAsync();
            return countryDayStatus;
        }

        public async Task PostCountryDayStatus(CountryDayStatus countryDayStatus)
        {
            _context.Add(countryDayStatus);
            await _context.SaveChangesAsync();
        }
    }
}
