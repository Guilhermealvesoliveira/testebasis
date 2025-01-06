using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.Books.Response;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Books;

namespace TesteBasisBook.Api.Controllers.Books
{
    public class ListBookController : BaseController
    {
        private readonly IListBookUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<ListBookController> _logger;

        public ListBookController(ILogger<ListBookController> logger, IListBookUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("Book")]
        [Route("/api/list-Books")]
        public async Task<ActionResult<ListBookResponse>> Execute(CancellationToken cancellationToken)
        {
            return await Handle<ListBookInput, ListBookOutput, ListBookResponse, List<ListBookResponseData>>(
                
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
