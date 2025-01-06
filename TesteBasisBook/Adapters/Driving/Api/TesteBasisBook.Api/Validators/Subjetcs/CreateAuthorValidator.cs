using FluentValidation;
using TesteBasisBook.Api.Dtos.Authors.Request;

namespace TesteBasisBook.Api.Validators.Author
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorRequest>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(0, 40).WithMessage("Nome deve ter no máximo 40 caracteres.");
        }
    }
}
