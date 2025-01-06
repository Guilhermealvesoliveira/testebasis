using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TesteBasisBook.Api.Dtos.Authors.Request;
using TesteBasisBook.Api.Dtos.Authors.Response;
using TesteBasisBook.Domain.Application.UseCases.Authors;
using TesteBasisBook.Domain.Adapters.Driving.Api.Mappings;
using TesteBasisBook.Api.Handlers;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Reports;

namespace TesteBasisBook.Api.Controllers.Authors
{
    public class GenerateReportController : BaseController
    {
        private readonly IGenerateReportUseCase _useCase;
        private readonly IMapperService _mapperService;
        private readonly ILogger<GenerateReportController> _logger;

        public GenerateReportController(ILogger<GenerateReportController> logger, IGenerateReportUseCase useCase, IMapperService mapperService) : base(mapperService)
        {
            _useCase = useCase;
            _logger = logger;
        }

        [HttpGet]
        [Tags("Reports")]
        [Route("/api/generate-reporte")]
        public IActionResult Execute(CancellationToken cancellationToken)
        {
            var renderedBytes = _useCase.GenerateReport();
            return File(renderedBytes, "application/pdf", "relatorio1.pdf");
        }
    }
}
