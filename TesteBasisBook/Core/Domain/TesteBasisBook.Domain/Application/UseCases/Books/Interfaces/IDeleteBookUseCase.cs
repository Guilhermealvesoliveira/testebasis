using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Books
{
    public interface IDeleteBookUseCase
    {
        Task<DeleteBookOutput> ExecuteAsync(DeleteBookInput input, CancellationToken cancellationToken);
    }
}
