using System.Net;
using MedEl.Domain.Models.Vehicles;
using MedEl.Domain.Services;
using MedEl.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace MedEl.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly INamedFactoryResolver<ICarFactory> _carResolver;
        private readonly IVehicleRepository _carRepository;
        private readonly ITireSetRepository _tireSetRepository;

        public CarController(
            INamedFactoryResolver<ICarFactory> carResolver,
            IVehicleRepository carRepository,
            ITireSetRepository tireSetRepository)
        {
            _carResolver = carResolver ?? throw new ArgumentNullException(nameof(carResolver));
            _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
            _tireSetRepository = tireSetRepository ?? throw new ArgumentNullException(nameof(tireSetRepository));
        }

        [HttpGet("factories")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetCarFactories()
        {
            return Ok(_carResolver.Names);
        }

        [HttpPost("{brand}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCarAsync(string brand)
        {
            var factory = _carResolver.GetFactory(brand);
            var car = factory.CreateNew();
            var result = await _carRepository.AddAsync(car);
            await _carRepository.UnitOfWork.SaveEntitiesAsync();

            return Ok(result);
        }

        [HttpPatch("{id}/switchTires/{tireSetId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> SwitchTireSetAsync(int id, int tireSetId)
        {
            var vehicle = await _carRepository.GetByIdAsync(id);
            if (vehicle is Car car)
            {
                var tires = await _tireSetRepository.GetByIdAsync(tireSetId);
                car.SetTires(tires);
                await _carRepository.UpdateAsync(car);
                await _carRepository.UnitOfWork.SaveEntitiesAsync();
            }

            return Ok();
        }
    }
}