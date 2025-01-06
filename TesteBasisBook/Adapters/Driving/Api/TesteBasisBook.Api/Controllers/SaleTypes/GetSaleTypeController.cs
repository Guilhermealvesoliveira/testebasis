using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.SaleTypes.Response;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.GetSaleType;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;

namespace TesteBasisBook.Api.Controllers.SaleType
{
    public class GetSaleTypeController : BaseController
    {
        private readonly IGetSaleTypeUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<GetSaleTypeController> _logger;

        public GetSaleTypeController(ILogger<GetSaleTypeController> logger, IGetSaleTypeUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("SaleType")]
        [Route("/api/get-SaleType")]
        public async Task<ActionResult<GetSaleTypeResponse>> Execute([FromQuery] int SaleTypeId, CancellationToken cancellationToken)
        {
            return await Handle< GetSaleTypeInput, GetSaleTypeOutput, GetSaleTypeResponse, GetSaleTypeResponseData>(
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
