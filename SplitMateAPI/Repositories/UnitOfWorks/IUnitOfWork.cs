using SplitMateAPI.Repositories.UserRepositories;

namespace SplitMateAPI.Repositories.UnitOfWorks
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
		void Detach(Object entity);

		#region Repositories

		IUserRepository Users { get; }

		#endregion
	}
}
