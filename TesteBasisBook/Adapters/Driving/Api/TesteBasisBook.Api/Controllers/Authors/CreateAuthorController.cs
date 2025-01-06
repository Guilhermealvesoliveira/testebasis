using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.Authors.Request;
using TesteBasisBook.Api.Dtos.Authors.Response;
using TesteBasisBook.Domain.Application.UseCases.Authors;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;

namespace TesteBasisBook.Api.Controllers.Authors
{
    public class CreateAuthorController : BaseController
    {
        private readonly ICreateAuthorUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly IValidator<CreateAuthorRequest> _validator;
        private readonly ILogger<CreateAuthorController> _logger;

        public CreateAuthorController(ILogger<CreateAuthorController> logger, ICreateAuthorUseCase useCase, IMapperService mapperService, IValidator<CreateAuthorRequest> validator) : base(mapperService)
        {
            _useCase = useCase;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost]
        [Tags("Author")]
        [Route("/api/create-Author")]
        public async Task<ActionResult<CreateAuthorResponse>> Execute([FromBody] CreateAuthorRequest request, CancellationToken cancellationToken)
        {
            return await Handle<CreateAuthorRequest, CreateAuthorInput, CreateAuthorOutput, CreateAuthorResponse, string>(
                request,
                _validator,
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
