namespace Domain.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAsync();

    Task<T> GetByIdAsync(int id);

    Task<T> GetCompleteEntityAsync(int id);

    Task<T> InsertAsync(T entity);

    Task UpdateAsync(T entity);
    Task UpdateAsync(T entity, T oldEntity);

    Task DeleteAsync(int id);
    string GetEntityNotFoundErrorMessage(int id);
}
