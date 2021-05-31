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
    public class HolidayPeriodService
    {
        private readonly CalendarService _calendarService;

        public HolidayPeriodService( CalendarService calendarService)
        {
            _calendarService = calendarService ?? throw new ArgumentNullException(nameof(calendarService));
        }

        public async Task<List<int>> CountHolidaysInRow(int year, string country)
        {
            List<int> freeDaysAmountInRow = new();
            int count = 0;
            var days = _calendarService.GetDateRangeStringForYear(year);
            foreach (var day in days)
            {
                var dayInteger = day.ParseStringToDateDictionary();
                bool isWorkingDay = await _calendarService.IsWorkingDay(dayInteger["day"], dayInteger["month"], dayInteger["year"], country);
                bool isPublicHolidaDay = await _calendarService.IsPublicHolidayDay(dayInteger["day"], dayInteger["month"], dayInteger["year"], country);
                if (isPublicHolidaDay || !isWorkingDay)
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

        public async Task<int> GetFreeDaysInRowMaxNumber(int year, string country)
        {
            var freeDaysAmountInRow = await CountHolidaysInRow(year, country);
            return freeDaysAmountInRow.Max();
        }

        public HolidayPeriod GenerateCountryMaxHolidayPeriodForYear(int year, string country, int maxHolidayPeriod)
        {
            return new HolidayPeriod()
            {
                Country = country.ParseToCountryCodeEnum(),
                Year = year,
                MaxHolidayLength = maxHolidayPeriod
            };
        }
    }
}
