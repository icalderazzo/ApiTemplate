
namespace Core.Interfaces.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        T Update(T entity);
        T GetById(int id);
        List<T> GetAll();
        void SaveChanges();
    }
}
