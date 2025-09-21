using Microsoft.EntityFrameworkCore;
using SplitMateAPI.Data;
using SplitMateAPI.Repositories.UserRepositories;

namespace SplitMateAPI.Repositories.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		private readonly RepositoryContainer _repositories;

		public UnitOfWork(ApplicationDbContext context, RepositoryContainer repositories)
		{
			_context = context;
			_repositories = repositories;
		}

		public IUserRepository Users => _repositories.UserRepository;

		public void Detach(object entity)
		{
			var entry = _context.Entry(entity);
			if (entry != null)
			{
				entry.State = EntityState.Detached;
			}
		}

		public void Dispose()
		{
			_context.Dispose();
		}

		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var result = await _context.SaveChangesAsync(cancellationToken);
			return result;
		}
	}
}
