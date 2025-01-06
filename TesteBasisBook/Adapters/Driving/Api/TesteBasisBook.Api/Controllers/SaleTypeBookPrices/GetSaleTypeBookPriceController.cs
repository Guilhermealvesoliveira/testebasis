using Microsoft.AspNetCore.Mvc;

using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.GetSaleTypeBookPrice;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Response;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;


namespace TesteBasisBook.Api.Controllers.SaleTypeBookPrice
{
    public class GetSaleTypeBookPriceController : BaseController
    {
        private readonly IGetSaleTypeBookPriceUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<GetSaleTypeBookPriceController> _logger;

        public GetSaleTypeBookPriceController(ILogger<GetSaleTypeBookPriceController> logger, IGetSaleTypeBookPriceUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("SaleTypeBookPrice")]
        [Route("/api/get-SaleTypeBookPrice")]
        public async Task<ActionResult<GetSaleTypeBookPriceResponse>> Execute([FromQuery] int bookId, [FromQuery] int saleTypeId, CancellationToken cancellationToken)
        {
            return await Handle< GetSaleTypeBookPriceInput, GetSaleTypeBookPriceOutput, GetSaleTypeBookPriceResponse, GetSaleTypeBookPriceResponseData>(
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
