using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories
{
    public interface ISubjectBookRepository : IGenericRepositoryAsync<SubjectBook>
    {
        Task<IEnumerable<int>> GetSubjectsByBook(int bookId, CancellationToken cancellationToken);
        Task DeleteSubjectsByBook(int bookId, CancellationToken cancellationToken);
    }
}
