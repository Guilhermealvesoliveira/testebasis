using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Request;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Response;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.DeleteSaleTypeBookPrice;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;

namespace TesteBasisBook.Api.Controllers.SaleTypeBookPrices
{
    public class DeleteSaleTypeBookPriceController : BaseController
    {
        private readonly IDeleteSaleTypeBookPriceUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<DeleteSaleTypeBookPriceController> _logger;

        public DeleteSaleTypeBookPriceController(ILogger<DeleteSaleTypeBookPriceController> logger, IDeleteSaleTypeBookPriceUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpDelete]
        [Tags("SaleTypeBookPrice")]
        [Route("/api/delete-SaleTypeBookPrice")]
        public async Task<ActionResult<DeleteSaleTypeBookPriceResponse>> Execute([FromQuery] int bookId, [FromQuery] int saleTypeId, CancellationToken cancellationToken)
        {
            return await Handle<DeleteSaleTypeBookPriceInput, DeleteSaleTypeBookPriceOutput, DeleteSaleTypeBookPriceResponse, string>(
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
