using CountryHolidaySolution.Domain.Helpers;
using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.Domain.Services
{
    public class HolidayService
    {
        private readonly DataService _dataService;

        public HolidayService(DataService dataService)
        {
                _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public async Task<IEnumerable<Holiday>> GetHolidays(int year, string countryCode)
        {
            try
            {
                var url = HolidayUrlHelper.GenerateHolidayUrl(year, countryCode);
                var content = await _dataService.GetData(url);
                var newEntities = ParsingHolidayHelper.GenerateHelodays(content);
                return newEntities;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
