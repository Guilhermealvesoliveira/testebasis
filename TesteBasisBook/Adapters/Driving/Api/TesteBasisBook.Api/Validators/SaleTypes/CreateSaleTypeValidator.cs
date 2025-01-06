using FluentValidation;
using TesteBasisBook.Api.Dtos.SaleTypes.Request;

namespace TesteBasisBook.Api.Validators.SaleType
{
    public class CreateSaleTypeValidator : AbstractValidator<CreateSaleTypeRequest>
    {
        public CreateSaleTypeValidator()
        {
            RuleFor(x => x.Description).NotEmpty().Length(0, 40).WithMessage("Descrição deve ter no máximo 40 caracteres.");
        }
    }
}
