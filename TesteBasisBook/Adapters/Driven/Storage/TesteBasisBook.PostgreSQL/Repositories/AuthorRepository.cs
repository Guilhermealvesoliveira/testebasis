using Microsoft.Extensions.Logging;
using System.Data;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;
using TesteBasisBook.PostgreSQL.Dapper;

namespace TesteBasisBook.PostgreSQL.Repositories
{
    public class AuthorRepository : GenericRepositoryAsync<Author>, IAuthorRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IDbConnection _connection;
        private readonly ILogger<GenericRepositoryAsync<Author>> _logger;

        public AuthorRepository(ISqlConnectionFactory sqlConnectionFactory, ILogger<GenericRepositoryAsync<Author>> logger) : base(sqlConnectionFactory, "Autor", "teste_basis", "SubjectBook")
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _connection = _sqlConnectionFactory.GetOpenConnection();
            _logger = logger;
        }
        public async Task<Author> GetAuthorByNameAsync(string name, CancellationToken cancellationToken)
        {
            try
            {
                var SQL = @"
                  SELECT a.""CodAu"",a.""Nome""
                    FROM teste_basis.""Autor"" a
                    WHERE a.""Nome"" = @name"
                ;

                using (var connection = _sqlConnectionFactory.GetOpenConnection())
                {
                    var result = await connection.QuerySingleOrDefaultWithToken<Author>(
                        SQL,
                        new { name },
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
    }

}