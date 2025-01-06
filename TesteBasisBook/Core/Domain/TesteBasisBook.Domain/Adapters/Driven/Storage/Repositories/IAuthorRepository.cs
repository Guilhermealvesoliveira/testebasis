using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories
{
    public interface IAuthorRepository: IGenericRepositoryAsync<Author>
    {
        Task<Author> GetAuthorByNameAsync(string name, CancellationToken cancellationToken);
    }
}
