using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.ListSaleTypeBookPrice;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.Services.SaleTypeBookPrices
{
    public class ListSaleTypeBookPriceUseCase : IListSaleTypeBookPriceUseCase
    {
        private readonly ISaleTypeBookPriceRepository _SaleTypeBookPriceRepository;
        private readonly ILogger<ListSaleTypeBookPriceUseCase> _logger;

        public ListSaleTypeBookPriceUseCase(ISaleTypeBookPriceRepository SaleTypeBookPriceRepository, ILogger<ListSaleTypeBookPriceUseCase> logger)
        {
            _logger = logger;
            _SaleTypeBookPriceRepository = SaleTypeBookPriceRepository;
        }

        public async Task<ListSaleTypeBookPriceOutput> ExecuteAsync(ListSaleTypeBookPriceInput input, CancellationToken cancellationToken)
        {
            try
            {
                var SaleTypeBookPrices = await _SaleTypeBookPriceRepository.GetSaleTypeBookPriceByBook(input.BookId, cancellationToken);
                if (!SaleTypeBookPrices.Any())
                {
                    return new ListSaleTypeBookPriceOutput
                    {
                        IsSuccess = false,
                        Message = "No SaleTypeBookPrice has been registered"
                    };
                }
                var ListSaleTypeBookPrices = new List<ListSaleTypeBookPriceOutputData>();

                foreach (var SaleTypeBookPrice in SaleTypeBookPrices) {
                    ListSaleTypeBookPrices.Add(
                        new ListSaleTypeBookPriceOutputData {
                            BookId = SaleTypeBookPrice.BookId,
                            SaleTypeId = SaleTypeBookPrice.SaleTypeId,
                            Price = SaleTypeBookPrice.Price,
                            BookTitle = SaleTypeBookPrice.BookTitle,
                            SaleType = SaleTypeBookPrice.SaleType,
                        });
                }

                return new ListSaleTypeBookPriceOutput
                {
                    IsSuccess = true,
                    Data = ListSaleTypeBookPrices,
                    Message = "Get list successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ListSaleTypeBookPriceOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
