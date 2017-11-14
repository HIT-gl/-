using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class InvoiceDBContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
    }
}