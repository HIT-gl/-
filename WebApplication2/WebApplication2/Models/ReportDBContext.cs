using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class ReportDBContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Profit> Profits { get; set; }
        public DbSet<Wage> Wages { get; set; }
    }
}