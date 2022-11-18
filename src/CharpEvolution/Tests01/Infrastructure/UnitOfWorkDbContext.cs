using System;

namespace CsharpEvolution.Tests01.Persistence
{
    public interface IUnitOfWork
    {
        IPerformedOperationRepository DbContextRepository { get; }
        //IDbConnector DbConnector { get; set; }

        void BeginTransaction();
        void Commit();
        void RollBack();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        //public IDbConnector DbConnector { get; set; }
        public IPerformedOperationRepository DbContextRepository { get; }

        private readonly PerformedOperationContext _operationContext;
        private bool disposed = false;

        public UnitOfWork(PerformedOperationContext operationContext, IPerformedOperationRepository dbContextCalculatorRepository)
        {
            _operationContext = operationContext;
            DbContextRepository = dbContextCalculatorRepository;
        }


        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            _operationContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _operationContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }
    }
}
