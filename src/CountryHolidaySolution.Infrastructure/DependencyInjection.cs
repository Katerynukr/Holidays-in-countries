using CountryHolidaySolution.Domain.Interfaces;
using CountryHolidaySolution.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>( c => c.UseSqlServer(defaultConnection));

            services.AddScoped<ISupportedCountryRepository, SupportedCountryRepository>();
            services.AddScoped<IDayStatusRepository, DayStatusRepository>();
            services.AddScoped<IMaxHolidayPeriodRepository, MaxHolidayPeriodRepository>();
        }
    }
}
