using System;
using System.Threading;
using System.Threading.Tasks;

namespace MedEl.Domain.Services
{
	public interface IUnitOfWork : IDisposable
	{
		Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
