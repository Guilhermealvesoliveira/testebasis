using Microsoft.Extensions.Logging;
using System.Data;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;
using TesteBasisBook.PostgreSQL.Dapper;

namespace TesteBasisBook.PostgreSQL.Repositories
{
    public class SubjectBookRepository : GenericRepositoryAsync<SubjectBook>, ISubjectBookRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IDbConnection _connection;
        private readonly ILogger<GenericRepositoryAsync<SubjectBook>> _logger;

        public SubjectBookRepository(ISqlConnectionFactory sqlConnectionFactory, ILogger<GenericRepositoryAsync<SubjectBook>> logger) : base(sqlConnectionFactory, "Livro_Assunto", "teste_basis", "SubjectBook")
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _connection = _sqlConnectionFactory.GetOpenConnection();
            _logger = logger;
        }
        public async Task<IEnumerable<int>> GetSubjectsByBook(int bookId, CancellationToken cancellationToken)
        {
            try
            {
                var SQL = @"
                  SELECT la.""CodAs""
                    FROM teste_basis.""Livro_Assunto"" la
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
        public async Task DeleteSubjectsByBook(int bookId, CancellationToken cancellationToken)
        {
            try
            {
                var SQL = @"
                  DELETE
                    FROM teste_basis.Livro_Assunto la
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
