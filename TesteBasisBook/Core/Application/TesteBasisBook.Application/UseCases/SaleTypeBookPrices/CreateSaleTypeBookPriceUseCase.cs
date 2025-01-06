using Microsoft.Extensions.Logging;

using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.CreateSaleTypeBookPrice;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;

namespace TesteBasisBook.Application.Services.SaleTypeBookPrice
{
    public class CreateSaleTypeBookPriceUseCase : ICreateSaleTypeBookPriceUseCase
    {
        private readonly ISaleTypeBookPriceRepository _SaleTypeBookPriceRepository;
        private readonly ILogger<CreateSaleTypeBookPriceUseCase> _logger;

        public CreateSaleTypeBookPriceUseCase(ISaleTypeBookPriceRepository SaleTypeBookPriceRepository, ILogger<CreateSaleTypeBookPriceUseCase> logger)
        {
            _logger = logger;
            _SaleTypeBookPriceRepository = SaleTypeBookPriceRepository;
        }

        public async Task<CreateSaleTypeBookPriceOutput> ExecuteAsync(CreateSaleTypeBookPriceInput input, CancellationToken cancellationToken)
        {
            try
            {
                var SaleTypeBookPrice = await _SaleTypeBookPriceRepository.GetSaleTypeBookPriceByBookAndType(input.BookId, input.SaleTypeId, cancellationToken);

                if (SaleTypeBookPrice != default)
                {
                    return new CreateSaleTypeBookPriceOutput
                    {
                        IsSuccess = false,
                        Message = "SaleTypeBookPrice already",
                        BusinessRuleViolation= true,
                    };
                }

                var newSubjecct = new Domain.Entity.SaleTypeBookPrice
                {
                    SaleTypeId = input.SaleTypeId,
                    BookId = input.BookId,
                    Price = input.Price,    
                };
                await _SaleTypeBookPriceRepository.InsertAsync(newSubjecct, cancellationToken);

                return new CreateSaleTypeBookPriceOutput
                {
                    IsSuccess = true,
                    Message = "SaleTypeBookPrice saved successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new CreateSaleTypeBookPriceOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve SaleTypeBookPrice."
                };
            }
        }
    }
}
