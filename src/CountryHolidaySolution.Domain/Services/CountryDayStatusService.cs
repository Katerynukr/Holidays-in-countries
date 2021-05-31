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
    public class CountryDayStatusService
    {
        private readonly DataService _dataService;
        public CountryDayStatusService(DataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        private async Task<WorkDayType> GetDayType(int day, int month, int year, string country)
        {
            var url = UrlHelper.GenerateIsWorkingDayUrl(day, month, year, country);
            var content = await _dataService.GetData(url);
            var dateType = MappingHelper.MapIsWorkingDateType(content);
            return dateType;
           
        }

        private CountryDayStatus GenerateCountryCalendarDayStatus(int day, int month, int year, string country, WorkDayType dayType)
        {
            CountryDayStatus countryDayStatus = new()
            {
                CountryCode = country.ParseToCountryCodeEnum(),
                DayType = dayType,
                Day = day,
                Month = month,
                Year = year
            };
            return countryDayStatus;
        }

        public async Task<CountryDayStatus> GetCountryDayStatus(int day, int month, int year, string country)
        {
            var countryDayType = await GetDayType(day, month, year, country);
            var countryCalendarDay = GenerateCountryCalendarDayStatus(day, month, year, country, countryDayType);
            return countryCalendarDay;
        }
    }
}
