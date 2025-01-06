using Microsoft.Extensions.Logging;
using System.Data;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;
using TesteBasisBook.PostgreSQL.Dapper;

namespace TesteBasisBook.PostgreSQL.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IDbConnection _connection;
        private readonly ILogger<GenericRepositoryAsync<Subject>> _logger;

        public SubjectRepository(ISqlConnectionFactory sqlConnectionFactory, ILogger<GenericRepositoryAsync<Subject>> logger) : base(sqlConnectionFactory, "Assunto", "teste_basis", "Subject")
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _connection = _sqlConnectionFactory.GetOpenConnection();
            _logger = logger;
        }

        public async Task<Subject> GetSubjectByDescriptionAsync(string description, CancellationToken cancellationToken)
        {
            try
            {
                var SQL = @"
                  SELECT s.""CodAs"",s.""Descricao""
                    FROM teste_basis.""Assunto"" s
                    WHERE s.""Descricao"" = @description"
                ;

                using (var connection = _sqlConnectionFactory.GetOpenConnection())
                {
                    var result = await connection.QuerySingleOrDefaultWithToken<Subject>(
                        SQL,
                        new { description },
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
