using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CsharpEvolution.Tests01.Persistence
{
    public class CalculatorDB
    {
        string connectionString = @"Data Source=BRRIOWN041122\SQLEXPRESS2;Initial Catalog=CalculatorApp;Integrated Security=True";
        public void Something()
        {

        }

        private void Connection(object sender, EventArgs args)
        {
            SqlConnection connection = new(connectionString);

        }
    }
}
