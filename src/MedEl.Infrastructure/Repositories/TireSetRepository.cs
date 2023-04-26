using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MedEl.Domain.Models.Tires;
using MedEl.Domain.Services;
using MedEl.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MedEl.Infrastructure.Repositories
{
    internal class TireSetRepository : ITireSetRepository
    {
        private readonly MedElContext _context;

		public IUnitOfWork UnitOfWork => _context;

        public TireSetRepository(MedElContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<TireSet> AddAsync(TireSet tireSet, CancellationToken cancellationToken = default)
        {
            return (await _context.TireSets.AddAsync(tireSet, cancellationToken)).Entity;
        }

        public Task UpdateAsync(TireSet tireSet, CancellationToken cancellationToken = default)
        {
            _context.Entry(tireSet).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TireSet>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.TireSets.ToListAsync(cancellationToken);
        }

        public async Task<TireSet> GetByIdAsync(int tireSetId, CancellationToken cancellationToken = default)
        {
            var tireSet = await _context.TireSets.FindAsync(tireSetId)
               ?? _context.TireSets.Local.FirstOrDefault(o => o.Id == tireSetId);

            return tireSet;
        }
    }
}
