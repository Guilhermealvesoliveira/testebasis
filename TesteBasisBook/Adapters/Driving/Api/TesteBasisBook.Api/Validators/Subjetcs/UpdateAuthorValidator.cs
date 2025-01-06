using FluentValidation;
using TesteBasisBook.Api.Dtos.Authors.Request;

namespace TesteBasisBook.Api.Validators.Authors
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorRequest>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
