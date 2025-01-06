using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.GetSaleTypeBookPrice;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.Services.SaleTypeBookPrices
{
    public class GetSaleTypeBookPriceUseCase : IGetSaleTypeBookPriceUseCase
    {
        private readonly ISaleTypeBookPriceRepository _SaleTypeBookPriceRepository;
        private readonly ILogger<GetSaleTypeBookPriceUseCase> _logger;

        public GetSaleTypeBookPriceUseCase(ISaleTypeBookPriceRepository SaleTypeBookPriceRepository, ILogger<GetSaleTypeBookPriceUseCase> logger)
        {
            _logger = logger;
            _SaleTypeBookPriceRepository = SaleTypeBookPriceRepository;
        }

        public async Task<GetSaleTypeBookPriceOutput> ExecuteAsync(GetSaleTypeBookPriceInput input, CancellationToken cancellationToken)
        {
            try
            {
                var SaleTypeBookPrice = await _SaleTypeBookPriceRepository.GetSaleTypeBookPriceByBookAndType(input.BookId, input.SaleTypeId, cancellationToken);
                if (SaleTypeBookPrice == default)
                {
                    return new GetSaleTypeBookPriceOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "SaleTypeBookPrice not found",

                    };
                }

                return new GetSaleTypeBookPriceOutput
                {
                    IsSuccess = true,
                    Message = "SaleTypeBookPrice Get successfully",        
                    Data = new GetSaleTypeBookPriceOutputData
                    {
                        BookId = SaleTypeBookPrice.BookId,
                        SaleTypeId = SaleTypeBookPrice.SaleTypeId,
                        Price = SaleTypeBookPrice.Price,
                    }

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetSaleTypeBookPriceOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
