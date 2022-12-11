using CsharpEvolution.Tests01.Domain.MathOperations.Enums;

namespace CsharpEvolution.Tests01.Domain.Entities.Messages;

public class GetPerformedOperationResponse
{

    public int Id { get; set; }

    public string MathOperation { get; set; }

    public decimal NumOne { get; set; }
    public decimal NumTwo { get; set; }
    public decimal Result { get; set; }
}
