using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Authors;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.UseCases.Authors
{
    public class DeleteAuthorUseCase : IDeleteAuthorUseCase
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly ILogger<DeleteAuthorUseCase> _logger;

        public DeleteAuthorUseCase(IAuthorRepository AuthorRepository, ILogger<DeleteAuthorUseCase> logger)
        {
            _logger = logger;
            _AuthorRepository = AuthorRepository;
        }

        public async Task<DeleteAuthorOutput> ExecuteAsync(DeleteAuthorInput input, CancellationToken cancellationToken)
        {
            try
            {
                var Author = await _AuthorRepository.GetAsync(input.AuthorId, cancellationToken);
                if (Author == default)
                {
                    return new DeleteAuthorOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "Author not found",

                    };
                }

                await _AuthorRepository.DeleteAsync(Author.AuthorId, cancellationToken);

                return new DeleteAuthorOutput
                {
                    IsSuccess = true,
                    Message = "Author deleted successfully"

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new DeleteAuthorOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
