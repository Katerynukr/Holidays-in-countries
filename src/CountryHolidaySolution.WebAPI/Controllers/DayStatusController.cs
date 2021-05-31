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
    public class DayStatusController : ControllerBase
    {
        private readonly IDayStatusRepository _repository;
        private readonly DayStatusService _dayStatusService;

        public DayStatusController(IDayStatusRepository repository, DayStatusService dayStatusService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _dayStatusService = dayStatusService ?? throw new ArgumentNullException(nameof(dayStatusService));
        }

        [HttpGet("{day}-{month}-{year}/{country}/")]
        public async Task<ActionResult<Task<DayStatus>>> GetDayStatus(int day, int month, int year, string country)
        {
            var countryDayStatus = await _repository.GetDayStatus(day, month, year, country);
            if (countryDayStatus == null)
            {
                try
                {
                    var newCountryDayStatus = await _dayStatusService.GetCountryDayStatus(day, month, year, country);
                    await _repository.PostDayStatus(newCountryDayStatus);
                    countryDayStatus = await _repository.GetDayStatus(day, month, year, country);
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
