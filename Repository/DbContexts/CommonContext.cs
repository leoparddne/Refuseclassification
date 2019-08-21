using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DbContexts
{
    public class CommonContext : DbContext
    {
        public CommonContext( DbContextOptions<CommonContext> options) : base(options)
        {
        }

        public DbSet<record> record { get; set; }
        public DbSet<recordType> recordType { get; set; }

    }
}
