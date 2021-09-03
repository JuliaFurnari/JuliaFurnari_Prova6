using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Day6.Core.Models;

namespace Week6Day6.EF
{
    class InsuranceContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Policy> Policies { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
		    Database=Insurance;Trusted_Connection=True;");
        }
    }
}
