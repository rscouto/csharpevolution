namespace CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;

public interface IOperation
{
    public decimal Calculate(decimal numOne, decimal optionalNumTwo = 0);
}
