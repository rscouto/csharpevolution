using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolution.Tests01.Persistence
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PerformedOperationContext _operationContext;

        public UnitOfWork(PerformedOperationContext operationContext)
        {
            _operationContext = operationContext;
        }

        public void Commit()
        {
            _operationContext.SaveChanges();
        }

        public void RollBack()
        {
            
        }

    }
}
