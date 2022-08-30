namespace CsharpEvolution.Tests01.SimpleCalculator;

public class MathOperationsFactory
{

    public MathOperationsFactory(string mathOperation)
    {
    }

    public long Calculate(string mathOperation, long numOne, long numTwo)
    {
        long result = 0;

        switch (mathOperation)
        {
            case "SOMA":
               result = MathOperationCalculator.CalculateSum(numOne, numTwo);
                
                break;
            case "SUBTRAÇÃO":
                result = MathOperationCalculator.CalculateSubtraction(numOne, numTwo);
                break;
            case "MULTIPLICAÇÃO":
                result = MathOperationCalculator.CalculateMultiplication(numOne, numTwo);
                break;

            case "DIVISÃO":
                result = MathOperationCalculator.CalculateDivision(numOne, numTwo);
                break;
        }

        return result;
    }
}
