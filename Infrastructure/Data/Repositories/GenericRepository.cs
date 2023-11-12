using Domain.Interfaces.Repositories;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public abstract class GenericRepository<T> : IRepository<T> where T : class
{
    protected readonly AirportDatabaseContext DatabaseContext;
    protected readonly DbSet<T> Table;

    public GenericRepository(AirportDatabaseContext databaseContext)
    {
        this.DatabaseContext = databaseContext;
        Table = databaseContext.Set<T>();
    }
    
    public virtual async Task<IEnumerable<T>> GetAsync() => await Table.ToListAsync();

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await Table.FindAsync(id)
               ?? throw new EntityNotFoundException(
                   GetEntityNotFoundErrorMessage(id));
    }

    public abstract Task<T> GetCompleteEntityAsync(int id);

    public virtual async Task<T> InsertAsync(T entity)
    {
        var ent = await Table.AddAsync(entity);
        
        return ent.Entity;
    }

    public virtual Task UpdateAsync(T entity)
    {
        Table.Update(entity);
        return Task.CompletedTask;
    }
    public virtual Task UpdateAsync(T entity, T oldEntity)
    {
        DatabaseContext.Entry(oldEntity).State = EntityState.Detached;
        
        Table.Update(entity);
        return Task.CompletedTask;
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        Table.Remove(entity);
    }

    public string GetEntityNotFoundErrorMessage(int id) =>
        $"{typeof(T).Name} with id {id} not found.";

}