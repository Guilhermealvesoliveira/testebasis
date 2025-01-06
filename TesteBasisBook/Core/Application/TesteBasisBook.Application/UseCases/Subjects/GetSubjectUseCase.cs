using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.GetSubject;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.Services.Subjects
{
    public class GetSubjectUseCase : IGetSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILogger<GetSubjectUseCase> _logger;

        public GetSubjectUseCase(ISubjectRepository subjectRepository, ILogger<GetSubjectUseCase> logger)
        {
            _logger = logger;
            _subjectRepository = subjectRepository;
        }

        public async Task<GetSubjectOutput> ExecuteAsync(GetSubjectInput input, CancellationToken cancellationToken)
        {
            try
            {
                var subject = await _subjectRepository.GetAsync(input.SubjectId, cancellationToken);
                if (subject == default)
                {
                    return new GetSubjectOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "Subject not found",

                    };
                }

                return new GetSubjectOutput
                {
                    IsSuccess = true,
                    Message = "Subject Get successfully",        
                    Data = new GetSubjectOutputData
                    {
                        Description = subject.Description,
                        SubjectId = subject.SubjectId,
                    }

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetSubjectOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
