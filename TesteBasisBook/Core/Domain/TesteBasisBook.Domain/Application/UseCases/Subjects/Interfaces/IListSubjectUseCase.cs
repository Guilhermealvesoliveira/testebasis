using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Subjects.ListSubject
{
    public interface IListSubjectUseCase
    {
        Task<ListSubjectOutput> ExecuteAsync(ListSubjectInput input, CancellationToken cancellationToken);
    }
}
