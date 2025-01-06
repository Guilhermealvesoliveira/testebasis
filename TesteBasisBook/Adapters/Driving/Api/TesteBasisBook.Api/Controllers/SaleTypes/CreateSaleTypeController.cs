using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.SaleTypes.Request;
using TesteBasisBook.Api.Dtos.SaleTypes.Response;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.CreateSaleType;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;

namespace TesteBasisBook.Api.Controllers.SaleTypes
{
    public class CreateSaleTypeController : BaseController
    {
        private readonly ICreateSaleTypeUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly IValidator<CreateSaleTypeRequest> _validator;
        private readonly ILogger<CreateSaleTypeController> _logger;

        public CreateSaleTypeController(ILogger<CreateSaleTypeController> logger, ICreateSaleTypeUseCase useCase, IMapperService mapperService, IValidator<CreateSaleTypeRequest> validator) : base(mapperService)
        {
            _useCase = useCase;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost]
        [Tags("SaleType")]
        [Route("/api/create-SaleType")]
        public async Task<ActionResult<CreateSaleTypeResponse>> Execute([FromBody] CreateSaleTypeRequest request, CancellationToken cancellationToken)
        {
            return await Handle<CreateSaleTypeRequest, CreateSaleTypeInput, CreateSaleTypeOutput, CreateSaleTypeResponse, string>(
                request,
                _validator,
                input => _useCase.ExecuteAsync(input, cancellationToken),
                cancellationToken);
        }
    }
}
