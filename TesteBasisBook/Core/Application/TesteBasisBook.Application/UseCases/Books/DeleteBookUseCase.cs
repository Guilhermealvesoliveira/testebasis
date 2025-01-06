using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Books;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.UseCases.Books
{
    public class DeleteBookUseCase : IDeleteBookUseCase
    {
        private readonly IBookRepository _BookRepository;
        private readonly ILogger<DeleteBookUseCase> _logger;

        public DeleteBookUseCase(IBookRepository BookRepository, ILogger<DeleteBookUseCase> logger)
        {
            _logger = logger;
            _BookRepository = BookRepository;
        }

        public async Task<DeleteBookOutput> ExecuteAsync(DeleteBookInput input, CancellationToken cancellationToken)
        {
            try
            {
                var Book = await _BookRepository.GetAsync(input.BookId, cancellationToken);
                if (Book == default)
                {
                    return new DeleteBookOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "Book not found",

                    };
                }

                await _BookRepository.DeleteAsync(Book.BookId, cancellationToken);

                return new DeleteBookOutput
                {
                    IsSuccess = true,
                    Message = "Book deleted successfully"

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new DeleteBookOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
