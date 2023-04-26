using System.Net;
using MedEl.Domain.Models.Tires;
using MedEl.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedEl.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TireSetController : ControllerBase
    {
        private readonly ITireSetRepository _repository;

        public TireSetController(ITireSetRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return Ok(result);
        }

        [HttpPost("summer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateSummerTireSetAsync(float pressure, string size, float maximumTemperature)
        {
            var tireSet = new SummerTireSet(pressure, TireSize.Parse(size), maximumTemperature);
            var result = await _repository.AddAsync(tireSet);
            await _repository.UnitOfWork.SaveEntitiesAsync();

            return Ok(result);
        }

        [HttpPost("winter")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateWinterTireSetAsync(float pressure, string size, float minimumTemperature, float thickness)
        {
            var tireSet = new WinterTireSet(pressure, TireSize.Parse(size), minimumTemperature, thickness);
            var result = await _repository.AddAsync(tireSet);
            await _repository.UnitOfWork.SaveEntitiesAsync();

            return Ok(result);
        }
    }
}