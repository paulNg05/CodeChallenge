using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly ILogger<CompensationRepository> _logger;
        private readonly EmployeeContext _employeeContext;

        public CompensationRepository(ILogger<CompensationRepository> logger, EmployeeContext employeeContext)
        {
            _logger = logger;
            _employeeContext = employeeContext;
        }

        public Compensation Add(Compensation compensation)
        {
            _employeeContext.Compensations.Add(compensation);
            return compensation;
        }

        public Compensation GetById(string id)
        {
                        
            return _employeeContext.Compensations.SingleOrDefault(e => e.employeeId == id);

        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }

        public Compensation Remove(Compensation compensation)
        {
            return _employeeContext.Remove(compensation).Entity;
        }
    }
}
