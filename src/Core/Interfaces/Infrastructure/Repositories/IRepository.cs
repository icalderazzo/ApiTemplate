
namespace Core.Interfaces.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        void Delete(int id);
        Task DeleteAsync(int id);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
