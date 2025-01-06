using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.DeleteSaleTypeBookPrice;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.Services.SaleTypeBookPrices
{
    public class DeleteSaleTypeBookPriceUseCase : IDeleteSaleTypeBookPriceUseCase
    {
        private readonly ISaleTypeBookPriceRepository _SaleTypeBookPriceRepository;
        private readonly ILogger<DeleteSaleTypeBookPriceUseCase> _logger;

        public DeleteSaleTypeBookPriceUseCase(ISaleTypeBookPriceRepository SaleTypeBookPriceRepository, ILogger<DeleteSaleTypeBookPriceUseCase> logger)
        {
            _logger = logger;
            _SaleTypeBookPriceRepository = SaleTypeBookPriceRepository;
        }

        public async Task<DeleteSaleTypeBookPriceOutput> ExecuteAsync(DeleteSaleTypeBookPriceInput input, CancellationToken cancellationToken)
        {
            try
            {
                var SaleTypeBookPrice = await _SaleTypeBookPriceRepository.GetSaleTypeBookPriceByBookAndType(input.BookId, input.SaleTypeId, cancellationToken);
                if (SaleTypeBookPrice == default)
                {
                    return new DeleteSaleTypeBookPriceOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "SaleTypeBookPrice not found",

                    };
                }

                await _SaleTypeBookPriceRepository.DeleteSaleTypeBookPriceByBookAndType(SaleTypeBookPrice.BookId, SaleTypeBookPrice.SaleTypeId, cancellationToken);

                return new DeleteSaleTypeBookPriceOutput
                {
                    IsSuccess = true,
                    Message = "SaleTypeBookPrice deleted successfully"

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new DeleteSaleTypeBookPriceOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
