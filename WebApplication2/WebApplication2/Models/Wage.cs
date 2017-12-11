using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Wage
    {
        public int id { get; set; }
        public int Employeeid { get; set; }
        public string EmployeeName { get; set; }
        public int SalaryStandards { get; set; }
        public int AttendanceDays { get; set; }
        public decimal Amount { get; set; }
    }

   
}