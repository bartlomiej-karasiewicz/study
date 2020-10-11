﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patients.Controllers.Model
{
    public class DpDataContext: DbContext
    {
        public DpDataContext(DbContextOptions options) : base(options) { 
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
