using System.Data;
using Dapper;
namespace TesteBasisBook.PostgreSQL.Dapper
{
    public static class DapperExtensionsAsync
    {
        public static async Task<int> ExecuteAsyncWithToken(this IDbConnection cnn,
            string sql,
            object param = null!,
            IDbTransaction transaction = null!,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CancellationToken cancellationToken = default)
        {
            return await cnn.ExecuteAsync(
                new CommandDefinition(sql, param, transaction, commandTimeout, commandType, cancellationToken: cancellationToken));
        }
        public static async Task<int> ExecuteScalarAsyncWithToken(this IDbConnection cnn,
           string sql,
           object param = null!,
           IDbTransaction transaction = null!,
           int? commandTimeout = null,
           CommandType? commandType = null,
           CancellationToken cancellationToken = default)
        {
            return await cnn.ExecuteScalarAsync<int>(
                new CommandDefinition(sql, param, transaction, commandTimeout, commandType, cancellationToken: cancellationToken));
        }
        public static async Task<IEnumerable<T>> QueryAsyncWithToken<T>(this IDbConnection cnn,
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CancellationToken cancellationToken = default)
        {
            return await cnn.QueryAsync<T>(new CommandDefinition(sql, param, transaction, commandTimeout, commandType,
                cancellationToken: cancellationToken));
        }

        public static async Task<T> QuerySingleOrDefaultWithToken<T>(this IDbConnection cnn,
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await cnn.QuerySingleOrDefaultAsync<T>(new CommandDefinition(sql, param, transaction, commandTimeout, commandType,
                               cancellationToken: cancellationToken));
            }
            catch(Exception ex)
            {
                var e = ex;
                throw;
            }
           
        }

        public static async Task<T> QuerySingleWithToken<T>(this IDbConnection cnn,
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CancellationToken cancellationToken = default)
        {
            return await cnn.QuerySingleAsync<T>(new CommandDefinition(sql, param, transaction, commandTimeout, commandType,
                cancellationToken: cancellationToken));
        }
    }

}
