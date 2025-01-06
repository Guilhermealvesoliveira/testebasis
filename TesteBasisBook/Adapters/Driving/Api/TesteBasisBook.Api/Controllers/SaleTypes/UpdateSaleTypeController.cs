using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.SaleTypes.Request;
using TesteBasisBook.Api.Dtos.SaleTypes.Response;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.UpdateSaleType;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;

namespace TesteBasisBook.Api.Controllers.SaleTypes
{
    public class UpdateSaleTypeController : BaseController
    {
        private readonly IUpdateSaleTypeUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly IValidator<UpdateSaleTypeRequest> _validator;
        private readonly ILogger<UpdateSaleTypeController> _logger;

        public UpdateSaleTypeController(ILogger<UpdateSaleTypeController> logger, IUpdateSaleTypeUseCase useCase, IMapperService mapperService, IValidator<UpdateSaleTypeRequest> validator) : base(mapperService)
        {
            _useCase = useCase;
            _validator = validator;
            _logger = logger;
        }

        [HttpPut]
        [Tags("SaleType")]
        [Route("/api/update-SaleType")]
        public async Task<ActionResult<UpdateSaleTypeResponse>> Execute([FromBody] UpdateSaleTypeRequest request, CancellationToken cancellationToken)
        {
            return await Handle<UpdateSaleTypeRequest, UpdateSaleTypeInput, UpdateSaleTypeOutput, UpdateSaleTypeResponse, string>(
                request,
                _validator,
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
