using SplitMateAPI.Common;
using SplitMateAPI.Core;
using System.Linq.Expressions;

namespace SplitMateAPI.Repositories.GenericRepository;

public interface IGenericRepository<T> where T : class
{
    #region CRUD Operations

    Task<T> AddAsync(T record, CancellationToken? cancellationToken = null);
    Task<T> GetByIdAsync(Guid id, CancellationToken? cancellationToken = null);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken? cancellationToken = null);
    T Update(T record);
    Task<bool> DeleteAsync(Guid id, CancellationToken? cancellationToken = null);
    Task<bool> ExistsAsync(Guid id, CancellationToken? cancellationToken = null);
    Task<PagedResult<T>> GetPagedAsync(IQueryable<T> query, int pageNumber, int pageSize, CancellationToken? cancellationToken = null);

    #endregion

    #region Selectors

    Task<TResult?> GetByIdAsync<TResult>(Guid id, Expression<Func<T, TResult>> selector, CancellationToken? cancellationToken = null) where TResult : EntitySelector<T, TResult>;
	Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector, CancellationToken? cancellationToken = null) where TResult : EntitySelector<T, TResult>;

	#endregion
}