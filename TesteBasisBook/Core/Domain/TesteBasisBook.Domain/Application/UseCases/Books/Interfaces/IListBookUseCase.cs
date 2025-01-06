using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Books
{
    public interface IListBookUseCase
    {
        Task<ListBookOutput> ExecuteAsync(ListBookInput input, CancellationToken cancellationToken);
    }
}
