using System;

namespace CsharpEvolution.Tests01.Persistence
{
    public interface IUnitOfWork
    {
        IDbContextCalculatorRepository DbContextRepository { get; }
        ICalculatorRepository CalculatorRepository { get; }
        IDbConnector DbConnector { get; set; }


        void BeginTransaction();
        void Commit();
        void RollBack();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IDbConnector DbConnector { get; set; } 

        private readonly PerformedOperationContext _operationContext;
        private readonly IDbContextCalculatorRepository _dbContextCalculatorRepository;
        private  IDbContextCalculatorRepository _dbCalculatorRepository = null;  
        private  ICalculatorRepository _calculatorRepository = null;
        private bool disposed = false;

        public UnitOfWork(PerformedOperationContext operationContext, IDbContextCalculatorRepository dbContextCalculatorRepository)
        {
            _operationContext = operationContext;
            _dbContextCalculatorRepository = dbContextCalculatorRepository;
        }

        public IDbContextCalculatorRepository DbContextRepository
        {
            get
            {
                if (_dbCalculatorRepository == null)
                {
                    _dbCalculatorRepository = new DbContextCalculatorRepository(_operationContext);
                }
                return _dbCalculatorRepository;
            }
        }

        public ICalculatorRepository CalculatorRepository
        {
            get
            {
                if (_calculatorRepository == null)
                {
                    _calculatorRepository = new CalculatorRepository();
                }
                return _calculatorRepository;
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
