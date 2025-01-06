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
    public class GetBookController : BaseController
    {
        private readonly IGetBookUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<GetBookController> _logger;

        public GetBookController(ILogger<GetBookController> logger, IGetBookUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("Book")]
        [Route("/api/get-Book")]
        public async Task<ActionResult<GetBookResponse>> Execute([FromQuery] int BookId, CancellationToken cancellationToken)
        {
            return await Handle< GetBookInput, GetBookOutput, GetBookResponse, GetBookResponseData>(
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
