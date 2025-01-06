using FluentValidation;
using Microsoft.AspNetCore.Mvc;

using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.UpdateSaleTypeBookPrice;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Request;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Response;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;


namespace TesteBasisBook.Api.Controllers.SaleTypeBookPrice
{
    public class UpdateSaleTypeBookPriceController : BaseController
    {
        private readonly IUpdateSaleTypeBookPriceUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly IValidator<UpdateSaleTypeBookPriceRequest> _validator;
        private readonly ILogger<UpdateSaleTypeBookPriceController> _logger;

        public UpdateSaleTypeBookPriceController(ILogger<UpdateSaleTypeBookPriceController> logger, IUpdateSaleTypeBookPriceUseCase useCase, IMapperService mapperService, IValidator<UpdateSaleTypeBookPriceRequest> validator) : base(mapperService)
        {
            _useCase = useCase;
            _validator = validator;
            _logger = logger;
        }

        [HttpPut]
        [Tags("SaleTypeBookPrice")]
        [Route("/api/update-SaleTypeBookPrice")]
        public async Task<ActionResult<UpdateSaleTypeBookPriceResponse>> Execute([FromBody] UpdateSaleTypeBookPriceRequest request, CancellationToken cancellationToken)
        {
            return await Handle<UpdateSaleTypeBookPriceRequest, UpdateSaleTypeBookPriceInput, UpdateSaleTypeBookPriceOutput, UpdateSaleTypeBookPriceResponse, string>(
                request,
                _validator,
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
