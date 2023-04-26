using System.Net;
using MedEl.Domain.Models.Vehicles;
using MedEl.Domain.Services;
using MedEl.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace MedEl.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _repository;

        public VehicleController(IVehicleRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost("{id}/move")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> MoveVehicleAsync(int id)
        {
            var vehicle = await _repository.GetByIdAsync(id);
            vehicle.Move();
            await _repository.UnitOfWork.SaveEntitiesAsync();

            return Ok();
        }
    }
}