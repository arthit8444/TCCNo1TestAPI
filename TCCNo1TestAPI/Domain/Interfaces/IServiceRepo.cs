using TCCNo1TestAPI.Domain.Entities;

namespace TCCNo1TestAPI.Domain.Interfaces
{
    public interface IServiceRepo<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
