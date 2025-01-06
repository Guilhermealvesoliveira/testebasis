using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.SaleTypes.Request;
using TesteBasisBook.Api.Dtos.SaleTypes.Response;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.DeleteSaleType;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;

namespace TesteBasisBook.Api.Controllers.SaleTypes
{
    public class DeleteSaleTypeController : BaseController
    {
        private readonly IDeleteSaleTypeUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<DeleteSaleTypeController> _logger;

        public DeleteSaleTypeController(ILogger<DeleteSaleTypeController> logger, IDeleteSaleTypeUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpDelete]
        [Tags("SaleType")]
        [Route("/api/delete-SaleType")]
        public async Task<ActionResult<DeleteSaleTypeResponse>> Execute([FromQuery] int SaleTypeId, CancellationToken cancellationToken)
        {
            return await Handle<DeleteSaleTypeInput, DeleteSaleTypeOutput, DeleteSaleTypeResponse, string>(
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
