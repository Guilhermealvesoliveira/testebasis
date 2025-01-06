using Microsoft.Extensions.Logging;
using System.Data;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Dtos;
using TesteBasisBook.Domain.Entity;
using TesteBasisBook.PostgreSQL.Dapper;

namespace TesteBasisBook.PostgreSQL.Repositories
{
    public class SaleTypeBookPriceRepository : GenericRepositoryAsync<SaleTypeBookPrice>, ISaleTypeBookPriceRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IDbConnection _connection;
        private readonly ILogger<GenericRepositoryAsync<SaleTypeBookPrice>> _logger;

        public SaleTypeBookPriceRepository(ISqlConnectionFactory sqlConnectionFactory, ILogger<GenericRepositoryAsync<SaleTypeBookPrice>> logger) : base(sqlConnectionFactory, "Livro_TipoVenda_Preco", "teste_basis", "SaleTypeBookPrice")
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _connection = _sqlConnectionFactory.GetOpenConnection();
            _logger = logger;
        }

        public async Task<IEnumerable<SaleTypeBookPriceDto>> GetSaleTypeBookPriceByBook(int bookId, CancellationToken cancellationToken)
        {
            try
            {
                var SQL = @"
                  SELECT ltp.""CodL"" as BookId,ltp.""CodTv"" as SaleTypeId,ltp.""Preco"" as Price,l.""Titulo"" as BookTitle, tv.""Descricao"" as SaleType
                    FROM teste_basis.""Livro_TipoVenda_Preco"" ltp
                    INNER JOIN teste_basis.""Livro"" l ON ltp.""CodL"" = l.""CodL""
                    INNER JOIN teste_basis.""TipoVenda"" tv ON ltp.""CodTv"" = tv.""CodTv""
                    WHERE ltp.""CodL"" = @bookId"
                ;

                using (var connection = _sqlConnectionFactory.GetOpenConnection())
                {
                    var result = await connection.QueryAsyncWithToken<SaleTypeBookPriceDto>(
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
        public async Task<SaleTypeBookPrice> GetSaleTypeBookPriceByBookAndType(int bookId, int saleTypeId, CancellationToken cancellationToken)
        {
            try
            {
                var SQL = @"
                  SELECT ltp.""CodTv"" as SaleTypeId,ltp.""CodL"" as BookId,ltp.""Preco"" as Price
                    FROM teste_basis.""Livro_TipoVenda_Preco"" ltp
                    WHERE ltp.""CodL"" = @bookId AND ltp.""CodTv"" = @saleTypeId"
                ;

                using (var connection = _sqlConnectionFactory.GetOpenConnection())
                {
                    var result = await connection.QuerySingleOrDefaultWithToken<SaleTypeBookPrice>(
                        SQL,
                        new { bookId, saleTypeId },
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

        public async Task DeleteSaleTypeBookPriceByBookAndType(int bookId, int saleTypeId, CancellationToken cancellationToken)
        {
            try
            {
                var SQL = @"
                  Delete
                    FROM teste_basis.""Livro_TipoVenda_Preco"" ltp
                    WHERE ltp.""CodL"" = @bookId AND ltp.""CodTv"" = @saleTypeId"
                ;

                using (var connection = _sqlConnectionFactory.GetOpenConnection())
                {
                    var result = await connection.ExecuteAsyncWithToken(
                        SQL,
                        new { bookId, saleTypeId },
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
