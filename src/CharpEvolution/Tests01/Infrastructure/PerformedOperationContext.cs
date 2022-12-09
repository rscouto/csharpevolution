using CsharpEvolution.Tests01.Domain.MathOperations.Enums;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CsharpEvolution.Tests01.Persistence
{
    public class PerformedOperationContext : DbContext
    {
        public PerformedOperationContext() : base()
        {

        }

        public DbSet<PerformedOperation> Operations { get; set; }

        string connectionString = @"Data Source=BRRIOWN041122\SQLEXPRESS2;Initial Catalog=CalculatorAppDBContext;Integrated Security=True";//@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var modelBuilder = new ModelBuilder();
            modelBuilder.Entity<PerformedOperation>(p =>
                {
                    p.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

                    p.HasKey(p => p.Id);

                    p.Property(p => p.MathOperation)
                    .HasConversion(
                        o => o.ToString(),
                        o => (MathOperation)Enum.Parse(typeof(MathOperation), o));

                    p.Property(p => p.NumOne)
                    .HasColumnType("decimal(18,4)")
                    .IsRequired();

                    p.Property(p => p.NumTwo)
                    .HasColumnType("decimal(18,4)")
                    .IsRequired();

                    p.Property(p => p.Result)
                    .HasColumnType("decimal(18,4)")
                    .IsRequired();
                });
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
