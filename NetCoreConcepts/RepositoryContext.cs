using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreConcepts;

namespace NetCoreConcepts
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasOne(p => p.EmployeeDetail)
                .WithOne(p => p.Employee)
                .HasForeignKey<Employee>(p => p.Id);
            builder.Entity<EmployeeDetail>()
                .HasOne(p => p.Employee)
                .WithOne(p => p.EmployeeDetail)
                .HasForeignKey<EmployeeDetail>(p => p.Id);
            builder.Entity<Employee>().ToTable("Employee");

            base.OnModelCreating(builder);
            builder
                .Entity<Rider>()
                .Property(e => e.Mount)
                .HasConversion(
                    v => v.ToString(),
                    v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));
        }

        public DbSet<Employee> Employee { get; set; }

        
    }
}
