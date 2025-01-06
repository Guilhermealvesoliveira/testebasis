using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.CreateSaleType;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Application.Services.SaleTypes
{
    public class CreateSaleTypeUseCase : ICreateSaleTypeUseCase
    {
        private readonly ISaleTypeRepository _SaleTypeRepository;
        private readonly ILogger<CreateSaleTypeUseCase> _logger;

        public CreateSaleTypeUseCase(ISaleTypeRepository SaleTypeRepository, ILogger<CreateSaleTypeUseCase> logger)
        {
            _logger = logger;
            _SaleTypeRepository = SaleTypeRepository;
        }

        public async Task<CreateSaleTypeOutput> ExecuteAsync(CreateSaleTypeInput input, CancellationToken cancellationToken)
        {
            try
            {
                var saleType = await _SaleTypeRepository.GetSaleTypeByDescriptionAsync(input.Description, cancellationToken);

                if (saleType != default)
                {
                    return new CreateSaleTypeOutput
                    {
                        IsSuccess = false,
                        Message = "SaleType already",
                        BusinessRuleViolation= true,
                    };
                }

                var newSubjecct = new Domain.Entity.SaleType
                {
                    Description = input.Description,
                };
                await _SaleTypeRepository.InsertAsync(newSubjecct, cancellationToken);

                return new CreateSaleTypeOutput
                {
                    IsSuccess = true,
                    Message = "SaleType saved successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new CreateSaleTypeOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve SaleType."
                };
            }
        }
    }
}
