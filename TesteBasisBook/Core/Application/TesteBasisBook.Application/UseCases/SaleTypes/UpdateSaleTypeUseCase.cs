using Microsoft.Extensions.Logging;

using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.UpdateSaleType;

namespace TesteBasisBook.Application.Services.SaleType
{
    public class UpdateSaleTypeUseCase : IUpdateSaleTypeUseCase
    {
        private readonly ISaleTypeRepository _SaleTypeRepository;
        private readonly ILogger<UpdateSaleTypeUseCase> _logger;

        public UpdateSaleTypeUseCase(ISaleTypeRepository SaleTypeRepository, ILogger<UpdateSaleTypeUseCase> logger)
        {
            _logger = logger;
            _SaleTypeRepository = SaleTypeRepository;
        }

        public async Task<UpdateSaleTypeOutput> ExecuteAsync(UpdateSaleTypeInput input, CancellationToken cancellationToken)
        {
            try
            {
                var SaleType = await _SaleTypeRepository.GetAsync(input.SaleTypeId, cancellationToken);
                if(SaleType == default)
                {
                    return new UpdateSaleTypeOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "SaleType not found",

                    };
                }

                SaleType.Description = input.Description;

                await _SaleTypeRepository.UpdateAsync(SaleType, cancellationToken);

                return new UpdateSaleTypeOutput
                {
                    IsSuccess = true,
                    Message = "SaleType updated successfully"

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new UpdateSaleTypeOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
