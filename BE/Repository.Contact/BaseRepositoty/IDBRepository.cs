using Database;
using System.Linq.Expressions;

namespace Repository.Contracts;

public interface IDBRepository<TFactDbContext> where TFactDbContext : FactDbContext
{
    #region Create
    Task<T> AddAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;

    Task<int> AddRangeAsync<T>(IEnumerable<T> entities, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;
    #endregion

    #region Update
    Task<T> UpdateAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;

    Task<int> UpdateRangeAsync<T>(IEnumerable<T> entities, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;
    #endregion

    #region Delete (use)
    Task<int> DeleteAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class;

    #endregion

    #region Delete (admin use only)
    Task<int> DeleteForAdminAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;
    Task<int> DeleteRangeForAdminAsync<T>(IEnumerable<T> entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;
    #endregion

    #region Retrive
    Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class;
    Task<List<R>> GetAsync<T, R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class;

    Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class;
    #endregion

    #region Query
    public IQueryable<T> GetSet<T>(Expression<Func<T, bool>> predicate) where T : class;

    public IQueryable<T> GetSetAsTracking<T>(Expression<Func<T, bool>> predicate) where T : class;
    #endregion

    #region Transaction
    Task ActionInTransaction(Func<Task> action);

    #endregion

    Task<int> SaveChangeAsync(bool clearTracker = false, CancellationToken cancellationToken = default);

}
