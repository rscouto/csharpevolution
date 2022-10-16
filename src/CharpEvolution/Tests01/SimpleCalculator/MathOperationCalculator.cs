using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;

namespace CsharpEvolution.Tests01.SimpleCalculator;

public class MathOperationCalculator
{
    private readonly IOperation _mathOperation;
    public MathOperationCalculator(string operation, IOperation mathOperation)
    {
        _mathOperation = mathOperation;
    }

    public long Calculate(string mathOperation, long numOne, long numTwo)
    {
        return _mathOperation.Calculate(numOne, numTwo);
    }
}
