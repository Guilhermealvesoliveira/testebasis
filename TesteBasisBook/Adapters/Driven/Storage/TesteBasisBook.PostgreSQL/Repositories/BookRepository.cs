using Microsoft.Extensions.Logging;
using System.Data;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.PostgreSQL.Repositories
{
    public class BookRepository : GenericRepositoryAsync<Book>, IBookRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IDbConnection _connection;
        private readonly ILogger<GenericRepositoryAsync<Book>> _logger;

        public BookRepository(ISqlConnectionFactory sqlConnectionFactory, ILogger<GenericRepositoryAsync<Book>> logger) : base(sqlConnectionFactory, "Livro", "teste_basis", "Book")
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _connection = _sqlConnectionFactory.GetOpenConnection();
            _logger = logger;
        }
    }
}
