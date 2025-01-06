using Microsoft.Extensions.Logging;
using System.Data;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;
using TesteBasisBook.PostgreSQL.Dapper;

namespace TesteBasisBook.PostgreSQL.Repositories
{
    public class SaleTypeRepository : GenericRepositoryAsync<SaleType>, ISaleTypeRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IDbConnection _connection;
        private readonly ILogger<GenericRepositoryAsync<SaleType>> _logger;

        public SaleTypeRepository(ISqlConnectionFactory sqlConnectionFactory, ILogger<GenericRepositoryAsync<SaleType>> logger) : base(sqlConnectionFactory, "TipoVenda", "teste_basis", "SaleType")
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _connection = _sqlConnectionFactory.GetOpenConnection();
            _logger = logger;
        }
        public async Task<SaleType> GetSaleTypeByDescriptionAsync(string description, CancellationToken cancellationToken)
        {
            try
            {
                var SQL = @"
                  SELECT s.""CodTv"",s.""Descricao""
                    FROM teste_basis.""TipoVenda"" s
                    WHERE s.""Descricao"" = @description"
                ;

                using (var connection = _sqlConnectionFactory.GetOpenConnection())
                {
                    var result = await connection.QuerySingleOrDefaultWithToken<SaleType>(
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
