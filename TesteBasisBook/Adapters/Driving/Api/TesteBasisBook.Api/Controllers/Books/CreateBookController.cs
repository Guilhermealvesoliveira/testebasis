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
    public class CreateBookController : BaseController
    {
        private readonly ICreateBookUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly IValidator<CreateBookRequest> _validator;
        private readonly ILogger<CreateBookController> _logger;

        public CreateBookController(ILogger<CreateBookController> logger, ICreateBookUseCase useCase, IMapperService mapperService, IValidator<CreateBookRequest> validator) : base(mapperService)
        {
            _useCase = useCase;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost]
        [Tags("Book")]
        [Route("/api/create-Book")]
        public async Task<ActionResult<CreateBookResponse>> Execute([FromBody] CreateBookRequest request, CancellationToken cancellationToken)
        {
            return await Handle<CreateBookRequest, CreateBookInput, CreateBookOutput, CreateBookResponse, string>(
                request,
                _validator,
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
