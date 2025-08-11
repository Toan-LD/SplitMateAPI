namespace SplitMateAPI.Repositories.UnitOfWork
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
		void Detach(Object entity);
	}
}
