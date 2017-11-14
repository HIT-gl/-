using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Profit
    {
        public int id { get; set; }
        public decimal SalesRevenue { get; set; }
        public decimal SalesCost { get; set; }
        public decimal OperatingExpenses { get; set; }
        public decimal Tax { get; set; }
    }

   
}