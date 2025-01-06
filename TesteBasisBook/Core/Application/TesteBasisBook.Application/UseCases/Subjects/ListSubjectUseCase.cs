using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.ListSubject;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.Services.Subjects
{
    public class ListSubjectUseCase : IListSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILogger<ListSubjectUseCase> _logger;

        public ListSubjectUseCase(ISubjectRepository subjectRepository, ILogger<ListSubjectUseCase> logger)
        {
            _logger = logger;
            _subjectRepository = subjectRepository;
        }

        public async Task<ListSubjectOutput> ExecuteAsync(ListSubjectInput input, CancellationToken cancellationToken)
        {
            try
            {
                var subjects = await _subjectRepository.GetAllAsync(cancellationToken);
                if (!subjects.Any())
                {
                    return new ListSubjectOutput
                    {
                        IsSuccess = false,
                        Message = "No subject has been registered"
                    };
                }
                var ListSubjects = new List<ListSubjectOutputData>();

                foreach (var subject in subjects) {
                    ListSubjects.Add(
                        new ListSubjectOutputData {
                        SubjectId = subject.SubjectId,
                        Description = subject.Description
                        });
                }

                return new ListSubjectOutput
                {
                    IsSuccess = true,
                    Data = ListSubjects,
                    Message = "Get list successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ListSubjectOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
