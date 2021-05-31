using CountryHolidaySolution.Domain.Interfaces;
using CountryHolidaySolution.Domain.Models;
using CountryHolidaySolution.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryHolidayPeriodController : ControllerBase
    {
        private readonly ICountryHolidayPeriodRepository _repository;
        private readonly HolidayPeriodService _holidayCounterService;

        public CountryHolidayPeriodController(ICountryHolidayPeriodRepository repository, HolidayPeriodService holidayCounterService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _holidayCounterService = holidayCounterService ?? throw new ArgumentNullException(nameof(holidayCounterService));
        }

        [HttpGet("{year}/{country}")]
        public async Task<ActionResult<HolidayPeriod>> GetMaxHolidayPeriod(int year, string country)
        {
            var countryMaxHolidayPeriod = await _repository.GetMaxHolidayPeriod(year, country);
            if(countryMaxHolidayPeriod == null)
            {
                try
                {
                    var newHolidayPeriod = await _holidayCounterService.GetFreeDaysInRowMaxNumber(year, country);
                    var countryMaxHolidayEntity =  _holidayCounterService.GenerateCountryMaxHolidayPeriodForYear(year, country, newHolidayPeriod);
                    await _repository.PostMaxHolidayPeriod(countryMaxHolidayEntity);
                    countryMaxHolidayPeriod = await _repository.GetMaxHolidayPeriod(year, country);
                }
                catch
                {
                   return BadRequest(null);
                }
            }
            return Ok(countryMaxHolidayPeriod);
        }
    }
}
