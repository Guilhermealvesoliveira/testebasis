using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Subjects.UpdateSubject
{
    public interface IUpdateSubjectUseCase
    {
        Task<UpdateSubjectOutput> ExecuteAsync(UpdateSubjectInput input, CancellationToken cancellationToken);
    }
}
