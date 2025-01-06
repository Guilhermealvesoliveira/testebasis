using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.DeleteSaleType;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.Services.SaleType
{
    public class DeleteSaleTypeUseCase : IDeleteSaleTypeUseCase
    {
        private readonly ISaleTypeRepository _SaleTypeRepository;
        private readonly ILogger<DeleteSaleTypeUseCase> _logger;

        public DeleteSaleTypeUseCase(ISaleTypeRepository SaleTypeRepository, ILogger<DeleteSaleTypeUseCase> logger)
        {
            _logger = logger;
            _SaleTypeRepository = SaleTypeRepository;
        }

        public async Task<DeleteSaleTypeOutput> ExecuteAsync(DeleteSaleTypeInput input, CancellationToken cancellationToken)
        {
            try
            {
                var SaleType = await _SaleTypeRepository.GetAsync(input.SaleTypeId, cancellationToken);
                if (SaleType == default)
                {
                    return new DeleteSaleTypeOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "SaleType not found",

                    };
                }

                await _SaleTypeRepository.DeleteAsync(SaleType.SaleTypeId, cancellationToken);

                return new DeleteSaleTypeOutput
                {
                    IsSuccess = true,
                    Message = "SaleType deleted successfully"

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new DeleteSaleTypeOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
