using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using FluentValidation;

namespace Api.Messages;

public class MathOperationRequest
{
    public OperationType MathOperation { get; set; }
    public decimal NumOne { get; set; }
    public decimal NumTwo { get; set; }
}

public sealed class MathOperationRequestValidator : AbstractValidator<MathOperationRequest>
{
    public const int FindRangeLimitInDays = 30;

    public MathOperationRequestValidator()
    {
        RuleFor(x => x.MathOperation)
            .NotEmpty()
            .IsInEnum();

        RuleFor(x => x.NumOne).NotEmpty();

        RuleFor(x => x.NumTwo).NotEmpty();
    }
}
