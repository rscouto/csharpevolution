using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolution.Tests01.Persistence
{
    public interface IDbConnector : IDisposable
    {
        IDbConnection _connection { get; set; }
        IDbTransaction _transaction { get; set; }    

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
