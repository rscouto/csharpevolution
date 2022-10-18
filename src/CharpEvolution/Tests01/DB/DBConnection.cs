using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolution.Tests01.DB;

public sealed class DBConnection : DbConnection
{
    public override string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override string Database => throw new NotImplementedException();

    public override string DataSource => throw new NotImplementedException();

    public override string ServerVersion => throw new NotImplementedException();

    public override ConnectionState State => throw new NotImplementedException();

    public override void ChangeDatabase(string databaseName)
    {
        throw new NotImplementedException();
    }

    public override void Close()
    {
        throw new NotImplementedException();
    }

    public override void Open()
    {
        throw new NotImplementedException();
    }

    protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
    {
        throw new NotImplementedException();
    }

    protected override DbCommand CreateDbCommand()
    {
        throw new NotImplementedException();
    }
}

    //private static void ReadOrderData(string connectionString)
    //{
        //string queryString =
            //"SELECT OrderID, CustomerID FROM dbo.Orders;";
            //"SELECT operation, paramA, paramB, result FROM operations INNER JOIN 'table2' ON operation.id = 'table2.id' ORDER BY operations.date descending; 
        //using (SqlConnection connection = new SqlConnection(
                   //connectionString))
        //{
            //SqlCommand command = new SqlCommand(
                //queryString, connection);
            //connection.Open();
        //}

//INNER - Matches only
//LEFT - Completes right side w/ null in no matches
//RIGHT - Completes left side w/ null if no matches
//FULL (also OUTER FULL) - Includes all and missing info are completed with null on both sides
