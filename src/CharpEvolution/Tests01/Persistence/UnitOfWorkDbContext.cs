using System;

namespace CsharpEvolution.Tests01.Persistence
{
    public interface IUnitOfWorkDbContext
    {
        IDbContextCalculatorRepository DbContextRepository { get; }
        IDbConnector DbConnector { get; set; }

        void BeginTransaction();
        void Commit();
        void RollBack();
    }

    public class UnitOfWorkDbContext : IUnitOfWorkDbContext, IDisposable
    {
        public IDbConnector DbConnector { get; set; }

        private readonly PerformedOperationContext _operationContext;
        private IDbContextCalculatorRepository _dbContextCalculatorRepository;
        private bool disposed = false;

        public UnitOfWorkDbContext(PerformedOperationContext operationContext, IDbContextCalculatorRepository dbContextCalculatorRepository)
        {
            _operationContext = operationContext;
            _dbContextCalculatorRepository = dbContextCalculatorRepository;
        }

        public IDbContextCalculatorRepository DbContextRepository
        {
            get
            {
                if (_dbContextCalculatorRepository == null)
                {
                    _dbContextCalculatorRepository = new DbContextCalculatorRepository(_operationContext);
                }
                return _dbContextCalculatorRepository;
            }
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
