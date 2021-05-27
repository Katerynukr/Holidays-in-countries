using CountryHolidaySolution.Domain.Helpers;
using CountryHolidaySolution.Domain.Interfaces;
using CountryHolidaySolution.Domain.Models;
using CountryHolidaySolution.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CountryHolidaySolution.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepository _repository;
        private readonly HolidayService _holidayService;

        public CountriesController(ICountriesRepository repository, HolidayService holidayService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository)); 
            _holidayService = holidayService ?? throw new ArgumentNullException(nameof(holidayService)); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportedCountry>>> GetAll()
        {
            var countries = await _repository.GetAll();
            return Ok(countries);
        }

        [HttpGet("{year}/{country}/")]
        public async Task<ActionResult<IEnumerable<Holiday>>> GetCountryHolidaysByMonth(int year, string country)
        {
            var holidays = await _repository.GetCountryHolidaysForYear(year, country);
            if( holidays.Count() > 0)
            {
                return Ok(holidays);
            }
            else
            {
                var newHolidays = await _holidayService.GetHolidays(year, country);
                await _repository.UpdateContryHolidaysForYear(newHolidays, country);
                var updatedHolidays = _repository.GetCountryHolidaysForYear(year, country);
                return Ok(updatedHolidays);
            }
            
        }
    }
}
