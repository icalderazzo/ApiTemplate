
namespace Core.Interfaces.Services
{
    public interface IService<T>
    {
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(int id);
        Task DeleteAsync(int id);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
    }
}
