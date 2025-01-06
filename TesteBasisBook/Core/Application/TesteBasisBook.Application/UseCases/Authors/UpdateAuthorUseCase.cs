using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Authors;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.UseCases.Authors
{
    public class UpdateAuthorUseCase : IUpdateAuthorUseCase
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly ILogger<UpdateAuthorUseCase> _logger;

        public UpdateAuthorUseCase(IAuthorRepository AuthorRepository, ILogger<UpdateAuthorUseCase> logger)
        {
            _logger = logger;
            _AuthorRepository = AuthorRepository;
        }

        public async Task<UpdateAuthorOutput> ExecuteAsync(UpdateAuthorInput input, CancellationToken cancellationToken)
        {
            try
            {
                var Author = await _AuthorRepository.GetAsync(input.AuthorId, cancellationToken);
                if (Author == default)
                {
                    return new UpdateAuthorOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "Author not found",

                    };
                }

                Author.Name = input.Name;
                await _AuthorRepository.UpdateAsync(Author, cancellationToken);

                return new UpdateAuthorOutput
                {
                    IsSuccess = true,
                    Message = "Author updated successfully"

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new UpdateAuthorOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
