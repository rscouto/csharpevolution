using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace CsharpEvolution.Tests01.Persistence;

public interface ICalculatorRepository
{
    int Create(PerformedOperation operation);
    IEnumerable<PerformedOperation> Find(string operation = null);
}

public class CalculatorRepository : ICalculatorRepository
{
    string connectionString = @"Data Source=BRRIOWN041122\SQLEXPRESS2;Initial Catalog=CalculatorApp;Integrated Security=True";

    

    //TODO aumentar precisão dos decimais no banco
    public int Create(PerformedOperation operation)
    {
        var timer = new Stopwatch();
        timer.Start();

        string sql = @"INSERT INTO MEMORIADECALCULO(MathOperation, NumOne, NumTwo, Result) 
                       VALUES(@MathOperation, @NumOne, @NumTwo, @Result);" +
                      "SELECT @_id = SCOPE_IDENTITY()";
        SqlConnection connection = new(connectionString);
        try
        {
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.Add(new SqlParameter("@MathOperation", operation.MathOperation));
            command.Parameters.Add(new SqlParameter("@NumOne", operation.NumOne));
            command.Parameters.Add(new SqlParameter("@NumTwo", operation.NumTwo));
            command.Parameters.Add(new SqlParameter("@Result", operation.Result));
            command.Parameters.Add("@_id", SqlDbType.Int).Direction = ParameterDirection.Output;

            connection.Open();

            command.ExecuteNonQuery();

            int id = (int)command.Parameters["@_id"].Value;


            connection.Close();

            TimeSpan timeTaken = timer.Elapsed;
            string elapsed = "\nTempo Decorrido: " + timeTaken.ToString(@"m\:ss\.fff") + "\n";
            Console.WriteLine(elapsed);

            return id;
        }

        finally
        {
            connection.Close();
        }
    }
    public IEnumerable<PerformedOperation> Find(string operation = null)
    {
        var operations = new List<PerformedOperation>();
        var timer = new Stopwatch();

        timer.Start();

        var sql = @"SELECT m._id, m.MathOperation, m.NumOne, m.NumTwo, m.Result 
                    FROM MEMORIADECALCULO m 
                    ORDER BY _id DESC;";

        SqlConnection connection = new(connectionString);

        try
        {
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var operationPerformed = new PerformedOperation();

                    operationPerformed.Id = reader.GetInt32("_id");
                    operationPerformed.MathOperation = reader.GetString("MathOperation");
                    operationPerformed.NumOne = reader.GetDecimal("NumOne");
                    operationPerformed.NumTwo = reader.GetDecimal("NumTwo");
                    operationPerformed.Result = reader.GetDecimal("Result");
                    operations.Add(operationPerformed);
                }

                connection.Close();
            }

            TimeSpan timeTaken = timer.Elapsed;
            string elapsed = "\nTempo Decorrido: " + timeTaken.ToString(@"m\:ss\.fff") + "\n";
            Console.WriteLine(elapsed);

            return operations;
        }

        finally
        {
            connection.Close();
        }

        return Enumerable.Empty<PerformedOperation>();

    }
}






