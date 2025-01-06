using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.Subjects.Request;
using TesteBasisBook.Api.Dtos.Subjects.Response;
using TesteBasisBook.Domain.Application.UseCases.Subjects.DeleteSubject;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Api.Controllers.Subjects
{
    public class DeleteSubjectController : BaseController
    {
        private readonly IDeleteSubjectUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<DeleteSubjectController> _logger;

        public DeleteSubjectController(ILogger<DeleteSubjectController> logger, IDeleteSubjectUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpDelete]
        [Tags("Subject")]
        [Route("/api/delete-subject")]
        public async Task<ActionResult<DeleteSubjectResponse>> Execute([FromQuery] int subjectId, CancellationToken cancellationToken)
        {
            return await Handle<DeleteSubjectInput, DeleteSubjectOutput, DeleteSubjectResponse, string>(
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
