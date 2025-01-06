using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Reports.Services;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Application.UseCases.Reports;
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Application.Services.Subjects
{
    public class GenerateReportUseCase : IGenerateReportUseCase
    {
        private readonly IReportGenerateService _reportGenerateService;
        private readonly ILogger<GenerateReportUseCase> _logger;

        public GenerateReportUseCase(IReportGenerateService reportGenerateService, ILogger<GenerateReportUseCase> logger)
        {
            _logger = logger;
            _reportGenerateService = reportGenerateService;
        }


        public byte[] GenerateReport()
        {
            return _reportGenerateService.Execute();
        }
    }
}
