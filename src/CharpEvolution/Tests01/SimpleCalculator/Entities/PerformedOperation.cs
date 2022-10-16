namespace CsharpEvolution.Tests01.SimpleCalculator.Entities;

public class PerformedOperation
{
    public PerformedOperation(string mathOperation, long numOne, long? numTwo, long result)
    {
        MathOperation = mathOperation;
        NumOne = numOne;
        NumTwo = numTwo;
        Result = result;
    }
    
    public string MathOperation { get; set; }
    public long NumOne { get; set; }
    public long? NumTwo { get; set; }
    public long Result { get; set; }
}
