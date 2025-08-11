using Microsoft.EntityFrameworkCore;
using SplitMateAPI.Core;
using SplitMateAPI.Data;
using SplitMateAPI.Repositories.GenericRepository;
using System.Linq.Expressions;

namespace SplitMateAPI.Repositories.Generic;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private	readonly ApplicationDbContext _context;
	private DbSet<T> _dbSet => _context.Set<T>();
	private IQueryable<T> _query => _dbSet.AsNoTracking();
	private static Expression<Func<T, bool>> PredicateById(Guid id) => x => EF.Property<Guid>(x, "id") == id;

	public GenericRepository(ApplicationDbContext context)
	{
		_context = context;
	}


	#region CRUD

	public async Task<T> AddAsync(T record, CancellationToken? cancellationToken = null)
	{
		var newRecord = await _dbSet.AddAsync(record, cancellationToken ?? CancellationToken.None);
		return newRecord.Entity;
	}

	public async Task<T> GetByIdAsync(Guid id, CancellationToken? cancellationToken = null)
		=> await _query.FirstOrDefaultAsync(PredicateById(id), cancellationToken ?? CancellationToken.None);

	public async Task<IEnumerable<T>> GetAllAsync(CancellationToken? cancellationToken = null)
		=> await _query.ToListAsync(cancellationToken ?? CancellationToken.None);

	public T Update(T record)
	{
		var entry = _context.Update(record);
		return entry.Entity;
	}

	public async Task<bool> DeleteAsync(Guid id, CancellationToken? cancellationToken = null)
	{
		var affectedRows = await _dbSet.Where(e => EF.Property<Guid>(e, "id") == id)
							   .ExecuteDeleteAsync(cancellationToken ?? CancellationToken.None);
		return affectedRows > 0;
	}

	public async Task<bool> ExistsAsync(Guid id, CancellationToken? cancellationToken = null)
		=> await _query.AnyAsync(PredicateById(id), cancellationToken ?? CancellationToken.None);

	public async Task<PagedResult<T>> GetPagedAsync(IQueryable<T> query, int pageNumber, int pageSize, CancellationToken? cancellationToken = null)
	{
		var result = new PagedResult<T>
		{
			TotalCount = await query.CountAsync(cancellationToken ?? CancellationToken.None),
			PageNumber = pageNumber,
			PageSize = pageSize
		};

		result.Items = await query.Skip((pageNumber - 1) * pageSize)
								  .Take(pageSize)
								  .AsNoTracking()
								  .ToListAsync(cancellationToken ?? CancellationToken.None);

		return result;
	}

	#endregion

	#region Selectors

	public async Task<TResult?> GetByIdAsync<TResult>(Guid id, Expression<Func<T, TResult>> selector, CancellationToken? cancellationToken = null) where TResult : Common.EntitySelector<T, TResult>
		=> await _query.Where(PredicateById(id)).Select(selector).FirstOrDefaultAsync(cancellationToken ?? CancellationToken.None);

	public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector, CancellationToken? cancellationToken = null) where TResult : Common.EntitySelector<T, TResult>
		=> await _query.Select(selector).ToListAsync(cancellationToken ?? CancellationToken.None);

	#endregion
}