using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger<CompensationController> _logger;
        private readonly ICompensationService _compensationSrv;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationSrv)
        {
            _logger = logger;
            _compensationSrv = compensationSrv;
        }
        [HttpPost]
        public IActionResult CreateEmpCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received employee compensation create request for '{compensation.employeeId }'");

            _compensationSrv.Create(compensation);

            return CreatedAtRoute("GetEmpCompensationById", new { id = compensation.employeeId }, compensation);
        }

        [HttpGet("{id}", Name = "GetEmpCompensationById")]
        public IActionResult GetEmpCompensationById(String id)
        {
            _logger.LogDebug($"Received employee compensation get request for '{id}'");

            var empCompensation = _compensationSrv.GetById(id);

            if (empCompensation == null)
                return NotFound();

            return Ok(empCompensation);
        }

    }
}
