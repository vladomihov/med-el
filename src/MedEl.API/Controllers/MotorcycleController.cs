using System.Net;
using MedEl.Domain.Models.Vehicles;
using MedEl.Domain.Services;
using MedEl.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace MedEl.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MotorcycleController : ControllerBase
    {
        private readonly INamedFactoryResolver<IMotorcycleFactory> _motorcycleResolver;
        private readonly IVehicleRepository _repository;

        public MotorcycleController(
            INamedFactoryResolver<IMotorcycleFactory> motorcycleResolver,
            IVehicleRepository repository)
        {
            _motorcycleResolver = motorcycleResolver ?? throw new ArgumentNullException(nameof(motorcycleResolver));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("motorcycle/factories")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetMotorcycleFactories()
        {
            return Ok(_motorcycleResolver.Names);
        }

        [HttpPost("motorcycle/{brand}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMotorcycleAsync(string brand)
        {
            var factory = _motorcycleResolver.GetFactory(brand);
            var motorcycle = factory.CreateNew();
            var result = await _repository.AddAsync(motorcycle);
            await _repository.UnitOfWork.SaveEntitiesAsync();

            return Ok(result);
        }
    }
}