using CodeChallenge.Models;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
    public class ReportingService : IReportingService
    {
        private readonly ILogger<ReportingService> _logger;
        private readonly IEmployeeService _employeeService;

        public ReportingService(ILogger<ReportingService> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        // Get the employee info by calling the employee endpoint and compute the numberOfReport
        public ReportingStructure GetById(string employeeId)
        {

            ReportingStructure emplDirectReports = new ReportingStructure();
            int numberOfDirectReport = 0;
            emplDirectReports.Employee = _employeeService.GetById(employeeId);
            if (emplDirectReports.Employee.DirectReports.Count > 0)
            {

                foreach (var empl in emplDirectReports.Employee.DirectReports)
                {
                    numberOfDirectReport++;
                    GetNumberOfRemport(empl.EmployeeId, ref numberOfDirectReport);
                }
            }

            emplDirectReports.NumberOfReports = numberOfDirectReport;

            return emplDirectReports;

        }

        private void GetNumberOfRemport(string employeeId, ref int numOfReport)
        {
            var reportEmp = _employeeService.GetById(employeeId);
            if (reportEmp.DirectReports.Count >0)
            {
                foreach (var emp in reportEmp.DirectReports)
                {
                    numOfReport++;
                    GetNumberOfRemport(emp.EmployeeId, ref numOfReport);

                }
            }
        }
    }
}
