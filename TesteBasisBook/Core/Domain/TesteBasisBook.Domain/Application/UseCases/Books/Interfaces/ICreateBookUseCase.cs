using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Books
{
    public interface ICreateBookUseCase
    {
        Task<CreateBookOutput> ExecuteAsync(CreateBookInput input, CancellationToken cancellationToken);
    }
}
