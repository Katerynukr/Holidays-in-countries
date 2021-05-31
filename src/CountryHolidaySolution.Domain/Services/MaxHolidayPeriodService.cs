using CountryHolidaySolution.Domain.Extensions;
using CountryHolidaySolution.Domain.Helpers;
using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Services
{
    public class MaxHolidayPeriodService
    {
        private readonly CalendarService _calendarService;

        public MaxHolidayPeriodService( CalendarService calendarService)
        {
            _calendarService = calendarService ?? throw new ArgumentNullException(nameof(calendarService));
        }

        public async Task<List<int>> GetAllHolidaysInRow(int year, string country)
        {
            var days = _calendarService.GetDateRangeStringForYear(year);
            return await CountHolidaysInRow(days, country);
        }

        private async Task<bool> IsHolidayInRow(string day, string country)
        {
            var dayInteger = day.ParseStringToDateDictionary();
            bool isWorkingDay = await _calendarService.IsWorkingDay(dayInteger["day"], dayInteger["month"], dayInteger["year"], country);
            bool isPublicHolidaDay = await _calendarService.IsPublicHolidayDay(dayInteger["day"], dayInteger["month"], dayInteger["year"], country);
            if (isPublicHolidaDay || !isWorkingDay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<List<int>> CountHolidaysInRow(List<string> days, string country)
        {
            List<int> freeDaysAmountInRow = new();
            int count = 0;
            foreach (var day in days)
            {
                var isInRow = await IsHolidayInRow(day, country);
                if (isInRow)
                {
                    count++;
                }
                else
                {
                    freeDaysAmountInRow.Add(count);
                    count = 0;
                }
            }
            return freeDaysAmountInRow;
        }

        public async Task<int> GetMaxHolidayPeriod(int year, string country)
        {
            var freeDaysAmountInRow = await GetAllHolidaysInRow(year, country);
            return freeDaysAmountInRow.Max();
        }

        public MaxHolidayPeriod GenerateCountryMaxHolidayPeriodForYear(int year, string country, int maxHolidayPeriod)
        {
            return new MaxHolidayPeriod()
            {
                Country = country.ParseToCountryCodeEnum(),
                Year = year,
                MaxHolidayLength = maxHolidayPeriod
            };
        }
    }
}
