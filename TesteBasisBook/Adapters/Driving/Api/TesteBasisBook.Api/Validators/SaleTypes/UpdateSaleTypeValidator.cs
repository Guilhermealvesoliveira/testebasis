using FluentValidation;
using TesteBasisBook.Api.Dtos.SaleTypes.Request;

namespace TesteBasisBook.Api.Validators.SaleTypes
{
    public class UpdateSaleTypeValidator : AbstractValidator<UpdateSaleTypeRequest>
    {
        public UpdateSaleTypeValidator()
        {
            RuleFor(x => x.SaleTypeId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
