using Core.Interfaces.Infrastructure.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class ServiceBase<T> : IService<T>
    {
        protected readonly IRepository<T> _repository;
        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual void Create(T entity)
        {
            try
            {
                _repository.Create(entity);

                // *The SaveChanges method should be called by the service whenever data wants to be saved in the database* //
                //_repository.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            try
            {
                _repository.Update(entity);
                //_repository.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
