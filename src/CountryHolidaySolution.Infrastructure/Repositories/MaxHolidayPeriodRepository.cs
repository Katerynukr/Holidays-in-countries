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
    public class MaxHolidayPeriodRepository : IMaxHolidayPeriodRepository
    {
        private readonly DataContext _context;
        public MaxHolidayPeriodRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<MaxHolidayPeriod> GetMaxHolidayPeriod(int year, string country)
        {
            var countryCode = country.ParseToCountryCodeEnum();
            return await _context.HolidayPeriods.Where(h => h.Country == countryCode && h.Year == year).FirstOrDefaultAsync();
        }

        public async Task PostMaxHolidayPeriod(MaxHolidayPeriod holiday)
        {
            _context.HolidayPeriods.Add(holiday);
            await _context.SaveChangesAsync();
        }
    }
}
