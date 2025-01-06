using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Subjects.CreateSubject
{
    public interface ICreateSubjectUseCase
    {
        Task<CreateSubjectOutput> ExecuteAsync(CreateSubjectInput input, CancellationToken cancellationToken);
    }
}
