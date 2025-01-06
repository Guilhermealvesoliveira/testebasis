using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories
{
    public interface IAuthorBookRepository : IGenericRepositoryAsync<AuthorBook>
    {
        Task<IEnumerable<int>> GetAuthorsByBook(int bookId, CancellationToken cancellationToken);
        Task DeleteAuthorsByBook(int bookId, CancellationToken cancellationToken);
    }
}
