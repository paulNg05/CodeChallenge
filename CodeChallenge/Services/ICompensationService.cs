using CodeChallenge.Models;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        Compensation Create(Compensation employeeComp);
        Compensation GetById(string id);
    }
}