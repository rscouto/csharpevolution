using CsharpEvolution.Tests01.SimpleCalculator.Common;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CsharpEvolution.Tests01.Persistence
{
    public interface IDbContextCalculatorRepository
    {
        int Create(PerformedOperation operation);
        IEnumerable<PerformedOperation> Find();
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
            using var _ = this.MeasureTimeCurrentMethod(); 

            _operationContext.Operations.Add(operation);
            //_operationContext.SaveChanges();

            return operation.Id;
        }

        public IEnumerable<PerformedOperation> Find()
        {
            using var _ = this.MeasureTimeCurrentMethod();

            var query = from op in _operationContext.Operations
                        orderby op.Id descending
                        select op;
                      

            var result = query.ToList();

            return result;
        }
    }
}
