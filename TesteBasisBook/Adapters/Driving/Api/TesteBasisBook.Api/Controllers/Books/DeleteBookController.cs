using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.Books.Request;
using TesteBasisBook.Api.Dtos.Books.Response;
using TesteBasisBook.Domain.Application.UseCases.Books;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;

namespace TesteBasisBook.Api.Controllers.Books
{
    public class DeleteBookController : BaseController
    {
        private readonly IDeleteBookUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<DeleteBookController> _logger;

        public DeleteBookController(ILogger<DeleteBookController> logger, IDeleteBookUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpDelete]
        [Tags("Book")]
        [Route("/api/delete-Book")]
        public async Task<ActionResult<DeleteBookResponse>> Execute([FromQuery] int BookId, CancellationToken cancellationToken)
        {
            return await Handle<DeleteBookInput, DeleteBookOutput, DeleteBookResponse, string>(
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
