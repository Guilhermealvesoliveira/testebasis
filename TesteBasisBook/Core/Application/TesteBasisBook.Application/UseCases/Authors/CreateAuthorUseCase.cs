using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Authors;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Application.UseCases.Authors
{
    public class CreateAuthorUseCase : ICreateAuthorUseCase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<CreateAuthorUseCase> _logger;

        public CreateAuthorUseCase(IAuthorRepository AuthorRepository, ILogger<CreateAuthorUseCase> logger)
        {
            _logger = logger;
            _authorRepository = AuthorRepository;
        }

        public async Task<CreateAuthorOutput> ExecuteAsync(CreateAuthorInput input, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _authorRepository.GetAuthorByNameAsync(input.Name, cancellationToken);

                if (author != default)
                {
                    return new CreateAuthorOutput
                    {
                        IsSuccess = false,
                        Message = "Author already",
                        BusinessRuleViolation = true,
                    };
                }
                var newAuthor = new Author
                {
                    Name = input.Name,
                };
                await _authorRepository.InsertAsync(newAuthor, cancellationToken);

                return new CreateAuthorOutput
                {
                    IsSuccess = true,
                    Message = "Author saved successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new CreateAuthorOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve Author."
                };
            }
        }
    }
}
