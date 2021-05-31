using CountryHolidaySolution.Domain.Extensions;
using CountryHolidaySolution.Domain.Helpers;
using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Services
{
    public class DayStatusService
    {
        private readonly DataService _dataService;
        public DayStatusService(DataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        private async Task<WorkDay> GetDayType(int day, int month, int year, string country)
        {
            var url = UrlHelper.GenerateIsWorkingDayUrl(day, month, year, country);
            var content = await _dataService.GetData(url);
            var dateType = MappingHelper.MapIsWorkingDayType(content);
            return dateType;  
        }

        private DayStatus GenerateCountryDayStatus(int day, int month, int year, string country, WorkDay dayType)
        {
            DayStatus countryDayStatus = new()
            {
                CountryCode = country.ParseToCountryCodeEnum(),
                DayType = dayType,
                Day = day,
                Month = month,
                Year = year
            };
            return countryDayStatus;
        }

        public async Task<DayStatus> GetCountryDayStatus(int day, int month, int year, string country)
        {
            var countryDayType = await GetDayType(day, month, year, country);
            var countryCalendarDay = GenerateCountryDayStatus(day, month, year, country, countryDayType);
            return countryCalendarDay;
        }
    }
}
