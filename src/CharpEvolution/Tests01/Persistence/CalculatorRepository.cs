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
    int CreateV2(PerformedOperation operation);
    IEnumerable<PerformedOperation> Find();
    void FindV2(string operation = null);
}

public class CalculatorRepository : ICalculatorRepository
{
    string connectionString = @"Data Source=BRRIOWN041122\SQLEXPRESS2;Initial Catalog=CalculatorApp;Integrated Security=True";

    public int CreateV2(PerformedOperation operation)
    {
        using (var db = new PerformedOperationContext())
        {
            var timer = new Stopwatch();
            timer.Start();

            // Create and save
            var performedOperation = new PerformedOperation
            {
                MathOperation = operation.MathOperation,
                NumOne = operation.NumOne,
                NumTwo = operation.NumTwo,
                Result = operation.Result,
            };

            db.Operations.Add(performedOperation);
            db.SaveChanges();

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string elapsed = "\nTempo Decorrido: " + timeTaken.ToString(@"m\:ss\.fff") + "\n";
            Console.WriteLine(elapsed); 
            return performedOperation.Id;
        }
    }

    public void FindV2(string operation = null)
    {
        using (var db = new PerformedOperationContext())
        {
            // Display all 
            var timer = new Stopwatch();
            timer.Start();

            var query = from op in db.Operations
                        orderby op.Id descending
                        select op;

            foreach (var op in query)
            {
                Console.WriteLine($"{op.Id}    {op.MathOperation}  " +
                    $"Parâmetros(A = {op.NumOne},   B = {op.NumTwo})    Result:{op.Result}\n");
            }

            TimeSpan timeTaken = timer.Elapsed;
            string elapsed = "\nTempo Decorrido: " + timeTaken.ToString(@"m\:ss\.fff") + "\n";
            Console.WriteLine(elapsed);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
    public int Create(PerformedOperation operation)
    {
        var timer = new Stopwatch();
        timer.Start();

        string sql = "INSERT INTO MEMORIADECALCULO(MathOperation, NumOne, NumTwo, Result) VALUES(@MathOperation, @NumOne, @NumTwo, @Result);" +
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
    //TODO Arrumar esse método Find
    public IEnumerable<PerformedOperation> Find()
    {
        List<PerformedOperation> operations = new();
        PerformedOperation operation = new();
        var timer = new Stopwatch();

        timer.Start();

        var sql = "SELECT m.@_id = SCOPE_IDENTITY(), m.MathOperation, m.NumOne, m.NumTwo, m.Result FROM MEMORIADECALCULO m ORDER BY _id DESC;";
        SqlConnection connection = new(connectionString);

        try
        {
            SqlCommand command = new SqlCommand(sql, connection);



            //command.Parameters.Add("{_id}");//isso aqui tá dando erro
            command.Parameters.Add("@MathOperation");
            command.Parameters.Add("@NumOne");
            command.Parameters.Add("@NumTwo");
            command.Parameters.Add("@Result");
            command.Parameters.Add("@_id", SqlDbType.Int).Direction = ParameterDirection.Output;
            //command.Parameters.Add("@MathOperation", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
            //command.Parameters.Add("@NumOne", SqlDbType.Decimal).Direction = ParameterDirection.Output;
            //command.Parameters.Add("@NumTwo", SqlDbType.Decimal).Direction = ParameterDirection.Output;
            //command.Parameters.Add("@Result", SqlDbType.Decimal).Direction = ParameterDirection.Output;

            connection.Open();

            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    operation.Id = (int)command.Parameters["@_id"].Value;
                    operation.MathOperation = (string)command.Parameters["@MathOperation"].Value;
                    operation.NumOne = (decimal)command.Parameters["@NumOne"].Value;
                    operation.NumTwo = (decimal)command.Parameters["@NumTwo"].Value;
                    operation.Result = (decimal)command.Parameters["@Result"].Value;
                    operations.Add(operation);
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






