using FluentValidation;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Request;

namespace TesteBasisBook.Api.Validators.SaleTypeBookPrice
{
    public class CreateSaleTypeBookPriceValidator : AbstractValidator<CreateSaleTypeBookPriceRequest>
    {
        public CreateSaleTypeBookPriceValidator()
        {
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.SaleTypeId).NotEmpty();
            RuleFor(x => x.BookId).NotEmpty();
        }
    }
}
