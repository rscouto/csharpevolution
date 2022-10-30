using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

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

        public int CreateV2(PerformedOperation operation)
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

                return performedOperation.Id;
            }
        }

        public void FindV2(string operation = null)
        {
            using (var db = new PerformedOperationContext())
            {
                // Display all 
                var query = from op in db.Operations
                            orderby op.Id descending
                            select op;

                StringBuilder stringWithAllOperations = new StringBuilder();

                foreach (var op in query)
                {
                    Console.WriteLine($"{op.Id}    {op.MathOperation}  " +
                        $"Parâmetros(A = {op.NumOne},   B = {op.NumTwo})    Result:{op.Result}\n");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }
    }
}
