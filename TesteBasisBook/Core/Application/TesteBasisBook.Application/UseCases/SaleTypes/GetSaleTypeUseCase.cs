using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.GetSaleType;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.Services.SaleType
{
    public class GetSaleTypeUseCase : IGetSaleTypeUseCase
    {
        private readonly ISaleTypeRepository _SaleTypeRepository;
        private readonly ILogger<GetSaleTypeUseCase> _logger;

        public GetSaleTypeUseCase(ISaleTypeRepository SaleTypeRepository, ILogger<GetSaleTypeUseCase> logger)
        {
            _logger = logger;
            _SaleTypeRepository = SaleTypeRepository;
        }

        public async Task<GetSaleTypeOutput> ExecuteAsync(GetSaleTypeInput input, CancellationToken cancellationToken)
        {
            try
            {
                var SaleType = await _SaleTypeRepository.GetAsync(input.SaleTypeId, cancellationToken);
                if (SaleType == default)
                {
                    return new GetSaleTypeOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "SaleType not found",

                    };
                }

                return new GetSaleTypeOutput
                {
                    IsSuccess = true,
                    Message = "SaleType Get successfully",        
                    Data = new GetSaleTypeOutputData
                    {
                        Description = SaleType.Description,
                        SaleTypeId = SaleType.SaleTypeId,
                    }

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetSaleTypeOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
