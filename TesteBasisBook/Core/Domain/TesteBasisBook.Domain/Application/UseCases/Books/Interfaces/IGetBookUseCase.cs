using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Books
{
    public interface IGetBookUseCase
    {
        Task<GetBookOutput> ExecuteAsync(GetBookInput input, CancellationToken cancellationToken);
    }
}
