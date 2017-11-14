﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class WageDBContext : DbContext
    {
        public DbSet<Wage> Wages { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Profit> Profits { get; set; }
    }
}