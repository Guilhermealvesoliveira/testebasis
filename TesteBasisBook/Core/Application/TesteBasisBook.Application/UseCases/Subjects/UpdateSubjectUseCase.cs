using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.UpdateSubject;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.Services.Subjects
{
    public class UpdateSubjectUseCase : IUpdateSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILogger<UpdateSubjectUseCase> _logger;

        public UpdateSubjectUseCase(ISubjectRepository subjectRepository, ILogger<UpdateSubjectUseCase> logger)
        {
            _logger = logger;
            _subjectRepository = subjectRepository;
        }

        public async Task<UpdateSubjectOutput> ExecuteAsync(UpdateSubjectInput input, CancellationToken cancellationToken)
        {
            try
            {
                var subject = await _subjectRepository.GetAsync(input.SubjectId, cancellationToken);
                if(subject == default)
                {
                    return new UpdateSubjectOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "Subject not found",

                    };
                }

                subject.Description = input.Description;

                await _subjectRepository.UpdateAsync(subject, cancellationToken);

                return new UpdateSubjectOutput
                {
                    IsSuccess = true,
                    Message = "Subject updated successfully"

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new UpdateSubjectOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
