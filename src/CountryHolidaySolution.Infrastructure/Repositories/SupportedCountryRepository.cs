using CountryHolidaySolution.Domain.Enums;
using CountryHolidaySolution.Domain.Extensions;
using CountryHolidaySolution.Domain.Helpers;
using CountryHolidaySolution.Domain.Interfaces;
using CountryHolidaySolution.Domain.Models;
using CountryHolidaySolution.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Infrastructure.Repositories
{
    public class SupportedCountryRepository : ISupportedCountryRepository
    {
        private readonly DataContext _context;

        public SupportedCountryRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<SupportedCountry>> GetAll()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries;
        }

        public async Task<IEnumerable<Holiday>> GetCountryHolidaysForYear(int year, string country)
        {
            var countryEntity = await GetCountryByCountryCode(country);
            if (countryEntity.Holidays != null)
            {
                return countryEntity.Holidays.Where(h => h.Date.Year == year).ToList();
            }
            return null;
        }

        public async Task UpdateContryHolidaysForYear(IEnumerable<Holiday> holidays, string country)
        {
            var countryEntity = await GetCountryByCountryCode(country);
            foreach(var holiday in holidays)
            {
                countryEntity.Holidays.Add(holiday);
            }
             _context.Update(countryEntity);
            await _context.SaveChangesAsync();
        }

        private async Task<SupportedCountry> GetCountryByCountryCode(string country)
        {
            var countryCode = country.ParseToCountryCodeEnum();
            var countryEntity = await _context.Countries.Where(c => c.CountryCode == countryCode).FirstOrDefaultAsync();
            return countryEntity;
        }
    }
}
