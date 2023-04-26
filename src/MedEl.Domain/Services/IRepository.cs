namespace MedEl.Domain.Services
{
    public interface IRepository<TEntity>
	{
		IUnitOfWork UnitOfWork { get; }
	}
}
