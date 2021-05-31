using CountryHolidaySolution.Domain.Models;
using CountryHolidaySolution.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain
{
    public static class DependencyInjection
    {
        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<DayStatusService>();
            services.AddScoped<DataService>();
            services.AddScoped<HolidayService>();
            services.AddScoped<MaxHolidayPeriodService>();
            services.AddScoped<CalendarService>();
        }
    }
}
