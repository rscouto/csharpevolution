using System.ComponentModel;

namespace CsharpEvolution.Tests01.SimpleCalculator.Entities;

public enum OperationType
{
    [Description("soma")]
    addition = 1,

    [Description("subtração")]
    subtraction = 2,

    [Description("multiplicação")]
    multiplication = 3,

    [Description("divisão")]
    division = 4,
}
