using System.Data;
using Npgsql;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
namespace TesteBasisBook.PostgreSQL.Dapper
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            if ((_connection == null || _connection.State != ConnectionState.Open) && !string.IsNullOrEmpty(_connectionString))
            {
                _connection = new NpgsqlConnection(_connectionString);
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }
        }
    }
}
