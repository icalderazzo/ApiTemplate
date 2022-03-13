using Dapper;

namespace DapperDatabaseInterface
{
    /// <summary>
    /// Database context implemented with Dapper micro ORM.
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Gets a collection of T from the database.
        /// </summary>
        /// <typeparam name="T">Type of return object</typeparam>
        /// <param name="query">Sql query</param>
        /// <param name="parameters">Parameters for the query</param>
        /// <returns></returns>
        ICollection<T> Get<T>(string query, object? parameters = null);

        Task<ICollection<T>> GetAsync<T>(string query, object? parameters = null);

        /// <summary>
        /// Stores data locally in the database context.
        /// </summary>
        /// <typeparam name="T">Type of object to save</typeparam>
        /// <param name="sql">Sql query; Could be an INSERT, UPDATE or DELETE query</param>
        /// <param name="data">Data to be saved (parameters for the query)</param>
        void Add<T>(string sql, T data);

        /// <summary>
        /// Sends data to the database (on a new transaction) using DynamicParamters in order
        /// to be able to get 'out' parameters, eg: a database generated primary key.
        /// </summary>
        /// <param name="sql">Sql query; Could be an INSERT, UPDATE or DELETE query</param>
        /// <param name="parameters">Parameters for the query</param>
        void Add(string sql, DynamicParameters parameters);

        /// <summary>
        /// If a transaction is not already opened, it opens a new one and starts to send locally
        /// stored data to the database.
        /// </summary>
        void SaveChanges();

        Task SaveChangesAsync();
    }
}