using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ILogger<Compensation> _logger;
        private readonly ICompensationRepository _compensation;

        public CompensationService(ILogger<Compensation> logger, ICompensationRepository compensation)
        {
            _logger = logger;
            _compensation = compensation;

        }

        public Compensation GetById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _compensation.GetById(id);

            }

            return null;
        }

        public Compensation Create(Compensation employeeComp)
        {
            if (employeeComp != null)
            {
                _compensation.Add(employeeComp);
                _compensation.SaveAsync().Wait();
            }

            return employeeComp;
        }



    }
}
