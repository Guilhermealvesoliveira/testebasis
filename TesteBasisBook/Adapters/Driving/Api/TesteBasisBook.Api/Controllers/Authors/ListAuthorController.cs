using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.Authors.Response;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Authors;

namespace TesteBasisBook.Api.Controllers.Authors
{
    public class ListAuthorController : BaseController
    {
        private readonly IListAuthorUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<ListAuthorController> _logger;

        public ListAuthorController(ILogger<ListAuthorController> logger, IListAuthorUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("Author")]
        [Route("/api/list-Authors")]
        public async Task<ActionResult<ListAuthorResponse>> Execute(CancellationToken cancellationToken)
        {
            return await Handle<ListAuthorInput, ListAuthorOutput, ListAuthorResponse, List<ListAuthorResponseData>>(
                
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
