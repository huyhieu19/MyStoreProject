using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System.Linq.Expressions;

namespace Repository.BaseRepository;

public sealed class DBRepository<TDbContext> : IDBRepository<TDbContext> where TDbContext : FactDbContext
{
    public readonly TDbContext dbContext;

    public DBRepository(TDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    #region Create

    public async Task<T> AddAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        var entry = await dbContext.AddAsync(entity, cancellationToken);
        await SaveChangeAsync(clearTracker, cancellationToken);
        return entry.Entity;
    }

    public async Task<int> AddRangeAsync<T>(IEnumerable<T> entities, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        await dbContext.AddRangeAsync(entities, cancellationToken);
        var result = await SaveChangeAsync(clearTracker, cancellationToken);
        return result;
    }

    #endregion Create

    #region Update

    public async Task<T> UpdateAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        var result = dbContext.Set<T>().Update(entity);
        await SaveChangeAsync(clearTracker, cancellationToken);
        return result.Entity;
    }

    public async Task<int> UpdateRangeAsync<T>(IEnumerable<T> entities, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        foreach (var entity in entities)
        {
            dbContext.Set<T>().Update(entity);
        }
        var result = await SaveChangeAsync(clearTracker, cancellationToken);
        return result;
    }

    #endregion Update

    #region Delete (use)

    public async Task<int> DeleteAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
    {
        var entity = await dbContext.Set<T>().AsTracking().FirstOrDefaultAsync(predicate, cancellationToken);

        if (entity == null)
        {
            throw new Exception("can not found");
        }
        if (entity is BaseIdEntity deletableEntity)
        {
            deletableEntity.IsDeleted = true;
            dbContext.Set<T>().Update(entity);
        }
        else
        {
            dbContext.Set<T>().Remove(entity);
        }
        return await SaveChangeAsync();
    }

    #endregion Delete (use)

    #region Delete (admin use only)

    public async Task<int> DeleteForAdminAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        dbContext.Set<T>().Remove(entity);
        var result = await SaveChangeAsync(clearTracker, cancellationToken);
        return result;
    }

    public async Task<int> DeleteRangeForAdminAsync<T>(IEnumerable<T> entities, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        dbContext.Set<T>().RemoveRange(entities);
        var result = await SaveChangeAsync(clearTracker, cancellationToken);
        return result;
    }

    #endregion Delete (admin use only)

    #region Retrive

    public async Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class
    {
        if (predicate == null)
        {
            return await dbContext.Set<T>().ToListAsync(cancellationToken);
        }
        return await dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<List<R>> GetAsync<T, R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class
    {
        if (predicate == null)
        {
            return await dbContext.Set<T>().Select(selector).ToListAsync(cancellationToken);
        }
        return await dbContext.Set<T>().Where(predicate).Select(selector).ToListAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class
    {
        return await dbContext.Set<T>().AnyAsync(predicate, cancellationToken);
    }

    // get with paging

    #endregion Retrive

    #region Query

    public IQueryable<T> GetSet<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        if (predicate == null)
        {
            return dbContext.Set<T>();
        }
        return dbContext.Set<T>().Where(predicate);
    }

    public IQueryable<T> GetSetAsTracking<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        if (predicate == null)
        {
            return dbContext.Set<T>().AsTracking();
        }
        return dbContext.Set<T>().Where(predicate).AsTracking();
    }

    #endregion Query

    #region Transaction

    public async Task ActionInTransaction(Func<Task> action)
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                // Perform multiple database operations within the transaction
                await action();
                // Commit the transaction
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                // Rollback the transaction if any operation fails
                transaction.Rollback();
            }
        }
    }

    #endregion Transaction

    #region Clear tracker

    public async Task<int> SaveChangeAsync(bool clearTracker = false, CancellationToken cancellationToken = default)
    {
        var result = await dbContext.SaveChangesAsync(cancellationToken);
        if (clearTracker)
        {
            dbContext.ChangeTracker.Clear();
        }
        return result;
    }

    #endregion Clear tracker
}