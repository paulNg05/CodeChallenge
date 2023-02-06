using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Models
{
    public class Compensation
    {
       
        [Key]   
        public  string  employeeId  { get; set; }
        public decimal salary { get; set; }
        public string effectiveDate { get; set; }
    }
}
