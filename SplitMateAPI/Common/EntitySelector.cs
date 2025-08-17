using System.Linq.Expressions;

namespace SplitMateAPI.Common;

/// <summary>
/// Base record for defining reusable EF Core projections.
/// </summary>
/// <typeparam name="TEntity">Source entity type</typeparam>
/// <typeparam name="TResult">Projected DTO/result type</typeparam>
public abstract record EntitySelector<TEntity, TResult>
	where TResult : EntitySelector<TEntity, TResult>
{
	/// <summary>
	/// The core projection expression. Override in derived record.
	/// </summary>
	protected abstract Expression<Func<TEntity, TResult>> SelectCore();

	/// <summary>
	/// Static accessor to the selector expression.
	/// </summary>
	public static Expression<Func<TEntity, TResult>> Selector => DerivedInstance.SelectCore();

	// Cache instance of the derived selector
	private static readonly TResult _instance = CreateInstance();
	private static TResult DerivedInstance => _instance;

	private static TResult CreateInstance()
	{
		return (TResult)System.Activator.CreateInstance(
			typeof(TResult),
			nonPublic: true)!;
	}
}