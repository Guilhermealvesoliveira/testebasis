using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Authors;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;

namespace TesteBasisBook.Application.UseCases.Authors
{
    public class ListAuthorUseCase : IListAuthorUseCase
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly ILogger<ListAuthorUseCase> _logger;

        public ListAuthorUseCase(IAuthorRepository AuthorRepository, ILogger<ListAuthorUseCase> logger)
        {
            _logger = logger;
            _AuthorRepository = AuthorRepository;
        }

        public async Task<ListAuthorOutput> ExecuteAsync(ListAuthorInput input, CancellationToken cancellationToken)
        {
            try
            {
               
                var Authors = await _AuthorRepository.GetAllAsync(cancellationToken);

                if (!Authors.Any())
                {
                    return new ListAuthorOutput
                    {
                        IsSuccess = false,
                        Message = "No Author has been registered"
                    };
                }

                var ListAuthors = new List<ListAuthorOutputData>();

                foreach (var Author in Authors)
                {
                    ListAuthors.Add(
                        new ListAuthorOutputData
                        {
                            AuthorId = Author.AuthorId,
                            Name = Author.Name
                        });
                }

                return new ListAuthorOutput
                {
                    IsSuccess = true,
                    Data = ListAuthors,
                    Message = "Get list successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ListAuthorOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
