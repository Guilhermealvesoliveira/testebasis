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
    public class UpdateBookController : BaseController
    {
        private readonly IUpdateBookUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly IValidator<UpdateBookRequest> _validator;
        private readonly ILogger<UpdateBookController> _logger;

        public UpdateBookController(ILogger<UpdateBookController> logger, IUpdateBookUseCase useCase, IMapperService mapperService, IValidator<UpdateBookRequest> validator) : base(mapperService)
        {
            _useCase = useCase;
            _validator = validator;
            _logger = logger;
        }

        [HttpPut]
        [Tags("Book")]
        [Route("/api/update-Book")]
        public async Task<ActionResult<UpdateBookResponse>> Execute([FromBody] UpdateBookRequest request, CancellationToken cancellationToken)
        {
            return await Handle<UpdateBookRequest, UpdateBookInput, UpdateBookOutput, UpdateBookResponse, string>(
                request,
                _validator,
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
