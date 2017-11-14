using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Report
    {
        public int id { get; set; }
        public decimal Revenue { get; set; }
        public decimal OperatingExpenses { get; set; }
        public decimal OperatingProfit { get; set; }
        public decimal Tax { get; set; }
        public decimal ProfitTax { get; set; }
    }

    
}