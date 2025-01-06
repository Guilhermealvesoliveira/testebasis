using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.ListSaleType;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.Services.SaleType
{
    public class ListSaleTypeUseCase : IListSaleTypeUseCase
    {
        private readonly ISaleTypeRepository _SaleTypeRepository;
        private readonly ILogger<ListSaleTypeUseCase> _logger;

        public ListSaleTypeUseCase(ISaleTypeRepository SaleTypeRepository, ILogger<ListSaleTypeUseCase> logger)
        {
            _logger = logger;
            _SaleTypeRepository = SaleTypeRepository;
        }

        public async Task<ListSaleTypeOutput> ExecuteAsync(ListSaleTypeInput input, CancellationToken cancellationToken)
        {
            try
            {
                var saleTypes = await _SaleTypeRepository.GetAllAsync(cancellationToken);
                if (!saleTypes.Any())
                {
                    return new ListSaleTypeOutput
                    {
                        IsSuccess = false,
                        Message = "No SaleType has been registered"
                    };
                }
                var ListSaleType = new List<ListSaleTypeOutputData>();

                foreach (var SaleType in saleTypes) {
                    ListSaleType.Add(
                        new ListSaleTypeOutputData {
                        SaleTypeId = SaleType.SaleTypeId,
                        Description = SaleType.Description
                        });
                }

                return new ListSaleTypeOutput
                {
                    IsSuccess = true,
                    Data = ListSaleType,
                    Message = "Get list successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ListSaleTypeOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
