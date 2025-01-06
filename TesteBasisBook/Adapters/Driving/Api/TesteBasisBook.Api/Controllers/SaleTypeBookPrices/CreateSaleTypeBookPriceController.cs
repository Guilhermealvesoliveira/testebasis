using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Request;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Response;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.CreateSaleTypeBookPrice;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;

namespace TesteBasisBook.Api.Controllers.SaleTypeBookPrices
{
    public class CreateSaleTypeBookPriceController : BaseController
    {
        private readonly ICreateSaleTypeBookPriceUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly IValidator<CreateSaleTypeBookPriceRequest> _validator;
        private readonly ILogger<CreateSaleTypeBookPriceController> _logger;

        public CreateSaleTypeBookPriceController(ILogger<CreateSaleTypeBookPriceController> logger, ICreateSaleTypeBookPriceUseCase useCase, IMapperService mapperService, IValidator<CreateSaleTypeBookPriceRequest> validator) : base(mapperService)
        {
            _useCase = useCase;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost]
        [Tags("SaleTypeBookPrice")]
        [Route("/api/create-SaleTypeBookPrice")]
        public async Task<ActionResult<CreateSaleTypeBookPriceResponse>> Execute([FromBody] CreateSaleTypeBookPriceRequest request, CancellationToken cancellationToken)
        {
            return await Handle<CreateSaleTypeBookPriceRequest, CreateSaleTypeBookPriceInput, CreateSaleTypeBookPriceOutput, CreateSaleTypeBookPriceResponse, string>(
                request,
                _validator,
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
