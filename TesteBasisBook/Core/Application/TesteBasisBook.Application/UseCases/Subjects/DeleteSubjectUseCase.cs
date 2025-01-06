using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.DeleteSubject;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.Services.Subjects
{
    public class DeleteSubjectUseCase : IDeleteSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILogger<DeleteSubjectUseCase> _logger;

        public DeleteSubjectUseCase(ISubjectRepository subjectRepository, ILogger<DeleteSubjectUseCase> logger)
        {
            _logger = logger;
            _subjectRepository = subjectRepository;
        }

        public async Task<DeleteSubjectOutput> ExecuteAsync(DeleteSubjectInput input, CancellationToken cancellationToken)
        {
            try
            {
                var subject = await _subjectRepository.GetAsync(input.SubjectId, cancellationToken);
                if (subject == default)
                {
                    return new DeleteSubjectOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "Subject not found",

                    };
                }

                await _subjectRepository.DeleteAsync(subject.SubjectId, cancellationToken);

                return new DeleteSubjectOutput
                {
                    IsSuccess = true,
                    Message = "Subject deleted successfully"

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new DeleteSubjectOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
