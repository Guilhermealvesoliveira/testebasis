using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Subjects.DeleteSubject
{
    public interface IDeleteSubjectUseCase
    {
        Task<DeleteSubjectOutput> ExecuteAsync(DeleteSubjectInput input, CancellationToken cancellationToken);
    }
}
