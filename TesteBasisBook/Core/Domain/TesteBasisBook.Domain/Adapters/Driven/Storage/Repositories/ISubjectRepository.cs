
using System.Data;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories
{
    public interface ISubjectRepository : IGenericRepositoryAsync<Subject>
    {
        Task<Subject> GetSubjectByDescriptionAsync(string description, CancellationToken cancellationToken);

    }
}
