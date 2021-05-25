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
    public class CountriesRepository : ICountriesRepository
    {
        private readonly DataContext _context;

        public CountriesRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<SupportedCountry>> GetAll()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries;
        }
    }
}
