using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MedEl.Domain.Models.Vehicles;

namespace MedEl.Domain.Services
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<Vehicle> AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default);

        Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken = default);

        Task<IEnumerable<Vehicle>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Vehicle> GetByIdAsync(int vehicleId, CancellationToken cancellationToken = default);
    }
}