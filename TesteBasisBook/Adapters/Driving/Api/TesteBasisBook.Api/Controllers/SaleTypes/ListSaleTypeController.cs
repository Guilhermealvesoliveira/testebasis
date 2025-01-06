using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.SaleTypes.Response;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.ListSaleType;

namespace TesteBasisBook.Api.Controllers.SaleTypes
{
    public class ListSaleTypeController : BaseController
    {
        private readonly IListSaleTypeUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<ListSaleTypeController> _logger;

        public ListSaleTypeController(ILogger<ListSaleTypeController> logger, IListSaleTypeUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("SaleType")]
        [Route("/api/list-SaleTypes")]
        public async Task<ActionResult<ListSaleTypeResponse>> Execute(CancellationToken cancellationToken)
        {
            return await Handle<ListSaleTypeInput, ListSaleTypeOutput, ListSaleTypeResponse, List<ListSaleTypeResponseData>>(
                
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
