using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MedEl.Domain.Models.Vehicles;
using MedEl.Domain.Services;
using MedEl.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MedEl.Infrastructure.Repositories
{
    internal class VehicleRepository : IVehicleRepository
    {
        private readonly MedElContext _context;

		public IUnitOfWork UnitOfWork => _context;

        public VehicleRepository(MedElContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Vehicle> AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
        {
            return (await _context.Vehicles.AddAsync(vehicle, cancellationToken)).Entity;
        }

        public Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
        {
            _context.Entry(vehicle).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Vehicles.ToListAsync(cancellationToken);
        }

        public async Task<Vehicle> GetByIdAsync(int vehicleId, CancellationToken cancellationToken = default)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId)
               ?? _context.Vehicles.Local.FirstOrDefault(o => o.Id == vehicleId);

            return vehicle;
        }
    }
}
