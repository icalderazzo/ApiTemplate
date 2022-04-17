using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDatabaseInterface;

public class DbContext : IDbContext
{
    private readonly string _connectionString;
    private IDbConnection? _connection;
    private IDbTransaction? _currentTransacction;

    /// <summary>
    /// List of tuples which stores data to be saved.
    /// Item1: the sql query
    /// Item2: data to be saved (or query parameters)
    /// </summary>
    private readonly List<(string, object?)> _dataToSave;

    public DbContext(string connectionString)
    {
        _connectionString = connectionString;
        _dataToSave = new List<(string, object?)>();
    }

    public void Add<T>(string sql, T data)
    {
        if (data == null)
            throw new NullReferenceException();

        _dataToSave.Add((sql, data));
    }

    public void Add(string sql, DynamicParameters parameters)
    {
        try
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
            _currentTransacction = _connection.BeginTransaction();
            _connection.Execute(sql, parameters, _currentTransacction);
        }
        catch (Exception)
        {
            _currentTransacction?.Rollback();
            throw;
        }
    }

    public void Delete(string sql, object? parameters = null)
    {
        _dataToSave.Add((sql, parameters));
    }

    public ICollection<T> Get<T>(string query, object? parameters = null)
    {
        try
        {
            if (_connection != null)
            {
                return _connection.Query<T>(query, parameters).ToList(); 
            }

            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var dbResult = conn.Query<T>(query, parameters);
                return dbResult.ToList();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ICollection<T>> GetAsync<T>(string query, object? parameters = null)
    {
        try
        {
            if (_connection != null)
            {
                var result = await _connection.QueryAsync<T>(query, parameters);
                return result.ToList(); 
            }

            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var dbResult = await conn.QueryAsync<T>(query, parameters);
                return dbResult.ToList();
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
                _currentTransacction.Connection.Execute(data.Item1, data.Item2, _currentTransacction);
            }
            _currentTransacction.Commit();
        }
        catch (Exception)
        {
            _currentTransacction?.Rollback();
            throw;
        }
        finally
        {
            Reset();
        }
    }

    public async Task SaveChangesAsync()
    {
        try
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _currentTransacction = _connection.BeginTransaction();
            }
            foreach (var (item1, item2) in _dataToSave)
            {
                await _currentTransacction.Connection.ExecuteAsync(item1, item2, _currentTransacction);
            }
            _currentTransacction.Commit();   
        }
        catch (Exception)
        {
            _currentTransacction?.Rollback();
            throw;             
        }
        finally
        {
            Reset();
        }
    }

    public void Update<T>(string sql, T data)
    {
        if (data == null)
            throw new NullReferenceException();

        _dataToSave.Add((sql, data));
    }

    /// <summary>
    /// Resets the current state of the context.
    /// </summary>
    private void Reset()
    {
        _currentTransacction = null;
        _dataToSave.Clear();
        if (_connection is not {State: ConnectionState.Open}) return;
        _connection.Close();
        _connection = null;
    }
}