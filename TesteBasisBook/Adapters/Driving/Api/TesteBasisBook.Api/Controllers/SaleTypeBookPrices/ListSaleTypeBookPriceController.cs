using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.ListSaleTypeBookPrice;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Response;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;


namespace TesteBasisBook.Api.Controllers.SaleTypeBookPrice
{
    public class ListSaleTypeBookPriceController : BaseController
    {
        private readonly IListSaleTypeBookPriceUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<ListSaleTypeBookPriceController> _logger;

        public ListSaleTypeBookPriceController(ILogger<ListSaleTypeBookPriceController> logger, IListSaleTypeBookPriceUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("SaleTypeBookPrice")]
        [Route("/api/list-SaleTypeBookPrice")]
        public async Task<ActionResult<ListSaleTypeBookPriceResponse>> Execute([FromQuery] int bookId, CancellationToken cancellationToken)
        {
            return await Handle<ListSaleTypeBookPriceInput, ListSaleTypeBookPriceOutput, ListSaleTypeBookPriceResponse, List<ListSaleTypeBookPriceResponseData>>(
                
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
