using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPJMD.Models;

namespace SPJMD.Data
{
    public class SPJMDContext : DbContext
    {
        public SPJMDContext (DbContextOptions<SPJMDContext> options)
            : base(options)
        {
        }

        public DbSet<SPJMD.Models.Policial> Policial { get; set; }
    }
}
