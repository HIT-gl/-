using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ReportDBContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
    }
}