//using CountryHolidaySolution.Domain.Extensions;
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
    public class CalendarService
    {
        private readonly DataService _dataService;

        public CalendarService(DataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }
        public DateTimeEnumerator GetDatesForYear(int year)
        {
            var fromDate = year.ParseIntegerToDateTimeFrom();
            var toDate = fromDate.AddYears(1);

            DateTimeEnumerator dateTimeRange = new(fromDate, toDate);
            return dateTimeRange;
        }

        public List<string> GetDateRangeStringForYear(int year)
        {
            List<string> days = new();
            var dates = GetDatesForYear(year);
            foreach(DateTime day in dates)
            {
                days.Add(day.ToString("MM-dd-yyyy"));
            }
            return days;
        }

        public async Task<bool> IsWorkingDay(int day, int month, int year, string country)
        {
            var url = UrlHelper.GenerateIsWorkingDayUrl(day, month, year, country);
            var content = await _dataService.GetData(url);
            var dayType = MappingHelper.MapIsWorkingDayType(content);
            return dayType.IsWorkDay;
        }

        public async Task<bool> IsPublicHolidayDay(int day, int month, int year, string country)
        {
            var url = UrlHelper.GenerateIsPublicHolidayUrl(day, month, year, country);
            var content = await _dataService.GetData(url);
            var dayType = MappingHelper.MapIsHolidayDayType(content);
            return dayType.IsPublicHoliday;
        }
    }
}
