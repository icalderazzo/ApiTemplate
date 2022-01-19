using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDatabaseInterface
{
    public class DbContext : IDbContext
    {
        private readonly string _connectionString;
        private IDbConnection? _connection;
        private IDbTransaction? _currentTransacction;

        /// <summary>
        /// List of tuples which stores data to be saved.
        /// Item1: the sql query
        /// Item2: data to be saves (or query parameters)
        /// </summary>
        private List<(string, object)> _dataToSave;

        public DbContext(string connectionString)
        {
            _connectionString = connectionString;
            _dataToSave = new();
        }

        public void Add<T>(string sql, T data)
        {
            _dataToSave.Add((sql, data));
        }

        public void Add(string sql, DynamicParameters parameters)
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _currentTransacction = _connection.BeginTransaction();
                _connection.Execute(sql, parameters, transaction: _currentTransacction);
            }
            catch (Exception)
            {
                if (_currentTransacction != null)
                {
                    _currentTransacction.Rollback();
                }
                throw;
            }
        }

        public ICollection<T> Get<T>(string query, object? parameters = null)
        {
            try
            {
                if (_connection != null)
                {
                    return _connection.Query<T>(query, parameters).ToList(); 
                }
                else
                {
                    using (IDbConnection conn = new SqlConnection(_connectionString))
                    {
                        var dbResult = conn.Query<T>(query, parameters);
                        return dbResult.ToList();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            try
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                    _connection.Open();
                    _currentTransacction = _connection.BeginTransaction();
                }
                foreach (var data in _dataToSave)
                {
                    _currentTransacction.Connection.Execute(data.Item1, data.Item2, transaction: _currentTransacction);
                }
                _currentTransacction.Commit();
            }
            catch (Exception)
            {
                if (_currentTransacction != null)
                {
                    _currentTransacction.Rollback();
                }
                throw;
            }
            finally
            {
                Reset();
            }
        }

        /// <summary>
        /// Resets the current state of the context.
        /// </summary>
        private void Reset()
        {
            _currentTransacction = null;
            _dataToSave.Clear();
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection = null;
            }
        }
    }
}