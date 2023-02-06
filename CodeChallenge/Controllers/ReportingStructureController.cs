using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/reporting")]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger<ReportingStructureController> _logger;
        private readonly IReportingService _reportService;

        public ReportingStructureController(ILogger<ReportingStructureController> Logger, IReportingService reportService)
        {
            _logger = Logger;
            _reportService = reportService;
        }
        [HttpGet("{id}", Name = "GetEmployeeDirectReport")]
        public IActionResult GetEmployeeDirectReport(String id)
        {
            _logger.LogDebug($"Received employee Direct Report get request for '{id}'");

            var employReport = _reportService.GetById(id);


            if (employReport == null)
                return NotFound();

            return Ok(employReport);
        }
    }
}
