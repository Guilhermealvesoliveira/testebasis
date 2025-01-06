using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Subjects.GetSubject
{
    public interface IGetSubjectUseCase
    {
        Task<GetSubjectOutput> ExecuteAsync(GetSubjectInput input, CancellationToken cancellationToken);
    }
}
