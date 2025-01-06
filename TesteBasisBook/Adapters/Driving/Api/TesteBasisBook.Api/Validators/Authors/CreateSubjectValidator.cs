using FluentValidation;
using TesteBasisBook.Api.Dtos.Subjects.Request;

namespace TesteBasisBook.Api.Validators.Subjects
{
    public class CreateSubjectValidator : AbstractValidator<CreateSubjectRequest>
    {
        public CreateSubjectValidator()
        {
            RuleFor(x => x.Description).NotEmpty().Length(0, 20).WithMessage("Descri��o deve ter no m�ximo 20 caracteres.");
        }
    }
}
