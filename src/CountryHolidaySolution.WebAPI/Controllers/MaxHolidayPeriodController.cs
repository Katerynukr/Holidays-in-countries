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
    public class MaxHolidayPeriodController : ControllerBase
    {
        private readonly IMaxHolidayPeriodRepository _repository;
        private readonly MaxHolidayPeriodService _maxHolidayPeriodService;

        public MaxHolidayPeriodController(IMaxHolidayPeriodRepository repository, MaxHolidayPeriodService maxHolidayPeriodService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _maxHolidayPeriodService = maxHolidayPeriodService ?? throw new ArgumentNullException(nameof(maxHolidayPeriodService));
        }

        [HttpGet("{year}/{country}")]
        public async Task<ActionResult<MaxHolidayPeriod>> GetMaxHolidayPeriod(int year, string country)
        {
            var countryMaxHolidayPeriod = await _repository.GetMaxHolidayPeriod(year, country);
            if(countryMaxHolidayPeriod == null)
            {
                try
                {
                    var newHolidayPeriod = await _maxHolidayPeriodService.GetMaxHolidayPeriod(year, country);
                    var countryMaxHolidayEntity =  _maxHolidayPeriodService.GenerateCountryMaxHolidayPeriodForYear(year, country, newHolidayPeriod);
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
