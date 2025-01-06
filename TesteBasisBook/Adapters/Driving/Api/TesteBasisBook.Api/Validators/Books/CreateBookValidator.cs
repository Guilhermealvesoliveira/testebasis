using FluentValidation;
using TesteBasisBook.Api.Dtos.Books.Request;

namespace TesteBasisBook.Api.Validators.Book
{
    public class CreateBookValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(0, 40).WithMessage("Nome deve ter no máximo 40 caracteres.");
            RuleFor(x => x.Publisher).NotEmpty().Length(0, 40).WithMessage("Nome deve ter no máximo 40 caracteres.");
            RuleFor(x => x.PublicationYear).NotEmpty().Length(0, 4).WithMessage("Nome deve ter no máximo 4 caracteres.");

        }
    }
}
