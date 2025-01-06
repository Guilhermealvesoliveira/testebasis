using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.Subjects.Request;
using TesteBasisBook.Api.Dtos.Subjects.Response;
using TesteBasisBook.Domain.Application.UseCases.Subjects.GetSubject;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Api.Controllers.Subjects
{
    public class GetSubjectController : BaseController
    {
        private readonly IGetSubjectUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<GetSubjectController> _logger;

        public GetSubjectController(ILogger<GetSubjectController> logger, IGetSubjectUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("Subject")]
        [Route("/api/get-subject")]
        public async Task<ActionResult<GetSubjectResponse>> Execute([FromQuery] int subjectId, CancellationToken cancellationToken)
        {
            return await Handle< GetSubjectInput, GetSubjectOutput, GetSubjectResponse, GetSubjectResponseData>(
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
