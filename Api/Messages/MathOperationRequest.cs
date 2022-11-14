using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using FluentValidation;

namespace Api.Messages;

public class MathOperationRequest
{
    public string MathOperation { get; set; }
    public decimal NumOne { get; set; }
    public decimal NumTwo { get; set; }
}

public sealed class MathOperationRequestValidator : AbstractValidator<MathOperationRequest>
{
    public MathOperationRequestValidator()
    {
        RuleFor(x => x.MathOperation).NotEmpty();

        RuleFor(x => x.NumOne).NotEmpty();

        RuleFor(x => x.NumTwo).NotEmpty();
    }
}
