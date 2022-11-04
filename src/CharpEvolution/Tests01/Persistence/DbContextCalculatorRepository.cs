using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolution.Tests01.Persistence
{
    public interface IDbContextCalculatorRepository
    {
        int Create(PerformedOperation operation);
        IEnumerable<PerformedOperation> Find(string operation = null);
    }

    public class DbContextCalculatorRepository : IDbContextCalculatorRepository

    {
        private readonly PerformedOperationContext _operationContext;

        public DbContextCalculatorRepository(PerformedOperationContext operationContext)
        {
            _operationContext = operationContext;
        }

        public int Create(PerformedOperation operation)
        {
            var timer = new Stopwatch();
            timer.Start();

            // Create and save
            var performedOperation = new PerformedOperation
            {
                MathOperation = operation.MathOperation,
                NumOne = operation.NumOne,
                NumTwo = operation.NumTwo,
                Result = operation.Result,
            };

            _operationContext.Operations.Add(performedOperation);
            _operationContext.SaveChanges();

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string elapsed = "\nTempo Decorrido: " + timeTaken.ToString(@"m\:ss\.fff") + "\n";
            Console.WriteLine(elapsed);

            return performedOperation.Id;
        }

        public IEnumerable<PerformedOperation> Find(string operation = null)
        {
            var timer = new Stopwatch();
            timer.Start();
            var operations = new List<PerformedOperation>();

            var query = from op in _operationContext.Operations
                        orderby op.Id descending
                        select op;

            foreach (var op in query)
            {
                Console.WriteLine($"{op.Id}    {op.MathOperation}  " +
                    $"Parâmetros(A = {op.NumOne},   B = {op.NumTwo})    Result:{op.Result}\n");
                operations.Add(op);
            }

            if (operations.Count > 0)
                return operations;

            return Enumerable.Empty<PerformedOperation>();

            TimeSpan timeTaken = timer.Elapsed;
            string elapsed = "\nTempo Decorrido: " + timeTaken.ToString(@"m\:ss\.fff") + "\n";
            Console.WriteLine(elapsed);

            Console.ReadKey();
        }
    }
}
