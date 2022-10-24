using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CsharpEvolution.Tests01.Persistence;

public interface ICalculatorRepository
{
    void Create(PerformedOperation operation);
}

public class CalculatorRepository : ICalculatorRepository
{
    //private readonly IMongoCollection<PerformedOperation> _collection;
    string connectionString = @"Data Source=BRRIOWN041122\SQLEXPRESS2;Initial Catalog=CalculatorApp;Integrated Security=True";

    //public CalculatorRepository(ICalculatorRepositorySettings settings)
    //{
    //    var client = new MongoClient(settings.ConnectionString);
    //    var database = client.GetDatabase(settings.DataBaseName);

    //    _collection = database.GetCollection<PerformedOperation>(settings.RpgStoreItemInventoryCollectionName);
    //}

    public void Create(PerformedOperation operation)
    {
        try
        {
            SqlConnection connection = new(connectionString);
            connection.Open();
            var query = "INSERT INTO MEMORIADECALCULO(id, MathOperation, NumOne, NumTwo, Result) " +
                "VALUES(DEFAULT, " + operation.MathOperation + ", " + operation.NumOne + ", " + operation.NumTwo + ", " + operation.Result + ")";

            SqlCommand sqlCommand = new(query, connection);
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    public List<PerformedOperation> Get()
    {
        List<PerformedOperation> operations = new();   

        try
        {
            SqlConnection connection = new(connectionString);
            connection.Open();
            var query = "SELECT (id, MathOperation, NumOne, NumTwo, Result) FROM MEMORIADECALCULO " +
                "ORDER BY id DESC)";
            //var query = "SELECT * FROM MEMORIADECALCULO " +
                //"ORDER BY id DESC)";

            SqlCommand sqlCommand = new(query, connection);
            sqlCommand.ExecuteNonQuery();
            return operations;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return operations;

    }
    //public PerformedOperation Create(PerformedOperation operation)
    //{
    //    _collection.InsertOne(operation);
    //    return operation;
    //}

    //public List<PerformedOperation> Find() =>
    //    _collection.Find(item => true).SortByDescending(item => item.Id).ToList();


    //public PerformedOperation FindById(string id)
    //{
    //    PerformedOperation operation = new();
    //    operation = _collection.Find<PerformedOperation>(item => item.Id == int.Parse(id)).FirstOrDefault();
    //    return operation;
    //}

}
