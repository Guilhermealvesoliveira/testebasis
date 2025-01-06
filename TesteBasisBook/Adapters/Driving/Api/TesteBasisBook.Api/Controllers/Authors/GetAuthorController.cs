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
    public class GetAuthorController : BaseController
    {
        private readonly IGetAuthorUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<GetAuthorController> _logger;

        public GetAuthorController(ILogger<GetAuthorController> logger, IGetAuthorUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("Author")]
        [Route("/api/get-author")]
        public async Task<ActionResult<GetAuthorResponse>> Execute([FromQuery] int AuthorId, CancellationToken cancellationToken)
        {
            return await Handle< GetAuthorInput, GetAuthorOutput, GetAuthorResponse, GetAuthorResponseData>(
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
