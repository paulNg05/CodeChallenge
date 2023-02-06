using CodeChallenge.Models;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation Add(Compensation compensation);
        Compensation GetById(string id);
        Compensation Remove(Compensation compensation);
        Task SaveAsync();
    }
}