using FluentValidation;
using TesteBasisBook.Api.Dtos.Subjects.Request;

namespace TesteBasisBook.Api.Validators.Subjects
{
    public class UpdateSubjectValidator : AbstractValidator<UpdateSubjectRequest>
    {
        public UpdateSubjectValidator()
        {
            RuleFor(x => x.SubjectId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
