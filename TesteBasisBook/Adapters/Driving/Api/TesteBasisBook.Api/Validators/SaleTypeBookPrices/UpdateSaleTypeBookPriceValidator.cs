using FluentValidation;
using TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Request;

namespace TesteBasisBook.Api.Validators.SaleTypeBookPrices
{
    public class UpdateSaleTypeBookPriceValidator : AbstractValidator<UpdateSaleTypeBookPriceRequest>
    {
        public UpdateSaleTypeBookPriceValidator()
        {
            RuleFor(x => x.BookId).NotEmpty();
            RuleFor(x => x.SaleTypeId).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
