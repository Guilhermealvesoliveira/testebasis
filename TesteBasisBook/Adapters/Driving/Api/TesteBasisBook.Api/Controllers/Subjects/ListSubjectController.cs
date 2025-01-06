using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.Subjects.Response;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.ListSubject;

namespace TesteBasisBook.Api.Controllers.Subjects
{
    public class ListSubjectController : BaseController
    {
        private readonly IListSubjectUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<ListSubjectController> _logger;

        public ListSubjectController(ILogger<ListSubjectController> logger, IListSubjectUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("Subject")]
        [Route("/api/list-subjects")]
        public async Task<ActionResult<ListSubjectResponse>> Execute(CancellationToken cancellationToken)
        {
            return await Handle<ListSubjectInput, ListSubjectOutput, ListSubjectResponse, List<ListSubjectResponseData>>(
                
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
