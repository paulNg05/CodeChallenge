using CodeChallenge.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace CodeChallenge.Data
{
    public class EmpCompensationDataSeeder
    {
 
        private const String EMPCOMPENSATION_SEED_DATA_FILE = "resources/EmpCompensationSeedData.json";
        private readonly EmployeeContext _employeeContext;

        public EmpCompensationDataSeeder(EmployeeContext employeeContext)
        {
           
            _employeeContext = employeeContext;
        }

        public async Task Seed()
        {
            if (!_employeeContext.Compensations.Any())
            {
                List<Compensation> compensations = LoadEmpCompensation();
                _employeeContext.Compensations.AddRange(compensations);

                await _employeeContext.SaveChangesAsync();
            }
        }

        private List<Compensation> LoadEmpCompensation()
        {
            using (FileStream fs = new FileStream(EMPCOMPENSATION_SEED_DATA_FILE, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            using (JsonReader jr = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();

                List<Compensation> Compensations = serializer.Deserialize<List<Compensation>>(jr);             

                return Compensations;
            }
        }

       
    }
}
