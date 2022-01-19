using Core.Interfaces.Infrastructure.Repositories;
using DapperDatabaseInterface;

namespace Repositories
{
    public class RepositoryBase<T> : IRepository<T>
    {
        protected readonly IDbContext _dbContext;
        public RepositoryBase(
            IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual T Create(T entity)
        {
            try
            {
                // *This code should be implemented in each repository because Dapper needs the queries* //

                //string query = "INSERT INTO TABLE (A1, A2, A3) VALUES (@A1, @A2, @A3)";
                //_dbContext.Add(query, entity);
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
