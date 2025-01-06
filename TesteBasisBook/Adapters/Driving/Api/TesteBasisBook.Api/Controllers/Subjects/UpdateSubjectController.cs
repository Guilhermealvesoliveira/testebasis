using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.Subjects.Request;
using TesteBasisBook.Api.Dtos.Subjects.Response;
using TesteBasisBook.Domain.Application.UseCases.Subjects.UpdateSubject;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Api.Controllers.Subjects
{
    public class UpdateSubjectController : BaseController
    {
        private readonly IUpdateSubjectUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly IValidator<UpdateSubjectRequest> _validator;
        private readonly ILogger<UpdateSubjectController> _logger;

        public UpdateSubjectController(ILogger<UpdateSubjectController> logger, IUpdateSubjectUseCase useCase, IMapperService mapperService, IValidator<UpdateSubjectRequest> validator) : base(mapperService)
        {
            _useCase = useCase;
            _validator = validator;
            _logger = logger;
        }

        [HttpPut]
        [Tags("Subject")]
        [Route("/api/update-subject")]
        public async Task<ActionResult<UpdateSubjectResponse>> Execute([FromBody] UpdateSubjectRequest request, CancellationToken cancellationToken)
        {
            return await Handle<UpdateSubjectRequest, UpdateSubjectInput, UpdateSubjectOutput, UpdateSubjectResponse, string>(
                request,
                _validator,
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
