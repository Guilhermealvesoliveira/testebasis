using Microsoft.Extensions.Logging;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;
using TesteBasisBook.PostgreSQL.Dapper;

namespace TesteBasisBook.PostgreSQL.Repositories
{
    internal class AuthorBookRepository : GenericRepositoryAsync<AuthorBook>, IAuthorBookRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IDbConnection _connection;
        private readonly ILogger<GenericRepositoryAsync<AuthorBook>> _logger;

        public AuthorBookRepository(ISqlConnectionFactory sqlConnectionFactory, ILogger<GenericRepositoryAsync<AuthorBook>> logger) : base(sqlConnectionFactory, "Livro_Autor", "teste_basis", "SubjectBook")
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _connection = _sqlConnectionFactory.GetOpenConnection();
            _logger = logger;
        }
        public async Task<IEnumerable<int>> GetAuthorsByBook(int bookId, CancellationToken cancellationToken)
        {
            try
            {
                var SQL = @"
                  SELECT la.""CodAu""
                    FROM teste_basis.""Livro_Autor"" la
                    WHERE la.""CodL"" = @bookId"
                ;

                using (var connection = _sqlConnectionFactory.GetOpenConnection())
                {
                    var result = await connection.QueryAsyncWithToken<int>(
                        SQL,
                        new { bookId },
                        commandType: CommandType.Text,
                        cancellationToken: cancellationToken
                    );
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching AccountUser by UserId.");
                throw;
            }
        }

        public async Task DeleteAuthorsByBook(int bookId, CancellationToken cancellationToken)
        {
            try
            {
                var SQL = @"
                  DELETE
                    FROM teste_basis.Livro_Autor la
                    WHERE s.CodL = @bookId"
                ;

                using (var connection = _sqlConnectionFactory.GetOpenConnection())
                {
                    var result = await connection.ExecuteAsyncWithToken(
                        SQL,
                        new { bookId },
                        commandType: CommandType.Text,
                        cancellationToken: cancellationToken
                    );
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching AccountUser by UserId.");
                throw;
            }
        }
    }
}
