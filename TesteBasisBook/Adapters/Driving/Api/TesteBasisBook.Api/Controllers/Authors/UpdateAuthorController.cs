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
    public class UpdateAuthorController : BaseController
    {
        private readonly IUpdateAuthorUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly IValidator<UpdateAuthorRequest> _validator;
        private readonly ILogger<UpdateAuthorController> _logger;

        public UpdateAuthorController(ILogger<UpdateAuthorController> logger, IUpdateAuthorUseCase useCase, IMapperService mapperService, IValidator<UpdateAuthorRequest> validator) : base(mapperService)
        {
            _useCase = useCase;
            _validator = validator;
            _logger = logger;
        }

        [HttpPut]
        [Tags("Author")]
        [Route("/api/update-Author")]
        public async Task<ActionResult<UpdateAuthorResponse>> Execute([FromBody] UpdateAuthorRequest request, CancellationToken cancellationToken)
        {
            return await Handle<UpdateAuthorRequest, UpdateAuthorInput, UpdateAuthorOutput, UpdateAuthorResponse, string>(
                request,
                _validator,
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
