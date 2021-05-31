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
    public class CountryHolidayPeriodRepository : ICountryHolidayPeriodRepository
    {
        private readonly DataContext _context;
        public CountryHolidayPeriodRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<HolidayPeriod> GetMaxHolidayPeriod(int year, string country)
        {
            var countryCode = country.ParseToCountryCodeEnum();
            return await _context.HolidayPeriods.Where(h => h.Country == countryCode && h.Year == year).FirstOrDefaultAsync();
        }

        public async Task PostMaxHolidayPeriod(HolidayPeriod holiday)
        {
            _context.HolidayPeriods.Add(holiday);
            await _context.SaveChangesAsync();
        }
    }
}
