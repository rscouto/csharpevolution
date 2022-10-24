using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolution.Tests01.Persistence
{
    public class CalculatorRepositorySettings : ICalculatorRepositorySettings
    {
        public string RpgStoreItemInventoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
