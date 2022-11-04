﻿using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace CsharpEvolution.Tests01.Persistence
{
    public class PerformedOperationContext : DbContext
    {
        public PerformedOperationContext() : base()
        {

        }
        //TODO descobrir pq Operations dá como 'Invalid object name 'Operations''
        public DbSet<PerformedOperation> Operations { get; set; }

        string connectionString = @"Data Source=BRRIOWN041122\SQLEXPRESS2;Initial Catalog=CalculatorAppDBContext;Integrated Security=True";//@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var modelBuilder = new ModelBuilder(); 
            modelBuilder.Entity<PerformedOperation>(p =>
                {
                    p.HasKey(p => p.Id);
                });
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}