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
    public class CountryDayStatusController : ControllerBase
    {
        private readonly ICountryDayStatusRepository _repository;
        private readonly CountryDayStatusService _countryDayStatusService;

        public CountryDayStatusController(ICountryDayStatusRepository repository, CountryDayStatusService countryDayStatusService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _countryDayStatusService = countryDayStatusService ?? throw new ArgumentNullException(nameof(countryDayStatusService));
        }

        [HttpGet("{day}-{month}-{year}/{country}/")]
        public async Task<ActionResult<Task<CountryDayStatus>>> GetCountryDayStatus(int day, int month, int year, string country)
        {
            var countryDayStatus = await _repository.GetCountryDayStatus(day, month, year, country);
            if (countryDayStatus == null)
            {
                try
                {
                    var newCountryDayStatus = await _countryDayStatusService.GetCountryDayStatus(day, month, year, country);
                    await _repository.PostCountryDayStatus(newCountryDayStatus);
                    countryDayStatus = await _repository.GetCountryDayStatus(day, month, year, country);
                }
                catch
                {
                    return BadRequest(null);
                }
                
            }
            return Ok(countryDayStatus);
        }
    }
}
