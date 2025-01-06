using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Authors;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.UseCases.Authors
{
    public class GetAuthorUseCase : IGetAuthorUseCase
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly ILogger<GetAuthorUseCase> _logger;

        public GetAuthorUseCase(IAuthorRepository AuthorRepository, ILogger<GetAuthorUseCase> logger)
        {
            _logger = logger;
            _AuthorRepository = AuthorRepository;
        }

        public async Task<GetAuthorOutput> ExecuteAsync(GetAuthorInput input, CancellationToken cancellationToken)
        {
            try
            {
                var Author = await _AuthorRepository.GetAsync(input.AuthorId, cancellationToken);
                if (Author == default)
                {
                    return new GetAuthorOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "Author not found",

                    };
                }

                return new GetAuthorOutput
                {
                    IsSuccess = true,
                    Message = "Author Get successfully",
                    Data = new GetAuthorOutputData
                    {
                        Name = Author.Name,
                        AuthorId = Author.AuthorId,
                    }

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetAuthorOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
