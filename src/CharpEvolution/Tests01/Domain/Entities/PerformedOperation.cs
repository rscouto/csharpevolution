using CsharpEvolution.Tests01.Domain.MathOperations.Enums;

namespace CsharpEvolution.Tests01.SimpleCalculator.Entities;

public class PerformedOperation
{
    public PerformedOperation()
    {
    }

    public PerformedOperation(MathOperation mathOperation, decimal numOne, decimal numTwo, decimal result)
    {
        MathOperation = mathOperation;
        NumOne = numOne;
        NumTwo = numTwo;
        Result = result;
    }

    public int Id { get; set; }
    public MathOperation MathOperation { get; set; }
    public decimal NumOne { get; set; }
    public decimal NumTwo { get; set; }
    public decimal Result { get; set; }
}
