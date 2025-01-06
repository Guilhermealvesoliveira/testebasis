using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.CreateSubject;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Application.Services.Subjects
{
    public class CreateSubjectUseCase : ICreateSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILogger<CreateSubjectUseCase> _logger;

        public CreateSubjectUseCase(ISubjectRepository subjectRepository, ILogger<CreateSubjectUseCase> logger)
        {
            _logger = logger;
            _subjectRepository = subjectRepository;
        }

        public async Task<CreateSubjectOutput> ExecuteAsync(CreateSubjectInput input, CancellationToken cancellationToken)
        {
            try
            {
                var subject = await _subjectRepository.GetSubjectByDescriptionAsync(input.Description, cancellationToken);

                if (subject != default)
                {
                    return new CreateSubjectOutput
                    {
                        IsSuccess = false,
                        Message = "Subject already",
                        BusinessRuleViolation= true,
                    };
                }

                var newSubjecct = new Subject
                {
                    Description = input.Description,
                };
                await _subjectRepository.InsertAsync(newSubjecct, cancellationToken);

                return new CreateSubjectOutput
                {
                    IsSuccess = true,
                    Message = "Subject saved successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new CreateSubjectOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve Subject."
                };
            }
        }
    }
}
