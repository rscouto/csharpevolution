using Api.Handlers;
using Api.Messages;
using AutoFixture;
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
    private readonly Mock<IUnitOfWorkDbContext> _unitOfWork;
    private readonly Mock<IUtils> _utilsMock;
    private readonly Mock<IMathOperationFactory> _factoryMock;
    private readonly CalculateHandler _handler;

    public CalculateHandlerTests()
    {
        _fixture = new Fixture();
        _unitOfWork = new Mock<IUnitOfWorkDbContext>();
        _utilsMock = new Mock<IUtils>(MockBehavior.Strict);
        _factoryMock = new Mock<IMathOperationFactory>(MockBehavior.Strict);
        _handler = new CalculateHandler(_unitOfWork.Object, _utilsMock.Object, _factoryMock.Object);
    }

    [Fact]
    public void Given_request_should_return_correct_result()
    {
        //Arrange

        var request = _fixture.Build<MathOperationRequest>()
            .With(x => x.MathOperation, "soma")
            .With(x => x.NumOne, 366)
            .With(x => x.NumTwo, 244)
            .Create();

        var operation = _fixture.Build<PerformedOperation>()
            .With(x => x.MathOperation, "soma")
            .With(x => x.NumOne, 366)
            .With(x => x.NumTwo, 244)
            .With(x => x.Result, 610)
            .Create();

        var expectedResult = 610M;

        _unitOfWork.Setup(x => x.DbContextRepository.Create(It.IsAny<PerformedOperation>()))
            .Returns(operation.Id);

        _factoryMock.Setup(x => x.Calculate(operation.MathOperation, operation.NumOne, operation.NumTwo))
            .Returns(expectedResult);

        _utilsMock.Setup(x => x.StoreInCache(It.Is<PerformedOperation>(x => x.Id == operation.Id)));

        //Act

        var result = _handler.Handle(request);

        //Assert
        _unitOfWork.Verify(x => x.DbContextRepository.Create(It.IsAny<PerformedOperation>()),
            Times.Once);
        result.Should().Be(operation.Result);
    }

    [Fact]
    public void Given_invalid_request_should_return_error()
    {
        //Arrange

        var request = _fixture.Build<MathOperationRequest>()
            .Without(x => x.MathOperation)
            .With(x => x.NumOne, 366)
            .With(x => x.NumTwo, 244)
            .Create();

        var operation = _fixture.Build<PerformedOperation>()
            .With(x => x.MathOperation, "soma")
            .With(x => x.NumOne, 366)
            .With(x => x.NumTwo, 244)
            .With(x => x.Result, 610)
            .Create();

        var expectedResult = 610M;
        var message = "Operação não reconhecida";

        _unitOfWork.Setup(x => x.DbContextRepository.Create(It.IsAny<PerformedOperation>()))
            .Returns(operation.Id);

        _factoryMock.Setup(x => x.Calculate(operation.MathOperation, operation.NumOne, operation.NumTwo))
            .Throws(new ArgumentException(message));

        _utilsMock.Setup(x => x.StoreInCache(It.Is<PerformedOperation>(x => x.Id == operation.Id)));

        //Act

        var result = _handler.Handle(request);

        //Assert
        _unitOfWork.Verify(x => x.DbContextRepository.Create(It.IsAny<PerformedOperation>()),
            Times.Never);
        
        //result.Should().Be(operation.Result);
    }

}
