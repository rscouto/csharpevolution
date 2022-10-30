using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

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

        public void Create(PerformedOperation operation)
        {
            using (var db = new PerformedOperationContext())
            {
                // Create and save


                var performedOperation = new PerformedOperation
                {
                    MathOperation = operation.MathOperation,
                    NumOne = operation.NumOne,
                    NumTwo = operation.NumTwo,
                    Result = operation.Result,
                };

                db.Operations.Add(performedOperation);
                db.SaveChanges();
            }
        }

        public void Find(string operation = null)
        {
            using (var db = new PerformedOperationContext())
            {
                // Display all 
                var query = from op in db.Operations
                            orderby op.Id
                            select op;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Id);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }
    }
}
