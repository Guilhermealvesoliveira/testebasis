using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.UpdateSaleTypeBookPrice;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using System.Diagnostics;
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Application.Services.SaleTypeBookPrices
{
    public class UpdateSaleTypeBookPriceUseCase : IUpdateSaleTypeBookPriceUseCase
    {
        private readonly ISaleTypeBookPriceRepository _SaleTypeBookPriceRepository;
        private readonly ILogger<UpdateSaleTypeBookPriceUseCase> _logger;

        public UpdateSaleTypeBookPriceUseCase(ISaleTypeBookPriceRepository SaleTypeBookPriceRepository, ILogger<UpdateSaleTypeBookPriceUseCase> logger)
        {
            _logger = logger;
            _SaleTypeBookPriceRepository = SaleTypeBookPriceRepository;
        }

        public async Task<UpdateSaleTypeBookPriceOutput> ExecuteAsync(UpdateSaleTypeBookPriceInput input, CancellationToken cancellationToken)
        {
            try
            {
                var SaleTypeBookPrice = await _SaleTypeBookPriceRepository.GetSaleTypeBookPriceByBookAndType(input.BookId, input.SaleTypeId, cancellationToken);
                if(SaleTypeBookPrice == default)
                {
                    return new UpdateSaleTypeBookPriceOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "SaleTypeBookPrice not found",

                    };
                }

                SaleTypeBookPrice.Price = input.Price;

                await _SaleTypeBookPriceRepository.UpdateAsync(SaleTypeBookPrice, cancellationToken);

                return new UpdateSaleTypeBookPriceOutput
                {
                    IsSuccess = true,
                    Message = "SaleTypeBookPrice updated successfully"

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new UpdateSaleTypeBookPriceOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
