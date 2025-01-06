using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.Subjects.Request;
using TesteBasisBook.Api.Dtos.Subjects.Response;
using TesteBasisBook.Domain.Application.UseCases.Subjects.CreateSubject;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Api.Controllers.Subjects
{
    public class CreateSubjectController : BaseController
    {
        private readonly ICreateSubjectUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly IValidator<CreateSubjectRequest> _validator;
        private readonly ILogger<CreateSubjectController> _logger;

        public CreateSubjectController(ILogger<CreateSubjectController> logger, ICreateSubjectUseCase useCase, IMapperService mapperService, IValidator<CreateSubjectRequest> validator) : base(mapperService)
        {
            _useCase = useCase;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost]
        [Tags("Subject")]
        [Route("/api/create-subject")]
        public async Task<ActionResult<CreateSubjectResponse>> Execute([FromBody] CreateSubjectRequest request, CancellationToken cancellationToken)
        {
            return await Handle<CreateSubjectRequest, CreateSubjectInput, CreateSubjectOutput, CreateSubjectResponse, string>(
                request,
                _validator,
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
