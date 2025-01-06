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
    public class DeleteAuthorController : BaseController
    {
        private readonly IDeleteAuthorUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<DeleteAuthorController> _logger;

        public DeleteAuthorController(ILogger<DeleteAuthorController> logger, IDeleteAuthorUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpDelete]
        [Tags("Author")]
        [Route("/api/delete-Author")]
        public async Task<ActionResult<DeleteAuthorResponse>> Execute([FromQuery] int AuthorId, CancellationToken cancellationToken)
        {
            return await Handle<DeleteAuthorInput, DeleteAuthorOutput, DeleteAuthorResponse, string>(
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
