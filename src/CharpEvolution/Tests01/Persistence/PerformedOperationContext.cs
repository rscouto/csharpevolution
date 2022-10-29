using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolution.Tests01.Persistence
{
    public class PerformedOperationContext : DbContext
    {
        public DbSet<PerformedOperation> Operations { get; set; }
        string connectionString = @"Data Source=BRRIOWN041122\SQLEXPRESS2;Initial Catalog=CalculatorApp;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
