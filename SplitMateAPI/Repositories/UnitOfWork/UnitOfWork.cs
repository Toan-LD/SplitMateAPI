using Microsoft.EntityFrameworkCore;
using SplitMateAPI.Data;

namespace SplitMateAPI.Repositories.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}

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
