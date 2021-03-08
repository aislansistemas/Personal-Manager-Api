using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Context
{
    public class PersonalManagerContext : IdentityDbContext
    {
        public PersonalManagerContext(DbContextOptions<PersonalManagerContext> options) : base(options){ }

        public DbSet<PersonalFinance> PersonalFinances { get; set; }
        public DbSet<ControlPoint> ControlPoints { get; set; }
    }
}
