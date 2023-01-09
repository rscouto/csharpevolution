using Api.Handlers;
using Api.Messages;
using AutoFixture;
using CsharpEvolution.Tests01.Domain.MathOperations.Enums;
using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Common;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using FluentAssertions;
using Moq;

namespace Calculator.UnitTests;
public class CalculateHandlerTests
{
    private readonly Fixture _fixture;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IUtils> _utilsMock;
    private readonly Mock<IMathOperationFactory> _factoryMock;
    private readonly CalculateHandler _handler;

    public CalculateHandlerTests()
    {
        _fixture = new Fixture();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _utilsMock = new Mock<IUtils>(MockBehavior.Strict);
        _factoryMock = new Mock<IMathOperationFactory>();
        _handler = new CalculateHandler(_unitOfWorkMock.Object, _utilsMock.Object, _factoryMock.Object);
    }

    [InlineData(MathOperation.Addition, 200, -500, -300)]
    [InlineData(MathOperation.Subtraction, -200, -500, -700)]
    [InlineData(MathOperation.Multiplication, 20, 60, 1200)]
    [InlineData(MathOperation.Division, 30, 120, 0.25)]
    [Theory]
    public void Given_request_should_return_correct_result(MathOperation mathOperation, decimal numberOne, decimal numberTwo, decimal result)
    {
        //Arrange

        var request = _fixture.Build<MathOperationRequest>()
            .With(x => x.operation, mathOperation)
            .With(x => x.NumOne, numberOne)
            .With(x => x.NumTwo, numberTwo)
            .Create();

        var operation = _fixture.Build<PerformedOperation>()
            .With(x => x.MathOperation, mathOperation)
            .With(x => x.NumOne, 366)
            .With(x => x.NumTwo, 244)
            .With(x => x.Result, result)
            .Create();

        var expectedResult = result;

        _unitOfWorkMock
            .Setup(x => x.PerformedOperationRepository.Create(It.IsAny<PerformedOperation>()))
            .Returns(operation.Id);

        _factoryMock
            .Setup(x => x.Calculate(operation.MathOperation, operation.NumOne, operation.NumTwo))
            .Returns(expectedResult);

        _utilsMock
            .Setup(x => x.StoreInCache(It.Is<PerformedOperation>(x => x.Id == operation.Id)));

        //Act

        var operationResult = _handler.Handle(request);

        //Assert
        _unitOfWorkMock
            .Verify(x => x.PerformedOperationRepository.Create(It.IsAny<PerformedOperation>()),
            Times.Once);
        result.Should().Be(operation.Result);
    }

    [Fact]
    public void Given_invalid_request_should_return_error()
    {
        //Arrange

        var request = _fixture.Build<MathOperationRequest>()
            .Without(x => x.operation)
            .With(x => x.NumOne, 366)
            .With(x => x.NumTwo, 244)
            .Create();

        var operation = _fixture.Build<PerformedOperation>()
            .Without(x => x.MathOperation)
            .With(x => x.NumOne, 366)
            .With(x => x.NumTwo, 244)
            .With(x => x.Result, 610)
            .Create();

        var expectedResult = 610M;
        var message = "Operação não reconhecida";

        _unitOfWorkMock
            .Setup(x => x.PerformedOperationRepository.Create(It.IsAny<PerformedOperation>()))
            .Returns(operation.Id);

        _factoryMock
            .Setup(x => x.Calculate(request.operation, request.NumOne, request.NumTwo))
            .Throws(new ArgumentException(message));

        _utilsMock
            .Setup(x => x.StoreInCache(It.Is<PerformedOperation>(x => x.Id == operation.Id)));

        //Act

        Action act = () => _handler.Handle(request);

        //Assert

        act.Should().Throw<ArgumentException>()
            .WithMessage(message);

        _unitOfWorkMock.Verify(x => x.PerformedOperationRepository.Create(It.IsAny<PerformedOperation>()),
            Times.Never);
    }
}
