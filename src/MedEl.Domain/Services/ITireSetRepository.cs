using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MedEl.Domain.Models.Tires;

namespace MedEl.Domain.Services
{
    public interface ITireSetRepository : IRepository<TireSet>
    {
        Task<TireSet> AddAsync(TireSet tireSet, CancellationToken cancellationToken = default);

        Task UpdateAsync(TireSet tireSet, CancellationToken cancellationToken = default);

        Task<IEnumerable<TireSet>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<TireSet> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}